//======================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	BulletinInfoBLL.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	公告信息（业务操作类）
//	修 改 人: 
//	修改日期:
//=====================================================================================

using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Model.CommInfo;
using Emedchina.TradeAssistant.Client.DAL.CommonInfo;

namespace Emedchina.TradeAssistant.Client.BLL.CommonInfo
{
    /// <summary>
    /// 公告信息（业务操作类）
    /// </summary>
    class BulletinInfoBLL
    {
        BulletinInfoDao dao = null;

        private BulletinInfoBLL()
        {
            dao = BulletinInfoDao.GetInstance();
        }

        public static BulletinInfoBLL GetInstance()
        {
            return new BulletinInfoBLL();
        }

        private BulletinInfoBLL(string connectionName)
        {
            dao = BulletinInfoDao.GetInstance(connectionName);
        }

        public static BulletinInfoBLL GetInstance(String strConnectionn)
        {
            return new BulletinInfoBLL(strConnectionn);
        }

        /// <summary>
        /// 获取公告信息数据集
        /// </summary>
        /// <returns></returns>
        public DataTable GetBulletinInfoDt(LogedInUser logedinUser)
        {
            try
            {
                return dao.GetBulletinInfoDt(logedinUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取公告信息对象
        /// </summary>
        /// <param name="Hc_Id"></param>
        /// <returns></returns>
        public BulletinInfoModel GetBulletinInfoModel(string strBulietin_Id)
        {
            try
            {
                return dao.GetBulletinInfoModel(strBulietin_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 修改公告接收用户表阅读状态
        /// </summary>
        /// <param name="ReceiverId"></param>
        public void ModifyBulletinReceiver(string ReceiverId)
        {
            try
            {
                dao.ModifyBulletinReceiver(ReceiverId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
