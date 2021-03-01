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
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Model.Order.PurchaseHandle;
using Emedchina.TradeAssistant.Client.BLL;
using Emedchina.TradeAssistant.Client.BLL.CommonInfo;
using Emedchina.TradeAssistant.Client.BLL.Order.PurchaseHandle;
using Emedchina.TradeAssistant.Client.DAL.Order.PurchaseHandle;
using Emedchina.TradeAssistant.Model.CommInfo;
using Emedchina.TradeAssistant.Client.Common;
using Emedchina.TradeAssistant.Client.BLL.Sync;


namespace Emedchina.TradeAssistant.Client.UI.Order.PurchaseHandle
{
    public partial class FormPurchaseCreate : Emedchina.TradeAssistant.Client.Base.BaseForm
    {
        private BindingSource projectTypeBinding = new BindingSource();
        private BindingSource salerListBinding = new BindingSource();
        private BindingSource oftenPurchaseBinding = new BindingSource();
        private BindingSource puchaseItemBinding = new BindingSource();
        //封装经常采购目录查询条件
        //private OftenpurChaseDirInput oftenpurChaseDirInput = new OftenpurChaseDirInput();
        //临时
        private UserInfoModel usInfo = new UserInfoModel();
        //采购单保存输入模型
        private PurchaseSaveModel purchaseSaveModel = new PurchaseSaveModel();

        //实例化采购单明细实体层

        PurchaseItemModel PurchaseItem = new PurchaseItemModel();
        //采购单保存后输出模型
        private PurchaseSaveModel output = new PurchaseSaveModel();
        //采购单明细数据
        private DataTable dtPurchaseItem = null;// new DataTable();
        //合同来源列表数据
        private DataTable dtProjectType = new DataTable();
        //项目产品数据集对象数据集
        private DataTable OrdProductDt = null;
        //配送商目录
        private DataTable SenderDt = null;
        //项目产品数据集对象数据集 临时使用
        //产品分类数据集
        private DataTable dtProductClass = null;

        private DataTable OrdProductTempDt = null;

        //库房目录
        private DataTable dtStone = null;

        //采购单datarow
        DataRow purchaseDataRow = null;
        private bool saveFlag = false;
        private bool checkFlag = false;
        private bool modifiedflag = false;//用于判断审核时采购单是否变化
        private bool editFlag = false;//判断是否有操作，如有操作未保存退出作提示。
        public static FormPurchaseCreate GetInstance(FormPurchaseBuild inForm, DataRow inDataRow)
        {

            return new FormPurchaseCreate("编辑采购单", inDataRow);

        }

        #region 创建窗体 FormPurchaseCreate
        /// <summary>
        /// 创建窗体
        /// </summary>
        public FormPurchaseCreate(string titleName, DataRow inDataRow)
        {
            InitializeComponent();
            this.Text = titleName;
            if (titleName == "审核采购单")
            {
                this.btngetCheck.Visible = true;
                this.btncheckno.Visible = true;
                this.BtnPostSend.Enabled = false;
            }
            this.purchaseDataRow = inDataRow;
            usInfo.Id = base.CurrentUserId;
            usInfo.Name = base.CurrentUserName;
            usInfo.OrgName = base.CurrentUserOrgName;
            usInfo.OrgId = base.CurrentUserOrgId;
            usInfo.HighID = base.CurrentUserHighID;
            usInfo.OrgAddr = base.CurrentUserOrgAbbr;

            //据此判断是否存在采购单
            purchaseSaveModel.PurchaseId = (inDataRow == null ? "" : inDataRow["id"].ToString());

            if (String.IsNullOrEmpty(purchaseSaveModel.PurchaseId))
            {
                lcCreater.Text = base.CurrentUserName;
                lcCreateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                // btnPrint.Enabled = false;
                IniTempHitCommData();

                lbeEditDate.Visible = false;
                lbeEditTime.Visible = false;
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

                lbeEditDate.Visible = true;
                lbeEditTime.Visible = true;
 
            }
            //绑定下拉列表
            InitData();
            //绑定项目采购目录
            // OrdProductBind();

        }
        //导入采购单
        public FormPurchaseCreate(string titleName,string m, IList<ImputPurchaseModel> result)
        {
            InitializeComponent();
            this.Text = titleName;
            usInfo.Id = base.CurrentUserId;
            usInfo.Name = base.CurrentUserName;
            usInfo.OrgName = base.CurrentUserOrgName;
            usInfo.OrgId = base.CurrentUserOrgId;
            usInfo.HighID = base.CurrentUserHighID;
            usInfo.OrgAddr = base.CurrentUserOrgAbbr;

            lcCreater.Text = base.CurrentUserName;
            lcCreateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            
            //初始化添加采购明细列表
            IniTempHitCommData();
            //从导入his采购单明细
            foreach (ImputPurchaseModel model in result)
            {
                DataRow dr = dtPurchaseItem.NewRow();
                dr["PROJECT_PROD_ID"] = model.EmedProductId;
                dr["SPEC_ID"] = model.EmedSpecId;
                dr["MODEL_ID"] = model.EmedModelId;
                dr["BASE_MEASURE"] = model.Bzdw;
                dr["PRODUCT_NAME"] = model.Cpmc;
                dr["COMMON_NAME"] = model.Hcmc;
                dr["AMOUNT"] = model.Cgsl;
                dr["MANUFACTURE_NAME_ABBR"] = model.Scqyjc;
                dr["MANUFACTURE_NAME"] = model.Scqymc;
                dr["SENDER_ID"] = model.EmedSenderId;
                dr["SENDER_NAME"] = model.Psqymc;
                dr["SENDER_NAME_ABBR"] = model.Psqyjc;
                dr["purchase_QUICKSEND"] = '0';
                dr["TRADE_PRICE"] = model.Price;
                dr["PACKAGEAMOUNT"] = Math.Floor(float.Parse(model.Cgsl) / float.Parse(model.Zdbz));
                dr["RowState"] = '0';
                dr["BRAND"] = model.Brand;
                dtPurchaseItem.Rows.Add(dr);

            }
            this.bindingSource2.DataSource = dtPurchaseItem;
            //btnSave.Enabled = false;
            labelRecordcount.Text = this.gridView3.RowCount + "条记录"; 
          
            //绑定下拉列表
            InitData();
           
        }
        #endregion


        private void FormPurchaseCreate_Load(object sender, EventArgs e)
        {
            if (!ClientConfiguration.IfDefineBigPacking)
            {
                this.gridView3.Columns["PACKAGEAMOUNT"].Visible = false;
            }
        }



