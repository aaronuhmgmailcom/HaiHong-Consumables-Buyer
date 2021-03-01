//======================================================================================
//	Copyright (c)  Emedchina
//
//	�� �� ��:	MainFormBase.cs   
//	�� �� ��:	������
//	��������:	2006-6-8
//	��������:	��������Ӧ�Ĵ����ļ�
//	�� �� ��: 
//	�޸�����:
//	��Ҫ�޸�����:����˵�ǰ�û���¼��Ϣ����2006.6.24 sunhl��
//=====================================================================================

/*
 * $Date: 06-09-25 17:11 $
 * $History: MainFormBase.cs $
 * 
 * *****************  Version 27  *****************
 * User: Liangxy      Date: 06-09-25   Time: 17:11
 * Updated in $/TradeAssistantSaler1.2.root/TradeAssistantSaler/TradeAssistantSaler/Base
 * 
 * *****************  Version 26  *****************
 * User: Liangxy      Date: 06-09-20   Time: 17:09
 * Updated in $/TradeAssistantSaler1.2.root/TradeAssistantSaler/TradeAssistantSaler/Base
 * 
 * *****************  Version 25  *****************
 * User: Liangxy      Date: 06-09-15   Time: 15:20
 * Updated in $/TradeAssistantSaler1.2.root/TradeAssistantSaler/TradeAssistantSaler/Base
 * 
 * *****************  Version 24  *****************
 * User: Panyj        Date: 06-09-11   Time: 16:01
 * Updated in $/TradeAssistantSaler1.2.root/TradeAssistantSaler/TradeAssistantSaler/Base
 * 
 * *****************  Version 23  *****************
 * User: Panyj        Date: 06-09-11   Time: 14:16
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Base
 * 
 * *****************  Version 22  *****************
 * User: Panyj        Date: 06-07-28   Time: 15:27
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Base
 * 
 * *****************  Version 21  *****************
 * User: Liangxy      Date: 06-07-17   Time: 9:45
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Base
 * 
 * *****************  Version 20  *****************
 * User: Liangxy      Date: 06-07-14   Time: 9:58
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Base
 * 
 * *****************  Version 19  *****************
 * User: Liangxy      Date: 06-07-04   Time: 15:48
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Base
 * 
 * *****************  Version 18  *****************
 * User: Liangxy      Date: 06-07-03   Time: 13:03
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Base
 * 
 * *****************  Version 17  *****************
 * User: Liangxy      Date: 06-06-29   Time: 16:50
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Base
 * 
 * *****************  Version 16  *****************
 * User: Liangxy      Date: 06-06-29   Time: 14:16
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Base
 * 
 * *****************  Version 15  *****************
 * User: Liangxy      Date: 06-06-29   Time: 10:54
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Base
 * 
 * *****************  Version 14  *****************
 * User: Liangxy      Date: 06-06-28   Time: 17:03
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Base
 * 
 * *****************  Version 13  *****************
 * User: Liangxy      Date: 06-06-28   Time: 15:51
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Base
 * 
 * *****************  Version 12  *****************
 * User: Liangxy      Date: 06-06-28   Time: 15:44
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Base
 * 
 * *****************  Version 11  *****************
 * User: Sunhl        Date: 06-06-26   Time: 13:40
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Base
 * 
 * *****************  Version 10  *****************
 * User: Sunhl        Date: 06-06-24   Time: 15:45
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Base
 * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emedchina.Commons.WinForms;
using Emedchina.Commons;
using System.IO;
using Emedchina.TradeAssistant.Client.Common;


namespace Emedchina.TradeAssistant.Client.Base
{
    /// <summary>
    ///CurrentUserId	��ǰ�û�id
    ///CurrentUserName	��ǰ�û�����
    ///CurrentUserOrgId	��ǰ�û�����id
    ///CurrentUserOrgName	��ǰ�û���������
    ///CurrentUserRegOrgId ��ǰ�û�ע�����id 
    ///CurrentUserRegionId	��ǰ�û�����id
    ///CurrentUserSingleRegionId	��ǰ�û�ע������id ���൱��AreaId,����Ȩ�����ѣ�
    ///CurrentUserRoleId		��ǰ�û���ɫid
    ///CurrentIsHospital  �Ƿ���ҽԺ�������ǹ�Ӧվ 
    /// </summary>
    public partial class MainFormBase : Form
    {
        protected DataTable newsTable;
        protected DataTable gridTable;
        protected DataView cachedDataView;
        protected DataView gridDataView;
        private static readonly int defaultPageSize = 20;
        private ComBase comBase = new ComBase();
        public MainFormBase()
        {
            InitializeComponent();
        }
        /// <summary>
        /// ��дShow����
        /// </summary>
        public new void Show()
        {
            base.Show();
            string functionName = this.GetType().ToString();

            FileControl.clientLog(functionName);

        }
        /// <summary>
        /// ��дHide����
        /// </summary>
        public new void Hide()
        {
            base.Hide();
            //FormSelf frm = (FormSelf)this.ParentForm;
            //frm.setTitle("");
            //frm.LoadFormToPanel(frm.DefaultPage);

        }

        private void MainFormBase_Load(object sender, EventArgs e)
        {

            //���ÿؼ�����
            comBase.setControls(this.Controls, this.CheckTextBox);
        }
        protected void CheckInputCom(object sender)
        {

            //ת�������ַ�
            comBase.CheckControls(sender);
        }
        protected void CheckInputAll()
        {

            //ת�������ַ�
            comBase.CheckAllControls(this.Controls);
        }
        protected void CheckTextBox(object sender, EventArgs e)
        {
            //ת�������ַ�
            comBase.CheckControls(sender);
        }
        ///// <summary>
        ///// �ӻ�����ȡ������
        ///// </summary>
        ///// <param name="TableName"></param>
        protected void InitFromCache(string TableName)
        {
            //CacheControl.GetInstance().checkCacheAndUpdate(TableName);
            newsTable = ClientCache.CachedDS.Tables[TableName];
            gridTable = newsTable.Clone();
            cachedDataView = newsTable.DefaultView;
            InitGridTableView(1, defaultPageSize);
        }
        /// <summary>
        /// �ӻ�����ȡ������
        /// </summary>
        /// <param name="TableName"></param>
        protected void InitFromCacheByData(DataTable dt)
        {

            newsTable = dt;
            gridTable = newsTable.Clone();
            cachedDataView = newsTable.DefaultView;
            InitGridTableView(1, defaultPageSize);
        }
        ///// <summary>
        ///// �ӻ�����ȡ���ӱ�����
        ///// </summary>
        ///// <param name="mainTableName">������</param>
        ///// <param name="childTableName">�ӱ���</param>
        ///// <param name="relation">�������ӱ�Ĺ�ϵ��</param>
        ///// <param name="id">����Id</param>
        //protected void InitFromCache(string TableName, string childTableName, string relation, string id)
        //{
        //    newsTable = ClientCache.CachedDS.Tables[childTableName].Clone();
        //    DataRow row = ClientCache.CachedDS.Tables[TableName].Rows.Find(id);
        //    DataRow[] rows = row.GetChildRows(relation);
        //    foreach (DataRow rowChild in rows)
        //    {
        //        newsTable.Rows.Add(rowChild.ItemArray);
        //    }
        //    gridTable = newsTable.Clone();
        //    cachedDataView = newsTable.DefaultView;
        //    InitGridTableView(1, defaultPageSize);
        //}
        ///// <summary>
        ///// �ӻ�����ȡ���ӱ�����
        ///// </summary>
        ///// <param name="mainTableName">������</param>
        ///// <param name="childTableName">�ӱ���</param>
        ///// <param name="relation">�������ӱ�Ĺ�ϵ��</param>
        ///// <param name="id">����Id</param>
        //protected DataTable GetChildTable(string mainTableName, string childTableName, string relation, string id)
        //{

        //    DataRow row = ClientCache.CachedDS.Tables[mainTableName].Rows.Find(id);
        //    DataRow[] rows = row.GetChildRows(relation);
        //    DataTable table = ClientCache.CachedDS.Tables[childTableName].Clone();
        //    foreach (DataRow rowChild in rows)
        //    {
        //        table.Rows.Add(rowChild.ItemArray);
        //    }
        //    return table;
        //}
        /// <summary>
        /// ��ҳ����
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        protected void InitGridTableView(int pageNum, int pageSize)
        {
            int start = PageUtils.GetLowIndexOfPage(pageNum, pageSize);
            int end = PageUtils.GetHighIndexOfPage(pageNum, pageSize);
            //PageChangedEventArgs pageNavigator = this.Controls["pageNavigator1"] as PageChangedEventArgs;
            gridTable.Clear();
            if (cachedDataView.Count < pageSize)
            {
                for (int i = 0; i < cachedDataView.Count; i++)
                {
                    DataRowView drw = cachedDataView[i];
                    gridTable.ImportRow(drw.Row);
                }
            }
            else
            {
                for (int i = start; i < end + 1; i++)
                {
                    if (i <= cachedDataView.Count)
                    {
                        DataRowView drw = cachedDataView[i - 1];
                        gridTable.ImportRow(drw.Row);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            gridDataView = gridTable.DefaultView;
        }


        //sunhl added,2006.6.24 15:15

        /// <summary>
        /// Gets the current user id.
        /// </summary>
        /// <value>The current user id.</value>
        protected virtual string CurrentUserId
        {
            get { return ClientSession.GetInstance().CurrentUser.UserInfo.Id; }
        }

        /// <summary>
        /// Gets the name of the current user.
        /// </summary>
        /// <value>The name of the current user.</value>
        protected virtual string CurrentUserName
        {
            get { return ClientSession.GetInstance().CurrentUser.UserInfo.Name; }
        }

        /// <summary>
        /// Gets the current user org id.
        /// </summary>
        /// <value>The current user org id.</value>
        protected virtual string CurrentUserOrgId
        {
            get { return ClientSession.GetInstance().CurrentUser.UserOrg.Reg_org_id; }
        }

        /// <summary>
        /// Gets the name of the current user org.
        /// </summary>
        /// <value>The name of the current user org.</value>
        protected virtual string CurrentUserOrgName
        {
            get { return ClientSession.GetInstance().CurrentUser.UserOrg.Name; }
        }

        /// <summary>
        /// Gets the current user region id.
        /// </summary>
        /// <value>The current user region id.</value>
        protected virtual string CurrentUserRegionId
        {
            get { return ClientSession.GetInstance().CurrentUser.UserInfo.Region_id; }
        }

        /// <summary>
        /// Gets the current user single region id.
        /// </summary>
        /// <value>The current user single region id.</value>
        protected virtual string CurrentUserSingleRegionId
        {
            get { return ClientSession.GetInstance().CurrentUser.SingleRegionId; }
        }

        /// <summary>
        /// Gets the current user role id.
        /// </summary>
        /// <value>The current user role id.</value>
        protected virtual string CurrentUserRoleId
        {
            get { return ClientSession.GetInstance().CurrentUser.UserInfo.Role_id; }
        }

        /// <summary>
        /// �����Ƿ�������ҵ
        /// </summary>
        /// <value></value>
        protected virtual bool CurrentUserIsFactory
        {
            get { return ClientSession.GetInstance().CurrentUser.UserOrg.IsFactory; }
        }

        /// <summary>
        /// ���ص�ǰ�û��������б�
        /// </summary>
        /// <value></value>
        protected virtual string CurrentUserAreaList
        {
            get { return ClientSession.GetInstance().CurrentUser.UserInfo.Area_List; }
        }

        /// <summary>
        /// Gets the current user reg org id.
        /// </summary>
        /// <value>The current user reg org id.</value>
        protected virtual string CurrentUserRegOrgId
        {
            get { return ClientSession.GetInstance().CurrentUser.UserOrg.Reg_org_id; }
        }

        protected virtual bool CurrentIsHospital
        {
            get { return ClientSession.GetInstance().CurrentUser.UserOrg.IsHospital; }
        }

    }
}