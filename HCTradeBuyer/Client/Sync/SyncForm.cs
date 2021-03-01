#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Header: /TradeAssistant1.2.root/TradeAssistant/TradeAssistant/Order/SyncForm.cs 27    06-10-31 16:54 Liangxy $ 
 * $Author: Liangxy $ <a href="mailto:sunhongliang@hotmail.com">�����(sunhl)</a>
 * $Revision: 27 $
 * $Date: 06-10-31 16:54 $
 * $History: SyncForm.cs $
 * 
 * *****************  Version 27  *****************
 * User: Liangxy      Date: 06-10-31   Time: 16:54
 * Updated in $/TradeAssistant1.2.root/TradeAssistant/TradeAssistant/Order
 * 
 * *****************  Version 26  *****************
 * User: Caojie       Date: 06-10-19   Time: 10:28
 * Updated in $/TradeAssistant1.2.root/TradeAssistant/TradeAssistant/Order
 * 
 * *****************  Version 25  *****************
 * User: Caojie       Date: 06-10-19   Time: 10:27
 * Updated in $/TradeAssistant1.2.root/TradeAssistant/TradeAssistant/Order
 * 
 * *****************  Version 24  *****************
 * User: Caojie       Date: 06-10-18   Time: 17:09
 * Updated in $/TradeAssistant1.2.root/TradeAssistant/TradeAssistant/Order
 * 
 * *****************  Version 23  *****************
 * User: Caojie       Date: 06-10-18   Time: 15:04
 * Updated in $/TradeAssistant1.2.root/TradeAssistant/TradeAssistant/Order
 * 
 * *****************  Version 22  *****************
 * User: Liangxy      Date: 06-09-25   Time: 10:41
 * Updated in $/TradeAssistant1.2.root/TradeAssistant/TradeAssistant/Order
 * 
 * *****************  Version 21  *****************
 * User: Liangxy      Date: 06-09-21   Time: 17:13
 * Updated in $/TradeAssistant1.2.root/TradeAssistant/TradeAssistant/Order
 * 
 * *****************  Version 20  *****************
 * User: Liangxy      Date: 06-09-20   Time: 17:09
 * Updated in $/TradeAssistant1.2.root/TradeAssistant/TradeAssistant/Order
 * 
 * *****************  Version 19  *****************
 * User: Caojie       Date: 06-09-18   Time: 14:10
 * Updated in $/TradeAssistant1.2.root/TradeAssistant/TradeAssistant/Order
 * 
 * *****************  Version 18  *****************
 * User: Caojie       Date: 06-09-18   Time: 13:15
 * Updated in $/TradeAssistant1.2.root/TradeAssistant/TradeAssistant/Order
 * 
 * *****************  Version 17  *****************
 * User: Caojie       Date: 06-09-15   Time: 17:39
 * Updated in $/TradeAssistant1.2.root/TradeAssistant/TradeAssistant/Order
 * 
 * *****************  Version 15  *****************
 * User: Sunhl        Date: 06-09-04   Time: 15:53
 * Updated in $/TradeAssistant.root/TradeAssistant/TradeAssistant/Order
 * 
 * *****************  Version 14  *****************
 * User: Sunhl        Date: 06-09-04   Time: 10:07
 * Updated in $/TradeAssistant.root/TradeAssistant/TradeAssistant/Order
 * �޸���������
 * 
 * *****************  Version 13  *****************
 * User: Panyj        Date: 06-07-28   Time: 14:30
 * Updated in $/TradeAssistant.root/TradeAssistant/TradeAssistant/Order
 * 
 * *****************  Version 12  *****************
 * User: Panyj        Date: 06-07-28   Time: 10:12
 * Updated in $/TradeAssistant.root/TradeAssistant/TradeAssistant/Order
 * 
 * *****************  Version 11  *****************
 * User: Shangfu      Date: 06-07-04   Time: 17:17
 * Updated in $/TradeAssistant.root/TradeAssistant/TradeAssistant/Order
 * 
 * *****************  Version 10  *****************
 * User: Shangfu      Date: 06-07-04   Time: 16:19
 * Updated in $/TradeAssistant.root/TradeAssistant/TradeAssistant/Order
 * 
 * *****************  Version 9  *****************
 * User: Liangxy      Date: 06-07-04   Time: 16:19
 * Updated in $/TradeAssistant.root/TradeAssistant/TradeAssistant/Order
 * 
 * *****************  Version 8  *****************
 * User: Tangsj       Date: 06-06-29   Time: 18:24
 * Updated in $/TradeAssistant.root/TradeAssistant/TradeAssistant/Order
 * 
 * *****************  Version 7  *****************
 * User: Liangxy      Date: 06-06-29   Time: 16:50
 * Updated in $/TradeAssistant.root/TradeAssistant/TradeAssistant/Order
 * 
 * *****************  Version 6  *****************
 * User: Sunhl        Date: 06-06-28   Time: 17:27
 * Updated in $/TradeAssistant.root/TradeAssistant/TradeAssistant/Order
 * ͬ����ɺ��Զ��رա�
 * 
 * *****************  Version 5  *****************
 * User: Sunhl        Date: 06-06-28   Time: 15:57
 * Updated in $/TradeAssistant.root/TradeAssistant/TradeAssistant/Order
 * 
 * *****************  Version 4  *****************
 * User: Sunhl        Date: 06-06-28   Time: 10:34
 * Updated in $/TradeAssistant.root/TradeAssistant/TradeAssistant/Order
 * 
 * *****************  Version 3  *****************
 * User: Sunhl        Date: 06-06-27   Time: 16:49
 * Updated in $/TradeAssistant.root/TradeAssistant/TradeAssistant/Order
 * 
 * *****************  Version 2  *****************
 * User: Sunhl        Date: 06-06-27   Time: 15:26
 * Updated in $/TradeAssistant.root/TradeAssistant/TradeAssistant/Order
 * 
 * *****************  Version 1  *****************
 * User: Sunhl        Date: 06-06-27   Time: 15:06
 * Created in $/TradeAssistant.root/TradeAssistant/TradeAssistant/Order
 ********************************************************************************/
