using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emedchina.Commons;
using DevExpress.Utils;
using DevExpress.XtraEditors;

using Emedchina.TradeAssistant.Client.UI.Report.ReportFile;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Client.BLL.Report;
using Emedchina.TradeAssistant.Model.Order.PurchaseHandle;
using Emedchina.TradeAssistant.Client.BLL;
using Emedchina.TradeAssistant.Client.BLL.Order.PurchaseHandle;
using Emedchina.TradeAssistant.Client.DAL.Order.PurchaseHandle;
using Emedchina.TradeAssistant.Client.UI.Report.ReportForm;
using Emedchina.TradeAssistant.Model.CommInfo;
using Emedchina.TradeAssistant.Client.Common;


namespace Emedchina.TradeAssistant.Client.UI.Order.PurchaseHandle
{
    public partial class FormPurchaseItem : Emedchina.TradeAssistant.Client.Base.BaseForm
    {      
        //临时
        private UserInfoModel usInfo = new UserInfoModel();
        //采购单保存输入模型
        private PurchaseSaveModel purchaseSaveModel = new PurchaseSaveModel();       
        //实例化采购单明细实体层       
        PurchaseItemModel PurchaseItem = new PurchaseItemModel();
        //采购单明细数据
        private DataTable dtPurchaseItem =null;// new DataTable();
        //采购单datarow
        DataRow purchaseDataRow = null;       
        public static FormPurchaseItem GetInstance(FormPurchaseBuild inForm, DataRow inDataRow)
        {
            return new FormPurchaseItem("编辑采购单", inDataRow);
        }

        #region 创建窗体 FormPurchaseCreate
        /// <summary>
        /// 创建窗体
        /// </summary>
        public FormPurchaseItem(string titleName, DataRow inDataRow)
        {
            InitializeComponent();
            this.Text = titleName;         
            this.purchaseDataRow = inDataRow;         
            //据此判断是否存在采购单
            purchaseSaveModel.PurchaseId = (inDataRow == null ? "" : inDataRow["id"].ToString());

            if (String.IsNullOrEmpty(purchaseSaveModel.PurchaseId))
            {
                lcCreater.Text = base.CurrentUserName;
                lcCreateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
               // btnPrint.Enabled = false;
                IniTempHitCommData();
            }
            else
            {
                lcCreater.Text = inDataRow["CREATE_USER_NAME"].ToString();
                lbeEditDate.Text = inDataRow["MODIFY_DATE"].ToString();
                lcPurchaseCode.Text = inDataRow["code"].ToString();
                lcCreateTime.Text = inDataRow["create_date1"].ToString();
                lcTotal.Text = float.Parse(inDataRow["TOTAL_SUM"].ToString()).ToString("###,###0.00") + "元";
                lcstate.Text = inDataRow["purchase_state"].ToString();
                lcquick.Text = inDataRow["purchase_QUICKSEND_LEVEL"].ToString();
                //tbRemark.Text = inDataRow["purchase_remark"].ToString();
                //    //从采购单明细缓存中载入已知采购单明细数据
                IniTempHitCommData();
                getPurchaseItemFromCache();
                InitGrid_Cmb();//初始化规格，型号，库房
                
            }          

        }
        #endregion

