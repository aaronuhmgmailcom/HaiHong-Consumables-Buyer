//======================================================================================
//	Copyright (c)  Emedchina
//
//	�� �� ��:	FormBase.cs   
//	�� �� ��:	������
//	��������:	2006-6-8
//	��������:	������������Ӧ�Ĵ����ļ�
//	�� �� ��: 
//	�޸�����:
//	��Ҫ�޸�����:����˵�ǰ�û���¼��Ϣ����2006.6.24 sunhl��
//=====================================================================================

/*
 * $Date: 06-09-20 17:09 $
 * $History: FormBase.cs $
 * 
 * *****************  Version 14  *****************
 * User: Liangxy      Date: 06-09-20   Time: 17:09
 * Updated in $/TradeAssistantSaler1.2.root/TradeAssistantSaler/TradeAssistantSaler/Base
 * 
 * *****************  Version 13  *****************
 * User: Liangxy      Date: 06-09-19   Time: 16:35
 * Updated in $/TradeAssistantSaler1.2.root/TradeAssistantSaler/TradeAssistantSaler/Base
 * 
 * *****************  Version 11  *****************
 * User: Liangxy      Date: 06-07-14   Time: 9:58
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Base
 * 
 * *****************  Version 10  *****************
 * User: Liangxy      Date: 06-07-04   Time: 15:48
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Base
 * 
 * *****************  Version 9  *****************
 * User: Liangxy      Date: 06-06-29   Time: 16:50
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Base
 * 
 * *****************  Version 8  *****************
 * User: Sunhl        Date: 06-06-26   Time: 13:40
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/Base
 * 
 * *****************  Version 7  *****************
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
using Emedchina.Commons;
using Emedchina.TradeAssistant.Client;

namespace Emedchina.TradeAssistant.Client.Base
{
    /// <summary>
    ///CurrentUserId	��ǰ�û�id
    ///CurrentUserName	��ǰ�û�����
    ///CurrentUserOrgId	��ǰ�û�����id
    ///CurrentUserRegOrgId ��ǰ�û�ע�����id
    ///CurrentUserOrgName	��ǰ�û���������
    ///CurrentUserRegionId	��ǰ�û�����id
    ///CurrentUserSingleRegionId	��ǰ�û�ע������id ���൱��AreaId,����Ȩ�����ѣ�
    ///CurrentUserRoleId		��ǰ�û���ɫid
    /// </summary>
    public partial class FormBase : Form
    {
        protected DataTable newsTable;
        protected DataTable gridTable;
        protected DataView cachedDataView;
        protected DataView gridDataView;
        private static readonly int defaultPageSize = 20;
        private ComBase comBase = new ComBase();

        public FormBase()
        {
            InitializeComponent();
        }
        //���ÿؼ�����
        private void FormBase_Load(object sender, EventArgs e)
        {
            this.Text = "����ҽҩ��������������";

            comBase.setControls(this.Controls, this.CheckTextBox);

        }
        protected void CheckInputCom(object sender)
        {

            //ת�������ַ�
            comBase.CheckControls(sender);
        }
        protected void CheckInputAll()
        {

            //���ÿؼ�����
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
        /// <summary>
        /// �ӻ�����ȡ������
        /// </summary>
        /// <param name="TableName"></param>
        protected void InitFromCacheByData(DataTable dt, int pageNum, int pageSize)
        {

            newsTable = dt;
            gridTable = newsTable.Clone();
            cachedDataView = newsTable.DefaultView;
            InitGridTableView(pageNum, pageSize);
        }
        ///// <summary>
        ///// �ӻ�����ȡ���ӱ�����
        ///// </summary>
        ///// <param name="mainTableName">������</param>
        ///// <param name="childTableName">�ӱ���</param>
        ///// <param name="relation">�������ӱ�Ĺ�ϵ��</param>
        ///// <param name="id">����Id</param>
        //protected void InitFromCache(string TableName,string  childTableName,string relation, string id)
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
        //protected DataTable GetChildTable(string mainTableName,string childTableName, string relation, string id)
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
        /// Gets the current user reg org id.
        /// </summary>
        /// <value>The current user reg org id.</value>
        protected virtual string CurrentUserRegOrgId
        {
            get { return ClientSession.GetInstance().CurrentUser.UserOrg.Reg_org_id; }
        }
    }
}