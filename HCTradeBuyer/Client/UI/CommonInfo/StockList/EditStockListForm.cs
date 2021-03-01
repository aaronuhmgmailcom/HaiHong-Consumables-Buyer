//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	EditStockListForm.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	新建经常采购供应目录
//	修 改 人: 
//	修改日期:
//=====================================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;

using Emedchina.Commons;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Client.BLL;
using Emedchina.TradeAssistant.Model.CommInfo;
using Emedchina.TradeAssistant.Client.Common;
using Emedchina.TradeAssistant.Client.BLL.CommonInfo;
using System.Threading;

namespace Emedchina.TradeAssistant.Client.UI.CommonInfo.StockList
{
    /// <summary>
    /// 新建经常采购供应目录
    /// </summary>
    public partial class EditStockListForm : BaseForm
    {
        #region 变量定义区

        //修改标志
        public bool EditFlag = false;
        
        //项目产品数据集对象数据集
        private DataTable OrdProductDt = null;

        //项目产品数据集对象数据集 临时使用
        private DataTable OrdProductTempDt = null;

        //产品分类数据集
        private DataTable dtProductClass = null;

        //配送商目录
        private DataTable SenderDt = null;

        //库房目录
        private DataTable dtStone = null;

        //获取当取用户对象
        LogedInUser CurrentUser = null;

        //采购供应目录列表
        DataTable dtHitComm = null;
        private Thread thread;

        #endregion

        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public EditStockListForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 项目产品数据绑定
        /// <summary>
        /// 项目产品数据绑定
        /// </summary>
        private void OrdProductBind()
        {
            //当前所选项目ID
            string strProjectID = this.LueProject.EditValue.ToString();

            //使用缓存 获取采购目录查询数据集
            string strDataName = Constant.ORDPRODUCT + strProjectID;
            if (ClientCache.CachedDS.Tables.IndexOf(strDataName) == -1)
            {
                DataTable tempDt = new DataTable(strDataName);

                //获取项目产品数据集
                tempDt = OrdProductBLL.GetInstance().GetOrdProductDt(strProjectID, CurrentUser, strDataName);

                OrdProductDt = tempDt.Copy();

                if (ClientCache.CachedDS.Tables.IndexOf(strDataName) != -1)
                    ClientCache.CachedDS.Tables.Remove(strDataName);
                ClientCache.CachedDS.Tables.Add(OrdProductDt);
            }

            //存入缓存
            InitFromCacheByData(strDataName);

            //清除缓存中查询条件
            if (base.cachedDataView != null)
            {
                base.cachedDataView.RowFilter = "";
            }

            //从缓存取数据集绑定到GRID
            bindingDsOrdProduct();
        }
        #endregion

        #region 绑定到GRID中
        /// <summary>
        /// 绑定到GRID中
        /// </summary>
        private void bindingDsOrdProduct()
        {
            this.bindingSource1.DataSource = base.cachedDataView;
            //if (OrdProductDt == null || OrdProductDt.Rows.Count < 1)
            //{
                OrdProductDt = base.cachedDataView.Table;
            //}

            OrdProductTempDt = OrdProductDt.Copy();
        }
        #endregion

        #region 页面加载
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditStockListForm_Load(object sender, EventArgs e)
        {
            //获取当前用户对象
            CurrentUser = base.CurrentUser;

            //thread = new Thread(new ThreadStart(ShowWaiting));
            //thread.Start();
            //绑定项目产品
            //OrdProductBind();
            //初始化添加采购供应目录列表
            IniTempHitCommData();

            //初始化下拉列表
            InitData();

            //初始货表格下拉框
            InitGrid_Cmb();

            //thread.Abort();
        }


        #endregion

        #region 显示等待窗体
        //显示等待窗体
        private void ShowWaiting()
        {
            LoadDataWaiting frm = new LoadDataWaiting("");
            frm.ShowDialog();
        }
        #endregion