        #region 从缓存中载入已知采购单明细数据 getPurchaseItemFromCache
        /// <summary>
        /// 从缓存中载入已知采购单明细数据
        /// </summary>
        private void getPurchaseItemFromCache()
        {
         DataTable dt = PurchaseClientDao.GetInstance().getPurchaseItem(base.CurrentUserOrgId, purchaseSaveModel.PurchaseId);
         foreach (DataRow r in dt.Rows)
         {
             DataRow dr = dtPurchaseItem.NewRow();
             dr["ID"] = r["ID"];
             dr["PROJECT_ID"] = r["PROJECT_ID"];
             dr["PURCHASE_ID"] = r["PURCHASE_ID"];
             dr["SPEC_ID"] = r["SPEC_ID"];
             dr["MODEL_ID"] = r["MODEL_ID"];
             dr["STORE_ROOM_ID"] = r["STORE_ROOM_ID"];
             dr["DATA_PRODUCT_ID"] = r["DATA_PRODUCT_ID"];
             dr["PROJECT_PROD_ID"] = r["PROJECT_PROD_ID"];
             dr["PRODUCT_NAME"] = r["PRODUCT_NAME"];//商品名
             dr["BASE_MEASURE"] = r["BASE_MEASURE"];
             dr["MANUFACTURE_NAME"] = r["MANUFACTURE_NAME"];
             dr["MANUFACTURE_NAME_ABBR"] = r["MANUFACTURE_NAME_ABBR"];
             dr["SALER_NAME"] = r["SALER_NAME"];
             dr["COMMON_NAME"] = r["COMMON_NAME"];
             dr["BRAND"] = r["BRAND"];
             dr["TRADE_PRICE"] = r["TRADE_PRICE"];
             dr["purchase_QUICKSEND"] = r["purchase_QUICKSEND"];
             dr["SENDER_ID"] = r["SENDER_ID"];
             dr["SENDER_NAME"] = r["SENDER_NAME"];
             dr["SENDER_NAME_ABBR"] = r["SENDER_NAME_ABBR"];
             dr["AMOUNT"] = r["AMOUNT"];
             dr["BASE_MEASURE"] = r["BASE_MEASURE"];
             dr["SPEC"] = r["SPEC"];
             dr["MODEL"] = r["MODEL"];
             dr["STORE_ROOM_NAME"] = r["STORE_ROOM_NAME"];
             dr["QUICKSEND_NAME"] = r["QUICKSEND_NAME"];
             dr["DESCRIPTIONS"] = r["DESCRIPTIONS"];
             dtPurchaseItem.Rows.Add(dr);
         }
            this.bindingSource2.DataSource = dtPurchaseItem;
            labelRecordcount.Text = this.gridView3.RowCount + "条记录";
        }
        #endregion
        private void getDataFromClient()
        {
            Emedchina.Commons.UserInfo ui = new Emedchina.Commons.UserInfo();
            ui.AreaId = base.CurrentUserSingleRegionId;
            ui.OrgId = base.CurrentUserRegOrgId;

        }

       
        #region 采购金额 setRequestTotal
        /// <summary>
        /// 采购金额
        /// </summary>
        /// <returns>采购金额</returns>
        private void setRequestTotal()
        {
            this.lcTotal.Text = getRequestTotal().ToString("###,###0.00")+"元";

        }
        #endregion


        #region 获取累计计划采购数量 getRequestTotal
        /// <summary>
        /// 获取累计计划采购数量
        /// </summary>
        /// <returns>累计计划采购数量</returns>
        private float getRequestTotal()
        {
            float requestTotal = 0.00F;
            //累计计划采购数量
            foreach (DataRow r in dtPurchaseItem.Rows)
            {
                requestTotal = requestTotal + float.Parse(r["AMOUNT"].ToString() ==
                    "" ? "0" : r["AMOUNT"].ToString()) * float.Parse(r["TRADE_PRICE"].ToString() ==
                    "" ? "0" : r["TRADE_PRICE"].ToString());
            }
            return requestTotal;
        }
        #endregion

        #region 初始化表格下拉框
        /// <summary>
        /// 初始化表格下拉框
        /// </summary>
        private void InitGrid_Cmb()
        {
            //初始化库房下拉框
            InitData_StoneInfo();
            InitData_SpecInfo();
            InitData_ModelInfo();

        }

        /// <summary>
        /// 初始化库房下拉框
        /// </summary>
        private void InitData_StoneInfo()
        {
            DataTable dtStone = CommUtilBLL.GetInstance().GetBuyerStoreInfo(base.CurrentUserOrgId);
            this.StoreRoomLue.DataSource = dtStone.DefaultView;
        }
        /// <summary>
        /// 初始化规格下拉框
        /// </summary>
        private void InitData_SpecInfo()
        {
            DataTable dtSpec = CommUtilBLL.GetInstance().GetSpecInfo();
            this.SpecLue.DataSource = dtSpec.DefaultView;
        }

