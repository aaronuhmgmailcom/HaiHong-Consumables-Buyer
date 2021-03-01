#region Header
/*****************************************************************************
 * $Header: /EmedTradeAsst/Client/His/FormImpHisPlan.cs.cs 1    07-5-25 15:52 yanbing $
 * $Author: yanbing $Revision: 1.0 $
 * $Date: 07-5-25 15:52 $
 * $History: FormImpHisPlan.cs $
 * 
 * *****************  Version 1  *****************
 * User: yanbing         Date:07-5-25   Time: 15:52
 * Updated in $/EmedTradeAsst/Client/His
 ********************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Client.BLL.His.EnterPrice;
using Emedchina.TradeAssistant.Client.Common;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Model.His;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Client.His;
using System.Data.OleDb;
using System.Collections;
using Emedchina.TradeAssistant.Client.DAL.His;
using DevExpress.XtraEditors;
namespace Emedchina.TradeAssistant.Client.His
{
    public partial class EntImpHisPlan : BaseForm
    {
        public List<string> LiItemId = new List<string>();
        DataSet ds = null;
        EnterpriseIDCompareBLL bll = EnterpriseIDCompareBLL.GetInstance();


        public EntImpHisPlan()
        {
            InitializeComponent();
            //HisConfig.Intance().Init();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    this.openFileDialog.Filter = "Excel�ļ�(*.xls)|*.xls|dbf�ļ�(*.dbf)|*.dbf|�ı��ļ�(*.txt)|*.txt|�����ļ� (*.*)|*.*";
            //    if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        if (this.openFileDialog.FileName == "")
            //        {
            //            EmedMessageBox.ShowWarning("��ѡ��ɹ��ƻ��ļ�·����");
            //        }
            //        else
            //        {
            //            this.txtFile.Text = this.openFileDialog.FileName;
            //            openFileDialog.InitialDirectory = System.Windows.Forms.Application.StartupPath;
            //            openFileDialog.RestoreDirectory = true;
            //            Cursor.Current = Cursors.AppStarting;
            //            string dbfile = this.openFileDialog.FileNames[0];
            //            this.ExcelToDS(dbfile);

            //        }
            //    }
            //}
            //catch (Exception exception1)
            //{
            //    return;
            //}
            //finally
            //{
            //    Cursor.Current = Cursors.Default;
            //    GC.Collect();
            //}


            string strCurrentDB = FileOperation.GetNodeValue(FileOperation.GetNodeObject(EmedFunc.GetLocalPersonCfgPath() + @"\HisEnterPriseMapList.xml", "Config/SourceDB"), "DBType");

            if (string.IsNullOrEmpty(strCurrentDB))
            {
                XtraMessageBox.Show("û�н����ֶ�ƥ�䣬�޷����룡", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //ComUtil.MsgBox("û�н����ֶ�ƥ�䣬�޷����룡");
                return;
            }
            //ѡ���������ļ�
            string str = "";

            if (strCurrentDB.CompareTo("EXCEL") == 0)
            {
                openFileDialog.Filter = "Excel�ĵ�(*.xls)|*.xls";
            }
            if (strCurrentDB.CompareTo("ACCESS") == 0)
            {
                openFileDialog.Filter = "MDB�ĵ�(*.mdb)|*.mdb";
            }

            //openFileDialog1.Filter = "DBF�ĵ�(*.dbf)|*.dbf|Excel�ĵ�(*.xls)|*.xls";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Title = "���ļ�";
            openFileDialog.InitialDirectory = System.Windows.Forms.Application.StartupPath;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FileName = "";
            openFileDialog.ShowDialog();
            try
            {
                str = openFileDialog.FileName;
                if (!string.IsNullOrEmpty(str))
                {
                    this.txtFile.Text = str;
                    ClientConfiguration.HisPath = str;
                    string sql=string.Empty;
                    if (strCurrentDB.CompareTo("EXCEL") == 0)
                    {
                        ClientConfiguration.ConnectionString = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + str + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1'";
                        sql = FileOperation.GetNodeObject(EmedFunc.GetLocalPersonCfgPath() + @"\HisEnterPriseMapList.xml", "Config/Sqls/Sql").InnerText;
                    }
                    if (strCurrentDB.CompareTo("ACCESS") == 0)
                    {
                        string password = SecretUtil.DeSecret(FileOperation.GetNodeValue(FileOperation.GetNodeObject(EmedFunc.GetLocalPersonCfgPath() + @"/HisEnterPriseMapList.xml", "Config/DestDB"), "Password"));
                        ClientConfiguration.ConnectionString = " Provider = Microsoft.Jet.OLEDB.4.0 ;Jet OLEDB:Database Password=" + password + "; Data Source = " + str + ";";
                        sql = FileOperation.GetNodeObject(EmedFunc.GetLocalPersonCfgPath() + @"\HisEnterPriseMapList.xml", "Config/ASqls/Sql").InnerText;
                    }
                    
                    
                    //ClientConfiguration.ConnectionString = ClientConfiguration.ConnectionString.Replace(ClientConfiguration.HisPath, str);                
                    ClientConfiguration.Save();

                 
                    DataTable dt = EnterpriseIDCompareDAO.GetInstance().GetEnterPrise(sql);
                    this.bindingSource.DataSource = null;
                    this.bindingSource.DataSource = dt;
                    this.lb_DgvCaptionText.Text = "HIS��ҵ���룺�� " + dt.DefaultView.Count + " ����¼";
                    //setErpSendMapData();
                }
            }
            catch (Exception)
            {
                this.bindingSource.DataSource = null;
                XtraMessageBox.Show("������Ч�������ļ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //ComUtil.MsgBox("������Ч�������ļ���");
            }
        }

        /// <summary>
        /// ��ȡExcel�ĵ�
        /// </summary>
        /// <param name="Path">�ļ�����</param>
        /// <returns>����һ�����ݼ�</returns>
        public DataSet ExcelToDS(string Path)
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "";
            OleDbDataAdapter myCommand = null;
            strExcel = "select * from [sheet1$] ";
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            ds = new DataSet();
            myCommand.Fill(ds, "table1");
            this.bindingSource.DataSource = ds.Tables[0];
            this.lb_DgvCaptionText.Text = "HIS��ҵ���룺�� " + ds.Tables[0].DefaultView.Count + " ����¼";

            //foreach (DataGridViewRow dr in this.dataGridView.Rows)
            //{
            //    dr.Cells["clmKey"].Value = false;
            //    dr.Selected = false;
            //    LiItemId.Clear();
            //}

            return ds;
        }
        


       
        private void btnImport_Click(object sender, EventArgs e)
        {
            SaveProductHis();
        }

      

       
     
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EntImpHisPlan_Load(object sender, EventArgs e)
        {
            //��HisConfig.xml��ȡ����
            //this.chkProductMap.Checked = HisConfig.Intance().IsUserSetMap && HisConfig.Intance().IsShowProductMap;
            //this.chkAll.Checked = HisConfig.Intance().IsUserSetMap && HisConfig.Intance().IsShowCorpMap;
           
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkAll.Checked)
            //{
            //    LiItemId.Clear();
            //    foreach (DataGridViewRow dr in this.dataGridView.Rows)
            //    {
            //        dr.Cells["clmKey"].Value = true;
            //        dr.Selected = true;
            //        string ItemId = dr.Cells["CODE"].Value.ToString();
            //        LiItemId.Add(ItemId);
            //    }
            //}
            //else
            //{
            //    foreach (DataGridViewRow dr in this.dataGridView.Rows)
            //    {
            //        dr.Cells["clmKey"].Value = false;
            //        dr.Selected = false;
            //        LiItemId.Clear();
            //    }
            //}
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 1 && e.RowIndex != -1)
            //{
            //    if ((bool)this.dataGridView.Rows[e.RowIndex].Cells["clmKey"].EditedFormattedValue == true)
            //    {
            //        string ItemId = this.dataGridView.Rows[e.RowIndex].Cells["CODE"].Value.ToString();
            //        LiItemId.Add(ItemId);
            //    }
            //    else if ((bool)this.dataGridView.Rows[e.RowIndex].Cells["clmKey"].EditedFormattedValue == false)
            //    {
            //        string ItemId = this.dataGridView.Rows[e.RowIndex].Cells["CODE"].Value.ToString();
            //        LiItemId.Remove(ItemId);
            //    }
            //}
        }


       
        #region �����Ʒ������Ϣ SaveProductHis
        /// <summary>
        /// �����Ʒ������Ϣ
        /// </summary>
        private void SaveProductHis()
        {
            //try
            //{
            //    ArrayList list1 = new ArrayList();
            //    for (int num1 = 0; num1 < this.dataGridView.RowCount; num1++)
            //    {
            //        DataGridViewRow row1 = this.dataGridView.Rows[num1];
            //        Emedchina.TradeAssistant.Model.User.LogedInUser usr = ClientSession.GetInstance().CurrentUser;

            //        string boolstr;
            //        if (row1.Cells[0].Value != null && row1.Cells[0].Value.ToString().ToLower() == "true")
            //            boolstr="True";
            //        else
            //            boolstr="False";


            //        string orgId = row1.Cells["ORG_ID"].Value.ToString();
            //        if (boolstr == "True" )//&& !string.IsNullOrEmpty(orgId)
            //        {
            //            if (bll.IsExistCode(row1.Cells["CODE"].Value.ToString(),usr.UserOrg.Reg_org_id.ToString()))
            //            {
            //                list1.Add(bll.UpdateHisEnterpriseMapSQL(row1, row1.Cells["CODE"].Value.ToString(), base.CurrentUserId, usr.UserOrg.Reg_org_id.ToString()));
            //            }
            //            else
            //            {
            //                list1.Add(bll.InsertHisEnterpriseMapSQL(row1, base.CurrentUserId, usr.UserOrg.Reg_org_id.ToString()));
            //            }
            //        }
            //    }
            //    if (list1.Count < 1)
            //    {
            //        return;
            //    }
            //    string[] textArray1 = new string[list1.Count];
            //    list1.CopyTo(textArray1);
            //    if (bll.HisOperation(textArray1))
            //    {
            //        //this.IsSave = true;
            //        EmedMessageBox.ShowInformation("����ɹ���");
            //    }
            //    else
            //    {
            //        EmedMessageBox.ShowInformation("����ʧ�ܣ�");
            //    }
            //}
            //catch (Exception exception1)
            //{
            //    EmedErrorLog.SaveLog("����ʧ��", exception1);
            //}

        }
        #endregion
       
    }
}