#endregion

#region using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Client;

using Emedchina.TradeAssistant.Client.Common;
using Emedchina.TradeAssistant.Client.DAL.Sync;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Model.User;
using System.Xml;
using System.ServiceProcess;
#endregion

//8�µ��޸���DoSyncAync����,�����Increment��Sync����.���ڸı仺�����.
namespace Emedchina.TradeAssistant.Sync.Order
{
    /// <summary>
    /// ����ͬ������
    /// </summary>
    public partial class SyncForm : Form
    {
        private int progressNum = 0;
        private DateTime dateTime0, dateTime1;
        private static bool isStart = true;
        private bool flag;
        private bool compressFlg = true;
        public delegate void treeinvoke();
        private bool TimeContinue = true;
        private string Selected;            //��ͬ����Ŀ�Ƿ�ѡ��
        private string Pub_tablename;       //�ڹ���״̬����ʾ��ǰͬ����Ŀ����
        private string ReadFlag;            //�������־
        Boolean IsCvsSync;                  //�Ƿ�ʹ��cvs����ͬ��
        private int curr_rows;              //��ǰͬ����Ŀ�����µ�����
        private string curr_time;           //ÿ��ͬ����Ŀ��ʱ
        private string logFlag;
        private int Total_rows;             //����������
        private int Total_time;��           //����ʱ
        private int curr_row;               //��ǰͬ����Ŀ���ڵ���

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SyncForm"/> class.
        /// </summary>
        public SyncForm()
        {
            InitializeComponent();
        }
        public SyncForm(bool flg)
        {
            InitializeComponent();
            compressFlg = flg;
        }

        /// <summary>
        /// Handles the DoWork event of the SyncBackgroundWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        private void SyncBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            dateTime0 = DateTime.Now;
            BackgroundWorker worker = sender as BackgroundWorker;
            flag = DoSyncAync(worker, e);
            
        }