        /// <summary>
        /// 初始化型号下拉框
        /// </summary>
        private void InitData_ModelInfo()
        {
            DataTable dtModel = CommUtilBLL.GetInstance().GetModelInfo();
            this.ModelLue.DataSource = dtModel.DefaultView;
        }

        #endregion


        #region 初始化添加采购明细列表
        /// <summary>
        ///  初始化添加采购明细列表
        /// </summary>
        private void IniTempHitCommData()
        {
            dtPurchaseItem = new DataTable();
            dtPurchaseItem.Columns.Add("ID");                //采购单明细id
            dtPurchaseItem.Columns.Add("PURCHASE_ID");       //采购单id
            dtPurchaseItem.Columns.Add("DATA_PRODUCT_ID");   //中心产品ID
            dtPurchaseItem.Columns.Add("CONT_PRODUCT_ID");   //合同商品ID
            dtPurchaseItem.Columns.Add("PROJECT_ID");        //项目id
            dtPurchaseItem.Columns.Add("PROJECT_PROD_ID");   //项目产品ID
            dtPurchaseItem.Columns.Add("PRODUCT_NAME");      //商品名
            dtPurchaseItem.Columns.Add("BRAND");             //品牌
            dtPurchaseItem.Columns.Add("SPEC_ID");           //规格ID
            dtPurchaseItem.Columns.Add("SPEC");              //规格
            dtPurchaseItem.Columns.Add("MODEL_ID");          //型号ID
            dtPurchaseItem.Columns.Add("MODEL");             //型号
            dtPurchaseItem.Columns.Add("SENDER_ID");         //配送企业ID
            dtPurchaseItem.Columns.Add("SENDER_NAME");       //配送商
            dtPurchaseItem.Columns.Add("SENDER_NAME_ABBR");  //配送商简称
            dtPurchaseItem.Columns.Add("BASE_MEASURE");      //基础计量单位
            dtPurchaseItem.Columns.Add("AMOUNT");            //订购数量
            dtPurchaseItem.Columns.Add("MANUFACTURE_ID");    //生产企业ID
            dtPurchaseItem.Columns.Add("MANUFACTURE_NAME");  //生产企业
            dtPurchaseItem.Columns.Add("MANUFACTURE_NAME_ABBR");  //生产企业简称
            dtPurchaseItem.Columns.Add("SALER_ID");          //经销企业ID
            dtPurchaseItem.Columns.Add("SALER_NAME");        //经销企业
            dtPurchaseItem.Columns.Add("SALER_NAME_ABBR");   //经销企业简称
            dtPurchaseItem.Columns.Add("COMMON_NAME");       //通用名
            //dtpurchaseItem.Columns.Add("BRAND");           //品牌
            dtPurchaseItem.Columns.Add("TRADE_PRICE");       //单价
            dtPurchaseItem.Columns.Add("PRODUCT_CODE");      //编码
            dtPurchaseItem.Columns.Add("GOODS_NO");          //货号
            dtPurchaseItem.Columns.Add("BARCODE");           //条码
            dtPurchaseItem.Columns.Add("BASE_MEASURE_SPEC"); //基础单位规格
            dtPurchaseItem.Columns.Add("BASE_MEASURE_MATER");//基础单位包装材质
            dtPurchaseItem.Columns.Add("RETAIL_PRICE");      //最高限价          
            //dtPurchaseItem.Columns.Add("SENDER_NAME_ABBR");//配送企业ID
            dtPurchaseItem.Columns.Add("STORE_ROOM_ID");     //库房ID
            dtPurchaseItem.Columns.Add("STORE_ROOM_NAME");   //库房ID
            dtPurchaseItem.Columns.Add("STORE_ROOM_ADDRESS");//库房ID
            dtPurchaseItem.Columns.Add("SUM");               //采购金额
            dtPurchaseItem.Columns.Add("purchase_QUICKSEND");//是否急需
            dtPurchaseItem.Columns.Add("RowState");          //操作类型（0为增加，1为修改,2为删除）
            dtPurchaseItem.Columns.Add("QUICKSEND_NAME");//是否急需
            dtPurchaseItem.Columns.Add("DESCRIPTIONS");//备注
            dtPurchaseItem.Columns["TRADE_PRICE"].DataType = Type.GetType("System.Double");
            dtPurchaseItem.AcceptChanges();

            this.bindingSource2.DataSource = dtPurchaseItem.DefaultView;

        }
         #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }       

