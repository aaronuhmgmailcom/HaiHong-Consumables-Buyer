using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Emedchina.TradeAssistant.Client.UI.DataMaintenance;
using Emedchina.TradeAssistant.Client.UI.TradeManage;
using Emedchina.TradeAssistant.Client.UI.CommonInfo;
using Emedchina.TradeAssistant.Client.UI.CommonInfo.StockList;
using Emedchina.TradeAssistant.Client.UI.CommonInfo.DataFound;
using Emedchina.TradeAssistant.Client.UI.CommonInfo.DefineCodeSet;
using Emedchina.TradeAssistant.Client.UI.UserManage;
using Emedchina.TradeAssistant.Client.UI.SystemManage;
using Emedchina.TradeAssistant.Client.UI.TradeManage.DoWithOrder;
using Emedchina.TradeAssistant.Client.UI.TradeStatistic;
using Emedchina.TradeAssistant.Client.His.Enterprise;
using Emedchina.TradeAssistant.Client.His.Product;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Client.BLL;
using Emedchina.TradeAssistant.Model.User;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;
using Emedchina.TradeAssistant.Client.UI.CommonInfo.StockUp;
using Emedchina.TradeAssistant.Client.UI.CommonInfo.OrdBuyerReturn;
using Emedchina.TradeAssistant.Client.UI.Order.PurchaseHandle;
using Emedchina.TradeAssistant.Client.UI.CommonInfo.UseOddAudi;
using Emedchina.TradeAssistant.Client.BLL.User;
using Emedchina.TradeAssistant.Client.Common;
using System.Reflection;
using Emedchina.TradeAssistant.Client.UI.CommonInfo.OrdInvoice;
using System.IO;
using System.Xml;