        #region 载入已知采购单明细数据 getPurchaseItemFromCache
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
                dr["PACKAGE"] = r["SELF_PACKAGE"];
                dr["AMOUNT"] = r["AMOUNT"];
                dr["BASE_MEASURE"] = r["BASE_MEASURE"];
                dr["PACKAGEAMOUNT"] = Math.Floor(float.Parse(r["AMOUNT"].ToString()) / float.Parse(r["SELF_PACKAGE"].ToString()));
                dr["DESCRIPTIONS"] = r["DESCRIPTIONS"];

                dtPurchaseItem.Rows.Add(dr);
            }
            this.bindingSource2.DataSource = dtPurchaseItem;
            btnSave.Enabled = false;
            this.BtnPostSend.Enabled = false;
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
            dtStone = CommUtilBLL.GetInstance().GetBuyerStoreInfo(base.CurrentUserOrgId);
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
            dtPurchaseItem.Columns.Add("ABBR_PY");          //拼音
            dtPurchaseItem.Columns.Add("ABBR_WB");          //五笔
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
            dtPurchaseItem.Columns.Add("PACKAGE");            //中大包装
            dtPurchaseItem.Columns.Add("PACKAGEAMOUNT");           //中大包装
            dtPurchaseItem.Columns["TRADE_PRICE"].DataType = Type.GetType("System.Double");
            dtPurchaseItem.Columns.Add("DESCRIPTIONS");            //描述
            dtPurchaseItem.AcceptChanges();

