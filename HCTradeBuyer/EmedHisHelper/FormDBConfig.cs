using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emedchina.TradeAsst.EmedHisCommonLibrary;
using Emedchina.Commons;
using System.IO;
using EmedHisHelper;
using DevExpress.XtraEditors;

namespace Emedchina.TradeAsst.EmedHisHelper
{
    public partial class FormDBConfig : DevExpress.XtraEditors.XtraForm
    {
        FormMain frmMain = null;

        public FormDBConfig()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDBConfig_Load(object sender, EventArgs e)
        {
            try
            {
                this.cmbDBType.Properties.Items.Clear();
                this.cmbDBType.Properties.Items.AddRange(new object[] { "用于SQL Server的数据库类型", "用于Access的数据库类型", "用于Foxpro的数据库类型", "用于Oracle的数据库类型", "用于Excel的数据库类型", "用于文本文件的数据库类型" });
                if ((Config.Intance().CurrentCfgType == "0") && (Config.Intance().CurrentTxtTemplet == ""))
                {
                    this.cmbDBType.Properties.Items.RemoveAt(this.cmbDBType.Properties.Items.Count - 1);
                }
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("SQL生成器变为活动", exception1);
            }

            try
            {
                if (Config.Intance().CurrentCfgType == "1")
                {
                    string text1 = Config.Intance().EleSource.GetAttribute("DBType").ToUpper();
                    if (text1 != "")
                    {
                        this.InitSourceDBInfo(text1);
                    }
                    else
                    {
                        this.cmbDBType.SelectedIndex = 0;
                    }
                    this.lblType.Text = "源数据类型：";
                }
                else
                {
                    string text2 = Config.Intance().EleDestination.GetAttribute("DBType").ToUpper();
                    if (text2 != "")
                    {
                        this.InitDestDBInfo(text2);
                    }
                    else
                    {
                        this.cmbDBType.SelectedIndex = 0;
                    }
                    this.lblType.Text = "目标数据类型：";
                }
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("设置数据库信息进行事件", exception1);
            }
        }

        private void InitSourceDBInfo(string inDBType)
        {
            try
            {
                switch (inDBType)
                {
                    case "SQLSERVER":
                        this.cmbDBType.SelectedIndex = 0;
                        this.txtServer.Text = Config.Intance().EleSource.GetAttribute("ServerName");
                        this.txtDataBase.Text = Config.Intance().EleSource.GetAttribute("DataBase");
                        this.txtUser.Text = Config.Intance().EleSource.GetAttribute("User");
                        this.txtPassword.Text = SecretUtil.DeSecret(Config.Intance().EleSource.GetAttribute("Password"));
                        return;

                    case "ACCESS":
                        this.cmbDBType.SelectedIndex = 1;
                        this.txtDataBase.Text = "template.mdb";
                        this.txtPassword.Text = SecretUtil.DeSecret(Config.Intance().EleSource.GetAttribute("Password"));
                        return;

                    case "FOXPRO":
                        this.cmbDBType.SelectedIndex = 2;
                        this.txtDataBase.Text = Application.StartupPath;
                        return;

                    case "ORACLE":
                        this.cmbDBType.SelectedIndex = 3;
                        this.txtServer.Text = Config.Intance().EleSource.GetAttribute("ServerName");
                        this.txtUser.Text = Config.Intance().EleSource.GetAttribute("User");
                        this.txtPassword.Text = SecretUtil.DeSecret(Config.Intance().EleSource.GetAttribute("Password"));
                        break;

                    case "TXT":
                        this.cmbDBType.SelectedIndex = 5;
                        this.txtDataBase.Text = Application.StartupPath;
                        break;

                    case "EXCEL":
                        this.cmbDBType.SelectedIndex = 4;
                        this.txtDataBase.Text = Config.Intance().CurrentExcelTemplet;
                        break;
                }
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("给源数据配置赋值", exception1);
            }
        }


