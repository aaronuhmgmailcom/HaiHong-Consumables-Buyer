#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Archive: /TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/LoginForm.cs $ 
 * $Author: Sunhl $ <a href="mailto:sunhongliang@hotmail.com">孙洪亮(sunhl)</a>
 * $Revision: 14 $
 * $History: LoginForm.cs $
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
using Emedchina.TradeAssistant.Client.Self;
using Emedchina.Commons.Debug;
using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Client.BLL.User;
using System.IO;
using Emedchina.TradeAssistant.Client.UI.PublicModule;
using Emedchina.TradeAssistant.Client.BLL;
using DevExpress.XtraEditors;
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
    public partial class LoginForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:LoginForm"/> class.
        /// </summary>
        public LoginForm()
        {
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
                //if (ClientConfiguration.IsOffline && (File.Exists(ClientConfiguration.LocalDBFile) && LoginUserOfflineBLL.GetInstance("ClientDB").GetUserCount(userNameTextBox.Text.Trim()) > 0))
                //{
                //    //离线登录，并取得当前登录用户信息                    
                //    user = LoginUserOfflineBLL.GetInstance("ClientDB").Login(userNameTextBox.Text.Trim(), passwordTextBox.Text);

                //}
                //else
                //{
                //    //在线
                //    user = ProxyFactory.UserProxy.DoLogin(userNameTextBox.Text.Trim(), passwordTextBox.Text);
                    
                //}
                user = new LogedInUser();
                user.UserInfo = new UserInfo();
                user.UserInfo.Name = "test";
                user.UserInfo.Org_id = "123456";
                user.UserInfo.Id = "123321";
                user.HighId = CommUtilBLL.GetInstance().GetHighID();
                ClientSession.GetInstance().CurrentUser = user;

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

            this.passwordTextBox.Text = "";
            this.Hide();
            new MainForm().Show();
            
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
        /// Handles the Load event of the LoginForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void LoginForm_Load(object sender, EventArgs e)
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
                        cmbUser.Items.Add(userCodeArray[i]);
                    }
                    cmbUser.Text = ClientConfiguration.LastUserCode;
                    //cmbUser.SelectedText = ClientConfiguration.LastUserCode;
                    this.userNameTextBox.Text = cmbUser.SelectedItem.ToString();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnConfig control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnConfig_Click(object sender, EventArgs e)
        {
            SystemConfig frm = new SystemConfig();
            frm.ShowDialog();
        }

        //new added,处理窗体关闭时序列化缓存到文件
        /// <summary>
        /// Handles the FormClosing event of the LoginForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.FormClosingEventArgs"/> instance containing the event data.</param>
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
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

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ClientConfiguration.RemoteMachine = this.txtIp.Text.ToString();
        //        ClientConfiguration.RemotePort = this.txtPort.Text.ToString();
        //        Properties.Settings.Default.WebSite = this.txtWeb.Text.ToString();
        //        if (this.chbResume.Checked)
        //        {
        //            ClientConfiguration.ResumeFlg = "1";
        //        }
        //        else
        //        {
        //            ClientConfiguration.ResumeFlg = "0";
        //        }
        //        ClientConfiguration.Save();
        //        MessageBox.Show("保存成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("操作失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //}

        //private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //     reLoad();

        //}
        //private void reLoad()
        //{
        //    this.txtIp.Text = ClientConfiguration.RemoteMachine;
        //    this.txtPort.Text = ClientConfiguration.RemotePort;
        //    this.txtWeb.Text = Properties.Settings.Default.WebSite;
        //    if (!string.IsNullOrEmpty(ClientConfiguration.ResumeFlg) && ClientConfiguration.ResumeFlg.Equals("1"))
        //    {
        //        this.chbResume.Checked = true;
        //    }
        //    else
        //    {
        //        this.chbResume.Checked = false;
        //    }

        //}
    }
}