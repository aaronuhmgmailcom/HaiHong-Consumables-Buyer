//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	DefineCodeForm.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	自定义编码维护
//	修 改 人: 
//	修改日期:
//=====================================================================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;

using Emedchina.TradeAssistant.Client.Common;
using Emedchina.TradeAssistant.Client.BLL;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Model.CommInfo;
using Emedchina.TradeAssistant.Client.BLL.CommonInfo;
using Emedchina.TradeAssistant.Client.Base;

namespace Emedchina.TradeAssistant.Client.UI.CommonInfo.DefineCodeSet
{
    /// <summary>
    /// 自定义编码维护
    /// </summary>
    public partial class DefineCodeForm : BaseForm
    {
        //自定义编码数据集对象
        private DataTable DefineCodeDt = null;

        //临时数据集
        private DataTable TempDt = null;

        //行数据对象
        private DefineInfoModel defineInfoModel = null;

        //行数据对象列表
        private List<DefineInfoModel> defineInfoListModel = null;

        //获取当取用户对象
        LogedInUser CurrentUser = null;

        public DefineCodeForm()
        {
            InitializeComponent();
        }
         
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBind(string ProjectID)
        {
            //获取采购目录查询数据集
            DefineCodeDt = DefineCodeBLL.GetInstance().GetDefineCodeDt(ProjectID);

            this.bindingSource1.DataSource = DefineCodeDt.DefaultView;
        }

        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DefineCodeForm_Load(object sender, EventArgs e)
        {
            //获取当取用户对象
            CurrentUser = base.CurrentUser;

            defineInfoListModel = new List<DefineInfoModel>();

            InitData_Project();
            
            this.sbSearch.Focus();
        }

        /// <summary>
        /// 绑定项目名称
        /// </summary>
        private void InitData_Project()
        {
            //绑定项目名称
            DataTable dtPro = CommUtilBLL.GetInstance().GetProjectInfoByProjectType("");

            LueProject.Properties.DataSource = dtPro;
            LueProject.Properties.Columns.Clear();
            LueProject.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PROJECT_NAME", 200, "项目名称"));
            LueProject.Properties.DisplayMember = "PROJECT_NAME";
            LueProject.Properties.ValueMember = "ID";
            LueProject.Properties.NullText = "请选择项目";

            string DefaultProjectID = dtPro.Rows[0]["ID"].ToString().Trim();
            LueProject.EditValue = Convert.ToInt32(DefaultProjectID);
        }

        /// <summary>
        /// 查询按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbSearch_Click(object sender, EventArgs e)
        {
            string ProjectID = this.LueProject.EditValue.ToString();
            DataBind(ProjectID);
            Filter();
        }

        #region 查询过滤方法
        /// <summary>
        /// 查询过滤方法
        /// </summary>
        private void Filter()
        {
            if (DefineCodeDt == null)
            {
                return;
            }

            //项目ID
            string ProjectId = string.Empty;
            if (this.LueProject.EditValue != null)
            {
                ProjectId = this.LueProject.EditValue.ToString().Trim();
            }

            string strProductName = this.txtProductName.Text.Trim(); //商品名称
            string SpecModel = this.txtSpecModel.Text.Trim();        //规格型号
            string SenderName = this.txtMeasureCor.Text.Trim();      //配送企业
            string ManuName = this.txtManuName.Text.Trim();          //生产企业

            StringBuilder StrFilter = new StringBuilder();

            StrFilter.Append("1=1");

            //商品名称
            if (!string.IsNullOrEmpty(strProductName))
            {
                StrFilter.AppendFormat(" AND PRODUCT_NAME LIKE '%{0}%'", strProductName);
            }

            //规格型号
            if (!string.IsNullOrEmpty(SpecModel))
            {
                StrFilter.AppendFormat(" AND (Spec LIKE '%{0}%' Or Model LIKE '%{0}%')", SpecModel);
            }

            //配送企业
            if (!string.IsNullOrEmpty(SenderName))
            {
                StrFilter.AppendFormat(" AND (SENDER_NAME LIKE '%{0}%' Or SENDER_NAME_ABBR LIKE '%{0}%')", SenderName);
            }

            //生产企业
            if (!string.IsNullOrEmpty(ManuName))
            {
                StrFilter.AppendFormat(" AND (MANU_NAME LIKE '%{0}%' Or MANU_NAME_ABBR LIKE '%{0}%')", ManuName);
            }

            //项目ID
            if (!string.IsNullOrEmpty(ProjectId))
            {
                StrFilter.AppendFormat(" AND PROJECT_ID = '{0}'", ProjectId);
            }
            
            if (DefineCodeDt.DefaultView != null)
            {
                this.DefineCodeDt.DefaultView.RowFilter = StrFilter.ToString();
            }

        }
        #endregion

        #region 按条件查询事件
        private void Found_TextChanged(object sender, EventArgs e)
        {
            Filter();
            ShowDefineInfo();
        }
        #endregion

