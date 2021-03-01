//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	ProductCodeCompareBLL.cs    
//	创 建 人:	yanbing
//	创建日期:	2007-9-26
//	功能描述:	产品编码匹配业务逻辑层
//	修 改 人: 
//	修改日期:
//	主要修改内容:
//=====================================================================================

using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Emedchina.Commons;
using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Model.His;
using Emedchina.TradeAssistant.Client.DAL.His;

namespace Emedchina.TradeAssistant.Client.BLL.His.Product
{
    public class ProductCodeCompareBLL : SqlDAOBase
    {
        private ProductCodeCompareDAL dao = null;

        private ProductCodeCompareBLL()
        {
            dao = ProductCodeCompareDAL.GetInstance();
        }

        private ProductCodeCompareBLL(string connectionName)
        {
            dao = ProductCodeCompareDAL.GetInstance(connectionName);
        }

        public static ProductCodeCompareBLL GetInstance()
        {
            return new ProductCodeCompareBLL();
        }

        public static ProductCodeCompareBLL GetInstance(string connectionName)
        {
            return new ProductCodeCompareBLL(connectionName);
        }

        #region 查询产品编码对照列表
        /// <summary>
        /// 查询 产品编码对照列表信息
        /// </summary>
        /// <param name="input">产品编码对照实体类</param>
        /// <returns></returns>
        public DataTable ProductCodeCompareList(Gpo_Product_MapModel input)
        {
            DataTable dt = null;
            try
            {
                dt = dao.ProductCodeCompareList(input);
            }
            catch
            {
                throw;
            }
            return dt;
        }
        #endregion

        #region 获得产品对照查询的海虹产品列表

        public DataTable GetCommList()
        {
            DataTable dt = null;
            try
            {
                dt = dao.GetCommList();
            }
            catch
            {
                throw;
            }
            return dt;
        }

        #endregion


        #region 获得新增产品编码匹配的采购供应目录列表

        public DataTable GetGpoHitCommList()
        {
            DataTable dt = null;
            try
            {
                dt = dao.GetGpoHitCommList();
            }
            catch
            {
                throw;
            }
            return dt;
        }

        #endregion

        #region 获得产品对照查询的HIS产品对照列表

        public DataTable GetGpoMapList(string porductID,string modelID,string specID)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = dao.GetGpoMapList(porductID, modelID, specID);
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }

            return dt;
        }

        #endregion

        /// <summary>
        ///获得一条HIS产品记录
        /// </summary>
        /// <param name="productcode"></param>
        /// <returns></returns>
        public Gpo_Product_MapModel GetGpoMapModel(string productcode)
        {
            Gpo_Product_MapModel product_MapModel = null;

            try
            {
                product_MapModel = dao.GetGpoMapModel(productcode);
            }
            catch (Exception e)
            {
                throw e;
                return null;
            }
            return product_MapModel;
        }

        /// <summary>
        ///获得一条HIS产品记录
        /// </summary>
        /// <param name="productcode"></param>
        /// <returns></returns>
        public Gpo_Product_MapModel GetGpoMapModelById(string strId)
        {
            Gpo_Product_MapModel product_MapModel = null;

            try
            {
                product_MapModel = dao.GetGpoMapModelById(strId);
            }
            catch (Exception e)
            {
                throw e;
                return null;
            }
            return product_MapModel;
        }

        //判断产品编码是否重复
        public bool JudgeHisProductCode(string productcode)
        {
            bool flag = false;

            try
            {
                flag = dao.JudgeHisProductCode(productcode);
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }

            return flag;
        }

        //对接产品对照表 新增记录
        public bool Add_Gpo_Product_Map(Gpo_Product_MapModel input,out string strID)
        {
            bool flag = false;

            try
            {
                flag = dao.Add_Gpo_Product_Map(input,out strID);
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }

            return flag;
        }

        //对接产品对照表 修改记录
        public bool Edit_Gpo_Product_Map(Gpo_Product_MapModel input)
        {
            bool flag = false;

            try
            {
                flag = dao.Edit_Gpo_Product_Map(input);
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }

            return flag;
        }


        //取消匹配
        public bool CancelComparion(string strId)
        {
            bool flag = false;

            try
            {
                flag = dao.CancelComparion(strId);
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }

            return flag;
        }

        //删除
        public void DeleteGpo_Product(string strid)
        {
            try
            {
                dao.DeleteGpo_Product(strid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //获取导出产品信息
        public DataTable GetExportGpoProductMapList()
        {
            DataTable dt = null;

            try
            {
                dt = dao.GetExportGpoProductMapList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;

        }

        //导入产品数据
        public bool Import_Gpo_Product(string orgid, IList<Gpo_Product_MapModel> list)
        {
            bool flag = true;
            try
            {
                flag = dao.Import_Gpo_Product(orgid, list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return flag;
        }

        public DataTable GetProjectTypeDt()
        {
            DataTable dt;
            try
            {
                dt = dao.GetProjectTypeDt();
            }catch
            {
                return null;
            }
            return dt;
        }
    }
}
