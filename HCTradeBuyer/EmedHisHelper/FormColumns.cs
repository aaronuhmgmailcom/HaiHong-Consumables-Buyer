using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emedchina.TradeAsst.EmedHisCommonLibrary;
using System.Xml;
using Emedchina.Commons;
using DevExpress.XtraEditors;

namespace EmedHisHelper
{
    public partial class FormColumns : DevExpress.XtraEditors.XtraForm
    {
        public string sql;
        DataTable dt;

        public FormColumns()
        {
            InitializeComponent();
        }

        private void FormColumns_Load(object sender, EventArgs e)
        {
            try
            {
                this.lblDBType.Text = Config.Intance().CurrentDBTypeDesc;
                if (Config.Intance().CurrentDBType == "TXT")
                {
                    this.lblTable.Text = "分隔符：";
                    //this.cmbType.DropDownStyle = ComboBoxStyle.DropDown;
                    this.cmbType.Enabled = false;
                    this.InitHisFieldList();
                }
                if (Config.Intance().CurrentCfgType == "1")
                {
                    this.ReadImpHisInfo();
                    this.ReadImpDestField();
                    this.ReadImpContrast();
                    this.btnAdd.Visible = this.btnDel.Visible = false;
                    this.lblDefaultValue.Enabled = this.txtDefaultValue.Enabled = false;
                }
                else
                {
                    this.ReadExpHisInfo();
                    this.ReadExpSourceField();
                    this.ReadExpContrast();
                }
                this.txtDefaultValue.Enabled = this.lblDefaultValue.Enabled = Config.Intance().CurrentCfgType == "0";
                this.txtAlgorithm.Enabled = (Config.Intance().CurrentCfgType != "0") || (Config.Intance().CurrentDBType != "TXT");
                gridView1_FocusedRowChanged(null,null);
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("装载SQL生成器", exception1);
            }
        }
        /// <summary>
        /// 初始化HIS字段列表
        /// </summary>
        private void InitHisFieldList()
        {
            try
            {
                XmlNodeList list1;
                if (Config.Intance().CurrentCfgType == "1")
                {
                    list1 = ((XmlElement)Config.Intance().EleSource.SelectSingleNode("SourceTable")).ChildNodes;
                }
                else
                {
                    list1 = ((XmlElement)Config.Intance().EleDestination.SelectSingleNode("DestTable")).ChildNodes;
                }
                this.cmbType.Properties.Items.Clear();
                for (int num1 = 0; num1 < list1.Count; num1++)
                {
                    this.cmbType.Properties.Items.Add(list1[num1].Attributes["Name"].Value);
                }
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("读取HIS字段的列表至下拉框", exception1);
            }
        }

        /// <summary>
        ///读取导入HIS源表信息 
        /// </summary>
        private void ReadImpHisInfo()
        {
            try
            {
                if (Config.Intance().CurrentDBType != "TXT")
                {
                    //if (Config.Intance().CurrentDBType == "EXCEL")
                        this.txtTable.Text = Config.Intance().EleSource.SelectSingleNode("SourceTable").Attributes["TableName"].Value;
                    //else
                    //    this.txtTable.Text = Config.Intance().CurrentDBName;
                }
                this.lblDBType.Text = Config.Intance().CurrentDBType;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("保存HIS源表信息", exception1);
            }
        }

        /// <summary>
        /// 读取导入HIS目标字段信息
        /// </summary>
        private void ReadImpDestField()
        {
            try
            {
                XmlElement element1 = (XmlElement)Config.Intance().EleDestination.SelectSingleNode("DestTable");

                lvColumns.DataSource = null;
                dt = new DataTable();
                dt.Columns.Add();
                dt.Columns.Add();
                dt.Columns.Add();
                dt.Columns.Add();
                dt.Columns.Add();
                dt.Columns.Add();
                dt.Columns.Add();
                dt.Columns.Add();

                dt.Columns[0].ColumnName = "num";
                dt.Columns[1].ColumnName = "name";
                dt.Columns[2].ColumnName = "type";
                dt.Columns[3].ColumnName = "oname";
                dt.Columns[4].ColumnName = "otype";
                dt.Columns[5].ColumnName = "default";
                dt.Columns[6].ColumnName = "regular";
                dt.Columns[7].ColumnName = "remark";

                DataRow item;
                for (int num1 = 0; num1 < element1.ChildNodes.Count; num1++)
                {
                    int num2 = num1 + 1;
                    //ListViewItem item1 = this.lvColumns.Items.Add(num2.ToString());
                    //item1.SubItems.Add("");
                    //item1.SubItems.Add("");
                    //item1.SubItems.Add(element1.ChildNodes[num1].Attributes["Name"].Value);
                    //item1.SubItems.Add(element1.ChildNodes[num1].Attributes["Type"].Value);
                    //item1.SubItems.Add(element1.ChildNodes[num1].Attributes["Default"].Value);
                    //item1.SubItems.Add("");
                    //item1.SubItems.Add(element1.ChildNodes[num1].Attributes["Desc"].Value);

                    //修改后加入datatable绑定
                    item = dt.NewRow();
                    item[0] = num2.ToString();
                    item[1] = "";
                    item[2] = "";
                    item[3] = element1.ChildNodes[num1].Attributes["Name"].Value;
                    item[4] = element1.ChildNodes[num1].Attributes["Type"].Value;
                    item[5] = element1.ChildNodes[num1].Attributes["Default"].Value;
                    item[6] = "";
                    item[7] = element1.ChildNodes[num1].Attributes["Desc"].Value;
                    dt.Rows.Add(item);
              

                }
                lvColumns.DataSource = dt.DefaultView;
                this.lvColumns.EndUpdate();
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("读取导入目的字段信息", exception1);
            }
        }