        private void InitDestDBInfo(string inDBType)
        {
            try
            {
                switch (inDBType)
                {
                    case "SQLSERVER":
                        this.cmbDBType.SelectedIndex = 0;
                        this.txtServer.Text = Config.Intance().EleDestination.GetAttribute("ServerName");
                        this.txtDataBase.Text = Config.Intance().EleDestination.GetAttribute("DataBase");
                        this.txtUser.Text = Config.Intance().EleDestination.GetAttribute("User");
                        this.txtPassword.Text = SecretUtil.DeSecret(Config.Intance().EleDestination.GetAttribute("Password"));
                        return;

                    case "ACCESS":
                        this.cmbDBType.SelectedIndex = 1;
                        this.txtDataBase.Text = "template.mdb";
                        this.txtPassword.Text = SecretUtil.DeSecret(Config.Intance().EleDestination.GetAttribute("Password"));
                        return;

                    case "FOXPRO":
                        this.cmbDBType.SelectedIndex = 2;
                        this.txtDataBase.Text = Config.Intance().CurrentFoxproTemplet;
                        return;

                    case "ORACLE":
                        this.cmbDBType.SelectedIndex = 3;
                        this.txtServer.Text = Config.Intance().EleDestination.GetAttribute("ServerName");
                        this.txtUser.Text = Config.Intance().EleDestination.GetAttribute("User");
                        this.txtPassword.Text = SecretUtil.DeSecret(Config.Intance().EleDestination.GetAttribute("Password"));
                        break;

                    case "TXT":
                        this.cmbDBType.SelectedIndex = 5;
                        this.txtDataBase.Text = Application.StartupPath;
                        break;

                    case "EXCEL":
                        this.cmbDBType.SelectedIndex = 4;
                        this.txtDataBase.Text = Config.Intance().CurrentExcelTemplet;
                        break;
                }
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("给目标数据配置赋值", exception1);
            }
        }

        private void btn_last_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (frmMain == null)
                frmMain = new FormMain();
            frmMain.ShowDialog();
        }

