#region Header
/*****************************************************************************
 * $Header: /TradeAssistantSaler1.2.root/TradeAssistantSaler/TradeAssistantSaler/Self/FormSelf.cs 50    06-10-31 16:54 Liangxy $
 * $Author: Liangxy $
 * $Revision: 50 $
 * $Date: 06-10-31 16:54 $
 * $History: FormSelf.cs $
 * 
 * *****************  Version 50  *****************
 * User: Liangxy      Date: 06-10-31   Time: 16:54
 * Updated in $/TradeAssistantSaler1.2.root/TradeAssistantSaler/TradeAssistantSaler/Self
 * 
 * *****************  Version 49  *****************
 * User: Panyj        Date: 06-09-11   Time: 15:57
 * Updated in $/TradeAssistantSaler1.2.root/TradeAssistantSaler/TradeAssistantSaler/Self
 * 
 * *****************  Version 48  *****************
 * User: Panyj        Date: 06-09-11   Time: 15:43
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Self
 * 
 * *****************  Version 47  *****************
 * User: Panyj        Date: 06-09-08   Time: 13:49
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Self
 * 
 * *****************  Version 46  *****************
 * User: Panyj        Date: 06-09-08   Time: 10:13
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Self
 * 
 * *****************  Version 45  *****************
 * User: Panyj        Date: 06-09-07   Time: 17:28
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Self
 * 
 * *****************  Version 44  *****************
 * User: Sunhl        Date: 06-09-04   Time: 10:08
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Self
 ********************************************************************************/
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Client.Common;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Client.Contract;
using Emedchina.TradeAssistant.Client.Order.SalerReturn;
using Emedchina.TradeAssistant.Client.Order.OrderSaler;
using Emedchina.TradeAssistant.Sync.Order;
using Emedchina.TradeAssistant.Client.Map.Hospital;
using Emedchina.TradeAssistant.Client.Map.Product;
using Emedchina.TradeAssistant.Client.UI.DataMaintenance;
using Emedchina.TradeAssistant.Client.UI.TradeManage;
//去掉了private void setOrderCache()，以免引起混淆
namespace Emedchina.TradeAssistant.Client.Self
{
    /// <summary>
    /// 应用程序主窗体

    /// </summary>
    public partial class FormSelf : Form
    {

        LoginForm login;

        public FormSelf()
        {
            InitializeComponent();
        }

        public FormSelf(LoginForm loginForm)
        {
            InitializeComponent();
            login = loginForm;
            //setOrderCache();            
        }

        #region exit App
        /// <summary>
        /// 退出应用程序

        /// </summary>
        private void TSMItem_Exit_Click(object sender, EventArgs e)
        {

            EndForm form = new EndForm(login, this);
            form.ShowDialog();

        }
        #endregion

        #region FormShowDialog
        /// <summary>
        /// 新开窗体
        /// </summary>
        ///　<param name="frm">新开窗体实例</param>
        public static void FormShowDialog(Form frm)
        {
            frm.ShowDialog();
            frm.Dispose();
        }
        #endregion

        #region LoadFormToPanel
        /// <summary>
        /// 点击菜单子窗体Dock到夫窗体指定容器panel
        /// </summary>
        /// <param name="frm">子窗体实例</param>
        public void LoadFormToPanel(MainFormBase frm)
        {
            this.panelMain.Controls.Clear();
            //modified by sunhl
            if (this.panelMain.Controls.Contains(frm))
            {
                frm.Show();
                frm.BringToFront();
                this.labelfrmtxt.Text = frm.Text;
                this.tableLayoutPanel.Visible = (this.panelMain.Controls.Count > 0);
            }
            else
            {
                frm.Location = new Point(0, 0);
                frm.TopLevel = false;
                frm.TopMost = false;
                frm.ControlBox = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                frm.Visible = true;
                this.panelMain.Controls.Add(frm);
                frm.Show();
                frm.BringToFront();
                this.labelfrmtxt.Text = frm.Text;
                this.tableLayoutPanel.Visible = (this.panelMain.Controls.Count > 0);
            }
        }
        #endregion

        //add by yanbing20070924 添加重载方法
        #region LoadFormToPanel(重载使用窗体为BaseForm)
        /// <summary>
        /// 点击菜单子窗体Dock到夫窗体指定容器panel
        /// </summary>
        /// <param name="frm">子窗体实例</param>
        public void LoadFormToPanel(BaseForm frm)
        {
            this.panelMain.Controls.Clear();
            //modified by sunhl
            if (this.panelMain.Controls.Contains(frm))
            {
                frm.Show();
                frm.BringToFront();
                this.labelfrmtxt.Text = frm.Text;
                this.tableLayoutPanel.Visible = (this.panelMain.Controls.Count > 0);
            }
            else
            {
                frm.Location = new Point(0, 0);
                frm.TopLevel = false;
                frm.TopMost = false;
                frm.ControlBox = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                frm.Visible = true;
                this.panelMain.Controls.Add(frm);
                frm.Show();
                frm.BringToFront();
                this.labelfrmtxt.Text = frm.Text;
                this.tableLayoutPanel.Visible = (this.panelMain.Controls.Count > 0);
            }
        }
        #endregion
        //end add