        /// <summary>
        /// 读取匹配规则
        /// </summary>
        private void ReadImpContrast()
        {
            try
            {
                XmlElement element1 = Config.Intance().EleContrast;
                this.lvColumns.BeginUpdate();
                for (int num1 = 0; num1 < element1.ChildNodes.Count; num1++)
                {
                    string text1 = element1.ChildNodes[num1].Attributes["DestField"].Value;
                    string text2 = element1.ChildNodes[num1].Attributes["SourceField"].Value;
                    string text3 = element1.ChildNodes[num1].Attributes["Algorithm"].Value;
                    for (int num2 = 0; num2 < this.gridView1.RowCount; num2++)
                    {
                        if (this.gridView1.GetDataRow(num2)[3].ToString() == text1)
                        {
                            XmlElement element2 = (XmlElement)Config.Intance().EleSource.SelectSingleNode("SourceTable");
                            for (int num3 = 0; num3 < element2.ChildNodes.Count; num3++)
                            {
                                if (element2.ChildNodes[num3].Attributes["Name"].Value == text2)
                                {
                                    this.gridView1.GetDataRow(num2)[1] = text2;
                                    this.gridView1.GetDataRow(num2)[2] = element2.ChildNodes[num3].Attributes["Type"].Value;
                                }
                            }
                            this.gridView1.GetDataRow(num2)[6] = text3;
                        }
                    }
                }
                this.lvColumns.EndUpdate();
                if (Config.Intance().CurrentDBType == "TXT")
                {
                    this.txtTable.Text = element1.GetAttribute("Delimited");
                }
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("读取匹配规则", exception1);
            }
        }

        /// <summary>
        /// 读取导出HIS目的表信息
        /// </summary>
        private void ReadExpHisInfo()
        {
            try
            {
                if (Config.Intance().CurrentDBType != "TXT")
                {
                    //if (Config.Intance().CurrentDBType == "EXCEL")
                        this.txtTable.Text = Config.Intance().EleDestination.SelectSingleNode("DestTable").Attributes["TableName"].Value;
                    //else
                    //    this.txtTable.Text = Config.Intance().CurrentDBName;
                }
                this.lblDBType.Text = Config.Intance().CurrentDBType;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("保存HIS目的表信息", exception1);
            }
        }

        /// <summary>
        /// 读取导出HIS源表信息
        /// </summary>
        private void ReadExpSourceField()
        {
            try
            {
                XmlElement element1 = (XmlElement)Config.Intance().EleSource.SelectSingleNode("SourceTable");
                this.lvColumns.BeginUpdate();
                //this.lvColumns.Items.Clear();

                lvColumns.DataSource = null;
                dt = new DataTable();
                dt.Columns.Add();
                dt.Columns.Add();
                dt.Columns.Add();
                dt.Columns.Add();
                dt.Columns.Add();
                dt.Columns.Add();
                dt.Columns.Add();
                dt.Columns.Add();

                dt.Columns[0].ColumnName = "num";
                dt.Columns[1].ColumnName = "name";
                dt.Columns[2].ColumnName = "type";
                dt.Columns[3].ColumnName = "oname";
                dt.Columns[4].ColumnName = "otype";
                dt.Columns[5].ColumnName = "default";
                dt.Columns[6].ColumnName = "regular";
                dt.Columns[7].ColumnName = "remark";

                DataRow item;
                for (int num1 = 0; num1 < element1.ChildNodes.Count; num1++)
                {
                    int num2 = num1 + 1;
                    //ListViewItem item1 = this.lvColumns.Items.Add(num2.ToString());
                    //item1.SubItems.Add(element1.ChildNodes[num1].Attributes["Name"].Value);
                    //item1.SubItems.Add(element1.ChildNodes[num1].Attributes["Type"].Value);
                    //item1.SubItems.Add("");
                    //item1.SubItems.Add("");
                    //item1.SubItems.Add("");
                    //item1.SubItems.Add("");
                    //item1.SubItems.Add(element1.ChildNodes[num1].Attributes["Desc"].Value);

                    //修改后加入datatable绑定
                    item = dt.NewRow();
                    item[0] = num2.ToString();
                    item[1] = element1.ChildNodes[num1].Attributes["Name"].Value;
                    item[2] = element1.ChildNodes[num1].Attributes["Type"].Value;
                    item[3] = "";
                    item[4] = "";
                    item[5] = "";
                    item[6] = "";
                    item[7] = element1.ChildNodes[num1].Attributes["Desc"].Value;
                    dt.Rows.Add(item);
                  
                }
                lvColumns.DataSource = dt.DefaultView;
                this.lvColumns.EndUpdate();
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("ReadExpSourceField", exception1);
            }
        }

