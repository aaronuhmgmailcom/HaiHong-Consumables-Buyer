using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emedchina.TradeAsst.EmedHisHelper;
using Emedchina.TradeAsst.EmedHisCommonLibrary;
using Emedchina.Commons;
using System.Xml;
using DevExpress.XtraEditors;

namespace EmedHisHelper
{
    public partial class FormSql : DevExpress.XtraEditors.XtraForm
    {
        FormDBConfig frmDBConfig = null;
        private string sqlDelete;

        public FormSql()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_last_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (frmDBConfig == null)
                frmDBConfig = new FormDBConfig();
            frmDBConfig.ShowDialog();
        }

        private void btnSqlBuild_Click(object sender, EventArgs e)
        {
            FormColumns columns1 = new FormColumns();
            columns1.sql = this.rtbSql.Text;
            if ((columns1.ShowDialog() == DialogResult.OK) && (Config.Intance().CurrentDBType != "TXT"))
            {
                this.rtbSql.Text = columns1.sql;
            }
            columns1.Dispose();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSql_Load(object sender, EventArgs e)
        {
            if (Config.Intance().Version != "1.0")
            {
                this.m_subtitleLabel.Text = "配置主表的SQL，SQL语句请用SQL生成器自动生成";
                this.lblDesc.Text = "主表SQL";
            }
            else
            {
                this.m_subtitleLabel.Text = "SQL语句请用SQL生成器自动生成";
            }
        }

        private void rtbSql_TextChanged(object sender, EventArgs e)
        {
            this.btnDataView.Enabled = this.btnSaveSql.Enabled = false;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (Config.Intance().CurrentCfgType == "1")
                {
                    DataSet set1;
                    if (Config.Intance().CurrentDBType == "TXT")
                    {
                        set1 = uncTxt.getDataSet(Config.Intance().CurrentTxtTemplet);
                    }
                    else if (Config.Intance().CurrentDBType == "FOXPRO")
                    {
                        set1 = EmedOdbc.getDataSet(this.rtbSql.Text.Trim().Replace(":StoreOutDate", "2002-01-01"), Config.Intance().CurrentDBConStr);
                    }
                    else
                    {
                        set1 = EmedDB.getDataSet(this.rtbSql.Text.Trim().Replace(":StoreOutDate", "2002-01-01"), Config.Intance().CurrentDBConStr);
                    }
                    if ((set1 != null) && EmedFunc.CheckTable(set1))
                    {
                        if (this.IsFullSql(set1))
                        {
                            XtraMessageBox.Show("Sql语句配置正确！","提示");
                            this.btnSaveSql.Enabled = this.btnDataView.Enabled = true;
                        }
                        else
                        {
                            this.btnSaveSql.Enabled = this.btnDataView.Enabled = false;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Sql语句配置错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.btnSaveSql.Enabled = this.btnDataView.Enabled = false;
                    }
                }
                else
                {
                    bool flag1;
                    if (Config.Intance().CurrentDBType == "TXT")
                    {
                        uncTxt txt1 = new uncTxt();
                        flag1 = (txt1.BeginInsert(Config.Intance().CurrentTxtTemplet) && txt1.ExecInsert(this.CreateTestDataRow(), true)) && txt1.EndInsert();
                    }
                    else if (Config.Intance().CurrentDBType == "FOXPRO")
                    {
                        flag1 = EmedOdbc.ExcuteSql(this.CreateTestInsertSql(this.rtbSql.Text.Trim().Replace(":StoreOutDate", "2002-01-01")), Config.Intance().CurrentDBConStr) && EmedOdbc.ExcuteSql(this.sqlDelete, Config.Intance().CurrentDBConStr);
                    }
                    else if (Config.Intance().CurrentDBType == "EXCEL")
                    {
                        flag1 = EmedDB.ExcuteSql(this.CreateTestInsertSql(this.rtbSql.Text.Trim().Replace(":StoreOutDate", "2002-01-01")), Config.Intance().CurrentDBConStr);
                    }
                    else if (Config.Intance().CurrentDBType == "ACCESS")
                    {
                        flag1 = EmedDB.ExcuteSql(this.CreateTestInsertSql(this.rtbSql.Text.Trim().Replace(":StoreOutDate", "2002-01-01")), Config.Intance().CurrentDBConStr) && EmedDB.ExcuteSql(this.sqlDelete, Config.Intance().CurrentDBConStr);
                    }
                    else
                    {
                        flag1 = EmedDB.ExcuteSql(this.CreateTestInsertSql(this.rtbSql.Text.Trim().Replace(":StoreOutDate", "2002-01-01")), Config.Intance().CurrentDBConStr) && EmedDB.ExcuteSql(this.sqlDelete, Config.Intance().CurrentDBConStr);
                    }
                    if (flag1)
                    {
                        XtraMessageBox.Show("Sql语句配置正确！","提示");
                        this.btnSaveSql.Enabled = true;
                    }
                    else
                    {
                        XtraMessageBox.Show("Sql语句配置错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.btnSaveSql.Enabled = this.btnDataView.Enabled = false;
                    }
                }
            }
            catch (Exception exception1)
            {
                XtraMessageBox.Show("Sql语句配置错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ErrorLog.SaveLog("测试SQL", exception1);
            }
        }

        private bool IsFullSql(DataSet dsCheck)
        {
            if (dsCheck.Tables.Count <= 0)
            {
                return false;
            }
            XmlElement element1 = (XmlElement)Config.Intance().EleDestination.SelectSingleNode("DestTable");
            for (int num1 = 0; num1 < element1.ChildNodes.Count; num1++)
            {
                if (dsCheck.Tables[0].Columns.IndexOf(element1.ChildNodes[num1].Attributes["Name"].Value) == -1)
                {
                    XtraMessageBox.Show("目标字段\"" + element1.ChildNodes[num1].Attributes["Name"].Value + "\"没有找到！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private DataRow CreateTestDataRow()
        {
            try
            {
                XmlElement element1 = (XmlElement)Config.Intance().EleSource.SelectSingleNode("SourceTable");
                DataSet set1 = new DataSet();
                DataTable table1 = new DataTable(element1.Attributes["TableName"].Value);
                set1.Tables.Add(table1);
                DataColumn column1 = null;
                string text1 = "";
                for (int num1 = 0; num1 < element1.ChildNodes.Count; num1++)
                {
                    column1 = new DataColumn();
                    column1.ColumnName = element1.ChildNodes[num1].Attributes["Name"].Value;
                    text1 = element1.ChildNodes[num1].Attributes["Type"].Value.ToLower();
                    column1.DataType = uncTxt.GetDataType(text1);
                    if (element1.ChildNodes[num1].Attributes["Default"].Value != "")
                    {
                        column1.DefaultValue = element1.ChildNodes[num1].Attributes["Default"].Value;
                    }
                    table1.Columns.Add(column1);
                }
                DataRow row1 = table1.NewRow();
                XmlNodeList list1 = Config.Intance().EleContrast.ChildNodes;
                for (int num2 = 0; num2 < table1.Columns.Count; num2++)
                {
                    for (int num3 = 0; num3 < list1.Count; num3++)
                    {
                        if (list1[num3].Attributes["SourceField"].Value == table1.Columns[num2].ColumnName)
                        {
                            string text2 = list1[num3].Attributes["DestDBType"].Value;
                            if (uncTxt.GetDataType(text2) == Type.GetType("System.String"))
                            {
                                row1[num2] = "测试" + table1.Columns[num2].ColumnName;
                                break;
                            }
                            if (uncTxt.GetDataType(text2) == Type.GetType("System.Int32"))
                            {
                                row1[num2] = "0";
                                break;
                            }
                            if (uncTxt.GetDataType(text2) == Type.GetType("System.Double"))
                            {
                                row1[num2] = "0.00";
                                break;
                            }
                            if (uncTxt.GetDataType(text2) == Type.GetType("System.DateTime"))
                            {
                                row1[num2] = DateTime.Now.ToString();
                            }
                            break;
                        }
                    }
                }
                return row1;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("创建测试导出用的数据行", exception1);
                return null;
            }
        }

        private string CreateTestInsertSql(string inInsertSql)
        {
            try
            {
                XmlElement element1 = Config.Intance().EleContrast;
                XmlElement element2 = (XmlElement)Config.Intance().EleDestination.SelectSingleNode("DestTable");
                int num1 = 0;
                string text1 = inInsertSql.Trim().ToLower();
                string text2 = "";
                string text3 = "";
                string text4 = "";
                string text5 = "";
                string text6 = "";
                string text7 = "";
                this.sqlDelete = "delete from " + element2.Attributes["TableName"].Value + " where ";
                for (int num2 = 0; num2 < element1.ChildNodes.Count; num2++)
                {
                    text2 = element1.ChildNodes[num2].Attributes["SourceField"].Value.Trim().ToLower();
                    text3 = element1.ChildNodes[num2].Attributes["DestField"].Value;
                    text5 = element1.ChildNodes[num2].Attributes["DestDBType"].Value;
                    text6 = element1.ChildNodes[num2].Attributes["Algorithm"].Value;
                    if (text2 != "")
                    {
                        text4 = this.CreateTestValue(text2, text5);
                        text1 = text1.Replace("@" + text2, text4);
                        if (((text2 != "") && (text6 == "")) && (text5 == "字符型"))
                        {
                            if (num1 == 0)
                            {
                                this.sqlDelete = this.sqlDelete + text3 + "=" + text4;
                            }
                            else
                            {
                                this.sqlDelete = this.sqlDelete + " and " + text3 + "=" + text4;
                            }
                            num1++;
                        }
                    }
                }
                XmlElement element3 = (XmlElement)Config.Intance().EleSource.SelectSingleNode("SourceTable");
                for (int num3 = 0; num3 < element3.ChildNodes.Count; num3++)
                {
                    text7 = element3.ChildNodes[num3].Attributes["Type"].Value;
                    text2 = element3.ChildNodes[num3].Attributes["Name"].Value.Trim().ToLower();
                    text4 = this.CreateTestValue(text2, text7);
                    text1 = text1.Replace("@" + text2, text4);
                }
                return text1;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("生成Insert语句", exception1);
                return "";
            }
        }

        private string CreateTestValue(string inSrcField, string inType)
        {
            if (this.GetDataType(inType) == Type.GetType("System.String"))
            {
                return "'t'";
            }
            if (this.GetDataType(inType) == Type.GetType("System.Int32"))
            {
                return "'0'";
            }
            if (this.GetDataType(inType) == Type.GetType("System.Double"))
            {
                return "'0.00'";
            }
            if (this.GetDataType(inType) != Type.GetType("System.DateTime"))
            {
                return "'t'";
            }
            if ((Config.Intance().CurrentDBType != "FOXPRO") && (Config.Intance().CurrentDBType != "ACCESS"))
            {
                return ("'" + DateTime.Now.ToString() + "'");
            }
            return DateTime.Now.ToString();
        }

        public Type GetDataType(string srcType)
        {
            srcType = srcType.ToLower();
            if (srcType.IndexOf("char") == -1)
            {
                if ((srcType.IndexOf("date") != -1) | (srcType.IndexOf("time") != -1))
                {
                    return Type.GetType("System.DateTime");
                }
                if (srcType.IndexOf("number") != -1)
                {
                    return Type.GetType("System.Double");
                }
                if (srcType.IndexOf("字符型") != -1)
                {
                    return Type.GetType("System.String");
                }
                if (srcType.IndexOf("整型") != -1)
                {
                    return Type.GetType("System.Int32");
                }
                if (srcType.IndexOf("日期型") != -1)
                {
                    return Type.GetType("System.DateTime");
                }
                if (srcType.IndexOf("浮点数") != -1)
                {
                    return Type.GetType("System.Double");
                }
            }
            return Type.GetType("System.String");
        }

        private void btnSaveSql_Click(object sender, EventArgs e)
        {
            try
            {

                if (Config.Intance().CurrentDBType == "EXCEL")
                {
                    if (Config.Intance().CurrentCfgType == "1")
                    {
                        Config.Intance().EleSql.ChildNodes[0].Attributes["Pattern"].Value = "0";
                    }
                    else
                    {
                        Config.Intance().EleSql.ChildNodes[0].Attributes["Pattern"].Value = "1";
                    }
                    Config.Intance().EleSql.ChildNodes[0].Attributes["ExecSort"].Value = "1";
                    Config.Intance().EleSql.ChildNodes[0].InnerText = this.rtbSql.Text;
                    if (Config.Intance().SaveSQL(Config.Intance().CurrentCfgFile, (XmlElement)Config.Intance().EleSql.ChildNodes[0]))
                    {
                        XtraMessageBox.Show("SQL语句保存成功！","提示");
                        this.btn_next.Enabled = true;
                    }
                    else
                    {
                        XtraMessageBox.Show("SQL语句保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (Config.Intance().CurrentDBType == "SQLSERVER")
                {
                    if (Config.Intance().CurrentCfgType == "1")
                    {
                        Config.Intance().MSql.ChildNodes[0].Attributes["Pattern"].Value = "0";
                    }
                    else
                    {
                        Config.Intance().MSql.ChildNodes[0].Attributes["Pattern"].Value = "1";
                    }
                    Config.Intance().MSql.ChildNodes[0].Attributes["ExecSort"].Value = "1";
                    Config.Intance().MSql.ChildNodes[0].InnerText = this.rtbSql.Text;
                    if (Config.Intance().SaveMSQL(Config.Intance().CurrentCfgFile, (XmlElement)Config.Intance().MSql.ChildNodes[0]))
                    {
                        XtraMessageBox.Show("SQL语句保存成功！","提示");
                        this.btn_next.Enabled = true;
                    }
                    else
                    {
                        XtraMessageBox.Show("SQL语句保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                if (Config.Intance().CurrentDBType == "ACCESS")
                {
                    if (Config.Intance().CurrentCfgType == "1")
                    {
                        Config.Intance().ASql.ChildNodes[0].Attributes["Pattern"].Value = "0";
                    }
                    else
                    {
                        Config.Intance().ASql.ChildNodes[0].Attributes["Pattern"].Value = "1";
                    }
                    Config.Intance().ASql.ChildNodes[0].Attributes["ExecSort"].Value = "1";
                    Config.Intance().ASql.ChildNodes[0].InnerText = this.rtbSql.Text;
                    if (Config.Intance().SaveASQL(Config.Intance().CurrentCfgFile, (XmlElement)Config.Intance().ASql.ChildNodes[0]))
                    {
                        XtraMessageBox.Show("SQL语句保存成功！","提示");
                        this.btn_next.Enabled = true;
                    }
                    else
                    {
                        XtraMessageBox.Show("SQL语句保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("保存SQL", exception1);
            }
        }

        private void btnDataView_Click(object sender, EventArgs e)
        {
            DataSet set1 = null;
            if (Config.Intance().CurrentCfgType == "1")
            {
                if (Config.Intance().CurrentDBType == "TXT")
                {
                    set1 = uncTxt.getDataSet(Config.Intance().CurrentTxtTemplet);
                }
                else if (Config.Intance().CurrentDBType == "FOXPRO")
                {
                    set1 = EmedOdbc.getDataSet(this.rtbSql.Text.Trim().Replace(":StoreOutDate", "2002-01-01"), Config.Intance().CurrentDBConStr);
                }
                else
                {
                    set1 = EmedDB.getDataSet(this.rtbSql.Text.Trim().Replace(":StoreOutDate", "2002-01-01"), Config.Intance().CurrentDBConStr);
                }
            }
            else
            {
                string text1 = "select * from " + Config.Intance().EleDestination.SelectSingleNode("DestTable").Attributes["TableName"].Value;
                if (Config.Intance().CurrentDBType == "FOXPRO")
                {
                    set1 = EmedOdbc.getDataSet(text1, Config.Intance().CurrentDBConStr);
                }
                else
                {
                    set1 = EmedDB.getDataSet(text1, Config.Intance().CurrentDBConStr);
                }
            }
            FormDataView view1 = new FormDataView(set1);
            view1.ShowDialog();
            view1.Dispose();
        }

        private void FormSql_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (Config.Intance().CurrentDBType == "TXT")
                {
                    this.rtbSql.Text = "";
                    this.rtbSql.Enabled = false;
                    this.btnSaveSql.Enabled = this.btnDataView.Enabled = false;
                    //this.btnBeforeSql.Visible = this.btnAfterSql.Visible = false;
                }
                else if (Config.Intance().CurrentDBType == "EXCEL")
                {
                    this.rtbSql.Text = Config.Intance().EleSql.ChildNodes[0].InnerText;
                    this.rtbSql.Enabled = true;
                    this.btnSaveSql.Enabled = this.btnDataView.Enabled = false;
                    //this.btnBeforeSql.Visible = this.btnAfterSql.Visible = true;
                }
                else if (Config.Intance().CurrentDBType == "SQLSERVER")
                {
                    this.rtbSql.Text = Config.Intance().MSql.ChildNodes[0].InnerText;
                    this.rtbSql.Enabled = true;
                    this.btnSaveSql.Enabled = this.btnDataView.Enabled = false;
                    //this.btnBeforeSql.Visible = this.btnAfterSql.Visible = true;
                }
                else if (Config.Intance().CurrentDBType == "ACCESS")
                {
                    this.rtbSql.Text = Config.Intance().ASql.ChildNodes[0].InnerText;
                    this.rtbSql.Enabled = true;
                    this.btnSaveSql.Enabled = this.btnDataView.Enabled = false;
                    //this.btnBeforeSql.Visible = this.btnAfterSql.Visible = true;
                }
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("设置SQL页面进入", exception1);
            }
        }

        private void FormSql_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }

    }
}