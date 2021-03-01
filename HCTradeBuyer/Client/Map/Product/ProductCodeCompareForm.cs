/*****************************************************************************
创 建 人:	罗澜涛
创建日期:	2007-5-21
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
using Emedchina.TradeAssistant.Model.Map;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Client.BLL.Map.Product;
using Emedchina.TradeAssistant.Client.Common;

namespace Emedchina.TradeAssistant.Client.Map.Product
{
    public partial class ProductCodeCompareForm : MainFormBase
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
            thread = new Thread(new ThreadStart(ShowWaiting));
            thread.Start();

            IniData();

            thread.Abort();
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
            InitCmbState();
            this.CmbIsMap.Text = "全部";
            this.CmbProcessFlag.Text = "全部";


        }
        #endregion

        #region 显示等待窗体
        private void ShowWaiting()
        {
            LoadDataWaiting frm = new LoadDataWaiting("");
            frm.ShowDialog();
        }
        #endregion

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
            index = pageNavigator1.CurrentPageIndex;
            size = pageNavigator1.PageSize;

            //查询总的数据集
            if (dtCompare == null)
            {
                dtCompare = ProductCodeCompareBLL.GetInstance("ClientDB").GetCommList();
            }
            //CommListDt = ProductCodeCompareBLL.GetInstance("ClientDB").GetGpoHitCommList();
            if (dtCompare == null)
                return;
            InitFromCacheByData(dtCompare);
       
            this.InitGridTableView(pageNavigator1.CurrentPageIndex, pageNavigator1.PageSize);
            this.bindingSource1.DataSource = base.gridDataView;
            this.pageNavigator1.ItemCount = base.cachedDataView.Count;

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
            product_MapModel.MedicaName = this.tbxmedicalname.Text.Trim();     //药品名称
            product_MapModel.IsMap = this.CmbIsMap.SelectedValue.ToString();           //匹配状态
            product_MapModel.ProcessFlag = this.CmbProcessFlag.SelectedValue.ToString();     //处理状态
            product_MapModel.ProductCode = this.txtHisCode.Text.Trim();         //HIS产品编码

            return product_MapModel;
        }
        #endregion

        #region 绑定申请状态
        /// <summary>
        /// 绑定状态
        /// </summary>
        public void InitCmbState()
        {
            //绑定匹配状态
            DataTable dtIsMap = new DataTable();
            dtIsMap.Columns.Add();
            dtIsMap.Columns.Add();
            dtIsMap.Columns[0].ColumnName = "value";
            dtIsMap.Columns[1].ColumnName = "text";
            string[] dataIsMap = { "", "全部" };
            dtIsMap.Rows.Add(dataIsMap);
            string[] dataIsMap1 = { "1", "已匹配" };
            dtIsMap.Rows.Add(dataIsMap1);
            string[] dataIsMap2 = { "0", "未匹配" };
            dtIsMap.Rows.Add(dataIsMap2);

            this.CmbIsMap.DataSource = dtIsMap;
            this.CmbIsMap.DisplayMember = "text";
            this.CmbIsMap.ValueMember = "value";

            //绑定处理状态
            DataTable dtProcessFlag = new DataTable();
            dtProcessFlag.Columns.Add();
            dtProcessFlag.Columns.Add();
            dtProcessFlag.Columns[0].ColumnName = "value";
            dtProcessFlag.Columns[1].ColumnName = "text";
            string[] dataProcessFlag = { "", "全部" };
            dtProcessFlag.Rows.Add(dataProcessFlag);
            string[] dataProcessFlag1 = { "1", "已处理" };
            dtProcessFlag.Rows.Add(dataProcessFlag1);
            string[] dataProcessFlag2 = { "0", "未处理" };
            dtProcessFlag.Rows.Add(dataProcessFlag2);

            this.CmbProcessFlag.DataSource = dtProcessFlag;
            this.CmbProcessFlag.DisplayMember = "text";
            this.CmbProcessFlag.ValueMember = "value";
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
                CommListDt = ProductCodeCompareBLL.GetInstance("ClientDB").GetGpoHitCommList();
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
            if (MessageBox.Show("确认取消匹配关系？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                //Gpo_Product_MapModel productmapitem = new Gpo_Product_MapModel();
                string strId = this.dgvProIDCompare.CurrentRow.Cells["ID"].Value.ToString();
                //productmapitem.ProductID = this.dgvProIDCompare.CurrentRow.Cells["PRODUCT_ID"].Value.ToString();
                //string ProductCode = this.dgvProIDCompare.CurrentCell == null ? "" : this.dgvProIDCompare.CurrentRow.Cells["PRODUCT_CODE"].Value.ToString();
                //取消匹配
                bool flag = ProductCodeCompareBLL.GetInstance("ClientDB").CancelComparion(strId);

                if (flag == true)
                {
                    DataColumn[] keys = new DataColumn[1];
                    DataColumn myColumn = new DataColumn();
                    keys[0] = this.dtCompare.Columns["ID"];
                    this.dtCompare.PrimaryKey = keys;
                    DataRow dr = dtCompare.Rows.Find(strId);

                    dr["IsMap"] = "0";
                    dr["Is_Map"] = "未匹配";
                    dr["PRODUCT_ID"] = "";
                    
                    IniData();
                }

                foreach (DataGridViewRow row in this.dgvProIDCompare.Rows)
                {
                    if (row.Cells["ID"].Value.ToString() == strId)
                    {
                        this.dgvProIDCompare.CurrentCell = this.dgvProIDCompare["ID", row.Index];
                    }
                }
                MessageBox.Show("匹配关系已取消！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 修改
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (this.dgvProIDCompare.CurrentRow != null)
            {
                if (this.CommListDt == null)
                {
                    CommListDt = ProductCodeCompareBLL.GetInstance("ClientDB").GetGpoHitCommList();
                }

                ProductCodeForm frm = new ProductCodeForm();
                frm.CommListDt = this.CommListDt.Copy();
                frm.IsAdd = false;
                frm.productid = this.dgvProIDCompare.CurrentRow.Cells["PRODUCT_ID"].Value.ToString().Trim();
                int currentrowindex = this.dgvProIDCompare.CurrentRow.Index;
                frm.productcode = this.dgvProIDCompare.CurrentCell == null ? "" : this.dgvProIDCompare.CurrentRow.Cells["PRODUCT_CODE"].Value.ToString();
                frm.strID = this.dgvProIDCompare.CurrentCell == null ? "" : this.dgvProIDCompare.CurrentRow.Cells["ID"].Value.ToString();
                frm.ShowDialog();

                if (frm.productmapitemOper == null)
                    return;

                //更新DataTable
                UpdateDtCompare(frm.productmapitemOper);

                //重新绑定数据
                IniData();
                
                foreach (DataGridViewRow row in this.dgvProIDCompare.Rows)
                {
                    if (row.Cells["PRODUCT_CODE"].Value.ToString() == frm.productcode)
                    {
                        this.dgvProIDCompare.CurrentCell = this.dgvProIDCompare["PRODUCT_CODE", row.Index];
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
                    drnew["PRODUCT_CODE"] = productmapitemOper.ProductCode;
                    drnew["COMMON_NAME"] = productmapitemOper.CommonName;
                    drnew["PRODUCT_NAME"] = productmapitemOper.Product_Name;
                    drnew["HISPRODUCT_NAME"] = productmapitemOper.CommonName + "(" + productmapitemOper.Product_Name + ")";
                    drnew["MODE_ID"] = productmapitemOper.Mode_ID;
                    drnew["MODE_NAME"] = productmapitemOper.Mode_Name;

                    drnew["MEDICAL_SPEC_ID"] = productmapitemOper.Medical_Spec_Id;
                    drnew["MEDICAL_SPEC"] = productmapitemOper.Medical_Spec;
                    if (!string.IsNullOrEmpty(productmapitemOper.Stand_Rate))
                    {
                        drnew["STAND_RATE"] = productmapitemOper.Stand_Rate;
                    }
                    if (!string.IsNullOrEmpty(productmapitemOper.Package_Rate))
                    {
                        drnew["PACKAGE_RATE"] = productmapitemOper.Package_Rate;
                    }
                    drnew["USE_UNIT_ID"] = productmapitemOper.UseUnitCode;
                    drnew["USE_UNIT"] = productmapitemOper.Use_Unit;

                    drnew["SPEC_UNIT_ID"] = productmapitemOper.Spec_Unit_Id;
                    drnew["SPEC_UNIT"] = productmapitemOper.Spec_Unit;
                    drnew["FACTORY_CODE"] = productmapitemOper.Factory_Code;
                    drnew["FACTORY_NAME"] = productmapitemOper.Factory_Name;

                    drnew["REMARK"] = productmapitemOper.Remark;

                    drnew["IsMap"] = productmapitemOper.IsMap;

                    if (productmapitemOper.IsMap.Equals("1"))
                    {
                        drnew["Is_Map"] = "已匹配";
                        drnew["PRODUCT_ID"] = productmapitemOper.ProductID;
                    }
                    else
                    {
                        drnew["Is_Map"] = "未匹配";
                        drnew["PRODUCT_ID"] = "";
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
                    dr["PRODUCT_CODE"] = productmapitemOper.ProductCode;
                    dr["COMMON_NAME"] = productmapitemOper.CommonName;
                    dr["PRODUCT_NAME"] = productmapitemOper.Product_Name;
                    dr["HISPRODUCT_NAME"] = productmapitemOper.CommonName + "(" + productmapitemOper.Product_Name + ")";
                    dr["MODE_ID"] = productmapitemOper.Mode_ID;
                    dr["MODE_NAME"] = productmapitemOper.Mode_Name;

                    dr["MEDICAL_SPEC_ID"] = productmapitemOper.Medical_Spec_Id;
                    dr["MEDICAL_SPEC"] = productmapitemOper.Medical_Spec;
                    if (!string.IsNullOrEmpty(productmapitemOper.Stand_Rate))
                    {
                        dr["STAND_RATE"] = productmapitemOper.Stand_Rate;
                    }
                    if (!string.IsNullOrEmpty(productmapitemOper.Package_Rate))
                    {
                        dr["PACKAGE_RATE"] = productmapitemOper.Package_Rate;
                    }
                    dr["USE_UNIT_ID"] = productmapitemOper.UseUnitCode;
                    dr["USE_UNIT"] = productmapitemOper.Use_Unit;

                    dr["SPEC_UNIT_ID"] = productmapitemOper.Spec_Unit_Id;
                    dr["SPEC_UNIT"] = productmapitemOper.Spec_Unit;
                    dr["FACTORY_CODE"] = productmapitemOper.Factory_Code;
                    dr["FACTORY_NAME"] = productmapitemOper.Factory_Name;
                    dr["REMARK"] = productmapitemOper.Remark;

                    dr["IsMap"] = productmapitemOper.IsMap;
                    if (productmapitemOper.IsMap.Equals("1"))
                    {
                        dr["Is_Map"] = "已匹配";
                        dr["PRODUCT_ID"] = productmapitemOper.ProductID;
                    }
                    else
                    {
                        dr["Is_Map"] = "未匹配";
                        dr["PRODUCT_ID"] = "";
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

        #region 判断匹配按钮是否可用
        private void dgvProIDCompare_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.dgvProIDCompare.CurrentRow != null && isdelete == false)
            {
                //string productID = this.dgvProIDCompare.CurrentRow.Cells["PRODUCT_ID"].Value == null ? "" : this.dgvProIDCompare.CurrentRow.Cells["PRODUCT_ID"].Value.ToString();
                string ismap = this.dgvProIDCompare.CurrentRow.Cells["IsMap"].Value == null ? "0" : this.dgvProIDCompare.CurrentRow.Cells["IsMap"].Value.ToString();
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
        #endregion

        #region 删除事件
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvProIDCompare.CurrentRow != null)
            {
                if (MessageBox.Show("确认删除HIS记录？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string strid = this.dgvProIDCompare.CurrentCell == null ? "" : this.dgvProIDCompare.CurrentRow.Cells["ID"].Value.ToString();
                    try
                    {
                        ProductCodeCompareBLL.GetInstance("ClientDB").DeleteGpo_Product(strid);
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
                        MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (this.CmbProcessFlag.SelectedValue == null || this.CmbIsMap.SelectedValue == null || dtCompare == null)
                return;
            string FactoryName = StringUtils.repalceSepStr(this.tbxproducter.Text.Trim());       //生产企业
            string MedicaName = StringUtils.repalceSepStr(this.tbxmedicalname.Text.Trim());     //药品名称
            string IsMap = this.CmbIsMap.SelectedValue.ToString();           //匹配状态
            string ProcessFlag = this.CmbProcessFlag.SelectedValue.ToString();     //处理状态
            string ProductCode = StringUtils.repalceSepStr(this.txtHisCode.Text.Trim());         //HIS产品编码

            StringBuilder filter = new StringBuilder();
            filter.Append("1=1");
            if (!string.IsNullOrEmpty(FactoryName))
                filter.AppendFormat(" And (FACTORY_NAME LIKE '%{0}%')", FactoryName);
            if (!string.IsNullOrEmpty(MedicaName))
                filter.AppendFormat(" AND (COMMON_NAME LIKE '%{0}%' or PRODUCT_NAME LIKE '%{0}%')", MedicaName);
            if (!string.IsNullOrEmpty(ProductCode))
                filter.AppendFormat(" And (PRODUCT_CODE LIKE '%{0}%')", ProductCode);
            //匹配状态
            switch (IsMap)
            {
                case "1":
                    filter.AppendFormat(" And IsMap='{0}'", IsMap);
                    break;
                case "0":
                    filter.AppendFormat(" And (IsMap='{0}' or IsMap is null)", IsMap);
                    break;
                default:
                    break;
            }
            //处理状态
            switch (ProcessFlag)
            {
                case "1":
                    filter.AppendFormat(" And PROCESS_FLAG='{0}'", ProcessFlag);
                    break;
                case "0":
                    filter.AppendFormat(" And (PROCESS_FLAG='{0}' or PROCESS_FLAG is null)", ProcessFlag);
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
            CheckInputCom(sender);
            Filter();
        }

        private void tbxproducter_TextChanged(object sender, EventArgs e)
        {
            CheckInputCom(sender);
            Filter();
        }

        private void txtHisCode_TextChanged(object sender, EventArgs e)
        {
            CheckInputCom(sender);
            Filter();
        }
        #endregion

        private void dgvProIDCompare_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string data = this.dgvProIDCompare.Columns[e.ColumnIndex].DataPropertyName;
            if (flag)
            {
                this.cachedDataView.Sort = data + " DESC";
                flag = false;
            }
            else
            {
                this.cachedDataView.Sort = data + " ASC";
                flag = true;
            }
         
            InitFromCacheByData(dtCompare);
            this.InitGridTableView(pageNavigator1.CurrentPageIndex, pageNavigator1.PageSize);
            this.bindingSource1.DataSource = base.gridDataView;
            this.pageNavigator1.ItemCount = base.cachedDataView.Count;
        }
    }
}