namespace Emedchina.TradeAssistant.Client.UI.PublicModule
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //子窗体
        private Form frmX;
        private LogedInUser user;
        Form login;

        public MainForm()
        {
            InitializeComponent();
            user = ClientSession.GetInstance().CurrentUser;
            InitSkins();
        }

        public MainForm(Form frm)
        {
            InitializeComponent();
            user = ClientSession.GetInstance().CurrentUser;
            InitSkins();
            login = frm;
        }

        private void barButtonItem28_ItemClick(object sender, ItemClickEventArgs e)
        {
            EndForm form = new EndForm(login, this);
            form.ShowDialog();
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
            ribbon.ForceInitialize();
            foreach (DevExpress.Skins.SkinContainer skin in DevExpress.Skins.SkinManager.Default.Skins)
            {
                BarCheckItem item = ribbon.Items.CreateCheckItem(skin.SkinName, false);
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
                this.barSBSkin.ItemLinks.Add(item);
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
            foreach (BarItemLink link in barSBSkin.ItemLinks)
                ((BarCheckItem)link.Item).Checked = link.Item.Tag == defaultLookAndFeel1.LookAndFeel.ActiveSkinName;

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

        #region 打开窗体事件

        /// <summary>
        /// 创建采购单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemCreatPurchase_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new FormPurchaseBuild();
            CreateMDIForm(frmX);
        }
        
        /// <summary>
        /// 库房信息维护
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiWarehouseMgr_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new WarehouseMgr();
            CreateMDIForm(frmX);
        }

        /// <summary>
        /// 订单商品信息查询 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiQueryOrderItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new QueryOrderItem();
            CreateMDIForm(frmX);
        }

        /// <summary>
        /// 公告信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new AfficheInfoForm();
            CreateMDIForm(frmX);
        }

        /// <summary>
        /// 可采购目录维护
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new StockListForm();
            CreateMDIForm(frmX);
        }

        /// <summary>
        /// 医院配送商品查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new SendProductForm();
            CreateMDIForm(frmX);
        }

        /// <summary>
        /// 缺货查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new OosQueryForm();
            CreateMDIForm(frmX);
        }

        /// <summary>
        /// 自定义产品编码、大包装设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new DefineCodeForm();
            CreateMDIForm(frmX);
        }



        #endregion

        /// <summary>
        /// 用户信息维护 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiUserInfoMgr_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserInfoMgr frmUserInfoMgr = new UserInfoMgr();
            frmUserInfoMgr.ShowDialog();

        }

        /// <summary>
        /// 系统配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiSystemConfig_ItemClick(object sender, ItemClickEventArgs e)
        {
            SystemConfigMgr frmSysForm = new SystemConfigMgr();
            frmSysForm.ShowDialog();
        }

        /// <summary>
        /// 采购商品查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new PurchaseCommerceForm();
            CreateMDIForm(frmX);
        }

        /// <summary>
        /// 二级库存统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem20_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new SecondAyrlnvForm();
            CreateMDIForm(frmX);
        }

        /// <summary>
        /// 订单处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiDoWithOrder_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new BuyerOrderList();
            CreateMDIForm(frmX);
        }

        /// <summary>
        /// 企业编码对照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiEnterPriceCompare_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new EnterpriseIDComprison();
            CreateMDIForm(frmX);
        }
        
        /// <summary>
        /// 产品编码对照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiProductCompare_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new ProductCodeCompareForm();
            CreateMDIForm(frmX);
        }

        private void bbiFileSetting_ItemClick(object sender, ItemClickEventArgs e)
        {
            Emedchina.TradeAsst.EmedHisHelper.FormMain frm = new Emedchina.TradeAsst.EmedHisHelper.FormMain();
            frm.ShowDialog();
        }

        private void barBtnCreatPurchase_ItemClick(object sender, ItemClickEventArgs e)
        {
            

            barStaticItemUser.Caption = "当前用户：" + user.UserInfo.Name;

            RibbonPage newPage = new RibbonPage(DateTime.Now.ToString());

            RibbonPageGroup group = new RibbonPageGroup();
            BarButtonItem item = new BarButtonItem(ribbon.Manager, DateTime.Now.ToString());
            
            item.ImageIndex = 3;
            group.ItemLinks.Add(item);
            newPage.Groups.Add(group);
            ribbon.Pages.Add(newPage);

            //BarButtonItem item1 = new BarButtonItem();

            //item1.ImageIndex = 3;
            //group.ItemLinks.Add(item1);
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            barStaticItemUser.Caption = "当前用户：" + user.UserInfo.Name;
            SyncForm frmSync = new SyncForm();
            frmSync.ShowDialog();
            barButtonItem2_ItemClick(null, null);
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {

            Form frm = new SyncForm();
            frm.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            EndForm form = new EndForm(login, this);
            form.ShowDialog();
        }


        /// <summary>
        /// 发货单确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnAffirmSend_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new OrdInvoiceListForm();
            CreateMDIForm(frmX);
        }

        /// <summary>
        /// 备货单确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnAffirmStockUp_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new OrdStockUpForm();
            CreateMDIForm(frmX);
        }

        /// <summary>
        /// 经销企业统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiSalerStatistic_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new SalerStatistic();
            CreateMDIForm(frmX);
        }
        
        /// <summary>
        /// 退货管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiReturnMan_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new OrdBuyerReturnForm();
            CreateMDIForm(frmX);
        }

        /// <summary>
        /// 使用单审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiAudiUse_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new UseOddAudiForm();
            CreateMDIForm(frmX);
        }

        private void bbiPersonConfig_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserConfig frm = new UserConfig();
            frm.ShowDialog();

        }


        /// <summary>
        /// 生产菜单
        /// </summary>
        public void BuildMenu()
        {
            DataRow[] rowArray1 = null;
            DataRow[] rowArray2 = null;
            string groupNo;
            string groupName;
            string menuID;
            MenuStrip mainMenu = new MenuStrip();
            try
            {
                LogedInUser curUser = ClientSession.GetInstance().CurrentUser;

                string clientType = UserConfigXml.GetConfigInfo("ClientType", "type");

                DataTable dt = new DataTable();
                //根据配置文件，离线或在线生成用户菜单
                if (ClientConfiguration.IsOfflineLogin)
                {
                    //离线生成菜单
                    //dt = LoginUserOfflineBLL.GetInstance("ClientDB").GetMenuOffline(curUser.UserInfo.Id, clientType);
                }
                else
                {
                    //在线生成菜单
                    //dt = ProxyFactory.UserProxy.GetMenu(curUser.UserInfo.Id, clientType);
                }

                dt = LoginUserOfflineBLL.GetInstance("ClientDB").GetMenuOffline(curUser.UserInfo.Id, clientType);
                if (dt.Rows.Count != 0)
                {
                    rowArray1 = dt.Select("father='0'");
                    for (int i = 0; i < rowArray1.Length; i++)
                    {
                        //创建一个父菜单项
                        RibbonPage newPage = new RibbonPage();
                        //给菜单赋Text值。也就是在界面上看到的值。
                        newPage.Text = rowArray1[i]["name"].ToString().Trim();
                        menuID = rowArray1[i]["id"].ToString().Trim();
                        rowArray2 = dt.Select("father = '" + menuID + "'");
                        if (rowArray2.Length > 0)
                        {
                            CreateSubMenu(newPage, menuID, dt);
                        }

                        ribbon.Pages.Add(newPage);
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 创建子菜单

        /// </summary>
        /// <param name="topMenu"></param>
        /// <param name="ItemID"></param>
        /// <param name="dt"></param>
        private void CreateSubMenu(RibbonPage topMenu, string itemID, DataTable dt)
        {
            DataRow[] rows;
            string groupNo = "";
            string lastGroupNo = "";
            string groupName;
            string key;
            RibbonPageGroup groupMenu = null;
            try
            {
                //过滤出当前父菜单下在所有子菜单数据(仅为下一层的)
                rows = dt.Select("father = '" + itemID + "'", "Group_NO asc");

                for (int i = 0; i < rows.Length; i++)
                {

                    //创建子菜单项
                    BarButtonItem subMenu = new BarButtonItem();
                    subMenu.Manager = ribbon.Manager;
                    subMenu.Caption = rows[i]["name"].ToString().Trim();

                    subMenu.Tag = rows[i]["MODULE_ACTION"] == null ? "" : rows[i]["MODULE_ACTION"].ToString().Trim();
                    key = rows[i]["SHORTCUT"].ToString().Trim().ToUpper();
                    if (!string.IsNullOrEmpty(key))
                    {

                        switch (key)
                        {
                            case "A":
                                subMenu.ShortCut = Shortcut.CtrlA;
                                break;

                            case "P":
                                subMenu.ShortCut = Shortcut.CtrlP;
                                break;

                            case "D":
                                subMenu.ShortCut = Shortcut.CtrlD;
                                break;

                            case "H":
                                subMenu.ShortCut = Shortcut.CtrlH;
                                break;

                        }

                    }
                    if (!string.IsNullOrEmpty(subMenu.Tag.ToString()))
                        subMenu.ItemClick += new ItemClickEventHandler(menuClick);
                    if (!string.IsNullOrEmpty(rows[i]["image"].ToString().Trim()))
                    {
                        subMenu.ImageIndex = int.Parse(rows[i]["image"].ToString());
                    }
                    groupNo = rows[i]["Group_No"] == null ? "" : rows[i]["Group_No"].ToString().Trim();
                    groupName = rows[i]["Group_Name"] == null ? "" : rows[i]["Group_Name"].ToString().Trim();
                    //if (!string.IsNullOrEmpty(groupNo))
                    //{
                    if (!lastGroupNo.Equals(groupNo))
                    {
                        lastGroupNo = groupNo;
                        groupMenu = new RibbonPageGroup();
                        groupMenu.Text = groupName;
                        groupMenu.ShowCaptionButton = false;
                        topMenu.Groups.Add(groupMenu);

                    }
                    //}
                    groupMenu.ItemLinks.Add(subMenu);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 点击菜单项执行的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void menuClick(object sender, ItemClickEventArgs e)
        {
            string methodName = e.Item.Tag.ToString().Trim();

            MethodInfo method = base.GetType().GetMethod(methodName);
            if (method != null)
            {
                Object[] param = new Object[2];
                param[0] = sender;
                param[1] = e;
                method.Invoke(this, param);
            }
        }

        /// <summary>
        /// 自定义产品编码、大包装设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiSefDefine_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new DefineCodeForm();
            CreateMDIForm(frmX);
        }

        private void barBtnCheckPurchase_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frmX != null)
            {
                frmX.Close();
                frmX.Dispose();
            }
            frmX = new FormPurchaseCkeck();
            CreateMDIForm(frmX);
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            string updateUrl = Properties.Settings.Default.UpdateUrl;
            System.Diagnostics.Process.Start(updateUrl);
        }

        public void webLoad(string item)
        {
            BrowserForm form = new BrowserForm();
            form.Target = item;
            //form.ShowDialog();
            //LoadFormToPanel(form);
        }
    }
}