        /// <summary>
        /// 读取导出匹配规则
        /// </summary>
        private void ReadExpContrast()
        {
            try
            {
                XmlElement element1 = Config.Intance().EleContrast;
                this.lvColumns.BeginUpdate();
                for (int num1 = 0; num1 < element1.ChildNodes.Count; num1++)
                {
                    string text1 = element1.ChildNodes[num1].Attributes["DestField"].Value;
                    string text2 = element1.ChildNodes[num1].Attributes["SourceField"].Value;
                    string text3 = element1.ChildNodes[num1].Attributes["Algorithm"].Value;
                    bool flag1 = element1.ChildNodes[num1].Attributes["IsNew"].Value == "1";
                    DataRow item1 = dt.NewRow();
                    if (flag1)
                    {
                        for (int num2 = 0; num2 < this.gridView1.Columns.Count; num2++)
                        {
                            item1[num2] = "";
                        }
                        item1[0] = this.gridView1.RowCount.ToString();
                        item1[7] = "新增字段";
                        if (!this.SetOneExpDestField(text1, item1, text3))
                        {
                            item1.Table.Rows.Remove(item1);
                        }
                    }
                    else
                    {
                        for (int num3 = 0; num3 < this.gridView1.RowCount; num3++)
                        {
                            if ((this.gridView1.GetDataRow(num3)[1].ToString() == text2) && (this.gridView1.GetDataRow(num3)[3].ToString() == ""))
                            {
                                item1 = this.gridView1.GetDataRow(num3);

                                this.SetOneExpDestField(text1, item1, text3);
                                break;
                            }
                        }
                    }
                }
                this.lvColumns.EndUpdate();
                if (Config.Intance().CurrentDBType == "TXT")
                {
                    this.txtTable.Text = element1.GetAttribute("Delimited");
                }
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("读取导出匹配规则", exception1);
            }
        }

