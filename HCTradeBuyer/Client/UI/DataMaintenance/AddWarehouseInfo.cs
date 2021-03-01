//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	AddWarehouseInfo.cs    
//	创 建 人:	yanbing
//	创建日期:	2007-10-8
//	功能描述:	增加库房信息
//	修 改 人: 
//	修改日期:
//	主要修改内容:
//=====================================================================================
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Emedchina.TradeAssistant.Model.DataMaintenance;
using Emedchina.TradeAssistant.Client.BLL.DataMaintenance;
using Emedchina.TradeAssistant.Client.DAL.DataMaintenance;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Client.Base;

namespace Emedchina.TradeAssistant.Client.UI.DataMaintenance
{
    public partial class AddWarehouseInfo : BaseForm
    {
        private WarehouseModel warehouseModel = new WarehouseModel();
        private bool IsSave;
        WarehouseMgrBLL bll = WarehouseMgrBLL.GetInstance();

        public AddWarehouseInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbSave_Click(object sender, EventArgs e)
        {
            LogedInUser CurrentUser = ClientSession.GetInstance().CurrentUser;
            //检查输入是否空
            if (checkTxtEmpty())
            {
                try
                {
                    if (bll.JudgeCode(this.warehouseModel.StoneName) < 1)
                    {
                        bll.InsertWarehouseInfo(this.warehouseModel, CurrentUser);
                        XtraMessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ClearAll();
                        this.IsSave = true;
                    }
                    else
                    {
                        XtraMessageBox.Show("此库房名称已存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("保存时发送错误：" + ex.Message.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        /// <summary>
        /// 输入空检查函数
        /// </summary>
        private bool checkTxtEmpty()
        {
            warehouseModel.Stone_address = this.teAddress.Text;
            warehouseModel.Linman=this.teLinkMan.Text;
            warehouseModel.Linktel=this.teLinkTel.Text;
            warehouseModel.StoneName=this.teWarehouseName.Text;
            warehouseModel.Type = Convert.ToString(this.rgtype.SelectedIndex+1);

            //if (this.rgtype.SelectedIndex == 0)
            //    type = "普通";
            //else
            //    type = "其他";

            if (string.IsNullOrEmpty(warehouseModel.StoneName))
            {
                XtraMessageBox.Show("请输入库房名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrEmpty(warehouseModel.Linman))
            {
                XtraMessageBox.Show("请输入库房联系人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrEmpty(warehouseModel.Linktel))
            {
                XtraMessageBox.Show("请输入库房联系电话！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrEmpty(warehouseModel.Stone_address))
            {
                XtraMessageBox.Show("请输入库房地址！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
           
        }

        /// <summary>
        /// 清空文本框
        /// </summary>
        private void ClearAll()
        {
            this.teAddress.Text = "";
            this.teLinkMan.Text = "";
            this.teLinkTel.Text = "";
            this.teWarehouseName.Text = "";
            
        }

        private void AddWarehouseInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }
    }
}