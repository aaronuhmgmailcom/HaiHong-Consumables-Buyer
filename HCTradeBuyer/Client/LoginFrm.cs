#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Archive: /TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/LoginFrm.cs $ 
 * $Author: Sunhl $ <a href="mailto:sunhongliang@hotmail.com">孙洪亮(sunhl)</a>
 * $Revision: 14 $
 * $History: LoginFrm.cs $
 * 
 * *****************  Version 14  *****************
 * User: Sunhl        Date: 06-09-04   Time: 10:07
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 * 修改增量缓存
 * 
 * *****************  Version 13  *****************
 * User: Liangxy      Date: 06-08-25   Time: 15:25
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 * 
 * *****************  Version 12  *****************
 * User: Sunhl        Date: 06-08-25   Time: 13:10
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 * 
 * *****************  Version 11  *****************
 * User: Sunhl        Date: 06-08-25   Time: 11:22
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 * 
 * *****************  Version 10  *****************
 * User: Sunhl        Date: 06-08-25   Time: 11:16
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 * 添加了异常写入windows日志
 * 
 * *****************  Version 9  *****************
 * User: Liangxy      Date: 06-07-12   Time: 17:22
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 * 
 * *****************  Version 8  *****************
 * User: Liangxy      Date: 06-07-12   Time: 11:30
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 * 
 * *****************  Version 7  *****************
 * User: Liangxy      Date: 06-07-06   Time: 14:34
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 * 
 * *****************  Version 6  *****************
 * User: Liangxy      Date: 06-06-29   Time: 13:33
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 * 
 * *****************  Version 5  *****************
 * User: Panyj        Date: 06-06-29   Time: 11:06
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 * 
 * *****************  Version 4  *****************
 * User: Sunhl        Date: 06-06-26   Time: 11:55
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 * 
 * *****************  Version 3  *****************
 * User: Sunhl        Date: 06-06-24   Time: 14:47
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 * 
 * *****************  Version 2  *****************
 * User: Sunhl        Date: 06-06-24   Time: 10:39
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 ********************************************************************************/
#endregion

#region using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Remoting.User;
using Emedchina.TradeAssistant.Model.Exceptions;
using Emedchina.Commons.Debug;
using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Client.BLL.User;
using System.IO;
using Emedchina.TradeAssistant.Client.UI.PublicModule;
using Emedchina.TradeAssistant.Client.BLL;
using DevExpress.XtraEditors;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Client.UI.SystemManage;
using Emedchina.TradeAssistant.Client.Common;
using Emedchina.Commons;
using Microsoft.Win32;
#endregion

namespace Emedchina.TradeAssistant.Client
{
    /// <summary>
    /// 用户登录主窗口。
    /// 密码最大长度为20个字符。
    /// 通过ErrorProvider提供错误信息。
    /// 通过异常来判断用户登录状态。
    /// 登录成功后将会在内存中放入User对象。
    /// </summary>
    public partial class LoginFrm : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:LoginFrm"/> class.
        /// </summary>
        public LoginFrm()
        {
            //object o = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Feitian\USBToken3000ND", "Version", null);
            //if (o == null)
            //{

            //    //Process.Start("epsft11_stdSimpChinese.exe");
            //    System.Diagnostics.Process p = new System.Diagnostics.Process();
            //    p.StartInfo.FileName = "eps3knd_stdSimpChinese.exe";//需要启动的程序名   
            //    p.Start();//启动   
            //    p.WaitForExit();

            //}
            InitializeComponent();

        }

