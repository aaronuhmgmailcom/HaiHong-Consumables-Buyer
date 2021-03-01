//======================================================================================
//	Copyright (c)  Emedchina
//
//	�� �� ��:	InitComboBox.cs   
//	�� �� ��:	������
//	��������:	2006-6-14
//	��������:	��ʼ�������б�
//	�� �� ��: 
//	�޸�����:
//	��Ҫ�޸�����:
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
        /// ��ʼ������״̬�����б�
        /// </summary>
        /// <param name="box">�����б����</param>
        public static void InitOrderState(ComboBox box)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns[0].ColumnName = "value";
            dt.Columns[1].ColumnName = "text";
            string[] data = { "-1", "δ���" };
            dt.Rows.Add(data);
            string[] data1 = { "0", "������" };
            dt.Rows.Add(data1);
            string[] data2 = { "1", "�����Ķ�" };
            dt.Rows.Add(data2);
            string[] data3 = { "2", "��������" };
            dt.Rows.Add(data3);
            string[] data4 = { "3", "���" };
            dt.Rows.Add(data4);
            string[] data5 = { "", "ȫ��" };
            dt.Rows.Add(data5);
            box.DataSource = dt;
            box.DisplayMember = "text";
            box.ValueMember = "value";
        }
        /// <summary>
        /// ��ʼ�����������б�
        /// </summary>
        /// <param name="box">�����б����</param>
        public static void InitOrderType(ComboBox box)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns[0].ColumnName = "value";
            dt.Columns[1].ColumnName = "text";
            string[] data = { "1", "����ҵ" };
            dt.Rows.Add(data);
            string[] data1 = { "2", "������" };
            dt.Rows.Add(data1);

            box.DataSource = dt;
            box.DisplayMember = "text";
            box.ValueMember = "value";
        }
        /// <summary>
        /// ��ʼ����ѯ���������б�
        /// </summary>
        /// <param name="box">�����б����</param>
        public static void InitType(ComboBox box)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns[0].ColumnName = "value";
            dt.Columns[1].ColumnName = "text";
            string[] data1 = { "1", "����ҵ" };
            dt.Rows.Add(data1);
            string[] data2 = { "2", "������" };
            dt.Rows.Add(data2);
            

            box.DataSource = dt;
            box.DisplayMember = "text";
            box.ValueMember = "value";
        }
        /// <summary>
        /// ��ʼ���˻����������б�
        /// </summary>
        /// <param name="box">�����б����</param>
        public static void InitBuyerReturnType(ComboBox box)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns[0].ColumnName = "value";
            dt.Columns[1].ColumnName = "text";
            string[] data1 = { "1", "Ʒ��" };
            dt.Rows.Add(data1);
            string[] data2 = { "2", "������ҵ" };
            dt.Rows.Add(data2);
            string[] data3 = { "3", "������ҵ" };
            dt.Rows.Add(data3);

            box.DataSource = dt;
            box.DisplayMember = "text";
            box.ValueMember = "value";
        }
        /// <summary>
        /// ��ʼ���˻�״̬�����б�
        /// </summary>
        /// <param name="box">�����б����</param>
        public static void InitReturnStateType(ComboBox box)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns[0].ColumnName = "value";
            dt.Columns[1].ColumnName = "text";
            string[] data = { "", "ȫ��" };
            dt.Rows.Add(data);
            string[] data1 = { "1", "�ѷ���" };
            dt.Rows.Add(data1);
            string[] data2 = { "2", "�ѳ���" };
            dt.Rows.Add(data2);
            string[] data3 = { "3", "�Է���ͬ��" };
            dt.Rows.Add(data3);
            string[] data4 = { "4", "�Է��Ѿܾ�" };
            dt.Rows.Add(data4);

            box.DataSource = dt;
            box.DisplayMember = "text";
            box.ValueMember = "value";
        }
        /// <summary>
        /// ��ʼ���˻�״̬�����б�
        /// </summary>
        /// <param name="box">�����б����</param>
        public static void InitReturnReason(DataGridViewComboBoxColumn box)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns[0].ColumnName = "value";
            dt.Columns[1].ColumnName = "text";

            string[] data = { "", "" };
            dt.Rows.Add(data);
            string[] data1 = { "1", "����ԭ��" };
            dt.Rows.Add(data1);
            string[] data2 = { "2", "��������Ҫ��" };
            dt.Rows.Add(data2);
            string[] data3 = { "3", "��Ч��" };
            dt.Rows.Add(data3);
            string[] data4 = { "4", "�۸����" };
            dt.Rows.Add(data4);
            string[] data5 = { "5", "����" };
            dt.Rows.Add(data5);
            string[] data6 = { "6", "����" };
            dt.Rows.Add(data6);
            string[] data7 = { "7", "����" };
            dt.Rows.Add(data7);

            box.DataSource = dt;
            box.DisplayMember = "text";
            box.ValueMember = "value";
            box.Selected = true;
        }
        /// <summary>
        /// ��ʼ���ɹ���Χ�����б�
        /// </summary>
        /// <param name="box">�����б����</param>
        public static void InitScope(ComboBox box)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns[0].ColumnName = "value";
            dt.Columns[1].ColumnName = "text";

           
            string[] data2 = { Constant.CONTITEM, "��ͬ�ɹ�Ŀ¼" };
            dt.Rows.Add(data2);
            string[] data1 = { Constant.HITCOMMTABLE, "�����ɹ�Ŀ¼" };
            dt.Rows.Add(data1);
            

            box.DataSource = dt;
            box.DisplayMember = "text";
            box.ValueMember = "value";
        }

        /// <summary>
        /// ��ʼ���˻����������б�
        /// </summary>
        /// <param name="box">�����б����</param>
        public static void InitExportOrderType(ComboBox box)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns[0].ColumnName = "value";
            dt.Columns[1].ColumnName = "text";
            string[] data1 = { "0", "δ����" };
            dt.Rows.Add(data1);
            string[] data2 = { "1", "�ѵ���" };
            dt.Rows.Add(data2);
            string[] data3 = { "", "ȫ��" };
            dt.Rows.Add(data3);

            box.DataSource = dt;
            box.DisplayMember = "text";
            box.ValueMember = "value";
        }

    }
}
