//======================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	ViewAfficheInfoForm.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	查看公告信息
//	修 改 人: 
//	修改日期:
//=====================================================================================

using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using Emedchina.TradeAssistant.Model.CommInfo;
using Emedchina.TradeAssistant.Client.BLL.CommonInfo;

namespace Emedchina.TradeAssistant.Client.UI.CommonInfo.AfficheInfo
{
    /// <summary>
    /// 查看公告信息
    /// </summary>
    public partial class ViewAfficheInfoForm : DevExpress.XtraEditors.XtraForm
    {

        #region 变量定义区
        //公告信息对象
        private BulletinInfoModel model = null;
        #endregion

        #region 构造
        public ViewAfficheInfoForm()
        {
            InitializeComponent();
            IniTextClear();
        }

        public ViewAfficheInfoForm(string strBulletionID)
        {
            InitializeComponent();
            IniData(strBulletionID);
        }
        #endregion

        #region 初始货显示数据
        /// <summary>
        /// 初始化显示信息
        /// </summary>
        /// <param name="strBulietin_Id">公告ID</param>
        private void IniData(string strBulletionID)
        {
            //清空文本
            IniTextClear();

            //获取公告对象
            model = BulletinInfoBLL.GetInstance().GetBulletinInfoModel(strBulletionID);

            if (model != null)
            {
                this.labTitle.Text = model.Title;
                this.webContent.DocumentText = model.Content.ToString();
                this.labReadName.Text = model.ReadName;
                this.labISSUER_NAME.Text = model.IsSuerName;
                this.labISSUE_DATE.Text = model.IsSuerDate;

                //修改已阅读状态  1未阅读 2已阅读
                if (model.IsRead.Equals("1"))
                {
                    BulletinInfoBLL.GetInstance().ModifyBulletinReceiver(model.ReceiverId);
                }
            }
        }

        /// <summary>
        /// 清空文本
        /// </summary>
        private void IniTextClear()
        {
            this.labTitle.Text = "";
            //this.webContent.DocumentText = "";
            this.labReadName.Text = "";
            this.labISSUER_NAME.Text = "";
            this.labISSUE_DATE.Text = "";
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

    }
}