        /// <summary>
        /// Handles the Click event of the cancleBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void cancleBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the okBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void okBtn_Click(object sender, EventArgs e)
        {
            login();
        }
        /// <summary>
        ///  发送用户名和密码，处理可能出现的异常，登录成功后将User对象放入客户端，然后启动主窗体。
        /// </summary>
        private void login()
        {
            if (!CheckName())
            {
                this.userNameTextBox.Focus();
                this.userNameTextBox.SelectAll();
                return;
            }

            if (!CheckPassword())
            {
                this.passwordTextBox.Focus();
                this.passwordTextBox.SelectAll();
                return;
            }

            try
            {
                LogedInUser user = null;
                if (ClientConfiguration.IsOffline && (File.Exists(ClientConfiguration.LocalDBFile) && LoginUserOfflineBLL.GetInstance("ClientDB").GetUserCount(userNameTextBox.Text.Trim()) > 0))
                {
                    //离线登录，并取得当前登录用户信息                    
                    user = LoginUserOfflineBLL.GetInstance("ClientDB").Login(userNameTextBox.Text.Trim(), SecretUtil.MD5Encoding(passwordTextBox.Text));

                }
                else
                {
                    //在线
                    user = ProxyFactory.UserProxy.DoLogin(userNameTextBox.Text.Trim(), SecretUtil.MD5Encoding(passwordTextBox.Text));

                }

                user.HighId = CommUtilBLL.GetInstance("ClientTempDB").GetHighID();
                ClientSession.GetInstance().CurrentUser = user;
                ClientSession.GetInstance().IsLogin = true;

            }
            catch (LoginException loginEx)
            {
                XtraMessageBox.Show(string.Format("用户登录失败:\n  {0}.", loginEx.Message), "登录失败", MessageBoxButtons.OKCancel);
                //XtraMessageBox.Show(loginEx.StackTrace);
                EventLog.WriteEntry("login", loginEx.StackTrace);
                return;
            }
            catch (Exception ex)
            {
                //这个处理不友好,发布前需要修改
                XtraMessageBox.Show(string.Format("用户登录失败:\n  {0}.", ex.Message), "登录失败", MessageBoxButtons.OKCancel);
                //XtraMessageBox.Show(ex.StackTrace);
                EventLog.WriteEntry("login", ex.StackTrace);
                return;
            }
            this.Hide();
            //usercode写入到app.config文件
            string userCode = userNameTextBox.Text;
            string userCodeList = ClientConfiguration.UserCode;
            if (!userCodeList.Contains(userCode))
            {
                if (!string.IsNullOrEmpty(userCodeList))
                {
                    ClientConfiguration.UserCode = userCode + "," + userCodeList;
                }
                else
                {
                    ClientConfiguration.UserCode = userCode;
                }

            }
            ClientConfiguration.LastUserCode = userCode;
            ClientConfiguration.Save();

            UserConfigXml.SetConfigInfo("LoginLog", "LoginedUsersCode", ClientConfiguration.UserCode);
            UserConfigXml.SetConfigInfo("LoginLog", "LastLoginedUserCode", ClientConfiguration.LastUserCode);
            

            this.passwordTextBox.Text = "";
            if (!ClientConfiguration.MenuStyle.Equals("0"))
                new MainForm(this).Show();
            else
                new ParentForm(this).Show();
            //this.Close();
        }

