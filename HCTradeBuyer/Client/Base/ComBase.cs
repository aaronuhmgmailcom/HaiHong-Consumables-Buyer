//======================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	ComBase.cs   
//	创 建 人:	梁晓奕
//	创建日期:	2006-6-8
//	功能描述:	共通的页面处理
//	修 改 人: 
//	修改日期:
//=====================================================================================
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Emedchina.Commons;


namespace Emedchina.TradeAssistant.Client.Base
{
    public class ComBase
    {

        /// <summary>
        /// 递归设置页面控件属性
        /// </summary>
        /// <param name="p_Controls"></param>
        /// <param name="e">输入框的check方法</param>
        public void setControls(System.Windows.Forms.Control.ControlCollection p_Controls,EventHandler e)
        {
            Size size = new Size();
            size.Height = 23;
            size.Width = 100;
            //DataGridViewCellStyle dataGridViewCellStyle = null;
            
            //System.Windows.Forms.Control.ControlCollection p_Controls = frm.panelMain.Controls;

            foreach (System.Windows.Forms.Control ctl in p_Controls)
            {
                FlowLayoutPanel flpan = ctl as FlowLayoutPanel;
                if (flpan != null)
                {
                    setControls(flpan.Controls, e);
                    continue;
                }
                GroupBox grp = ctl as GroupBox;
                if (grp != null)
                {
                    setControls(grp.Controls, e);
                    continue;
                }

                Panel pan = ctl as Panel;
                if (pan != null)
                {
                    setControls(pan.Controls, e);
                    continue;
                }
                TabControl tabcontrol = ctl as TabControl;
                if (tabcontrol != null)
                {
                    setControls(tabcontrol.Controls,e);
                    continue;
                }
                TabPage tabpage = ctl as TabPage;
                if (tabpage != null)
                {
                    setControls(tabpage.Controls,e);
                    continue;
                }
                TableLayoutPanel tlpan = ctl as TableLayoutPanel;
                if (tlpan != null)
                {
                    setControls(tlpan.Controls,e);
                    continue;
                }
                UserControl uc = ctl as UserControl;
                if (uc != null)
                {
                    setControls(uc.Controls,e);
                    continue;
                }
                //设置文本框大小
                TextBox txtbox = ctl as TextBox;
                //增加TextBox Tag 标志判断 控制是否基层 edited by xujc 2006-06-26
                if ((txtbox != null) && (txtbox.Tag == null))
                {
                    txtbox.Size = size;
                    txtbox.Leave += new System.EventHandler(e);
                }
                //DataGridViewTextBoxColumn dgvtxtbox = ctl as DataGridViewTextBoxColumn;
                //if ((dgvtxtbox != null) && (dgvtxtbox.Tag == null))
                //{
                //    //txtbox.Size = size;
                //    dgvtxtbox.Leave += new System.EventHandler(e);
                //}


                
                //设定按钮快捷键
                Button btn = ctl as Button;
                if (btn != null)
                {
                    setShortcutKey(btn);
                }
                //设定焦点
                if (ctl.TabIndex == 0)
                {
                    if (ctl.CanSelect)
                    {
                        ctl.Select();
                        ctl.Focus();
                    }
                }
                //设置datagridview格式
                DataGridView dgv = ctl as DataGridView;
                if (dgv != null)
                {
                    dgv.RowHeadersVisible = false;
                    dgv.AllowUserToResizeRows = false;

                    dgv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.MediumSlateBlue; 
                    
                    if (dgv.Tag != null)
                    {
                        if (dgv.Tag.ToString().Equals("1"))
                        {
                            dgv.DefaultCellStyle.NullValue = "-";
                        }
                    }
                    setControls(dgv.Controls, e);
                    continue;
                    
                }


            }
        }
        /// <summary>
        /// 输入项的检查
        /// </summary>
        /// <param name="sender"></param>
        public void CheckControls(object sender)
        {
            

            
            //转换特殊字符
            TextBox txtbox = sender as TextBox;
            if (txtbox != null)
            {
                //txtbox.
                string temp = StringUtils.repalceSepStr(txtbox.Text.ToString());
                if (!temp.Equals(txtbox.Text.ToString()))
                {

                    txtbox.Text = StringUtils.repalceSepStr(txtbox.Text.ToString());
                }
            }
                


        }
        /// <summary>
        /// 检查所有的输入项
        /// </summary>
        /// <param name="p_Controls"></param>
        public void CheckAllControls(System.Windows.Forms.Control.ControlCollection p_Controls)
        {

            foreach (System.Windows.Forms.Control ctl in p_Controls)
            {
                FlowLayoutPanel flpan = ctl as FlowLayoutPanel;
                if (flpan != null)
                {
                    CheckAllControls(flpan.Controls);
                    continue;
                }
                GroupBox grp = ctl as GroupBox;
                if (grp != null)
                {
                    CheckAllControls(grp.Controls);
                    continue;
                }

                Panel pan = ctl as Panel;
                if (pan != null)
                {
                    CheckAllControls(pan.Controls);
                    continue;
                }
                TabControl tabcontrol = ctl as TabControl;
                if (tabcontrol != null)
                {
                    CheckAllControls(tabcontrol.Controls);
                    continue;
                }
                TabPage tabpage = ctl as TabPage;
                if (tabpage != null)
                {
                    CheckAllControls(tabpage.Controls);
                    continue;
                }
                TableLayoutPanel tlpan = ctl as TableLayoutPanel;
                if (tlpan != null)
                {
                    CheckAllControls(tlpan.Controls);
                    continue;
                }
                UserControl uc = ctl as UserControl;
                if (uc != null)
                {
                    CheckAllControls(uc.Controls);
                    continue;
                }
                //转换特殊字符
                TextBox txtbox = ctl as TextBox;
                if (txtbox != null)
                {
                    //txtbox.
                    string temp = StringUtils.repalceSepStr(txtbox.Text.ToString());
                    if (!temp.Equals(txtbox.Text.ToString()))
                    {

                        txtbox.Text = StringUtils.repalceSepStr(txtbox.Text.ToString());
                    }
                }
            }



        }
        /// <summary>
        /// 设定按钮快捷键
        /// </summary>
        /// <param name="btn">按钮对象</param>
        private void setShortcutKey(Button btn)
        {
            string btnText = btn.Text.ToString();
            switch (btnText)
            {
                case "查询":
                    btnText = btnText + "(&Q)";
                    break;
                case "保存":
                    btnText = btnText + "(&S)";
                    break;
                case "打印":
                    btnText = btnText + "(&P)";
                    break;
                case "生成Excel":
                    btnText = btnText + "(&X)";
                    break;
                case "关闭":
                    btnText = btnText + "(&C)";
                    break;

            }
            btn.Text = btnText;
        }
    }
}