        /// <summary>
        /// 获取当前选中行对象
        /// </summary>
        /// <returns></returns>
        private DefineInfoModel GetDefineInfoModel(DataRow dr)
        {
            DefineInfoModel model = new DefineInfoModel();

            model.Hit_Comm_Id = dr["HIT_COMM_ID"].ToString();
            model.CommerceName = dr["PRODUCT_NAME"].ToString();
            model.CommonName    = dr["COMMON_NAME"].ToString();
            model.Spec          = dr["SPEC"].ToString();
            model.Model         = dr["MODEL"].ToString();
            model.ManuName      = dr["MANU_NAME"].ToString();
            model.Price         = base.SetNumFormat(dr["PRICE"].ToString());
            model.ProductMnemonic = dr["PRODUCT_MNEMONIC"].ToString();
            model.SelfPackage   = dr["SELF_PACKAGE"].ToString();
            if (string.IsNullOrEmpty(model.SelfPackage))
                model.SelfPackage = "1";
            model.Alias         = dr["ALIAS"].ToString();
            model.AliasPinyin   = dr["ALIAS_PINYIN"].ToString();

            return model;
        }

        /// <summary>
        /// 获取当前选择ID
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public string GetGridViewColValue(DevExpress.XtraGrid.Views.Base.ColumnView view)
        {
            string value = string.Empty;

            if (view.RowCount == 0)
                return value;

            DevExpress.XtraGrid.Columns.GridColumn colvalue = view.Columns.ColumnByFieldName("ID");
            value = view.GetRowCellValue(view.FocusedRowHandle, colvalue).ToString();

            return value;
        }

        #region 保存当前行对象（修改项）
        /// <summary>
        /// 保存自定义编码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtProductMnemonic_TextChanged(object sender, EventArgs e)
        {
            if (DefineCodeDt != null)
            {
                if (DefineCodeDt.DefaultView.Count > 0)
                {
                    DataRow dr = this.gVDefineInfo.GetDataRow(this.gVDefineInfo.FocusedRowHandle);
                    if (dr != null)
                        dr["PRODUCT_MNEMONIC"] = this.txtProductMnemonic.Text.Trim();
                }
            }
        }

