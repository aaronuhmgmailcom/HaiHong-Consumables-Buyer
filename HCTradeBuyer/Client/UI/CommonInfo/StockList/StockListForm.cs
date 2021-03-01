//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	StockListForm.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	常用可采购目录
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

using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Client.Common;
using Emedchina.TradeAssistant.Client.BLL;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Client.BLL.CommonInfo;
using Emedchina.TradeAssistant.Client.UI.CommonInfo.OrdProduct;
using System.Threading;

namespace Emedchina.TradeAssistant.Client.UI.CommonInfo.StockList
{
    /// <summary>
    /// 常用可采购目录
    /// </summary>
    public partial class StockListForm : BaseForm
    {
        #region 变量定义区
        //定义当前采购目录数据集
        private DataTable HitCommDt = null;
        //定义当前产品分类数据集
        private DataTable dtProductClass = null;
        
        //定义当前用户对象
        private LogedInUser CurrentUser = null;
        #endregion

        public StockListForm()
        {
            InitializeComponent();
        }

        #region 页面加载
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockListForm_Load(object sender, EventArgs e)
        {
            //获取当取用户对象
            CurrentUser = base.CurrentUser;

            InitData();
            DataBind();

            this.btnNew.Focus();
        }
        #endregion

        #region 新增事件
        /// <summary>
        /// 新增可采购目录信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            EditStockListForm frm = new EditStockListForm();
            frm.ShowDialog();

            if (frm.EditFlag)
            {
                //数据发生变动，刷新数据
                string strProjectID = LueProject.EditValue.ToString();
                //使用缓存 获取采购目录查询数据集
                string strDataName = Constant.HITCOMMTABLE + strProjectID;
                if (ClientCache.CachedDS.Tables.IndexOf(strDataName) != -1)
                    ClientCache.CachedDS.Tables.Remove(strDataName);
                DataBind();
            }
        }
        #endregion

        #region 查看商品信息
        /// <summary>
        /// 查看商品详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnView_Click(object sender, EventArgs e)
        {
            if (this.gVStockList.RowCount == 0)
                return;

            //string strProjectProductID = GetGridViewColValue(this.gVStockList, "PROJECT_PRODUCT_ID");

            DataRow dr = this.gVStockList.GetDataRow(this.gVStockList.FocusedRowHandle);

            string strProjectProductID = dr["PROJECT_PRODUCT_ID"].ToString();
            string strSpec = dr["SPEC"].ToString();
            string strModel = dr["MODEL"].ToString();

            ViewOrdProductForm frm = new ViewOrdProductForm(strProjectProductID, strSpec,strModel);
            frm.ShowDialog();
        }
        #endregion

        /// <summary>
        /// 获取当前选择列值
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public string GetGridViewColValue(DevExpress.XtraGrid.Views.Base.ColumnView view,string ColName)
        {
            string value = string.Empty;

            if (view.RowCount == 0)
                return value;

            DevExpress.XtraGrid.Columns.GridColumn colvalue = view.Columns.ColumnByFieldName(ColName);
            value = view.GetRowCellValue(view.FocusedRowHandle, colvalue).ToString();

            return value;
        }

        /// <summary>
        /// 修改商品信息(库房、配送商、配送单位)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (this.gVStockList.RowCount == 0)
                return;

            string strHitCommID = GetGridViewColValue(this.gVStockList, "ID");

            ViewStockListForm frm = new ViewStockListForm(strHitCommID);
            frm.ShowDialog();