            this.bindingSource2.DataSource = dtPurchaseItem.DefaultView;

        }
        #endregion


        #region 初始化列表
        /// <summary>
        /// 初始化
        /// </summary>
        private void InitData()
        {
            InitData_ProjectType();
            InitData_Project();
            InitData_ProjectClass();
            InitGrid_Cmb();//初始化规格，型号，库房
            //初始化配送商
            //InitData_BuyerSender(base.CurrentUserOrgId, "", "");

        }

        /// <summary>
        /// 初始化项目类型
        /// </summary>
        private void InitData_ProjectType()
        {
            //绑定项目类型
            DataTable dt = new DataTable();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns[0].ColumnName = "value";
            dt.Columns[1].ColumnName = "Name";
            string[] data0 = { "0", "全部" };
            dt.Rows.Add(data0);
            string[] data1 = { "1", "招投标" };
            dt.Rows.Add(data1);
            string[] data2 = { "2", "备案采购" };
            dt.Rows.Add(data2);
            string[] data3 = { "3", "竞价采购" };
            dt.Rows.Add(data3);
            string[] data4 = { "4", "浏览采购" };
            dt.Rows.Add(data4);

            LueProjectType.Properties.DataSource = dt;
            LueProjectType.Properties.NullText = "";

            //设置默认值
            LueProjectType.EditValue = "0";
        }

        private void InitData_Project()
        {
            //绑定项目名称
            DataTable dtPro = CommUtilBLL.GetInstance().GetProjectInfoByProjectType("");

            LueProject.Properties.DataSource = dtPro;
            LueProject.Properties.Columns.Clear();
            LueProject.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PROJECT_NAME", 200, "项目名称"));
            LueProject.Properties.DisplayMember = "PROJECT_NAME";
            LueProject.Properties.ValueMember = "ID";
            LueProject.Properties.NullText = "请选择...";

            //默认显示第一个项目
            string DefaultProjectID = dtPro.Rows[0]["ID"].ToString().Trim();
            LueProject.EditValue = Convert.ToInt32(DefaultProjectID);
        }
        private void InitData_StoreRoom()
        {
            //绑定库房名称（用于整单的库房选择）
            DataTable dtStone = CommUtilBLL.GetInstance().GetBuyerStoreInfo(base.CurrentUserOrgId);

           LueStoreroom.Properties.DataSource = dtStone;
           LueStoreroom.Properties.Columns.Clear();
           LueStoreroom.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("STORE_NAME", 200, "项目名称"));
           LueStoreroom.Properties.DisplayMember = "STORE_NAME";
           LueStoreroom.Properties.ValueMember = "STORE_ID";
           LueStoreroom.Properties.NullText = "请选择...";

        }
        private void InitData_ProjectClass()
        {
            //绑定品种分类信息
            dtProductClass = CommUtilBLL.GetInstance().GetProductClassInfoByProjectID("");

            this.LueProductClass.Properties.DataSource = dtProductClass;
            LueProductClass.Properties.NullText = "全部";
            LueProductClass.EditValue = "0";//默认为“全部”
        }
        #endregion

        /// <summary>
        /// 项目产品数据绑定
        /// </summary>
        private void OrdProductBind()
        {

            //当前所选项目ID
            string strProjectID = this.LueProject.EditValue.ToString();
            string strProductItem = this.cmbProductItem.Text;
            //使用缓存 获取采购目录查询数据集
            string strDataName = Constant.ORDPRODUCT + strProjectID + strProductItem;
            if (ClientCache.CachedDS.Tables.IndexOf(strDataName) == -1)
            {
                DataTable tempDt = new DataTable(strDataName);

                //获取项目产品数据集
                if (this.cmbProductItem.Text == "经常采购目录")
                {
                    tempDt = HitCommAndContClientBll.GetInstance().GetHitProductDt(strProjectID, CurrentUser, strDataName);
                }
                else
                {
                    tempDt = OrdProductBLL.GetInstance().GetOrdProductDt(strProjectID, CurrentUser, strDataName);
                }
                OrdProductDt = tempDt.Copy();

                if (ClientCache.CachedDS.Tables.IndexOf(strDataName) != -1)
                    ClientCache.CachedDS.Tables.Remove(strDataName);
                ClientCache.CachedDS.Tables.Add(OrdProductDt);
            }

            //存入缓存
            InitFromCacheByData(strDataName);

            //从缓存取数据集绑定到GRID
            bindingDsOrdProduct();
            Filter_Product();
        }

        #region 绑定到GRID中
        /// <summary>
        /// 绑定到GRID中
        /// </summary>
        private void bindingDsOrdProduct()
        {
            this.bindingSource1.DataSource = base.cachedDataView;

            OrdProductDt = base.cachedDataView.Table;

            OrdProductTempDt = OrdProductDt.Copy();

            this.gVOrdProduct.ExpandAllGroups();

        }
        #endregion

        #region 采购单保存

        /// <summary>
        /// 如果在修改模式下，该采购单明细没有数据时，提示是否删除采购单操作
        /// </summary>
        private bool DelPurchase()
        {
            this.saveFlag = false;
            if (!String.IsNullOrEmpty(purchaseSaveModel.PurchaseId))
            {
                //没有明细提示删除
                if (this.gridView3.RowCount == 0)
                {
                    if (XtraMessageBox.Show("采购单明细没有数据，是否删除该采购单？", Constant.MsgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //根SavePurchase离线设置，直接离线删除没有明细的采购单，不判断 DelPurchase 状态
                        bool flag = new PurchaseOfflineBLL().PurchaseDeleteLocal(purchaseSaveModel.PurchaseId, base.CurrentUserId);

                        if (flag)
                        {
                            XtraMessageBox.Show("采购单删除成功！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("采购单删除失败！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        this.Close();
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 采购单保存
        /// </summary>
        private void PurchaseSave()
        {

            output = new PurchaseOfflineBLL().SavePurchaseOffline(this.purchaseSaveModel, usInfo.Id);

            if (!string.IsNullOrEmpty(output.PurchaseId))
            {

                this.btnSave.Enabled = false;
                this.BtnPostSend.Enabled = false;
                //btnPrint.Enabled = true;
                this.saveFlag = false;

                //try
                //{
                    //XtraMessageBox.Show("采购单保存成功！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    purchaseSaveModel.PurchaseId = output.PurchaseId;
                    this.purchaseSaveModel.List.Clear();//
                    this.dtPurchaseItem.Clear();//清空dtPurchaseItem
                    getPurchaseItemFromCache();//需重新刷新采购单明细数据
                    this.saveFlag = false;

                //}
                //catch (Exception ex)
                //{
                //    XtraMessageBox.Show("采购单缓存维护失败，请重新启动程序刷新缓存！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
            }

        }

        /// <summary>　采购单保存
        /// 采购单保存
        /// </summary>
        /// <returns></returns>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //判断是否删除空采购单
            if (DelPurchase())
                return;

            //校验数据
            string strError = string.Empty;
            if (!checkInput(out strError))
            {
                checkFlag = false;
                XtraMessageBox.Show(strError, Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            checkFlag = true;

            //获取数据保存模型
            getPurchaseSaveModelList();

            //调用采购单保存事件
            try
            {
                PurchaseSave();
                XtraMessageBox.Show("采购单保存成功！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                editFlag = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("采购单保存失败！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                checkFlag = false;
                return;
            }
        }
        #endregion
        #region 遍历dgvPurchaseItem获取PurchaseSaveModel getPurchaseSaveModelList
        /// <summary>
        /// 遍历dgvPurchaseItem获取PurchaseSaveModel
        /// </summary>
        private void getPurchaseSaveModelList()
        {
            //采购单信息
            purchaseSaveModel.PurchaseId = purchaseSaveModel.PurchaseId;
            purchaseSaveModel.PurchaseCode = "";
            //purchaseSaveModel.PurchaseRemark = this.tbRemark.Text;

            //当前登录用户信息
            purchaseSaveModel.BuyerOrgid = base.CurrentUserOrgId;
            purchaseSaveModel.CreateUserid = base.CurrentUserId;
            purchaseSaveModel.CreateUsername = base.CurrentUserName;
            purchaseSaveModel.HighID = base.CurrentUserHighID;

            if (this.Text == "审核采购单" || lcstate.Text == "送审")
            {
                purchaseSaveModel.State = "2";//送审
            }
            else
            {
                purchaseSaveModel.State = "1";//准备
            }

            foreach (DataRow r in dtPurchaseItem.Rows)
            {

                PurchaseItemSaveModel purchaseItem = new PurchaseItemSaveModel();
                if ((r["RowState"].ToString() == "0")
                    || (r["RowState"].ToString() == "1"))
                {
                    this.purchaseSaveModel.List.Add(buildPurchaseItemSaveModel(r, purchaseItem));

                }
            }

        }
        #endregion

        /// <summary>
        /// 输入校验
        /// </summary>
        /// <returns></returns>
        private bool checkInput(out string Error)
        {
            Error = string.Empty;
            string requestQty;//采购数量
            string specid;//规格
            string modelid;//型号
            string storeid;//库房
            string senderid;//配送
            int request;

            if (this.gridView3.RowCount == 0)
            {
                Error = "采购单明细没有数据！";
                return false;
            }

            foreach (DataRow row in dtPurchaseItem.Rows)
            {
                requestQty = row["AMOUNT"].ToString();
                specid = row["SPEC_ID"].ToString();
                modelid = row["MODEL_ID"].ToString();
                storeid = row["STORE_ROOM_ID"].ToString();
                senderid = row["SENDER_ID"].ToString();
                if (!int.TryParse(requestQty, out request))
                {
                    Error = "请输入订购数量！";
                    return false;
                }
                if (request < 1)
                {
                    Error = "采购数量必须是大于0的整数！";
                    return false;
                }
                if (string.IsNullOrEmpty(specid))
                {
                    Error = "请选择一种规格！";
                    return false;
                }
                if (string.IsNullOrEmpty(modelid))
                {
                    Error = "请选择一种型号！";
                    return false;
                }
                if (string.IsNullOrEmpty(storeid))
                {
                    Error = "请选择库房！";
                    return false;
                }
                if (string.IsNullOrEmpty(senderid))
                {
                    Error = "请选择配送企业！";
                    return false;
                }
            }
            return true;
        }

        #region 组装采购单明细保存模型数组 buildPurchaseItemSaveModel
        /// <summary>
        /// 组装采购单明细保存模型数组
        /// </summary>
        /// <param name="r">行</param>
        /// <returns>PurchaseItemSaveModel</returns>
        private PurchaseItemSaveModel buildPurchaseItemSaveModel(DataRow r, PurchaseItemSaveModel purchaseItem)
        {

            //采购单明细信息
            purchaseItem.RowState = r["RowState"].ToString();
            purchaseItem.Projectprodid = r["PROJECT_PROD_ID"].ToString();
            purchaseItem.SenderId = r["SENDER_ID"].ToString();
            purchaseItem.SenderName = r["SENDER_NAME"].ToString();
            purchaseItem.SenderAbbr = r["SENDER_NAME_ABBR"].ToString();
            purchaseItem.PurchaseId = purchaseSaveModel.PurchaseId;
            purchaseItem.PurchaseItemId = r["Id"].ToString();
            purchaseItem.Storeroomid = r["STORE_ROOM_ID"].ToString();//库房id
            purchaseItem.Storeroomname = r["STORE_ROOM_NAME"].ToString();
            purchaseItem.Storeroomaddress = r["STORE_ROOM_ADDRESS"].ToString();
            purchaseItem.RequestQty = r["AMOUNT"].ToString();
            purchaseItem.SalerId = r["SALER_ID"].ToString();
            purchaseItem.SalerName = r["SALER_NAME"].ToString();
            purchaseItem.SalerAbbr = r["SALER_NAME_ABBR"].ToString();
            purchaseItem.SpecId = r["SPEC_ID"].ToString();
            purchaseItem.Spec = r["SPEC"].ToString();
            purchaseItem.ModelId = r["MODEL_ID"].ToString();
            purchaseItem.Model = r["MODEL"].ToString();
            purchaseItem.Isquicsend = r["purchase_QUICKSEND"].ToString();//是否急需
            purchaseItem.UnitPrice = r["TRADE_PRICE"].ToString();//交易价格
            purchaseItem.Descriptions = r["DESCRIPTIONS"].ToString();//描述

            purchaseItem.ModifyUserid = base.CurrentUserId;

            return purchaseItem;
        }
        #endregion


        //审核通过
        private void btngetCheck_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled)//当审核前采购单发生变化首先执行保存采购单操作
            {
                XtraMessageBox.Show("采购单内容发生变化，请先保存采购单！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnSave.Focus();
                return;
            }

            //离线发送功能
            string mes;
            mes = new PurchaseOfflineBLL().getCheckPurchaseOffline(purchaseSaveModel.PurchaseId, usInfo);
            if (ClientConfiguration.IfSendImmediately)
            {
                if (XtraMessageBox.Show("是否立即发送到服务器？", Constant.MsgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    List<string> InvalidList = null;
                    int rows;
                    bool sendOk = new ClientUploadBLL().UploadData(true, out InvalidList, out rows);
                    if (!sendOk)
                    {
                        mes = "数据已保存到本地库，但发送到服务器失败，请同步数据！";
                    }
                }
            }

            if (string.IsNullOrEmpty(mes))
            {
                XtraMessageBox.Show("审核通过成功！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnAdd.Enabled = false;
                this.btncheckno.Enabled = false;
                this.btnDel.Enabled = false;
                this.btnSave.Enabled = false;
                this.BtnPostSend.Enabled = false;
                this.btngetCheck.Enabled = false;
                //this.gridView3.Columns["AMOUNT"]. = false;
                lcstate.Text = "审核通过";
            }
            else
            {
                XtraMessageBox.Show(mes, Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //如果失败，则不刷新用户界面
                return;
            }

        }


        private void btncheckno_Click(object sender, EventArgs e)
        {
            bool flag;
            flag = new PurchaseOfflineBLL().Checkno(purchaseSaveModel.PurchaseId);
            if (flag)
            {

                XtraMessageBox.Show("审核拒绝成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnAdd.Enabled = false;
                this.btncheckno.Enabled = false;
                this.btnDel.Enabled = false;
                this.btnSave.Enabled = false;
                this.BtnPostSend.Enabled = false;
                this.btngetCheck.Enabled = false;

            }
            else
            {
                XtraMessageBox.Show("审核拒绝失败！没有返回数据！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }


        #region 添加产品到采购明细目录
        /// <summary>
        ///  添加产品到采购明细目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.gVOrdProduct.RowCount == 0)
            {
                XtraMessageBox.Show("没有选择数据！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            editFlag = true;

            int currentRow = this.gVOrdProduct.FocusedRowHandle;

            string strPackName = string.Empty;

            //判断是否选择为配套信息
            if (currentRow < 0)
            {
                currentRow = this.gVOrdProduct.GetDataRowHandleByGroupRowHandle(currentRow);

                foreach (DevExpress.XtraGrid.Columns.GridColumn groupColumn in this.gVOrdProduct.GroupedColumns)
                {
                    object val = this.gVOrdProduct.GetRowCellValue(currentRow, groupColumn);
                    strPackName = val.ToString();
                }

                //当主套不为空时，即没用所属配套的产品信息。不作按主套批量添加
                if (!strPackName.Trim().Equals("【非配套产品】"))
                {
                    //按整套输入订购数量
                    FormPackage fromPackage = new FormPackage();
                    fromPackage.ShowDialog();

                    string PackageAmount = fromPackage.strPackageAmount;
                    //取消则 撤销添加
                    if (string.IsNullOrEmpty(PackageAmount))
                    {
                        return;
                    }

                    

                    OrdProductTempDt.DefaultView.RowFilter = string.Format("PackName='{0}'", strPackName);

                    //OrdProductTempDt = OrdProductDt.Copy();

                    DataTable DtTemp = OrdProductTempDt.DefaultView.ToTable();

                    foreach (DataRow dr in DtTemp.Rows)
                    {
                        PurchaseOrderItemModel ordProductModel = GetOrdProductModelByTreeList(dr);
                        AddPurchaseItemView(ordProductModel, true, PackageAmount);
                    }
                }
            }
            else
            {
                //获取当前项目产品对象
                DataRow dr = (DataRow)this.gVOrdProduct.GetDataRow(this.gVOrdProduct.FocusedRowHandle);

                if (dr == null)
                    return;

                PurchaseOrderItemModel ordProductModel = GetOrdProductModelByTreeList(dr);
                AddPurchaseItemView(ordProductModel,false,"");
            }

            setRequestTotal();//更新金额

        }
        /// <summary>
        /// 添加到采购明细目录
        /// </summary>
        /// <param name="ordProductModel"></param>
        private void AddPurchaseItemView(PurchaseOrderItemModel ordProductModel,bool Is_Package,string PackageAmount)
        {
            //dtPurchaseItem.Columns["TRADE_PRICE"].DataType = Type.GetType("System.Double");
            DataRow dr = dtPurchaseItem.NewRow();
            dr["ID"] = "";
            dr["DATA_PRODUCT_ID"] = ordProductModel.DataproductId;
            dr["PROJECT_ID"] = ordProductModel.ProjectId;
            dr["PROJECT_PROD_ID"] = ordProductModel.ProjectprodId;
            dr["PRODUCT_NAME"] = ordProductModel.ProductName;//商品名
            dr["BASE_MEASURE"] = ordProductModel.Sendmeasure;
            dr["MANUFACTURE_NAME"] = ordProductModel.ManufactureName;
            dr["MANUFACTURE_NAME_ABBR"] = ordProductModel.ManufactureNameEasy;
            dr["SALER_NAME"] = ordProductModel.SalerName;
            dr["COMMON_NAME"] = ordProductModel.CommonName;
            dr["BRAND"] = ordProductModel.Brand;
            dr["TRADE_PRICE"] = ordProductModel.UnitPrice;
            if (this.cmbProductItem.Text == "经常采购目录")
            {
                dr["SPEC_ID"] = ordProductModel.SpecId;
                dr["MODEL_ID"] = ordProductModel.ModelId;
                dr["PACKAGE"] = ordProductModel.Package;
            }
            else
            {
                dr["PACKAGE"] = 1;
            }
            //dr["BASE_MEASURE"] = ordProductModel.Sendmeasure;
            dr["purchase_QUICKSEND"] = '0';
            dr["SENDER_ID"] = ordProductModel.SenderId;
            dr["SENDER_NAME"] = ordProductModel.SenderName;
            dr["SENDER_NAME_ABBR"] = ordProductModel.SenderNameEasy;
            dr["BASE_MEASURE"] = ordProductModel.Basemeasure;
            dr["RowState"] = '0';//将该行的操作类型设为新增

            if (Is_Package)
            {
                if (!string.IsNullOrEmpty(ordProductModel.Amount.ToString()))
                    dr["AMOUNT"] = Convert.ToInt32(PackageAmount) * ordProductModel.Amount;
                else
                    dr["AMOUNT"] = PackageAmount;
                //setRequestTotal();//更新金额
            }

            //默认显示第一个库房
            if (dtStone.Rows.Count > 0)
                dr["STORE_ROOM_ID"] = dtStone.Rows[0]["STORE_ID"].ToString().Trim();

            dtPurchaseItem.Rows.Add(dr);
        }
        #endregion

        #region 获取当前选择项目产品记录对象
        /// <summary>
        /// 获取当前选择项目产品记录对象
        /// </summary>
        /// <returns></returns>
        private PurchaseOrderItemModel GetOrdProductModelByTreeList(DataRow dr)
        {
            PurchaseOrderItemModel PurchaseItem = new PurchaseOrderItemModel();

            if (dr == null)
                return null;

            PurchaseItem.DataproductId = dr["DATA_PRODUCT_ID"].ToString().Trim();
            PurchaseItem.ProjectprodId = dr["PROJECT_PROD_ID"].ToString().Trim();
            if (this.cmbProductItem.Text == "经常采购目录")
            {
                PurchaseItem.SpecId = dr["SPEC_ID"].ToString().Trim();
                PurchaseItem.ModelId = dr["MODEL_ID"].ToString().Trim();
                PurchaseItem.Package = decimal.Parse(dr["SELF_PACKAGE"].ToString());
                PurchaseItem.SenderNameEasy = dr["SENDER_NAME_ABBR"].ToString().Trim();
            }
            PurchaseItem.Spec = dr["SPEC"].ToString().Trim();
            PurchaseItem.Model = dr["MODEL"].ToString().Trim();
            PurchaseItem.Brand = dr["BRAND"].ToString().Trim();
            PurchaseItem.CommonName = dr["COMMON_NAME"].ToString().Trim();
            PurchaseItem.SalerName = dr["SALER_NAME"].ToString().Trim();
            PurchaseItem.ProductName = dr["PRODUCT_NAME"].ToString().Trim();
            PurchaseItem.Abbr_Py = dr["ABBR_PY"].ToString().Trim();
            PurchaseItem.Abbr_Wb = dr["ABBR_WB"].ToString().Trim();
            PurchaseItem.UnitPrice = decimal.Parse(dr["PRICE"].ToString());
            PurchaseItem.Sendmeasure = dr["BASE_MEASURE"].ToString().Trim();
            PurchaseItem.ManufactureNameEasy = dr["MANU_NAME_ABBR"].ToString().Trim();
            PurchaseItem.ManufactureName = dr["MANU_NAME"].ToString().Trim();
            PurchaseItem.RepositoryId = "";
            PurchaseItem.Storeroomname = "";
            PurchaseItem.Basemeasure = dr["BASE_MEASURE"].ToString().Trim();
            PurchaseItem.SenderId = dr["SENDER_ID"].ToString().Trim();
            PurchaseItem.SenderName = dr["SENDER_NAME"].ToString().Trim();
            PurchaseItem.ProjectId = dr["PROJECT_ID"].ToString().Trim();
            //数量
            if (!dr["AMOUNT"].ToString().Equals("-"))
                PurchaseItem.Amount = Convert.ToInt32(dr["AMOUNT"].ToString().Trim());
            return PurchaseItem;

        }
        #endregion


        #region 移除已添加项
        /// <summary>
        /// 移除已添加项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dtPurchaseItem != null)
            {
                if (dtPurchaseItem.Rows.Count == 0)
                {
                    XtraMessageBox.Show("没有选择数据！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                editFlag = true;

                DataRow dr = this.gridView3.GetDataRow(this.gridView3.FocusedRowHandle);
                //新增加记录删除不加入PurchaseSaveModel
                if (!String.IsNullOrEmpty(dr["ID"].ToString()))
                {
                    //加入维护模型
                    PurchaseItemSaveModel purchaseItem = new PurchaseItemSaveModel();
                    dr["RowState"] = "2";
                    this.purchaseSaveModel.List.Add(buildPurchaseItemSaveModel(dr, purchaseItem));
                }
                dtPurchaseItem.Rows.Remove(dr);
                dtPurchaseItem.AcceptChanges();
                btnSave.Enabled = true;
                BtnPostSend.Enabled = true;
            }
        }
        #endregion


        #region//根据买方ID，项目ID，项目产品ID绑定配送商
        /// <summary>
        /// 根据买方ID，项目ID，项目产品ID绑定配送商
        /// </summary>
        /// <param name="buyerId"></param>
        /// <param name="projectId"></param>
        /// <param name="projectProdId"></param>
        private void InitData_BuyerSender(string buyerId, string projectId, string projectProdId)
        {
            SenderDt = CommUtilBLL.GetInstance().GetSenderInfo(buyerId, projectId, projectProdId);

            LueSender.Properties.DataSource = SenderDt;
            LueSender.Properties.Columns.Clear();
            //LueSender.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SENDER_NAME", 100, "配送商名称"));
            LueSender.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SENDER_ABBR", 100, "配送商名称"));
            LueSender.Properties.DisplayMember = "SENDER_ABBR";
            LueSender.Properties.ValueMember = "SENDER_ID";
            LueSender.Properties.NullText = "请选择..";
        }

        #endregion


        /// <summary>
        /// 刷新数据集
        /// </summary>
        /// <param name="strKeyID"></param>
        private void RefSenderDt(string strSenderID, string strSenderName)
        {

            DataRow dr = this.gridView3.GetDataRow(this.gridView3.FocusedRowHandle);
            //DataRow dr = dtPurchaseItem.Rows[this.gridView3.FocusedRowHandle];

            if (dr != null)
            {
                dr["SENDER_ID"] = strSenderID;
                dr["SENDER_NAME_ABBR"] = strSenderName;
            }
        }


        /// <summary>
        /// 获取Grid当前选择 某个字段值
        /// </summary>
        /// <param name="view">gridView对象</param>
        /// <param name="ColName">字段名</param>
        /// <returns></returns>
        public string GetGridViewColValue(DevExpress.XtraGrid.Views.Base.ColumnView view, string ColName)
        {
            string value = string.Empty;

            if (view.RowCount == 0)
                return value;

            DevExpress.XtraGrid.Columns.GridColumn colvalue = view.Columns.ColumnByFieldName(ColName);
            value = view.GetRowCellValue(view.FocusedRowHandle, colvalue).ToString();

            return value;
        }

        #region 查询过滤方法
        /// <summary>
        /// 查询过滤方法
        /// </summary>
        private void Filter_Product()
        {

            //项目类型
            string ProjectType = string.Empty;
            if (this.LueProjectType.EditValue != null && !this.LueProjectType.EditValue.ToString().Equals("0"))
            {
                ProjectType = this.LueProjectType.EditValue.ToString().Trim();
            }
            //项目ID
            string ProjectId = string.Empty;
            if (this.LueProject.EditValue != null)
            {
                ProjectId = this.LueProject.EditValue.ToString().Trim();
            }
            //产品分类ID
            string ClassId = string.Empty;
            if (this.LueProductClass.EditValue != null && !this.LueProductClass.EditValue.ToString().Equals("0"))
            {
                ClassId = this.LueProductClass.EditValue.ToString().Trim();
            }
            //商品名称
            string ProductName = this.txtCommerceName.Text.Trim();
            string Spec = this.txtSpec.Text.Trim();
            string Model = this.txtModel.Text.Trim();
            string ManuName = this.txtManuName.Text.Trim();
            string SalerName = this.txtSalerName.Text.Trim();
            string SenderName = this.txtSenderName.Text.Trim();
            string Price = this.txtPrice.Text.Trim();
            //招标序号
            string strbid_id = this.txtBid_Id.Text.Trim();

            StringBuilder StrFilter = new StringBuilder();
            StrFilter.Append("1=1");
            if (this.cmdCreateDate.Visible == true)
            {
                //开始时间
                string createDate = this.cmdCreateDate.Text.ToString();
                //结束时间
                string endDate = this.cmdEndDate.Text.ToString();
                //if (DateTime.Compare(this.cmdEndDate.DateTime, this.cmdCreateDate.DateTime) < 0)
                //{
                //    XtraMessageBox.Show("创建日期结束日期必须大于开始日期！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}

                if (!string.IsNullOrEmpty(createDate))
                {
                    StrFilter.AppendFormat(" and LAST_DATE >= '{0}'", createDate + " 00:00:00");
                }

                if (!string.IsNullOrEmpty(endDate))
                {
                    StrFilter.AppendFormat(" and LAST_DATE <= '{0}'", endDate + " 23:59:59");
                }
            }

            //项目类型
            if (!string.IsNullOrEmpty(ProjectType))
            {
                StrFilter.AppendFormat(" AND PROJECT_TYPE = '{0}'", ProjectType);
            }

            //项目ID
            if (!string.IsNullOrEmpty(ProjectId))
            {
                StrFilter.AppendFormat(" AND PROJECT_ID = '{0}'", ProjectId);
            }

            //产品分类ID
            if (!string.IsNullOrEmpty(ClassId))
            {
                StrFilter.AppendFormat(" AND CLASS_ID = '{0}'", ClassId);
            }

            //商品名称
            if (!string.IsNullOrEmpty(ProductName))
            {

                if (this.cmbProductItem.Text == "经常采购目录" && ClientConfiguration.IfSetProEasy)
                {
                    StrFilter.AppendFormat(" AND (PRODUCT_NAME LIKE '%{0}%' Or COMMON_NAME LIKE '%{0}%' Or ABBR_PY LIKE '%{0}%' Or ABBR_WB LIKE '%{0}%' Or ALIAS LIKE '%{0}%'  Or ALIAS_PINYIN LIKE '%{0}%' Or PRODUCT_MNEMONIC LIKE '%{0}%')", ProductName);
                }
                else
                {
                    StrFilter.AppendFormat(" AND (PRODUCT_NAME LIKE '%{0}%' Or COMMON_NAME LIKE '%{0}%' Or ABBR_PY LIKE '%{0}%' Or ABBR_WB LIKE '%{0}%')", ProductName);
                }
            }

            //规格
            if (!string.IsNullOrEmpty(Spec))
            {
                StrFilter.AppendFormat(" AND (SPEC LIKE '%{0}%' )", Spec);
            }
            //型号
            if (!string.IsNullOrEmpty(Model))
            {
                StrFilter.AppendFormat(" AND ( MODEL LIKE '%{0}%')", Model);
            }

            //生产企业
            if (!string.IsNullOrEmpty(ManuName))
            {
                StrFilter.AppendFormat(" AND (MANU_NAME LIKE '%{0}%' Or MANU_NAME_ABBR LIKE '%{0}%' Or MANU_NAME_SPELL_ABBR LIKE '%{0}%' Or MANU_NAME_WB LIKE '%{0}%')", ManuName);
            }

            //经销企业
            if (!string.IsNullOrEmpty(SalerName))
            {
                StrFilter.AppendFormat(" AND (SALER_NAME LIKE '%{0}%' Or SALER_NAME_ABBR LIKE '%{0}%' Or SALER_NAME_SPELL_ABBR LIKE '%{0}%' Or SALER_NAME_WB LIKE '%{0}%')", SalerName);
            }

            //配送企业
            if (!string.IsNullOrEmpty(SenderName) && this.cmbProductItem.Text.Equals("经常采购目录"))
            {
                StrFilter.AppendFormat(" AND (SENDER_NAME LIKE '%{0}%' Or SENDER_NAME_ABBR LIKE '%{0}%' Or SENDER_NAME_SPELL_ABBR LIKE '%{0}%' Or SENDER_NAME_WB LIKE '%{0}%')", SenderName);
            }

            //单价
            if (!string.IsNullOrEmpty(Price))
            {
                Price = Emedchina.Commons.StringUtils.ToDBC(Price);
                StrFilter.AppendFormat(" AND ( PRICE = '{0}')", Price);
            }

            //招标序号
            if (!string.IsNullOrEmpty(strbid_id))
            {
                StrFilter.AppendFormat(" AND bid_id LIKE '%{0}%'", strbid_id);
            }

            if (base.cachedDataView != null)
            {
                base.cachedDataView.RowFilter = StrFilter.ToString();
            }
        }
        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 项目选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LueProject_EditValueChanged(object sender, EventArgs e)
        {
            //绑定项目产品
            OrdProductBind();
            if (LueProject.EditValue != null && dtProductClass != null)
            {
                Filter_ProjectClass(LueProject.EditValue.ToString());
            }
            this.Filter_Product();
            this.LueProductClass.Focus();
        }

        private void Found_TextChanged(object sender, EventArgs e)
        {
            Filter_Product();
            this.gVOrdProduct.ExpandAllGroups();
        }

        private void gridView3_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (this.gridView3.RowCount > 0)
            {
                DataRow dr = this.gridView3.GetDataRow(e.RowHandle);

                int request;
                string requestQty = dr["AMOUNT"].ToString();

                if (!int.TryParse(requestQty, out request) && this.gridView3.FocusedColumn.FieldName.ToUpper() == "AMOUNT")
                {
                    XtraMessageBox.Show("非法采购数量！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dr["AMOUNT"] = "";
                    return;
                }
                string packageamount = dr["PACKAGEAMOUNT"].ToString();
                if (!int.TryParse(packageamount, out request) && this.gridView3.FocusedColumn.FieldName.ToUpper() == "PACKAGEAMOUNT")
                {
                    XtraMessageBox.Show("非法采购数量！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dr["PACKAGEAMOUNT"] = "";
                    return;
                }
                if (dr["RowState"].ToString() != "0")
                {
                    dr["RowState"] = '1';//如果该行不为新增将该行的操作类型设为修改
                }
                labelRecordcount.Text = this.gridView3.RowCount + "条记录";
                if (lcstate.Text == "审核通过")
                    return;
                btnSave.Enabled = true;

                if (this.Text == "审核采购单")
                {
                    BtnPostSend.Enabled = false;
                }
                else
                {
                    BtnPostSend.Enabled = true;
                }

                editFlag = true;

                //使用大包装
                if (ClientConfiguration.IfDefineBigPacking)
                {
                    //转换比
                    string strPackage = dr["PACKAGE"].ToString();
                    if (strPackage != null && !string.IsNullOrEmpty(strPackage))
                    {
                        if (this.gridView3.FocusedColumn.FieldName.ToUpper() == "PACKAGEAMOUNT")
                        {
                            dr["AMOUNT"] = Math.Ceiling(int.Parse(packageamount) * float.Parse(strPackage));
                        }
                        if (this.gridView3.FocusedColumn.FieldName.ToUpper() == "AMOUNT")
                        {
                            //计算浮点的最小整数
                            dr["PACKAGEAMOUNT"] = Math.Floor(float.Parse(dr["AMOUNT"].ToString()) / float.Parse(strPackage));
                        }
                    }
                }

                //更改标题金额
                setRequestTotal();
            }

        }

        /// <summary>
        /// 已添加项目改变事件，改变配送商
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (this.gridView3.RowCount == 0)
                return;
            DataRow dr = this.gridView3.GetDataRow(this.gridView3.FocusedRowHandle);
            if (dr != null)
            {
                string strProjectID = dr["PROJECT_ID"].ToString();
                string strProjectProdID = dr["PROJECT_PROD_ID"].ToString();
                //初始化配送商
                this.LueSender.EditValue = null;//改变项目清空配送商
                InitData_BuyerSender(base.CurrentUserOrgId, strProjectID, strProjectProdID);
                InitData_StoreRoom();
            }

        }
        //选择采购目录（项目产品目录，经常采购目录）
        private void cmbProductItem_TextChanged(object sender, EventArgs e)
        {
            if (this.cmbProductItem.Text == "经常采购目录")
            {
                cehistory.Visible = true;
                LblSenderName.Visible = true;
                txtSenderName.Visible = true;
                this.gVOrdProduct.Columns["SENDER_NAME_ABBR"].Visible = true;
            }
            else
            {
                cehistory.Visible = false;
                LblSenderName.Visible = false;
                txtSenderName.Visible = false;
                this.gVOrdProduct.Columns["SENDER_NAME_ABBR"].Visible = false;
            }
            if (this.LueProject.EditValue == null)
            {
                XtraMessageBox.Show("请选择来源项目！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //绑定项目产品
            OrdProductBind();

        }
        //选择是否使用历史采购
        private void cehistory_CheckedChanged(object sender, EventArgs e)
        {

            if (this.cehistory.Checked == true)
            {
                this.LelFrom.Visible = true;
                this.cmdCreateDate.Visible = true;
                labelControl11.Visible = true;
                this.cmdEndDate.Visible = true;
                this.cmbProductItem.Enabled = false;
                this.cmdEndDate.DateTime = DateTime.Now;
                this.cmdCreateDate.DateTime = DateTime.Now.AddMonths(-3);

            }
            else
            {
                this.LelFrom.Visible = false;
                this.cmdCreateDate.Visible = false;
                labelControl11.Visible = false;
                this.cmdEndDate.Visible = false;
                this.cmbProductItem.Enabled = true;
                Filter_Product();
            }
        }

        ////双击项目产品目录
        private void gVOrdProduct_DoubleClick_1(object sender, EventArgs e)
        {
            if (this.btnAdd.Enabled == true)
            {
                this.btnAdd_Click(sender, e);
            }

        }
        //采购目录回车添加到采购明细
        private void gVOrdProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.btnAdd_Click(sender, e);
            }
            
        }


        private void gVOrdProduct_RowCountChanged(object sender, EventArgs e)
        {
            labelControl9.Text = "    共 " + base.cachedDataView.Count + "条数据";
        }

        private void gridView3_RowCountChanged(object sender, EventArgs e)
        {
            labelRecordcount.Text = "    共 " + this.gridView3.RowCount + " 条数据";
        }
        /// <summary>
        /// 更改配送商事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LueSender_EditValueChanged(object sender, EventArgs e)
        {
            if (lcstate.Text.Equals("审核通过"))
                return;

            if (this.LueSender.EditValue == null)
                return;

            if (this.gridView3.RowCount == 0)
                return;

            if (SenderDt == null)
                return;

            if (SenderDt.DefaultView.Count == 0)
                return;

            DataRow dr = this.gridView3.GetDataRow(this.gridView3.FocusedRowHandle);

            if (dr != null)
            {
                dr["SENDER_ID"] = this.LueSender.EditValue.ToString();
                dr["SENDER_NAME_ABBR"] = this.LueSender.Text.ToString();

                DataTable dt = SenderDt.DefaultView.ToTable();
                dt.DefaultView.RowFilter = string.Format("SENDER_ID ='{0}'", LueSender.EditValue.ToString());
                dr["SENDER_NAME"] = dt.DefaultView.ToTable().Rows[0]["SENDER_NAME"].ToString();
            }

            btnSave.Enabled = true;

            if (this.Text != "审核采购单")
                BtnPostSend.Enabled = true;

            editFlag = true;
        }

        private void gVOrdProduct_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            DataRow dr = (DataRow)gVOrdProduct.GetDataRow(e.RowHandle);
            if (string.IsNullOrEmpty(dr["REG_VALID_DATE"].ToString()))
                return;
            if (DateTime.Compare(Convert.ToDateTime(dr["REG_VALID_DATE"].ToString()), DateTime.Now) < 0)
            {
                e.Appearance.ForeColor = Color.Red;
            }

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

        private void gVOrdProduct_Click(object sender, EventArgs e)
        {
            DataRow dr = this.gVOrdProduct.GetDataRow(this.gVOrdProduct.FocusedRowHandle);
            if (dr != null)
            {
                if (this.gVOrdProduct.FocusedColumn.FieldName.ToUpper() == "SALER_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["SALER_NAME"].ToString());

                else if (this.gVOrdProduct.FocusedColumn.FieldName.ToUpper() == "MANU_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["MANU_NAME"].ToString());

                else if (this.gVOrdProduct.FocusedColumn.FieldName.ToUpper() == "SENDER_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["SENDER_NAME"].ToString());

                else
                    toolTipController1.HideHint();
            }
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

        private void FormPurchaseCreate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.btnAdd_Click(sender, e);
            }
        }

        //过滤品种分类
        private void Filter_ProjectClass(string strProjectID)
        {
            dtProductClass.DefaultView.RowFilter = string.Format(" ID=0 Or PROJECT_ID='{0}'", strProjectID);
            LueProductClass.EditValue = 0;//默认为“全部”
        }
        //整单库房选择
        private void LueStoreroom_EditValueChanged(object sender, EventArgs e)
        {
            if (lcstate.Text.Equals("审核通过"))
                return;

            foreach (DataRow r in dtPurchaseItem.Rows)
            {
                r["STORE_ROOM_ID"] = this.LueStoreroom.EditValue.ToString();
                r["STORE_ROOM_NAME"] = this.LueStoreroom.Text.ToString();
            }

            if (this.Text != "审核采购单")
                editFlag = true;

        }

        #region 限止价格只充许输入数字字符、退格及点号键
        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                this.txtPrice.Text = Emedchina.Commons.StringUtils.ToDBC(this.txtPrice.Text);
                e.Handled = true;
            }
        }
        #endregion

        /// <summary>
        /// 保存采购单并发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPostSend_Click(object sender, EventArgs e)
        {
            //判断是否删除空采购单
            if (DelPurchase())
                return;

            //校验数据
            string strError = string.Empty;
            if (!checkInput(out strError))
            {
                checkFlag = false;
                XtraMessageBox.Show(strError, Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            checkFlag = true;
            editFlag = false;

            //获取数据保存模型
            getPurchaseSaveModelList();
                        
            try
            {
                //调用采购单保存事件
                PurchaseSave();
                //调用发送采购单事件
                bool flag = new PurchaseOfflineBLL().putCheckPurchaseOffline(output.PurchaseId);
                if (flag == true)
                {
                    lcPurchaseCode.Text = output.PurchaseCode;
                    lcstate.Text = "送审";
                    XtraMessageBox.Show("采购单保存并送审成功！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("采购单保存并送审失败！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("采购单保存并送审失败！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                checkFlag = false;
                return;
            }
        }

        private void SpecLue_EditValueChanged(object sender, EventArgs e)
        {
            if (this.gridView3.RowCount == 0)
                return;

            DevExpress.XtraEditors.LookUpEdit LueText = (DevExpress.XtraEditors.LookUpEdit)sender;

            DataRow dr = this.gridView3.GetDataRow(this.gridView3.FocusedRowHandle);

            if (dr != null)
            {
                dr["SPEC"] = LueText.Text.ToString();
            }
        }

        private void ModelLue_EditValueChanged(object sender, EventArgs e)
        {
            if (this.gridView3.RowCount == 0)
                return;

            DevExpress.XtraEditors.LookUpEdit LueText = (DevExpress.XtraEditors.LookUpEdit)sender;

            DataRow dr = this.gridView3.GetDataRow(this.gridView3.FocusedRowHandle);

            if (dr != null)
            {
                dr["MODEL"] = LueText.Text.ToString();
            }
        }

        private void StoreRoomLue_EditValueChanged(object sender, EventArgs e)
        {
            if (this.gridView3.RowCount == 0)
                return;

            DevExpress.XtraEditors.LookUpEdit LueText = (DevExpress.XtraEditors.LookUpEdit)sender;

            DataRow dr = this.gridView3.GetDataRow(this.gridView3.FocusedRowHandle);

            if (dr != null)
            {
                dr["STORE_ROOM_NAME"] = LueText.Text.ToString();
            }
        }

        #region 按品名过滤
        private void txtCommName_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        /// <summary>
        /// 查询过滤方法
        /// </summary>
        private void Filter()
        {
            StringBuilder StrFilter = new StringBuilder();

            string strProductName = this.txtCommName.Text.Trim();

            StrFilter.Append(" 1=1");

            //通用名称
            if (!string.IsNullOrEmpty(strProductName))
            {
                StrFilter.AppendFormat(" AND (PRODUCT_NAME LIKE '%{0}%' Or COMMON_NAME LIKE '%{0}%' Or ABBR_PY LIKE '%{0}%' Or ABBR_WB LIKE '%{0}%')", strProductName);
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

        #region 退出事件
        private void BtnExit_Click(object sender, EventArgs e)
        {
            if (editFlag)
            {
                if (XtraMessageBox.Show("采购单没有保存，是否保存？", Constant.MsgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btnSave_Click(null, null);
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }
        #endregion


        private void LueProjectType_EditValueChanged(object sender, EventArgs e)
        {
            LueProject.Focus();
        }

        private void LueProductClass_EditValueChanged(object sender, EventArgs e)
        {
            txtPrice.Focus();
        }

        private void LueProjectType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.LueProject.Focus();
            }
        }

        private void LueProject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.LueProductClass.Focus();
            }
        }

        private void LueProductClass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtPrice.Focus();
            }
        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtBid_Id.Focus();
            }
        }

        private void txtBid_Id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtCommerceName.Focus();
            }
        }

        private void txtCommerceName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtSpec.Focus();
            }
        }

        private void txtSpec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtModel.Focus();
            }
        }

        private void txtModel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtSalerName.Focus();
            }
        }

        private void txtSalerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtManuName.Focus();
            }
        }

        private void txtManuName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (txtSenderName.Visible)
                {
                    this.txtSenderName.Focus();
                }
                else
                {
                    this.cmbProductItem.Focus();
                }
            }
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            this.txtPrice.Text = Emedchina.Commons.StringUtils.ToDBC(this.txtPrice.Text);
        }



    }
}

