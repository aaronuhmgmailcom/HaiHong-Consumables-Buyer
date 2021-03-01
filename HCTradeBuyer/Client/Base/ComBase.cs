//======================================================================================
//	Copyright (c)  Emedchina
//
//	�� �� ��:	ComBase.cs   
//	�� �� ��:	������
//	��������:	2006-6-8
//	��������:	��ͨ��ҳ�洦��
//	�� �� ��: 
//	�޸�����:
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
        /// �ݹ�����ҳ��ؼ�����
        /// </summary>
        /// <param name="p_Controls"></param>
        /// <param name="e">������check����</param>
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
                //�����ı����С
                TextBox txtbox = ctl as TextBox;
                //����TextBox Tag ��־�ж� �����Ƿ���� edited by xujc 2006-06-26
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


                
                //�趨��ť��ݼ�
                Button btn = ctl as Button;
                if (btn != null)
                {
                    setShortcutKey(btn);
                }
                //�趨����
                if (ctl.TabIndex == 0)
                {
                    if (ctl.CanSelect)
                    {
                        ctl.Select();
                        ctl.Focus();
                    }
                }
                //����datagridview��ʽ
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
        /// ������ļ��
        /// </summary>
        /// <param name="sender"></param>
        public void CheckControls(object sender)
        {
            

            
            //ת�������ַ�
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
        /// ������е�������
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
                //ת�������ַ�
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
        /// �趨��ť��ݼ�
        /// </summary>
        /// <param name="btn">��ť����</param>
        private void setShortcutKey(Button btn)
        {
            string btnText = btn.Text.ToString();
            switch (btnText)
            {
                case "��ѯ":
                    btnText = btnText + "(&Q)";
                    break;
                case "����":
                    btnText = btnText + "(&S)";
                    break;
                case "��ӡ":
                    btnText = btnText + "(&P)";
                    break;
                case "����Excel":
                    btnText = btnText + "(&X)";
                    break;
                case "�ر�":
                    btnText = btnText + "(&C)";
                    break;

            }
            btn.Text = btnText;
        }
    }
}