            if (frm.EditFlag)
            {
                //数据发生变动，刷新数据
                string strProjectID = LueProject.EditValue.ToString();
                //使用缓存 获取采购目录查询数据集
                string strDataName = Constant.HITCOMMTABLE + strProjectID;
                if (ClientCache.CachedDS.Tables.IndexOf(strDataName) != -1)
                    ClientCache.CachedDS.Tables.Remove(strDataName);
                DataBind();
                Filter();

                //清空制单时用到供应目录缓存
                string strDataNameByPurchace = Constant.ORDPRODUCT + strProjectID + "经常采购目录";
                if (ClientCache.CachedDS.Tables.IndexOf(strDataNameByPurchace) != -1)
                    ClientCache.CachedDS.Tables.Remove(strDataNameByPurchace);
            }
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
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbSearch_Click(object sender, EventArgs e)
        {
            DataBind();
            Filter();
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBind()
        {
            //获取所选择项目类型
            string strProjectID = string.Empty;
            if (LueProject.EditValue != null)
            {
                strProjectID = LueProject.EditValue.ToString();
            }

            //使用缓存 获取采购目录查询数据集
            string strDataName = Constant.HITCOMMTABLE + strProjectID;
            //使用缓存 获取采购目录查询数据集
            if (ClientCache.CachedDS.Tables.IndexOf(strDataName) == -1)
            {
                DataTable tempDt = new DataTable(strDataName);

                //获取采购目录查询数据集
                tempDt = StockListBLL.GetInstance().GetStockList(CurrentUser, strProjectID, strDataName);

                HitCommDt = tempDt.Copy();

                if (ClientCache.CachedDS.Tables.IndexOf(strDataName) != -1)
                    ClientCache.CachedDS.Tables.Remove(strDataName);
                ClientCache.CachedDS.Tables.Add(HitCommDt);
            }

            //存入缓存
            InitFromCacheByData(strDataName);

            //从缓存取数据集绑定到GRID
            bindingDsHitComm();
            
        }

        #region 绑定到GRID中
        /// <summary>
        /// 绑定到GRID中
        /// </summary>
        private void bindingDsHitComm()
        {
            //this.GridHitComm.BeginInit();
            this.bindingSource1.DataSource = base.cachedDataView;
            //this.GridHitComm.EndInit();
            if (HitCommDt == null || HitCommDt.Rows.Count < 1)
            {
                HitCommDt = base.cachedDataView.Table;
            }
        }
        #endregion

        #region 查询过滤方法
        /// <summary>
        /// 查询过滤方法
        /// </summary>
        private void Filter()
        {
            //项目类型
            string ProjectType = string.Empty;
            if (this.LueProjectType.EditValue != null && !this.LueProjectType.EditValue.ToString().Equals("0"))
            {
                ProjectType = this.LueProjectType.EditValue.ToString().Trim();
            }
            //项目ID
            string ProjectId = string.Empty;
            if (this.LueProject.EditValue != null)
            {
                ProjectId = this.LueProject.EditValue.ToString().Trim();
            }
            //产品分类ID
            string ClassId = string.Empty;
            if (this.LueProductClass.EditValue != null && !this.LueProductClass.EditValue.ToString().Equals("0"))
            {
                ClassId = this.LueProductClass.EditValue.ToString().Trim();
            }
            string ProductName = this.txtCommerceName.Text.Trim();
            string SpecModel = this.txtSpecModel.Text.Trim();
            string SenderName = this.txtMeasureCor.Text.Trim();
            string ManuName = this.txtManuName.Text.Trim();
            string SalerName = this.txtSalerName.Text.Trim();

            StringBuilder StrFilter = new StringBuilder();

            StrFilter.Append("1=1");

            //项目类型
            if (!string.IsNullOrEmpty(ProjectType))
            {
                StrFilter.AppendFormat(" AND PROJECT_TYPE LIKE '%{0}%'", ProjectType);
            }

            //项目ID
            if (!string.IsNullOrEmpty(ProjectId))
            {
                StrFilter.AppendFormat(" AND PROJECT_ID = '{0}'", ProjectId);
            }

            //产品分类ID
            if (!string.IsNullOrEmpty(ClassId))
            {
                StrFilter.AppendFormat(" AND CLASS_ID = '{0}'", ClassId);
            }

            //商品名称
            if (!string.IsNullOrEmpty(ProductName))
            {
                StrFilter.AppendFormat(" AND (PRODUCT_NAME LIKE '%{0}%' Or COMMON_NAME LIKE '%{0}%' Or ABBR_PY LIKE '%{0}%' Or ABBR_WB LIKE '%{0}%' Or PRODUCT_MNEMONIC LIKE '%{0}%' Or ALIAS LIKE '%{0}%' Or ALIAS_PINYIN LIKE '%{0}%')", ProductName);
            }

            //规格型号
            if (!string.IsNullOrEmpty(SpecModel))
            {
                StrFilter.AppendFormat(" AND (SPEC LIKE '%{0}%' Or MODEL LIKE '%{0}%')", SpecModel);
            }

            //配送企业
            if (!string.IsNullOrEmpty(SenderName))
            {
                StrFilter.AppendFormat(" AND (SENDER_NAME LIKE '%{0}%' Or SENDER_NAME_ABBR LIKE '%{0}%' Or SENDER_NAME_SPELL_ABBR LIKE '%{0}%' Or SENDER_NAME_WB LIKE '%{0}%')", SenderName);
            }

            //生产企业
            if (!string.IsNullOrEmpty(ManuName))
            {
                StrFilter.AppendFormat(" AND (MANU_NAME LIKE '%{0}%' Or MANU_NAME_ABBR LIKE '%{0}%' Or MANU_NAME_SPELL_ABBR LIKE '%{0}%' Or MANU_NAME_WB LIKE '%{0}%')", ManuName);
            }

            //经销企业
            if (!string.IsNullOrEmpty(SalerName))
            {
                StrFilter.AppendFormat(" AND (SALER_NAME LIKE '%{0}%' Or SALER_NAME_ABBR LIKE '%{0}%' Or SALER_NAME_SPELL_ABBR LIKE '%{0}%' Or SALER_NAME_WB LIKE '%{0}%')", SalerName);
            }

            if (base.cachedDataView != null)
            {
                base.cachedDataView.RowFilter = StrFilter.ToString();
            }

        }
        #endregion

        #region 按条件查询事件
        private void Found_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }
        #endregion

