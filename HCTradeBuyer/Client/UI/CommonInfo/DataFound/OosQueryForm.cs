//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	OosQueryForm.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	缺货查询
//	修 改 人: 
//	修改日期:
//=====================================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;

using Emedchina.TradeAssistant.Client.Common;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Client.DAL.Comm;
using Emedchina.TradeAssistant.Client.BLL;
using Emedchina.TradeAssistant.Client.BLL.CommonInfo;
using Emedchina.TradeAssistant.Client.UI.Report.ReportForm;
using Emedchina.TradeAssistant.Client.UI.Report.ReportFile;
using Emedchina.TradeAssistant.Client.BLL.Report;


namespace Emedchina.TradeAssistant.Client.UI.CommonInfo.DataFound
{
    /// <summary>
    /// 缺货查询
    /// </summary>
    public partial class OosQueryForm : BaseForm
    {
        #region 变量定义区
        //常用可采购目录数据集对象
        private DataTable OosQueryDt = null;

        //定义当前产品分类数据集
        private DataTable dtProductClass = null;

        #endregion

        #region 构造
        public OosQueryForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 页面加载
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OosQueryForm_Load(object sender, EventArgs e)
        {
            InitData();
            DataBind();
            //Filter();
        }
        #endregion

        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBind()
        {
            //获取当取用户对象
            LogedInUser CurrentUser = base.CurrentUser;

            //获取所选择项目类型
            string strProjectID = string.Empty;

            if (LueProject.EditValue != null)
            {
                strProjectID = LueProject.EditValue.ToString();
            }

            //使用缓存 获取采购目录查询数据集
            if (ClientCache.CachedDS.Tables.IndexOf(Constant.OOSQUERY) == -1)
            {
                DataTable tempDt = new DataTable(Constant.OOSQUERY);

                //获取缺货数据
                tempDt = OosQueryBLL.GetInstance().GetOosProductInfo(CurrentUser, strProjectID);

                OosQueryDt = tempDt.Copy();

                if (ClientCache.CachedDS.Tables.IndexOf(Constant.OOSQUERY) != -1)
                    ClientCache.CachedDS.Tables.Remove(Constant.OOSQUERY);
                ClientCache.CachedDS.Tables.Add(OosQueryDt);
            }

            //存入缓存
            InitFromCacheByData(Constant.OOSQUERY);

            //从缓存取数据集绑定到GRID
            bindingDsOosQuery();
        }
        #endregion

        #region 绑定到GRID中
        /// <summary>
        /// 绑定到GRID中
        /// </summary>
        private void bindingDsOosQuery()
        {
            this.bindingSource1.DataSource = base.cachedDataView;
            if (OosQueryDt == null || OosQueryDt.Rows.Count < 1)
            {
                OosQueryDt = base.cachedDataView.Table;
            }
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
            LueProjectType.Properties.Columns.Clear();
            LueProjectType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", 100, "类型名称"));
            LueProjectType.Properties.DisplayMember = "Name";
            LueProjectType.Properties.ValueMember = "value";
            LueProjectType.Properties.NullText = "";

            LueProjectType.EditValue = "0";
        }

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

            //默认显示第一个项目
            string DefaultProjectID = dtPro.Rows[0]["ID"].ToString().Trim();
            LueProject.EditValue = Convert.ToInt32(DefaultProjectID);
        }

        private void InitData_ProjectClass()
        {
            //绑定品种分类信息
            dtProductClass = CommUtilBLL.GetInstance().GetProductClassInfoByProjectID("");

            this.LueProductClass.Properties.DataSource = dtProductClass;
            LueProductClass.Properties.Columns.Clear();
            LueProductClass.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLASS_NAME", 100, "分类名称"));
            LueProductClass.Properties.DisplayMember = "CLASS_NAME";
            LueProductClass.Properties.ValueMember = "ID";
            LueProductClass.Properties.NullText = "全部";

            LueProductClass.EditValue = 0;//默认为“全部”
        }

        private void Filter_ProjectClass(string strProjectID)
        {
            dtProductClass.DefaultView.RowFilter = string.Format(" ID=0 Or PROJECT_ID='{0}'", strProjectID);
            LueProductClass.EditValue = 0;//默认为“全部”
        }

        #endregion

        #region 关闭事件
        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 查询事件
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbSearch_Click(object sender, EventArgs e)
        {
            Filter();
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

            string ProductName = this.txtProductName.Text.Trim();
            string Spec = this.txtSpec.Text.Trim();
            string Model = this.txtModel.Text.Trim();
            string SenderName = this.txtMeasureCor.Text.Trim();
            string ManuName = this.txtManuName.Text.Trim();
            string SalerName = this.txtSalerName.Text.Trim();
            string StateName = this.cmbStateName.Text.Trim();

            StringBuilder StrFilter = new StringBuilder();

            StrFilter.Append("1=1");

            //项目类型
            if (!string.IsNullOrEmpty(ProjectType))
            {
                StrFilter.AppendFormat(" AND PROJECT_TYPE = '{0}'", ProjectType);
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
                StrFilter.AppendFormat(" AND PRODUCT_NAME LIKE '%{0}%'", ProductName);
            }

            //规格
            if (!string.IsNullOrEmpty(Spec))
            {
                StrFilter.AppendFormat(" AND Spec LIKE '%{0}%'", Spec);
            }

            //型号
            if (!string.IsNullOrEmpty(Model))
            {
                StrFilter.AppendFormat(" AND Model LIKE '%{0}%'", Model);
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

            //商品状态
            if (!string.IsNullOrEmpty(StateName))
            {
                StrFilter.AppendFormat(" AND StateName LIKE '%{0}%'", StateName);
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

        #region 加入序号及更改记录数
        /// <summary>
        /// 加入序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gVHitCommOOS_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            int rowIndex = e.RowHandle;
            if (rowIndex >= 0)
            {
                rowIndex++;
                e.Info.DisplayText = rowIndex.ToString();
            }
            e.Info.ImageIndex = -1;
        }

        private void gVHitCommOOS_RowCountChanged(object sender, EventArgs e)
        {
            labelControlCount.Text = "    共 " + gVHitCommOOS.RowCount + " 条数据";
        }
        #endregion

        #region 打印
        private void btnPrint_Click(object sender, EventArgs e)
        {
            FrmPrint frmPrint = new FrmPrint(new OOSQueryXtraReport(base.CurrentUserOrgName + "缺货查询报表"), base.cachedDataView.Table);
            frmPrint.ShowDialog();
        }
        #endregion

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

        private void gVHitCommOOS_Click(object sender, EventArgs e)
        {
            DataRow dr = this.gVHitCommOOS.GetDataRow(this.gVHitCommOOS.FocusedRowHandle);
            if (dr != null)
            {
                if (this.gVHitCommOOS.FocusedColumn.FieldName.ToUpper() == "SENDER_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["SENDER_NAME"].ToString());

                else if (this.gVHitCommOOS.FocusedColumn.FieldName.ToUpper() == "SALER_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["SALER_NAME"].ToString());

                else if (this.gVHitCommOOS.FocusedColumn.FieldName.ToUpper() == "MANU_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["MANU_NAME"].ToString());

                else
                    toolTipController1.HideHint();
            }
        }
        #endregion

        private void LueProject_EditValueChanged(object sender, EventArgs e)
        {
            if (LueProject.EditValue != null && dtProductClass != null)
            {
                Filter_ProjectClass(LueProject.EditValue.ToString());
            }
            this.Filter();
        }
    }
}