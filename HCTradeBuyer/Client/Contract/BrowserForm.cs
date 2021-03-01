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
    /// ��ʾWeb��ҳ��Form
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
        * �ֱ���ò�ͬ��Url
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
                this.Text = "������Ϣά��";
            }
            if (target == "UserPassWord")
            {
                temp = Properties.Settings.Default.UserPassWord;
                this.Text = "�޸ĸ�������";
            }
            if (target == "DirSearch")
            {
                temp = Properties.Settings.Default.DirSearch;
                this.Text = "��Ŀ�ɽ�Ŀ¼��ѯ";
            }

            if (target == "OrderList")
            {
                temp = Properties.Settings.Default.OrderList;
                this.Text = "������ѯ";
            }

            if (target == "ContractList")
            {
                temp = Properties.Settings.Default.ContractList;
                this.Text = "��ͬ��ѯ";
            }

            if (target == "ContractSign")
            {
                temp = Properties.Settings.Default.ContractSign;
                this.Text = "��ͬǩ��";
            }

            if (target == "ContractUpdate")
            {
                temp = Properties.Settings.Default.ContractUpdate;
                this.Text = "��ͬ���";
            }
            if (target == "ReturnList")
            {
                temp = Properties.Settings.Default.ReturnList;
                this.Text = "�˻�����";
            }
            if (target == "NoticeList")
            {
                temp = Properties.Settings.Default.NoticeList;
                this.Text = "�鿴֪ͨ";
            }
            if (target == "SmsNo")
            {
                temp = Properties.Settings.Default.SmsNo;
                this.Text = "�������ź���ά��";
            }

            //if (target == "HospitalCatalog")
            //{
            //    temp = Properties.Settings.Default.HospitalCatalog;
            //    this.Text = "ҽԺ��ҳ";
            //}

            //if (target == "UserComplain")
            //{
            //    temp = Properties.Settings.Default.UserComplain;
            //    this.Text = "�û�Ͷ��";
            //}

            //if (target == "ViewNews")
            //{
            //    temp = Properties.Settings.Default.ViewNews;
            //    this.Text = "�鿴��ʾ";
            //}

            //if (target == "Sms")
            //{
            //    temp = Properties.Settings.Default.Sms;
            //    this.Text = "֪ͨ";
            //}

            //if (target == "SmsReader")
            //{
            //    temp = Properties.Settings.Default.SmsReader;
            //    this.Text = "��֪ͨ";
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
        /// �ĵ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            flg = true;
        }

        /// <summary>
        /// ���ڷ�ֹ�������ʵı�־λ
        /// </summary>
        private bool flg;

        /// <summary>
        /// ����url
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