        private void formSelf_load(object sender, EventArgs e)
        {


            //"导出基础信息"判断业务流程("进销存"企业对接功能)，shangfu 2007-8-24
            //如果为1就是进销存对接接口     

            string clientPlat = UserConfigXml.GetConfigInfo("ClientPlat", "type");
            if ("1".Equals(clientPlat))
            {
                tsmExpBaseInfo.Visible = true;
            }
            else
            {
                tsmExpBaseInfo.Visible = false;
            }

            login.Hide();
            //modified by sunhl

            //Emedchina.TradeAssistant.Client.OrderStat frm = new Emedchina.TradeAssistant.Client.OrderStat();
            //this.LoadFormToPanel(frm);
            string className = FileControl.readLog();
            
            userStatusLable.Text = string.Format("当前用户:{0} ", ClientSession.GetInstance().CurrentUser.UserInfo.Name);
            //emptyStatusLabel.Width = GetEmptyLabelWidth();

            emptyStatusLabel.Text = GetEmptyLableText();
            this.Text = Application.ProductName;

            //下载更新的页面
            FormShowDialog(new SyncForm());

            //默认首页

            //自动导航到上次关闭系统时的页面
            if (!string.IsNullOrEmpty(ClientConfiguration.ResumeFlg) && ClientConfiguration.ResumeFlg.Equals("1"))
            {
                if (!string.IsNullOrEmpty(className))
                {
                    showLastState(className);
                }
            }



        }

       

        /// <summary>
        /// Handles the FormClosing event of the FormSelf control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.Windows.Forms.FormClosingEventArgs"/> instance containing the event data.</param>
        private void FormSelf_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("是否确认退出系统？", "交易助手", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    login.Close();
            //}
            //else
            //{
            //    e.Cancel = true;
            //}

            e.Cancel = true;
            EndForm form = new EndForm(login, this);
            form.ShowDialog();
        }

        private void FormSelf_Load(object sender, EventArgs e)
        {

        }

        //private void setOrderCache()
        //{
        //    CacheControl.GetInstance().setOrderCache();
        //}

        /// <summary>
        /// Handles the SizeChanged event of the statusStrip control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void statusStrip_SizeChanged(object sender, EventArgs e)
        {
            //emptyStatusLabel.Width = GetEmptyLabelWidth()

            emptyStatusLabel.Text = GetEmptyLableText();
        }

        /// <summary>
        /// Gets the empty width of the label.
        /// </summary>
        /// <returns></returns>
        private int GetEmptyLabelWidth()
        {
            int width = this.Width - userStatusLable.Width - copyrightStatusLabel.Width + 20;
            if (width <= 0)
                width = 0;

            return width;
        }

        /// <summary>
        /// Gets the spaces of empty lable.
        /// </summary>
        /// <returns></returns>
        private int GetSpacesOfEmptyLable()
        {
            int spaces = GetEmptyLabelWidth() / 7 + 1;
            if (spaces <= 0)
                spaces = 1;
            return spaces;
        }


        /// <summary>
        /// Gets the empty lable text.
        /// </summary>
        /// <returns></returns>
        private string GetEmptyLableText()
        {
            StringBuilder sb = new StringBuilder(80);

            sb.Append(' ', GetSpacesOfEmptyLable());

            return sb.ToString();
        }

        private void systemConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomConfig frm = new CustomConfig();
            frm.ShowDialog();
        }
        /// <summary>
        /// 利用反射恢复上次运行状态
        /// </summary>
        /// <param name="className">类名</param>
        private void showLastState(string className)
        {
            try
            {
                MainFormBase frm = (MainFormBase)System.Activator.CreateInstance(Type.GetType(className));
                LoadFormToPanel(frm);
            }
            catch
            {
                MessageBox.Show("状态恢复失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void setTitle(string title)
        {
            this.labelfrmtxt.Text = title;
        }

        #region 打开Web窗口 Panyj


        private void TSM_conmerchandisedir_Click(object sender, EventArgs e)
        {
            webLoad("conmerchandisedir");
        }

        private void TSM_contracttemplate_Click(object sender, EventArgs e)
        {
            webLoad("contracttemplate");
        }

        private void TSM_contractsign_Click(object sender, EventArgs e)
        {
            webLoad("contractsign");
        }

        private void TSM_contractquery_Click(object sender, EventArgs e)
        {
            webLoad("contractquery");
        }

        private void TSM_contractchange_Click(object sender, EventArgs e)
        {
            webLoad("contractchange");
        }

        public void webLoad(string item) {
            BrowserForm form = new BrowserForm();
            form.Target = item;
            //form.ShowDialog();
            LoadFormToPanel(form);
        }
        

        private void TSMItem_Help_Click(object sender, EventArgs e)
        {
            Help.ShowHelpIndex(this, Properties.Settings.Default.HelpUrl);
        }

        private void TSMItem_UserInfoEdit_Click(object sender, EventArgs e)
        {
            webLoad("userInfoEdit");
        }

       

        private void OrderApplyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webLoad("orderApply");
        }

        private void ApplyManagerToolStripMenuItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webLoad("applyManager");
        }
        #endregion

        private void systemConfigToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SystemConfig frm = new SystemConfig();
            frm.setTxtReadOnly();
            frm.ShowDialog();
        }
       

