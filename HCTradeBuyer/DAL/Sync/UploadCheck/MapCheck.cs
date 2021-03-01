using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Emedchina.Commons.Data;

namespace Emedchina.TradeAssistant.DAL.Sync.UploadCheck
{
    public class MapCheck : OracleDAOBase
    {
        private MapCheck()
            : base()
        { }

        private MapCheck(string connectionName)
            : base(connectionName)
        { }

        public static MapCheck GetInstance()
        {
            return new MapCheck();
        }

        public static MapCheck GetInstance(string connectionName)
        {
            return new MapCheck(connectionName);
        }
        public bool CheckProductForInsert(DataRow dr, DbTransaction tran, out string strInvalid)
        {
            strInvalid = "";
            bool flag = false;
            string sql = "select count(*) from gpo_product_map g where g.map_orgid = :map_orgid and g.product_code = :product_code";
            DbParameter para = this.DbFacade.CreateParameter();
            para.ParameterName = "map_orgid";
            para.DbType = DbType.AnsiString;
            para.Value = dr["map_orgid"].ToString();

            DbParameter para1 = this.DbFacade.CreateParameter();
            para1.ParameterName = "product_code";
            para1.DbType = DbType.AnsiString;
            para1.Value = dr["product_code"].ToString();

            Object o = DbFacade.SQLExecuteScalar(sql,tran, para,para1);

            if (o != null && !o.ToString().Equals("0"))
            {
                strInvalid = "table:gpo_product_map/ID:" + dr["ID"].ToString() + "/药品编码:" + dr["product_code"].ToString() + "已存在不能新增";
                flag = false;
            }
            else
            {
                flag = true;
            }
            

            return flag;
        }


        public bool CheckCorpForInsert(DataRow dr, DbTransaction tran, out string strInvalid)
        {
            strInvalid = "";
            bool flag = false;
            string sql = "select count(*) from gpo_corp_map g where g.map_orgid = :map_orgid and g.code = :code";
            DbParameter para = this.DbFacade.CreateParameter();
            para.ParameterName = "map_orgid";
            para.DbType = DbType.AnsiString;
            para.Value = dr["map_orgid"].ToString();

            DbParameter para1 = this.DbFacade.CreateParameter();
            para1.ParameterName = "code";
            para1.DbType = DbType.AnsiString;
            para1.Value = dr["code"].ToString();

            Object o = DbFacade.SQLExecuteScalar(sql, tran, para, para1);

            if (o != null && !o.ToString().Equals("0"))
            {
                strInvalid = "table:gpo_corp_map/ID:" + dr["ID"].ToString() + "/机构编码:" + dr["code"].ToString() + "已存在不能新增";
                flag = false;
            }
            else
            {
                flag = true;
            }


            return flag;
        }
    }
}