        private void gridView3_RowCountChanged(object sender, EventArgs e)
        {
            labelRecordcount.Text = "    共 " + this.gridView3.RowCount + " 条数据";
        }

        #region 显示Title
        private void toolTipLocationControl_ToolTipLocationChanged(string HintValue)
        {
            ToolTipControllerShowEventArgs args = toolTipController1.CreateShowArgs();
            args.ToolTip = HintValue;
            args.IconType = ToolTipIconType.Information;
            args.ImageIndex = -1;
            args.IconSize = ToolTipIconSize.Small;
            toolTipController1.ShowHint(args);
        }

        private void gridView3_Click(object sender, EventArgs e)
        {
            DataRow dr = this.gridView3.GetDataRow(this.gridView3.FocusedRowHandle);
            if (dr != null)
            {
                if (this.gridView3.FocusedColumn.FieldName.ToUpper() == "MANUFACTURE_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["MANUFACTURE_NAME"].ToString());

                else if (this.gridView3.FocusedColumn.FieldName.ToUpper() == "SENDER_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["SENDER_NAME"].ToString());
                else
                    toolTipController1.HideHint();
            }

        }
        #endregion

        #region 导出Excel文件

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            if (this.gridView3.RowCount == 0)
            {
                XtraMessageBox.Show("无可操作记录！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            //选择导出文件
            string ExpFilePath = this.SelectExportFile();

            if (ExpFilePath.Length == 0)
                return;

            string[] strArr = {"商品名称","通用名称","品牌","规格","型号","交易价格（元）","单位","订购数量","生产企业", "配送企业","是否急需","库房"};
            string[] strColNameArr = { "Product_Name", "Common_Name", "Brand", "Spec", "Model", "Trade_Price", "BASE_MEASURE", "AMOUNT", "MANUFACTURE_NAME", "SENDER_NAME", "QUICKSEND_NAME", "STORE_ROOM_NAME" };

            if (FileOperation.ExportExcelFile(dtPurchaseItem, ExpFilePath, strArr, strColNameArr))
            {
                XtraMessageBox.Show("数据导出成功！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        /// <summary>
        /// 设定导出文件
        /// </summary>
        /// <returns></returns>
        private string SelectExportFile()
        {
            string tmpPath = "";
            try
            {
                this.saveFileDialog1.Filter = "Excel文件(*.xls)|*.xls|dbf文件(*.dbf)|*.dbf|文本文件(*.txt)|*.txt|所有文件 (*.*)|*.*";

                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (this.saveFileDialog1.FileName == "")
                    {
                        XtraMessageBox.Show("请设置到货导出文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        return "";
                    }
                    return this.saveFileDialog1.FileName;
                }
            }
            catch (Exception e)
            {
                tmpPath = "";
            }
            return tmpPath;
        }


        #endregion

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if (this.gridView3.RowCount == 0)
                return;

            DataTable dt = ReportBLL.GetInstance().GetPurchaseReportData(purchaseSaveModel.PurchaseId);
            FrmPrint frmPrint = new FrmPrint(new PurchaseXtraReport(base.CurrentUserOrgName + "采购单报表"), dt);
            frmPrint.ShowDialog();
        }

        #region 按品名过滤
        private void txtRemark_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        /// <summary>
        /// 查询过滤方法
        /// </summary>
        private void Filter()
        {
            StringBuilder StrFilter = new StringBuilder();

            string strRemark = this.txtRemark.Text.Trim();

            StrFilter.Append(" 1=1");

            //备注
            if (!string.IsNullOrEmpty(strRemark))
            {
                StrFilter.AppendFormat(" AND DESCRIPTIONS LIKE '%{0}%'", strRemark);
            }

            if (dtPurchaseItem != null)
            {
                if (dtPurchaseItem.DefaultView != null)
                {
                    this.dtPurchaseItem.DefaultView.RowFilter = StrFilter.ToString();
                }
            }
        }
        #endregion

    }
}

 