        private void cmbDBType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (this.cmbDBType.SelectedIndex)
                {
                    case 0:
                        Config.Intance().CurrentDBType = "SQLSERVER";
                        setBtnStateDb();
                        goto Label_0090;

                    case 1:
                        Config.Intance().CurrentDBType = "ACCESS";
                        setBtnStateFile();
                        goto Label_0090;

                    case 2:
                        Config.Intance().CurrentDBType = "FOXPRO";
                        setBtnStateFile();
                        goto Label_0090;

                    case 3:
                        Config.Intance().CurrentDBType = "ORACLE";
                        setBtnStateDb();
                        goto Label_0090;

                    case 4:
                        Config.Intance().CurrentDBType = "EXCEL";
                        setBtnStateFile();
                        goto Label_0090;

                    case 5:
                        break;

                    default:
                        goto Label_0090;
                }
                Config.Intance().CurrentDBType = "TXT";
                Label_0090:
                Config.Intance().CurrentDBTypeDesc = this.cmbDBType.SelectedText;
                this.InitControl(Config.Intance().CurrentDBType);
                btn_next.Enabled = false;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("选择数据类型改变", exception1);
            }
        }

        private void setBtnStateFile()
        {
            this.btnImportDbFile.Visible = true;
        }
        private void setBtnStateDb()
        {
            this.btnImportDbFile.Visible = false;
        }
        private void InitControl(string inDBType)
        {
            try
            {
                switch (inDBType.ToUpper())
                {
                    case "SQLSERVER":
                        this.txtServer.Enabled = this.txtDataBase.Enabled = this.txtUser.Enabled = this.txtPassword.Enabled = true;
                        this.btnDataView.Hide();
                        goto Label_02FD;

                    case "ACCESS":
                        this.txtServer.Enabled = this.txtUser.Enabled = false;
                        this.txtPassword.Enabled = true;
                        this.txtServer.Text = this.txtUser.Text = this.txtPassword.Text = "";
                        this.txtDataBase.Text = "template.mdb";
                        this.txtDataBase.Enabled = false;
                        this.txtUser.Enabled = true;
                        this.btnDataView.Show();
                        goto Label_02FD;

                    case "FOXPRO":
                        this.txtServer.Enabled = this.txtUser.Enabled = this.txtPassword.Enabled = false;
                        this.txtServer.Text = this.txtUser.Text = this.txtPassword.Text = "";
                        this.txtDataBase.Enabled = false;
                        this.txtDataBase.Text = Config.Intance().CurrentFoxproTemplet;
                        this.btnDataView.Hide();
                        goto Label_02FD;

                    case "ORACLE":
                        this.txtDataBase.Enabled = false;
                        this.txtDataBase.Text = "";
                        this.txtServer.Enabled = this.txtUser.Enabled = this.txtPassword.Enabled = true;
                        this.btnDataView.Hide();
                        goto Label_02FD;

                    case "TXT":
                        this.txtServer.Enabled = this.txtUser.Enabled = this.txtPassword.Enabled = false;
                        this.txtServer.Text = this.txtUser.Text = this.txtPassword.Text = "";
                        this.txtDataBase.Enabled = false;
                        this.txtDataBase.Text = Application.StartupPath;
                        this.btnDataView.Hide();
                        break;

                    case "EXCEL":
                        this.txtServer.Enabled = this.txtUser.Enabled = this.txtPassword.Enabled = false;
                        this.txtServer.Text = this.txtUser.Text = this.txtPassword.Text = "";
                        this.txtDataBase.Enabled = false;
                        this.txtDataBase.Text = Config.Intance().CurrentExcelTemplet;
                        this.btnDataView.Hide();
                        break;
                }
                Label_02FD:
                if (Config.Intance().CurrentCfgType == "0")
                {
                    this.InitDestDBInfo(inDBType.ToUpper());
                }
                if (Config.Intance().CurrentCfgType == "1")
                {
                    this.InitSourceDBInfo(inDBType.ToUpper());
                }
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("初始化数据库设置控制信息", exception1);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                string text1 = "";
                if (this.CheckAttr(out text1))
                {
                    if (this.TestConnection(text1))
                    {
                        if (this.CheckTemplet())
                        {
                            if (this.SaveDBConfig())
                            {
                                XtraMessageBox.Show("测试通过，保存成功！","提示");
                                Config.Intance().CurrentDBConStr = this.GetConnStr(text1);
                                btn_next.Enabled = true;
                            }
                            else
                            {
                                XtraMessageBox.Show("保存配置信息失败！请重试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("服务器未连接或用户名、密码错误！请重试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("保存数据库配置", exception1);
            }
        }

        private bool CheckAttr(out string dbType)
        {
            string text1 = "";
            if (this.cmbDBType.SelectedIndex == 0)
            {
                if (this.CheckSqlAttr())
                {
                    text1 = "SQLSERVER";
                }
                else
                {
                    dbType = "";
                    return false;
                }
            }
            if (this.cmbDBType.SelectedIndex == 1)
            {
                if (this.CheckAccessAttr())
                {
                    text1 = "ACCESS";
                }
                else
                {
                    dbType = "";
                    return false;
                }
            }
            if (this.cmbDBType.SelectedIndex == 2)
            {
                if (this.CheckVFPAttr())
                {
                    text1 = "FOXPRO";
                }
                else
                {
                    dbType = "";
                    return false;
                }
            }
            if (this.cmbDBType.SelectedIndex == 3)
            {
                if (this.CheckOracleAttr())
                {
                    text1 = "ORACLE";
                }
                else
                {
                    dbType = "";
                    return false;
                }
            }
            if (this.cmbDBType.SelectedIndex == 5)
            {
                if (this.CheckTxtAttr())
                {
                    text1 = "TXT";
                }
                else
                {
                    dbType = "";
                    return false;
                }
            }
            if (this.cmbDBType.SelectedIndex == 4)
            {
                if (this.CheckExcelAttr())
                {
                    text1 = "EXCEL";
                }
                else
                {
                    dbType = "";
                    return false;
                }
            }
            dbType = text1;
            return true;
        }


        private bool TestConnection(string inDBType)
        {
            if (inDBType == "TXT")
            {
                return true;
            }
            if (inDBType == "FOXPRO")
            {
                return EmedOdbc.TestConnection(this.GetConnStr(inDBType));
            }
            return EmedDB.TestConnection(this.GetConnStr(inDBType));
        }

        private bool CheckTemplet()
        {
            //modify by gaoyuan 20070411 由于发布时将数据库文件以数据文件的类型发布，故修改文件路径
            //if (((Config.Intance().CurrentDBType == "FOXPRO") && (Config.Intance().CurrentFoxproTemplet != "")) && !File.Exists(Config.Intance().CurrentFoxproTemplet))
            if (((Config.Intance().CurrentDBType == "FOXPRO") && (Config.Intance().CurrentFoxproTemplet != "")) && !File.Exists(EmedFunc.GetLocalPersonCfgPath() + @"\" + Config.Intance().CurrentFoxproTemplet))
            {
                XtraMessageBox.Show(Config.Intance().CurrentFoxproTemplet + "不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //modify by gaoyuan 20070411 由于发布时将数据库文件以数据文件的类型发布，故修改文件路径
            //if (((Config.Intance().CurrentDBType == "FOXPRO") && (Config.Intance().CurrentFoxproDetailTemplet != "")) && !File.Exists(Config.Intance().CurrentFoxproDetailTemplet))
            if (((Config.Intance().CurrentDBType == "FOXPRO") && (Config.Intance().CurrentFoxproDetailTemplet != "")) && !File.Exists(EmedFunc.GetLocalPersonCfgPath() + @"\" + Config.Intance().CurrentFoxproDetailTemplet))
            {
                XtraMessageBox.Show(Config.Intance().CurrentFoxproDetailTemplet + "不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //modify by gaoyuan 20070411 由于发布时将数据库文件以数据文件的类型发布，故修改文件路径
            //if (((Config.Intance().CurrentDBType == "TXT") && (Config.Intance().CurrentTxtTemplet != "")) && !File.Exists(Config.Intance().CurrentTxtTemplet))
            if (((Config.Intance().CurrentDBType == "TXT") && (Config.Intance().CurrentTxtTemplet != "")) && !File.Exists(EmedFunc.GetLocalPersonCfgPath() + @"\" + Config.Intance().CurrentTxtTemplet))
            {
                XtraMessageBox.Show(Config.Intance().CurrentTxtTemplet + "不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //modify by gaoyuan 20070411 由于发布时将数据库文件以数据文件的类型发布，故修改文件路径
            //if (((Config.Intance().CurrentDBType == "EXCEL") && (Config.Intance().CurrentExcelTemplet != "")) && !File.Exists(Config.Intance().CurrentExcelTemplet))
            if (((Config.Intance().CurrentDBType == "EXCEL") && (Config.Intance().CurrentExcelTemplet != "")) && !File.Exists(EmedFunc.GetLocalPersonCfgPath() + @"\" + Config.Intance().CurrentExcelTemplet))
            {
                XtraMessageBox.Show(Config.Intance().CurrentExcelTemplet + "不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                return false;
            }
            return true;
        }

        private bool SaveDBConfig()
        {
            try
            {
                if (Config.Intance().CurrentCfgType == "1")
                {
                    if (this.cmbDBType.SelectedIndex == 0)
                    {
                        Config.Intance().EleSource.SetAttribute("DBType", "SQLSERVER");
                        Config.Intance().EleSource.SetAttribute("ServerName", this.txtServer.Text);
                        Config.Intance().EleSource.SetAttribute("DataBase", this.txtDataBase.Text);
                        Config.Intance().EleSource.SetAttribute("User", this.txtUser.Text);
                        Config.Intance().EleSource.SetAttribute("Password", SecretUtil.Secret(this.txtPassword.Text.Trim()));
                    }
                    else if (this.cmbDBType.SelectedIndex == 1)
                    {
                        Config.Intance().EleSource.SetAttribute("DBType", "ACCESS");
                        Config.Intance().EleSource.SetAttribute("DBPath", this.txtDataBase.Text);
                        Config.Intance().EleSource.SetAttribute("Password", SecretUtil.Secret(this.txtPassword.Text.Trim()));
                        //Config.Intance().DestTable.SetAttribute("TableName", Config.Intance().CurrentDBName);
                    }
                    else if (this.cmbDBType.SelectedIndex == 2)
                    {
                        Config.Intance().EleSource.SetAttribute("DBType", "FOXPRO");
                        Config.Intance().EleSource.SetAttribute("DBPath", this.txtDataBase.Text);
                    }
                    else if (this.cmbDBType.SelectedIndex == 3)
                    {
                        Config.Intance().EleSource.SetAttribute("DBType", "ORACLE");
                        Config.Intance().EleSource.SetAttribute("ServerName", this.txtServer.Text);
                        Config.Intance().EleSource.SetAttribute("User", this.txtUser.Text);
                        Config.Intance().EleSource.SetAttribute("Password", SecretUtil.Secret(this.txtPassword.Text.Trim()));
                    }
                    else if (this.cmbDBType.SelectedIndex == 5)
                    {
                        Config.Intance().EleSource.SetAttribute("DBType", "TXT");
                        Config.Intance().EleSource.SetAttribute("DBPath", this.txtDataBase.Text);
                    }
                    else if (this.cmbDBType.SelectedIndex == 4)
                    {
                        Config.Intance().EleSource.SetAttribute("DBType", "EXCEL");
                        Config.Intance().EleSource.SetAttribute("DBPath", this.txtDataBase.Text);
                        //Config.Intance().DestTable.SetAttribute("TableName", "sheet1");
                    }
                    Config.Intance().SaveSourceDB(Config.Intance().CurrentCfgFile, Config.Intance().EleSource);
                }
                else
                {
                    if (this.cmbDBType.SelectedIndex == 0)
                    {
                        Config.Intance().EleDestination.SetAttribute("DBType", "SQLSERVER");
                        Config.Intance().EleDestination.SetAttribute("ServerName", this.txtServer.Text);
                        Config.Intance().EleDestination.SetAttribute("DataBase", this.txtDataBase.Text);
                        Config.Intance().EleDestination.SetAttribute("User", this.txtUser.Text);
                        Config.Intance().EleDestination.SetAttribute("Password", SecretUtil.Secret(this.txtPassword.Text.Trim()));
                    }
                    else if (this.cmbDBType.SelectedIndex == 1)
                    {
                        Config.Intance().EleDestination.SetAttribute("DBType", "ACCESS");
                        Config.Intance().EleDestination.SetAttribute("DBPath", this.txtDataBase.Text);
                        Config.Intance().EleDestination.SetAttribute("Password", SecretUtil.Secret(this.txtPassword.Text.Trim()));
                        //Config.Intance().DestTable.SetAttribute("TableName", Config.Intance().CurrentDBName);
                    }
                    else if (this.cmbDBType.SelectedIndex == 2)
                    {
                        Config.Intance().EleDestination.SetAttribute("DBType", "FOXPRO");
                        Config.Intance().EleDestination.SetAttribute("DBPath", this.txtDataBase.Text);
                    }
                    else if (this.cmbDBType.SelectedIndex == 3)
                    {
                        Config.Intance().EleDestination.SetAttribute("DBType", "ORACLE");
                        Config.Intance().EleDestination.SetAttribute("ServerName", this.txtServer.Text);
                        Config.Intance().EleDestination.SetAttribute("User", this.txtUser.Text);
                        Config.Intance().EleDestination.SetAttribute("Password", SecretUtil.Secret(this.txtPassword.Text.Trim()));
                    }
                    else if (this.cmbDBType.SelectedIndex == 5)
                    {
                        Config.Intance().EleDestination.SetAttribute("DBType", "TXT");
                        Config.Intance().EleDestination.SetAttribute("DBPath", this.txtDataBase.Text);
                    }
                    else if (this.cmbDBType.SelectedIndex == 4)
                    {
                        Config.Intance().EleDestination.SetAttribute("DBType", "EXCEL");
                        Config.Intance().EleDestination.SetAttribute("DBPath", this.txtDataBase.Text);
                        //Config.Intance().DestTable.SetAttribute("TableName", "sheet1");
                    }
                    Config.Intance().SaveDestDB(Config.Intance().CurrentCfgFile, Config.Intance().EleDestination);
                }
                return true;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("保存配置信息", exception1);
                return false;
            }
        }

        private string GetConnStr(string inDBType)
        {
            //MessageBox.Show(EmedFunc.GetLocalPersonCfgPath() + @"\" + this.txtDataBase.Text);
            string text1 = "";
            string text2 = inDBType.ToUpper();
            if (text2 == null)
            {
                return text1;
            }
            text2 = string.IsInterned(text2);
            if (text2 == "SQLSERVER")
            {
                return ("Provider=SQLOLEDB;Server=" + this.txtServer.Text + ";UID=" + this.txtUser.Text + ";PWD=" + this.txtPassword.Text + ";Database=" + this.txtDataBase.Text);
            }
            if (text2 == "ACCESS")
            {
                //modify by gaoyuan 20070411 由于发布时将数据库文件以数据文件的类型发布，故修改文件路径
                //return ("Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:Database Password=" + this.txtPassword.Text + ";Data Source=" + this.txtDataBase.Text);
                return ("Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:Database Password=" + this.txtPassword.Text + ";Data Source=" + EmedFunc.GetLocalPersonCfgPath() + @"\" + this.txtDataBase.Text);
            }
            if (text2 == "FOXPRO")
            {
                //modify by gaoyuan 20070411 由于发布时将数据库文件以数据文件的类型发布，故修改文件路径
                //return ("Provider=MSDASQL.1;Driver=Microsoft Visual Foxpro Driver;SourceDB=" + this.txtDataBase.Text + ";SourceType=DBF;");
                return ("Provider=MSDASQL.1;Driver=Microsoft Visual Foxpro Driver;SourceDB=" + EmedFunc.GetLocalPersonCfgPath() + @"\" + this.txtDataBase.Text + ";SourceType=DBF;");
            }
            if (text2 == "ORACLE")
            {
                return ("Provider=MSDAORA.1;Data Source=" + this.txtServer.Text + ";User ID=" + this.txtUser.Text + ";Password=" + this.txtPassword.Text);
            }
            if (text2 != "EXCEL")
            {
                return text1;
            }
            if (Config.Intance().CurrentCfgType == "1")
            {
                //modify by gaoyuan 20070411 由于发布时将数据库文件以数据文件的类型发布，故修改文件路径
                return ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + EmedFunc.GetLocalPersonCfgPath() + @"\" + this.txtDataBase.Text + ";Persist Security Info=False;Extended Properties=\"Excel 8.0;IMEX=1\"");
            }
            //modify by gaoyuan 20070411 由于发布时将数据库文件以数据文件的类型发布，故修改文件路径
            return ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + EmedFunc.GetLocalPersonCfgPath() + @"\" + this.txtDataBase.Text + ";Extended Properties=Excel 8.0");
        }

        private bool CheckSqlAttr()
        {
            try
            {
                if (this.txtServer.Text.Trim() == "")
                {
                    XtraMessageBox.Show("服务器地址不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtServer.Focus();
                    return false;
                }
                if (this.txtDataBase.Text.Trim() == "")
                {
                    XtraMessageBox.Show("数据库名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtDataBase.Focus();
                    return false;
                }
                if (this.txtUser.Text.Trim() == "")
                {
                    XtraMessageBox.Show("数据库用户名不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtUser.Focus();
                    return false;
                }
                if (this.txtUser.Text.Trim() == "")
                {
                    XtraMessageBox.Show("数据库密码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtUser.Focus();
                    return false;
                }
                return true;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("检查Sql Server 配置", exception1);
                return false;
            }
        }

        private bool CheckAccessAttr()
        {
            if (this.txtDataBase.Text.Trim() == "")
            {
                XtraMessageBox.Show("数据库名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtDataBase.Focus();
                return false;
            }
            return true;
        }

        private bool CheckVFPAttr()
        {
            if (this.txtDataBase.Text.Trim() == "")
            {
                XtraMessageBox.Show("数据库名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtDataBase.Focus();
                return false;
            }
            return true;
        }

        private bool CheckOracleAttr()
        {
            try
            {
                if (this.txtServer.Text.Trim() == "")
                {
                    XtraMessageBox.Show("数据库名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtDataBase.Focus();
                    return false;
                }
                if (this.txtUser.Text.Trim() == "")
                {
                    XtraMessageBox.Show("数据库用户名不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtUser.Focus();
                    return false;
                }
                return true;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("检查Oracle配置", exception1);
                return false;
            }
        }

        private bool CheckTxtAttr()
        {
            return true;
        }

        private bool CheckExcelAttr()
        {
            return true;
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormSql frm = new FormSql();
            frm.ShowDialog();
        }
        /// <summary>
        /// 选择数据文件 梁晓奕添加2007-4-13
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportDbFile_Click(object sender, EventArgs e)
        {
            switch (this.cmbDBType.SelectedIndex)
            {
                
                case 1:
                    openFileDialog1.Filter = "MDB文档(*.mdb)|*.mdb";
                    break;

                case 2:
                    openFileDialog1.Filter = "DBF文档(*.dbf)|*.dbf";
                    break;

                case 4:
                    openFileDialog1.Filter = "Excel文档(*.xls)|*.xls";
                    break;

                default:
                    return;
                    
            }
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Title = "打开文件";
            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FileName = "";
            //modify by gaoyuan 20070417 取消时不做任何操作
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string fileName = openFileDialog1.FileName;

            //add by yanbing 2007-6-11 for export to access
            //this.txtDataBase.Text = fileName;
            //end by yanbing  2007-6-11

            string soureFileName = EmedFunc.GetLocalPersonCfgPath() + @"\" + this.txtDataBase.Text;
            string backFileName = EmedFunc.GetLocalPersonCfgPath() + @"\Bak" + this.txtDataBase.Text;
            if (!File.Exists(backFileName))
            {
                File.Copy(soureFileName, backFileName);
            }
            if (File.Exists(soureFileName))
            {
                File.Delete(soureFileName);
            }
            if (File.Exists(fileName))
            {
                File.Copy(fileName, soureFileName);
            }
        }

        private void btnDataView_Click(object sender, EventArgs e)
        {

        }

        private void FormDBConfig_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }
    }
}