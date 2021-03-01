//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	AfficheInfoForm.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	公告信息查看
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
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Client.BLL.CommonInfo;
using Emedchina.TradeAssistant.Client.UI.CommonInfo.AfficheInfo;

namespace Emedchina.TradeAssistant.Client.UI.CommonInfo
{
    /// <summary>
    /// 公告信息查看
    /// </summary>
    public partial class AfficheInfoForm : BaseForm
    {
        //获取当取用户对象
        LogedInUser CurrentUser = null;

        //公告信息数据集对象
        private DataTable ArricheInfoDt = null;

        public AfficheInfoForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AfficheInfoForm_Load(object sender, EventArgs e)
        {
            //获取当取用户对象
            CurrentUser = base.CurrentUser;

            //初始化下拉列表
            InitData();

            //初始化查询
            AfficheInfoBind();
            Filter();
            this.txtTitle.Focus();
        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 数据绑定公告信息
        /// </summary>ss
        private void AfficheInfoBind()
        {
            ArricheInfoDt = BulletinInfoBLL.GetInstance().GetBulletinInfoDt(CurrentUser);

            if (ArricheInfoDt != null)
            {
                this.bindingSource1.DataSource = ArricheInfoDt.DefaultView;
            }
        }

        /// <summary>
        /// 查询过滤方法
        /// </summary>
        private void Filter()
        {
            //公告标题
            string strTitle = this.txtTitle.Text.ToString().Trim();
            //公告状态 （2已阅读 1未阅读）
            string strIsRead = this.LueState.EditValue.ToString().Trim();

            StringBuilder StrFilter = new StringBuilder();

            StrFilter.Append("1=1");

            //公告标题
            if (!string.IsNullOrEmpty(strTitle))
            {
                StrFilter.AppendFormat(" AND Title LIKE '%{0}%'", strTitle);
            }

            //状态
            if (!string.IsNullOrEmpty(strIsRead))
            {
                StrFilter.AppendFormat(" AND IS_READ='{0}'", strIsRead);
            }

            if (ArricheInfoDt != null)
            {
                if (ArricheInfoDt.DefaultView != null)
                {
                    this.ArricheInfoDt.DefaultView.RowFilter = StrFilter.ToString();
                }
            }

        }

        #region 按条件查询事件
        private void Found_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }
        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        private void InitData()
        {
            InitData_State();
        }

        /// <summary>
        /// 初始化状态
        /// </summary>
        private void InitData_State()
        {
            //绑定状态
            DataTable dt = new DataTable();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns[0].ColumnName = "value";
            dt.Columns[1].ColumnName = "Name";

            string[] data0 = { "", "全部" };
            dt.Rows.Add(data0);
            string[] data1 = { "2", "已阅读" };
            dt.Rows.Add(data1);
            string[] data2 = { "1", "未阅读" };
            dt.Rows.Add(data2);

            this.LueState.Properties.DataSource = dt;
            this.LueState.Properties.Columns.Clear();
            this.LueState.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", 100, "类型名称"));
            this.LueState.Properties.DisplayMember = "Name";
            this.LueState.Properties.ValueMember = "value";
            this.LueState.Properties.NullText = "";

            this.LueState.EditValue = "1";
        }

        /// <summary>
        /// 查看按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnView_Click(object sender, EventArgs e)
        {
            //判断是否为空数据集
            if (this.gviewAfficheInfo.RowCount == 0)
                return;

            //采购目录ID
            string strBulletionID = GetGridViewColValue(this.gviewAfficheInfo,"ID");
            ViewAfficheInfoForm frm = new ViewAfficheInfoForm(strBulletionID);
            frm.ShowDialog();

            string strReceiverID = GetGridViewColValue(this.gviewAfficheInfo, "ReceiverID");
            RefreshDt(strReceiverID);
        }

        /// <summary>
        /// 刷新数据集
        /// </summary>
        /// <param name="strReceiverID"></param>
        private void RefreshDt(string strReceiverID)
        {
            DataColumn[] keys = new DataColumn[1];
            DataColumn myColumn = new DataColumn();

            keys[0] = ArricheInfoDt.Columns[0];
            ArricheInfoDt.PrimaryKey = keys;

            DataRow dr = ArricheInfoDt.Rows.Find(strReceiverID);

            if (dr != null)
            {
                dr["IS_READ"] = "2";
                dr["ReadName"] = "已阅读";
            }
        }

        /// <summary>
        /// 获取Grid当前选择 某个字段值
        /// </summary>
        /// <param name="view">gridView对象</param>
        /// <param name="ColName">字段名</param>
        /// <returns></returns>
        public string GetGridViewColValue(DevExpress.XtraGrid.Views.Base.ColumnView view, string ColName)
        {
            string value = string.Empty;

            if (view.RowCount == 0)
                return value;

            DevExpress.XtraGrid.Columns.GridColumn colvalue = view.Columns.ColumnByFieldName(ColName);
            value = view.GetRowCellValue(view.FocusedRowHandle, colvalue).ToString();

            return value;
        }

        /// <summary>
        /// 加入序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gviewAfficheInfo_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            int rowIndex = e.RowHandle;
            if (rowIndex >= 0)
            {
                rowIndex++;
                e.Info.DisplayText = rowIndex.ToString();
            }
            e.Info.ImageIndex = -1;
        }

        private void gviewAfficheInfo_RowCountChanged(object sender, EventArgs e)
        {
            labelControlCount.Text = "    共 " + gviewAfficheInfo.RowCount + " 条数据";
        }

        #region 显示Tip
        private void gviewAfficheInfo_Click(object sender, EventArgs e)
        {
            DataRow dr = gviewAfficheInfo.GetDataRow(gviewAfficheInfo.FocusedRowHandle);
            if (dr != null)
            {
                if (gviewAfficheInfo.FocusedColumn.FieldName == "ISSUE_DATE")
                    toolTipLocationControl_ToolTipLocationChanged(dr["ISSUE_DATE"].ToString());
                
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
        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            AfficheInfoBind();
            Filter();
        }

    }
}