        #region 初始化添加采购供应目录列表
        /// <summary>
        /// 初始化添加采购供应目录列表
        /// </summary>
        private void IniTempHitCommData()
        {
            dtHitComm = new DataTable();

            dtHitComm.Columns.Add("PROJECT_ID");        //项目ID
            dtHitComm.Columns.Add("DATA_PRODUCT_ID");   //中心产品ID
            dtHitComm.Columns.Add("CONT_PRODUCT_ID");   //合同商品ID
            dtHitComm.Columns.Add("PROJECT_PROD_ID");   //项目产品ID
            dtHitComm.Columns.Add("PRODUCT_NAME");      //商品名
            dtHitComm.Columns.Add("COMMERCE_NAME");     //商品名
            dtHitComm.Columns.Add("SPEC_ID");           //规格ID
            dtHitComm.Columns.Add("MODEL_ID");          //型号ID
            dtHitComm.Columns.Add("SPEC");           //规格
            dtHitComm.Columns.Add("MODEL");          //型号
            dtHitComm.Columns.Add("SENDER_NAME");       //配送商
            dtHitComm.Columns.Add("SENDER_NAME_ABBR");       //配送商简称
            dtHitComm.Columns.Add("BASE_MEASURE");      //基础计量单位
            dtHitComm.Columns.Add("MANU_NAME");         //生产企业
            dtHitComm.Columns.Add("MANU_NAME_ABBR");    //生产企业简称

            dtHitComm.Columns.Add("SALER_NAME");        //经销企业
            dtHitComm.Columns.Add("SALER_NAME_ABBR");   //经销企业简称
            dtHitComm.Columns.Add("COMMON_NAME");       //通用名
            dtHitComm.Columns.Add("ABBR_PY");           //拼音简码
            dtHitComm.Columns.Add("ABBR_WB");           //五笔简码
            dtHitComm.Columns.Add("BRAND");             //品牌
            dtHitComm.Columns.Add("PRICE");             //单价
            dtHitComm.Columns.Add("PRODUCTCODE");       //编码
            dtHitComm.Columns.Add("GOODS_NO");          //货号
            dtHitComm.Columns.Add("BARCODE");           //条码
            dtHitComm.Columns.Add("BASE_MEASURE_SPEC"); //基础单位规格
            dtHitComm.Columns.Add("BASE_MEASURE_MATER"); //基础单位包装材质
            dtHitComm.Columns.Add("MAX_PRICE");         //最高限价
            dtHitComm.Columns.Add("MANU_ID");           //生产企业ID
            dtHitComm.Columns.Add("SALER_ID");          //经销企业ID
            dtHitComm.Columns.Add("SENDER_ID");         //配送企业ID
            dtHitComm.Columns.Add("STORE_ROOM_ID");     //库房ID
            dtHitComm.Columns.Add("STORE_ROOM_NAME");   //库房名称

            dtHitComm.Columns.Add("DEFAULT_MEASURE");        //配送单位
            dtHitComm.Columns.Add("DEFAULT_MEASURE_EX");     //配送单位转换率
            dtHitComm.Columns.Add("INSTRU_CODE");        //器械编码
            dtHitComm.Columns.Add("INSTRU_NAME");           //器械名称

            dtHitComm.Columns.Add("REG_NO");            //注册证号
            dtHitComm.Columns.Add("REG_VALID_DATE");    //注册证有效期截止日期

            dtHitComm.Columns.Add("PRODUCT_MNEMONIC");  //自定义编码
            dtHitComm.Columns.Add("SELF_PACKAGE");      //大包装
            dtHitComm.Columns.Add("ALIAS");             //别名
            dtHitComm.Columns.Add("ALIAS_PINYIN");      //别名拼音
            
            dtHitComm.AcceptChanges();

            this.bindingSource2.DataSource = dtHitComm.DefaultView;

        }
        #endregion

        #region 添加项目产品到常用采购目录
        /// <summary>
        /// 添加项目产品到常用采购目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddHitComm_Click(object sender, EventArgs e)
        {
            if (this.gVOrdProduct.RowCount == 0)
                return;
            
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
                    OrdProductTempDt.DefaultView.RowFilter = string.Format("PackName='{0}'", strPackName);

                    DataTable DtTemp = OrdProductTempDt.DefaultView.ToTable();

                    foreach (DataRow dr in DtTemp.Rows)
                    {
                        OrdProductModel ordProductModel = GetOrdProductModelByTreeList(dr);
                        AddHitCommView(ordProductModel);
                    }
                }
            }
            else
            {
                //获取当前项目产品对象
                DataRow dr = (DataRow)this.gVOrdProduct.GetDataRow(this.gVOrdProduct.FocusedRowHandle);

                if (dr == null)
                    return;

                OrdProductModel ordProductModel = GetOrdProductModelByTreeList(dr);
                AddHitCommView(ordProductModel);
            }

