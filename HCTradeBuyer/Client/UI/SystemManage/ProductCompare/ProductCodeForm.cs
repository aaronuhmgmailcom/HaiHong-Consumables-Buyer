/*****************************************************************************
创 建 人:	yanbing
创建日期:	2007-10-10
功能描述:	新增与修改 产品编码对照
******************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Model.His;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Client.BLL.His.Product;
using DevExpress.XtraEditors;
using DevExpress.Utils;

namespace Emedchina.TradeAssistant.Client.His.Product
{
    public partial class ProductCodeForm : BaseForm
    {

        #region 定义变量区
        public string strID;
        public bool issaved;
        public bool IsAdd;
        public string productid;
        public string sPEC_ID;
        public string mODEL_ID;

        public string productcode;
        public DataTable CommListDt;
        private DataTable CompareDt;
        public Gpo_Product_MapModel productmapitemOper;
        #endregion

        #region 构造
        public ProductCodeForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 页面加载
        private void ProductCodeForm_Load(object sender, EventArgs e)
        {
            if (!IsAdd)
            {
                //修改
                this.xtraTabPage1.Text = "修改产品编码匹配";
                this.txtCode.Enabled = false;
                this.txtBrand.Enabled = false;
                //this.txtProducerCode.Enabled = false;
                //this.txtSpecCode.Enabled = false;
                //this.txtSpecUnitCode.Enabled = false;
                //this.txtUseUnitCode.Enabled = false;
            }
            InitCommListDT();

            //InitDataProjectType();

            CompareDt = new DataTable();
            CompareDt = CommListDt.Copy();
            //this.cbbsourcetype.Text = "全部";
            if (this.IsAdd == false && issaved == false)
            {
                ModifyLoadPage();
            }

        }
        #endregion

       
        #region 获取采购供应目录列表
        private void InitCommListDT()
        {
            //CommListDt = ProductCodeCompareBLL.GetInstance("ClientDB").GetGpoHitCommList();
            if (CommListDt != null)
                this.bindingSource1.DataSource = CommListDt.DefaultView;
        }
        #endregion

        #region 双击实现匹配
        private void dgvComm_DoubleClick(object sender, EventArgs e)
        {
            Comprison();
        }
        #endregion

        #region 匹配事件
        public void Comprison()
        {
            DataRow row = gridView5.GetDataRow(gridView5.FocusedRowHandle);

            if (row != null)
            {
                string proID = row["PROJECT_PROD_ID"].ToString();
                string specID = row["SPEC_ID"].ToString();
                string modelID = row["MODEL_ID"].ToString();

                DataTable dt = ProductCodeCompareBLL.GetInstance().GetGpoMapList(proID, modelID, specID);

                int MapSum = dt.Rows.Count;
                if (MapSum > 0)
                {
                    ContProductModel productModel = new ContProductModel();
                    productModel.MedicalName = row["COMMON_NAME"].ToString();
                    productModel.FactoryName = row["MANU_NAME"].ToString();
                    productModel.Model = row["MODEL"].ToString();
                    productModel.UncSpec = row["SPEC"].ToString();
                    productModel.TradeName = row["product_name"].ToString();

                    productModel.MatchHisDT = dt;

                    ProIDMatchShowBoxForm proshowbox = new ProIDMatchShowBoxForm(productModel);
                    proshowbox.IsAdd = this.IsAdd;
                    proshowbox.ShowDialog();

                    if (proshowbox.DialogResult == DialogResult.OK)
                    {
                        this.bindingSource2.DataSource = CompareDt.DefaultView;
                        CompareDt.DefaultView.RowFilter = " PROJECT_PROD_ID ='" + row["PROJECT_PROD_ID"].ToString() + "' AND MODEL_ID = '" + row["MODEL_ID"].ToString() + " ' AND SPEC_ID = '" + row["SPEC_ID"].ToString() + "'";
                    }
                }
                else
                {
                    this.bindingSource2.DataSource = CompareDt.DefaultView;
                    CompareDt.DefaultView.RowFilter = " PROJECT_PROD_ID ='" + row["PROJECT_PROD_ID"].ToString() + "' AND MODEL_ID = '" + row["MODEL_ID"].ToString() + " ' AND SPEC_ID = '" + row["SPEC_ID"].ToString() + "'";
                }
            }
        }
        #endregion

        #region 修改匹配关系时显示的页面，定位与HIS匹配的采购供应目录

        private void ModifyLoadPage()
        {
            if (!string.IsNullOrEmpty(this.productid))
            {
                for (int i = 0; i < this.gridView5.RowCount; i++)
                {
                    DataRow drrow = gridView5.GetDataRow(i);
                    if (drrow["PROJECT_PROD_ID"].ToString() == this.productid && drrow["MODEL_ID"].ToString() == this.mODEL_ID && drrow["SPEC_ID"].ToString() == this.sPEC_ID)
                    {
                        this.gridView5.FocusedRowHandle = i;
                        this.bindingSource2.DataSource = CompareDt.DefaultView;
                        CompareDt.DefaultView.RowFilter = " PROJECT_PROD_ID ='" + drrow["PROJECT_PROD_ID"].ToString() + "' AND MODEL_ID = '" + drrow["MODEL_ID"].ToString() + " ' AND SPEC_ID = '" + drrow["SPEC_ID"].ToString() + "'";
                        break;
                    }
                }
                
            }

            Gpo_Product_MapModel productmapitem = ProductCodeCompareBLL.GetInstance().GetGpoMapModelById(this.strID);
            ShowHISItemInfo(productmapitem);
        }

        #endregion

        #region 显示HIS数据
        private void ShowHISItemInfo(Gpo_Product_MapModel promapintance)
        {
            //this.txtCode.Text = promapintance.ProductCode;
            //this.txtName.Text = promapintance.Product_Name;     //产品名称
            //this.txtCommonName.Text = promapintance.CommonName; //通用名称
            //this.txtBrand.Text = promapintance.Mode_ID;
            //this.txtModeName.Text = promapintance.Mode_Name;

            //this.txtSpecCode.Text = promapintance.Medical_Spec_Id;
            //this.txtSpecName.Text = promapintance.Medical_Spec;
            //this.txtStandRate.Text = promapintance.Stand_Rate;
            //this.txtPackageRate.Text = promapintance.Package_Rate;

            //this.txtUseUnitCode.Text = promapintance.UseUnitCode;
            //this.txtUseUnit.Text = promapintance.Use_Unit;
            
            //this.txtSpecUnitCode.Text = promapintance.Spec_Unit_Id;
            //this.txtSpecUnit.Text = promapintance.Spec_Unit;
            //this.txtProducerCode.Text = promapintance.Factory_Code;
            //this.txtProducer.Text = promapintance.Factory_Name;

            this.txtCode.Text = promapintance.ProductCode;
            this.txtCommonName.Text = promapintance.CommonName;
            this.txtName.Text = promapintance.Product_Name;
            this.teCName.Text = promapintance.CommerceName;
            this.txtBrand.Text = promapintance.Brand;
            this.teMODELID.Text = promapintance.Mode_ID;
            this.txtModeName.Text = promapintance.Mode_Name;
            this.teSPEC_ID.Text = promapintance.Spec_Unit_Id;
            this.txtSpecName.Text = promapintance.Spec_Unit;
            this.teBASEMEASURE.Text = promapintance.Base_measure;
            this.teBASEMEASURESPEC.Text = promapintance.Base_measure_spec;

            this.teBASEMEASUREMATE.Text = promapintance.Base_measure_mate;
            this.teSTANDRATE.Text = promapintance.Stand_Rate;
            this.teFACTORYCODE.Text = promapintance.Factory_Code;
            this.teFACTORYName.Text = promapintance.Factory_Name;
            this.teSALERNAME.Text = promapintance.Saler_Name;

            this.teSALERCODE.Text = promapintance.Saler_Code;
            this.teSENDERCODE.Text = promapintance.Sender_Code;

            this.teSENDERNAME.Text = promapintance.Sender_Name;

            this.teSTOCKID.Text = promapintance.Stock_Id;
            this.teSTOCKNAME.Text = promapintance.Stock_Name;
            //productmapitemOper.User = CurrentUser;


            this.txtRemark.Text = promapintance.Remark;

            if (promapintance.ProcessFlag == "1")
            {
                this.cbxRead.Checked = true;
            }
            else
            {
                this.cbxRead.Checked = false;
            }
        }

        #endregion

        #region 设置Filter过滤
        private void Filter()
        {
            string producter = this.tbxproducter.Text;      //生产企业
            string productname = this.tbxproductname.Text;  //品名
            string sender = this.tbxsender.Text;            //配送企业
            //string sourcetype = this.cbbsourcetype.Text;    //来源类型
            StringBuilder filter = new StringBuilder();
            filter.Append("1=1");
            if (!string.IsNullOrEmpty(productname))
                filter.AppendFormat(" AND (COMMON_NAME LIKE '%{0}%'  or PRODUCT_NAME LIKE '%{0}%' or ABBR_WB LIKE '%{0}%' or ABBR_PY like '%{0}%'  or COMMERCE_NAME LIKE '%{0}%')", productname);
            if (!string.IsNullOrEmpty(producter))
                filter.AppendFormat(" AND (MANU_NAME LIKE '%{0}%'  or MANU_NAME_ABBR LIKE '%{0}%')", producter);//or FACTORY_EASY like '%{0}%' or FACTORY_WUBI LIKE '%{0}%' or FACTORY_PINYIN like '%{0}%'
            if (!string.IsNullOrEmpty(sender))
                filter.AppendFormat(" AND (SENDER_NAME LIKE '%{0}%' or SENDER_NAME_ABBR like '%{0}%' )", sender);
            //switch (sourcetype)
            //{
            //    case "全部":
            //        break;
            //    default:
            //        filter.AppendFormat(" and source LIKE '%{0}%'", sourcetype); break;
            //}
            if (CommListDt.DefaultView != null)
                this.CommListDt.DefaultView.RowFilter = filter.ToString();

        }
        #endregion

        #region 输入文本调用过滤方法

        private void tbxproductname_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void tbxproducter_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void tbxsender_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void cbbsourcetype_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        #endregion

        #region 匹配事件
        private void btnMatch_Click(object sender, EventArgs e)
        {
            Comprison();
        }
        #endregion

        #region 保存按钮实现
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        #endregion

        #region 保存事件
        private void Save()
        {
            if (string.IsNullOrEmpty(txtCode.Text.Trim()) || string.IsNullOrEmpty(txtCommonName.Text.Trim()) || string.IsNullOrEmpty(txtModeName.Text.Trim()) || string.IsNullOrEmpty(txtSpecName.Text.Trim()) || string.IsNullOrEmpty(teBASEMEASURE.Text.Trim()) || string.IsNullOrEmpty(teBASEMEASURESPEC.Text.Trim()))
            {
                XtraMessageBox.Show("带 * 为必填项！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (issaved == false)
            {
                //定义对接产品对照表实体类
                productmapitemOper = new Gpo_Product_MapModel();

                LogedInUser CurrentUser = ClientSession.GetInstance().CurrentUser;

                productmapitemOper.IsMap = "0";//未匹配

                DataRow crow = gridView3.GetDataRow(gridView3.FocusedRowHandle);
                if (crow != null)
                {
                    productmapitemOper.ProductID = crow["PROJECT_PROD_ID"].ToString();     //产品ID
                    productmapitemOper.Map_Orgid = CurrentUser.UserOrg.Id;
                    productmapitemOper.Sender_Id = crow["Sender_Id"].ToString();     //配送企业ID
                    productmapitemOper.Factory_Id = crow["Factory_Id"].ToString();   //生产企业ID
                    productmapitemOper.HH_Mode_ID = crow["MODEL_ID"].ToString();  //客户端型号ID
                    productmapitemOper.HH_Spec_ID = crow["SPEC_ID"].ToString();  //客户端规格ID

                    productmapitemOper.IsMap = "1";//已匹配

                }
                else
                {
                    productmapitemOper.ProductID = "0";     //产品ID
                    productmapitemOper.Map_Orgid = CurrentUser.UserOrg.Id;
                    productmapitemOper.Sender_Id = "0";     //配送企业ID
                    productmapitemOper.Factory_Id = "0";   //生产企业ID
                    productmapitemOper.HH_Mode_ID = "0";  //客户端型号ID
                    productmapitemOper.HH_Spec_ID = "0";  //客户端规格ID

                    productmapitemOper.IsMap = "0";//未匹配
                }
                productmapitemOper.ID = this.strID;
                productmapitemOper.ProductCode = this.txtCode.Text;
                productmapitemOper.CommonName = this.txtCommonName.Text;

                productmapitemOper.Product_Name = this.txtName.Text;
                productmapitemOper.CommerceName = this.teCName.Text;


                productmapitemOper.Brand = this.txtBrand.Text;

                productmapitemOper.Mode_ID = this.teMODELID.Text;
                productmapitemOper.Mode_Name = this.txtModeName.Text;

                productmapitemOper.Spec_Unit_Id = this.teSPEC_ID.Text;
                productmapitemOper.Spec_Unit = this.txtSpecName.Text;
                productmapitemOper.Base_measure = this.teBASEMEASURE.Text;
                productmapitemOper.Base_measure_spec = this.teBASEMEASURESPEC.Text;
                productmapitemOper.Base_measure_mate = this.teBASEMEASUREMATE.Text;

                productmapitemOper.Stand_Rate = this.teSTANDRATE.Text;
                productmapitemOper.Factory_Code = this.teFACTORYCODE.Text;
                productmapitemOper.Factory_Name = this.teFACTORYName.Text;
                productmapitemOper.Saler_Name = this.teSALERNAME.Text;
                productmapitemOper.Saler_Code = this.teSALERCODE.Text;
                productmapitemOper.Sender_Code = this.teSENDERCODE.Text;
                productmapitemOper.Sender_Name = this.teSENDERNAME.Text;

                productmapitemOper.Stock_Id = this.teSTOCKID.Text;
                productmapitemOper.Stock_Name = this.teSTOCKNAME.Text;
                productmapitemOper.User = CurrentUser;

                productmapitemOper.Remark = this.txtRemark.Text;

                //是否阅读
                if (this.cbxRead.Checked == true)
                {
                    productmapitemOper.ProcessFlag = "1";
                }
                else
                {
                    productmapitemOper.ProcessFlag = "0";
                }
                //判断是否作插入操作还是修改操作

                if (IsAdd == true)
                    SaveAdd(productmapitemOper);
                else if (IsAdd == false)
                    SaveUpdate(productmapitemOper);
            }
        }

        //插入操作
        private void SaveAdd(Gpo_Product_MapModel productmapitem)
        {
            bool flag = ProductCodeCompareBLL.GetInstance().JudgeHisProductCode(productmapitem.ProductCode);
            if (flag == false )
            {   //产品编码没有重复
                ProductCodeCompareBLL.GetInstance().Add_Gpo_Product_Map(productmapitem,out strID);
                InitCommListDT();
                Filter();
                issaved = true;
                XtraMessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("该产品编码已存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //修改操作
        private void SaveUpdate(Gpo_Product_MapModel productmapitem)
        {
            issaved = true;
            ProductCodeCompareBLL.GetInstance().Edit_Gpo_Product_Map(productmapitem);
            InitCommListDT();
            Filter();

            XtraMessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region 取消匹配
        private void btnCancelMatch_Click(object sender, EventArgs e)
        {
            this.bindingSource2.DataSource = null;
        }
        #endregion

        #region 关闭事件
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 关闭时判断是否保存
        private void ProductCodeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //如果带*必填控件都不为空且未保存过则关闭时提示保存
            //if ((!string.IsNullOrEmpty(txtCode.Text) && !string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtModeName.Text) && !string.IsNullOrEmpty(txtSpecName.Text) && !string.IsNullOrEmpty(txtUseUnit.Text) && !string.IsNullOrEmpty(txtSpecUnit.Text)) && issaved == false)
            //{
            //        if (MessageBox.Show("是否保存？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //            btnSave_Click(null, null);
            //}
        }
        #endregion

        private void ProductCodeForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }

        private void toolTipLocationControl_ToolTipLocationChanged(string senderName)
        {
            ToolTipControllerShowEventArgs args = toolTipController1.CreateShowArgs();
            args.ToolTip = senderName;
            args.IconType = ToolTipIconType.Information;
            args.ImageIndex = -1;
            args.IconSize = ToolTipIconSize.Small;
            toolTipController1.ShowHint(args);
        }

        private void gridView5_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView5.GetDataRow(gridView5.FocusedRowHandle);
            if (dr != null)
            {
                if (gridView5.FocusedColumn.FieldName == "SENDER_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["SENDER_NAME"].ToString());
                else if (gridView5.FocusedColumn.FieldName == "MANU_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["MANU_NAME"].ToString());

            }
        }

        private void gridView3_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (dr != null)
            {
                if (gridView3.FocusedColumn.FieldName == "SENDER_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["SENDER_NAME"].ToString());
                else if (gridView3.FocusedColumn.FieldName == "MANU_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["MANU_NAME"].ToString());

            }
        }


    }
}