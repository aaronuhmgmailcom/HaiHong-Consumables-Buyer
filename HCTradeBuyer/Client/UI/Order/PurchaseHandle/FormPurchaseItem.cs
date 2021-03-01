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
        //��ʱ
        private UserInfoModel usInfo = new UserInfoModel();
        //�ɹ�����������ģ��
        private PurchaseSaveModel purchaseSaveModel = new PurchaseSaveModel();       
        //ʵ�����ɹ�����ϸʵ���       
        PurchaseItemModel PurchaseItem = new PurchaseItemModel();
        //�ɹ�����ϸ����
        private DataTable dtPurchaseItem =null;// new DataTable();
        //�ɹ���datarow
        DataRow purchaseDataRow = null;       
        public static FormPurchaseItem GetInstance(FormPurchaseBuild inForm, DataRow inDataRow)
        {
            return new FormPurchaseItem("�༭�ɹ���", inDataRow);
        }

        #region �������� FormPurchaseCreate
        /// <summary>
        /// ��������
        /// </summary>
        public FormPurchaseItem(string titleName, DataRow inDataRow)
        {
            InitializeComponent();
            this.Text = titleName;         
            this.purchaseDataRow = inDataRow;         
            //�ݴ��ж��Ƿ���ڲɹ���
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
                lcTotal.Text = float.Parse(inDataRow["TOTAL_SUM"].ToString()).ToString("###,###0.00") + "Ԫ";
                lcstate.Text = inDataRow["purchase_state"].ToString();
                lcquick.Text = inDataRow["purchase_QUICKSEND_LEVEL"].ToString();
                //tbRemark.Text = inDataRow["purchase_remark"].ToString();
                //    //�Ӳɹ�����ϸ������������֪�ɹ�����ϸ����
                IniTempHitCommData();
                getPurchaseItemFromCache();
                InitGrid_Cmb();//��ʼ������ͺţ��ⷿ
                
            }          

        }
        #endregion

        #region �ӻ�����������֪�ɹ�����ϸ���� getPurchaseItemFromCache
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
            DataTable dtStone = CommUtilBLL.GetInstance().GetBuyerStoreInfo(base.CurrentUserOrgId);
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
            dtPurchaseItem.Columns.Add("QUICKSEND_NAME");//�Ƿ���
            dtPurchaseItem.Columns.Add("DESCRIPTIONS");//��ע
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
            labelRecordcount.Text = "    �� " + this.gridView3.RowCount + " ������";
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

        #region ����Excel�ļ�

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            if (this.gridView3.RowCount == 0)
            {
                XtraMessageBox.Show("�޿ɲ�����¼��", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            //ѡ�񵼳��ļ�
            string ExpFilePath = this.SelectExportFile();

            if (ExpFilePath.Length == 0)
                return;

            string[] strArr = {"��Ʒ����","ͨ������","Ʒ��","���","�ͺ�","���׼۸�Ԫ��","��λ","��������","������ҵ", "������ҵ","�Ƿ���","�ⷿ"};
            string[] strColNameArr = { "Product_Name", "Common_Name", "Brand", "Spec", "Model", "Trade_Price", "BASE_MEASURE", "AMOUNT", "MANUFACTURE_NAME", "SENDER_NAME", "QUICKSEND_NAME", "STORE_ROOM_NAME" };

            if (FileOperation.ExportExcelFile(dtPurchaseItem, ExpFilePath, strArr, strColNameArr))
            {
                XtraMessageBox.Show("���ݵ����ɹ���", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        /// <summary>
        /// �趨�����ļ�
        /// </summary>
        /// <returns></returns>
        private string SelectExportFile()
        {
            string tmpPath = "";
            try
            {
                this.saveFileDialog1.Filter = "Excel�ļ�(*.xls)|*.xls|dbf�ļ�(*.dbf)|*.dbf|�ı��ļ�(*.txt)|*.txt|�����ļ� (*.*)|*.*";

                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (this.saveFileDialog1.FileName == "")
                    {
                        XtraMessageBox.Show("�����õ��������ļ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
            FrmPrint frmPrint = new FrmPrint(new PurchaseXtraReport(base.CurrentUserOrgName + "�ɹ�������"), dt);
            frmPrint.ShowDialog();
        }

        #region ��Ʒ������
        private void txtRemark_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        /// <summary>
        /// ��ѯ���˷���
        /// </summary>
        private void Filter()
        {
            StringBuilder StrFilter = new StringBuilder();

            string strRemark = this.txtRemark.Text.Trim();

            StrFilter.Append(" 1=1");

            //��ע
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

 