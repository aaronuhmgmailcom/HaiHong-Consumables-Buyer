//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	WarehouseMgr.cs    
//	创 建 人:	yanbing
//	创建日期:	2007-10-8
//	功能描述:	库房信息维护
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
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Client.BLL.DataMaintenance;
using Emedchina.TradeAssistant.Client.DAL.DataMaintenance;
using Emedchina.TradeAssistant.Model.User;

namespace Emedchina.TradeAssistant.Client.UI.DataMaintenance
{
    public partial class WarehouseMgr : BaseForm
    {
        private DataTable DtWarehouse;
        public WarehouseMgr()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbAdd_Click(object sender, EventArgs e)
        {
            AddWarehouseInfo frmAddWarehouseInfo = new AddWarehouseInfo();
            frmAddWarehouseInfo.ShowDialog();
            bindingList();

           
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbModify_Click(object sender, EventArgs e)
        {
            ModifyWarehouseInfo frmModifyWarehouseInfo = new ModifyWarehouseInfo();

            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (dr != null)
            {
                frmModifyWarehouseInfo.name = dr["STORE_NAME"].ToString();
                frmModifyWarehouseInfo.linkMan = dr["LINKMAN"].ToString();
                frmModifyWarehouseInfo.linkTel = dr["TEL"].ToString();
                frmModifyWarehouseInfo.address = dr["STORE_ADDRESS"].ToString();
                frmModifyWarehouseInfo.state = dr["ENABLE_FLAG"].ToString();
                frmModifyWarehouseInfo.id = dr["id"].ToString();
                frmModifyWarehouseInfo.type = dr["type"].ToString();

                frmModifyWarehouseInfo.ShowDialog();
                bindingList();

                for (int i = 0; i < this.gridView3.RowCount; i++)
                {
                    DataRow drrow = gridView3.GetDataRow(i);
                    if (drrow["id"].ToString() == dr["id"].ToString())
                    {
                        this.gridView3.FocusedRowHandle = i;
                    }
                }

            }
        }

        private void WarehouseMgr_Load(object sender, EventArgs e)
        {
            bindingList();
        }

        private void bindingList()
        {
            LogedInUser CurrentUser = ClientSession.GetInstance().CurrentUser;
            DtWarehouse = WarehouseMgrBLL.GetInstance().GetWarehouseInfoDt(CurrentUser);

            base.InitFromCacheByData(DtWarehouse);

            try
            {
                this.bindingSourceWarehouse.DataSource = null;
                this.bindingSourceWarehouse.DataSource = DtWarehouse.DefaultView;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbDelete_Click(object sender, EventArgs e)
        {
            //仓库ID
            string strWarehouseId = string.Empty;
            LogedInUser CurrentUser = ClientSession.GetInstance().CurrentUser;
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (dr != null)
            {
                strWarehouseId = dr["id"].ToString();

                if (strWarehouseId != null)
                {
                    //if (WarehouseMgrBLL.GetInstance().JudgeCanUse(strWarehouseId) < 1)
                    //{
                        if (XtraMessageBox.Show("确认作废记录？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            try
                            {
                                WarehouseMgrBLL.GetInstance().Delete(strWarehouseId, CurrentUser);
                                for (int i = 0; i < this.gridView3.RowCount; i++)
                                {
                                    DataRow drrow = gridView3.GetDataRow(i);
                                    if (drrow["id"].ToString() == dr["id"].ToString())
                                    {
                                        drrow["state"] = "不可用";
                                        this.gridView3.FocusedRowHandle = i;
                                    }
                                }
                                XtraMessageBox.Show("作废成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show("保存时发送错误：" + ex.Message.ToString());
                            }
                            finally
                            {
                                //this.bindingList();
                                
                            }
                           
                        }
                    //}
                    //else
                    //{
                    //    XtraMessageBox.Show(" 库房可用，无法删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}


                }
              
            }
        }


        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 文本框变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void teWarehouseName_TextChanged(object sender, EventArgs e)
        {
            ItemFilter();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbSearch_Click(object sender, EventArgs e)
        {
            //LogedInUser CurrentUser = ClientSession.GetInstance().CurrentUser;
            //DtWarehouse = WarehouseMgrBLL.GetInstance().GetWarehouseInfoDt(CurrentUser);
            //base.InitFromCacheByData(DtWarehouse);

            bindingList();
            ItemFilter();
        }

        /// <summary>
        /// 设置ItemFilter过滤列表
        /// </summary>
        private void ItemFilter()
        {
            string sWarehouseName = this.teWarehouseName.Text;

            StringBuilder filter = new StringBuilder();
            filter.Append("1=1");
            if (!string.IsNullOrEmpty(sWarehouseName))
                filter.AppendFormat(" and (STORE_NAME like '%{0}%' )", sWarehouseName);
          
            this.cachedDataView.RowFilter = filter.ToString();

        }

        private void gridView3_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            int rowIndex = e.RowHandle;
            if (rowIndex >= 0)
            {
                rowIndex++;
                e.Info.DisplayText = rowIndex.ToString();
            }
            e.Info.ImageIndex = -1;
        }

        private void gridView3_RowCountChanged(object sender, EventArgs e)
        {
            labelControlCount.Text = "    共 " + gridView3.RowCount + " 条数据";
        }


    }
}