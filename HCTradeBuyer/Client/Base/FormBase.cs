//======================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	FormBase.cs   
//	创 建 人:	梁晓奕
//	创建日期:	2006-6-8
//	功能描述:	弹出窗体基类对应的代码文件
//	修 改 人: 
//	修改日期:
//	主要修改内容:添加了当前用户登录信息。（2006.6.24 sunhl）
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
    ///CurrentUserId	当前用户id
    ///CurrentUserName	当前用户名称
    ///CurrentUserOrgId	当前用户机构id
    ///CurrentUserRegOrgId 当前用户注册机构id
    ///CurrentUserOrgName	当前用户机构名称
    ///CurrentUserRegionId	当前用户区域id
    ///CurrentUserSingleRegionId	当前用户注册区域id （相当于AreaId,解释权归世佳）
    ///CurrentUserRoleId		当前用户角色id
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
        //设置控件属性
        private void FormBase_Load(object sender, EventArgs e)
        {
            this.Text = "海虹医药电子商务交易助手";

            comBase.setControls(this.Controls, this.CheckTextBox);

        }
        protected void CheckInputCom(object sender)
        {

            //转换特殊字符
            comBase.CheckControls(sender);
        }
        protected void CheckInputAll()
        {

            //设置控件属性
            comBase.CheckAllControls(this.Controls);
        }
        protected void CheckTextBox(object sender, EventArgs e)
        {
            //转换特殊字符
            comBase.CheckControls(sender);
        }
        ///// <summary>
        ///// 从缓存中取得数据
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
        /// 从缓存中取得数据
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
        /// 从缓存中取得数据
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
        ///// 从缓存中取得子表数据
        ///// </summary>
        ///// <param name="mainTableName">主表名</param>
        ///// <param name="childTableName">子表名</param>
        ///// <param name="relation">主表与子表的关系名</param>
        ///// <param name="id">主表Id</param>
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
        ///// 从缓存中取得子表数据
        ///// </summary>
        ///// <param name="mainTableName">主表名</param>
        ///// <param name="childTableName">子表名</param>
        ///// <param name="relation">主表与子表的关系名</param>
        ///// <param name="id">主表Id</param>
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
        /// 分页操作
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