        /// <summary>
        /// 保存大包装
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSelfPackage_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtSelfPackage.Text.Trim()))
                return;

            if (DefineCodeDt != null)
            {
                if (DefineCodeDt.DefaultView.Count > 0)
                {
                    DataRow dr = this.gVDefineInfo.GetDataRow(this.gVDefineInfo.FocusedRowHandle);
                    if (dr != null)
                        dr["SELF_PACKAGE"] = this.txtSelfPackage.Text.Trim();
                }
            }
        }

        /// <summary>
        /// 保存别名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAlias_TextChanged(object sender, EventArgs e)
        {
            if (DefineCodeDt != null)
            {
                if (DefineCodeDt.DefaultView.Count > 0)
                {
                    DataRow dr = this.gVDefineInfo.GetDataRow(this.gVDefineInfo.FocusedRowHandle);
                    if (dr != null)
                        dr["ALIAS"] = this.txtAlias.Text.Trim();
                }
            }
        }

        /// <summary>
        /// 保存别名拼音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAliasPinyin_TextChanged(object sender, EventArgs e)
        {
            if (DefineCodeDt != null)
            {
                if (DefineCodeDt.DefaultView.Count > 0)
                {
                    //DataRow dr = DefineCodeDt.Rows[this.gVDefineInfo.FocusedRowHandle];
                    DataRow dr = this.gVDefineInfo.GetDataRow(this.gVDefineInfo.FocusedRowHandle);
                    if (dr != null)
                        dr["ALIAS_PINYIN"] = this.txtAliasPinyin.Text.Trim();
                }
            }
        }

        #endregion

        /// <summary>
        /// 自定义编码及大包装修改后 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                defineInfoListModel = GetDefineInfoListModel();
                if (defineInfoListModel.Count == 0)
                    return;

                DefineCodeBLL.GetInstance().OperatorDefineInfoList(defineInfoListModel, this.CurrentUser);

                XtraMessageBox.Show("自定义编码及大包装设置成功！", Constant.APPNAME, MessageBoxButtons.OK, MessageBoxIcon.Information);

                //清空制单时用到供应目录缓存
                string strProjectID = LueProject.EditValue.ToString();
                string strDataNameByPurchace = Constant.ORDPRODUCT + strProjectID + "经常采购目录";
                if (ClientCache.CachedDS.Tables.IndexOf(strDataNameByPurchace) != -1)
                    ClientCache.CachedDS.Tables.Remove(strDataNameByPurchace);
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("自定义编码及大包装设置失败！", Constant.APPNAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 获取修改后的自定义编码列表对象
        /// </summary>
        /// <returns></returns>
        private List<DefineInfoModel> GetDefineInfoListModel()
        {
            defineInfoListModel.Clear();

            foreach (DataRow dr in DefineCodeDt.Rows)
            {
                if (dr.RowState == DataRowState.Modified)
                {
                    //if (!string.IsNullOrEmpty(dr["SELF_PACKAGE"].ToString()))
                    //{
                        DefineInfoModel model = GetDefineInfoModel(dr);

                        defineInfoListModel.Add(model);
                    //}
                }
            }
            return defineInfoListModel;
        }

        /// <summary>
        /// 加入序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gVDefineInfo_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            int rowIndex = e.RowHandle;
            if (rowIndex >= 0)
            {
                rowIndex++;
                e.Info.DisplayText = rowIndex.ToString();
            }
            e.Info.ImageIndex = -1;
        }
        
        /// <summary>
        /// 行选择改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gVDefineInfo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ShowDefineInfo();

            //this.txtProductMnemonic.Focus();
        }

        private void ShowDefineInfo()
        {
            if (DefineCodeDt == null)
                return;

            if (DefineCodeDt.DefaultView.Count == 0)
                return;

            DataRow dr = this.gVDefineInfo.GetDataRow(this.gVDefineInfo.FocusedRowHandle);

            defineInfoModel = GetDefineInfoModel(dr);

            //显示数据
            if (defineInfoModel != null)
            {
                this.txtViewProductName.Text = defineInfoModel.CommerceName;
                this.txtViewCommName.Text = defineInfoModel.CommonName;
                this.txtViewSpec.Text = defineInfoModel.Spec;
                this.txtViewModel.Text = defineInfoModel.Model;
                this.txtViewManuName.Text = defineInfoModel.ManuName;
                this.txtViewPrice.Text = defineInfoModel.Price;
                this.txtProductMnemonic.Text = defineInfoModel.ProductMnemonic;
                this.txtSelfPackage.Text = defineInfoModel.SelfPackage;
                this.txtAlias.Text = defineInfoModel.Alias;
                this.txtAliasPinyin.Text = defineInfoModel.AliasPinyin;
            }
        }
        
        private void gVDefineInfo_RowCountChanged(object sender, EventArgs e)
        {
            labelControlCount.Text = "    共 " + DefineCodeDt.DefaultView.Count.ToString() + " 条数据";
        }

        #region 显示Title
        private void toolTipLocationControl_ToolTipLocationChanged(string HintValue)
        {
            ToolTipControllerShowEventArgs args = toolTipController1.CreateShowArgs();
            args.ToolTip = HintValue;
            args.IconType = ToolTipIconType.Information;
            args.ImageIndex = -1;
            args.IconSize = ToolTipIconSize.Small;
            toolTipController1.ShowHint(args);
        }

        private void gVDefineInfo_Click(object sender, EventArgs e)
        {
            DataRow dr = this.gVDefineInfo.GetDataRow(this.gVDefineInfo.FocusedRowHandle);
            if (dr != null)
            {
                if (this.gVDefineInfo.FocusedColumn.FieldName.ToUpper() == "SENDER_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["SENDER_NAME"].ToString());

                else if (this.gVDefineInfo.FocusedColumn.FieldName.ToUpper() == "MANU_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["MANU_NAME"].ToString());

                else
                    toolTipController1.HideHint();
            }
            this.txtProductMnemonic.Focus();
        }
        #endregion

        #region 回车事件
        private void txtProductMnemonic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                this.txtSelfPackage.Focus();
            }
        }

        private void txtSelfPackage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                this.txtAlias.Focus();
            }
        }

        private void txtAlias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                this.txtAliasPinyin.Focus();
            }
        }

        private void txtAliasPinyin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                this.btnSave.Focus();
            }
        }
        #endregion

        private void txtProductMnemonic_Leave(object sender, EventArgs e)
        {
            string strProductMnemonic = this.txtProductMnemonic.Text.Trim();

            if (string.IsNullOrEmpty(strProductMnemonic))
                return;

            if (IsRepeatProductMnemonic(strProductMnemonic))
            {                
                this.txtProductMnemonic.Text = string.Empty;
                //该自定义编码重复
                XtraMessageBox.Show("该自定义编码已存在，请重新输入！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtProductMnemonic.Focus();
            }
        }

        private bool IsRepeatProductMnemonic(string strProductMnemonic)
        {
            bool flag = false;

            if (DefineCodeDt == null)
            {
                return flag;
            }

            if (DefineCodeDt.DefaultView != null)
            {
                DataTable dt = DefineCodeDt.Copy();

                dt.DefaultView.RowFilter = string.Format(" PRODUCT_MNEMONIC='{0}'",strProductMnemonic);

                if (dt.DefaultView.Count > 1)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }

            return flag;
        }

        #region 回车事件
        private void txtProductMnemonic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (string.IsNullOrEmpty(this.txtSelfPackage.Text))
                    this.txtSelfPackage.Text = "1";
                this.txtSelfPackage.Focus();
            }
        }

        private void txtSelfPackage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtAlias.Focus();
            }
        }

        private void txtAlias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtAliasPinyin.Focus();
            }
        }

        private void txtAliasPinyin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnSave.Focus();
            }
        }
        #endregion

    }
}