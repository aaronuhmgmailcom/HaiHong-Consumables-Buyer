using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Emedchina.TradeAsst.EmedHisCommonLibrary;
using System.IO;
using Emedchina.Commons;
using DevExpress.XtraEditors;

namespace Emedchina.TradeAsst.EmedHisHelper
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        private CfgList _cfgList;
        private bool _isExistSlnCfg;
        private ArrayList _listIndex;
        private IContainer components;
        private string localPersonCfgPath;

        public FormMain()
        {
            //InitializeComponent();
            this.components = null;
            this._cfgList = new CfgList();
            this._listIndex = new ArrayList();
            this._isExistSlnCfg = false;
            this.InitializeComponent();
            localPersonCfgPath = EmedFunc.GetLocalPersonCfgPath();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDBConfig frm = new FormDBConfig();
            frm.ShowDialog();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //this.gridView1.Appearance.EvenRow.BackColor = Color.FromArgb(int.Parse(ClientConfiguration.EvenColor));
            //this.gridView1.Appearance.OddRow.BackColor = Color.FromArgb(int.Parse(ClientConfiguration.OddColor));
            this.InitCfgList();
        }

        /// <summary>
        /// 初始化HIS接口项目列表
        /// </summary>
        private void InitCfgList()
        {
            this.lvConfig.DataSource = null;
            //this.lvConfig.Items.Clear();
            ArrayList list1 = new ArrayList();
            this._isExistSlnCfg = this._cfgList.ReadConfig();
            if (this._isExistSlnCfg)
            {
                for (int num1 = 0; num1 < this._cfgList.Cfgs.Length; num1++)
                {

                    if (this._cfgList.Cfgs[num1] != null)
                    {
                        string text1 = Application.StartupPath + @"\" + this._cfgList.Cfgs[num1].DllName;
                        //MessageBox.Show(localPersonCfgPath + @"\" + this._cfgList.Cfgs[num1].CfgName);
                        string text2 = localPersonCfgPath + @"\" + this._cfgList.Cfgs[num1].CfgName;
                        string text3 = Application.StartupPath + @"\" + this._cfgList.Cfgs[num1].CfgTemplet;
                        if (File.Exists(text2))
                        {
                            ListViewItem item1 = new ListViewItem(this._cfgList.Cfgs[num1].Name);
                            item1.Tag = localPersonCfgPath + @"\" + this._cfgList.Cfgs[num1].CfgName;
                            item1.SubItems.Add(this._cfgList.Cfgs[num1].CfgName);
                            item1.SubItems.Add(this._cfgList.Cfgs[num1].TypeCn);
                            list1.Add(item1);
                            this._listIndex.Add(num1.ToString());
                            if (!File.Exists(text2) && File.Exists(text3))
                            {
                                File.Copy(text3, text2);
                            }
                        }
                    }
                }
            }
            else
            {
                string text4 = Application.StartupPath + @"\HisPortalReceiveLib.dll";
                if (File.Exists(text4))
                {
                    ListViewItem item2 = new ListViewItem("导出到货项目");
                    item2.Tag = EmedFunc.GetLocalPersonCfgPath() + @"\HisOrderReceive.xml";
                    item2.SubItems.Add("HisOrderReceive.xml");
                    item2.SubItems.Add("导出");
                    list1.Add(item2);
                    if (!File.Exists(EmedFunc.GetLocalPersonCfgPath() + @"\HisOrderReceive.xml") && File.Exists(Application.StartupPath + @"\ReceivePortal.data"))
                    {
                        File.Copy(Application.StartupPath + @"\ReceivePortal.data", EmedFunc.GetLocalPersonCfgPath() + @"\HisOrderReceive.xml");
                    }
                }
                string text5 = Application.StartupPath + @"\HisPortalEnterLib.dll";
                if (File.Exists(text5))
                {
                    ListViewItem item3 = new ListViewItem("导出入库项目");
                    item3.Tag = Application.StartupPath + @"\EnterPortal.cfg";
                    item3.SubItems.Add("EnterPortal.cfg");
                    item3.SubItems.Add("导出");
                    list1.Add(item3);
                    if (!File.Exists(Application.StartupPath + @"\EnterPortal.cfg") && File.Exists(Application.StartupPath + @"\EnterPortal.data"))
                    {
                        File.Copy(Application.StartupPath + @"\EnterPortal.data", Application.StartupPath + @"\EnterPortal.cfg");
                    }
                }
                string text6 = Application.StartupPath + @"\HisPortalPurchaseLib.dll";
                if (File.Exists(text6))
                {
                    ListViewItem item4 = new ListViewItem("导入采购计划项目");
                    item4.Tag = EmedFunc.GetLocalPersonCfgPath() + @"\HisPurchase.xml";
                    item4.SubItems.Add("HisPurchase.xml");
                    item4.SubItems.Add("导入");
                    list1.Add(item4);
                    if (!File.Exists(EmedFunc.GetLocalPersonCfgPath() + @"\HisPurchase.xml") && File.Exists(Application.StartupPath + @"\PurchasePortal.data"))
                    {
                        File.Copy(Application.StartupPath + @"\PurchasePortal.data", EmedFunc.GetLocalPersonCfgPath() + @"\HisPurchase.xml");
                    }
                }
                string text7 = Application.StartupPath + @"\HisPortalStockLib.dll";
                if (File.Exists(text7))
                {
                    ListViewItem item5 = new ListViewItem("导入库存项目");
                    item5.Tag = Application.StartupPath + @"\StockPortal.cfg";
                    item5.SubItems.Add("StockPortal.cfg");
                    item5.SubItems.Add("导入");
                    list1.Add(item5);
                    if (!File.Exists(Application.StartupPath + @"\StockPortal.cfg") && File.Exists(Application.StartupPath + @"\StockPortal.data"))
                    {
                        File.Copy(Application.StartupPath + @"\StockPortal.data", Application.StartupPath + @"\StockPortal.cfg");
                    }
                }
            }
            string text8 = Application.StartupPath + @"\ErpPortalStockLib.dll";
            if (File.Exists(text8))
            {
                ListViewItem item6 = new ListViewItem("导入物流系统库存数据");
                item6.Tag = Application.StartupPath + @"\ErpStockPortal.cfg";
                item6.SubItems.Add("ErpStockPortal.cfg");
                item6.SubItems.Add("导入");
                list1.Add(item6);
            }
            string text9 = Application.StartupPath + @"\ErpPortalStoreOutLib.dll";
            if (File.Exists(text9))
            {
                ListViewItem item7 = new ListViewItem("导入物流系统出库数据");
                item7.Tag = Application.StartupPath + @"\ErpStoreOutPortal.cfg";
                item7.SubItems.Add("ErpStoreOutPortal.cfg");
                item7.SubItems.Add("导入");
                list1.Add(item7);
            }
            string text10 = Application.StartupPath + @"\ErpPortalMedicalLib.dll";
            if (File.Exists(text10))
            {
                ListViewItem item8 = new ListViewItem("导入物流系统药品字典数据");
                item8.Tag = Application.StartupPath + @"\ErpMedicalPortal.cfg";
                item8.SubItems.Add("ErpMedicalPortal.cfg");
                item8.SubItems.Add("导入");
                list1.Add(item8);
            }
            ListViewItem[] itemArray1 = new ListViewItem[list1.Count];
            list1.CopyTo(itemArray1);
            
            //this.lvConfig.Items.AddRange(itemArray1);


            //新加实验代码
            DataTable dt = new DataTable();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns[0].ColumnName = "name";
            dt.Columns[1].ColumnName = "item";
            dt.Columns[2].ColumnName = "detail";
            dt.Columns[3].ColumnName = "Tag";

            ListViewItem Parameter;
            DataRow item;
            for (int i = 0; i < itemArray1.Length; i++)
            {

                Parameter = itemArray1[i];
                item = dt.NewRow();

                item[0] = Parameter.SubItems[0].Text.ToString();
                item[1] = Parameter.SubItems[1].Text.ToString();
                item[2] = Parameter.SubItems[2].Text.ToString();
                item[3] = Parameter.Tag.ToString();
                dt.Rows.Add(item);
            }
            lvConfig.DataSource = dt.DefaultView;

            //结束
        }

        private void lvConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                if (dr == null)
                {
                    return;
                }
                Cursor.Current = Cursors.AppStarting;
                    if (!File.Exists(dr["Tag"].ToString()))
                    {
                        XtraMessageBox.Show("配置文件" + dr["Tag"].ToString() + "不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Config.Intance().InitCfgData(dr["Tag"].ToString());
                        if (this._isExistSlnCfg)
                        {
                            if (gridView1.FocusedRowHandle < this._listIndex.Count)
                            {
                                int num1 = Convert.ToInt32(this._listIndex[gridView1.FocusedRowHandle].ToString());
                                Config.Intance().CurrentCfgType = this._cfgList.Cfgs[num1].Type;
                                Config.Intance().CurrentFoxproTemplet = this._cfgList.Cfgs[num1].FoxTemplet;
                                //Config.Intance().CurrentMDBTemplet = this._cfgList.Cfgs[num1].MDBTemplet;
                                //Config.Intance().CurrentDBName = this._cfgList.Cfgs[num1].DBName;
                                Config.Intance().CurrentFoxproDetailTemplet = this._cfgList.Cfgs[num1].FoxDetailTemplet;
                                Config.Intance().CurrentTxtTemplet = this._cfgList.Cfgs[num1].TxtTemplet;
                                Config.Intance().CurrentExcelTemplet = this._cfgList.Cfgs[num1].ExcelTemplet;
                                Config.Intance().IsMulti = this._cfgList.Cfgs[num1].IsMulti;
                            }
                        }
                        else
                        {
                            //start modify by gaoyuan 20070417 由于发布时将数据库文件以数据文件的类型发布，故修改文件路径
                            if (dr["name"].ToString().Trim() == "导出到货项目")
                            {
                                Config.Intance().CurrentCfgType = "0";
                                //Config.Intance().CurrentFoxproTemplet = Application.StartupPath + @"\SendReceive.dbf";
                                Config.Intance().CurrentFoxproTemplet = localPersonCfgPath + @"\SendReceive.dbf";
                                Config.Intance().CurrentFoxproDetailTemplet = "";
                                //Config.Intance().CurrentTxtTemplet = Application.StartupPath + @"\SendReceive.txt";
                                Config.Intance().CurrentTxtTemplet = localPersonCfgPath + @"\SendReceive.txt";
                                //Config.Intance().CurrentExcelTemplet = Application.StartupPath + @"\SendReceive.xls";
                                Config.Intance().CurrentExcelTemplet = localPersonCfgPath + @"\SendReceive.xls";
                            }
                            if (dr["name"].ToString().Trim() == "导出入库项目")
                            {
                                Config.Intance().CurrentCfgType = "0";
                                //Config.Intance().CurrentFoxproTemplet = Application.StartupPath + @"\SendEnter.dbf";
                                Config.Intance().CurrentFoxproTemplet = localPersonCfgPath + @"\SendEnter.dbf";
                                //Config.Intance().CurrentFoxproDetailTemplet = Application.StartupPath + @"\SendEnterDetail.dbf";
                                Config.Intance().CurrentFoxproDetailTemplet = localPersonCfgPath + @"\SendEnterDetail.dbf";
                                Config.Intance().CurrentTxtTemplet = "";
                                //Config.Intance().CurrentExcelTemplet = Application.StartupPath + @"\SendEnter.xls";
                                Config.Intance().CurrentExcelTemplet = localPersonCfgPath + @"\SendEnter.xls";
                            }
                            if (dr["name"].ToString().Trim() == "导入采购计划项目")
                            {
                                Config.Intance().CurrentCfgType = "1";
                                //Config.Intance().CurrentFoxproTemplet = Application.StartupPath + @"\GetPurchase.dbf";
                                Config.Intance().CurrentFoxproTemplet = localPersonCfgPath + @"\GetPurchase.dbf";
                                Config.Intance().CurrentFoxproDetailTemplet = "";
                                //Config.Intance().CurrentTxtTemplet = Application.StartupPath + @"\GetPurchase.txt";
                                Config.Intance().CurrentTxtTemplet = localPersonCfgPath + @"\GetPurchase.txt";
                                //Config.Intance().CurrentExcelTemplet = Application.StartupPath + @"\GetPurchase.xls";
                                Config.Intance().CurrentExcelTemplet = localPersonCfgPath + @"\GetPurchase.xls";
                            }
                            if (dr["name"].ToString().Trim() == "导入库存项目")
                            {
                                Config.Intance().CurrentCfgType = "1";
                                Config.Intance().CurrentFoxproTemplet = "";
                                Config.Intance().CurrentFoxproDetailTemplet = "";
                                Config.Intance().CurrentTxtTemplet = "";
                                Config.Intance().CurrentExcelTemplet = "";
                            }
                            //end modify by gaoyuan 20070417 由于发布时将数据库文件以数据文件的类型发布，故修改文件路径
                            Config.Intance().IsMulti = false;
                        }
                        Config.Intance().CurrentCfgFile = dr["Tag"].ToString();
                        Cursor.Current = Cursors.Default;
                    }
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("刷新项目选项", exception1);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                if (dr == null)
                {
                    return;
                }
                Cursor.Current = Cursors.AppStarting;
                if (!File.Exists(dr["Tag"].ToString()))
                {
                    XtraMessageBox.Show("配置文件" + dr["Tag"].ToString() + "不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Config.Intance().InitCfgData(dr["Tag"].ToString());
                    if (this._isExistSlnCfg)
                    {
                        if (gridView1.FocusedRowHandle < this._listIndex.Count)
                        {
                            int num1 = Convert.ToInt32(this._listIndex[gridView1.FocusedRowHandle].ToString());
                            Config.Intance().CurrentCfgType = this._cfgList.Cfgs[num1].Type;
                            Config.Intance().CurrentFoxproTemplet = this._cfgList.Cfgs[num1].FoxTemplet;
                            //Config.Intance().CurrentMDBTemplet = this._cfgList.Cfgs[num1].MDBTemplet;
                            //Config.Intance().CurrentDBName = this._cfgList.Cfgs[num1].DBName;
                            Config.Intance().CurrentFoxproDetailTemplet = this._cfgList.Cfgs[num1].FoxDetailTemplet;
                            Config.Intance().CurrentTxtTemplet = this._cfgList.Cfgs[num1].TxtTemplet;
                            Config.Intance().CurrentExcelTemplet = this._cfgList.Cfgs[num1].ExcelTemplet;
                            Config.Intance().IsMulti = this._cfgList.Cfgs[num1].IsMulti;
                        }
                    }
                    else
                    {
                        //start modify by gaoyuan 20070417 由于发布时将数据库文件以数据文件的类型发布，故修改文件路径
                        if (dr["name"].ToString().Trim() == "导出到货项目")
                        {
                            Config.Intance().CurrentCfgType = "0";
                            //Config.Intance().CurrentFoxproTemplet = Application.StartupPath + @"\SendReceive.dbf";
                            Config.Intance().CurrentFoxproTemplet = localPersonCfgPath + @"\SendReceive.dbf";
                            Config.Intance().CurrentFoxproDetailTemplet = "";
                            //Config.Intance().CurrentTxtTemplet = Application.StartupPath + @"\SendReceive.txt";
                            Config.Intance().CurrentTxtTemplet = localPersonCfgPath + @"\SendReceive.txt";
                            //Config.Intance().CurrentExcelTemplet = Application.StartupPath + @"\SendReceive.xls";
                            Config.Intance().CurrentExcelTemplet = localPersonCfgPath + @"\SendReceive.xls";
                        }
                        if (dr["name"].ToString().Trim() == "导出入库项目")
                        {
                            Config.Intance().CurrentCfgType = "0";
                            //Config.Intance().CurrentFoxproTemplet = Application.StartupPath + @"\SendEnter.dbf";
                            Config.Intance().CurrentFoxproTemplet = localPersonCfgPath + @"\SendEnter.dbf";
                            //Config.Intance().CurrentFoxproDetailTemplet = Application.StartupPath + @"\SendEnterDetail.dbf";
                            Config.Intance().CurrentFoxproDetailTemplet = localPersonCfgPath + @"\SendEnterDetail.dbf";
                            Config.Intance().CurrentTxtTemplet = "";
                            //Config.Intance().CurrentExcelTemplet = Application.StartupPath + @"\SendEnter.xls";
                            Config.Intance().CurrentExcelTemplet = localPersonCfgPath + @"\SendEnter.xls";
                        }
                        if (dr["name"].ToString().Trim() == "导入采购计划项目")
                        {
                            Config.Intance().CurrentCfgType = "1";
                            //Config.Intance().CurrentFoxproTemplet = Application.StartupPath + @"\GetPurchase.dbf";
                            Config.Intance().CurrentFoxproTemplet = localPersonCfgPath + @"\GetPurchase.dbf";
                            Config.Intance().CurrentFoxproDetailTemplet = "";
                            //Config.Intance().CurrentTxtTemplet = Application.StartupPath + @"\GetPurchase.txt";
                            Config.Intance().CurrentTxtTemplet = localPersonCfgPath + @"\GetPurchase.txt";
                            //Config.Intance().CurrentExcelTemplet = Application.StartupPath + @"\GetPurchase.xls";
                            Config.Intance().CurrentExcelTemplet = localPersonCfgPath + @"\GetPurchase.xls";
                        }
                        if (dr["name"].ToString().Trim() == "导入库存项目")
                        {
                            Config.Intance().CurrentCfgType = "1";
                            Config.Intance().CurrentFoxproTemplet = "";
                            Config.Intance().CurrentFoxproDetailTemplet = "";
                            Config.Intance().CurrentTxtTemplet = "";
                            Config.Intance().CurrentExcelTemplet = "";
                        }
                        //end modify by gaoyuan 20070417 由于发布时将数据库文件以数据文件的类型发布，故修改文件路径
                        Config.Intance().IsMulti = false;
                    }
                    Config.Intance().CurrentCfgFile = dr["Tag"].ToString();
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("刷新项目选项", exception1);
            }
        }

        private void FormMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }

    }
}