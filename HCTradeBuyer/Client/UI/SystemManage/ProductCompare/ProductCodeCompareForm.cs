/*****************************************************************************
创 建 人:	yanbing
创建日期:	2007-9-28
功能描述:	查看产品编码对照
 ********************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Model.His;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Client.BLL.His.Product;
using Emedchina.TradeAssistant.Client.Common;
using DevExpress.XtraEditors;

namespace Emedchina.TradeAssistant.Client.His.Product
{
    public partial class ProductCodeCompareForm : BaseForm
    {
        #region 变量定义区
        private DataTable dtCompare;
        private DataTable CommListDt;
        bool isdelete;
        private bool flag = true;
        private Thread thread;
        #endregion

        #region 构造函数
        public ProductCodeCompareForm()
        {
            InitializeComponent();            
            
            //查询
            //thread = new Thread(new ThreadStart(ShowWaiting));
            //thread.Start();

            IniData();

            //thread.Abort();
        }
        #endregion

        #region 页面加载
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductCodeCompareForm_Load(object sender, EventArgs e)
        {
            //初始化状态
            //InitCmbState();
            this.CmbIsMap.Text = "全部";
            this.CmbProcessFlag.Text = "全部";


        }
        #endregion

        //未使用注释
        //#region 显示等待窗体
        //private void ShowWaiting()
        //{
        //    LoadDataWaiting frm = new LoadDataWaiting("");
        //    frm.ShowDialog();
        //}
        //#endregion

        #region 查询按钮事件
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dtCompare = null;
            IniData();
            this.Filter();
        }
        #endregion

        #region 查询事件
        /// <summary>
        /// 查询数据
        /// </summary>
        private void IniData()
        {
            int index, size;
          
            //查询总的数据集
            if (dtCompare == null)
            {
                dtCompare = ProductCodeCompareBLL.GetInstance().GetCommList();
            }
            //CommListDt = ProductCodeCompareBLL.GetInstance("ClientDB").GetGpoHitCommList();
            if (dtCompare == null)
                return;

            base.InitFromCacheByData(dtCompare);
            this.bindingSource1.DataSource = dtCompare.DefaultView;
           

        }

        #endregion

        #region 获取对接产品对照表对象
        /// <summary>
        /// 获取对接产品对照表对象
        /// </summary>
        private Gpo_Product_MapModel GpoProductMapModel()
        {
            Gpo_Product_MapModel product_MapModel = new Gpo_Product_MapModel();
            product_MapModel.FactoryName = this.tbxproducter.Text.Trim();       //生产企业
            product_MapModel.MedicaName = this.tbxmedicalname.Text.Trim();     //产品名称
            product_MapModel.IsMap = this.CmbIsMap.SelectedItem.ToString();           //匹配状态
            product_MapModel.ProcessFlag = this.CmbProcessFlag.SelectedItem.ToString();     //处理状态
            product_MapModel.ProductCode = this.txtHisCode.Text.Trim();         //HIS产品编码

            return product_MapModel;
        }
        #endregion

        #region 翻页事件
        private void pageNavigator1_PageIndexOrPageSizeChanged(object source, Emedchina.Commons.WinForms.PageChangedEventArgs e)
        {
            IniData();
        }
        #endregion

        #region 查看对照
        private void btnSeeCompare_Click(object sender, EventArgs e)
        {
            ProductCodeCompareQueryForm frm = new ProductCodeCompareQueryForm();
            //if (this.CommListDt == null)
            //{
            //    CommListDt = ProductCodeCompareBLL.GetInstance("ClientDB").GetGpoHitCommList();
            //}
            //frm.commDT = this.CommListDt.Copy();
            frm.ShowDialog();
        }
        #endregion

        #region 新增
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.CommListDt == null)
            {
                CommListDt = ProductCodeCompareBLL.GetInstance().GetGpoHitCommList();
            }

            ProductCodeForm frm = new ProductCodeForm();
            frm.CommListDt = this.CommListDt.Copy();
            frm.IsAdd = true;
            frm.ShowDialog();

            if (frm.strID == null)
                return;

            //更新DataTable
            frm.productmapitemOper.ID = frm.strID;
            UpdateDtCompare(frm.productmapitemOper);

            //重新绑定数据
            IniData();
        }
        #endregion

        #region 取消匹配
        private void btnCancleMatch_Click(object sender, EventArgs e)
        {
            DataRow drow = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (drow != null)
            {
                if (XtraMessageBox.Show("确认取消匹配关系？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Gpo_Product_MapModel productmapitem = new Gpo_Product_MapModel();
                    string strId = drow["ID"].ToString();
                    //productmapitem.ProductID = this.dgvProIDCompare.CurrentRow.Cells["PRODUCT_ID"].Value.ToString();
                    //string ProductCode = this.dgvProIDCompare.CurrentCell == null ? "" : this.dgvProIDCompare.CurrentRow.Cells["PRODUCT_CODE"].Value.ToString();
                    //取消匹配
                    bool flag = ProductCodeCompareBLL.GetInstance().CancelComparion(strId);

                    if (flag == true)
                    {
                        DataColumn[] keys = new DataColumn[1];
                        DataColumn myColumn = new DataColumn();
                        keys[0] = this.dtCompare.Columns["ID"];
                        this.dtCompare.PrimaryKey = keys;
                        DataRow dr = dtCompare.Rows.Find(strId);

                        dr["IsMap"] = "0";
                        dr["Is_Map"] = "未匹配";
                        dr["PROJECT_PROD_ID"] = "0";

                        IniData();
                    }
                    //原foreach
                    //foreach (DataGridViewRow row in this.dgvProIDCompare.Rows)
                    //{
                    //    if (row.Cells["ID"].Value.ToString() == strId)
                    //    {
                    //        this.dgvProIDCompare.CurrentCell = this.dgvProIDCompare["ID", row.Index];
                    //    }
                    //}

                    //修改如下
                    for (int i = 0; i < this.gridView3.RowCount; i++)
                    {
                        DataRow drrow = gridView3.GetDataRow(i);
                        if (drrow["ID"].ToString() == strId)
                        {
                            this.gridView3.FocusedRowHandle = i;
                        }
                    }

                    XtraMessageBox.Show("匹配关系已取消！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region 修改
        private void btnModify_Click(object sender, EventArgs e)
        {
            DataRow drow = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (drow != null)
            {
                if (this.CommListDt == null)
                {
                    CommListDt = ProductCodeCompareBLL.GetInstance().GetGpoHitCommList();
                }

                ProductCodeForm frm = new ProductCodeForm();
                frm.CommListDt = this.CommListDt.Copy();
                frm.IsAdd = false;
                frm.productid = drow["PROJECT_PROD_ID"].ToString().Trim();
                frm.mODEL_ID = drow["HH_MODE_ID"].ToString().Trim();
                frm.sPEC_ID = drow["HH_SPEC_ID"].ToString().Trim();
                int currentrowindex = gridView3.FocusedRowHandle;
                frm.productcode = drow == null ? "" : drow["HIS_PRODUCT_ID"].ToString();
                frm.strID = drow == null ? "" : drow["ID"].ToString();
                frm.ShowDialog();

                if (frm.productmapitemOper == null)
                    return;

                //更新DataTable
                UpdateDtCompare(frm.productmapitemOper);

                //重新绑定数据
                IniData();

                //foreach (DataGridViewRow row in this.dgvProIDCompare.Rows)
                //{
                //    if (row.Cells["PRODUCT_CODE"].Value.ToString() == frm.productcode)
                //    {
                //        this.dgvProIDCompare.CurrentCell = this.dgvProIDCompare["PRODUCT_CODE", row.Index];
                //    }
                //}

                for (int i = 0; i < this.gridView3.RowCount; i++)
                {
                    DataRow drrow = gridView3.GetDataRow(i);
                    if (drrow["PROJECT_PROD_ID"].ToString() == drow["PROJECT_PROD_ID"] && drrow["HH_MODE_ID"].ToString() == drow["HH_MODE_ID"] && drrow["HH_SPEC_ID"].ToString() == drow["HH_SPEC_ID"])
                    {
                        this.gridView3.FocusedRowHandle = i;
                    }
                }
            }
        }
        #endregion

        #region 更新DT操作
        private void UpdateDtCompare(Gpo_Product_MapModel productmapitemOper)
        {
            if (CommListDt != null)
            {
                DataColumn[] keys = new DataColumn[1];

                DataColumn myColumn = new DataColumn();

                keys[0] = this.dtCompare.Columns["ID"];

                this.dtCompare.PrimaryKey = keys;

                DataRow dr = dtCompare.Rows.Find(productmapitemOper.ID);

                if (dr == null)
                {
                    DataRow drnew = this.dtCompare.NewRow();
                    
                    drnew["ID"] = productmapitemOper.ID;

                    drnew["his_product_ID"] = productmapitemOper.ProductCode;
                    drnew["PROJECT_PROD_ID"] = productmapitemOper.ProductID;
                    drnew["HH_MODE_ID"] = productmapitemOper.HH_Mode_ID;
                    drnew["HH_SPEC_ID"] = productmapitemOper.HH_Spec_ID;

                    drnew["COMMON_NAME"] = string.IsNullOrEmpty(productmapitemOper.CommonName) ? "-" : productmapitemOper.CommonName;
                    drnew["PRODUCT_NAME"] = string.IsNullOrEmpty(productmapitemOper.Product_Name) ? "-" : productmapitemOper.Product_Name;
                    drnew["COMMERCE_NAME"] = string.IsNullOrEmpty(productmapitemOper.CommerceName) ? "-" : productmapitemOper.CommerceName;

                    drnew["BRAND"] = string.IsNullOrEmpty(productmapitemOper.Brand) ? "-" : productmapitemOper.Brand;

                    //drnew["HISPRODUCT_NAME"] = productmapitemOper.CommonName + "(" + productmapitemOper.Product_Name + ")";
                    drnew["MODE_ID"] = productmapitemOper.Mode_ID;
                    drnew["MODE_NAME"] = string.IsNullOrEmpty(productmapitemOper.Mode_Name) ? "-" : productmapitemOper.Mode_Name;

                    drnew["SPEC_ID"] = productmapitemOper.Spec_Unit_Id;
                    drnew["SPEC"] = string.IsNullOrEmpty(productmapitemOper.Spec_Unit) ? "-" : productmapitemOper.Spec_Unit;

                    if (!string.IsNullOrEmpty(productmapitemOper.Stand_Rate))
                    {
                        drnew["STAND_RATE"] = productmapitemOper.Stand_Rate;
                    }
                    else
                    {
                        drnew["STAND_RATE"] = "-";
                    }

                    drnew["BASE_MEASURE"] = string.IsNullOrEmpty(productmapitemOper.Base_measure) ? "-" : productmapitemOper.Base_measure;
                    drnew["BASE_MEASURE_SPEC"] = string.IsNullOrEmpty(productmapitemOper.Base_measure_spec) ? "-" : productmapitemOper.Base_measure_spec;
                    drnew["BASE_MEASURE_MATE"] = string.IsNullOrEmpty(productmapitemOper.Base_measure_mate) ? "-" : productmapitemOper.Base_measure_mate;


                 
                    drnew["FACTORY_CODE"] = productmapitemOper.Factory_Code;
                    drnew["FACTORY_NAME"] = string.IsNullOrEmpty(productmapitemOper.Factory_Name) ? "-" : productmapitemOper.Factory_Name;

                    drnew["SALER_CODE"] = productmapitemOper.Saler_Code;
                    drnew["SALER_NAME"] = productmapitemOper.Saler_Name;

                    drnew["SENDER_CODE"] = productmapitemOper.Sender_Code;
                    drnew["SENDER_NAME"] = string.IsNullOrEmpty(productmapitemOper.Sender_Name) ? "-" : productmapitemOper.Sender_Name;

                    drnew["STOCK_ID"] = productmapitemOper.Stock_Id;
                    drnew["STOCK_NAME"] = productmapitemOper.Stock_Name;


                    drnew["REMARK"] = string.IsNullOrEmpty(productmapitemOper.Remark) ? "-" : productmapitemOper.Remark;

                    drnew["IsMap"] = productmapitemOper.IsMap;

                    if (productmapitemOper.IsMap.Equals("1"))
                    {
                        drnew["Is_Map"] = "已匹配";
                        drnew["PROJECT_PROD_ID"] = productmapitemOper.ProductID;
                    }
                    else
                    {
                        drnew["Is_Map"] = "未匹配";
                        drnew["PROJECT_PROD_ID"] = "";
                    }

                    drnew["PROCESS_FLAG"] = productmapitemOper.ProcessFlag;

                    if (productmapitemOper.ProcessFlag.Equals("1"))
                        drnew["Is_Process_flag"] = "已处理";
                    else
                        drnew["Is_Process_flag"] = "未处理";

                    dtCompare.Rows.Add(drnew);
                }
                else
                {
                    dr["his_product_ID"] = productmapitemOper.ProductCode;
                    dr["PROJECT_PROD_ID"] = productmapitemOper.ProductID;
                    dr["HH_MODE_ID"] = productmapitemOper.HH_Mode_ID;
                    dr["HH_SPEC_ID"] = productmapitemOper.HH_Spec_ID;


                    dr["COMMON_NAME"] = string.IsNullOrEmpty(productmapitemOper.CommonName) ? "-" : productmapitemOper.CommonName;
                    dr["PRODUCT_NAME"] = string.IsNullOrEmpty(productmapitemOper.Product_Name) ? "-" : productmapitemOper.Product_Name;
                    dr["COMMERCE_NAME"] = string.IsNullOrEmpty(productmapitemOper.CommerceName) ? "-" : productmapitemOper.CommerceName;

                    dr["BRAND"] = string.IsNullOrEmpty(productmapitemOper.Brand) ? "-" : productmapitemOper.Brand;

                    //drnew["HISPRODUCT_NAME"] = productmapitemOper.CommonName + "(" + productmapitemOper.Product_Name + ")";
                    dr["MODE_ID"] = productmapitemOper.Mode_ID;
                    dr["MODE_NAME"] = string.IsNullOrEmpty(productmapitemOper.Mode_Name) ? "-" : productmapitemOper.Mode_Name;

                    dr["SPEC_ID"] = productmapitemOper.Spec_Unit_Id;
                    dr["SPEC"] = string.IsNullOrEmpty(productmapitemOper.Spec_Unit) ? "-" : productmapitemOper.Spec_Unit;

                    if (!string.IsNullOrEmpty(productmapitemOper.Stand_Rate))
                    {
                        dr["STAND_RATE"] = productmapitemOper.Stand_Rate;
                    }
                    else
                    {
                        dr["STAND_RATE"] = "-";
                    }


                    dr["BASE_MEASURE"] = string.IsNullOrEmpty(productmapitemOper.Base_measure) ? "-" : productmapitemOper.Base_measure;
                    dr["BASE_MEASURE_SPEC"] = string.IsNullOrEmpty(productmapitemOper.Base_measure_spec) ? "-" : productmapitemOper.Base_measure_spec;
                    dr["BASE_MEASURE_MATE"] = string.IsNullOrEmpty(productmapitemOper.Base_measure_mate) ? "-" : productmapitemOper.Base_measure_mate;



                    dr["FACTORY_CODE"] = productmapitemOper.Factory_Code;
                    dr["FACTORY_NAME"] = string.IsNullOrEmpty(productmapitemOper.Factory_Name) ? "-" : productmapitemOper.Factory_Name;

                    dr["SALER_CODE"] = productmapitemOper.Saler_Code;
                    dr["SALER_NAME"] = productmapitemOper.Saler_Name;

                    dr["SENDER_CODE"] = productmapitemOper.Sender_Code;
                    dr["SENDER_NAME"] = string.IsNullOrEmpty(productmapitemOper.Sender_Name) ? "-" : productmapitemOper.Sender_Name;

                    dr["STOCK_ID"] = productmapitemOper.Stock_Id;
                    dr["STOCK_NAME"] = productmapitemOper.Stock_Name;


                    dr["REMARK"] = string.IsNullOrEmpty(productmapitemOper.Remark) ? "-" : productmapitemOper.Remark;

                    dr["IsMap"] = productmapitemOper.IsMap;
                    if (productmapitemOper.IsMap.Equals("1"))
                    {
                        dr["Is_Map"] = "已匹配";
                        dr["PROJECT_PROD_ID"] = productmapitemOper.ProductID;
                    }
                    else
                    {
                        dr["Is_Map"] = "未匹配";
                        dr["PROJECT_PROD_ID"] = "";
                    }

                    dr["PROCESS_FLAG"] = productmapitemOper.ProcessFlag;
                    if (productmapitemOper.ProcessFlag.Equals("1"))
                        dr["Is_Process_flag"] = "已处理";
                    else
                        dr["Is_Process_flag"] = "未处理";
                }

            }
        }
        #endregion

      
        #region 删除事件
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRow drow = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (drow != null)
            {
                if (XtraMessageBox.Show("确认删除HIS记录？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strid = drow == null ? "" : drow["ID"].ToString();
                    try
                    {
                        ProductCodeCompareBLL.GetInstance().DeleteGpo_Product(strid);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        isdelete = true;

                        DataColumn[] keys = new DataColumn[1];
                        DataColumn myColumn = new DataColumn();
                        keys[0] = this.dtCompare.Columns["ID"];
                        this.dtCompare.PrimaryKey = keys;
                        DataRow dr = dtCompare.Rows.Find(strid);

                        if (dr != null)
                            dtCompare.Rows.Remove(dr);

                        //重新绑定查询数据
                        IniData();
                        XtraMessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        #endregion

        #region 导出产品对照表
        private void butimp_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = ProductCodeCompareBLL.GetInstance("ClientDB").GetExportGpoProductMapList();

                this.saveFileDialog1.Filter = "Excel文件(*.xls)|*.xls";

                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (this.saveFileDialog1.FileName != "")
                    {
                        string[] strarr ={ "海虹通用名", "海虹商品名", "海虹剂型", "海虹规格", "海虹生产企业", "产品id", "his产品编号", "His产品名称", "通用名", "HIS剂型", "HIS规格包装", "HIS包装单位", "HIS使用单位", "HIS包装转换比", "海虹单位转换比", "HIS生产企业", "备注", "处理标记", "是否匹配" };

                        FileOperation.ExportExcelFile(dt, this.saveFileDialog1.FileName, strarr);

                        ComUtil.MsgBox("导出产品对照表成功！");
                    }
                }
                
            }
            catch
            {
                ComUtil.MsgBox("导出产品对照表出错！");
            }
        }
        #endregion

        #region 导入产品表
        private void butexp_Click(object sender, EventArgs e)
        {
            ProImpHisPlan frm = new ProImpHisPlan();
            frm.ShowDialog();
        }
        #endregion

        #region 处理数据选择异常问题
        private void dgvProIDCompare_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }
        #endregion

        #region 返回事件
        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        #endregion

        #region 设置Filter过滤
        private void Filter()
        {
            if (this.CmbProcessFlag.SelectedItem == null || this.CmbIsMap.SelectedItem == null || dtCompare == null)
                return;
            string FactoryName = this.tbxproducter.Text.Trim();       //生产企业
            string MedicaName = this.tbxmedicalname.Text.Trim();     //产品名称
            
            string IsMap = this.CmbIsMap.Text.ToString();           //匹配状态
            string ProcessFlag = this.CmbProcessFlag.Text.ToString();     //处理状态

            string ProductCode = this.txtHisCode.Text.Trim();         //HIS产品编码

            StringBuilder filter = new StringBuilder();
            filter.Append("1=1");
            if (!string.IsNullOrEmpty(FactoryName))
                filter.AppendFormat(" And (FACTORY_NAME LIKE '%{0}%')", FactoryName);
            if (!string.IsNullOrEmpty(MedicaName))
                filter.AppendFormat(" AND (COMMON_NAME LIKE '%{0}%' or PRODUCT_NAME LIKE '%{0}%')", MedicaName);
            if (!string.IsNullOrEmpty(ProductCode))
                filter.AppendFormat(" And (his_PRODUCT_ID LIKE '%{0}%')", ProductCode);
            //匹配状态

            switch (IsMap)
            {
                case "已匹配":
                    filter.AppendFormat(" And Is_Map='{0}'", IsMap);
                    break;
                case "未匹配":
                    filter.AppendFormat(" And (Is_Map='{0}' or Is_Map is null)", IsMap);
                    break;
                default:
                    break;
            }
            //处理状态

            switch (ProcessFlag)
            {
                case "已处理":
                    filter.AppendFormat(" And is_PROCESS_FLAG='{0}'", ProcessFlag);
                    break;
                case "未处理":
                    filter.AppendFormat(" And (is_PROCESS_FLAG='{0}' or is_PROCESS_FLAG is null)", ProcessFlag);
                    break;
                default:
                    break;
            }
            //if (dtCompare.DefaultView == null)
            this.dtCompare.DefaultView.RowFilter = filter.ToString();
            //绑定查询数据
            IniData();

        }
        #endregion

        #region 调用过滤
        private void CmbIsMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void CmbProcessFlag_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void tbxmedicalname_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void tbxproducter_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void txtHisCode_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }
        #endregion

        
        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (dr != null && isdelete == false)
            {
                string ismap = dr["IS_MAP"] == null ? "0" : dr["IS_MAP"].ToString();
                if (ismap == "未匹配")
                {
                    this.btnCancleMatch.Enabled = false;
                }
                else
                {
                    this.btnCancleMatch.Enabled = true;
                }
            }
            else
            {
                isdelete = false;
            }
        }

        private void gridView3_RowCountChanged(object sender, EventArgs e)
        {
            labelControlCount.Text = "    共 " + gridView3.RowCount + " 条数据";
        }
    }
}