        /// <summary>
        /// 手动更新客户端软件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string updateUrl = Properties.Settings.Default.UpdateUrl;
            System.Diagnostics.Process.Start(updateUrl);
        }

        WarehouseMgr warehouseMgr = null;
        private WarehouseMgr WarehouseMgr
        {
            get
            {
                if (warehouseMgr == null)
                    warehouseMgr = new WarehouseMgr();
                return warehouseMgr;
            }
        }

        QueryOrderItem queryOrderItem = null;
        private QueryOrderItem QueryOrderItem
        {
            get
            {
                if (queryOrderItem == null)
                    queryOrderItem = new QueryOrderItem();
                return queryOrderItem;
            }
        }

        SalerReturnMainDlg salerReturnMain = null;
        private SalerReturnMainDlg SalerReturnMain
        {
            get
            {
                if (salerReturnMain == null)
                    salerReturnMain = new SalerReturnMainDlg();
                return salerReturnMain;
            }
        }

        private void toolStripBtn_OrderReturn_Click(object sender, EventArgs e)
        {
            BackManageToolStripMenuItem_Click(sender, e);
            //LoadFormToPanel(SalerReturnMain);
        }
        private SalerOrderList salerOrderList = null;
        private SalerOrderList SalerOrderList
        {
            get
            {
                if (salerOrderList == null)
                    salerOrderList = new SalerOrderList();
                return salerOrderList;
            }
        }
        private void toolStripBtn_OrderDealer_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(SalerOrderList);
        }

        private void orderHandleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(SalerOrderList);
        }

        private void BackManageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webLoad("ReturnList");
        }

        private void userinfo_Click(object sender, EventArgs e)
        {
            webLoad("userInfo");
        }

        private void HitCommSaler_Click(object sender, EventArgs e)
        {
            webLoad("HitCommSaler"); 
        }

        private void orderlist_Click(object sender, EventArgs e)
        {
            webLoad("OrderList");
        }

        private void ContractList_Click(object sender, EventArgs e)
        {
            webLoad("DirSearch");
        }

        private void CentContractList_Click(object sender, EventArgs e)
        {
            webLoad("ContractList");
        }

        private void TradeCount_Click(object sender, EventArgs e)
        {
            webLoad("TradeCount");
        }

        private void HospitalCatalog_Click(object sender, EventArgs e)
        {
            webLoad("HospitalCatalog");
        }

        private void UserComplain_Click(object sender, EventArgs e)
        {
            webLoad("UserComplain");
        }

        private void ViewNews_Click(object sender, EventArgs e)
        {
            webLoad("ViewNews");
        }

        private void Sms_Click(object sender, EventArgs e)
        {
            webLoad("Sms");
        }

        private void SmsReader_Click(object sender, EventArgs e)
        {
            webLoad("SmsReader");
        }

        private void UpdatePassWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webLoad("UserPassWord");
        }

        private void ContractSignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webLoad("ContractSign");
        }

        private void ContractUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webLoad("ContractUpdate");
        }

        private void NoticeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webLoad("NoticeList");
        }

        private void SmsNOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webLoad("SmsNo");
        }

        private void SyncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SyncForm sysForm = new SyncForm();
            sysForm.ShowDialog();
        }

        private void ToolStripMenuItemITConfig_Click(object sender, EventArgs e)
        {
            //Emedchina.TradeAsst.EmedHisHelper.FormMain frm = new Emedchina.TradeAsst.EmedHisHelper.FormMain();
            //frm.ShowDialog();
        }



   
     
        //医院编码匹配
        private void ToolStripMenuItemHospitalMap_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new HosptailIDComprison());
        }
     
        //产品编码匹配
        private void ToolStripMenuItemProductMap_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new ProductCodeCompareForm());
        }

        private void toolStripMenuItemUpdate_Click(object sender, EventArgs e)
        {
            string updateUrl = Properties.Settings.Default.UpdateUrl;
            System.Diagnostics.Process.Start(updateUrl);
        }


        //"导出基础信息"判断业务流程("进销存"企业对接功能)，shangfu 2007-8-24
        private void tsmExpBaseInfo_Click(object sender, EventArgs e)
        {
            ExpBaseInfo frm = new ExpBaseInfo();
            frm.ShowDialog();
        }

        private void WarehouseMgrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(WarehouseMgr);
           
        }

        private void QueryOrderItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(QueryOrderItem);
        }



    }
}