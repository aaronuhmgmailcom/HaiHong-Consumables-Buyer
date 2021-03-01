/*****************************************************
 * $Header: /TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Contract/BrowserForm.cs 13    06-07-24 16:56 Panyj $
 * $Author: Panyj $
 * $Revision: 13 $
 * $Date: 06-07-24 16:56 $
 * $History: BrowserForm.cs $
 * 
 * *****************  Version 13  *****************
 * User: Panyj        Date: 06-07-24   Time: 16:56
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Contract
 * 
 * *****************  Version 12  *****************
 * User: Panyj        Date: 06-07-24   Time: 9:48
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Contract
 * 
 * *****************  Version 11  *****************
 * User: Panyj        Date: 06-07-12   Time: 10:35
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Contract
 * 
 * *****************  Version 10  *****************
 * User: Panyj        Date: 06-07-12   Time: 10:18
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Contract
 * 
 * *****************  Version 9  *****************
 * User: Panyj        Date: 06-07-11   Time: 16:26
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Contract
 * 
 * *****************  Version 8  *****************
 * User: Panyj        Date: 06-07-11   Time: 15:31
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Contract
 * 
 * *****************  Version 7  *****************
 * User: Panyj        Date: 06-07-11   Time: 9:29
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Contract
 * 
 * *****************  Version 6  *****************
 * User: Panyj        Date: 06-07-10   Time: 15:02
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Contract
 * 
 * *****************  Version 5  *****************
 * User: Panyj        Date: 06-07-10   Time: 14:12
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Contract
 * 
 * *****************  Version 4  *****************
 * User: Panyj        Date: 06-07-06   Time: 17:01
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Contract
 ****************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emedchina.TradeAssistant.Client.Common;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Client.Base;
using System.Web;

namespace Emedchina.TradeAssistant.Client.Contract
{
    /// <summary>
    /// 显示Web网页的Form
    /// </summary>
    public partial class BrowserForm : BaseForm
    {
        public BrowserForm()
        {
            InitializeComponent();
        }

        private void BrowserForm_Load(object sender, EventArgs e)
        {
            getUrl();
        }

        private string target;

        public string Target
        {
            get { return target; }
            set { target = value; }
        }

        /**
        * 分别调用不同的Url
        */
        private void getUrl()
        {
            string myUrl = "";

            ClientSession client = ClientSession.GetInstance();
            LogedInUser myUser = client.CurrentUser;
            string userName = myUser.UserInfo.Code;
            string passWord = myUser.UserInfo.Password;

            string temp = "";
            myUrl = Properties.Settings.Default.WebSite;
            if (target == "userInfo")
            {
                temp = Properties.Settings.Default.userInfo;
                this.Text = "个人信息维护";
            }
            if (target == "UserPassWord")
            {
                temp = Properties.Settings.Default.UserPassWord;
                this.Text = "修改个人密码";
            }
            if (target == "DirSearch")
            {
                temp = Properties.Settings.Default.DirSearch;
                this.Text = "项目成交目录查询";
            }

            if (target == "OrderList")
            {
                temp = Properties.Settings.Default.OrderList;
                this.Text = "订单查询";
            }

            if (target == "ContractList")
            {
                temp = Properties.Settings.Default.ContractList;
                this.Text = "合同查询";
            }

            if (target == "ContractSign")
            {
                temp = Properties.Settings.Default.ContractSign;
                this.Text = "合同签订";
            }

            if (target == "ContractUpdate")
            {
                temp = Properties.Settings.Default.ContractUpdate;
                this.Text = "合同变更";
            }
            if (target == "ReturnList")
            {
                temp = Properties.Settings.Default.ReturnList;
                this.Text = "退货管理";
            }
            if (target == "NoticeList")
            {
                temp = Properties.Settings.Default.NoticeList;
                this.Text = "查看通知";
            }
            if (target == "SmsNo")
            {
                temp = Properties.Settings.Default.SmsNo;
                this.Text = "订单短信号码维护";
            }

            //if (target == "HospitalCatalog")
            //{
            //    temp = Properties.Settings.Default.HospitalCatalog;
            //    this.Text = "医院黄页";
            //}

            //if (target == "UserComplain")
            //{
            //    temp = Properties.Settings.Default.UserComplain;
            //    this.Text = "用户投诉";
            //}

            //if (target == "ViewNews")
            //{
            //    temp = Properties.Settings.Default.ViewNews;
            //    this.Text = "查看公示";
            //}

            //if (target == "Sms")
            //{
            //    temp = Properties.Settings.Default.Sms;
            //    this.Text = "通知";
            //}

            //if (target == "SmsReader")
            //{
            //    temp = Properties.Settings.Default.SmsReader;
            //    this.Text = "收通知";
            //} 

            //string webSite = ClientConfiguration.WebUrl;
            ////string webSite = Properties.Settings.Default.WebSite;

            //myUrl = webSite + "jundun?userName=" + userName + "&password=" + passWord + "&url=" + HttpUtility.UrlEncode(temp);

            //this.webBrowser1.Navigate(myUrl);


            string fix = "&TAClient=1&code=" + userName + "&passWord=" + passWord;


            string webSite = Properties.Settings.Default.WebSite;

            //"/gpo/portal?isMenuFlag=1&handlerId=khd.bid.view&operate=BidViewCorp&currModuleID=USER00000000000000122514";
            myUrl = webSite + temp + fix;

            if (!string.IsNullOrEmpty(temp))
            this.webBrowser1.Url = new System.Uri(myUrl, System.UriKind.Absolute);
        }


        /// <summary>
        /// 文档结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            flg = true;
        }

        /// <summary>
        /// 用于防止反复访问的标志位
        /// </summary>
        private bool flg;

        /// <summary>
        /// 拦截url
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (this.webBrowser1.Url != null)
            {
                if (flg)
                {
                    flg = false;

                    string myUrl = this.webBrowser1.Url.ToString();
                    Console.WriteLine(myUrl);
                    if ((myUrl.Contains("?")) && (!myUrl.Contains("TAClient=1")))
                    {
                        myUrl += "&TAClient=1";
                        this.webBrowser1.Navigate(myUrl);
                    }

                }
            }
        }
    }
}