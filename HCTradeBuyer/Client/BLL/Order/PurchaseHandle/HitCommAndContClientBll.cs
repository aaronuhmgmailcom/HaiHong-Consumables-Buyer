
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Client.DAL.Order.PurchaseHandle;

namespace Emedchina.TradeAssistant.Client.BLL.Order.PurchaseHandle
{
    /// <summary>
    /// 项目产品表信息（业务操作类）
    /// </summary>
    public class HitCommAndContClientBll
    {
        HitCommAndContClientDao dao = null;

        public HitCommAndContClientBll()
        {
            dao = HitCommAndContClientDao.GetInstance();
        }

        public static HitCommAndContClientBll GetInstance()
        {
            return new HitCommAndContClientBll();
        }

       public HitCommAndContClientBll(string connectionName)
        {
            dao = HitCommAndContClientDao.GetInstance(connectionName);
        }

        public static HitCommAndContClientBll GetInstance(String strConnectionn)
        {
            return new HitCommAndContClientBll(strConnectionn);
        }

        /// <summary>
        /// 获取经常采购目录项目产品信息(使用地方：新建常采购供应目录)
        /// </summary>
        /// <returns></returns>
        public DataTable GetHitProductDt(string strProjectID, LogedInUser logedinUser, string strDataName)
        {
            try
            {
                return dao.GetHitProductDt(strProjectID, logedinUser, strDataName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




       
    }
}

