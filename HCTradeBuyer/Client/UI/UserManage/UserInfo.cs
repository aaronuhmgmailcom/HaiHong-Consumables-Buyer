using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Configuration;
using System.Collections;
using System.Xml;
using System.Net;
using System.IO;
using System.Text;
using System.Threading;
using Emedchina.TradeAssistant.Client.DAL.UserInfomation;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Client.Base;
using System.Security.Cryptography;

namespace Emedchina.TradeAssistant.Client.UI.UserManage
{
    public partial class UserInfoMgr : BaseForm
    {
        public UserInfoMgr()
        {
            InitializeComponent();
        }

        private void UserInfoMgr_Load(object sender, EventArgs e)
        {
            this.teUserName.Text=base.CurrentUserName;
            this.teEmail.Text=base.CurrentUser.UserInfo.Code;
        }

        private void sbSave_Click(object sender, EventArgs e)
        {
            string sOldpass = "";
            string sOldpassInput = this.teOrignPsd.Text;
            string sNewpass1 = this.teNewPsd.Text;
            string sNewpass2 = this.teAffirmPsd.Text;


            if (string.IsNullOrEmpty(sOldpassInput))
            {
                XtraMessageBox.Show("旧密码不能为空值！请输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(sNewpass1))
            {
                XtraMessageBox.Show("新密码不能为空值！请输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //将输入的信息保存到隐藏控件,保存失败时重新写回到页面显示控件中

            //取出本地物化视图中的用户密码
            DataTable dt = PassMgrDAO.GetInstance().GetLocalsysUserInfo(base.CurrentUserId );

            if (dt.Rows.Count > 0)
            {
                //数据库中未加密，这里直接取出后进行比较，如果加密以后，请在此先解密
                sOldpass = dt.Rows[0]["PASSWORD"].ToString();

                //判断输入的密码是否和登陆用户的当前密码相同
                if (sOldpass == SecretUtil.MD5Encoding(sOldpassInput))
                {
                    //判断两次输入的新密码是否相同
                    if (sNewpass1 == sNewpass2)
                    {
                        try
                        {
                            //保存新密码
                            sNewpass1 = SecretUtil.MD5Encoding(sNewpass1);
                            this.SavePassword(sNewpass1);
                            
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    else
                    {
                        //提示用户两次输入的新密码不一致
                        XtraMessageBox.Show("两次输入的新密码不一致！请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    //提示用户旧密码输入错误
                    XtraMessageBox.Show("用户旧密码输入错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                //本系统未找到当前用户信息
                XtraMessageBox.Show("本系统未找到当前用户信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


      

        #region 保存密码
        /// <summary>
        /// 保存密码
        /// </summary>
        private void SavePassword(string spass)
        {
            try
            {
                ////更新本系统物化视图用户密码
                //result = new passwordmgrDAO().UpdateLocalsysUserInfo(
                //    PageConfiguration.GetUser(this).ID.ToString(),
                //    spass,
                //    PageConfiguration.GetUser(this).ID.ToString(),
                //    PageConfiguration.GetUser(this).UserName.ToString()
                //);

                //生成XML报文
                string sXml = GenXML(
                    base.CurrentUserId,
                    this.teUserName.Text,
                    //"耗材营运管理员",
                    this.teEmail.Text,
                    spass
                    );

                //更新用户系统用户密码

                //传送报文
                string postData = sXml.ToString();

                Uri passUri = new Uri("http://172.25.13.113/user/clientAddOrEdit.do?method=editAndAdd");

                HttpWebRequest HttpWReq = (HttpWebRequest)WebRequest.Create(passUri);
                HttpWReq.Method = "POST";

                UTF8Encoding encoding = new UTF8Encoding();
                byte[] byteArray = encoding.GetBytes(postData);

                HttpWReq.ContentType = "application/x-www-form-urlencoded";
                HttpWReq.ContentLength = byteArray.Length;

                ////采用异步方式请求
                //HttpWReq.BeginGetRequestStream(new AsyncCallback(ReadCallback), HttpWReq);
                //allDone.WaitOne();

                Stream postStream = HttpWReq.GetRequestStream();
                // Write to the request stream.
                postStream.Write(byteArray, 0, byteArray.Length);
                postStream.Close();

                HttpWebResponse HttpWResp = (HttpWebResponse)HttpWReq.GetResponse();

                Stream receiveStream = HttpWResp.GetResponseStream();

                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

                string sResponse = readStream.ReadToEnd();


                // Releases the resources of the response.
                HttpWResp.Close();
                // Releases the resources of the StreamReader.
                readStream.Close();
                // Releases the resources of the Stream.
                receiveStream.Close();

                //读取返回的结果，并判断是否保存成功
                string sResult = "";
                string sError = "";
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(sResponse);

                //使用NodeList获取结果
                XmlNodeList returnFlag = doc.GetElementsByTagName("returnFlag");
                sResult = returnFlag.Item(0).InnerText.ToString();

                XmlNodeList summary = doc.GetElementsByTagName("summary");
                sError = summary.Item(0).InnerText.ToString();

                ////使用Node获取结果
                //XmlNode rootNode = doc.DocumentElement;
                //if (rootNode.HasChildNodes)
                //{
                //    XmlNode returnFlag = rootNode.FirstChild;
                //    sResult = returnFlag.InnerText.ToString();

                //    XmlNode summary = returnFlag.NextSibling;
                //    sError = summary.InnerText.ToString();
                //}

                //int i = PassMgrDAO.GetInstance().UpdateLocalsysUserInfo(base.CurrentUserId, spass, base.CurrentUserId, base.CurrentUserName);


                if (sResult == "0" )
                {
                    XtraMessageBox.Show("用户密码保存成功，新密码将在一小时后生效！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("用户密码保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion 保存密码

        #region 生成修改密码信息XML
        /// <summary>
        /// 生成修改密码信息XML
        /// </summary>
        private string GenXML(string operid, string opername, string opermail, string newpass)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml("<data></data>");
                //设置版本信息 
                XmlDeclaration Xmldecl;
                Xmldecl = doc.CreateXmlDeclaration("1.0", null, null);
                Xmldecl.Encoding = "UTF-8";
                //Xmldecl.Standalone="yes";     
                // 
                XmlElement data = doc.DocumentElement;
                doc.InsertBefore(Xmldecl, data);
                //设置根结点 
                XmlElement rootNode = doc.DocumentElement;


                XmlElement operatorId = doc.CreateElement("operatorId");
                operatorId.InnerText = operid;
                rootNode.AppendChild(operatorId);

                XmlElement operatorName = doc.CreateElement("operatorName");
                operatorName.InnerText = opername;
                rootNode.AppendChild(operatorName);


                XmlElement usrUser = doc.CreateElement("usrUser");
                rootNode.AppendChild(usrUser);

                XmlElement usrId = doc.CreateElement("usrId");
                usrId.InnerText = operid;
                usrUser.AppendChild(usrId);

                XmlElement usrName = doc.CreateElement("usrName");
                usrName.InnerText = opername;
                usrUser.AppendChild(usrName);

                XmlElement usrMail = doc.CreateElement("usrMail");
                usrMail.InnerText = opermail;
                usrUser.AppendChild(usrMail);

                XmlElement usrPassword = doc.CreateElement("usrPassword");
                usrPassword.InnerText = newpass;
                usrUser.AppendChild(usrPassword);

                XmlElement orgId = doc.CreateElement("orgId");
                usrUser.AppendChild(orgId);

                XmlElement orgName = doc.CreateElement("orgName");
                usrUser.AppendChild(orgName);

                XmlElement orgType = doc.CreateElement("orgType");
                usrUser.AppendChild(orgType);

                XmlElement usrEnableFlag = doc.CreateElement("usrEnableFlag");
                usrEnableFlag.InnerText = "1";
                usrUser.AppendChild(usrEnableFlag);

                XmlElement usrRemark = doc.CreateElement("usrRemark");
                usrUser.AppendChild(usrRemark);

                return doc.InnerXml.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion 生成修改密码信息XML

        private void UserInfoMgr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }
    }
}