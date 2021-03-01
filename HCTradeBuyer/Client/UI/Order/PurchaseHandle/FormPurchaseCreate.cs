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
        //��װ�����ɹ�Ŀ¼��ѯ����
        //private OftenpurChaseDirInput oftenpurChaseDirInput = new OftenpurChaseDirInput();
        //��ʱ
        private UserInfoModel usInfo = new UserInfoModel();
        //�ɹ�����������ģ��
        private PurchaseSaveModel purchaseSaveModel = new PurchaseSaveModel();

        //ʵ�����ɹ�����ϸʵ���

        PurchaseItemModel PurchaseItem = new PurchaseItemModel();
        //�ɹ�����������ģ��
        private PurchaseSaveModel output = new PurchaseSaveModel();
        //�ɹ�����ϸ����
        private DataTable dtPurchaseItem = null;// new DataTable();
        //��ͬ��Դ�б�����
        private DataTable dtProjectType = new DataTable();
        //��Ŀ��Ʒ���ݼ��������ݼ�
        private DataTable OrdProductDt = null;
        //������Ŀ¼
        private DataTable SenderDt = null;
        //��Ŀ��Ʒ���ݼ��������ݼ� ��ʱʹ��
        //��Ʒ�������ݼ�
        private DataTable dtProductClass = null;

        private DataTable OrdProductTempDt = null;

        //�ⷿĿ¼
        private DataTable dtStone = null;

        //�ɹ���datarow
        DataRow purchaseDataRow = null;
        private bool saveFlag = false;
        private bool checkFlag = false;
        private bool modifiedflag = false;//�����ж����ʱ�ɹ����Ƿ�仯
        private bool editFlag = false;//�ж��Ƿ��в��������в���δ�����˳�����ʾ��
        public static FormPurchaseCreate GetInstance(FormPurchaseBuild inForm, DataRow inDataRow)
        {

            return new FormPurchaseCreate("�༭�ɹ���", inDataRow);

        }

        #region �������� FormPurchaseCreate
        /// <summary>
        /// ��������
        /// </summary>
        public FormPurchaseCreate(string titleName, DataRow inDataRow)
        {
            InitializeComponent();
            this.Text = titleName;
            if (titleName == "��˲ɹ���")
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

            //�ݴ��ж��Ƿ���ڲɹ���
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
                lcTotal.Text = float.Parse(inDataRow["TOTAL_SUM"].ToString()).ToString("###,###0.00") + "Ԫ";
                lcstate.Text = inDataRow["purchase_state"].ToString();
                lcquick.Text = inDataRow["purchase_QUICKSEND_LEVEL"].ToString();
                //tbRemark.Text = inDataRow["purchase_remark"].ToString();
                //    //�Ӳɹ�����ϸ������������֪�ɹ�����ϸ����
                IniTempHitCommData();
                getPurchaseItemFromCache();

                lbeEditDate.Visible = true;
                lbeEditTime.Visible = true;
 
            }
            //�������б�
            InitData();
            //����Ŀ�ɹ�Ŀ¼
            // OrdProductBind();

        }
        //����ɹ���
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
            
            //��ʼ����Ӳɹ���ϸ�б�
            IniTempHitCommData();
            //�ӵ���his�ɹ�����ϸ
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
            labelRecordcount.Text = this.gridView3.RowCount + "����¼"; 
          
            //�������б�
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



        #region ������֪�ɹ�����ϸ���� getPurchaseItemFromCache
        /// <summary>
        /// �ӻ�����������֪�ɹ�����ϸ����
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
                dr["PRODUCT_NAME"] = r["PRODUCT_NAME"];//��Ʒ��
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
            labelRecordcount.Text = this.gridView3.RowCount + "����¼";
        }
        #endregion


        private void getDataFromClient()
        {
            Emedchina.Commons.UserInfo ui = new Emedchina.Commons.UserInfo();
            ui.AreaId = base.CurrentUserSingleRegionId;
            ui.OrgId = base.CurrentUserRegOrgId;

        }


        #region �ɹ���� setRequestTotal
        /// <summary>
        /// �ɹ����
        /// </summary>
        /// <returns>�ɹ����</returns>
        private void setRequestTotal()
        {
            this.lcTotal.Text = getRequestTotal().ToString("###,###0.00")+"Ԫ";

        }
        #endregion


        #region ��ȡ�ۼƼƻ��ɹ����� getRequestTotal
        /// <summary>
        /// ��ȡ�ۼƼƻ��ɹ�����
        /// </summary>
        /// <returns>�ۼƼƻ��ɹ�����</returns>
        private float getRequestTotal()
        {
            float requestTotal = 0.00F;
            //�ۼƼƻ��ɹ�����
            foreach (DataRow r in dtPurchaseItem.Rows)
            {
                requestTotal = requestTotal + float.Parse(r["AMOUNT"].ToString() ==
                    "" ? "0" : r["AMOUNT"].ToString()) * float.Parse(r["TRADE_PRICE"].ToString() ==
                    "" ? "0" : r["TRADE_PRICE"].ToString());
            }
            return requestTotal;
        }
        #endregion

        #region ��ʼ�����������
        /// <summary>
        /// ��ʼ�����������
        /// </summary>
        private void InitGrid_Cmb()
        {
            //��ʼ���ⷿ������
            InitData_StoneInfo();
            InitData_SpecInfo();
            InitData_ModelInfo();

        }

        /// <summary>
        /// ��ʼ���ⷿ������
        /// </summary>
        private void InitData_StoneInfo()
        {
            dtStone = CommUtilBLL.GetInstance().GetBuyerStoreInfo(base.CurrentUserOrgId);
            this.StoreRoomLue.DataSource = dtStone.DefaultView;
        }
        /// <summary>
        /// ��ʼ�����������
        /// </summary>
        private void InitData_SpecInfo()
        {
            DataTable dtSpec = CommUtilBLL.GetInstance().GetSpecInfo();
            this.SpecLue.DataSource = dtSpec.DefaultView;
        }

        /// <summary>
        /// ��ʼ���ͺ�������
        /// </summary>
        private void InitData_ModelInfo()
        {
            DataTable dtModel = CommUtilBLL.GetInstance().GetModelInfo();
            this.ModelLue.DataSource = dtModel.DefaultView;
        }

        #endregion


        #region ��ʼ����Ӳɹ���ϸ�б�
        /// <summary>
        ///  ��ʼ����Ӳɹ���ϸ�б�
        /// </summary>
        private void IniTempHitCommData()
        {
            dtPurchaseItem = new DataTable();
            dtPurchaseItem.Columns.Add("ID");                //�ɹ�����ϸid
            dtPurchaseItem.Columns.Add("PURCHASE_ID");       //�ɹ���id
            dtPurchaseItem.Columns.Add("DATA_PRODUCT_ID");   //���Ĳ�ƷID
            dtPurchaseItem.Columns.Add("CONT_PRODUCT_ID");   //��ͬ��ƷID
            dtPurchaseItem.Columns.Add("PROJECT_ID");        //��Ŀid
            dtPurchaseItem.Columns.Add("PROJECT_PROD_ID");   //��Ŀ��ƷID
            dtPurchaseItem.Columns.Add("PRODUCT_NAME");      //��Ʒ��
            dtPurchaseItem.Columns.Add("BRAND");             //Ʒ��
            dtPurchaseItem.Columns.Add("SPEC_ID");           //���ID
            dtPurchaseItem.Columns.Add("SPEC");              //���
            dtPurchaseItem.Columns.Add("MODEL_ID");          //�ͺ�ID
            dtPurchaseItem.Columns.Add("MODEL");             //�ͺ�
            dtPurchaseItem.Columns.Add("SENDER_ID");         //������ҵID
            dtPurchaseItem.Columns.Add("SENDER_NAME");       //������
            dtPurchaseItem.Columns.Add("SENDER_NAME_ABBR");  //�����̼��
            dtPurchaseItem.Columns.Add("BASE_MEASURE");      //����������λ
            dtPurchaseItem.Columns.Add("AMOUNT");            //��������
            dtPurchaseItem.Columns.Add("MANUFACTURE_ID");    //������ҵID
            dtPurchaseItem.Columns.Add("MANUFACTURE_NAME");  //������ҵ
            dtPurchaseItem.Columns.Add("MANUFACTURE_NAME_ABBR");  //������ҵ���
            dtPurchaseItem.Columns.Add("SALER_ID");          //������ҵID
            dtPurchaseItem.Columns.Add("SALER_NAME");        //������ҵ
            dtPurchaseItem.Columns.Add("SALER_NAME_ABBR");   //������ҵ���
            dtPurchaseItem.Columns.Add("COMMON_NAME");       //ͨ����
            dtPurchaseItem.Columns.Add("ABBR_PY");          //ƴ��
            dtPurchaseItem.Columns.Add("ABBR_WB");          //���
            //dtpurchaseItem.Columns.Add("BRAND");           //Ʒ��
            dtPurchaseItem.Columns.Add("TRADE_PRICE");       //����
            dtPurchaseItem.Columns.Add("PRODUCT_CODE");      //����
            dtPurchaseItem.Columns.Add("GOODS_NO");          //����
            dtPurchaseItem.Columns.Add("BARCODE");           //����
            dtPurchaseItem.Columns.Add("BASE_MEASURE_SPEC"); //������λ���
            dtPurchaseItem.Columns.Add("BASE_MEASURE_MATER");//������λ��װ����
            dtPurchaseItem.Columns.Add("RETAIL_PRICE");      //����޼�          
            //dtPurchaseItem.Columns.Add("SENDER_NAME_ABBR");//������ҵID
            dtPurchaseItem.Columns.Add("STORE_ROOM_ID");     //�ⷿID
            dtPurchaseItem.Columns.Add("STORE_ROOM_NAME");   //�ⷿID
            dtPurchaseItem.Columns.Add("STORE_ROOM_ADDRESS");//�ⷿID
            dtPurchaseItem.Columns.Add("SUM");               //�ɹ����
            dtPurchaseItem.Columns.Add("purchase_QUICKSEND");//�Ƿ���
            dtPurchaseItem.Columns.Add("RowState");          //�������ͣ�0Ϊ���ӣ�1Ϊ�޸�,2Ϊɾ����
            dtPurchaseItem.Columns.Add("PACKAGE");            //�д��װ
            dtPurchaseItem.Columns.Add("PACKAGEAMOUNT");           //�д��װ
            dtPurchaseItem.Columns["TRADE_PRICE"].DataType = Type.GetType("System.Double");
            dtPurchaseItem.Columns.Add("DESCRIPTIONS");            //����
            dtPurchaseItem.AcceptChanges();

            this.bindingSource2.DataSource = dtPurchaseItem.DefaultView;

        }
        #endregion


        #region ��ʼ���б�
        /// <summary>
        /// ��ʼ��
        /// </summary>
        private void InitData()
        {
            InitData_ProjectType();
            InitData_Project();
            InitData_ProjectClass();
            InitGrid_Cmb();//��ʼ������ͺţ��ⷿ
            //��ʼ��������
            //InitData_BuyerSender(base.CurrentUserOrgId, "", "");

        }

        /// <summary>
        /// ��ʼ����Ŀ����
        /// </summary>
        private void InitData_ProjectType()
        {
            //����Ŀ����
            DataTable dt = new DataTable();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns[0].ColumnName = "value";
            dt.Columns[1].ColumnName = "Name";
            string[] data0 = { "0", "ȫ��" };
            dt.Rows.Add(data0);
            string[] data1 = { "1", "��Ͷ��" };
            dt.Rows.Add(data1);
            string[] data2 = { "2", "�����ɹ�" };
            dt.Rows.Add(data2);
            string[] data3 = { "3", "���۲ɹ�" };
            dt.Rows.Add(data3);
            string[] data4 = { "4", "����ɹ�" };
            dt.Rows.Add(data4);

            LueProjectType.Properties.DataSource = dt;
            LueProjectType.Properties.NullText = "";

            //����Ĭ��ֵ
            LueProjectType.EditValue = "0";
        }

        private void InitData_Project()
        {
            //����Ŀ����
            DataTable dtPro = CommUtilBLL.GetInstance().GetProjectInfoByProjectType("");

            LueProject.Properties.DataSource = dtPro;
            LueProject.Properties.Columns.Clear();
            LueProject.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PROJECT_NAME", 200, "��Ŀ����"));
            LueProject.Properties.DisplayMember = "PROJECT_NAME";
            LueProject.Properties.ValueMember = "ID";
            LueProject.Properties.NullText = "��ѡ��...";

            //Ĭ����ʾ��һ����Ŀ
            string DefaultProjectID = dtPro.Rows[0]["ID"].ToString().Trim();
            LueProject.EditValue = Convert.ToInt32(DefaultProjectID);
        }
        private void InitData_StoreRoom()
        {
            //�󶨿ⷿ���ƣ����������Ŀⷿѡ��
            DataTable dtStone = CommUtilBLL.GetInstance().GetBuyerStoreInfo(base.CurrentUserOrgId);

           LueStoreroom.Properties.DataSource = dtStone;
           LueStoreroom.Properties.Columns.Clear();
           LueStoreroom.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("STORE_NAME", 200, "��Ŀ����"));
           LueStoreroom.Properties.DisplayMember = "STORE_NAME";
           LueStoreroom.Properties.ValueMember = "STORE_ID";
           LueStoreroom.Properties.NullText = "��ѡ��...";

        }
        private void InitData_ProjectClass()
        {
            //��Ʒ�ַ�����Ϣ
            dtProductClass = CommUtilBLL.GetInstance().GetProductClassInfoByProjectID("");

            this.LueProductClass.Properties.DataSource = dtProductClass;
            LueProductClass.Properties.NullText = "ȫ��";
            LueProductClass.EditValue = "0";//Ĭ��Ϊ��ȫ����
        }
        #endregion

        /// <summary>
        /// ��Ŀ��Ʒ���ݰ�
        /// </summary>
        private void OrdProductBind()
        {

            //��ǰ��ѡ��ĿID
            string strProjectID = this.LueProject.EditValue.ToString();
            string strProductItem = this.cmbProductItem.Text;
            //ʹ�û��� ��ȡ�ɹ�Ŀ¼��ѯ���ݼ�
            string strDataName = Constant.ORDPRODUCT + strProjectID + strProductItem;
            if (ClientCache.CachedDS.Tables.IndexOf(strDataName) == -1)
            {
                DataTable tempDt = new DataTable(strDataName);

                //��ȡ��Ŀ��Ʒ���ݼ�
                if (this.cmbProductItem.Text == "�����ɹ�Ŀ¼")
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

            //���뻺��
            InitFromCacheByData(strDataName);

            //�ӻ���ȡ���ݼ��󶨵�GRID
            bindingDsOrdProduct();
            Filter_Product();
        }

        #region �󶨵�GRID��
        /// <summary>
        /// �󶨵�GRID��
        /// </summary>
        private void bindingDsOrdProduct()
        {
            this.bindingSource1.DataSource = base.cachedDataView;

            OrdProductDt = base.cachedDataView.Table;

            OrdProductTempDt = OrdProductDt.Copy();

            this.gVOrdProduct.ExpandAllGroups();

        }
        #endregion

        #region �ɹ�������

        /// <summary>
        /// ������޸�ģʽ�£��òɹ�����ϸû������ʱ����ʾ�Ƿ�ɾ���ɹ�������
        /// </summary>
        private bool DelPurchase()
        {
            this.saveFlag = false;
            if (!String.IsNullOrEmpty(purchaseSaveModel.PurchaseId))
            {
                //û����ϸ��ʾɾ��
                if (this.gridView3.RowCount == 0)
                {
                    if (XtraMessageBox.Show("�ɹ�����ϸû�����ݣ��Ƿ�ɾ���òɹ�����", Constant.MsgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //��SavePurchase�������ã�ֱ������ɾ��û����ϸ�Ĳɹ��������ж� DelPurchase ״̬
                        bool flag = new PurchaseOfflineBLL().PurchaseDeleteLocal(purchaseSaveModel.PurchaseId, base.CurrentUserId);

                        if (flag)
                        {
                            XtraMessageBox.Show("�ɹ���ɾ���ɹ���", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("�ɹ���ɾ��ʧ�ܣ�", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        this.Close();
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// �ɹ�������
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
                    //XtraMessageBox.Show("�ɹ�������ɹ���", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    purchaseSaveModel.PurchaseId = output.PurchaseId;
                    this.purchaseSaveModel.List.Clear();//
                    this.dtPurchaseItem.Clear();//���dtPurchaseItem
                    getPurchaseItemFromCache();//������ˢ�²ɹ�����ϸ����
                    this.saveFlag = false;

                //}
                //catch (Exception ex)
                //{
                //    XtraMessageBox.Show("�ɹ�������ά��ʧ�ܣ���������������ˢ�»��棡", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
            }

        }

        /// <summary>���ɹ�������
        /// �ɹ�������
        /// </summary>
        /// <returns></returns>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //�ж��Ƿ�ɾ���ղɹ���
            if (DelPurchase())
                return;

            //У������
            string strError = string.Empty;
            if (!checkInput(out strError))
            {
                checkFlag = false;
                XtraMessageBox.Show(strError, Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            checkFlag = true;

            //��ȡ���ݱ���ģ��
            getPurchaseSaveModelList();

            //���òɹ��������¼�
            try
            {
                PurchaseSave();
                XtraMessageBox.Show("�ɹ�������ɹ���", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                editFlag = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("�ɹ�������ʧ�ܣ�", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                checkFlag = false;
                return;
            }
        }
        #endregion
        #region ����dgvPurchaseItem��ȡPurchaseSaveModel getPurchaseSaveModelList
        /// <summary>
        /// ����dgvPurchaseItem��ȡPurchaseSaveModel
        /// </summary>
        private void getPurchaseSaveModelList()
        {
            //�ɹ�����Ϣ
            purchaseSaveModel.PurchaseId = purchaseSaveModel.PurchaseId;
            purchaseSaveModel.PurchaseCode = "";
            //purchaseSaveModel.PurchaseRemark = this.tbRemark.Text;

            //��ǰ��¼�û���Ϣ
            purchaseSaveModel.BuyerOrgid = base.CurrentUserOrgId;
            purchaseSaveModel.CreateUserid = base.CurrentUserId;
            purchaseSaveModel.CreateUsername = base.CurrentUserName;
            purchaseSaveModel.HighID = base.CurrentUserHighID;

            if (this.Text == "��˲ɹ���" || lcstate.Text == "����")
            {
                purchaseSaveModel.State = "2";//����
            }
            else
            {
                purchaseSaveModel.State = "1";//׼��
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
        /// ����У��
        /// </summary>
        /// <returns></returns>
        private bool checkInput(out string Error)
        {
            Error = string.Empty;
            string requestQty;//�ɹ�����
            string specid;//���
            string modelid;//�ͺ�
            string storeid;//�ⷿ
            string senderid;//����
            int request;

            if (this.gridView3.RowCount == 0)
            {
                Error = "�ɹ�����ϸû�����ݣ�";
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
                    Error = "�����붩��������";
                    return false;
                }
                if (request < 1)
                {
                    Error = "�ɹ����������Ǵ���0��������";
                    return false;
                }
                if (string.IsNullOrEmpty(specid))
                {
                    Error = "��ѡ��һ�ֹ��";
                    return false;
                }
                if (string.IsNullOrEmpty(modelid))
                {
                    Error = "��ѡ��һ���ͺţ�";
                    return false;
                }
                if (string.IsNullOrEmpty(storeid))
                {
                    Error = "��ѡ��ⷿ��";
                    return false;
                }
                if (string.IsNullOrEmpty(senderid))
                {
                    Error = "��ѡ��������ҵ��";
                    return false;
                }
            }
            return true;
        }

        #region ��װ�ɹ�����ϸ����ģ������ buildPurchaseItemSaveModel
        /// <summary>
        /// ��װ�ɹ�����ϸ����ģ������
        /// </summary>
        /// <param name="r">��</param>
        /// <returns>PurchaseItemSaveModel</returns>
        private PurchaseItemSaveModel buildPurchaseItemSaveModel(DataRow r, PurchaseItemSaveModel purchaseItem)
        {

            //�ɹ�����ϸ��Ϣ
            purchaseItem.RowState = r["RowState"].ToString();
            purchaseItem.Projectprodid = r["PROJECT_PROD_ID"].ToString();
            purchaseItem.SenderId = r["SENDER_ID"].ToString();
            purchaseItem.SenderName = r["SENDER_NAME"].ToString();
            purchaseItem.SenderAbbr = r["SENDER_NAME_ABBR"].ToString();
            purchaseItem.PurchaseId = purchaseSaveModel.PurchaseId;
            purchaseItem.PurchaseItemId = r["Id"].ToString();
            purchaseItem.Storeroomid = r["STORE_ROOM_ID"].ToString();//�ⷿid
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
            purchaseItem.Isquicsend = r["purchase_QUICKSEND"].ToString();//�Ƿ���
            purchaseItem.UnitPrice = r["TRADE_PRICE"].ToString();//���׼۸�
            purchaseItem.Descriptions = r["DESCRIPTIONS"].ToString();//����

            purchaseItem.ModifyUserid = base.CurrentUserId;

            return purchaseItem;
        }
        #endregion


        //���ͨ��
        private void btngetCheck_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled)//�����ǰ�ɹ��������仯����ִ�б���ɹ�������
            {
                XtraMessageBox.Show("�ɹ������ݷ����仯�����ȱ���ɹ�����", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnSave.Focus();
                return;
            }

            //���߷��͹���
            string mes;
            mes = new PurchaseOfflineBLL().getCheckPurchaseOffline(purchaseSaveModel.PurchaseId, usInfo);
            if (ClientConfiguration.IfSendImmediately)
            {
                if (XtraMessageBox.Show("�Ƿ��������͵���������", Constant.MsgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    List<string> InvalidList = null;
                    int rows;
                    bool sendOk = new ClientUploadBLL().UploadData(true, out InvalidList, out rows);
                    if (!sendOk)
                    {
                        mes = "�����ѱ��浽���ؿ⣬�����͵�������ʧ�ܣ���ͬ�����ݣ�";
                    }
                }
            }

            if (string.IsNullOrEmpty(mes))
            {
                XtraMessageBox.Show("���ͨ���ɹ���", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnAdd.Enabled = false;
                this.btncheckno.Enabled = false;
                this.btnDel.Enabled = false;
                this.btnSave.Enabled = false;
                this.BtnPostSend.Enabled = false;
                this.btngetCheck.Enabled = false;
                //this.gridView3.Columns["AMOUNT"]. = false;
                lcstate.Text = "���ͨ��";
            }
            else
            {
                XtraMessageBox.Show(mes, Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //���ʧ�ܣ���ˢ���û�����
                return;
            }

        }


        private void btncheckno_Click(object sender, EventArgs e)
        {
            bool flag;
            flag = new PurchaseOfflineBLL().Checkno(purchaseSaveModel.PurchaseId);
            if (flag)
            {

                XtraMessageBox.Show("��˾ܾ��ɹ���", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnAdd.Enabled = false;
                this.btncheckno.Enabled = false;
                this.btnDel.Enabled = false;
                this.btnSave.Enabled = false;
                this.BtnPostSend.Enabled = false;
                this.btngetCheck.Enabled = false;

            }
            else
            {
                XtraMessageBox.Show("��˾ܾ�ʧ�ܣ�û�з������ݣ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }


        #region ��Ӳ�Ʒ���ɹ���ϸĿ¼
        /// <summary>
        ///  ��Ӳ�Ʒ���ɹ���ϸĿ¼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.gVOrdProduct.RowCount == 0)
            {
                XtraMessageBox.Show("û��ѡ�����ݣ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            editFlag = true;

            int currentRow = this.gVOrdProduct.FocusedRowHandle;

            string strPackName = string.Empty;

            //�ж��Ƿ�ѡ��Ϊ������Ϣ
            if (currentRow < 0)
            {
                currentRow = this.gVOrdProduct.GetDataRowHandleByGroupRowHandle(currentRow);

                foreach (DevExpress.XtraGrid.Columns.GridColumn groupColumn in this.gVOrdProduct.GroupedColumns)
                {
                    object val = this.gVOrdProduct.GetRowCellValue(currentRow, groupColumn);
                    strPackName = val.ToString();
                }

                //�����ײ�Ϊ��ʱ����û���������׵Ĳ�Ʒ��Ϣ�������������������
                if (!strPackName.Trim().Equals("�������ײ�Ʒ��"))
                {
                    //���������붩������
                    FormPackage fromPackage = new FormPackage();
                    fromPackage.ShowDialog();

                    string PackageAmount = fromPackage.strPackageAmount;
                    //ȡ���� �������
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
                //��ȡ��ǰ��Ŀ��Ʒ����
                DataRow dr = (DataRow)this.gVOrdProduct.GetDataRow(this.gVOrdProduct.FocusedRowHandle);

                if (dr == null)
                    return;

                PurchaseOrderItemModel ordProductModel = GetOrdProductModelByTreeList(dr);
                AddPurchaseItemView(ordProductModel,false,"");
            }

            setRequestTotal();//���½��

        }
        /// <summary>
        /// ��ӵ��ɹ���ϸĿ¼
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
            dr["PRODUCT_NAME"] = ordProductModel.ProductName;//��Ʒ��
            dr["BASE_MEASURE"] = ordProductModel.Sendmeasure;
            dr["MANUFACTURE_NAME"] = ordProductModel.ManufactureName;
            dr["MANUFACTURE_NAME_ABBR"] = ordProductModel.ManufactureNameEasy;
            dr["SALER_NAME"] = ordProductModel.SalerName;
            dr["COMMON_NAME"] = ordProductModel.CommonName;
            dr["BRAND"] = ordProductModel.Brand;
            dr["TRADE_PRICE"] = ordProductModel.UnitPrice;
            if (this.cmbProductItem.Text == "�����ɹ�Ŀ¼")
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
            dr["RowState"] = '0';//�����еĲ���������Ϊ����

            if (Is_Package)
            {
                if (!string.IsNullOrEmpty(ordProductModel.Amount.ToString()))
                    dr["AMOUNT"] = Convert.ToInt32(PackageAmount) * ordProductModel.Amount;
                else
                    dr["AMOUNT"] = PackageAmount;
                //setRequestTotal();//���½��
            }

            //Ĭ����ʾ��һ���ⷿ
            if (dtStone.Rows.Count > 0)
                dr["STORE_ROOM_ID"] = dtStone.Rows[0]["STORE_ID"].ToString().Trim();

            dtPurchaseItem.Rows.Add(dr);
        }
        #endregion

        #region ��ȡ��ǰѡ����Ŀ��Ʒ��¼����
        /// <summary>
        /// ��ȡ��ǰѡ����Ŀ��Ʒ��¼����
        /// </summary>
        /// <returns></returns>
        private PurchaseOrderItemModel GetOrdProductModelByTreeList(DataRow dr)
        {
            PurchaseOrderItemModel PurchaseItem = new PurchaseOrderItemModel();

            if (dr == null)
                return null;

            PurchaseItem.DataproductId = dr["DATA_PRODUCT_ID"].ToString().Trim();
            PurchaseItem.ProjectprodId = dr["PROJECT_PROD_ID"].ToString().Trim();
            if (this.cmbProductItem.Text == "�����ɹ�Ŀ¼")
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
            //����
            if (!dr["AMOUNT"].ToString().Equals("-"))
                PurchaseItem.Amount = Convert.ToInt32(dr["AMOUNT"].ToString().Trim());
            return PurchaseItem;

        }
        #endregion


        #region �Ƴ��������
        /// <summary>
        /// �Ƴ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dtPurchaseItem != null)
            {
                if (dtPurchaseItem.Rows.Count == 0)
                {
                    XtraMessageBox.Show("û��ѡ�����ݣ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                editFlag = true;

                DataRow dr = this.gridView3.GetDataRow(this.gridView3.FocusedRowHandle);
                //�����Ӽ�¼ɾ��������PurchaseSaveModel
                if (!String.IsNullOrEmpty(dr["ID"].ToString()))
                {
                    //����ά��ģ��
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


        #region//������ID����ĿID����Ŀ��ƷID��������
        /// <summary>
        /// ������ID����ĿID����Ŀ��ƷID��������
        /// </summary>
        /// <param name="buyerId"></param>
        /// <param name="projectId"></param>
        /// <param name="projectProdId"></param>
        private void InitData_BuyerSender(string buyerId, string projectId, string projectProdId)
        {
            SenderDt = CommUtilBLL.GetInstance().GetSenderInfo(buyerId, projectId, projectProdId);

            LueSender.Properties.DataSource = SenderDt;
            LueSender.Properties.Columns.Clear();
            //LueSender.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SENDER_NAME", 100, "����������"));
            LueSender.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SENDER_ABBR", 100, "����������"));
            LueSender.Properties.DisplayMember = "SENDER_ABBR";
            LueSender.Properties.ValueMember = "SENDER_ID";
            LueSender.Properties.NullText = "��ѡ��..";
        }

        #endregion


        /// <summary>
        /// ˢ�����ݼ�
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
        /// ��ȡGrid��ǰѡ�� ĳ���ֶ�ֵ
        /// </summary>
        /// <param name="view">gridView����</param>
        /// <param name="ColName">�ֶ���</param>
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

        #region ��ѯ���˷���
        /// <summary>
        /// ��ѯ���˷���
        /// </summary>
        private void Filter_Product()
        {

            //��Ŀ����
            string ProjectType = string.Empty;
            if (this.LueProjectType.EditValue != null && !this.LueProjectType.EditValue.ToString().Equals("0"))
            {
                ProjectType = this.LueProjectType.EditValue.ToString().Trim();
            }
            //��ĿID
            string ProjectId = string.Empty;
            if (this.LueProject.EditValue != null)
            {
                ProjectId = this.LueProject.EditValue.ToString().Trim();
            }
            //��Ʒ����ID
            string ClassId = string.Empty;
            if (this.LueProductClass.EditValue != null && !this.LueProductClass.EditValue.ToString().Equals("0"))
            {
                ClassId = this.LueProductClass.EditValue.ToString().Trim();
            }
            //��Ʒ����
            string ProductName = this.txtCommerceName.Text.Trim();
            string Spec = this.txtSpec.Text.Trim();
            string Model = this.txtModel.Text.Trim();
            string ManuName = this.txtManuName.Text.Trim();
            string SalerName = this.txtSalerName.Text.Trim();
            string SenderName = this.txtSenderName.Text.Trim();
            string Price = this.txtPrice.Text.Trim();
            //�б����
            string strbid_id = this.txtBid_Id.Text.Trim();

            StringBuilder StrFilter = new StringBuilder();
            StrFilter.Append("1=1");
            if (this.cmdCreateDate.Visible == true)
            {
                //��ʼʱ��
                string createDate = this.cmdCreateDate.Text.ToString();
                //����ʱ��
                string endDate = this.cmdEndDate.Text.ToString();
                //if (DateTime.Compare(this.cmdEndDate.DateTime, this.cmdCreateDate.DateTime) < 0)
                //{
                //    XtraMessageBox.Show("�������ڽ������ڱ�����ڿ�ʼ���ڣ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            //��Ŀ����
            if (!string.IsNullOrEmpty(ProjectType))
            {
                StrFilter.AppendFormat(" AND PROJECT_TYPE = '{0}'", ProjectType);
            }

            //��ĿID
            if (!string.IsNullOrEmpty(ProjectId))
            {
                StrFilter.AppendFormat(" AND PROJECT_ID = '{0}'", ProjectId);
            }

            //��Ʒ����ID
            if (!string.IsNullOrEmpty(ClassId))
            {
                StrFilter.AppendFormat(" AND CLASS_ID = '{0}'", ClassId);
            }

            //��Ʒ����
            if (!string.IsNullOrEmpty(ProductName))
            {

                if (this.cmbProductItem.Text == "�����ɹ�Ŀ¼" && ClientConfiguration.IfSetProEasy)
                {
                    StrFilter.AppendFormat(" AND (PRODUCT_NAME LIKE '%{0}%' Or COMMON_NAME LIKE '%{0}%' Or ABBR_PY LIKE '%{0}%' Or ABBR_WB LIKE '%{0}%' Or ALIAS LIKE '%{0}%'  Or ALIAS_PINYIN LIKE '%{0}%' Or PRODUCT_MNEMONIC LIKE '%{0}%')", ProductName);
                }
                else
                {
                    StrFilter.AppendFormat(" AND (PRODUCT_NAME LIKE '%{0}%' Or COMMON_NAME LIKE '%{0}%' Or ABBR_PY LIKE '%{0}%' Or ABBR_WB LIKE '%{0}%')", ProductName);
                }
            }

            //���
            if (!string.IsNullOrEmpty(Spec))
            {
                StrFilter.AppendFormat(" AND (SPEC LIKE '%{0}%' )", Spec);
            }
            //�ͺ�
            if (!string.IsNullOrEmpty(Model))
            {
                StrFilter.AppendFormat(" AND ( MODEL LIKE '%{0}%')", Model);
            }

            //������ҵ
            if (!string.IsNullOrEmpty(ManuName))
            {
                StrFilter.AppendFormat(" AND (MANU_NAME LIKE '%{0}%' Or MANU_NAME_ABBR LIKE '%{0}%' Or MANU_NAME_SPELL_ABBR LIKE '%{0}%' Or MANU_NAME_WB LIKE '%{0}%')", ManuName);
            }

            //������ҵ
            if (!string.IsNullOrEmpty(SalerName))
            {
                StrFilter.AppendFormat(" AND (SALER_NAME LIKE '%{0}%' Or SALER_NAME_ABBR LIKE '%{0}%' Or SALER_NAME_SPELL_ABBR LIKE '%{0}%' Or SALER_NAME_WB LIKE '%{0}%')", SalerName);
            }

            //������ҵ
            if (!string.IsNullOrEmpty(SenderName) && this.cmbProductItem.Text.Equals("�����ɹ�Ŀ¼"))
            {
                StrFilter.AppendFormat(" AND (SENDER_NAME LIKE '%{0}%' Or SENDER_NAME_ABBR LIKE '%{0}%' Or SENDER_NAME_SPELL_ABBR LIKE '%{0}%' Or SENDER_NAME_WB LIKE '%{0}%')", SenderName);
            }

            //����
            if (!string.IsNullOrEmpty(Price))
            {
                Price = Emedchina.Commons.StringUtils.ToDBC(Price);
                StrFilter.AppendFormat(" AND ( PRICE = '{0}')", Price);
            }

            //�б����
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
        /// ��Ŀѡ���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LueProject_EditValueChanged(object sender, EventArgs e)
        {
            //����Ŀ��Ʒ
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
                    XtraMessageBox.Show("�Ƿ��ɹ�������", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dr["AMOUNT"] = "";
                    return;
                }
                string packageamount = dr["PACKAGEAMOUNT"].ToString();
                if (!int.TryParse(packageamount, out request) && this.gridView3.FocusedColumn.FieldName.ToUpper() == "PACKAGEAMOUNT")
                {
                    XtraMessageBox.Show("�Ƿ��ɹ�������", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dr["PACKAGEAMOUNT"] = "";
                    return;
                }
                if (dr["RowState"].ToString() != "0")
                {
                    dr["RowState"] = '1';//������в�Ϊ���������еĲ���������Ϊ�޸�
                }
                labelRecordcount.Text = this.gridView3.RowCount + "����¼";
                if (lcstate.Text == "���ͨ��")
                    return;
                btnSave.Enabled = true;

                if (this.Text == "��˲ɹ���")
                {
                    BtnPostSend.Enabled = false;
                }
                else
                {
                    BtnPostSend.Enabled = true;
                }

                editFlag = true;

                //ʹ�ô��װ
                if (ClientConfiguration.IfDefineBigPacking)
                {
                    //ת����
                    string strPackage = dr["PACKAGE"].ToString();
                    if (strPackage != null && !string.IsNullOrEmpty(strPackage))
                    {
                        if (this.gridView3.FocusedColumn.FieldName.ToUpper() == "PACKAGEAMOUNT")
                        {
                            dr["AMOUNT"] = Math.Ceiling(int.Parse(packageamount) * float.Parse(strPackage));
                        }
                        if (this.gridView3.FocusedColumn.FieldName.ToUpper() == "AMOUNT")
                        {
                            //���㸡�����С����
                            dr["PACKAGEAMOUNT"] = Math.Floor(float.Parse(dr["AMOUNT"].ToString()) / float.Parse(strPackage));
                        }
                    }
                }

                //���ı�����
                setRequestTotal();
            }

        }

        /// <summary>
        /// �������Ŀ�ı��¼����ı�������
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
                //��ʼ��������
                this.LueSender.EditValue = null;//�ı���Ŀ���������
                InitData_BuyerSender(base.CurrentUserOrgId, strProjectID, strProjectProdID);
                InitData_StoreRoom();
            }

        }
        //ѡ��ɹ�Ŀ¼����Ŀ��ƷĿ¼�������ɹ�Ŀ¼��
        private void cmbProductItem_TextChanged(object sender, EventArgs e)
        {
            if (this.cmbProductItem.Text == "�����ɹ�Ŀ¼")
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
                XtraMessageBox.Show("��ѡ����Դ��Ŀ��", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //����Ŀ��Ʒ
            OrdProductBind();

        }
        //ѡ���Ƿ�ʹ����ʷ�ɹ�
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

        ////˫����Ŀ��ƷĿ¼
        private void gVOrdProduct_DoubleClick_1(object sender, EventArgs e)
        {
            if (this.btnAdd.Enabled == true)
            {
                this.btnAdd_Click(sender, e);
            }

        }
        //�ɹ�Ŀ¼�س���ӵ��ɹ���ϸ
        private void gVOrdProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.btnAdd_Click(sender, e);
            }
            
        }


        private void gVOrdProduct_RowCountChanged(object sender, EventArgs e)
        {
            labelControl9.Text = "    �� " + base.cachedDataView.Count + "������";
        }

        private void gridView3_RowCountChanged(object sender, EventArgs e)
        {
            labelRecordcount.Text = "    �� " + this.gridView3.RowCount + " ������";
        }
        /// <summary>
        /// �����������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LueSender_EditValueChanged(object sender, EventArgs e)
        {
            if (lcstate.Text.Equals("���ͨ��"))
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

            if (this.Text != "��˲ɹ���")
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

        

        #region ��ʾTitle
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

        //����Ʒ�ַ���
        private void Filter_ProjectClass(string strProjectID)
        {
            dtProductClass.DefaultView.RowFilter = string.Format(" ID=0 Or PROJECT_ID='{0}'", strProjectID);
            LueProductClass.EditValue = 0;//Ĭ��Ϊ��ȫ����
        }
        //�����ⷿѡ��
        private void LueStoreroom_EditValueChanged(object sender, EventArgs e)
        {
            if (lcstate.Text.Equals("���ͨ��"))
                return;

            foreach (DataRow r in dtPurchaseItem.Rows)
            {
                r["STORE_ROOM_ID"] = this.LueStoreroom.EditValue.ToString();
                r["STORE_ROOM_NAME"] = this.LueStoreroom.Text.ToString();
            }

            if (this.Text != "��˲ɹ���")
                editFlag = true;

        }

        #region ��ֹ�۸�ֻ�������������ַ����˸񼰵�ż�
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
        /// ����ɹ���������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPostSend_Click(object sender, EventArgs e)
        {
            //�ж��Ƿ�ɾ���ղɹ���
            if (DelPurchase())
                return;

            //У������
            string strError = string.Empty;
            if (!checkInput(out strError))
            {
                checkFlag = false;
                XtraMessageBox.Show(strError, Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            checkFlag = true;
            editFlag = false;

            //��ȡ���ݱ���ģ��
            getPurchaseSaveModelList();
                        
            try
            {
                //���òɹ��������¼�
                PurchaseSave();
                //���÷��Ͳɹ����¼�
                bool flag = new PurchaseOfflineBLL().putCheckPurchaseOffline(output.PurchaseId);
                if (flag == true)
                {
                    lcPurchaseCode.Text = output.PurchaseCode;
                    lcstate.Text = "����";
                    XtraMessageBox.Show("�ɹ������沢����ɹ���", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("�ɹ������沢����ʧ�ܣ�", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("�ɹ������沢����ʧ�ܣ�", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        #region ��Ʒ������
        private void txtCommName_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        /// <summary>
        /// ��ѯ���˷���
        /// </summary>
        private void Filter()
        {
            StringBuilder StrFilter = new StringBuilder();

            string strProductName = this.txtCommName.Text.Trim();

            StrFilter.Append(" 1=1");

            //ͨ������
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

        #region �˳��¼�
        private void BtnExit_Click(object sender, EventArgs e)
        {
            if (editFlag)
            {
                if (XtraMessageBox.Show("�ɹ���û�б��棬�Ƿ񱣴棿", Constant.MsgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

