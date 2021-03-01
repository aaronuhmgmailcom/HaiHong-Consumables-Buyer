/*****************************************************************************
创 建 人:	罗澜涛
创建日期:	2007-5-21
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
using Emedchina.TradeAssistant.Model.Map;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Client.BLL.Map.Product;

namespace Emedchina.TradeAssistant.Client.Map.Product
{
    public partial class ProductCodeForm : FormBase
    {

        #region 定义变量区
        public string strID;
        public bool issaved;
        public bool IsAdd;
        public string productid;
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
                labelfrmtxt.Text = "修改产品编码匹配";
                this.txtCode.Enabled = false;
                this.txtModeCode.Enabled = false;
                this.txtProducerCode.Enabled = false;
                this.txtSpecCode.Enabled = false;
                this.txtSpecUnitCode.Enabled = false;
                this.txtUseUnitCode.Enabled = false;
            }
            InitCommListDT();

            InitDataProjectType();

            CompareDt = new DataTable();
            CompareDt = CommListDt.Copy();
            this.cbbsourcetype.Text = "全部";
            if (this.IsAdd == false && issaved == false)
            {
                ModifyLoadPage();
            }

        }
        #endregion

        #region 类型绑定

        private void InitDataProjectType()
        {
            DataTable dt = ProductCodeCompareBLL.GetInstance("ClientDB").GetProjectTypeDt();

            string[] data = { "", "全部" ,""};
            dt.Rows.Add(data);

            cbbsourcetype.DataSource = dt;
            cbbsourcetype.DisplayMember = "Name";
            cbbsourcetype.ValueMember = "Code";

            cbbsourcetype.SelectedIndex = cbbsourcetype.Items.Count - 1;
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
            DataGridViewRow row = this.dgvComm.CurrentRow;

            if (row != null)
            {
                string proID = row.Cells["PRODUCT_ID"].Value.ToString();
                DataTable dt = ProductCodeCompareBLL.GetInstance("ClientDB").GetGpoMapList(proID);

                int MapSum = dt.Rows.Count;
                if (MapSum > 0)
                {
                    ContProductModel productModel = new ContProductModel();
                    productModel.MedicalName = row.Cells["MEDICAL_NAME"].Value.ToString();
                    productModel.FactoryName = row.Cells["FACTORY_NAME"].Value.ToString();
                    productModel.DoseageForm = row.Cells["DOSEAGE_FORM"].Value.ToString();
                    productModel.UncSpec = row.Cells["unc_spec"].Value.ToString();


                    productModel.MatchHisDT = dt;

                    ProIDMatchShowBoxForm proshowbox = new ProIDMatchShowBoxForm(productModel);
                    proshowbox.IsAdd = this.IsAdd;
                    proshowbox.ShowDialog();

                    if (proshowbox.DialogResult == DialogResult.OK)
                    {
                        this.bindingSource2.DataSource = CompareDt.DefaultView;
                        CompareDt.DefaultView.RowFilter = " PRODUCT_ID ='" + row.Cells["PRODUCT_ID"].Value.ToString() + "'";
                    }
                }
                else
                {
                    this.bindingSource2.DataSource = CompareDt.DefaultView;
                    CompareDt.DefaultView.RowFilter = " PRODUCT_ID ='" + row.Cells["PRODUCT_ID"].Value.ToString() + "'";
                }
            }
        }
        #endregion

        #region 修改匹配关系时显示的页面，定位与HIS匹配的采购供应目录

        private void ModifyLoadPage()
        {
            if (!string.IsNullOrEmpty(this.productid))
            {
                foreach (DataGridViewRow row in this.dgvComm.Rows)
                {
                    if (row.Cells["PRODUCT_ID"].Value.ToString() == this.productid)
                    {
                        this.dgvComm.CurrentCell = this.dgvComm["MEDICAL_NAME", row.Index];
                        this.bindingSource2.DataSource = CompareDt.DefaultView;
                        CompareDt.DefaultView.RowFilter = "PRODUCT_ID ='" + row.Cells["PRODUCT_ID"].Value.ToString() + "'";
                        break;
                    }
                }
            }

            Gpo_Product_MapModel productmapitem = ProductCodeCompareBLL.GetInstance("ClientDB").GetGpoMapModelById(this.strID);
            ShowHISItemInfo(productmapitem);
        }

        #endregion

        #region 显示HIS数据
        private void ShowHISItemInfo(Gpo_Product_MapModel promapintance)
        {
            this.txtCode.Text = promapintance.ProductCode;
            this.txtName.Text = promapintance.Product_Name;     //产品名称
            this.txtCommonName.Text = promapintance.CommonName; //通用名称
            this.txtModeCode.Text = promapintance.Mode_ID;
            this.txtModeName.Text = promapintance.Mode_Name;

            this.txtSpecCode.Text = promapintance.Medical_Spec_Id;
            this.txtSpecName.Text = promapintance.Medical_Spec;
            this.txtStandRate.Text = promapintance.Stand_Rate;
            this.txtPackageRate.Text = promapintance.Package_Rate;

            this.txtUseUnitCode.Text = promapintance.UseUnitCode;
            this.txtUseUnit.Text = promapintance.Use_Unit;
            
            this.txtSpecUnitCode.Text = promapintance.Spec_Unit_Id;
            this.txtSpecUnit.Text = promapintance.Spec_Unit;
            this.txtProducerCode.Text = promapintance.Factory_Code;
            this.txtProducer.Text = promapintance.Factory_Name;
            
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
            
            string producter = StringUtils.repalceSepStr(this.tbxproducter.Text);      //生产企业
            string productname = StringUtils.repalceSepStr(this.tbxproductname.Text);  //品名
            string sender = StringUtils.repalceSepStr(this.tbxsender.Text);            //配送企业
            string sourcetype = this.cbbsourcetype.Text;    //来源类型
            StringBuilder filter = new StringBuilder();
            filter.Append("1=1");
            if (!string.IsNullOrEmpty(productname))
                filter.AppendFormat(" and (medical_name like '%{0}%' or medical_wubi like '%{0}%' or medical_pinyin like '%{0}%' or spell_abbr like '%{0}%' or name_wb like '%{0}%' or trade_name like '%{0}%')", productname.ToUpper());
            if (!string.IsNullOrEmpty(producter))
                filter.AppendFormat(" and (factory_name like '%{0}%' or factory_easy like '%{0}%' or factory_wubi like '%{0}%' or factory_pinyin like '%{0}%')", producter);
            if (!string.IsNullOrEmpty(sender))
                filter.AppendFormat(" and (org_name like '%{0}%' or org_easy like '%{0}%' or org_pinyin like '%{0}%' or org_wubi like '%{0}%')", sender.ToUpper());
            switch (sourcetype)
            {
                case "全部":
                    break;
                default:
                    filter.AppendFormat(" and source LIKE '%{0}%'", sourcetype); break;
            }
            if (CommListDt.DefaultView != null)
                this.CommListDt.DefaultView.RowFilter = filter.ToString();
            
        }
        #endregion

        #region 输入文本调用过滤方法

        private void tbxproductname_TextChanged(object sender, EventArgs e)
        {
            //CheckInputCom(sender);
            Filter();
        }

        private void tbxproducter_TextChanged(object sender, EventArgs e)
        {
            //CheckInputCom(sender);
            Filter();
        }
        
        private void tbxsender_TextChanged(object sender, EventArgs e)
        {
            //CheckInputCom(sender);
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
            if (string.IsNullOrEmpty(txtCode.Text.Trim()) || string.IsNullOrEmpty(txtCommonName.Text.Trim()) || string.IsNullOrEmpty(txtModeName.Text.Trim()) || string.IsNullOrEmpty(txtSpecName.Text.Trim()) || string.IsNullOrEmpty(txtSpecUnit.Text.Trim()))
            {
                ComUtil.MsgBox("带 * 为必填项！");
            }
            else //if (issaved == false)
            {
                //定义对接产品对照表实体类
                productmapitemOper = new Gpo_Product_MapModel();

                LogedInUser CurrentUser = ClientSession.GetInstance().CurrentUser;

                productmapitemOper.IsMap = "0";//未匹配

                if (dgvProIDCompare.CurrentRow != null)
                {
                    productmapitemOper.ProductID = this.dgvProIDCompare.CurrentRow.Cells["PRO_ID"].Value.ToString();     //产品ID
                    productmapitemOper.Map_Orgid = CurrentUser.UserOrg.Reg_org_id;
                    productmapitemOper.Sender_Id = this.dgvProIDCompare.CurrentRow.Cells["SenderId"].Value.ToString();     //配送企业ID
                    productmapitemOper.Factory_Id = this.dgvProIDCompare.CurrentRow.Cells["FactoryId"].Value.ToString();   //生产企业ID
                    productmapitemOper.IsMap = "1";//已匹配
                }
                //转换字符
                CharConvert();
                productmapitemOper.ID = this.strID;
                productmapitemOper.ProductCode = this.txtCode.Text;
                productmapitemOper.CommonName = this.txtCommonName.Text;
                productmapitemOper.Product_Name = this.txtName.Text;
                productmapitemOper.Mode_ID = this.txtModeCode.Text;
                productmapitemOper.Mode_Name = this.txtModeName.Text;

                productmapitemOper.Medical_Spec_Id = this.txtSpecCode.Text;
                productmapitemOper.Medical_Spec = this.txtSpecName.Text;
                productmapitemOper.Stand_Rate = this.txtStandRate.Text;
                productmapitemOper.Package_Rate = this.txtPackageRate.Text;

                productmapitemOper.UseUnitCode = this.txtUseUnitCode.Text;
                productmapitemOper.Use_Unit = this.txtUseUnit.Text;

                productmapitemOper.Spec_Unit_Id = this.txtSpecUnitCode.Text;
                productmapitemOper.Spec_Unit = this.txtSpecUnit.Text;
                productmapitemOper.Factory_Code = this.txtProducerCode.Text;
                productmapitemOper.Factory_Name = this.txtProducer.Text;

              
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
            bool flag = ProductCodeCompareBLL.GetInstance("ClientDB").JudgeHisProductCode(productmapitem.ProductCode);
            if (flag == false )
            {   //产品编码没有重复
                ProductCodeCompareBLL.GetInstance("ClientDB").Add_Gpo_Product_Map(productmapitem,out strID);
                InitCommListDT();
                Filter();
                issaved = true;
                ComUtil.MsgBox("保存成功！");
            }
            else
            {
                ComUtil.MsgBox("该产品编码已存在！");
            }
        }

        //修改操作
        private void SaveUpdate(Gpo_Product_MapModel productmapitem)
        {
            issaved = true;
            ProductCodeCompareBLL.GetInstance("ClientDB").Edit_Gpo_Product_Map(productmapitem);
            InitCommListDT();
            Filter();
            ComUtil.MsgBox("保存成功！");
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
        //add by cjg   
        /// <summary>
        /// 转换异常字符
        /// </summary>
        private void CharConvert()
        {
            foreach (Control con in this.groupBox2.Controls)
            {
                if (con is TextBox && !(con.Text.StartsWith("[")  && con.Text.EndsWith("]")))
                {
                    con.Text = StringUtils.repalceSepStr(con.Text);                   
                    
                }                
            }        
        }

    }
}