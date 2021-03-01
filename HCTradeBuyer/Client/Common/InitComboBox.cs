//======================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	InitComboBox.cs   
//	创 建 人:	梁晓奕
//	创建日期:	2006-6-14
//	功能描述:	初始化下拉列表
//	修 改 人: 
//	修改日期:
//	主要修改内容:
//=====================================================================================
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace Emedchina.TradeAssistant.Client.Common
{
    public class InitComboBox
    {
        /// <summary>
        /// 初始化订单状态下拉列表
        /// </summary>
        /// <param name="box">下拉列表对象</param>
        public static void InitOrderState(ComboBox box)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns[0].ColumnName = "value";
            dt.Columns[1].ColumnName = "text";
            string[] data = { "-1", "未完成" };
            dt.Rows.Add(data);
            string[] data1 = { "0", "－发送" };
            dt.Rows.Add(data1);
            string[] data2 = { "1", "－已阅读" };
            dt.Rows.Add(data2);
            string[] data3 = { "2", "－交易中" };
            dt.Rows.Add(data3);
            string[] data4 = { "3", "完成" };
            dt.Rows.Add(data4);
            string[] data5 = { "", "全部" };
            dt.Rows.Add(data5);
            box.DataSource = dt;
            box.DisplayMember = "text";
            box.ValueMember = "value";
        }
        /// <summary>
        /// 初始化类型下拉列表
        /// </summary>
        /// <param name="box">下拉列表对象</param>
        public static void InitOrderType(ComboBox box)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns[0].ColumnName = "value";
            dt.Columns[1].ColumnName = "text";
            string[] data = { "1", "买方企业" };
            dt.Rows.Add(data);
            string[] data1 = { "2", "订单号" };
            dt.Rows.Add(data1);

            box.DataSource = dt;
            box.DisplayMember = "text";
            box.ValueMember = "value";
        }
        /// <summary>
        /// 初始化查询类型下拉列表
        /// </summary>
        /// <param name="box">下拉列表对象</param>
        public static void InitType(ComboBox box)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns[0].ColumnName = "value";
            dt.Columns[1].ColumnName = "text";
            string[] data1 = { "1", "买方企业" };
            dt.Rows.Add(data1);
            string[] data2 = { "2", "订单号" };
            dt.Rows.Add(data2);
            

            box.DataSource = dt;
            box.DisplayMember = "text";
            box.ValueMember = "value";
        }
        /// <summary>
        /// 初始化退货管理下拉列表
        /// </summary>
        /// <param name="box">下拉列表对象</param>
        public static void InitBuyerReturnType(ComboBox box)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns[0].ColumnName = "value";
            dt.Columns[1].ColumnName = "text";
            string[] data1 = { "1", "品名" };
            dt.Rows.Add(data1);
            string[] data2 = { "2", "经销企业" };
            dt.Rows.Add(data2);
            string[] data3 = { "3", "卖方企业" };
            dt.Rows.Add(data3);

            box.DataSource = dt;
            box.DisplayMember = "text";
            box.ValueMember = "value";
        }
        /// <summary>
        /// 初始化退货状态下拉列表
        /// </summary>
        /// <param name="box">下拉列表对象</param>
        public static void InitReturnStateType(ComboBox box)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns[0].ColumnName = "value";
            dt.Columns[1].ColumnName = "text";
            string[] data = { "", "全部" };
            dt.Rows.Add(data);
            string[] data1 = { "1", "已发出" };
            dt.Rows.Add(data1);
            string[] data2 = { "2", "已撤销" };
            dt.Rows.Add(data2);
            string[] data3 = { "3", "对方已同意" };
            dt.Rows.Add(data3);
            string[] data4 = { "4", "对方已拒绝" };
            dt.Rows.Add(data4);

            box.DataSource = dt;
            box.DisplayMember = "text";
            box.ValueMember = "value";
        }
        /// <summary>
        /// 初始化退货状态下拉列表
        /// </summary>
        /// <param name="box">下拉列表对象</param>
        public static void InitReturnReason(DataGridViewComboBoxColumn box)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns[0].ColumnName = "value";
            dt.Columns[1].ColumnName = "text";

            string[] data = { "", "" };
            dt.Rows.Add(data);
            string[] data1 = { "1", "质量原因" };
            dt.Rows.Add(data1);
            string[] data2 = { "2", "不符订单要求" };
            dt.Rows.Add(data2);
            string[] data3 = { "3", "近效期" };
            dt.Rows.Add(data3);
            string[] data4 = { "4", "价格调整" };
            dt.Rows.Add(data4);
            string[] data5 = { "5", "滞销" };
            dt.Rows.Add(data5);
            string[] data6 = { "6", "变质" };
            dt.Rows.Add(data6);
            string[] data7 = { "7", "其他" };
            dt.Rows.Add(data7);

            box.DataSource = dt;
            box.DisplayMember = "text";
            box.ValueMember = "value";
            box.Selected = true;
        }
        /// <summary>
        /// 初始化采购范围下拉列表
        /// </summary>
        /// <param name="box">下拉列表对象</param>
        public static void InitScope(ComboBox box)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns[0].ColumnName = "value";
            dt.Columns[1].ColumnName = "text";

           
            string[] data2 = { Constant.CONTITEM, "合同采购目录" };
            dt.Rows.Add(data2);
            string[] data1 = { Constant.HITCOMMTABLE, "经常采购目录" };
            dt.Rows.Add(data1);
            

            box.DataSource = dt;
            box.DisplayMember = "text";
            box.ValueMember = "value";
        }

        /// <summary>
        /// 初始化退货管理下拉列表
        /// </summary>
        /// <param name="box">下拉列表对象</param>
        public static void InitExportOrderType(ComboBox box)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns[0].ColumnName = "value";
            dt.Columns[1].ColumnName = "text";
            string[] data1 = { "0", "未导出" };
            dt.Rows.Add(data1);
            string[] data2 = { "1", "已导出" };
            dt.Rows.Add(data2);
            string[] data3 = { "", "全部" };
            dt.Rows.Add(data3);

            box.DataSource = dt;
            box.DisplayMember = "text";
            box.ValueMember = "value";
        }

    }
}