        //not used
        /// <summary>
        /// Handles the ProgressChanged event of the SyncBackgroundWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.ComponentModel.ProgressChangedEventArgs"/> instance containing the event data.</param>
        private void SyncBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.SyncProgressBar.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the SyncBackgroundWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void SyncBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!flag)
            {
                MessageBox.Show("���ؿ��ļ����𻵣������°�װ��", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            this.progressTimer.Enabled = false;
            this.progressNum = 100;
            this.SyncProgressBar.Value = 100;
            //ѹ�����ݿ�����ǰ
            /*
            if (flag)
            {
                if (ClientSession.GetInstance()["CompressFlg"] == null || (bool)ClientSession.GetInstance()["CompressFlg"])
                {
                    if (MessageBox.Show("�Ƿ�ѹ�����ݿ⣿", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        try
                        {
                            FileControl.CompactAccessDB(ClientConfiguration.TmpDBFile);
                            ClientSession.GetInstance()["CompressFlg"] = false;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("�˲���ϵͳ��֧��ѹ�����ݿ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }
                    }
                }
            }
             * */

            //��ť
            WorkDoneStatus();
            //this.Close();
            //MessageBox.Show(string.Format("{0} tables.",e.Result));
        }

        /// <summary>
        /// Does the sync aync.
        /// ͨ������CacheControl�����û���ķ���ʵ�֡�����Ļ����ȡ��CacheControl��ά����
        /// </summary>
        /// <param name="worker">The worker.</param>
        /// <param name="e">The <see cref="T:System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        /// <returns>�����е�Table����</returns>
        /// <remarks>û�п���ֻ�ڱ������л����������������µ����,û������</remarks>
        private bool DoSyncAync(BackgroundWorker worker, DoWorkEventArgs e)
        {
            return Sync();

            //return ClientCache.CachedDS.Tables.Count;
        }

        //����ģ����ļ�,������ʱ�ļ�
        public static void CopyDB(string TemplateFileName, string TempFileName)
        {
            try
            {
                //ServiceController[] sl = ServiceController.GetServices();
                //string[] sln = new string[sl.Length];
                //int i = 0;
                //foreach (ServiceController sc in sl)
                //{
                //    sln[i] = sc.ServiceName;
                //    i++;
                //}
                //ServiceController serviceController1 = new ServiceController();

                //serviceController1.ServiceName = "MSSQL$SQLEXPRESS";
                //serviceController1.MachineName = ".";

                //if (serviceController1.Status == ServiceControllerStatus.Running)
                //{
                //    serviceController1.Stop();
                //}

                //�����ʱ���ļ����ڣ���ɾ��
                if (File.Exists(TempFileName))
                {
                    System.IO.File.Delete(TempFileName);
                }
                System.Threading.Thread.Sleep(2000);
                System.IO.File.Copy(TemplateFileName, TempFileName,true);
                System.IO.File.Copy(TemplateFileName.Replace(".mdf", "_log.LDF"), TempFileName.Replace(".mdf", "_log.LDF"), true);
                //ClientSyncDataDAO syncDao = ClientSyncDataDAO.GetInstance("ClientTempDB");
                //syncDao.CopyDB(TemplateFileName, TempFileName);
                //syncDao.CloseConntion();
                //System.Threading.Thread.Sleep(1000);

                //if (serviceController1.Status == ServiceControllerStatus.Stopped)
                //{
                //    serviceController1.Start();
                //}
                try
                {
                    //FileControl.CompactAccessDB(ClientConfiguration.LocalDBFile);
                    //ClientSession.GetInstance()["CompressFlg"] = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("�˲���ϵͳ��֧��ѹ�����ݿ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region ͬ������ʱ����
        /// <summary>
        /// ����״̬
        /// </summary>
        private void UpdateStart()
        {
            Selected = listView1.Items[0].StateImageIndex.ToString();
            if (Selected.Equals("1"))
            {
                listView1.Items[0].Selected = true;
                msgLabel.Text = "�����ϴ���������......";
                listView1.Items[0].ImageIndex = 1;
                listView1.EnsureVisible(0);
                TimeContinue = true;
            }
            else
            {
                TimeContinue = false;
            }
        }

        /// <summary>
        /// ͬ��ÿ��ǰʱ������ʾ
        /// </summary>
        private void UpdatelistView1()
        {
            Pub_tablename = listView1.Items[curr_row].SubItems[4].Text.ToString();
            ReadFlag = listView1.Items[curr_row].SubItems[6].Text.ToString();
            logFlag = listView1.Items[curr_row].SubItems[5].Text.ToString();
            Selected = listView1.Items[curr_row].StateImageIndex.ToString();
            IsCvsSync = csvFlag.Checked;  //�Ƿ�ʹ��CVSͬ������
            if (Selected == "1")
            {
                listView1.Items[curr_row].Selected = true;
                msgLabel.Text = "����" + listView1.Items[curr_row].SubItems[1].Text.ToString() + "......";
                listView1.Items[curr_row].ImageIndex = 1;
                listView1.EnsureVisible(curr_row);
            }
        }

        /// <summary>
        /// ͬ��ÿ���ʱ������ʾ
        /// </summary>
        private void UpdatelistView2()
        {
            listView1.Items[curr_row].SubItems[2].Text = curr_rows.ToString();
            listView1.Items[curr_row].SubItems[3].Text = curr_time;
            listView1.Items[curr_row].Selected = false;
            listView1.Items[curr_row].ImageIndex = 0;
        }

        /// <summary>
        /// �ϴ����½���
        /// </summary>
        private void UpdateEnd()
        {
            listView1.Items[0].SubItems[2].Text = "0";
            listView1.Items[0].SubItems[3].Text = curr_time;
            listView1.Items[0].Selected = false;
            listView1.Items[0].ImageIndex = 0;
            TimeContinue = true;
        }

        #endregion

        #region ͬ��
        /// <summary>
        /// Syncs this instance.
        /// </summary>
        private bool Sync()
        {

            bool returnvalue = true;
            string filePath;
            //FileControl.CompactAccessDB(ClientConfiguration.TmpDBFile);

            //ɾ���ļ�¼��
            int rows = 0;
            //�ϴ����ݲ���---------------------------------------------------------
            listView1.Invoke(new treeinvoke(UpdateStart));
            if (this.chkUpload.Checked && chkUpload.Enabled)
            {
                List<string> InvalidList = null;

                if (EmedFunc.GetLocalPersonCfgPath().EndsWith("\\"))
                    filePath = EmedFunc.GetLocalPersonCfgPath() + "db\\TradeAssistant.mdf";
                else
                    filePath = EmedFunc.GetLocalPersonCfgPath() + "\\db\\TradeAssistant.mdf";
                if (File.Exists(filePath))
                {
                    //������ �°��ս������ֳ��򷽷� 2007-04-06
                    bool flag = new ClientUploadBLL().UploadData(false,out InvalidList, out rows);
                    if (!flag)
                    {
                        MessageBox.Show("���������ϴ�ʧ�ܣ�������", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        rows = 0;
                        return false;
                    }
                }
            }
            curr_rows = rows;
            listView1.Invoke(new treeinvoke(UpdatelistView2));
            //---------------------------------------------------------------------
            DateTime Time_Star, Time_End;
            //��ȡ��ID
            //string buyerId = ClientSession.GetInstance().CurrentUser.UserOrg.Reg_org_id;
            //��ȡ�û�ID
            //string userId = ClientSession.GetInstance().CurrentUser.UserInfo.Id;

            //��ȡ��ǰ�û�����
            LogedInUser CurrentUser = ClientSession.GetInstance().CurrentUser;

            //����ͬ��dao����������ͬ��������ֻ����һ�����ݿ�����
            ClientSyncDataDAO syncDao = ClientSyncDataDAO.GetInstance("ClientTempDB");
            //if (!this.rbAdd.Checked && csvFlag.Checked)
                //syncDao.OpenADShell();
            for (int i = 1; i < listView1.Items.Count; i++)
            {
                //timer_num = 0;
                curr_row = i;
                progressNum = 0;
                Time_Star = DateTime.Now;
                listView1.Invoke(new treeinvoke(UpdatelistView1));

                curr_rows = 0;
                try
                {
                    if (Selected == "1" && i != listView1.Items.Count - 1)
                    {
                        if (this.rbAdd.Checked)
                        {
                            //����ͬ��
                            curr_rows = syncDao.AllIncrementOneSync(CurrentUser, Pub_tablename, logFlag);
                        }
                        else
                        {
                            //ȫͬ��
                            if (csvFlag.Checked)
                            {
                                //����CVS��ʽ
                                curr_rows = syncDao.AllSyncFromCsv(CurrentUser, Pub_tablename);
                            }
                            else
                            {
                                curr_rows = syncDao.AllSyncOneData(CurrentUser, Pub_tablename);
                            }
                        }
                    }

                    if (i == listView1.Items.Count - 1)
                    {
                        syncDao.OpenADShell();
                        syncDao.CompressDB(ClientConfiguration.TmpDBFile);
                        syncDao.CloseADShell();
                    }
                }
                catch (Exception ex)
                {
                    returnvalue = false;
                }

                Time_End = DateTime.Now;
                TimeSpan timeSpan = Time_End.Subtract(Time_Star);
                int seconds = Convert.ToInt16(timeSpan.TotalSeconds);
                curr_time = new ClientSyncBLL().SecondToTimeStr(seconds);
                listView1.Invoke(new treeinvoke(UpdatelistView2));
                if (curr_rows != -1)
                    Total_rows = Total_rows + curr_rows;
                Total_time = Total_time + seconds;
            }
            //if (!this.rbAdd.Checked && csvFlag.Checked)
                //syncDao.CloseADShell();
            
            //ͬ����ɣ��ر����ݿ�����
            syncDao.CloseConntion();

            if (Total_rows != 0)
            {
                try
                {
                    //FileControl.CompactAccessDB(ClientConfiguration.TmpDBFile);
                    CopyDB(ClientConfiguration.TmpDBFile, ClientConfiguration.LocalDBFile);
                }
                catch (Exception ex)
                {
                    if (MessageBox.Show("����ѹ�����ļ��쳣��������̿ռ䣬�����Ƿ��˳���", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return false;
                    }
                }
            }
            
            return returnvalue;
        }
        #endregion

        /// <summary>
        /// In the work status.
        /// ���ư�ť�����״̬        
        /// </summary>
        private void InWorkingStatus()
        {
            this.UseWaitCursor = true;
            this.okButton.Enabled = false;
            this.Bt_exit.Enabled = false;
        }

        /// <summary>
        /// Works the done status.
        /// </summary>
        private void WorkDoneStatus()
        {
            this.UseWaitCursor = false;
            this.okButton.Enabled = true;
            this.Bt_exit.Enabled = true;
            this.lbrec.Text = "��ͬ�� " + Total_rows.ToString() + " ����¼����ʱ " + this.lblTime.Text;
            this.Bt_exit.Text = "���";
            this.okButton.Enabled = false;
            this.msgLabel.Text = "������Ŀͬ���ɹ���";
            this.lbrec.Visible = true;
            this.lblTime.Visible = false;
        }

        /// <summary>
        /// Handles the Tick event of the progressTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void progressTimer_Tick(object sender, EventArgs e)
        {
            if (progressNum++ < 100)
                this.SyncProgressBar.Value = progressNum;
            else
            {
                progressNum = 1;
                this.SyncProgressBar.Value = progressNum;
            }
            dateTime1 = DateTime.Now;
            TimeSpan timeSpan = dateTime1 - dateTime0;
            this.lblTime.Text = Math.Round(timeSpan.TotalSeconds, 2).ToString() + "��";
        }

        /// <summary>
        /// Starts the sycn.
        /// </summary>
        private void StartSycn()
        {
            InWorkingStatus();
            SyncBackgroundWorker.RunWorkerAsync();
            this.progressTimer.Enabled = true;
        }

        /// <summary>
        /// Handles the Click event of the okButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void okButton_Click(object sender, EventArgs e)
        {
            //this.progressTimer.Enabled = false;
            //this.progressTimer.Dispose();
            //this.Close();
            if (!this.chkUpload.Checked)
                if (MessageBox.Show("�˲��������ϴ���������,�Ƿ������", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
            this.lblTime.Visible = true;
            this.msgLabel.Visible = true;
            this.SyncProgressBar.Visible = true;
            StartSycn();
        }

        /// <summary>
        /// Handles the Load event of the SyncForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void SyncForm_Load(object sender, EventArgs e)
        {
            //StartSycn();
            InitializeListView();
            listView1.CheckBoxes = false;
            this.lblTime.Visible = false;
            this.msgLabel.Visible = false;
            this.SyncProgressBar.Visible = false;
            string filePath;
            //�ж������ļ��Ƿ���ڣ������ڣ�ֻ��ȫͬ��  2007-6-28
            if (EmedFunc.GetLocalPersonCfgPath().EndsWith("\\"))
                filePath = EmedFunc.GetLocalPersonCfgPath() + "db\\TradeAssistant.mdf";
            else
                filePath = EmedFunc.GetLocalPersonCfgPath() + "\\db\\TradeAssistant.mdf";
            if (!File.Exists(filePath))
            {
                this.rbAdd.Enabled = false;
                this.chkUpload.Enabled = false;
                this.csvFlag.Checked = false;
                this.rbAll.Checked = true;
            }
            //add by yanbing csv��ʽ�������ö�ȡ 2007-6-28
            string XmlPath = ClientConfiguration.LocalPersonConfigPath + @"\UserConfig.xml";
            if (File.Exists(XmlPath))
            {
                XmlDocument document1 = new XmlDocument();
                document1.Load(XmlPath);
                XmlElement element1 = (XmlElement)document1.SelectSingleNode("UserConfig/ConnectLogic");
                this.csvFlag.Checked = element1.GetAttribute("IfUseCSVMethod").ToLower() == "true";
            }
            //end add
        }

        #region ��ʼ����ʾ�б�
        /// <summary>
        /// ��ʼListView
        /// </summary>
        private void InitializeListView()
        {
            string Parameter, TableName, TableDesc, SyncType, readFlag, logFlag;
            listView1.SmallImageList = imageList1;

            listView1.Columns.Add("", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("ͬ����Ŀ", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("������", -2, HorizontalAlignment.Right);
            listView1.Columns.Add("��ʱ", -2, HorizontalAlignment.Right);
            listView1.Columns.Add("����", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("log", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("read", -2, HorizontalAlignment.Left);

            listView1.Columns[0].Width = 50;
            listView1.Columns[1].Width = 252;
            listView1.Columns[2].Width = 68;
            listView1.Columns[3].Width = 0;
            listView1.Columns[4].Width = 0;
            listView1.Columns[5].Width = 0;
            listView1.Columns[6].Width = 0;


            ListViewItem item = new ListViewItem("", 0);
            item.SubItems.Add("�ϴ���������");
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.SubItems.Add("");

            listView1.Items.AddRange(new ListViewItem[] { item });
            listView1.Items[0].ImageIndex = 0;
            listView1.Items[0].StateImageIndex = 1;
            //listView1.Items[0].BackColor = Color.Gray;


            //ArrayList results = new ClientSyncBLL().GetTableParameter();
            ArrayList results = ClientSyncBLL.GetTableParameter();

            for (int i = 0; i < results.Count; i++)
            {

                Parameter = (string)results[i];
                string[] ParameterField = Parameter.Split(new char[] { ',' });
                TableName = ParameterField[0];
                TableDesc = ParameterField[1];
                SyncType = ParameterField[2];
                logFlag = ParameterField[3];
                readFlag = ParameterField[4];

                ListViewItem item1 = new ListViewItem("", 0);
                item1.SubItems.Add(SyncType + TableDesc);
                item1.SubItems.Add("");
                item1.SubItems.Add("");
                item1.SubItems.Add(TableName);
                item1.SubItems.Add(logFlag);
                item1.SubItems.Add(readFlag);

                listView1.Items.AddRange(new ListViewItem[] { item1 });

                //start modify by gaoyuan 2007.1.18
                //if (ClientConfiguration.OnlineSync.Equals("0"))
                if (true)
                {
                    listView1.Items[i + 1].ImageIndex = 0;
                    listView1.Items[i + 1].StateImageIndex = 1;
                }
                else
                {
                    listView1.Items[i].ImageIndex = 0;
                    listView1.Items[i].StateImageIndex = 1;
                }
                //end modify by gaoyuan 2007.1.18
            }

            ListViewItem item2 = new ListViewItem("", 0);
            item2.SubItems.Add(" ѹ����ʱ���滻���ؿ�");
            item2.SubItems.Add("");
            item2.SubItems.Add("");
            item2.SubItems.Add("");
            item2.SubItems.Add("");
            item2.SubItems.Add("");

            listView1.Items.AddRange(new ListViewItem[] { item2 });
            listView1.Items[listView1.Items.Count - 1].ImageIndex = 0;
            listView1.Items[listView1.Items.Count - 1].StateImageIndex = 1;
        }
        #endregion

        /// <summary>
        /// �Ƿ�ʱ
        /// </summary>
        /// <returns></returns>
        private bool notTimeOut()
        {

            bool syncLimit = Emedchina.TradeAssistant.Client.Properties.Settings.Default.SyncLimit;

            if (!syncLimit) //ͬ���Ƿ��ܵ�ʱ������? ȱʡ��false
            {
                return true;
            }
            dateTime1 = DateTime.Now;
            TimeSpan timeSpan = dateTime1 - dateTime0;
            if (timeSpan.TotalSeconds > 180)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        /// <summary>
        /// Determines whether this instance is increment.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if this instance is increment; otherwise, <c>false</c>.
        /// </returns>
        private bool IsIncrement
        {
            get { return "1".Equals(ClientConfiguration.SyncPolicy); }
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbAll.Checked)
            {
                //�����ã����ͬ����ʽ���ܽܡ�2007-8-29
                //this.csvFlag.Enabled = true;
            }
            else
            {
                this.csvFlag.Enabled = false;
            }
        }

        private void Bt_exit_Click(object sender, EventArgs e)
        {
            //if (Total_rows != 0)
            //{
            //    try
            //    {
            //        //FileControl.CompactAccessDB(ClientConfiguration.TmpDBFile);
            //        CopyDB(ClientConfiguration.TmpDBFile, ClientConfiguration.LocalDBFile);
            //    }
            //    catch (Exception ex)
            //    {
            //        if (MessageBox.Show("����ѹ�����ļ��쳣��������̿ռ䣬�����Ƿ��˳��������֣�", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //        {
            //            return;
            //        }
            //    }
            //}
            if (!File.Exists(ClientConfiguration.LocalDBFile))
                CopyDB(ClientConfiguration.TmpDBFile, ClientConfiguration.LocalDBFile);

            this.Close();
        }
        //add by yanbing 2007-06-28 csv��ʽ��������
        private void csvFlag_CheckedChanged(object sender, EventArgs e)
        {
            string XmlPath = ClientConfiguration.LocalPersonConfigPath + @"\UserConfig.xml";
            if (File.Exists(XmlPath))
            {
                XmlDocument document1 = new XmlDocument();
                document1.Load(XmlPath);
                XmlElement element1 = (XmlElement)document1.SelectSingleNode("UserConfig/ConnectLogic");

                element1.SetAttribute("IfUseCSVMethod", this.csvFlag.Checked ? "True" : "False");
                document1.Save(XmlPath);
            }
        }
        //end add
    }
}