        /// <summary>
        /// Handles the Validating event of the userNameTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void userNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            CheckName();
        }

        /// <summary>
        /// Handles the Validating event of the passwordTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void passwordTextBox_Validating(object sender, CancelEventArgs e)
        {
            CheckPassword();
        }


        /// <summary>
        /// Checks the name.
        /// </summary>
        /// <returns></returns>
        private bool CheckName()
        {
            if (string.IsNullOrEmpty(this.userNameTextBox.Text))
            {
                this.userNameErrorProvider.SetError(this.userNameTextBox, "用户名不能为空!");
                return false;
            }

            if (IsNameValid())
            {
                this.userNameErrorProvider.SetError(this.userNameTextBox, string.Empty);
                return true;
            }
            else
            {
                this.userNameErrorProvider.SetError(this.userNameTextBox, "用户无效!");
                return false;
            }
        }

        /// <summary>
        /// Checks the password.
        /// </summary>
        /// <returns></returns>
        private bool CheckPassword()
        {
            if (string.IsNullOrEmpty(this.passwordTextBox.Text))
            {
                this.passwordErrorProvider.SetError(this.passwordTextBox, "密码不能为空!");
                return false;
            }

            if (IsPasswordValid())
            {
                this.passwordErrorProvider.SetError(this.passwordTextBox, string.Empty);
                return true;
            }
            else
            {
                this.passwordErrorProvider.SetError(this.passwordTextBox, "密码无效!");
                return false;
            }
        }


        /// <summary>
        /// Determines whether [is name valid].
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if [is name valid]; otherwise, <c>false</c>.
        /// </returns>
        protected virtual bool IsNameValid()
        {
            //return userNameTextBox.Text.Length > 6;
            return true;
        }

        /// <summary>
        /// Determines whether [is password valid].
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if [is password valid]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsPasswordValid()
        {
            //return passwordTextBox.Text.Length > 6;
            return true;
        }

        /// <summary>
        /// Handles the Leave event of the userNameTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void userNameTextBox_Leave(object sender, EventArgs e)
        {
            CheckName();
        }

        /// <summary>
        /// Handles the Leave event of the passwordTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void passwordTextBox_Leave(object sender, EventArgs e)
        {
            CheckPassword();
        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

        /// <summary>
        /// Handles the Load event of the LoginFrm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void LoginFrm_Load(object sender, EventArgs e)
        {
            string version;
            version = "V" + Application.ProductVersion;
            lblVerson.Text = version;
            string userCodeList = ClientConfiguration.UserCode;
            if (!string.IsNullOrEmpty(userCodeList))
            {
                string[] userCodeArray = userCodeList.Split(new char[] { ',' });
                if (userCodeArray.Length == 1)
                {
                    this.userNameTextBox.Text = userCodeArray[0];
                }
                else
                {
                    userNameTextBox.Visible = false;
                    cmbUser.Visible = true;
                    for (int i = 0; i < userCodeArray.Length; i++)
                    {
                        cmbUser.Properties.Items.Add(userCodeArray[i]);
                    }
                    cmbUser.Text = ClientConfiguration.LastUserCode;
                    //cmbUser.SelectedText = ClientConfiguration.LastUserCode;
                    this.userNameTextBox.Text = cmbUser.SelectedItem.ToString();
                }
            }
            //if (string.IsNullOrEmpty(ClientConfiguration.Skin))
            //    this.LookAndFeel.SetSkinStyle("Money Twins");
            //else
            //    this.LookAndFeel.SetSkinStyle(ClientConfiguration.Skin);

            if (!string.IsNullOrEmpty(ClientConfiguration.Skin))
                defaultLookAndFeel1.LookAndFeel.SetSkinStyle(ClientConfiguration.Skin);
            else
                defaultLookAndFeel1.LookAndFeel.SetSkinStyle("Money Twins");
            //this.ShowInTaskbar = true;
        }

        /// <summary>
        /// Handles the Click event of the btnConfig control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnConfig_Click(object sender, EventArgs e)
        {
            SystemConfigMgr frm = new SystemConfigMgr();
            frm.ShowDialog();
        }

        //new added,处理窗体关闭时序列化缓存到文件
        /// <summary>
        /// Handles the FormClosing event of the LoginFrm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.FormClosingEventArgs"/> instance containing the event data.</param>
        private void LoginFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string file = ClientCache.SerializeFile;
                DataFormatter.SerializeToFile(ClientCache.CachedDS, ClientCache.SerializeFile);
            }
            catch
            {
                EventLog.WriteEntry("login", "反序列化失败,有可能是用户取消了登录,或者反序列化文件过程中出现了问题.");
            }
                
        }

        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            userNameTextBox.Text = cmbUser.SelectedItem.ToString();
        }

        private void cmbUser_SelectedValueChanged(object sender, EventArgs e)
        {
            userNameTextBox.Text = cmbUser.Text;
        }

        private void cmbUser_Leave(object sender, EventArgs e)
        {
            userNameTextBox.Text = cmbUser.Text;
        }

        private void simpleButtonLogin_Click(object sender, EventArgs e)
        {
            loginByKey();
        }

        private void loginByKey()
        {
            //先清楚原来的error提示
            errorProviderUser.Clear();
            errorProviderPin.Clear();

            //验证输入
            if (!CheckUser())
            {
                this.textEditUser.Focus();
                return;
            }

            if (!CheckPin())
            {
                this.textEditPin.Focus();
                this.textEditPin.SelectAll();
                return;
            }


            //验证登录（暂时写死）

            bool loginSuccess = false;

            string usbKeySn = Usb.GetSerialNumber();

            //增加固定的可以访问本系统的用户,增加一个指定用户，需增加类似下面的一行代码
            if (usbKeySn == "0403394716150307" && Usb.isCorrectUserPin(this.textEditPin.Text)) loginSuccess = true;
            if (usbKeySn == "0403394716150589" && Usb.isCorrectUserPin(this.textEditPin.Text)) loginSuccess = true;
            if (usbKeySn == "0495124716150307" && Usb.isCorrectUserPin(this.textEditPin.Text)) loginSuccess = true;
            if (usbKeySn == "0449134616150307" && Usb.isCorrectUserPin(this.textEditPin.Text)) loginSuccess = true;

            //增加2个正式用户
            if (usbKeySn == "0715260509110607" && Usb.isCorrectUserPin(this.textEditPin.Text)) loginSuccess = true;
            if (usbKeySn == "0725421309110607" && Usb.isCorrectUserPin(this.textEditPin.Text)) loginSuccess = true;


            //登录成功则加载主页面
            if (loginSuccess)
            {
                this.Hide();
                this.timerLogin.Stop();
                this.textEditPin.Text = "";
                if (!ClientConfiguration.MenuStyle.Equals("0"))
                    new MainForm(this).Show();
                else
                    new ParentForm(this).Show();
            }
            else
            {
                this.errorProviderPin.SetError(this.textEditPin, "登录失败，请检查您的key是否有访问本系统的权限、pin 码是否正确！");

            }
        }

        /// <summary>
        /// 检查是否已插入了电子钥匙
        /// </summary>
        /// <returns></returns>

        private bool CheckUser()
        {
            if (string.IsNullOrEmpty(this.textEditUser.Text))
            {
                errorProviderUser.SetError(textEditUser, "请检查是否已安装驱动并插入电子钥匙！");
                return false;
            }
            return true;

        }

        /// <summary>
        /// 检查pin码的输入
        /// </summary>
        /// <returns></returns>

        private bool CheckPin()
        {
            if (string.IsNullOrEmpty(this.textEditPin.Text))
            {
                this.errorProviderPin.SetError(this.textEditPin, "验证码不能为空且必须为4位!");
                return false;
            }
            return true;

        }

        private void timerLogin_Tick(object sender, EventArgs e)
        {
            InitTxtBoxUser();

            if (!this.textEditUser.Text.Equals("")) timerLogin.Stop();
        }

        /// <summary>
        /// 自动读入用户姓名
        /// </summary>
        private void InitTxtBoxUser()
        {
            this.textEditUser.Text = GetUser();

            if (this.textEditUser.Text.Equals(""))
            {
                errorProviderUser.SetError(textEditUser, "请检查是否已安装驱动并插入电子钥匙！");
            }
            else
            {
                errorProviderUser.Clear();
            }

            textEditUser.Enabled = false;

        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                InitTxtBoxUser();
                timerLogin.Interval = 2000;
                timerLogin.Start();
            }
        }


        /// <summary>
        /// 读取序列号，并判定对应的用户名
        /// 说明：目前特殊情况先写死
        /// </summary>
        private string GetUser()
        {
            string userName = "";
            string usbKeySn = Usb.GetSerialNumber();

            //说明：特殊情况，暂时写死了

            switch (usbKeySn)
            {
                case "0403394716150307":
                    userName = "张三";
                    break;
                case "0403394716150589":
                    userName = "李四";
                    break;

                case "0449134616150307":
                    userName = "测试";
                    break;
                case "0495124716150307":
                    userName = "张文涛";
                    break;

                case "0715260509110607":
                    userName = "正式1";
                    break;

                case "0725421309110607":
                    userName = "正式2";
                    break;

                default:
                    this.textEditUser.Text = "";
                    break;
            }

            return userName;

        }

        private void textEditPin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginByKey();
            }
        }

    }
}