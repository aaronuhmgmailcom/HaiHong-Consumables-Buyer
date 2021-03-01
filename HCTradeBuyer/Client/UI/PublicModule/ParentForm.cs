using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Emedchina.TradeAssistant.Client.UI.UserManage;
using Emedchina.TradeAssistant.Client.UI.TradeManage;
using Emedchina.TradeAssistant.Client.UI.DataMaintenance;
using Emedchina.TradeAssistant.Client.UI.CommonInfo.StockList;
using Emedchina.TradeAssistant.Client.UI.Order.PurchaseHandle;
using Emedchina.TradeAssistant.Client.UI.TradeManage.DoWithOrder;
using Emedchina.TradeAssistant.Client.UI.CommonInfo.OrdBuyerReturn;
using Emedchina.TradeAssistant.Client.UI.CommonInfo.UseOddAudi;
using Emedchina.TradeAssistant.Client.UI.CommonInfo.OrdInvoice;
using Emedchina.TradeAssistant.Client.UI.CommonInfo.StockUp;
using Emedchina.TradeAssistant.Client.UI.CommonInfo.DataFound;
using Emedchina.TradeAssistant.Client.UI.SystemManage;
using Emedchina.TradeAssistant.Client.His.Enterprise;
using Emedchina.TradeAssistant.Client.His.Product;
using DevExpress.XtraBars;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Client.UI.CommonInfo.DefineCodeSet;
using Emedchina.TradeAssistant.Client.UI.CommonInfo;
using System.IO;
using System.Xml;

namespace Emedchina.TradeAssistant.Client.UI.PublicModule
{
    public partial class ParentForm : DevExpress.XtraEditors.XtraForm
    {
        //子窗体
        private Form frmX;
        private LogedInUser user;
        Form login;

        public ParentForm()
        {
            InitializeComponent();
            user = ClientSession.GetInstance().CurrentUser;
            InitSkins();
        }

        public ParentForm(Form frm)
        {
            InitializeComponent();
            user = ClientSession.GetInstance().CurrentUser;
            InitSkins();
            login = frm;
        }

        private void bbiUserInfoMgr_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserInfoMgr frmUserInfoMgr = new UserInfoMgr();
            frmUserInfoMgr.ShowDialog();
        }