            //清空制单时用到供应目录缓存
            string strProjectID = this.LueProject.EditValue.ToString();
            string strDataName = Constant.ORDPRODUCT + strProjectID + "经常采购目录";
            if (ClientCache.CachedDS.Tables.IndexOf(strDataName) != -1)
                ClientCache.CachedDS.Tables.Remove(strDataName);
        }

        /// <summary>
        /// 添加到采购供应目录
        /// </summary>
        /// <param name="ordProductModel"></param>
        private void AddHitCommView(OrdProductModel ordProductModel)
        {
            DataRow dr = dtHitComm.NewRow();

            dr["PROJECT_ID"] = ordProductModel.Project_Id;
            dr["DATA_PRODUCT_ID"] = ordProductModel.Data_Product_Id;
            dr["CONT_PRODUCT_ID"] = ordProductModel.Cont_Product_Id;
            dr["PROJECT_PROD_ID"] = ordProductModel.Project_Prod_Id;
            dr["COMMERCE_NAME"] = ordProductModel.Product_Name;//商品名
            dr["PRODUCT_NAME"] = ordProductModel.Product_Name;//商品名
            dr["SPEC"] = ordProductModel.Spec;
            dr["MODEL"] = ordProductModel.Model;
            //dr["STORE_ROOM_NAME"] = ordProductModel.;
            dr["BASE_MEASURE"] = ordProductModel.Base_Measure;
            dr["MANU_NAME"] = ordProductModel.ManuName;
            dr["MANU_NAME_ABBR"] = ordProductModel.ManuName_Abbr;
            dr["SALER_NAME"] = ordProductModel.SalerName;
            dr["SALER_NAME_ABBR"] = ordProductModel.SalerNameAbbr;
            dr["COMMON_NAME"] = ordProductModel.Common_Name;
            dr["PRODUCT_NAME"] = ordProductModel.Product_Name;
            dr["ABBR_PY"] = ordProductModel.Abbr_py;
            dr["ABBR_WB"] = ordProductModel.Abbr_wb;
            dr["BRAND"] = ordProductModel.Brand;
            dr["PRICE"] = System.Math.Round(Convert.ToDecimal(ordProductModel.Price),2);
            dr["PRODUCTCODE"] = ordProductModel.Code;
            dr["BASE_MEASURE"] = ordProductModel.Base_Measure;
            dr["GOODS_NO"] = ordProductModel.GoodsNo;
            dr["BARCODE"] = ordProductModel.Barcode;
            dr["BASE_MEASURE_SPEC"] = ordProductModel.Base_Measure_Spec;
            dr["BASE_MEASURE_MATER"] = ordProductModel.Base_Measure_Mate;
            dr["DEFAULT_MEASURE"] = ordProductModel.Measure;
            dr["DEFAULT_MEASURE_EX"] = ordProductModel.DefaultMeasureEx;
            dr["MAX_PRICE"] = ordProductModel.Max_Price;
            dr["MANU_ID"] = ordProductModel.Manu_Id;
            dr["SALER_ID"] = ordProductModel.Saler_Id;

            dr["INSTRU_CODE"] = ordProductModel.Instru_Code;
            dr["INSTRU_NAME"] = ordProductModel.Instru_Name;
            
            //dr["SENDER_ID"] = ordProductModel.Sender_Id;
            //注册证号及有效日期
            dr["REG_NO"] = ordProductModel.Reg_No;
            dr["REG_VALID_DATE"] = ordProductModel.Reg_Valid_Date;

            //默认显示第一个库房
            if (dtStone.Rows.Count > 0)
                dr["STORE_ROOM_ID"] = dtStone.Rows[0]["STORE_ID"].ToString().Trim();

            dtHitComm.Rows.Add(dr);
        }
        
        #endregion

        #region 获取当前选择项目产品记录对象
        /// <summary>
        /// 获取当前选择项目产品记录对象
        /// </summary>
        /// <returns></returns>
        private OrdProductModel GetOrdProductModelByTreeList(DataRow dr)
        {
            OrdProductModel model = new OrdProductModel();

            if (dr == null)
                return null;

            model.Project_Id = dr["PROJECT_ID"].ToString().Trim();
            model.Data_Product_Id = dr["DATA_PRODUCT_ID"].ToString().Trim();
            model.Cont_Product_Id = "";//dr["CONT_PRODUCT_ID"].ToString().Trim();
            model.Project_Prod_Id = dr["PROJECT_PROD_ID"].ToString().Trim();
            model.Spec = dr["SPEC"].ToString().Trim();
            model.Model = dr["MODEL"].ToString().Trim();
            model.Base_Measure = dr["BASE_MEASURE"].ToString().Trim();
            model.ManuName = dr["MANU_NAME"].ToString().Trim();
            model.ManuName_Abbr = dr["MANU_NAME_ABBR"].ToString().Trim();
            model.SalerName = dr["SALER_NAME"].ToString().Trim();
            model.SalerNameAbbr = dr["SALER_NAME_ABBR"].ToString().Trim();
            model.Commerce_Name = dr["COMMERCE_NAME"].ToString().Trim();
            model.Common_Name = dr["COMMON_NAME"].ToString().Trim();
            model.Product_Name = dr["PRODUCT_NAME"].ToString().Trim();
            model.Abbr_py = dr["ABBR_PY"].ToString().Trim();
            model.Abbr_wb = dr["ABBR_WB"].ToString().Trim();
            model.Brand = dr["BRAND"].ToString().Trim();
            model.Price = Convert.ToDecimal(dr["PRICE"].ToString().Trim());
            model.Code = dr["ProductCode"].ToString().Trim();
            model.GoodsNo = dr["GOODS_NO"].ToString().Trim();
            model.Barcode = dr["BARCODE"].ToString().Trim();
            model.Base_Measure_Spec = dr["BASE_MEASURE_SPEC"].ToString().Trim();
            model.Base_Measure_Mate = dr["BASE_MEASURE_MATER"].ToString().Trim();
            model.Measure = dr["DEFAULT_MEASURE"].ToString().Trim();
            model.DefaultMeasureEx = dr["DEFAULT_MEASURE_EX"].ToString().Trim();
            model.Max_Price = dr["MAX_PRICE"].ToString().Trim();
            model.Manu_Id = dr["MANU_ID"].ToString().Trim();
            model.Saler_Id = dr["SALER_ID"].ToString().Trim();
            model.Instru_Code = dr["INSTRU_CODE"].ToString().Trim();
            model.Instru_Name = dr["INSTRU_NAME"].ToString().Trim();
            //model.Sender_Id = dr["SENDER_ID"].ToString();
            model.Reg_No = dr["REG_NO"].ToString().Trim();
            model.Reg_Valid_Date = dr["REG_VALID_DATE"].ToString().Trim();
            return model;
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
            //初始化规格下拉框
            InitData_SpecInfo();
            //初始化型号下拉框
            InitData_ModelInfo();
        }

        /// <summary>
        /// 初始化库房下拉框
        /// </summary>
        private void InitData_StoneInfo()
        {
            dtStone = CommUtilBLL.GetInstance().GetBuyerStoreInfo(CurrentUser.UserOrg.Id);
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

        #region 初始化列表
        /// <summary>
        /// 初始化
        /// </summary>
        private void InitData()
        {
            InitData_ProjectType();
            InitData_Project();
            InitData_ProjectClass();
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
            //LueProjectType.Properties.Columns.Clear();
            //LueProjectType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", 100, "类型名称"));
            //LueProjectType.Properties.DisplayMember = "Name";
            //LueProjectType.Properties.ValueMember = "value";
            LueProjectType.Properties.NullText = "";

            //设置默认值
            LueProjectType.EditValue = "0";
        }
        //绑定项目名称
        private void InitData_Project()
        {
            //绑定项目名称
            DataTable dtPro = CommUtilBLL.GetInstance().GetProjectInfoByProjectType("");

            LueProject.Properties.DataSource = dtPro;
            LueProject.Properties.Columns.Clear();
            LueProject.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PROJECT_NAME", 200, "项目名称"));
            LueProject.Properties.DisplayMember = "PROJECT_NAME";
            LueProject.Properties.ValueMember = "ID";
            LueProject.Properties.NullText = "请选择项目";

            //默认显示第一个项目
            string DefaultProjectID = dtPro.Rows[0]["ID"].ToString().Trim();
            LueProject.EditValue = Convert.ToInt32(DefaultProjectID);
        }
        //绑定品种分类
        private void InitData_ProjectClass()
        {
            //绑定品种分类信息
            dtProductClass = CommUtilBLL.GetInstance().GetProductClassInfoByProjectID("");

            this.LueProductClass.Properties.DataSource = dtProductClass;
            //LueProductClass.Properties.Columns.Clear();
            //LueProductClass.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLASS_NAME", 100, "分类名称"));
            //LueProductClass.Properties.DisplayMember = "CLASS_NAME";
            //LueProductClass.Properties.ValueMember = "ID";
            LueProductClass.Properties.NullText = "全部";

            LueProductClass.EditValue = 0;//默认为“全部”
        }

        /// <summary>
        /// 根据买方ID，项目ID，项目产品ID绑定配送商
        /// </summary>
        /// <param name="buyerId"></param>
        /// <param name="projectId"></param>
        /// <param name="projectProdId"></param>
        private void InitData_BuyerSender(string buyerId, string projectId, string projectProdId)
        {
            SenderDt = CommUtilBLL.GetInstance().GetSenderInfo(buyerId, projectId, projectProdId);
            LueSender.Properties.DataSource = null;
            LueSender.Properties.DataSource = SenderDt;
            //LueSender.Properties.Columns.Clear();
            //LueSender.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SENDER_NAME", 100, "配送商名称"));
            //LueSender.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SENDER_ABBR", 100, "配送商名称"));
            //LueSender.Properties.Columns["SENDER_ABBR"].Visible 
            //LueSender.Properties.DisplayMember = "SENDER_NAME";
            //LueSender.Properties.ValueMember = "SENDER_ID";
            LueSender.Properties.NullText = "请选择";

        }

        private void Filter_ProjectClass(string strProjectID)
        {
            dtProductClass.DefaultView.RowFilter = string.Format(" ID=0 Or PROJECT_ID='{0}'", strProjectID);
            LueProductClass.EditValue = 0;//默认为“全部”
        }

        #endregion

        #region 移除已添加项
        /// <summary>
        /// 移除已添加项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dtHitComm != null)
            {
                if (dtHitComm.Rows.Count == 0)
                    return;

                DataRow dr = dtHitComm.Rows[gvHitComm.FocusedRowHandle];
                dtHitComm.Rows.Remove(dr);
                dtHitComm.AcceptChanges();
            }
        }
        #endregion

        #region 保存到采购供应目录
        /// <summary>
        /// 保存到采购供应目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPost_Click(object sender, EventArgs e)
        {            
            //数据验证
            string strError = string.Empty;
            if (!Validata(out strError))
            {
                XtraMessageBox.Show(strError, Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //获取保存采购供应目录对象集
            List<OrdHitCommMode> ListOrdHitCommModel = new List<OrdHitCommMode>();
            foreach (DataRow dr in dtHitComm.Rows)
            {
                OrdHitCommMode model = GetOrdHitCommModel(dr);

                ListOrdHitCommModel.Add(model);
            }
            try
            {
                //保存至采购供应目录
                StockListBLL.GetInstance().SaveOrdHitCommListModel(ListOrdHitCommModel, CurrentUser);
                XtraMessageBox.Show("经常采购目录新增成功", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                EditFlag = true;

                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("经常采购目录新增失败", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 数据验证
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private bool Validata(out string Error)
        {
            Error = string.Empty;

            if (dtHitComm.Rows.Count == 0)
            {
                Error = "请添加项目产品产品！";
                return false;
            }

            foreach (DataRow dr in dtHitComm.Rows)
            {
                if (string.IsNullOrEmpty(dr["SPEC_ID"].ToString()))
                {
                    Error = "请选择规格！";
                    return false;
                }
                else if (string.IsNullOrEmpty(dr["MODEL_ID"].ToString()))
                {
                    Error = "请选择型号！";
                    return false;
                }
                else if (string.IsNullOrEmpty(dr["STORE_ROOM_ID"].ToString()))
                {
                    Error = "请选择库房！";
                    return false;
                }
                else if (string.IsNullOrEmpty(dr["SENDER_ID"].ToString()))
                {
                    Error = "请选择配送商！";
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 获取当前采购供应目录对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private OrdHitCommMode GetOrdHitCommModel(DataRow dr)
        {
            OrdHitCommMode model = new OrdHitCommMode();

            model.Project_Id            = dr["PROJECT_ID"].ToString();                  //项目ID
            model.Project_Product_Id    = dr["PROJECT_PROD_ID"].ToString();             //项目产品ID
            model.Data_Product_Id       = dr["DATA_PRODUCT_ID"].ToString();             //数据产品ID
            model.Cont_Product_Id       = dr["CONT_PRODUCT_ID"].ToString();             //合同产品ID
            model.Commerce_Name         = dr["COMMERCE_NAME"].ToString();               //商品名称
            model.Product_Name          = dr["PRODUCT_NAME"].ToString();                //商品名称
            model.Common_Name           = dr["COMMON_NAME"].ToString();                 //通用名称
            model.Spec_Id               = dr["SPEC_ID"].ToString();                     //规格ID
            model.Model_Id              = dr["MODEL_ID"].ToString();                    //型号ID
            model.Spec                  = dr["SPEC"].ToString();                        //规格
            model.Model                 = dr["MODEL"].ToString();                       //型号
            model.Measure               = dr["BASE_MEASURE"].ToString();                //基础计量单位
            model.ManuName              = dr["MANU_NAME"].ToString();                   //生产企业
            model.ManuNameAbbr          = dr["MANU_NAME_ABBR"].ToString();              //生产企业简称
            model.SalerName             = dr["SALER_NAME"].ToString();                  //经销企业
            model.SalerNameAbbr         = dr["SALER_NAME_ABBR"].ToString();             //经销企业简称
            model.Abbr_py               = dr["ABBR_PY"].ToString();                     //拼音简称
            model.Abbr_wb               = dr["ABBR_WB"].ToString();                     //五笔简称
            model.Brand                 = dr["BRAND"].ToString();                       //品牌
            model.Price                 = dr["PRICE"].ToString();                       //单价
            model.Code                  = dr["PRODUCTCODE"].ToString();                 //产品编码
            model.GoodsNo               = dr["GOODS_NO"].ToString();                    //货号
            model.Barcode               = dr["BARCODE"].ToString();                     //条码
            model.Base_Measure_Spec     = dr["BASE_MEASURE_SPEC"].ToString();           //基础单位规格
            model.Base_Measure_Mater    = dr["BASE_MEASURE_MATER"].ToString();          //基础单位包装材质
            model.Measure               = dr["DEFAULT_MEASURE"].ToString();             //缺省配送单位
            model.DefaultMeasureEx      = dr["DEFAULT_MEASURE_EX"].ToString();          //缺省配送单位转换率
            model.Max_Price             = dr["MAX_PRICE"].ToString();                   //最高限价
            model.Manu_Id               = dr["MANU_ID"].ToString();                     //生产企业ID
            model.Saler_Id              = dr["SALER_ID"].ToString();                    //经销企业ID
            model.Sender_Id             = dr["SENDER_ID"].ToString();                   //配送企业ID
            model.SenderName            = dr["SENDER_NAME"].ToString();                 //配送企业名称
            model.SenderNameAbbr        = dr["SENDER_NAME_ABBR"].ToString();            //配送企业简称
            model.Store_Room_Id         = dr["STORE_ROOM_ID"].ToString();               //库房ID
            model.StoreRoomName         = dr["STORE_ROOM_NAME"].ToString();             //库房名称

            model.RegNo                 = dr["REG_NO"].ToString();                      //产品注册证号
            model.RegValidDate          = dr["REG_VALID_DATE"].ToString();              //产品注册有效期

            model.ProductMnemonic       = dr["PRODUCT_MNEMONIC"].ToString();            //自定义编码
            model.SelfPackage           = dr["SELF_PACKAGE"].ToString();                //大包装
            model.Alias                 = dr["ALIAS"].ToString();                       //别名
            model.AliasPinyin           = dr["ALIAS_PINYIN"].ToString();                //别名拼音

            return model;
        }

        #endregion

        #region 根据通用名过滤
        /// <summary>
        /// 根据通用名过滤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                StrFilter.AppendFormat(" AND (PRODUCT_NAME LIKE '%{0}%' Or COMMON_NAME LIKE '%{0}%' Or ABBR_PY LIKE '%{0}%' Or ABBR_WB LIKE '%{0}%' Or PRODUCT_MNEMONIC LIKE '%{0}%' Or ALIAS LIKE '%{0}%' Or ALIAS_PINYIN LIKE '%{0}%')", strProductName);
            }

            if (dtHitComm != null)
            {
                if (dtHitComm.DefaultView != null)
                {
                    this.dtHitComm.DefaultView.RowFilter = StrFilter.ToString();
                    this.OrdProductTempDt = this.dtHitComm.DefaultView.ToTable();
                }
            }

        }
        #endregion

        #region 加入序号
        /// <summary>
        /// 加入序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvHitComm_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            int rowIndex = e.RowHandle;
            if (rowIndex >= 0)
            {
                rowIndex++;
                e.Info.DisplayText = rowIndex.ToString();
            }
            e.Info.ImageIndex = -1;
        }
        #endregion

        #region 关闭事件
        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

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
            string SpecModel = this.txtSpecModel.Text.Trim();
            string ManuName = this.txtManuName.Text.Trim();
            string SalerName = this.txtSalerName.Text.Trim();
            string Price = this.txtPrice.Text.Trim();
            //招标序号
            string strbid_id = this.txtBid_Id.Text.Trim();

            //配套名称
            string strPackage = this.txtPackage.Text.Trim();

            StringBuilder StrFilter = new StringBuilder();

            StrFilter.Append("1=1");

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
                StrFilter.AppendFormat(" AND (PRODUCT_NAME LIKE '%{0}%' Or COMMON_NAME LIKE '%{0}%' Or ABBR_PY LIKE '%{0}%' Or ABBR_WB LIKE '%{0}%')", ProductName);
            }

            //规格型号
            if (!string.IsNullOrEmpty(SpecModel))
            {
                StrFilter.AppendFormat(" AND (SPEC LIKE '%{0}%' Or MODEL LIKE '%{0}%')", SpecModel);
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

            //配套名称
            if (!string.IsNullOrEmpty(strPackage))
            {
                StrFilter.AppendFormat(" AND PackName LIKE '%{0}%'", strPackage);
            }

            //价格
            if (!string.IsNullOrEmpty(Price))
            {
                Price = Emedchina.Commons.StringUtils.ToDBC(Price);
                StrFilter.AppendFormat(" AND Price = '{0}'", Price);
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

        #region 按条件查询事件
        private void Found_TextChanged(object sender, EventArgs e)
        {
            Filter_Product();
            this.gVOrdProduct.ExpandAllGroups();

        }
        #endregion

        /// <summary>
        /// 更改配送商事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LueSender_EditValueChanged(object sender, EventArgs e)
        {
            if (this.LueSender.EditValue == null)
                return;

            if (this.gvHitComm.RowCount == 0)
                return;

            if (SenderDt == null)
                return;

            if (SenderDt.DefaultView.Count == 0)
                return;

            DataRow dr = this.gvHitComm.GetDataRow(this.gvHitComm.FocusedRowHandle);

            if (dr != null)
            {
                dr["SENDER_ID"] = this.LueSender.EditValue.ToString();
                dr["SENDER_NAME_ABBR"] = this.LueSender.Text.ToString();

                DataTable dt = SenderDt.DefaultView.ToTable();
                dt.DefaultView.RowFilter = string.Format("SENDER_ID ='{0}'", LueSender.EditValue.ToString());
                dr["SENDER_NAME"] = dt.DefaultView.ToTable().Rows[0]["SENDER_NAME"].ToString();
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
        }

        /// <summary>
        /// 选择规格值改变事件，对规格名称进行赋值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpecLue_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit LueText = (DevExpress.XtraEditors.LookUpEdit)sender;

            DataRow dr = this.gvHitComm.GetDataRow(this.gvHitComm.FocusedRowHandle);

            if (dr != null)
            {
                dr["SPEC"] = LueText.Text;
            }
        }

        /// <summary>
        /// 型号值改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModelLue_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit LueText = (DevExpress.XtraEditors.LookUpEdit)sender;

            DataRow dr = this.gvHitComm.GetDataRow(this.gvHitComm.FocusedRowHandle);

            if (dr != null)
            {
                dr["MODEL"] = LueText.Text;
            }
        }

        /// <summary>
        /// 已添加项目改变事件，改变配送商
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvHitComm_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (this.gvHitComm.RowCount == 0)
                return;

            DataRow dr = this.gvHitComm.GetDataRow(this.gvHitComm.FocusedRowHandle);

            if (dr != null)
            {
                string strProjectID = dr["PROJECT_ID"].ToString();              //项目ID
                string strProjectProdID = dr["PROJECT_PROD_ID"].ToString();     //项目产品ID
                //初始化配送商
                InitData_BuyerSender(base.CurrentUserOrgId, strProjectID, strProjectProdID);

                this.txtProductMnemonic.Text = dr["PRODUCT_MNEMONIC"].ToString();//自定义编码
                this.txtSelfPackage.Text = dr["SELF_PACKAGE"].ToString();        //大包装

                if (string.IsNullOrEmpty(this.txtSelfPackage.Text))
                {
                    this.txtSelfPackage.Text = "1";
                }
                this.txtAlias.Text = dr["ALIAS"].ToString();                     //别名
                this.txtAliasPinyin.Text = dr["ALIAS_PINYIN"].ToString();        //别名拼音
            }
        }

        /// <summary>
        /// 配送商点击事件，如果配送商为一条记录时执行该事件，用于修改修改商。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LueSender_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.LueSender.EditValue == null)
                return;

            if (this.gvHitComm.RowCount == 0)
                return;

            if (SenderDt == null || SenderDt.DefaultView.ToTable().Rows.Count == 0)
                return;

            if (SenderDt.DefaultView.Count == 0)
                return;

            DataRow dr = this.gvHitComm.GetDataRow(this.gvHitComm.FocusedRowHandle);

            if (dr != null)
            {
                dr["SENDER_ID"] = this.LueSender.EditValue.ToString();
                dr["SENDER_NAME_ABBR"] = this.LueSender.Text.ToString();

                DataTable dt = SenderDt.DefaultView.ToTable();
                dt.DefaultView.RowFilter = string.Format("SENDER_ID ='{0}'", LueSender.EditValue.ToString());
                dr["SENDER_NAME"] = dt.DefaultView.Table.Rows[0]["SENDER_NAME"].ToString();
            }
        }

        //数据改变事件
        private void gVOrdProduct_RowCountChanged(object sender, EventArgs e)
        {
            if (base.cachedDataView != null)
            {
                LabCount.Text = "    共" + base.cachedDataView.Count + "条数据";
            }
        }

        /// <summary>
        /// 库房选择改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StoreRoomLue_EditValueChanged(object sender, EventArgs e)
        {
            if (this.gvHitComm.RowCount == 0)
                return;

            DevExpress.XtraEditors.LookUpEdit LueText = (DevExpress.XtraEditors.LookUpEdit)sender;

            DataRow dr = this.gvHitComm.GetDataRow(this.gvHitComm.FocusedRowHandle);

            if (dr != null)
            {
                dr["STORE_ROOM_NAME"] = LueText.Text.ToString();
            }
        }
        /// <summary>
        /// 显示已添加项目产品记录数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvHitComm_RowCountChanged(object sender, EventArgs e)
        {
            LblProductCount.Text = "   共" + this.gvHitComm.RowCount + "条数据"; 
        }

        #region 显示Title
        private void toolTipLocationControl_ToolTipLocationChanged(string HintValue)
        {
            if (string.IsNullOrEmpty(HintValue))
                return;
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
                if (this.gVOrdProduct.FocusedColumn.FieldName.ToUpper() == "SENDER_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["SENDER_NAME"].ToString());

                else if (this.gVOrdProduct.FocusedColumn.FieldName.ToUpper() == "SALER_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["SALER_NAME"].ToString());

                else if (this.gVOrdProduct.FocusedColumn.FieldName.ToUpper() == "MANU_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["MANU_NAME"].ToString());

                else
                    toolTipController1.HideHint();
            }
        }

        private void gvHitComm_Click(object sender, EventArgs e)
        {
            DataRow dr = this.gvHitComm.GetDataRow(this.gvHitComm.FocusedRowHandle);
            if (dr != null)
            {
                if (this.gvHitComm.FocusedColumn.FieldName.ToUpper() == "MANU_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["MANU_NAME"].ToString());

                else if (this.gvHitComm.FocusedColumn.FieldName.ToUpper() == "SENDER_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["SENDER_NAME"].ToString());

                else
                    toolTipController1.HideHint();
            }
        }
        #endregion

        #region 有关自定义编码设置
        private void txtProductMnemonic_TextChanged(object sender, EventArgs e)
        {
            if (dtHitComm != null)
            {
                if (dtHitComm.DefaultView.Count > 0)
                {
                    DataRow dr = dtHitComm.Rows[this.gvHitComm.FocusedRowHandle];
                    if (dr != null)
                        dr["PRODUCT_MNEMONIC"] = this.txtProductMnemonic.Text.Trim();
                }
            }
        }       
        
        private void txtSelfPackage_TextChanged(object sender, EventArgs e)
        {
            if (dtHitComm != null)
            {
                if (dtHitComm.DefaultView.Count > 0)
                {
                    DataRow dr = dtHitComm.Rows[this.gvHitComm.FocusedRowHandle];
                    if (dr != null)
                        dr["SELF_PACKAGE"] = this.txtSelfPackage.Text.Trim();
                }
            }
        }

        private void txtAlias_TextChanged(object sender, EventArgs e)
        {
            if (dtHitComm != null)
            {
                if (dtHitComm.DefaultView.Count > 0)
                {
                    DataRow dr = dtHitComm.Rows[this.gvHitComm.FocusedRowHandle];
                    if (dr != null)
                        dr["ALIAS"] = this.txtAlias.Text.Trim();
                }
            }
        }

        private void txtAliasPinyin_TextChanged(object sender, EventArgs e)
        {
            if (dtHitComm != null)
            {
                if (dtHitComm.DefaultView.Count > 0)
                {
                    DataRow dr = dtHitComm.Rows[this.gvHitComm.FocusedRowHandle];
                    if (dr != null)
                        dr["ALIAS_PINYIN"] = this.txtAliasPinyin.Text.Trim();
                }
            }
        }
        #endregion

        #region 产品过有效期后，记录显红色
        /// <summary>
        /// 产品过有效期后，记录显红色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gVOrdProduct_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            DataRow dr = (DataRow)gVOrdProduct.GetDataRow(e.RowHandle);
            //产品注册有效期
            string RegDate = dr["REG_VALID_DATE"].ToString();

            if (!string.IsNullOrEmpty(RegDate))
            {
                DateTime RegDt = Convert.ToDateTime(RegDate);

                if (RegDt <= DateTime.Now)
                {
                    e.Appearance.ForeColor = Color.Red;
                }
            }
        }
        #endregion

        #region 判断自定义编码是否添加

        private void txtProductMnemonic_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtProductMnemonic.Text))
                return;

            if (IsAddProductMnemonic(this.txtProductMnemonic.Text))
            {
                XtraMessageBox.Show("自定义编码已存在，请重新输入！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtProductMnemonic.Text = "";
                this.txtProductMnemonic.Focus();
                return;
            }
        }

        /// <summary>
        /// 判断该自定义编码是否已添加
        /// </summary>
        /// <returns></returns>
        private bool IsAddProductMnemonic(string strProductMnemonic)
        {
            bool flag = false;
            if (dtHitComm.DefaultView.Count == 0)
                return false;

            if (DefineCodeBLL.GetInstance().DefineCodeIsAddProductMnemonic(strProductMnemonic,""))
            {
                flag = true;
            }
            else
            {
                DataTable dt = dtHitComm.Copy();
                dt.DefaultView.RowFilter = string.Format("PRODUCT_MNEMONIC='{0}'",strProductMnemonic);

                if (dt.DefaultView.Count >= 2)
                    flag = true;
            }

            return flag;
        }
        #endregion

        #region 回车事件

        private void gVOrdProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnAddHitComm_Click(null, null);
            }
        }

        private void txtSelfPackage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtAlias.Focus();
            }
        }

        private void txtAlias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtAliasPinyin.Focus();
            }
        }

        private void txtAliasPinyin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnPost.Focus();
            }
        }
        #endregion

        #region 限止价格只充许输入数字字符、退格及点号键
        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar!='\b' && !Char.IsDigit(e.KeyChar) && e.KeyChar!='.') 
　　        {
                this.txtPrice.Text = Emedchina.Commons.StringUtils.ToDBC(this.txtPrice.Text);
　　            e.Handled = true; 
　　        }
        }
        #endregion

        private void LueProjectType_EditValueChanged(object sender, EventArgs e)
        {
            this.LueProject.Focus();
        }

        private void LueProductClass_EditValueChanged(object sender, EventArgs e)
        {
            this.txtBid_Id.Focus();
        }

        private void LueProjectType_KeyDown(object sender, KeyEventArgs e)
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
                this.txtBid_Id.Focus();
            }
        }

        private void txtBid_Id_KeyDown(object sender, KeyEventArgs e)
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
                this.LueProject.Focus();
            }
        }

        private void LueProject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtSpecModel.Focus();
            }
        }

        private void txtSpecModel_KeyDown(object sender, KeyEventArgs e)
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
                this.txtCommerceName.Focus();
            }
        }

        private void txtCommerceName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtPackage.Focus();
            }
        }

        private void txtProductMnemonic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtSelfPackage.Focus();
            }
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            this.txtPrice.Text = Emedchina.Commons.StringUtils.ToDBC(this.txtPrice.Text);
        }

  }
}