        #region 初始化列表
        /// <summary>
        /// 初始化
        /// </summary>
        private void InitData()
        {
            InitData_ProjectType();
            InitData_Project();
            InitData_ProjectClass();
        }

        /// <summary>
        /// 初始化项目类型
        /// </summary>
        private void InitData_ProjectType()
        {
            //绑定项目类型
            DataTable dt = new DataTable();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns[0].ColumnName = "value";
            dt.Columns[1].ColumnName = "Name";

            string[] data0 = { "0", "全部" };
            dt.Rows.Add(data0);
            string[] data1 = { "1", "招投标" };
            dt.Rows.Add(data1);
            string[] data2 = { "2", "备案采购" };
            dt.Rows.Add(data2);
            string[] data3 = { "3", "竞价采购" };
            dt.Rows.Add(data3);
            string[] data4 = { "4", "浏览采购" };
            dt.Rows.Add(data4);

            LueProjectType.Properties.DataSource = dt;
            //LueProjectType.Properties.Columns.Clear();
            //LueProjectType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", 100, "类型名称"));
            //LueProjectType.Properties.DisplayMember = "Name";
            //LueProjectType.Properties.ValueMember = "value";
            LueProjectType.Properties.NullText = "全部";

            LueProjectType.EditValue = "0";//默认为“招投标”
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
        /// 绑定品种分类信息
        /// </summary>
        private void InitData_ProjectClass()
        {
            //绑定品种分类信息
            dtProductClass = CommUtilBLL.GetInstance().GetProductClassInfoByProjectID("");

            this.LueProductClass.Properties.DataSource = dtProductClass.DefaultView;
            LueProductClass.Properties.Columns.Clear();
            LueProductClass.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLASS_NAME", 100, "分类名称"));
            LueProductClass.Properties.DisplayMember = "CLASS_NAME";
            LueProductClass.Properties.ValueMember = "ID";
            LueProductClass.Properties.NullText = "全部";

            LueProductClass.EditValue = 0;//默认为“全部”
        }

        /// <summary>
        /// 过滤产品分类
        /// </summary>
        /// <param name="strProjectID"></param>
        private void Filter_ProjectClass(string strProjectID)
        {
            dtProductClass.DefaultView.RowFilter = string.Format(" ID=0 Or PROJECT_ID='{0}'", strProjectID);
            LueProductClass.EditValue = 0;//默认为“全部”
        }
        #endregion

        #region 删除采购供应目录
        /// <summary>
        /// 删除采购供应目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //提示信息
            if (XtraMessageBox.Show("确认删除采购供应目录信息吗？", Constant.MsgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            string strHitDommId = GetGridViewColValue(this.gVStockList,"ID");
            try
            {
                StockListBLL.GetInstance().DelOrdHitCommModel(strHitDommId);

                //刷新数据集
                RefreshDt();

                XtraMessageBox.Show("采购供应目录信息删除成功！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                //清空制单时用到供应目录缓存
                string strProjectID = LueProject.EditValue.ToString();
                string strDataNameByPurchace = Constant.ORDPRODUCT + strProjectID + "经常采购目录";
                if (ClientCache.CachedDS.Tables.IndexOf(strDataNameByPurchace) != -1)
                    ClientCache.CachedDS.Tables.Remove(strDataNameByPurchace);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("采购供应目录信息删除失败！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        /// <summary>
        /// 刷新数据集 删除时
        /// </summary>
        private void RefreshDt()
        {
            DataRow dr = this.gVStockList.GetDataRow(this.gVStockList.FocusedRowHandle);
            HitCommDt.Rows.Remove(dr);
        }

        /// <summary>
        /// 加入序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gVStockList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
        /// 表格数据改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gVStockList_RowCountChanged(object sender, EventArgs e)
        {
            labelControlCount.Text = "    共" + gVStockList.RowCount + "条数据";
        }

        /// <summary>
        /// 选择项目后查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LueProject_EditValueChanged(object sender, EventArgs e)
        {
            DataBind();
            if (LueProject.EditValue != null && dtProductClass != null)
            {
                Filter_ProjectClass(LueProject.EditValue.ToString());
            }
            this.Filter();
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

        private void gVStockList_Click(object sender, EventArgs e)
        {
            DataRow dr = this.gVStockList.GetDataRow(this.gVStockList.FocusedRowHandle);
            if (dr != null)
            {
                if (this.gVStockList.FocusedColumn.FieldName.ToUpper() == "SENDER_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["SENDER_NAME"].ToString());

                else if (this.gVStockList.FocusedColumn.FieldName.ToUpper() == "SALER_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["SALER_NAME"].ToString());

                else if (this.gVStockList.FocusedColumn.FieldName.ToUpper() == "MANU_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["MANU_NAME"].ToString());

                else
                    toolTipController1.HideHint();
            }
        }
        #endregion

        #region 产品过有效期后，记录显红色
        /// <summary>
        /// 产品过有效期后，记录显红色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gVStockList_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //if (e.RowHandle != this.gVStockList.FocusedRowHandle)
            //{

            DataRow dr = (DataRow)gVStockList.GetDataRow(e.RowHandle);

            if (dr == null)
                return;

            string RegDate = dr["REG_VALID_DATE"].ToString();

            if (!string.IsNullOrEmpty(RegDate))
            {
                DateTime RegDt = Convert.ToDateTime(RegDate);

                if (RegDt < DateTime.Now)
                {
                    e.Appearance.ForeColor = Color.Red;
                    //e.Appearance.BackColor = Color.White;
                }
            }
            //}
        }
        #endregion

    }
}