        private void bbiAfficheInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new AfficheInfoForm();
            CreateMDIForm(frmX);
        }

        private void barButtonItemWareHouse_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new WarehouseMgr();
            CreateMDIForm(frmX);
        }

        private void barButtonItemHitCommon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new StockListForm();
            CreateMDIForm(frmX);
        }

        private void barButtonItemCreatePurchase_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new FormPurchaseBuild();
            CreateMDIForm(frmX);
        }

        private void barButtonItemCheckPurchase_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new FormPurchaseCkeck();
            CreateMDIForm(frmX);
        }

        private void barButtonItemOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new BuyerOrderList();
            CreateMDIForm(frmX);
        }

        private void barButtonItemReturn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new OrdBuyerReturnForm();
            CreateMDIForm(frmX);
        }

        private void barButtonItemStock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new OrdStockUpForm();
            CreateMDIForm(frmX);
        }

        private void barButtonItemUsing_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new UseOddAudiForm();
            CreateMDIForm(frmX);
        }

        private void barButtonItemSend_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new OrdInvoiceListForm();
            CreateMDIForm(frmX);
        }

        private void barButtonItemPurchaseQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new PurchaseCommerceForm();
            CreateMDIForm(frmX);
        }

        private void barButtonItemOrderQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new QueryOrderItem();
            CreateMDIForm(frmX);
        }

        private void barButtonItemOOS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new OosQueryForm();
            CreateMDIForm(frmX);
        }

        private void barButtonItemSysCfg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SystemConfigMgr frmSysForm = new SystemConfigMgr();
            frmSysForm.ShowDialog();
        }

        private void barButtonItemSysUpd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string updateUrl = Properties.Settings.Default.UpdateUrl;
            System.Diagnostics.Process.Start(updateUrl);
        }

        private void barButtonItemSync_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Form frm = new SyncForm();
            frm.ShowDialog();
        }

        private void barButtonItemPerCfg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserConfig frm = new UserConfig(this,login);
            frm.ShowDialog();
        }

        private void barButtonItemITCfg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Emedchina.TradeAsst.EmedHisHelper.FormMain frm = new Emedchina.TradeAsst.EmedHisHelper.FormMain();
            frm.ShowDialog();
        }

        private void barButtonItemCorpMap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new EnterpriseIDComprison();
            CreateMDIForm(frmX);
        }

        private void barButtonItemProductMatch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new ProductCodeCompareForm();
            CreateMDIForm(frmX);
        }

        private void barButtonItemExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EndForm form = new EndForm(login, this);
            form.ShowDialog();
        }

        private void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            EndForm form = new EndForm(login, this);
            form.ShowDialog();
        }

        private void ParentForm_Load(object sender, EventArgs e)
        {
            barStaticItemUser.Caption = "当前用户：" + user.UserInfo.Name;
            SyncForm frmSync = new SyncForm();
            frmSync.ShowDialog();
            bbiAfficheInfo_ItemClick(null, null);
            String today;
            string dayOfWeek ="";
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    dayOfWeek = "星期五";
                    break;
                case DayOfWeek.Monday:
                    dayOfWeek = "星期一";
                    break;
                case DayOfWeek.Saturday:
                    dayOfWeek = "星期六";
                    break;
                case DayOfWeek.Sunday:
                    dayOfWeek = "星期天";
                    break;
                case DayOfWeek.Thursday:
                    dayOfWeek = "星期四";
                    break;
                case DayOfWeek.Tuesday:
                    dayOfWeek = "星期二";
                    break;
                case DayOfWeek.Wednesday:
                    dayOfWeek = "星期三";
                    break;
            }
            today = DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString() + "月" + DateTime.Now.Day.ToString() + "日  \r\n\r\n" + dayOfWeek;
            barStaticItemToday.Caption = today;

        }

        /// <summary>
        /// 显示子窗体
        /// </summary>
        /// <param name="frm"></param>
        public void CreateMDIForm(Form frm)
        {
            frm.MdiParent = this;
            frm.Show();
        }



        /// <summary>
        /// 皮肤初始化
        /// </summary>
        void InitSkins()
        {
            string skName = "";
            if (!string.IsNullOrEmpty(ClientConfiguration.Skin))
                defaultLookAndFeel1.LookAndFeel.SetSkinStyle(ClientConfiguration.Skin);
            else
                defaultLookAndFeel1.LookAndFeel.SetSkinStyle("Money Twins"); 
            barManager1.ForceInitialize();
            foreach (DevExpress.Skins.SkinContainer skin in DevExpress.Skins.SkinManager.Default.Skins)
            {
                BarCheckItem item = new BarCheckItem();// Items.CreateCheckItem(skin.SkinName, false);
                switch (skin.SkinName)
                {
                    case "Caramel":
                        skName = "焦糖";
                        break;
                    case "Money Twins":
                        skName = "水晶蓝";
                        break;
                    case "Lilian":
                        skName = "夜空蓝";
                        break;
                    case "The Asphalt World":
                        skName = "青涩世界";
                        break;
                    case "iMaginary":
                        skName = "虚幻时空";
                        break;
                    case "Black":
                        skName = "黑色";
                        break;
                    case "Blue":
                        skName = "浅蓝";
                        break;
                    case "Office 2007 Blue":
                        skName = "Office 蓝";
                        break;
                    case "Office 2007 Black":
                        skName = "Office 黑";
                        break;
                    case "Office 2007 Silver":
                        skName = "Office 银";
                        break;
                    case "Coffee":
                        skName = "咖啡";
                        break;
                    case "Liquid Sky":
                        skName = "晴空万里";
                        break;
                    case "London Liquid Sky":
                        skName = "伦敦天空";
                        break;
                    case "Glass Oceans":
                        skName = "蓝色海洋";
                        break;
                    case "Stardust":
                        skName = "星云幻想";
                        break;

                }
                
                item.Tag = skin.SkinName;
                item.Caption = skName;
                item.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(OnPaintStyleClick);
                barSubItemSkin.AddItem(item);
            }
        }

        /// <summary>
        /// 皮肤菜单事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnPaintStyleClick(object sender, ItemClickEventArgs e)
        {
            defaultLookAndFeel1.LookAndFeel.SetSkinStyle(e.Item.Tag.ToString());
            string XmlPath = ClientConfiguration.LocalPersonConfigPath;
            if (File.Exists(XmlPath))
            {
                XmlDocument Doc = new XmlDocument();
                Doc.Load(XmlPath);
                XmlElement element1 = (XmlElement)Doc.SelectSingleNode("UserConfig/ClientOptions");
                element1.SetAttribute("Skin", e.Item.Tag.ToString());
                Doc.Save(XmlPath);
                ClientConfiguration.Skin = e.Item.Tag.ToString();
            }
            
        }

        private void barSBSkin_Popup(object sender, EventArgs e)
        {
            foreach (BarItemLink link in barSubItemSkin.ItemLinks)
                ((BarCheckItem)link.Item).Checked = link.Item.Tag == defaultLookAndFeel1.LookAndFeel.ActiveSkinName;

        }

        private void barButtonItemSelf_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new DefineCodeForm();
            CreateMDIForm(frmX);
        }
    }
}