        private void lvColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView1.FocusedRowHandle > 0)
                {
                    DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                    if (Config.Intance().CurrentCfgType == "1")
                    {
                        this.cmbField.Text = dr[1].ToString();
                        this.cmbType.SelectedIndex = this.cmbType.Properties.Items.IndexOf(dr[2].ToString());
                        this.txtAlgorithm.Text = dr[6].ToString();
                        this.txtEmedField.Text = dr[3].ToString();
                        this.txtEmedType.Text = dr[4].ToString();
                        this.txtEmedDefault.Text = dr[5].ToString();
                    }
                    else
                    {
                        this.cmbField.Text = dr[3].ToString();
                        this.cmbType.SelectedIndex = this.cmbType.Properties.Items.IndexOf(dr[4].ToString());
                        this.txtDefaultValue.Text = dr[5].ToString();
                        this.txtAlgorithm.Text = dr[6].ToString();
                        this.txtEmedField.Text = dr[1].ToString();
                        this.txtEmedType.Text = dr[2].ToString();
                        this.btnDel.Enabled = dr[7].ToString() == "新增字段";
                    }
                    this.txtDesc.Text = dr[7].ToString();
                }
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("刷新转换明细的显示", exception1);
            }
        }

        /// <summary>
        /// 设置导出的单个字段信息
        /// </summary>
        /// <param name="_strDestFieldName"></param>
        /// <param name="_tmpItem"></param>
        /// <param name="_strAlgorithm"></param>
        /// <returns></returns>
        private bool SetOneExpDestField(string _strDestFieldName, DataRow _tmpItem, string _strAlgorithm)
        {
            try
            {
                XmlElement element1 = (XmlElement)Config.Intance().EleDestination.SelectSingleNode("DestTable");
                for (int num1 = 0; num1 < element1.ChildNodes.Count; num1++)
                {
                    if (element1.ChildNodes[num1].Attributes["Name"].Value == _strDestFieldName)
                    {
                        _tmpItem[3] = _strDestFieldName;
                        _tmpItem[4] = element1.ChildNodes[num1].Attributes["Type"].Value;
                        _tmpItem[5] = element1.ChildNodes[num1].Attributes["Default"].Value;
                        if (Config.Intance().CurrentDBType == "TXT")
                        {
                            _tmpItem[6] = "";
                        }
                        else
                        {
                            _tmpItem[6] = _strAlgorithm;
                        }
                        return true;
                    }
                }
                return false;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("设置导出的单个字段信息", exception1);
                return false;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.CheckField())
                {
                    int num1 = this.gridView1.RowCount + 1;

                    DataRow item1 = dt.NewRow();

                    if (Config.Intance().CurrentCfgType == "0")
                    {
                        item1[0] = "";
                        item1[1] = "";
                        item1[2] = this.cmbField.Text;
                        item1[3] = this.cmbType.Text;
                        item1[4] = this.txtDefaultValue.Text;
                        item1[5] = this.txtAlgorithm.Text;
                        item1[6] = "新增字段";
                    }
                    this.gridView1.FocusedRowHandle = num1;
                }
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("保存按钮事件", exception1);
            }

        }

        private bool CheckField()
        {
            if (((Config.Intance().CurrentDBType == "TXT") && (this.cmbField.Text != "")))
            {
                XtraMessageBox.Show("HIS字段不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                if (dr!= null)
                {
                    if (this.CheckField())
                    {
                        if (Config.Intance().CurrentCfgType == "1")
                        {
                            if (this.cmbField.Text == "")
                            {
                                dr[1] = "";
                                dr[2] = "";
                                dr[6] = this.txtAlgorithm.Text;
                            }
                            else
                            {
                                dr[1] = this.cmbField.Text;
                                dr[2] = this.cmbType.Text;
                                dr[6] = this.txtAlgorithm.Text;
                            }
                        }
                        else if (this.cmbField.Text == "")
                        {
                            dr[3] = "";
                            dr[4] = "";
                            dr[5] = "";
                            dr[6] = "";
                        }
                        else
                        {
                            dr[3] = this.cmbField.Text;
                            dr[4] = this.cmbType.Text;
                            dr[5] = this.txtDefaultValue.Text;
                            dr[6] = this.txtAlgorithm.Text;
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("请选中待修改的字段！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("修改按钮事件", exception1);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if ((this.txtTable.Text == "") && (Config.Intance().CurrentDBType != "TXT"))
            {
                XtraMessageBox.Show("请输入表名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                this.txtTable.Focus();
                base.DialogResult = DialogResult.None;
            }
            else if (!this.SaveConfig())
            {
                XtraMessageBox.Show("保存设置失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!this.CreateSQL())
            {
                if (Config.Intance().CurrentDBType != "TXT")
                {
                    XtraMessageBox.Show("生成SQL语句失败！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else
                {
                    base.DialogResult = DialogResult.None;
                }
            }
            else
            {
                base.Close();
            }
        }

        private bool CreateSQL()
        {
            if (Config.Intance().CurrentCfgType == "1")
            {
                if (Config.Intance().CurrentDBType == "TXT")
                {
                    return true;
                }
                return this.CreateImpSql();
            }
            if (Config.Intance().CurrentDBType == "FOXPRO")
            {
                return this.CreateFoxproExpSql();
            }
            if (Config.Intance().CurrentDBType == "SQLSERVER")
            {
                return this.CreateSqlServerExpSql();
            }
            if (Config.Intance().CurrentDBType == "ORACLE")
            {
                return this.CreateOracleExpSql();
            }
            if (Config.Intance().CurrentDBType == "ACCESS")
            {
                return this.CreateAccessExpSql();
            }
            if (Config.Intance().CurrentDBType == "TXT")
            {
                return true;
            }
            if (Config.Intance().CurrentDBType == "EXCEL")
            {
                return this.CreateExcelExpSql();
            }
            return false;
        }

        private bool SaveConfig()
        {
            bool flag1;
            try
            {
                //if (Config.Intance().CurrentCfgType == "1")
                //{
                //    if (Config.Intance().CurrentDBType == "TXT")
                //    {
                //        return (this.SaveImpHisInfo() && this.SaveConstrast());
                //    }
                //    return ((this.SaveImpHisInfo() && this.SaveImpSourceField()) && this.SaveConstrast());
                //}
                //if (Config.Intance().CurrentDBType == "TXT")
                //{
                //    return ((this.SaveExpHisInfo() && this.SaveExpTxtField()) && this.SaveConstrast());
                //}
                //return ((this.SaveExpHisInfo() && this.SaveExpDestField()) && this.SaveConstrast());
                if (Config.Intance().CurrentCfgType == "1")
                {
                    if (Config.Intance().CurrentDBType == "TXT")
                    {
                        return this.SaveConstrast();
                    }
                    return (this.SaveImpSourceField() && this.SaveConstrast());
                }
                if (Config.Intance().CurrentDBType == "TXT")
                {
                    return (this.SaveExpTxtField() && this.SaveConstrast());
                }
                flag1 = this.SaveExpDestField() && this.SaveConstrast();
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("保存配置数据", exception1);
                return false;
            }
            return flag1;
        }

        private bool CreateImpSql()
        {
            try
            {
                string text1 = "select ";
                for (int num1 = 0; num1 < this.gridView1.RowCount; num1++)
                {
                    string text2;
                    DataRow dr = gridView1.GetDataRow(num1);
                    if (dr[6].ToString() != "")
                    {
                        text2 = dr[6].ToString() + " as " + dr[3].ToString();
                    }
                    else if (dr[1].ToString() != "")
                    {
                        text2 = dr[1].ToString() + " as " + dr[3].ToString();
                    }
                    else if (dr[5].ToString() != "")
                    {
                        text2 = dr[5].ToString() + " as " + dr[3].ToString();
                    }
                    else
                    {
                        text2 = "'' as " + dr[3].ToString();
                    }
                    if (num1 == 0)
                    {
                        text1 = text1 + text2;
                    }
                    else
                    {
                        text1 = text1 + "," + text2;
                    }
                }
                if (Config.Intance().CurrentDBType == "EXCEL")
                {
                    text1 = text1 + " from `" + this.txtTable.Text + "$`";
                }
                else
                {
                    text1 = text1 + " from " + this.txtTable.Text;
                }
                this.sql = text1;
                return true;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("生成导入的SQL", exception1);
                return false;
            }
        }

        private bool CreateFoxproExpSql()
        {
            try
            {
                string text1 = "Insert into " + this.txtTable.Text + " ";
                string text2 = "";
                string text3 = "";
                string text4 = "";
                for (int num1 = 0; num1 < this.gridView1.RowCount; num1++)
                {
                    DataRow dr = gridView1.GetDataRow(num1);
                    if (dr[6].ToString() != "")
                    {
                        if (text2 == "")
                        {
                            text2 = dr[3].ToString();
                        }
                        else
                        {
                            text2 = text2 + "," + dr[3].ToString();
                        }
                        text4 = dr[6].ToString();
                        if (text3 == "")
                        {
                            text3 = text4;
                        }
                        else
                        {
                            text3 = text3 + "," + text4;
                        }
                    }
                    else if (dr[3].ToString() != "")
                    {
                        if (text2 == "")
                        {
                            text2 = dr[3].ToString();
                        }
                        else
                        {
                            text2 = text2 + "," + dr[3].ToString();
                        }
                        if (dr[7].ToString() == "新增字段")
                        {
                            if (dr[4].ToString() == "日期型")
                            {
                                text4 = dr[5].ToString();
                            }
                            else
                            {
                                text4 = "'" + dr[5].ToString() + "'";
                            }
                        }
                        else
                        {
                            text4 = "@" + dr[1].ToString();
                        }
                        if ((dr[3].ToString() != "") && (Config.Intance().CurrentDBType == "FOXPRO"))
                        {
                            if (dr[4].ToString() == "整型")
                            {
                                text4 = "int(val( " + text4 + "))";
                            }
                            else if (dr[4].ToString() == "浮点数")
                            {
                                text4 = "val( " + text4 + ")";
                            }
                            else if (dr[4].ToString() == "日期型")
                            {
                                text4 = "{^" + text4 + "}";
                            }
                        }
                        if (text3 == "")
                        {
                            text3 = text4;
                        }
                        else
                        {
                            text3 = text3 + "," + text4;
                        }
                    }
                }
                text1 = text1 + "( " + text2 + " ) Values ( " + text3 + " )";
                this.sql = text1;
                return true;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("创建导出Foxpro的SQL", exception1);
                return false;
            }
        }

        private bool CreateSqlServerExpSql()
        {
            try
            {
                string text1 = "Insert into " + this.txtTable.Text + " ";
                string text2 = "";
                string text3 = "";
                string text4 = "";
                for (int num1 = 0; num1 < this.gridView1.RowCount; num1++)
                {
                    DataRow dr = gridView1.GetDataRow(num1);
                    if (dr[6].ToString() != "")
                    {
                        if (text2 == "")
                        {
                            text2 = dr[3].ToString();
                        }
                        else
                        {
                            text2 = text2 + "," + dr[3].ToString();
                        }
                        text4 = dr[6].ToString();
                        if (text3 == "")
                        {
                            text3 = text4;
                        }
                        else
                        {
                            text3 = text3 + "," + text4;
                        }
                    }
                    else if (dr[3].ToString() != "")
                    {
                        if (text2 == "")
                        {
                            text2 = dr[3].ToString();
                        }
                        else
                        {
                            text2 = text2 + "," + dr[3].ToString();
                        }
                        if (dr[7].ToString() == "新增字段")
                        {
                            text4 = "'" + dr[5].ToString() + "'";
                        }
                        else
                        {
                            text4 = "@" + dr[1].ToString();
                        }
                        if (dr[3].ToString() != "")
                        {
                            if (dr[4].ToString() == "整型")
                            {
                                text4 = "convert( int, " + text4 + ")";
                            }
                            else if (dr[4].ToString() == "浮点数")
                            {
                                text4 = "convert( numeric, " + text4 + ")";
                            }
                            else if (dr[4].ToString() == "日期型")
                            {
                                text4 = "convert( datetime, " + text4 + ")";
                            }
                        }
                        if (text3 == "")
                        {
                            text3 = text4;
                        }
                        else
                        {
                            text3 = text3 + "," + text4;
                        }
                    }
                }
                text1 = text1 + "( " + text2 + " ) Select " + text3;
                this.sql = text1;
                return true;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("创建导出Sql Server的SQL", exception1);
                return false;
            }
        }

        private bool CreateOracleExpSql()
        {
            try
            {
                string text1 = "Insert into " + this.txtTable.Text + " ";
                string text2 = "";
                string text3 = "";
                string text4 = "";
                for (int num1 = 0; num1 < this.gridView1.RowCount; num1++)
                {
                    DataRow dr = gridView1.GetDataRow(num1);
                    if (dr[6].ToString() != "")
                    {
                        if (text2 == "")
                        {
                            text2 = dr[3].ToString();
                        }
                        else
                        {
                            text2 = text2 + "," + dr[3].ToString();
                        }
                        text4 = dr[6].ToString();
                        if (text3 == "")
                        {
                            text3 = text4;
                        }
                        else
                        {
                            text3 = text3 + "," + text4;
                        }
                    }
                    else if (dr[3].ToString() != "")
                    {
                        if (text2 == "")
                        {
                            text2 = dr[3].ToString();
                        }
                        else
                        {
                            text2 = text2 + "," + dr[3].ToString();
                        }
                        if (dr[7].ToString() == "新增字段")
                        {
                            text4 = "'" + dr[5].ToString() + "'";
                        }
                        else
                        {
                            text4 = "@" + dr[1].ToString();
                        }
                        if (dr[3].ToString() != "")
                        {
                            if (dr[4].ToString() == "整型")
                            {
                                text4 = "to_number(" + text4 + ")";
                            }
                            else if (dr[4].ToString() == "浮点数")
                            {
                                text4 = "to_number(" + text4 + ")";
                            }
                            else if (dr[4].ToString() == "日期型")
                            {
                                text4 = "to_date(" + text4 + ",'yyyy-mm-dd hh24:mi:ss')";
                            }
                        }
                        if (text3 == "")
                        {
                            text3 = text4;
                        }
                        else
                        {
                            text3 = text3 + "," + text4;
                        }
                    }
                }
                text1 = text1 + "( " + text2 + " ) Select " + text3 + " from dual";
                this.sql = text1;
                return true;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("创建导出Oracle的SQL", exception1);
                return false;
            }
        }

        private bool CreateAccessExpSql()
        {
            try
            {
                string text1 = "Insert into " + this.txtTable.Text + " ";
                string text2 = "";
                string text3 = "";
                string text4 = "";
                for (int num1 = 0; num1 < this.gridView1.RowCount; num1++)
                {
                    DataRow dr = gridView1.GetDataRow(num1);
                    if (dr[6].ToString() != "")
                    {
                        if (text2 == "")
                        {
                            text2 = dr[3].ToString();
                        }
                        else
                        {
                            text2 = text2 + "," + dr[3].ToString();
                        }
                        text4 = dr[6].ToString();
                        if (text3 == "")
                        {
                            text3 = text4;
                        }
                        else
                        {
                            text3 = text3 + "," + text4;
                        }
                    }
                    else if (dr[3].ToString() != "")
                    {
                        if (text2 == "")
                        {
                            text2 = dr[3].ToString();
                        }
                        else
                        {
                            text2 = text2 + "," + dr[3].ToString();
                        }
                        if (dr[7].ToString() == "新增字段")
                        {
                            if (dr[4].ToString() == "日期型")
                            {
                                text4 = dr[5].ToString();
                            }
                            else
                            {
                                text4 = "'" + dr[5].ToString() + "'";
                            }
                        }
                        else
                        {
                            text4 = "@" + dr[1].ToString();
                        }
                        if (dr[3].ToString() != "")
                        {
                            if (dr[4].ToString() == "整型")
                            {
                                text4 = "int(val( " + text4 + "))";
                            }
                            else if (dr[4].ToString() == "浮点数")
                            {
                                text4 = "val( " + text4 + ")";
                            }
                            else if (dr[4].ToString() == "日期型")
                            {
                                text4 = "#" + text4 + "#";
                            }
                        }
                        if (text3 == "")
                        {
                            text3 = text4;
                        }
                        else
                        {
                            text3 = text3 + "," + text4;
                        }
                    }
                }
                text1 = text1 + "( " + text2 + " ) Select " + text3;
                this.sql = text1;
                return true;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("创建导出Access的SQL", exception1);
                return false;
            }
        }

        private bool CreateExcelExpSql()
        {
            try
            {
                string text1 = "Insert into [" + this.txtTable.Text.Trim() + "$] ";
                string text2 = "";
                string text3 = "";
                string text4 = "";
                for (int num1 = 0; num1 < this.gridView1.RowCount; num1++)
                {
                    DataRow dr = gridView1.GetDataRow(num1);
                    if (dr[6].ToString() != "")
                    {
                        if (text2 == "")
                        {
                            text2 = dr[3].ToString();
                        }
                        else
                        {
                            text2 = text2 + "," + dr[3].ToString();
                        }
                        text4 = dr[6].ToString();
                        if (text3 == "")
                        {
                            text3 = text4;
                        }
                        else
                        {
                            text3 = text3 + "," + text4;
                        }
                    }
                    else if (dr[3].ToString() != "")
                    {
                        if (text2 == "")
                        {
                            text2 = dr[3].ToString();
                        }
                        else
                        {
                            text2 = text2 + "," + dr[3].ToString();
                        }
                        if (dr[7].ToString() == "新增字段")
                        {
                            text4 = "'" + dr[5].ToString() + "'";
                        }
                        else
                        {
                            text4 = "@" + dr[1].ToString();
                        }
                        if (text3 == "")
                        {
                            text3 = text4;
                        }
                        else
                        {
                            text3 = text3 + "," + text4;
                        }
                    }
                }
                text1 = text1 + "( " + text2 + " ) Select " + text3;
                this.sql = text1;
                return true;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("创建导出Excel的SQL", exception1);
                return false;
            }
        }

        private bool SaveImpHisInfo()
        {
            try
            {
                if (Config.Intance().CurrentDBType != "TXT")
                {
                    Config.Intance().EleSource.SelectSingleNode("SourceTable").Attributes["TableName"].Value = this.txtTable.Text;
                    Config.Intance().SaveSourceTable(Config.Intance().CurrentCfgFile, (XmlElement)Config.Intance().EleSource.SelectSingleNode("SourceTable"));
                }
                return true;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("保存导入的HIS表信息", exception1);
                return false;
            }
        }

        private bool SaveConstrast()
        {
            try
            {
                string text1 = Config.Intance().EleContrast.GetAttribute("Delimited");
                Config.Intance().EleContrast.RemoveAll();
                Config.Intance().EleContrast.SetAttribute("Delimited", text1);
                XmlDocument document1 = Config.Intance().EleContrast.OwnerDocument;
                //start add by gaoyuan 20070329
                Config.Intance().DestTable.SetAttribute("TableName", txtTable.Text.Trim());
                Config.Intance().SaveDestTable(Config.Intance().CurrentCfgFile, Config.Intance().RootConfig);
                //end add by gaoyuan 20070329
                for (int num1 = 0; num1 < this.gridView1.RowCount; num1++)
                {
                    DataRow dr = gridView1.GetDataRow(num1);
                    if ((dr[3].ToString() != "") | (dr[6].ToString() != ""))
                    {
                        XmlElement element1 = document1.CreateElement("Contrast");
                        XmlAttribute attribute1 = document1.CreateAttribute("SourceField");
                        attribute1.Value = dr[1].ToString();
                        element1.Attributes.Append(attribute1);
                        attribute1 = document1.CreateAttribute("DestField");
                        attribute1.Value = dr[3].ToString();
                        element1.Attributes.Append(attribute1);
                        attribute1 = document1.CreateAttribute("Algorithm");
                        attribute1.Value = dr[6].ToString();
                        element1.Attributes.Append(attribute1);
                        attribute1 = document1.CreateAttribute("IsNew");
                        if (dr[7].ToString().Trim() == "新增字段")
                        {
                            attribute1.Value = "1";
                        }
                        else
                        {
                            attribute1.Value = "0";
                        }
                        element1.Attributes.Append(attribute1);
                        attribute1 = document1.CreateAttribute("DestDBType");
                        attribute1.Value = dr[4].ToString();
                        element1.Attributes.Append(attribute1);
                        Config.Intance().EleContrast.AppendChild(element1);
                    }
                }
                if (Config.Intance().CurrentDBType == "TXT")
                {
                    Config.Intance().EleContrast.SetAttribute("Delimited", this.txtTable.Text);
                }
                Config.Intance().SaveConstrast(Config.Intance().CurrentCfgFile, Config.Intance().EleContrast);
                return true;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("保存转换规则", exception1);
                return false;
            }
        }

        private bool SaveImpSourceField()
        {
            try
            {
                XmlElement element1 = (XmlElement)Config.Intance().EleSource.SelectSingleNode("SourceTable");
                string text1 = element1.GetAttribute("TableName");
                element1.RemoveAll();
                element1.SetAttribute("TableName", text1);
                XmlDocument document1 = element1.OwnerDocument;
                int num1 = 1;
                for (int num2 = 0; num2 < this.gridView1.RowCount; num2++)
                {
                    DataRow dr = gridView1.GetDataRow(num1);
                    if (dr[1].ToString() != "")
                    {
                        XmlElement element2 = document1.CreateElement("SourceField");
                        XmlAttribute attribute1 = document1.CreateAttribute("Index");
                        attribute1.Value = num1.ToString();
                        element2.Attributes.Append(attribute1);
                        attribute1 = document1.CreateAttribute("Name");
                        attribute1.Value = dr[1].ToString();
                        element2.Attributes.Append(attribute1);
                        attribute1 = document1.CreateAttribute("Type");
                        attribute1.Value = dr[2].ToString();
                        element2.Attributes.Append(attribute1);
                        attribute1 = document1.CreateAttribute("Length");
                        element2.Attributes.Append(attribute1);
                        attribute1 = document1.CreateAttribute("Default");
                        element2.Attributes.Append(attribute1);
                        attribute1 = document1.CreateAttribute("Desc");
                        element2.Attributes.Append(attribute1);
                        element1.AppendChild(element2);
                        num1++;
                    }
                }
                Config.Intance().SaveSourceTableField(Config.Intance().CurrentCfgFile, element1);
                return true;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("保存导入的源字段", exception1);
                return false;
            }
        }

        private bool SaveExpHisInfo()
        {
            try
            {
                if (Config.Intance().CurrentDBType != "TXT")
                {
                    Config.Intance().EleDestination.SelectSingleNode("DestTable").Attributes["TableName"].Value = this.txtTable.Text;
                    Config.Intance().SaveDestTable(Config.Intance().CurrentCfgFile, (XmlElement)Config.Intance().EleSource.SelectSingleNode("SourceTable"));
                }
                return true;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("保存导出的HIS表信息", exception1);
                return false;
            }
        }

        private bool SaveExpTxtField()
        {
            try
            {
                for (int num1 = 0; num1 < this.gridView1.RowCount; num1++)
                {
                    DataRow dr = gridView1.GetDataRow(num1);
                    if (dr[5].ToString() != "")
                    {
                        XmlNodeList list1 = Config.Intance().EleDestination.SelectSingleNode("DestTable").ChildNodes;
                        for (int num2 = 0; num2 < list1.Count; num2++)
                        {
                            if (list1[num2].Attributes["Name"].Value == dr[3].ToString())
                            {
                                list1[num2].Attributes["Default"].Value = dr[5].ToString();
                                break;
                            }
                        }
                    }
                }
                Config.Intance().SaveDestTableField(Config.Intance().CurrentCfgFile, (XmlElement)Config.Intance().EleDestination.SelectSingleNode("DestTable"));
                return true;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("保存导出文本时，文本的定义信息", exception1);
                return false;
            }
        }

        private bool SaveExpDestField()
        {
            try
            {
                XmlElement element1 = (XmlElement)Config.Intance().EleDestination.SelectSingleNode("DestTable");
                string text1 = element1.GetAttribute("TableName");
                element1.RemoveAll();
                element1.SetAttribute("TableName", text1);
                XmlDocument document1 = element1.OwnerDocument;
                int num1 = 1;
                for (int num2 = 0; num2 < this.gridView1.RowCount; num2++)
                {
                    DataRow dr = gridView1.GetDataRow(num1-1);
                    if (dr[3].ToString() != "")
                    {
                        XmlElement element2 = document1.CreateElement("DestField");
                        XmlAttribute attribute1 = document1.CreateAttribute("Index");
                        attribute1.Value = num1.ToString();
                        element2.Attributes.Append(attribute1);
                        attribute1 = document1.CreateAttribute("Name");
                        attribute1.Value = dr[3].ToString();
                        element2.Attributes.Append(attribute1);
                        attribute1 = document1.CreateAttribute("Type");
                        attribute1.Value = dr[4].ToString();
                        element2.Attributes.Append(attribute1);
                        attribute1 = document1.CreateAttribute("Length");
                        element2.Attributes.Append(attribute1);
                        attribute1 = document1.CreateAttribute("Default");
                        attribute1.Value = dr[5].ToString();
                        element2.Attributes.Append(attribute1);
                        attribute1 = document1.CreateAttribute("Desc");
                        attribute1.Value = "";
                        element2.Attributes.Append(attribute1);
                        element1.AppendChild(element2);
                        num1++;
                    }
                }
                Config.Intance().SaveDestTableField(Config.Intance().CurrentCfgFile, element1);
                return true;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("保存导出的目的字段", exception1);
                return false;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                //原有代码
                //if ((this.lvColumns.SelectedItems.Count > 0) && (XtraMessageBox.Show("要删除这条记录吗？","提示",MessageBoxButtons.YesNo)==DialogResult.Yes))
                //{
                //    for (int num1 = this.lvColumns.SelectedItems[0].Index; num1 < this.lvColumns.Items.Count; num1++)
                //    {
                //        this.lvColumns.Items[num1].Text = num1.ToString();
                //    }
                //    this.lvColumns.SelectedItems[0].Remove();
                //}
                if ((dr!=null) && (XtraMessageBox.Show("要删除这条记录吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes))
                {
                    for (int num1 = gridView1.FocusedRowHandle; num1 < this.gridView1.RowCount; num1++)
                    {
                        dr["num"] = num1.ToString();
                    }
                    dr.Table.Rows.Remove(dr);
                }
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("删除新增字段", exception1);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtAlgorithm_TextChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (this.gridView1.FocusedRowHandle >= 0)
                {
                    DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                    if (Config.Intance().CurrentCfgType == "1")
                    {
                        this.cmbField.Text = dr[1].ToString();
                        this.cmbType.SelectedIndex = this.cmbType.Properties.Items.IndexOf(dr[2].ToString());
                        this.txtAlgorithm.Text = dr[6].ToString();
                        this.txtEmedField.Text = dr[3].ToString();
                        this.txtEmedType.Text = dr[4].ToString();
                        this.txtEmedDefault.Text = dr[5].ToString();
                    }
                    else
                    {
                        this.cmbField.Text = dr[3].ToString();
                        this.cmbType.SelectedIndex = this.cmbType.Properties.Items.IndexOf(dr[4].ToString());
                        this.txtDefaultValue.Text = dr[5].ToString();
                        this.txtAlgorithm.Text = dr[6].ToString();
                        this.txtEmedField.Text = dr[1].ToString();
                        this.txtEmedType.Text = dr[2].ToString();
                        this.btnDel.Enabled = dr[7].ToString() == "新增字段";
                    }
                    this.txtDesc.Text = dr[7].ToString();
                }
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("刷新转换明细的显示", exception1);
            }
        }

        private void FormColumns_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }
    }
}