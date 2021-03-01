
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
    /// ��Ŀ��Ʒ����Ϣ��ҵ������ࣩ
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
        /// ��ȡ�����ɹ�Ŀ¼��Ŀ��Ʒ��Ϣ(ʹ�õط����½����ɹ���ӦĿ¼)
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

