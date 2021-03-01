// =======================
// DevExpress 6.3.5 ���ػ�
// =======================
// 
// ���пؼ��Ѻ�����
// ��������ο���Windows��Office��Visual Studio��רҵ���������http://fosoyo.cnblogs.com/ ��V6.2.4���ػ�
//
// �Ѿ���һ���൱רҵ�ĺ����汾
// 
// By Shoppe Chung, http://blog.csdn.net/allisnew, 2007-05-04
// �κ���������http://blog.csdn.net/allisnew �����ԡ�
//
//
//
//
// ���ʹ��:
// �����ļ��������Ĺ��̣���������������õĿؼ��ĺ������ÿ������������ǰ�棬 ע�͵�������û�����õĿؼ��ĺ���
// 
// ���磺
//  �ҵĽ����ǽ��������÷��� [STAThread] static void Main()�� Application.Run(new ...());֮ǰ
//	[STAThread]
//	static void Main() 
//	{
//      // ����XtraBars
//	    DevExpress.XtraBars.Localization.BarLocalizer.Active = new DevExpress.LocalizationCHS.XtraBarsLocalizer();
//      
//	    Application.Run(new frmMain());
//	}
//
//
// ���ؼ��ĺ������ã�
//		DevExpress.XtraBars.Localization.BarLocalizer.Active            = new DevExpress.LocalizationCHS.XtraBarsLocalizer();
//		DevExpress.XtraCharts.Localization.ChartLocalizer.Active        = new DevExpress.LocalizationCHS.XtraChartsLocalizer();
//		DevExpress.XtraEditors.Controls.Localizer.Active                = new DevExpress.LocalizationCHS.XtraEditorsLocalizer();
//		DevExpress.XtraGrid.Localization.GridLocalizer.Active           = new DevExpress.LocalizationCHS.XtraGridLocalizer();
//		DevExpress.XtraLayout.Localization.LayoutLocalizer.Active       = new DevExpress.LocalizationCHS.XtraLayoutLocalizer();
//		DevExpress.XtraNavBar.NavBarLocalizer.Active                    = new DevExpress.LocalizationCHS.XtraNavBarLocalizer();
//		DevExpress.XtraPivotGrid.Localization.PivotGridLocalizer.Active = new DevExpress.LocalizationCHS.XtraPivotGridLocalizer();
//		DevExpress.XtraPrinting.Localization.PreviewLocalizer.Active    = new DevExpress.LocalizationCHS.XtraPrintingLocalizer();
//		DevExpress.XtraReports.Localization.ReportLocalizer.Active      = new DevExpress.LocalizationCHS.XtraReportsLocalizer();
//		DevExpress.XtraScheduler.Localization.SchedulerLocalizer.Active = new DevExpress.LocalizationCHS.XtraSchedulerLocalizer();
//		DevExpress.XtraTreeList.Localization.TreeListLocalizer.Active   = new DevExpress.LocalizationCHS.XtraTreeListLocalizer();
//		DevExpress.XtraVerticalGrid.Localization.VGridLocalizer.Active  = new DevExpress.LocalizationCHS.XtraVerticalGridLocalizer();
//

using DevExpress.XtraBars.Customization;
using DevExpress.XtraBars.Localization;
using DevExpress.XtraCharts.Localization;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraLayout.Localization;
using DevExpress.XtraNavBar;
//using DevExpress.XtraPivotGrid.Localization;
using DevExpress.XtraPrinting.Localization;
using DevExpress.XtraReports.Localization;
//using DevExpress.XtraScheduler.Localization;
using DevExpress.XtraTreeList.Localization;
using DevExpress.XtraVerticalGrid.Localization;

namespace DevExpress.LocalizationCHS
{
	// XtraBars�������ġ��Զ��塱�Ի���
	public class XtraBarsCustomizationLocalizer : CustomizationControl
	{
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public XtraBarsCustomizationLocalizer()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			this.tpToolbars.SuspendLayout();
			this.tpCommands.SuspendLayout();
			this.tpOptions.SuspendLayout();

			((System.ComponentModel.ISupportInitialize)(this.toolBarsList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lbCommands)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lbCategories)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbOptionsShowFullMenus.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbOptions_showFullMenusAfterDelay.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbOptions_showTips.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbOptions_ShowShortcutInTips.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
			this.tabControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbNBDlgName.Properties)).BeginInit();
			this.pnlNBDlg.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cbOptions_largeIcons.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbOptions_MenuAnimation.Properties)).BeginInit();
			this.SuspendLayout();

			// 
			// ���Զ��塱�Ի��� - WindowCaption
			// 
			//this.WindowCaption = "�Զ���";
			// 
			// ���Զ��塱�Ի��� - btClose
			// 
			this.btClose.Text = "�ر�";

			// 
			// Tabҳͷ = tpToolbars
			// 
			this.tpToolbars.Text = "������ (&B)";
			// 
			// Tabҳͷ = tpCommands
			// 
			this.tpCommands.Text = "���� (&C)";
			// 
			// Tabҳͷ = tpOptions
			// 
			this.tpOptions.Text = "ѡ�� (&O)";


			// ===== �����ǡ���������Tabҳ�ڵĸ�����
			// 
			// ����������Tabҳ�� - lbToolbarCaption
			// 
			this.lbToolbarCaption.Text = "������:";
			// 
			// ����������Tabҳ�� - btNewBar
			// 
			this.btNewBar.Text = "�½� (&N)...";
			// 
			// ����������Tabҳ�� - ���½����Ի���
			//
			this.lbNBDlgCaption.Text = "����������:";
			this.btNBDlgOk.Text = "ȷ��";
			this.btNBDlgCancel.Text = "ȡ��";
			// 
			// ����������Tabҳ�� - btRenameBar
			// 
			this.btRenameBar.Text = "������ (&E)...";
			// 
			// ����������Tabҳ�� - btDeleteBar
			// 
			this.btDeleteBar.Text = "ɾ�� (&D)";
			// 
			// ����������Tabҳ�� - btResetBar
			// 
			this.btResetBar.Text = "�������� (&R)...";


			// ===== �����ǡ����Tabҳ�ڵĸ�����
			// 
			// �����Tabҳ�� - lbCategoriesCaption
			// 
			this.lbCategoriesCaption.Text = "��� (&G):";
			// 
			// �����Tabҳ�� - lbCommandsCaption
			// 
			this.lbCommandsCaption.Text = "���� (&D):";
			// 
			// �����Tabҳ�� - lbDescCaption
			// 
			this.lbDescCaption.Text = "˵��";


			// ===== �����ǡ�ѡ�Tabҳ�ڵĸ�����
			// 
			// ��ѡ�Tabҳ�� - lbOptions_PCaption
			// 
			this.lbOptions_PCaption.Text = "���Ի��˵��͹�����";
			// 
			// ��ѡ�Tabҳ�� - lcbOptionsShowFullMenus
			// 
			this.cbOptionsShowFullMenus.Properties.Caption = "ʼ����ʾ�����˵�";
			// 
			// ��ѡ�Tabҳ�� - lcbOptions_showFullMenusAfterDelay
			// 
			this.cbOptions_showFullMenusAfterDelay.Properties.Caption = "���ָ�����ͣ������ʾ�����˵�";
			// 
			// ��ѡ�Tabҳ�� - lbtOptions_Reset
			// 
			this.btOptions_Reset.Text = "����������� (&R)";
			// 
			// ��ѡ�Tabҳ�� - llbOptions_Other
			// 
			this.lbOptions_Other.Text = "����";
			// 
			// ��ѡ�Tabҳ�� - lcbOptions_largeIcons
			// 
			this.cbOptions_largeIcons.Properties.Caption = "��ͼ�� (&L)";
			// 
			// ��ѡ�Tabҳ�� - lcbOptions_showTips
			// 
			this.cbOptions_showTips.Properties.Caption = "��ʾ���ڹ���������Ļ��ʾ (&T)";
			// 
			// ��ѡ�Tabҳ�� - lcbOptions_ShowShortcutInTips
			// 
			this.cbOptions_ShowShortcutInTips.Properties.Caption = "����Ļ��ʾ����ʾ��ݼ� (&H)";
			// 
			// ��ѡ�Tabҳ�� - llbOptions_MenuAnimation
			// 
			this.lbOptions_MenuAnimation.Text = "�˵��򿪷�ʽ (&M):";

			this.Name = "XtraBarsCustomizationLocalizer_CHS";


			this.tpToolbars.ResumeLayout(false);
			this.tpCommands.ResumeLayout(false);
			this.tpOptions.ResumeLayout(false);

			((System.ComponentModel.ISupportInitialize)(this.toolBarsList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lbCommands)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lbCategories)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbOptionsShowFullMenus.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbOptions_showFullMenusAfterDelay.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbOptions_showTips.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbOptions_ShowShortcutInTips.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
			this.tabControl.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tbNBDlgName.Properties)).EndInit();
			this.pnlNBDlg.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cbOptions_largeIcons.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbOptions_MenuAnimation.Properties)).EndInit();
			this.ResumeLayout(false);
		}
		#endregion
	}


	// XtraBars������
	public class XtraBarsLocalizer : BarLocalizer
	{
		protected override CustomizationControl CreateCustomizationControl()
		{
			return new XtraBarsCustomizationLocalizer();
		}

		public override string GetLocalizedString(BarString id)
		{
			switch (id)
			{
					// = 0
				case BarString.None:
					return "";

					// = 1
				case BarString.AddOrRemove:
					return "��ӻ�ɾ����ť (&A)";

					// = 2
				case BarString.ResetBar:
					return "�Ƿ�ȷ��Ҫȡ���� ��{0}�� �����������޸���";

					// = 3
				case BarString.ResetBarCaption:
					return "�Զ���";

					// = 4
				case BarString.ResetButton:
					return "���蹤���� (&R)";

					// = 5
				case BarString.CustomizeButton:
					return "�Զ��� (&C)...";

					// = 6
				case BarString.ToolBarMenu:
					//					return "&Reset$&Delete$!&Name$!Defau&lt style$&Text Only (Always)$Text &Only (in Menus)$Image &and Text$!Begin a &Group$&Visible$&Most recently used";
					return "���� (&R)$ɾ�� (&D)$!���� (&N)$!Ĭ�Ϸ�� (&L)$ʼ����ʾ�ı� (&T)$���˵�����ʾ�ı� (&O)$ͼ�����ı� (&A)$!��ʼһ�� (&G)$�ɼ��� (&V)$������õ� (&M)";

					// = 7
				case BarString.ToolbarNameCaption:
					return "���������� (&T):";

					// = 8
				case BarString.NewToolbarCaption:
					return "�½�������";

					// = 9
				case BarString.NewToolbarCustomNameFormat:
					return "�Զ��� {0}";

					// = 10
				case BarString.RenameToolbarCaption:
					return "������������";

					// = 11
				case BarString.CustomizeWindowCaption:
					return "�Զ���";

					// = 12
				case BarString.PopupMenuEditor:
					//return "Popup Menu Editor";
					return "�����˵��༭��";

					// = 13
				case BarString.MenuAnimationSystem:
					return "(ϵͳĬ��ֵ)";

					// = 14
				case BarString.MenuAnimationNone:
					return "��Ч��";

					// = 15
				case BarString.MenuAnimationSlide:
					return "����";

					// = 16
				case BarString.MenuAnimationFade:
					return "����";

					// = 17
				case BarString.MenuAnimationUnfold:
					return "չ��";

					// = 18
				case BarString.MenuAnimationRandom:
					return "���";

					// = 19
				case BarString.RibbonToolbarAbove:
					return "�ڹ������Ϸ���ʾ���ٷ��ʹ����� (&P)";

					// = 20
				case BarString.RibbonToolbarBelow:
					return "�ڹ������·���ʾ���ٷ��ʹ����� (&P)";

					// = 21
				case BarString.RibbonToolbarAdd:
					return "��ӵ����ٷ��ʹ����� (&A)";

					// = 22
				case BarString.RibbonToolbarMinimizeRibbon:
					return "��������С�� (&N)";

					// = 23
				case BarString.RibbonToolbarRemove:
					return "�ӿ��ٷ��ʹ�����ɾ�� (&R)";

					// = 24
				case BarString.RibbonGalleryFilter:
					return "������";

					// = 25
				case BarString.RibbonGalleryFilterNone:
					return "��";

					// = 26
				case BarString.BarUnassignedItems:
					//return "(Unassigned Items)";
					return "(δ������)";

					// = 27
				case BarString.BarAllItems:
					//return "(All Items)";
					return "(������)";
			}

			return base.GetLocalizedString(id);
		}		

		public override string Language
		{
			get
			{
				return "��������";
			}
		}
	}

	
	// XtraChartsͼ��
	public class XtraChartsLocalizer : ChartLocalizer
	{
		public override string GetLocalizedString(ChartStringId id)
		{
			switch (id)
			{
					// = 0
				case ChartStringId.SeriesPrefix:
					return "���� ";

					// = 1
				case ChartStringId.PalettePrefix:
					return "��ɫ�� ";

					// = 2
				case ChartStringId.ArgumentMember:
					return "����";

					// = 3
				case ChartStringId.ValueMember:
					return "��ֵ";

					// = 4
				case ChartStringId.LowValueMember:
					return "��ֵ";

					// = 5
				case ChartStringId.HighValueMember:
					return "��ֵ";

					// = 6
				case ChartStringId.OpenValueMember:
					return "��";

					// = 7
				case ChartStringId.CloseValueMember:
					return "�ر�";

					// = 8
				case ChartStringId.DefaultDataFilterName:
					return "����ɸѡ��";

					// = 9
				case ChartStringId.DefaultChartTitle:
					return "ͼ�����";

					// = 10
				case ChartStringId.MsgSeriesViewDoesNotExist:
					return "{0} ���в����ڡ�";

					// = 11
				case ChartStringId.MsgEmptyArrayOfValues:
					return "ֵ������Ϊ�ա�";

					// = 12
				case ChartStringId.MsgItemNotInCollection:
					return "����û�а���ָ���";

					// = 13
				case ChartStringId.MsgIncorrectValue:
					return "����ȷ��ֵ \"{0}\" �������� \"{1}\"��";

					// = 14
				case ChartStringId.MsgIncompatiblePointType:
					return "��(Point) \"{0}\" �����Ͳ����ݱ���(Scale) {1} ��";
					//return "The type of the "{0}" point isn't compatible with the {1} scale.";

					// = 15
				case ChartStringId.MsgIncompatibleArgumentDataMember:
					return "���� \"{0}\" �����Ͳ����ݱ���(Scale) {1} ��";
					//return "The type of the \"{0}\" argument data member isn't compatible with the {1} scale.";

					// = 16
				case ChartStringId.MsgIncompatibleValueDataMember:
					return "ֵ \"{0}\" �����Ͳ����ݱ���(Scale) {1} ��";
					//return "The type of the \"{0}\" value data member isn't compatible with the {1} scale.";

					// = 17
				case ChartStringId.MsgDesignTimeOnlySetting:
					return "�����Բ���������ʱ���á�";

					// = 18
				case ChartStringId.MsgInvalidDataSource:
					return "��Ч������Դ����(�ӿ�û��ʵ��)��";
					//return "Invalid datasource type (no supported interfaces are implemented).";

					// = 19
				case ChartStringId.MsgIncorrectDataMember:
					//return "The datasource doesn't contain a datamember with the \"{0}\" name.";
					return "����Դû�а�����Ϊ \"{0}\" �����ݳ�Ա��";

					// = 20
				case ChartStringId.MsgInvalidColorEachValue:
					//return "This view assumes that the ColorEach property is always set to \"{0}\".";
					return "����ͼ�ٶ�ColorEach����ʼ����Ϊ \"{0}\"��";

					// = 21
				case ChartStringId.MsgInvalidSortingKey:
					//return "It's impossible to set the sorting key's value to {0}.";
					return "���ܽ� {0} ��Ϊ����ļ�ֵ��";

					// = 22
				case ChartStringId.MsgInvalidFilterCondition:
					//return "The {0} condition can't be applied to the \"{1}\" data.";
					return "���� {0} ����Ӧ�������� {1}��";

					// = 23
				case ChartStringId.MsgIncorrectDataAdapter:
					//return "The {0} object isn't a data adapter.";
					return "���� {0} ����������������";

					// = 24
				case ChartStringId.MsgDataSnapshot:
					//return "The data snapshot is complete. All series data now statically persist in the chart. Note, this also means that the chart is now in unbound mode.";
					return "���ݿ�������ɡ�ע�⣬�������е���������ͼ���У�ͼ����δ��ģʽ��";

					// = 25
				case ChartStringId.MsgModifyDefaultPaletteError:
					// return "The palette is default and then can't be modified.";
					return "Ĭ�ϵ�ɫ�岻���޸ġ�";

					// = 26
				case ChartStringId.MsgAddExistingPaletteError:
					//return "The palette with the {0} name already exists in the repository.";
					return "��ɫ�� {0} ���ڵ�ɫ����С�";

					// = 27
				case ChartStringId.MsgInternalPropertyChangeError:
					//return "This property is intended for internal use only. You're not allowed to change its value.";
					return "�����Խ����ڲ�ʹ�ã���ֵ�������޸ġ�";

					// = 28
				case ChartStringId.MsgPaletteNotFound:
					//return "The chart doesn't contain a palette with the {0} name.";
					return "ͼ��û�а�����ɫ�� {0}��";

					// = 29
				case ChartStringId.MsgLabelSettingRuntimeError:
					//return "The \"Label\" property can't be set at runtime.";
					return "\"Label\"���Բ���������ʱ���á�";

					// = 30
				case ChartStringId.MsgPointOptionsSettingRuntimeError:
					//return "The \"PointOptions\" property can't be set at runtime.";
					return "\"PointOptions\"���Բ���������ʱ���á�";

					// = 31
				case ChartStringId.MsgIncorrectAxisRange:
					//return "The min value of the axis range ({0}) should be less than its max value ({1}).";
					return "��ķ�Χ����Сֵ({0})ӦС���������ֵ({1})��";

					// = 32
				case ChartStringId.MsgIncorrectNumericPrecision:
					//return "The precision should be greater than or equal to 0.";
					return "����(Precision)Ӧ���ڵ���0��";

					// = 33
				case ChartStringId.MsgIncorrectAxisThickness:
					//return "The axis thickness should be greater than 0.";
					return "����Ӧ����0��";

					// = 34
				case ChartStringId.MsgIncorrectBarWidth:
					//return "The bar width should be greater than 0.";
					return "�����Ӧ����0��";

					// = 35
				case ChartStringId.MsgIncorrectBarDepth:
					//return "The bar depth should be greater than 0.";
					return "���߶�Ӧ����0��";

					// = 36
				case ChartStringId.MsgIncorrectBorderThickness:
					//return "The border width should be greater than 0.";
					return "�߿���Ӧ����0��";

					// = 37
				case ChartStringId.MsgIncorrectChartTitleIndent:
					//return "The title indent should be greater than or equal to 0 and less than 1000.";
					return "���������Ӧ���ڵ���0��С��1000��";

					// = 38
				case ChartStringId.MsgIncorrectLegendMarkerSize:
					//return "The legend marker size should be greater than 0 and less than 1000.";
					return "ͼ���ĳߴ�Ӧ����0��С��1000��";

					// = 39
				case ChartStringId.MsgIncorrectLegendSpacingVertical:
					//return "The legend vertical spacing should be greater than or equal to 0 and less than 1000.";
					return "ͼ����ֱ���Ӧ���ڵ���0��С��1000��";

					// = 40
				case ChartStringId.MsgIncorrectLegendSpacingHorizontal:
					//return "The legend horizontal spacing should be greater than or equal to 0 and less than 1000.";
					return "ͼ��ˮƽ���Ӧ���ڵ���0��С��1000��";

					// = 41
				case ChartStringId.MsgIncorrectMarkerSize:
					//return "The marker size should be greater than 1.";
					return "��ǵĳߴ�Ӧ����1��";

					// = 42
				case ChartStringId.MsgIncorrectMarkerStarPointCount:
					//return "The number of star points should be greater than 3 and less than 101.";
					return "�����ĿӦ����3��С��101��";

					// = 43
				case ChartStringId.MsgIncorrectPieSeriesLabelColumnIndent:
					//return "The column indent should be greater than or equal to 0.";
					return "��������Ӧ���ڵ���0��";

					// = 44
				case ChartStringId.MsgIncorrectRangeBarSeriesLabelIndent:
					//return "The indent should be greater than or equal to 0.";
					return "����Ӧ���ڵ���0��";

					// = 45
				case ChartStringId.MsgIncorrectPercentPrecision:
					//return "The precision of the percent value should be greater than 0.";
					return "�ٷ����ľ���(Precision)Ӧ����0��";

					// = 46
				case ChartStringId.MsgIncorrectSeriesLabelLineLength:
					//return "The line length should be greater than or equal to 0 and less than 1000.";
					return "�ߵĳ���Ӧ���ڵ���0��С��1000��";

					// = 47
				case ChartStringId.MsgIncorrectStripConstructorParameters:
					//return "The minimum and maximum limits of the Strip can not be the same.";
					return "��(Strip)����С������Ʋ���һ����";

					// = 48
				case ChartStringId.MsgIncorrectStripLimitAxisValue:
					//return "The AxisValue property cannot be set to null for the StripLimit object.";
					return "StripLimit�����AxisValue������Ϊ�ա�";

					// = 49
				case ChartStringId.MsgIncorrectStripMinLimit:
					//return "The min limit of the strip should be less than the max limit.";
					return "��(Strip)����С����ӦС��������ơ�";

					// = 50
				case ChartStringId.MsgIncorrectStripMaxLimit:
					//return "The max limit of the strip should be greater than the min limit.";
					return "��(Strip)���������Ӧ������С���ơ�";

					// = 51
				case ChartStringId.MsgIncorrectLineThickness:
					//return "The line thickness should be greater than 0.";
					return "�߿��Ӧ����0��";

					// = 52
				case ChartStringId.MsgIncorrectShadowSize:
					//return "The shadow size should be greater than 0.";
					return "��Ӱ�ߴ�Ӧ����0��";

					// = 53
				case ChartStringId.MsgIncorrectTickmarkThickness:
					//return "The tickmark thickness should be greater than 0.";
					return "�̶��߿��Ӧ����0��";

					// = 54
				case ChartStringId.MsgIncorrectTickmarkLength:
					//return "The tickmark length should be greater than 0.";
					return "�̶��߳���Ӧ����0��";

					// = 55
				case ChartStringId.MsgIncorrectTickmarkMinorThickness:
					//return "The thickness of the minor tickmark should be greater than 0.";
					return "�̶̿��߿��Ӧ����0��";

					// = 56
				case ChartStringId.MsgIncorrectTickmarkMinorLength:
					//return "The length of the minor tickmark should be greater than 0.";
					return "�̶̿��߳���Ӧ����0��";

					// = 57
				case ChartStringId.MsgIncorrectMinorCount:
					//return "The number of minor count should be greater than 0 and less than 100.";
					return "�̶̿��ߵ���Ŀ��Ӧ����0��";

					// = 58
				case ChartStringId.MsgIncorrectPercentValue:
					//return "The percent value should be greater than or equal to 0 and less than or equal to 100.";
					return "�ٷ�����ֵӦ���ڵ���0��С�ڵ���100��";

					// = 59
				case ChartStringId.MsgIncorrectSimpleDiagramDimension:
					//return "The dimension of the simple diagram should be greater than 0 and less than 100.";
					return "��ͼ��ĳߴ�Ӧ����0��С��100��";

					// = 60
				case ChartStringId.MsgIncorrectStockLevelLineLengthValue:
					//return "The stock level line length value should be greater than or equal to 0.";
					return "��Ʊ��ˮƽ�߳���Ӧ���ڵ���0��";

					// = 61
				case ChartStringId.MsgIncorrectReductionColorValue:
					//return "The reduction color value can't be empty.";
					return "��ɫ����ֵ����Ϊ�ա�";

					// = 62
				case ChartStringId.MsgIncorrectLabelAngle:
					//return "The angle of the label should be greater than or equal to -360 and less than or equal to 360.";
					return "��ǩ�ĽǶ�Ӧ���ڵ���-360�ȣ�С�ڵ���360�ȡ�";

					// = 63
				case ChartStringId.MsgIncorrectImageBounds:
					//return "Can't create an image for the specified size.";
					return "���ܴ���ָ���ߴ��ͼ��";

					// = 64
                //case ChartStringId.MsgInternalFile:
                //    //return "The specified file is an internal file of the project and can't be used.";
                //    return "ָ���ļ��ǹ��̵��ڲ��ļ�������ʹ�á�";

					// = 65
				case ChartStringId.MsgIncorrectUseImageProperty:
					//return "Image property can't be used for the WebChartControl. Please, use the ImageUrl property instead.";
					return "Image���Բ�������WebChartControl�ؼ��ϣ�����ImageUrl���Դ��档";

					// = 66
				case ChartStringId.MsgIncorrectUseImageUrlProperty:
					//return "ImageUrl property can be used for the WebChartControl only. Please, use the Image property instead.";
					return "ImageUrl����ֻ������WebChartControl�ؼ��ϣ�����Image���Դ��档";

					// = 67
				case ChartStringId.MsgIncorrectSeriesDistance:
					//return "The series distance should be greater than or equal to 0.";
					return "����֮��ľ���Ӧ���ڵ���0��";

					// = 68
				case ChartStringId.MsgIncorrectSeriesDistanceFixed:
					//return "The fixed series distance should be greater than or equal to 0.";
					return "�̶�����֮��ľ���Ӧ���ڵ���0��";

					// = 69
				case ChartStringId.MsgIncorrectSeriesIndentFixed:
					//return "The fixed series indent should be greater than or equal to 0.";
					return "�̶����е�����Ӧ���ڵ���0��";

					// = 70xxxx
				case ChartStringId.MsgIncorrectPlaneDepthFixed:
					return "The fixed plane depth should be greater than or equal to 1.";

					// = 71
				case ChartStringId.MsgIncorrectBarDistanceFixed:
					//return "The fixed bar distance should be greater than or equal to 0.";
					return "�̶���֮��ľ���Ӧ���ڵ���0��";

					// = 72
				case ChartStringId.MsgIncorrectBarDistance:
					//return "The bar distance should be greater than or equal to 0.";
					return "��֮��ľ���Ӧ���ڵ���0��";

					// = 73
				case ChartStringId.MsgArgumentSerializationError:
					//return "The argument of the series point can't be serialized correctly.";
					return "�����еĲ���������ȷ�����л���";

					// = 74
				case ChartStringId.MsgArgumentDeserializationError:
					//return "The argument of the series point can't be deserialized correctly.";
					return "�����еĲ���������ȷ�ط����л���";

					// = 75
				case ChartStringId.MsgMinMaxDifferentTypes:
					//return "The types of the MinValue and MaxValue don't match.";
					return "MinValue��MaxValue�����Ͳ�ƥ�䡣";

					// = 76
				case ChartStringId.MsgEmptyArgument:
					//return "An argument can't be empty.";
					return "��������Ϊ�ա�";

					// = 77
				case ChartStringId.MsgIncorrectImageFormat:
					//return "Impossible to export a chart to the specified image format.";
					return "���ܽ�ͼ����Ϊָ����ͼ���ʽ��";

					// = 78
				case ChartStringId.MsgIncorrectValueDataMemberCount:
					//return "It's necessary to specify {0} value data members for the current series view.";
					return "����ָ����ǰ������ͼ {0} ��ֵ��Ա��";

					// = 79
				case ChartStringId.MsgPaletteEditingIsntAllowed:
					//return "Editing isn't allowed !";
					return "������༭��";

					// = 80
				case ChartStringId.MsgPaletteDoubleClickToEdit:
					//return "Double-click to edit...";
					return "˫�����б༭...";

					// = 81
				case ChartStringId.MsgInvalidPaletteName:
					//return "Can't add a palette which has an empty name (\"\") to the palette repository. Please, specify a name for the palette.";
					return "���ܽ�������\"\"�ĵ�ɫ����뵽��ɫ����У���ָ�������ơ�";

					// = 82
				case ChartStringId.MsgInvalidScaleType:
					//return "The specified value to convert to the scale's internal representation isn't compatible with the current scale type.";
					return "ת����ָ��ֵ���ڲ���ʾ�ϲ����ݵ�ǰ�ı���(Scale)���͡�";

					// = 83
				case ChartStringId.MsgIncorrectTransformationMatrix:
					//return "Incorrect transformation matrix.";
					return "����ȷ�ı任����";

					// = 84
				case ChartStringId.MsgIncorrectPerspectiveAngle:
					//return "The perspective angle should be greater than or equal to 0 and less than 180.";
					return "͸�ӽ�Ӧ���ڵ���0�ȣ�С��180�ȡ�";

					// = 85
				case ChartStringId.MsgIncorrectPieDepth:
					//return "The pie depth should be greater than 0 and less than or equal to 100, since its value is measured in percents.";
					return "���߶�Ӧ���ڵ���0��С��100����Ϊ����ֵʹ�ðٷֱȺ����ġ�";

					// = 86
				case ChartStringId.MsgIncorrectGridSpacing:
					//return "The grid spacing should be greater than 0.";
					return "��ļ��(Spacing)Ӧ����0��";

					// = 87
				case ChartStringId.MsgIncompatibleValueScaleType:
					//return "The {0} scale type is incompatble with the {1} series view.";
					return "{0} �ı���(Scale)���Ͳ�����������ͼ {1}��";

					// = 88
				case ChartStringId.MsgIncorrectConstantLineAxisValue:
					//return "AxisValue can't be set to null for the ConstantLine object.";
					return "ConstantLine�����AxisValue������Ϊ�ա�";

					// = 89
				case ChartStringId.MsgIncorrectCustomAxisLabelAxisValue:
					//return "AxisValue can't be set to null for the CustomAxisLabel object.";
					return "CustomAxisLabel�����AxisValue������Ϊ�ա�";

					// = 90
				case ChartStringId.MsgIncorrectAxisRangeMinValue:
					//return "MinValue can't be set to null for the AxisRange object.";
					return "AxisRange�����MinValue������Ϊ�ա�";

					// = 91
				case ChartStringId.MsgIncorrectAxisRangeMaxValue:
					//return "MaxValue can't be set to null for the AxisRange object.";
					return "AxisRange�����MaxValue������Ϊ�ա�";

					// = 92
				case ChartStringId.Msg3DRotationToolTip:
					//return "Use Ctrl with the left mouse button\r\nto rotate the chart's diagram.";
					return "���������������תͼ��";

					// = 93
				case ChartStringId.MsgIncorrectPadding:
					//return "The padding should be greater than or equal to 0.";
					return "�ĵ�(padding)Ӧ���ڵ���0��";

					// = 94
				case ChartStringId.MsgIncorrectTaskLinkMinIndent:
					//return "The task link's minimum indent should be greater than or equal to 0.";
					return "�������ӵ���С����Ӧ���ڵ���0��";

					// = 95
				case ChartStringId.MsgIncorrectArrowWidth:
					//return "The arrow width should be always odd and greater than 0.";
					return "��ͷ���Ӧʼ��������������0��";

					// = 96
				case ChartStringId.MsgIncorrectArrowHeight:
					//return "The arrow height should be greater than 0.";
					return "��ͷ�߶�Ӧ����0��";

					// = 97
				case ChartStringId.MsgInvalidZeroAxisAlignment:
					//return "The Alignment can't be set to Alignment.Zero for the secondary axis.";
					return "�����Alignment������ΪAlignment.Zero��";

					// = 98
				case ChartStringId.MsgNullSeriesViewAxisX:
					//return "The series view's X-axis can't be set to null.";
					return "������ͼ��X�᲻����Ϊ�ա�";

					// = 99
				case ChartStringId.MsgNullSeriesViewAxisY:
					//return "The series view's Y-axis can't be set to null.";
					return "������ͼ��Y�᲻����Ϊ�ա�";

					// = 100
				case ChartStringId.MsgNonExistentSeriesViewAxisX:
					//return "Can't set the series view's X-axis, because the specified secondary axis isn't contained in the diagram's collection of secondary X-axes.";
					return "�����������е�X�ᣬ��Ϊָ���Ĵ���û�а�����ͼ��X���Ἧ���С�";

					// = 101
				case ChartStringId.MsgNonExistentSeriesViewAxisY:
					//return "Can't set the series view's Y-axis, because the specified secondary axis isn't contained in the diagram's collection of secondary Y-axes.";
					return "�����������е�Y�ᣬ��Ϊָ���Ĵ���û�а�����ͼ��Y���Ἧ���С�";

					// = 102
				case ChartStringId.MsgIncorrectSeriesViewAxisX:
					//return "Can't set the series view's X-axis, because the specified axis isn't the primary X-axis of the chart's diagram, or isn't the primary axis at all.";
					return "�����������е�X�ᣬ��Ϊָ�����᲻��ͼ��X���ᣬ���߸����������ᡣ";

					// = 103
				case ChartStringId.MsgIncorrectSeriesViewAxisY:
					//return "Can't set the series view's Y-axis, because the specified axis isn't the primary Y-axis of the chart's diagram, or isn't the primary axis at all.";
					return "�����������е�Y�ᣬ��Ϊָ�����᲻��ͼ��Y���ᣬ���߸����������ᡣ";

					// = 104
				case ChartStringId.MsgIncorrectParentSeriesPointOwner:
					//return "Owner of the parent series point can't be null and must be of the Series type.";
					return "�����е�������߲���Ϊ���ұ�������������(Series)��";

					// = 105
				case ChartStringId.MsgSeriesViewNotSupportRelations:
					//return "This series view doesn't support relations.";
					return "������ͼ��֧�ֹ�����";

					// = 106
				case ChartStringId.MsgIncorrectChildSeriesPointOwner:
					//return "Owner of the child series point can't be null and must be of the Series type.";
					return "�����е�������߲���Ϊ���ұ�������������(Series)��";

					// = 107
				case ChartStringId.MsgIncorrectChildSeriesPointID:
					//return "Child series point's ID must be positive or equal to zero.";
					return "�����е��ID������������0��";

					// = 108
				case ChartStringId.MsgIncorrectSeriesOfParentAndChildPoints:
					//return "Parent and child points must belong to the same series.";
					return "�����е�������е��ID��������ͬһ�����С�";

					// = 109
				case ChartStringId.MsgSelfRelatedSeriesPoint:
					//return "Series point can't have a relation to itself.";
					return "���е㲻�ܹ����Լ���";

					// = 110
				case ChartStringId.MsgSeriesPointRelationAlreadyExists:
					//return "The SeriesPointRelations collection already contains this relation.";
					return "SeriesPointRelations �����Ѿ������˹�����";

					// = 111
				case ChartStringId.MsgChildSeriesPointNotExist:
					//return "Child series point with ID equal to {0} doesn't exist.";
					return "IDΪ {0} �������е㲻���ڡ�";

					// = 112
				case ChartStringId.MsgRelationChildPointIDNotUnique:
					//return "Relation's ChildPointID must be unique.";
					return "�����������е�ID����Ψһ��";

					// = 113
				case ChartStringId.MsgSeriesPointIDNotUnique:
					//return "Series point's ID must be unique.";
					return "���е�ID����Ψһ��";

					// = 114
				case ChartStringId.MsgIncorrectFont:
					//return "Font can't be null.";
					return "���岻��Ϊ�ա�";

					// = 115
				case ChartStringId.MsgCalcHitInfoNotSupported:
					//return "Hit testing for 3D Chart Types isn't supported. So, this method is supported for 2D Chart Types only.";
					return "3Dͼ�����Ͳ�֧��Hit Test��2Dͼ��֧�֡�";

					// = 116
				case ChartStringId.VerbAbout:
					//return "About";
					return "����";

					// = 117
				case ChartStringId.VerbAboutDescription:
					//return "Shows basic information on the XtraCharts product.";
					return "��XtraCharts��Ʒ����ʾ������Ϣ��";

					// = 118
				case ChartStringId.VerbPopulate:
					//return "Populate";
					return "װ��";

					// = 119
				case ChartStringId.VerbPopulateDescription:
					//return "Populates the chart's datasource with data.";
					return "װ��ͼ������Դ��";

					// = 120
				case ChartStringId.VerbClearDataSource:
					//return "Clear datasource";
					return "�������Դ";

					// = 121
				case ChartStringId.VerbClearDataSourceDescription:
					//return "Clears the chart's datasource.";
					return "���ͼ������Դ��";

					// = 122
				case ChartStringId.VerbDataSnapshot:
					//return "Data snapshot";
					return "���ݿ���";

					// = 123
				case ChartStringId.VerbDataSnapshotDescription:
					//return "Copies all the data from the bound datasource to the chart, and then unbinds the datasource.";
					return "�Ӱ�����Դ�������ݵ�ͼ���ٽ������Դ��";

					// = 124
				case ChartStringId.VerbSeries:
					//return "Series...";
					return "����...";

					// = 125
				case ChartStringId.VerbSeriesDescription:
					//return "Opens the Series Collection Editor.";
					return "�����м��ϵı༭����";

					// = 126
				case ChartStringId.VerbEditPalettes:
					//return "Edit palettes...";
					return "�༭��ɫ��...";

					// = 127
				case ChartStringId.VerbEditPalettesDescription:
					//return "Opens the Palettes Editor.";
					return "�򿪵�ɫ��༭����";

					// = 128
				case ChartStringId.VerbWizard:
					//return "Wizard...";
					return "��...";

					// = 129
				case ChartStringId.VerbWizardDescription:
					//return "Runs the Chart Wizard, which allows the properties of the chart to be edited.";
					return "����ͼ�������༭ͼ�����ԡ�";

					// = 130
				case ChartStringId.PieIncorrectValuesText:
					//return "The Pie view can't represent negative\r\nvalues. All values must be either greater\r\nthan or equal to zero.";
					return "��ͼ������渺��������ֵ������ڵ���0��";

					// = 131
				case ChartStringId.FontFormat:
					return "{0}, {1}pt, {2}";

					// = 132
				case ChartStringId.TrnSeriesChanged:
					//return "Series changed";
					return "�����Ѹ���";

					// = 133
				case ChartStringId.TrnDataFiltersChanged:
					//return "DataFilters changed";
					return "����ɸѡ���Ѹ���";

					// = 134
				case ChartStringId.TrnValueDataMembersChanged:
					//return "ValueDataMembers changed";
					return "����ֵ���Ѹ���";

					// = 135
				case ChartStringId.TrnChartTitlesChanged:
					//return "Chart titles changed";
					return "ͼ������Ѹ���";

					// = 136
				case ChartStringId.TrnPalettesChanged:
					//return "Palettes changed";
					return "��ɫ���Ѹ���";

					// = 137
				case ChartStringId.TrnConstantLinesChanged:
					//return "Constant Lines changed";
					return "����(Constant Lines)�Ѹ���";

					// = 138
				case ChartStringId.TrnStripsChanged:
					//return "Strips changed";
					return "��(Strips)�Ѹ���";

					// = 139
				case ChartStringId.TrnCustomAxisLabelChanged:
					//return "Custom Axis Labels changed";
					return "�Զ������ǩ�Ѹ���";

					// = 140
				case ChartStringId.TrnSecondaryAxesXChanged:
					//return "Secondary axes X changed";
					return "X�����Ѹ���";

					// = 141
				case ChartStringId.TrnSecondaryAxesYChanged:
					//return "Secondary axes Y changed";
					return "Y�����Ѹ���";

					// = 142
				case ChartStringId.TrnChartWizard:
					//return "Chart wizard settings applied";
					return "ͼ����������Ӧ��";

					// = 143
				case ChartStringId.TrnSeriesDeleted:
					//return "Series deleted";
					return "������ɾ��";

					// = 144
				case ChartStringId.TrnChartTitleDeleted:
					//return "Chart title deleted";
					return "ͼ�������ɾ��";

					// = 145
				case ChartStringId.TrnConstantLineDeleted:
					//return "Constant line deleted";
					return "����(Constant Lines)��ɾ��";

					// = 146
				case ChartStringId.TrnSecondryAxisXDeleted:
					//return "Secondary axis X deleted";
					return "X������ɾ��";

					// = 147
				case ChartStringId.TrnSecondryAxisYDeleted:
					//return "Secondary axis Y deleted";
					return "Y������ɾ��";

					// = 148
				case ChartStringId.AxisXDefaultTitle:
					//return "Axis of arguments";
					return "������";

					// = 149
				case ChartStringId.AxisYDefaultTitle:
					//return "Axis of values";
					return "ֵ��";

					// = 150
				case ChartStringId.DefaultMinValue:
					//return "Min";
					return "��С";

					// = 151
				case ChartStringId.DefaultMaxValue:
					//return "Max";
					return "���";

					// = 152
				case ChartStringId.MenuItemAdd:
					//return "Add";
					return "���";

					// = 153
				case ChartStringId.MenuItemInsert:
					//return "Insert";
					return "����";

					// = 154
				case ChartStringId.MenuItemDelete:
					//return "Delete";
					return "ɾ��";

					// = 155
				case ChartStringId.MenuItemClear:
					//return "Clear";
					return "���";

					// = 156
				case ChartStringId.MenuItemMoveUp:
					//return "Move Up";
					return "����";

					// = 157
				case ChartStringId.MenuItemMoveDown:
					//return "Move Down";
					return "����";

					// = 158
				case ChartStringId.WizBarSeriesLabelPositionTop:
					//return "Top";
					return "����";

					// = 159
				case ChartStringId.WizBarSeriesLabelPositionCenter:
					//return "Center";
					return "����";

					// = 160
				case ChartStringId.WizPieSeriesLabelPositionInside:
					//return "Inside";
					return "�ڲ�";

					// = 161
				case ChartStringId.WizPieSeriesLabelPositionOutside:
					//return "Outside";
					return "�ⲿ";

					// = 162
				case ChartStringId.WizPieSeriesLabelPositionTwoColumns:
					//return "Two Columns";
					return "����";

					// = 163
				case ChartStringId.WizBoundSeries:
					//return "Bound Series";
					return "������";

					// = 164
				case ChartStringId.WizSeriesLabelDefaultText:
					//return "<empty>";
					return "<��>";

					// = 165
				case ChartStringId.WizAddProjectDataSource:
					//return "Add New Data Source...";
					return "���������Դ...";

					// = 166
				case ChartStringId.WizNullDataSourceConfirmation:
					//return "After setting the DataSource to null, all information on the bound series will be lost. Are you sure you want to proceed?";
					return "����Դ��Ϊ�պ󣬰�����������Ϣ����ʧ����ȷ��Ҫ������";

					// = 167
				case ChartStringId.WizCurrentAppearance:
					//return "Current Appearance";
					return "��ǰ���";

					// = 168
				case ChartStringId.WizNoSuitableData:
					//return "No data suitable for creating series points has been found.";
					return "û�������ʺϴ��������С�";

					// = 169
				case ChartStringId.SvnSideBySideBar:
					//return "Bar";
					return "��״��ͼ";

					// = 170
				case ChartStringId.SvnStackedBar:
					//return "Bar Stacked";
					return "������״��ͼ";

					// = 171
				case ChartStringId.SvnFullStackedBar:
					//return "Bar Stacked 100%";
					return "100%������״��ͼ";

					// = 172
				case ChartStringId.SvnPie:
					//return "Pie";
					return "��ͼ";

					// = 173
				case ChartStringId.SvnPoint:
					//return "Point";
					return "ɢ��ͼ";

					// = 174
				case ChartStringId.SvnLine:
					//return "Line";
					return "����ͼ";

					// = 175
				case ChartStringId.SvnStepLine:
					//return "Step Line";
					return "������ͼ";

					// = 176
				case ChartStringId.SvnArea:
					//return "Area";
					return "����ͼ";

					// = 177
				case ChartStringId.SvnStackedArea:
					//return "Area Stacked";
					return "��������ͼ";

					// = 178
				case ChartStringId.SvnFullStackedArea:
					//return "Area Stacked 100%";
					return "100%��������ͼ";

					// = 179
				case ChartStringId.SvnStock:
					//return "Stock";
					return "��Ʊͼ";

					// = 180
				case ChartStringId.SvnCandleStick:
					//return "Candle Stick";
					return "������ͼ";

					// = 181
				case ChartStringId.SvnSideBySideRangeBar:
					//return "Side By Side Range Bar";
					return "����������״ͼ";

					// = 182
				case ChartStringId.SvnOverlappedRangeBar:
					//return "Range Bar";
					return "������״ͼ";

					// = 183
				case ChartStringId.SvnSideBySideGantt:
					//return "Side By Side Gantt";
					return "��������ͼ";

					// = 184
				case ChartStringId.SvnOverlappedGantt:
					//return "Gantt";
					return "����ͼ";

					// = 185
				case ChartStringId.SvnManhattanBar:
					//return "Manhattan Bar";
					return "Manhattan��״ͼ";

					// = 186
				case ChartStringId.SvnPie3D:
					//return "Pie 3D";
					return "3D��ͼ";

					// = 187
				case ChartStringId.IncompatibleSeriesView:
					//return "(incompatible)";
					return "(������)";

					// = 188
				case ChartStringId.InvisibleSeriesView:
					//return "(invisible)";
					return "(���ɼ�)";

					// = 189
				case ChartStringId.IncompatibleSeriesHeader:
					//return "This series is incompatible:\r\n";
					return "�����в����ݣ�\r\n";

					// = 190xxxx
				case ChartStringId.IncompatibleSeriesMessage:
					return "by {0} with \"{1}\"";

					// = 191
				case ChartStringId.PrimaryAxisXName:
					//return "PrimaryAxisX";
					return "X����";

					// = 192
				case ChartStringId.PrimaryAxisYName:
					//return "PrimaryAxisY";
					return "Y����";

					// = 193
				case ChartStringId.IOCaption:
					//return "Illegal Operation";
					return "�Ƿ�����";

					// = 194
				case ChartStringId.IODeleteAxis:
					//return "The primary axis can't be deleted. If you want to hide it, set its Visible property to false.";
					return "����ɾ�����ᡣ��ͨ����Visible������Ϊfalse����������";
			}

			return base.GetLocalizedString(id);
		}

		public override string Language
		{
			get
			{
				return "��������";
			}
		}
	}


	// XtraEditors�����༭��
	public class XtraEditorsLocalizer : Localizer
	{
		public override string GetLocalizedString(StringId id)
		{
			switch (id)
			{
					// = 0
				case StringId.None:
					return "";

					// = 1
				case StringId.CaptionError:
					// return "Error";
					return "����";

					// = 2
				case StringId.InvalidValueText:
					// return "Invalid Value";
					return "��Чֵ";

					// = 3
				case StringId.CheckChecked:
					// return "Checked";
					return "��ѡ��";

					// = 4
				case StringId.CheckUnchecked:
					// return "Unchecked";
					return "δѡ��";

					// = 5
				case StringId.CheckIndeterminate:
					// return "Indeterminate";
					return "δѡ��";

					// = 6
				case StringId.DateEditToday:
					// return "Today";
					return "����";

					// = 7
				case StringId.DateEditClear:
					// return "Clear";
					return "���";

					// = 8
				case StringId.OK:
					// return "&OK";
					return "ȷ�� (&O)";

					// = 9
				case StringId.Cancel:
					// return "&Cancel";
					return "ȡ�� (&C)";

					// = 10
				case StringId.NavigatorFirstButtonHint:
					// return "First";
					return "��һ��";

					// = 11
				case StringId.NavigatorPreviousButtonHint:
					// return "Previous";
					return "��һ��";

					// = 12
				case StringId.NavigatorPreviousPageButtonHint:
					// return "Previous Page";
					return "��һҳ";

					// = 13
				case StringId.NavigatorNextButtonHint:
					// return "Next";
					return "��һ��";

					// = 14
				case StringId.NavigatorNextPageButtonHint:
					// return "Next Page";
					return "��һҳ";

					// = 15
				case StringId.NavigatorLastButtonHint:
					// return "Last";
					return "���һ��";

					// = 16
				case StringId.NavigatorAppendButtonHint:
					// return "Append";
					return "���";

					// = 17
				case StringId.NavigatorRemoveButtonHint:
					// return "Delete";
					return "ɾ��";

					// = 18
				case StringId.NavigatorEditButtonHint:
					// return "Edit";
					return "�༭";

					// = 19
				case StringId.NavigatorEndEditButtonHint:
					// return "End Edit";
					return "�����༭";

					// = 20
				case StringId.NavigatorCancelEditButtonHint:
					// return "Cancel Edit";
					return "ȡ���༭";

					// = 21
				case StringId.NavigatorTextStringFormat:
					// return "Record {0} of {1}";
					return "{0} / {1}";

					// = 22
				case StringId.PictureEditMenuCut:
					// return "Cut";
					return "����";

					// = 23
				case StringId.PictureEditMenuCopy:
					// return "Copy";
					return "����";

					// = 24
				case StringId.PictureEditMenuPaste:
					// return "Paste";
					return "ճ��";

					// = 25
				case StringId.PictureEditMenuDelete:
					// return "Delete";
					return "ɾ��";

					// = 26
				case StringId.PictureEditMenuLoad:
					// return "Load";
					return "����";

					// = 27
				case StringId.PictureEditMenuSave:
					// return "Save";
					return "����";

					// = 28
				case StringId.PictureEditOpenFileFilter:
					// return "Bitmap Files (*.bmp)|*.bmp|Graphics Interchange Format (*.gif)|*.gif|JPEG File Interchange Format (*.jpg;*.jpeg)|*.jpg;*.jpeg|Icon Files (*.ico)|*.ico|All Picture Files |*.bmp;*.gif;*.jpg;*.jpeg;*.ico;*.png;*.tif|All Files |*.*";
					return "λͼ�ļ� (*.bmp)|*.bmp|ͼ�ν�����ʽ (*.gif)|*.gif|JPEG �ļ�������ʽ (*.jpg;*.jpeg))|*.jpg;*.jpeg|ͼ���ļ� (*.ico)|*.ico|����ͼƬ�ļ� |*.bmp;*.gif;*.jpg;*.jpeg;*.ico;*.png;*.tif|�����ļ� |*.*";

					// = 29
				case StringId.PictureEditSaveFileFilter:
					// return "Bitmap Files (*.bmp)|*.bmp|Graphics Interchange Format (*.gif)|*.gif|JPEG File Interchange Format (*.jpg)|*.jpg";
					return "λͼ�ļ� (*.bmp)|*.bmp|ͼ�ν�����ʽ (*.gif)|*.gif|JPEG �ļ�������ʽ (*.jpg)|*.jpg";

					// = 30
				case StringId.PictureEditOpenFileTitle:
					// return "Open";
					return "��";

					// = 31
				case StringId.PictureEditSaveFileTitle:
					// return "Save As";
					return "���Ϊ";

					// = 32
				case StringId.PictureEditOpenFileError:
					// return "Wrong picture format";
					return "�����ͼƬ��ʽ";

					// = 33
				case StringId.PictureEditOpenFileErrorCaption:
					// return "Open error";
					return "�򿪴���";

					// = 34
				case StringId.LookUpEditValueIsNull:
					// return "[EditValue is null]";
					return "[��ֵ]";

					// = 35
				case StringId.LookUpInvalidEditValueType:
					// return "Invalid LookUpEdit EditValue type.";
					return "��Ч��LookUpEdit EditValue����";

					// = 36
				case StringId.LookUpColumnDefaultName:
					// return "Name";
					return "����";

					// = 37
				case StringId.MaskBoxValidateError:
					// return "The entered value is incomplete.  Do you want to correct it?\r\n\r\nYes - // return to the editor and correct the value.\r\nNo - leave the value as is.\r\nCancel - reset to the previous value.";
					return "����ֵ���������Ƿ���Ҫ������\r\n\r\n�� - ���ر༭���Ը�����\r\n�� - ����ԭֵ���䡣\r\nȡ�� - ���ô�ǰ��ֵ��";

					// = 38
				case StringId.UnknownPictureFormat:
					// return "Unknown picture format";
					return "δ֪��ͼƬ��ʽ";

					// = 39
				case StringId.DataEmpty:
					// return "No image data";
					return "��ͼ������";

					// = 40
				case StringId.NotValidArrayLength:
					// return "Not valid array length.";
					return "��Ч�����鳤��.";

					// = 41
				case StringId.ImagePopupEmpty:
					// return "(Empty)";
					return "(��)";

					// = 42
				case StringId.ImagePopupPicture:
					// return "(Picture)";
					return "(ͼƬ)";

					// = 43
				case StringId.ColorTabCustom:
					// return "Custom";
					return "�Զ���";

					// = 44
				case StringId.ColorTabWeb:
					return "Web";

					// = 45
				case StringId.ColorTabSystem:
					// return "System";
					return "ϵͳ";

					// = 46
				case StringId.CalcButtonMC:
					return "MC";

					// = 47
				case StringId.CalcButtonMR:
					return "MR";

					// = 48
				case StringId.CalcButtonMS:
					return "MS";

					// = 49
				case StringId.CalcButtonMx:
					return "M+";

					// = 50
				case StringId.CalcButtonSqrt:
					//return "sqrt";
					return "����";

					// = 51
				case StringId.CalcButtonBack:
					//return "Back"; ��ǰ��ֵ��λ
					return "��λ";

					// = 52
				case StringId.CalcButtonCE:
					// return "CE"; ����ǰ��������Ϊ��
					return "��0";

					// = 53
				case StringId.CalcButtonC:
					// return "C"; ���㣬�����������ָ�������״̬
					return "���"; 

					// = 54
				case StringId.CalcError:
					return "�������";

					// = 55
				case StringId.TabHeaderButtonPrev:
					// return "Scroll Left";
					return "�������";

					// = 56
				case StringId.TabHeaderButtonNext:
					// return "Scroll Right";
					return "���ҹ���";

					// = 57
				case StringId.TabHeaderButtonClose:
					// return "Close";
					return "�ر�";

					// = 58
				case StringId.XtraMessageBoxOkButtonText:
					// return "&OK";
					return "ȷ�� (&O)";

					// = 59
				case StringId.XtraMessageBoxCancelButtonText:
					// return "&Cancel";
					return "ȡ�� (&C)";

					// = 60
				case StringId.XtraMessageBoxYesButtonText:
					// return "&Yes";
					return "�� (&Y)";

					// = 61
				case StringId.XtraMessageBoxNoButtonText:
					// return "&No";
					return "�� (&N)";

					// = 62
				case StringId.XtraMessageBoxAbortButtonText:
					// return "&Abort";
					return "�ж� (&A)";

					// = 63
				case StringId.XtraMessageBoxRetryButtonText:
					// return "&Retry";
					return "���� (&R)";

					// = 64
				case StringId.XtraMessageBoxIgnoreButtonText:
					// return "&Ignore";
					return "���� (&I)";

					// = 65
				case StringId.TextEditMenuUndo:
					// return "&Undo";
					return "���� (&U)";

					// = 66
				case StringId.TextEditMenuCut:
					// return "Cu&t";
					return "���� (&T)";

					// = 67
				case StringId.TextEditMenuCopy:
					// return "&Copy";
					return "���� (&C)";

					// = 68
				case StringId.TextEditMenuPaste:
					// return "&Paste";
					return "ճ�� (&P)";

					// = 69
				case StringId.TextEditMenuDelete:
					// return "&Delete";
					return "ɾ�� (&D)";

					// = 70
				case StringId.TextEditMenuSelectAll:
					// return "Select &All";
					return "ȫѡ (&A)";

					// = 71
				case StringId.FilterGroupAnd:
					// return "And";
					return "��";

					// = 72
				case StringId.FilterGroupNotAnd:
					// return "Not And";
					return "���";

					// = 73
				case StringId.FilterGroupNotOr:
					//return "Not Or";
					return "���";

					// = 74
				case StringId.FilterGroupOr:
					// return "Or";
					return "��";

					// = 75
				case StringId.FilterClauseAnyOf:
					// return "Is any of";
					return "������һ";

					// = 76
				case StringId.FilterClauseBeginsWith:
					// return "Begins with";
					return "��ʼ��(�ִ�)";

					// = 77
				case StringId.FilterClauseBetween:
					// return "Is between";
					return "����(��Χ֮��)";

					// = 78
				case StringId.FilterClauseBetweenAnd:
					// return "and";
					return "��";

					// = 79
				case StringId.FilterClauseContains:
					// return "Contains";
					return "����";

					// = 80
				case StringId.FilterClauseEndsWith:
					// return "Ends with";
					return "������(�ִ�)";

					// = 81
				case StringId.FilterClauseEquals:
					// return "Equals";
					return "����";

					// = 82
				case StringId.FilterClauseGreater:
					// return "Is greater than";
					return "����";

					// = 83
				case StringId.FilterClauseGreaterOrEqual:
					// return "Is greater than or equal to";
					return "���ڵ���";

					// = 84
				case StringId.FilterClauseIsNotNull:
					// return "Is not blank";
					return "��Ϊ��";

					// = 85
				case StringId.FilterClauseIsNull:
					// return "Is blank";
					return "Ϊ��";

					// = 86
				case StringId.FilterClauseLess:
					// return "Is less than";
					return "С��";

					// = 87
				case StringId.FilterClauseLessOrEqual:
					// return "Is less than or equal to";
					return "С�ڵ���";

					// = 88
				case StringId.FilterClauseLike:
					// return "Is like";
					return "ƥ��(Like)";

					// = 89
				case StringId.FilterClauseNoneOf:
					// return "Is none of";
					return "��������һ";

					// = 90
				case StringId.FilterClauseNotBetween:
					// return "Is not between";
					return "������(��Χ֮��)";

					// = 91
				case StringId.FilterClauseDoesNotContain:
					// return "Does not contain";
					return "������";

					// = 92
				case StringId.FilterClauseDoesNotEqual:
					// return "Does not equal";
					return "������";

					// = 93
				case StringId.FilterClauseNotLike:
					// return "Is not like";
					return "��ƥ��(Like)";

					// = 94
				case StringId.FilterEmptyEnter:
					// return "<enter a value>";
					return "<����һ��ֵ>";

					// = 95
				case StringId.FilterEmptyValue:
					// return "<empty>";
					return "<��>";

					// = 96
				case StringId.FilterMenuConditionAdd:
					// return "Add Condition";
					return "�������";

					// = 97
				case StringId.FilterMenuGroupAdd:
					// return "Add Group";
					return "���������";

					// = 98
				case StringId.FilterMenuClearAll:
					// return "Clear All";
					return "ȫ�����";

					// = 99
				case StringId.FilterMenuRowRemove:
					// return "Remove Group";
					return "ɾ��������";

					// = 100
				case StringId.FilterToolTipNodeAdd:
					// return "Adds a new condition to this group";
					return "���������������";

					// = 101
				case StringId.FilterToolTipNodeRemove:
					// return "Removes this condition";
					return "ɾ��������";

					// = 102
				case StringId.FilterToolTipNodeAction:
					return "Actions";

					// = 103
				case StringId.FilterToolTipValueType:
					return "Compare with a value / another field's value";

					// = 104
				case StringId.FilterToolTipElementAdd:
					return "Adds a new item to the list";

					// = 105
				case StringId.FilterToolTipKeysAdd:
					// return "(Use the Insert or Add key)";
					return "(ʹ��'Insert'�� / ������'+'��)";

					// = 106
				case StringId.FilterToolTipKeysRemove:
					// return "(Use the Delete or Subtract key)";
					return "(ʹ��'Delete'�� / ������'-'��)";

					// = 107
				case StringId.ContainerAccessibleEditName:
					return "Editing control";

					// = 108
				case StringId.FilterCriteriaToStringGroupOperatorAnd:
					// return "��";
					return "��";

					// = 109
				case StringId.FilterCriteriaToStringGroupOperatorOr:
					// return "Or";
					return "��";

					// = 110
				case StringId.FilterCriteriaToStringUnaryOperatorBitwiseNot:
					return "~";

					// = 111
				case StringId.FilterCriteriaToStringUnaryOperatorIsNull:
					// return "Is Null";
					return "Ϊ��";

					// = 112
				case StringId.FilterCriteriaToStringUnaryOperatorMinus:
					return "-";

					// = 113
				case StringId.FilterCriteriaToStringUnaryOperatorNot:
					// return "Not";
					return "��";

					// = 114
				case StringId.FilterCriteriaToStringUnaryOperatorPlus:
					return "+";

					// = 115
				case StringId.FilterCriteriaToStringBinaryOperatorBitwiseAnd:
					return "&";

					// = 116
				case StringId.FilterCriteriaToStringBinaryOperatorBitwiseOr:
					return "|";

					// = 117
				case StringId.FilterCriteriaToStringBinaryOperatorBitwiseXor:
					return "^";

					// = 118
				case StringId.FilterCriteriaToStringBinaryOperatorDivide:
					return "/";

					// = 119
				case StringId.FilterCriteriaToStringBinaryOperatorEqual:
					return "=";

					// = 120
				case StringId.FilterCriteriaToStringBinaryOperatorGreater:
					return ">";

					// = 121
				case StringId.FilterCriteriaToStringBinaryOperatorGreaterOrEqual:
					return ">=";

					// = 122
				case StringId.FilterCriteriaToStringBinaryOperatorLess:
					return "<";

					// = 123
				case StringId.FilterCriteriaToStringBinaryOperatorLessOrEqual:
					return "<=";

					// = 124
				case StringId.FilterCriteriaToStringBinaryOperatorLike:
					return "ƥ��(Like)";

					// = 125
				case StringId.FilterCriteriaToStringBinaryOperatorMinus:
					return "-";

					// = 126
				case StringId.FilterCriteriaToStringBinaryOperatorModulo:
					return "%";

					// = 127
				case StringId.FilterCriteriaToStringBinaryOperatorMultiply:
					return "*";

					// = 128
				case StringId.FilterCriteriaToStringBinaryOperatorNotEqual:
					// return "<>";
					return "��";

					// = 129
				case StringId.FilterCriteriaToStringBinaryOperatorPlus:
					return "+";

					// = 130
				case StringId.FilterCriteriaToStringBetween:
					// return "Between";
					return "����";

					// = 131
				case StringId.FilterCriteriaToStringIn:
					// return "In";
					return "����";

					// = 132
				case StringId.FilterCriteriaToStringIsNotNull:
					// return "Is Not Null";
					return "��Ϊ��";

					// = 133
				case StringId.FilterCriteriaToStringNotLike:
					// return "Not Like";
					return "��ƥ��(Like)";

					// = 134
				case StringId.FilterCriteriaToStringFunctionIif:
					return "Iif";

					// = 135
				case StringId.FilterCriteriaToStringFunctionIsNull:
					return "IsNull";

					// = 136
				case StringId.FilterCriteriaToStringFunctionLen:
					return "Len";

					// = 137
				case StringId.FilterCriteriaToStringFunctionLower:
					return "Lower";

					// = 138
				case StringId.FilterCriteriaToStringFunctionNone:
					return "None";

					// = 139
				case StringId.FilterCriteriaToStringFunctionSubstring:
					return "Substring";

					// = 140
				case StringId.FilterCriteriaToStringFunctionTrim:
					return "Trim";

					// = 141
				case StringId.FilterCriteriaToStringFunctionUpper:
					return "Upper";

					// = 142
				case StringId.FilterCriteriaToStringFunctionCustom:
					return "Custom";
			}

			return base.GetLocalizedString(id);
		}

		public override string Language
		{
			get
			{
				return "��������";
			}
		}
	}


	// XtraGrid���
	public class XtraGridLocalizer : GridLocalizer
	{
		public override string GetLocalizedString(GridStringId id)
		{
			switch (id)
			{
					// = 0
				case GridStringId.FileIsNotFoundError:
					// return "File {0} is not found";
					return "�ļ�{0}û���ҵ�";

					// = 1
				case GridStringId.ColumnViewExceptionMessage:
					// return " Do you want to correct the value ?";
					return "�Ƿ�ȷ��Ҫ�޸�ֵ��";

					// = 2
				case GridStringId.CustomizationCaption:
					// return "Customization";
					return "ѡ����ʾ��";

					// = 3
				case GridStringId.CustomizationColumns:
					// return "Columns";
					return "��";

					// = 4
				case GridStringId.CustomizationBands:
					// return "Bands";
					return "��";

					// = 5
				case GridStringId.FilterPanelCustomizeButton:
					// return "Edit Filter";
					return "�༭����";

					// = 6
				case GridStringId.PopupFilterAll:
					// return "(All)";
					return "(����)";

					// = 7
				case GridStringId.PopupFilterCustom:
					// return "(Custom)";
					return "(�Զ���)";

					// = 8
				case GridStringId.PopupFilterBlanks:
					// return "(Blanks)";
					return "(��ֵ)";

					// = 9
				case GridStringId.PopupFilterNonBlanks:
					// return "(Non blanks)";
					return "(�ǿ�ֵ)";

					// = 10
				case GridStringId.CustomFilterDialogFormCaption:
					// return "Custom AutoFilter";
					return "�Զ���ɸѡ����";

					// = 11
				case GridStringId.CustomFilterDialogCaption:
					// return "Show rows where:";
					return "����Ϊ:";

					// = 12
				case GridStringId.CustomFilterDialogRadioAnd:
					// return "&And";
					return "�� (&A)";

					// = 13
				case GridStringId.CustomFilterDialogRadioOr:
					// return "O&r";
					return "�� (&R)";

					// = 14
				case GridStringId.CustomFilterDialogOkButton:
					// return "&OK";
					return "ȷ�� (&O)";

					// = 15
				case GridStringId.CustomFilterDialogClearFilter:
					// return "C&lear Filter";
					return "���ɸѡ�� (&L)";

					// = 16
				case GridStringId.CustomFilterDialog2FieldCheck:
					// return "Field";
					return "��";

					// = 17
				case GridStringId.CustomFilterDialogCancelButton:
					// return "&Cancel";
					return "ȡ�� (&C)";

					// = 18
				case GridStringId.CustomFilterDialogConditionEQU:
					// return "equals";
					return "����";

					// = 19
				case GridStringId.CustomFilterDialogConditionNEQ:
					// return "does not equal";
					return "������<>";

					// = 20
				case GridStringId.CustomFilterDialogConditionGT:
					// return "is greater than";
					return "����>";

					// = 21
				case GridStringId.CustomFilterDialogConditionGTE:
					// return "is greater than or equal to";
					return "���ڻ����>=";

					// = 22
				case GridStringId.CustomFilterDialogConditionLT:
					// return "is less than";
					return "С��<";

					// = 23
				case GridStringId.CustomFilterDialogConditionLTE:
					// return "is less than or equal to";
					return "С�ڻ����<=";

					// = 24
				case GridStringId.CustomFilterDialogConditionBlanks:
					// return "blanks";
					return "��ֵ";

					// = 25
				case GridStringId.CustomFilterDialogConditionNonBlanks:
					// return "non blanks";
					return "�ǿ�ֵ";

					// = 26
				case GridStringId.CustomFilterDialogConditionLike:
					// return "like";
					return "ƥ��(Like)";

					// = 27
				case GridStringId.CustomFilterDialogConditionNotLike:
					// return "not like";
					return "��ƥ��(Like)";

					// = 28
				case GridStringId.WindowErrorCaption:
					// return "";
					return "";

					// = 29
				case GridStringId.MenuFooterSum:
					// return "Sum";
					return "�ܺ�";

					// = 30
				case GridStringId.MenuFooterMin:
					// return "Min";
					return "��С";

					// = 31
				case GridStringId.MenuFooterMax:
					// return "Max";
					return "���";

					// = 32
				case GridStringId.MenuFooterCount:
					// return "Count";
					return "����";

					// = 33
				case GridStringId.MenuFooterAverage:
					// return "Average";
					return "ƽ��";

					// = 34
				case GridStringId.MenuFooterNone:
					// return "None";
					return "��";

					// = 35
				case GridStringId.MenuFooterSumFormat:
					// return "SUM={0:#.##}";
					return "�ϼ�={0:#.##}";

					// = 36
				case GridStringId.MenuFooterMinFormat:
					// return "MIN={0}";
					return "��С={0}";

					// = 37
				case GridStringId.MenuFooterMaxFormat:
					// return "MAX={0}";
					return "���={0}";

					// = 38
				case GridStringId.MenuFooterCountFormat:
					return "{0}";

					// = 39
				case GridStringId.MenuFooterAverageFormat:
					//return "AVR={0:#.##}";
					return "ƽ��={0:#.##}";

					// = 40
				case GridStringId.MenuColumnSortAscending:
					//return "Sort Ascending";
					return "����";

					// = 41
				case GridStringId.MenuColumnSortDescending:
					// return "Sort Descending";
					return "����";

					// = 42
				case GridStringId.MenuColumnGroup:
					// return "Group By This Column";
					return "�����з���";

					// = 43
				case GridStringId.MenuColumnUnGroup:
					// return "UnGroup";
					return "ȡ������";

					// = 44
				case GridStringId.MenuColumnColumnCustomization:
					// return "Column Chooser";
					return "ѡ����ʾ��";

					// = 45
				case GridStringId.MenuColumnBestFit:
					// return "Best Fit";
					return "�����п�";

					// = 46
				case GridStringId.MenuColumnFilter:
					// return "Can Filter";
					return "��ɸѡ";

					// = 47
				case GridStringId.MenuColumnClearFilter:
					// return "Clear Filter";
					return "���ɸѡ����";

					// = 48
				case GridStringId.MenuColumnBestFitAllColumns:
					// return "Best Fit (all columns)";
					return "���������п�";

					// = 49
				case GridStringId.MenuGroupPanelFullExpand:
					// return "Full Expand";
					return "ȫ��չ��";

					// = 50
				case GridStringId.MenuGroupPanelFullCollapse:
					// return "Full Collapse";
					return "ȫ������";

					// = 51
				case GridStringId.MenuGroupPanelClearGrouping:
					// return "Clear Grouping";
					return "�������";

					// = 52
				case GridStringId.PrintDesignerGridView:
					// return "Print Settings (Grid View)";
					return "��ӡ���� (�����ͼ)";

					// = 53
				case GridStringId.PrintDesignerCardView:
					// return "Print Settings (Card View)";
					return "��ӡ���� (��Ƭ��ͼ)";

					// = 54
				case GridStringId.PrintDesignerBandedView:
					// return "Print Settings (Banded View)";
					return "��ӡ���� (��״��ͼ)";

					// = 55
				case GridStringId.PrintDesignerBandHeader:
					// return "BandHeader";
					return "������";

					// = 56
				case GridStringId.MenuColumnGroupBox:
					// return "Group By Box";
					return "��ʾ������";

					// = 57
				case GridStringId.CardViewNewCard:
					// return "New Card";
					return "�¿�Ƭ";

					// = 58
				case GridStringId.CardViewQuickCustomizationButton:
					// return "Customize";
					return "�Զ����ʽ";

					// = 59
				case GridStringId.CardViewQuickCustomizationButtonFilter:
					// return "Filter";
					return "ɸѡ";

					// = 60
				case GridStringId.CardViewQuickCustomizationButtonSort:
					// return "Sort:";
					return "����:";

					// = 61
				case GridStringId.GridGroupPanelText:
					// return "Drag a column header here to group by that column";
					return "�϶��б��⵽�˽��з���";

					// = 62
				case GridStringId.GridNewRowText:
					// return "Click here to add a new row";
					return "����˴��������";

					// = 63
				case GridStringId.GridOutlookIntervals:
					// return "Older;Last Month;Earlier this Month;Three Weeks Ago;Two Weeks Ago;Last Week;;;;;;;;Yesterday;Today;Tomorrow;;;;;;;;Next Week;Two Weeks Away;Three Weeks Away;Later this Month;Next Month;Beyond Next Month;";
					return "����;�ϸ���;���³�;����ǰ;����ǰ;����;;;;;;;;����;����;����; ;;;;;;;����;���ܺ�;���ܺ�;�¸���;�¸���֮��;";

					// = 64
				case GridStringId.PrintDesignerDescription:
					// return "Set up various printing options for the current view.";
					return "Ϊ��ǰ��ͼ���ô�ӡѡ�";

					// = 65
				case GridStringId.MenuFooterCustomFormat:
					// return "Custom={0}";
					return "�Զ���={0}";

					// = 66
				case GridStringId.MenuFooterCountGroupFormat:
					// return "Count={0}";
					return "����: {0}";

					// = 67
				case GridStringId.MenuColumnClearSorting:
					// return "Clear Sorting";
					return "������";

					// = 68
				case GridStringId.MenuColumnFilterEditor:
					// return "Filter Editor";
					return "�༭ɸѡ����";

					// = 69
				case GridStringId.FilterBuilderOkButton:
					// return "&OK";
					return "ȷ�� (&O)";

					// = 70
				case GridStringId.FilterBuilderCancelButton:
					// return "&Cancel";
					return "ȡ�� (&C)";

					// = 71
				case GridStringId.FilterBuilderApplyButton:
					// return "&Apply";
					return "Ӧ�� (&A)";

					// = 72
				case GridStringId.FilterBuilderCaption:
					// return "Filter Builder";
					return "ɸѡ�����༭��";
			}

			return base.GetLocalizedString(id);
		}

		public override string Language
		{
			get
			{
				return "��������";
			}
		}
	}

	public class XtraLayoutLocalizer : LayoutLocalizer
	{
		public override string GetLocalizedString(LayoutStringId id)
		{
			switch (id)
			{
					// = 0
				case LayoutStringId.CustomizationParentName:
					// return "Customization";
					return "�Զ���";

					// = 1
				case LayoutStringId.DefaultItemText:
					// return "Item ";
					return "��Ŀ";

					// = 2
				case LayoutStringId.DefaultActionText:
					// return "DefaultAction";
					return "Ĭ�Ϸ�ʽ";

					// = 3
				case LayoutStringId.DefaultEmptyText:
					// return "none";
					return "��";

					// = 4
				case LayoutStringId.LayoutItemDescription:
					// return "Layout control item element";
					return "����";

					// = 5
				case LayoutStringId.LayoutGroupDescription:
					// return "Layout control group element";
					return "���ַ���";

					// = 6
				case LayoutStringId.TabbedGroupDescription:
					// return "Layout control tabbedGroup element";
					return "���ֱ�ǩ��";

					// = 7
				case LayoutStringId.LayoutControlDescription:
					// return "Layout control";
					return "���ֿؼ�";

					// = 8
				case LayoutStringId.CustomizationFormTitle:
					// return "Customization";
					return "�Զ��岼��";

					// = 9
				case LayoutStringId.HiddenItemsPageTitle:
					// return "Hidden Items";
					return "���ص���Ŀ";

					// = 10
				case LayoutStringId.TreeViewPageTitle:
					// return "Layout Tree View";
					return "��������ͼ";

					// = 11
				case LayoutStringId.RenameSelected:
					// return "Rename";
					return "������";

					// = 12
				case LayoutStringId.HideItemMenutext:
					// return "Hide Item";
					return "������Ŀ";

					// = 13
				case LayoutStringId.LockItemSizeMenuText:
					// return "Lock Item Size";
					return "������Ŀ��С";

					// = 14
				case LayoutStringId.UnLockItemSizeMenuText:
					// return "UnLock Item Size";
					return "������Ŀ��С";

					// = 15
				case LayoutStringId.GroupItemsMenuText:
					// return "Group";
					return "����";

					// = 16
				case LayoutStringId.UnGroupItemsMenuText:
					// return "Ungroup";
					return "ȡ������";

					// = 17
				case LayoutStringId.CreateTabbedGroupMenuText:
					// return "Create Tab Control";
					return "������ǩ";

					// = 18
				case LayoutStringId.AddTabMenuText:
					// return "Add Tab";
					return "��ӱ�ǩ";

					// = 19
				case LayoutStringId.UnGroupTabbedGroupMenuText:
					// return "Remove Tab Control";
					return "�Ƴ���ǩ";

					// = 20
				case LayoutStringId.TreeViewRootNodeName:
					// return "Root";
					return "��Ŀ¼";

					// = 21
				case LayoutStringId.ShowCustomizationFormMenuText:
					// return "Customize Layout";
					return "�Զ��岼��";

					// = 22
				case LayoutStringId.HideCustomizationFormMenuText:
					// return "Hide Customization Form";
					return "�����Զ��崰��";

					// = 23
				case LayoutStringId.EmptySpaceItemDefaultText:
					// return "Empty Space Item";
					return "�հ���";

					// = 24
				case LayoutStringId.SplitterItemDefaultText:
					// return "Splitter";
					return "�ָ���";

					// = 25
				case LayoutStringId.ControlGroupDefaultText:
					// return "Group ";
					return "�� ";

					// = 26
				case LayoutStringId.EmptyRootGroupText:
					// return "Drop controls here";
					return "�϶�����";

					// = 27
				case LayoutStringId.EmptyTabbedGroupText:
					// return "Drag drop groups into the caption area";
					return "�Ϸŷ��鵽������";

					// = 28
				case LayoutStringId.ResetLayoutMenuText:
					// return "Reset Layout";
					return "��ԭ����";

					// = 29
				case LayoutStringId.RenameMenuText:
					// return "Rename";
					return "������";

					// = 30
				case LayoutStringId.TextPositionMenuText:
					// return "Text Position";
					return "�ı�λ��";

					// = 31
				case LayoutStringId.TextPositionLeftMenuText:
					// return "Left";
					return "��";

					// = 32
				case LayoutStringId.TextPositionRightMenuText:
					// return "Right";
					return "��";

					// = 33
				case LayoutStringId.TextPositionTopMenuText:
					// return "Top";
					return "��";

					// = 34
				case LayoutStringId.TextPositionBottomMenuText:
					// return "Bottom";
					return "��";

					// = 35
				case LayoutStringId.ShowTextMenuItem:
					// return "Show Text";
					return "��ʾ�ı�";

					// = 36
				case LayoutStringId.HideTextMenuItem:
					// return "Hide Text";
					return "�����ı�";

					// = 37
				case LayoutStringId.LockSizeMenuItem:
					// return "Lock Size";
					return "������С";

					// = 38
				case LayoutStringId.LockWidthMenuItem:
					// return "Lock Width";
					return "�������";

					// = 39
				case LayoutStringId.LockHeightMenuItem:
					// return "Lock Height";
					return "�����߶�";

					// = 40
				case LayoutStringId.LockMenuGroup:
					return "";

					// = 41
				case LayoutStringId.ResetConstraintsToDefaultsMenuItem:
					return "";

					// = 42
				case LayoutStringId.FreeSizingMenuItem:
					// return "Free sizing";
					return "�������Ŵ�С";

					// = 43
				case LayoutStringId.CreateEmptySpaceItem:
					// return "Create EmptySpace Item";
					return "��������Ŀ";
			}

			return base.GetLocalizedString(id);
		}

		public override string Language
		{
			get
			{
				return "��������";
			}
		}
	}

	public class XtraNavBarLocalizer : NavBarLocalizer
	{
		public override string GetLocalizedString(NavBarStringId id)
		{
			switch (id)
			{
					// = 0
				case NavBarStringId.NavPaneMenuShowMoreButtons:
					// return "Show &More Buttons";
					return "��ʾ���ఴť (&M)";

					// = 1
				case NavBarStringId.NavPaneMenuShowFewerButtons:
					// return "Show &Fewer Buttons";
					return "��ʾ���ٰ�ť (&F)";

					// = 2
				case NavBarStringId.NavPaneMenuAddRemoveButtons:
					// return "&Add or Remove Buttons";
					return "��ӻ�ɾ����ť (&A)";

					// = 3
				case NavBarStringId.NavPaneChevronHint:
					// return "Configure buttons";
					return "���ð�ť";
			}

			return base.GetLocalizedString(id);
		}

		public override string Language
		{
			get
			{
				return "��������";
			}
		}
	}

    //public class XtraPivotGridLocalizer : PivotGridLocalizer
    //{
    //    public override string GetLocalizedString(PivotGridStringId id)
    //    {
    //        switch (id)
    //        {
    //                // = 0
    //            case PivotGridStringId.RowHeadersCustomization:
    //                // return "Drop Row Fields Here";
    //                return "�϶�������";

    //                // = 1
    //            case PivotGridStringId.ColumnHeadersCustomization:
    //                // return "Drop Column Fields Here";
    //                return "�϶�������";

    //                // = 2
    //            case PivotGridStringId.FilterHeadersCustomization:
    //                // return "Drop Filter Fields Here";
    //                return "�϶�ɸѡ�ֶ�����";

    //                // = 3
    //            case PivotGridStringId.DataHeadersCustomization:
    //                // return "Drop Data Items Here";
    //                return "�϶�����������";

    //                // = 4
    //            case PivotGridStringId.RowArea:
    //                // return "Row Area";
    //                return "����";

    //                // = 5
    //            case PivotGridStringId.ColumnArea:
    //                // return "Column Area";
    //                return "����";

    //                // = 6
    //            case PivotGridStringId.FilterArea:
    //                // return "Filter Area";
    //                return "ɸѡ��";

    //                // = 7
    //            case PivotGridStringId.DataArea:
    //                // return "Data Area";
    //                return "������";

    //                // = 8
    //            case PivotGridStringId.FilterShowAll:
    //                // return "(Show All)";
    //                return "(��ʾȫ��)";

    //                // = 9
    //            case PivotGridStringId.FilterShowBlanks:
    //                // return "Show Blanks";
    //                return "��ʾ�հ�";

    //                // = 10
    //            case PivotGridStringId.CustomizationFormCaption:
    //                // return "PivotGrid Field List";
    //                return "�Զ����ֶ�";

    //                // = 11
    //            case PivotGridStringId.CustomizationFormText:
    //                // return "Drag Items to the PivotGrid";
    //                return "�϶�������";

    //                // = 12
    //            case PivotGridStringId.CustomizationFormAddTo:
    //                // return "Add To";
    //                return "��ӵ�";

    //                // = 13
    //            case PivotGridStringId.Total:
    //                // return "Total";
    //                return "�ϼ�";

    //                // = 14
    //            case PivotGridStringId.GrandTotal:
    //                // return "Grand Total";
    //                return "�ܼ�";

    //                // = 15
    //            case PivotGridStringId.TotalFormat:
    //                // return "{0} Total";
    //                return "{0} �ϼ�";

    //                // = 16
    //            case PivotGridStringId.TotalFormatCount:
    //                // return "{0} Count";
    //                return "{0} ����";

    //                // = 17
    //            case PivotGridStringId.TotalFormatSum:
    //                // return "{0} Sum";
    //                return "{0} �ܺ�";

    //                // = 18
    //            case PivotGridStringId.TotalFormatMin:
    //                // return "{0} Min";
    //                return "{0} ��Сֵ";

    //                // = 19
    //            case PivotGridStringId.TotalFormatMax:
    //                // return "{0} Max";
    //                return "{0} ���ֵ";

    //                // = 20
    //            case PivotGridStringId.TotalFormatAverage:
    //                // return "{0} Average";
    //                return "{0} ƽ��ֵ";

    //                // = 21
    //            case PivotGridStringId.TotalFormatStdDev:
    //                // return "{0} StdDev";
    //                return "{0} ��׼�����";

    //                // = 22
    //            case PivotGridStringId.TotalFormatStdDevp:
    //                // return "{0} StdDevp";
    //                return "{0} ��չ��׼��";

    //                // = 23
    //            case PivotGridStringId.TotalFormatVar:
    //                // return "{0} Var";
    //                return "{0} ����������";

    //                // = 24
    //            case PivotGridStringId.TotalFormatVarp:
    //                // return "{0} Varp";
    //                return "{0} ��չ������";

    //                // = 25
    //            case PivotGridStringId.TotalFormatCustom:
    //                // return "{0} Custom";
    //                return "{0} �Զ���";

    //                // = 26
    //            case PivotGridStringId.PrintDesignerPageOptions:
    //                // return "Options";
    //                return "ѡ��";

    //                // = 27
    //            case PivotGridStringId.PrintDesignerPageBehavior:
    //                // return "Behavior";
    //                return "״̬";

    //                // = 28
    //            case PivotGridStringId.PrintDesignerCategoryDefault:
    //                // return "Default";
    //                return "Ĭ��";

    //                // = 29
    //            case PivotGridStringId.PrintDesignerCategoryLines:
    //                // return "Lines";
    //                return "��";

    //                // = 30
    //            case PivotGridStringId.PrintDesignerCategoryHeaders:
    //                // return "Headers";
    //                return "����";

    //                // = 31
    //            case PivotGridStringId.PrintDesignerHorizontalLines:
    //                // return "Horizontal Lines";
    //                return "ˮƽ��";

    //                // = 32
    //            case PivotGridStringId.PrintDesignerVerticalLines:
    //                // return "Vertical Lines";
    //                return "��ֱ��";

    //                // = 33
    //            case PivotGridStringId.PrintDesignerFilterHeaders:
    //                // return "Filter Headers";
    //                return "ɸѡ����";

    //                // = 34
    //            case PivotGridStringId.PrintDesignerDataHeaders:
    //                // return "Data Headers";
    //                return "���ݱ���";

    //                // = 35
    //            case PivotGridStringId.PrintDesignerColumnHeaders:
    //                // return "Column Headers";
    //                return "�б���";

    //                // = 36
    //            case PivotGridStringId.PrintDesignerRowHeaders:
    //                // return "Row Headers";
    //                return "�б���";

    //                // = 37
    //            case PivotGridStringId.PrintDesignerUsePrintAppearance:
    //                // return "Use Print Appearance";
    //                return "ʹ�ô�ӡ���";

    //                // = 38
    //            case PivotGridStringId.PopupMenuRefreshData:
    //                // return "Refresh Data";
    //                return "ˢ������";

    //                // = 39
    //            case PivotGridStringId.PopupMenuHideField:
    //                // return "Hide";
    //                return "����";

    //                // = 40
    //            case PivotGridStringId.PopupMenuShowFieldList:
    //                // return "Show Field List";
    //                return "��ʾ�Զ����ֶο�";

    //                // = 41
    //            case PivotGridStringId.PopupMenuHideFieldList:
    //                // return "Hide Field List";
    //                return "�����Զ����ֶο�";

    //                // = 42
    //            case PivotGridStringId.PopupMenuFieldOrder:
    //                // return "Order";
    //                return "˳��";

    //                // = 43
    //            case PivotGridStringId.PopupMenuMovetoBeginning:
    //                // return "Move to Beginning";
    //                return "��������";

    //                // = 44
    //            case PivotGridStringId.PopupMenuMovetoLeft:
    //                // return "Move to Left";
    //                return "����";

    //                // = 45
    //            case PivotGridStringId.PopupMenuMovetoRight:
    //                // return "Move to Right";
    //                return "����";

    //                // = 46
    //            case PivotGridStringId.PopupMenuMovetoEnd:
    //                // return "Move to End";
    //                return "��������";

    //                // = 47
    //            case PivotGridStringId.PopupMenuCollapse:
    //                // return "Collapse";
    //                return "����";

    //                // = 48
    //            case PivotGridStringId.PopupMenuExpand:
    //                // return "Expand";
    //                return "չ��";

    //                // = 49
    //            case PivotGridStringId.PopupMenuCollapseAll:
    //                // return "Collapse All";
    //                return "ȫ������";

    //                // = 50
    //            case PivotGridStringId.PopupMenuExpandAll:
    //                // return "Expand All";
    //                return "ȫ��չ��";

    //                // = 51
    //            case PivotGridStringId.DataFieldCaption:
    //                // return "Data";
    //                return "����";

    //                // = 52
    //            case PivotGridStringId.TopValueOthersRow:
    //                // return "Others";
    //                return "����";
    //        }

    //        return base.GetLocalizedString(id);
    //    }

    //    public override string Language
    //    {
    //        get
    //        {
    //            return "��������";
    //        }
    //    }
    //}

	public class XtraPrintingLocalizer : PreviewLocalizer
	{
		public override string GetLocalizedString(PreviewStringId id)
		{
			switch (id)
			{
					// = 0
				case PreviewStringId.Button_Cancel:
					return "ȡ��";

					// = 1
				case PreviewStringId.Button_Ok:
					return "ȷ��";

					// = 2
				case PreviewStringId.Button_Help:
					return "����";

					// = 3
				case PreviewStringId.Button_Apply:
					return "Ӧ��";

					// = 4
				case PreviewStringId.PPF_Preview_Caption:
					return "";

					// = 5
				case PreviewStringId.PreviewForm_Caption:
					return "Ԥ��";

					// = 6
				case PreviewStringId.TB_CustomizeBtn_ToolTip:
					return "";

					// = 7
				case PreviewStringId.TB_TTip_Customize:
					return "�Զ���";

					// = 8
				case PreviewStringId.TB_PrintBtn_ToolTip:
					return "";

					// = 9
				case PreviewStringId.TB_TTip_Print:
					return "��ӡ";

					// = 10
				case PreviewStringId.TB_PrintDirectBtn_ToolTip:
					return "";

					// = 11
				case PreviewStringId.TB_TTip_PrintDirect:
					return "ֱ�Ӵ�ӡ";

					// = 12
				case PreviewStringId.TB_PageSetupBtn_ToolTip:
					return "";

					// = 13
				case PreviewStringId.TB_TTip_PageSetup:
					return "ҳ������";

					// = 14
				case PreviewStringId.TB_MagnifierBtn_ToolTip:
					return "";

					// = 15
				case PreviewStringId.TB_TTip_Magnifier:
					return "�Ŵ�";

					// = 16
				case PreviewStringId.TB_ZoomInBtn_ToolTip:
					return "";

					// = 17
				case PreviewStringId.TB_TTip_ZoomIn:
					return "�Ŵ�";

					// = 18
				case PreviewStringId.TB_ZoomOutBtn_ToolTip:
					return "";

					// = 19
				case PreviewStringId.TB_TTip_ZoomOut:
					return "��С";

					// = 20
				case PreviewStringId.TB_ZoomBtn_ToolTip:
					return "";

					// = 21
				case PreviewStringId.TB_TTip_Zoom:
					return "����";

					// = 22
				case PreviewStringId.TB_SearchBtn_ToolTip:
					return "";

					// = 23
				case PreviewStringId.TB_TTip_Search:
					return "����";

					// = 24
				case PreviewStringId.TB_FirstPageBtn_ToolTip:
					return "";

					// = 25
				case PreviewStringId.TB_TTip_FirstPage:
					return "��һҳ";

					// = 26
				case PreviewStringId.TB_PreviousPageBtn_ToolTip:
					return "";

					// = 27
				case PreviewStringId.TB_TTip_PreviousPage:
					return "��һҳ";

					// = 28
				case PreviewStringId.TB_NextPageBtn_ToolTip:
					return "";

					// = 29
				case PreviewStringId.TB_TTip_NextPage:
					return "��һҳ";

					// = 30
				case PreviewStringId.TB_LastPageBtn_ToolTip:
					return "";

					// = 31
				case PreviewStringId.TB_TTip_LastPage:
					return "���һҳ";

					// = 32
				case PreviewStringId.TB_MultiplePagesBtn_ToolTip:
					return "";

					// = 33
				case PreviewStringId.TB_TTip_MultiplePages:
					return "��ҳ";

					// = 34
				case PreviewStringId.TB_BackGroundBtn_ToolTip:
					return "";

					// = 35
				case PreviewStringId.TB_TTip_Backgr:
					return "����ɫ";

					// = 36
				case PreviewStringId.TB_ClosePreviewBtn_ToolTip:
					return "";

					// = 37
				case PreviewStringId.TB_TTip_Close:
					return "�˳�Ԥ��";

					// = 38
				case PreviewStringId.TB_EditPageHFBtn_ToolTip:
					return "";

					// = 39
				case PreviewStringId.TB_TTip_EditPageHF:
					return "ҳüҳ��";

					// = 40
				case PreviewStringId.TB_HandToolBtn_ToolTip:
					return "";

					// = 41
				case PreviewStringId.TB_TTip_HandTool:
					return "���ι���";

					// = 42
				case PreviewStringId.TB_ExportBtn_ToolTip:
					return "";

					// = 43
				case PreviewStringId.TB_TTip_Export:
					return "�����ĵ�...";

					// = 44
				case PreviewStringId.TB_SendBtn_ToolTip:
					return "";

					// = 45
				case PreviewStringId.TB_TTip_Send:
					return "���� E-Mail...";

					// = 46
				case PreviewStringId.TB_DocMap_ToolTip:
					return "";

					// = 47xxxx
				case PreviewStringId.TB_TTip_Map:
					//return "Document Map";
					return "�ĵ��ṹ";

					// = 48
				case PreviewStringId.TB_Watermark_ToolTip:
					return "";

					// = 49
				case PreviewStringId.TB_TTip_Watermark:
					return "ˮӡ";

					// = 50
				case PreviewStringId.barExport_PDF_Document:
					return "";

					// = 51
				case PreviewStringId.MenuItem_PdfDocument:
					return "PDF�ĵ�";

					// = 52
				case PreviewStringId.MenuItem_PageLayout:
					return "ҳ����ʾ (&P)";

					// = 53
				case PreviewStringId.barExport_Text_Document:
					return "";

					// = 54
				case PreviewStringId.MenuItem_TxtDocument:
					return "Text�ĵ�";

					// = 55
				case PreviewStringId.MenuItem_GraphicDocument:
					return "ͼ���ļ�";

					// = 56
				case PreviewStringId.barExport_CSV_Document:
					return "";

					// = 57
				case PreviewStringId.MenuItem_CsvDocument:
					return "CSV�ĵ�";

					// = 58
				case PreviewStringId.barExport_MHT_Document:
					return "";

					// = 59
				case PreviewStringId.MenuItem_MhtDocument:
					return "MHT�ĵ�";

					// = 60
				case PreviewStringId.barExport_Excel_Document:
					return "";

					// = 61
				case PreviewStringId.MenuItem_XlsDocument:
					return "Excel�ĵ�";

					// = 62
				case PreviewStringId.barExport_RichTextDocument:
					return "";

					// = 63
				case PreviewStringId.MenuItem_RtfDocument:
					return "RTF�ĵ�";

					// = 64
				case PreviewStringId.barExport_HTMLDocument:
					return "";

					// = 65
				case PreviewStringId.MenuItem_HtmDocument:
					return "HTML�ĵ�";

					// = 66
				case PreviewStringId.barExport_BMP:
					return "";

					// = 67
				case PreviewStringId.SaveDlg_FilterBmp:
					return "BMP λͼ��ʽ";

					// = 68
				case PreviewStringId.barExport_GIF:
					return "";

					// = 69
				case PreviewStringId.SaveDlg_FilterGif:
					return "GIF ͼ�ν�����ʽ";

					// = 70
				case PreviewStringId.barExport_JPEG:
					return "";

					// = 71
				case PreviewStringId.SaveDlg_FilterJpeg:
					return "JPEG �ļ�������ʽ";

					// = 72
				case PreviewStringId.barExport_PNG:
					return "";

					// = 73
				case PreviewStringId.SaveDlg_FilterPng:
					return "PNG ����ֲ����ͼ��";

					// = 74
				case PreviewStringId.barExport_TIFF:
					return "";

					// = 75
				case PreviewStringId.SaveDlg_FilterTiff:
					return "TIFF Tagͼ���ļ���ʽ";

					// = 76
				case PreviewStringId.barExport_EMF:
					return "";

					// = 77
				case PreviewStringId.SaveDlg_FilterEmf:
					return "EMF Windows��ǿ��ͼԪ�ļ�";

					// = 78
				case PreviewStringId.barExport_WMF:
					return "";

					// = 79
				case PreviewStringId.SaveDlg_FilterWmf:
					return "WMF WindowsͼԪ�ļ�";

					// = 80
				case PreviewStringId.SB_TotalPageNo:
					return "��ҳ��:";

					// = 81
				case PreviewStringId.SB_CurrentPageNo:
					return "��ǰҳ:";

					// = 82
				case PreviewStringId.SB_ZoomFactor:
					return "���ű���:";

					// = 83
				case PreviewStringId.SB_PageNone:
					return "��";

					// = 84
				case PreviewStringId.SB_PageInfo_OF:
					return "";

					// = 85
				case PreviewStringId.SB_PageInfo:
					return "��{0}ҳ ��{1}ҳ";

					// = 86
				case PreviewStringId.PCE_PageContentEditor_Caption:
					return "";

					// = 87
				case PreviewStringId.PCE_PageNumber_ToolTip:
					return "";

					// = 88
				case PreviewStringId.PCE_PageOfPages_ToolTip:
					return "";

					// = 89
				case PreviewStringId.PCE_DatePrinted_ToolTip:
					return "";

					// = 90
				case PreviewStringId.PCE_TimePrinted_ToolTip:
					return "";

					// = 91
				case PreviewStringId.PCE_UserName_ToolTip:
					return "";

					// = 92
				case PreviewStringId.PCE_Image_ToolTip:
					return "";

					// = 93
				case PreviewStringId.PCE_FontButton:
					return "";

					// = 94
				case PreviewStringId.PCE_FooterLabel:
					return "";

					// = 95
				case PreviewStringId.PCE_HeaderLabel:
					return "";

					// = 96
				case PreviewStringId.PCE_AlignTops_ToolTip:
					return "";

					// = 97
				case PreviewStringId.PCE_AlignMiddles_ToolTip:
					return "";

					// = 98
				case PreviewStringId.PCE_AlignBottoms_ToolTip:
					return "";

					// = 99
				case PreviewStringId.MPE_PagesLabel:
					return "";

					// = 100xxxx
				case PreviewStringId.MPForm_Lbl_Pages:
					// return "Pages";
					return "ҳ��";

					// = 101
				case PreviewStringId.Msg_EmptyDocument:
					return "�ĵ�û��ҳ�档";

					// = 102
				case PreviewStringId.Msg_CreatingDocument:
					return "���ڴ����ĵ�...";

					// = 103
				case PreviewStringId.Msg_UnavailableNetPrinter:
					return "�����ӡ�������á�";

					// = 104
				case PreviewStringId.Msg_NeedPrinter:
					return "û�а�װ��ӡ����";

					// = 105
				case PreviewStringId.Msg_WrongPrinter:
					// return "The printer name is invalid. Please check the printer settings.";
					return "��Ч�Ĵ�ӡ�����ơ������ӡ���������Ƿ���ȷ��";

					// = 106
				case PreviewStringId.Msg_WrongPageSettings:
					// return "The current printer doesn't support the selected paper size.\r\nProceed with printing anyway?";
					return "��ӡ����֧����ѡ��ֽ�Ŵ�С��\r\n�Ƿ������ӡ��";

					// = 107
				case PreviewStringId.Msg_CustomDrawWarning:
					// return "Warning!";
					return "���棡";

					// = 108
				case PreviewStringId.Msg_PageMarginsWarning:
					//return "One or more margins are set outside the printable area of the page. Continue?";
					return "һ�������ϵı߽糬���˴�ӡ��Χ���Ƿ������";

					// = 109
				case PreviewStringId.Msg_IncorrectPageRange:
					//return "This is not a valid page range";
					return "��Ч��ҳ�뷶Χ�߽硣";

					// = 110
				case PreviewStringId.Msg_FontInvalidNumber:
					// return "The font size cannot be set to zero or a negative number";
					return "�����С����Ϊ0����";

					// = 111
				case PreviewStringId.Msg_NotSupportedFont:
					// return "This font is not yet supported";
					return "��֧�ֵ�����";

					// = 112
				case PreviewStringId.Msg_IncorrectZoomFactor:
					// return "The number must be beetween {0} and {1}.";
					return "���ֱ����� {0} �� {1} ֮�䡣";

					// = 113
				case PreviewStringId.Msg_InvalidMeasurement:
					// return "This is not a valid measurement.";
					return "��Ч�Ĺ淶";

					// = 114
				case PreviewStringId.Msg_CannotAccessFile:
					// return "The process cannot access the file \"{0}\" because it is being used by another process.";
					return "��ǰ�����޷������ļ�\"{0}\"����Ϊ��������������ʹ�á�";

					// = 115
				case PreviewStringId.Margin_Inch:
					return "Ӣ��";

					// = 116
				case PreviewStringId.Margin_Millimeter:
					return "����";

					// = 117
				case PreviewStringId.Margin_TopMargin:
					// return"Top Margin";
					return "�ϱ߾�";

					// = 118
				case PreviewStringId.Margin_BottomMargin:
					// return"Bottom Margin";
					return "�±߾�";

					// = 119
				case PreviewStringId.Margin_LeftMargin:
					// return"Left Margin";
					return "��߾�";

					// = 120
				case PreviewStringId.Margin_RightMargin:
					// return"Right Margin";
					return "�ұ߾�";

					// = 121
				case PreviewStringId.Page_Scroll:
					return "";

					// = 122
				case PreviewStringId.ScrollingInfo_Page:
					return "ҳ";

					// = 123
				case PreviewStringId.WMForm_PictureDlg_Title:
					return "ѡ��ͼƬ";

					// = 124
				case PreviewStringId.WMForm_ImageStretch:
					// return "Stretch";
					return "����";

					// = 125
				case PreviewStringId.WMForm_ImageClip:
					return "�޼�";

					// = 126
				case PreviewStringId.WMForm_ImageZoom:
					return "����";

					// = 127
				case PreviewStringId.WMForm_Watermark_Asap:
					// return"ASAP";
					return "����";

					// = 128
				case PreviewStringId.WMForm_Watermark_Confidential:
					// return"CONFIDENTIAL";
					return "����";

					// = 129
				case PreviewStringId.WMForm_Watermark_Copy:
					// return"COPY";
					return "����";

					// = 130
				case PreviewStringId.WMForm_Watermark_DoNotCopy:
					// return"DO NOT COPY";
					return "�Ͻ�����";

					// = 131
				case PreviewStringId.WMForm_Watermark_Draft:
					// return"DRAFT";
					return "�ݸ�";

					// = 132
				case PreviewStringId.WMForm_Watermark_Evaluation:
					// return"EVALUATION";
					return "����";

					// = 133
				case PreviewStringId.WMForm_Watermark_Original:
					// return"ORIGINAL";
					return "ԭʼ";

					// = 134
				case PreviewStringId.WMForm_Watermark_Personal:
					// return"PERSONAL";
					return "˽��";

					// = 135
				case PreviewStringId.WMForm_Watermark_Sample:
					// return"SAMPLE";
					return "��Ʒ";

					// = 136
				case PreviewStringId.WMForm_Watermark_TopSecret:
					// return"TOP SECRET";
					return "����";

					// = 137
				case PreviewStringId.WMForm_Watermark_Urgent:
					// return"URGENT";
					return "����";

					// = 138
				case PreviewStringId.WMForm_Direction_Horizontal:
					return "����";

					// = 139
				case PreviewStringId.WMForm_Direction_Vertical:
					return "����";

					// = 140
				case PreviewStringId.WMForm_Direction_BackwardDiagonal:
					return "�ԽǷ���";

					// = 141
				case PreviewStringId.WMForm_Direction_ForwardDiagonal:
					return "���ԽǷ���";

					// = 142
				case PreviewStringId.WMForm_VertAlign_Bottom:
					return "�õ�";

					// = 143
				case PreviewStringId.WMForm_VertAlign_Middle:
					return "��ֱ����";

					// = 144
				case PreviewStringId.WMForm_VertAlign_Top:
					return "�ö�";

					// = 145
				case PreviewStringId.WMForm_HorzAlign_Left:
					return "����";

					// = 146
				case PreviewStringId.WMForm_HorzAlign_Center:
					return "ˮƽ����";

					// = 147
				case PreviewStringId.WMForm_HorzAlign_Right:
					return "����";

					// = 148
				case PreviewStringId.WMForm_ZOrderRgrItem_InFront:
					return "���ڶ��� (&F)";

					// = 149
				case PreviewStringId.WMForm_ZOrderRgrItem_Behind:
					return "���ڵײ� (&B)";

					// = 150
				case PreviewStringId.WMForm_PageRangeRgrItem_All:
					return "ȫ�� (&A)";

					// = 151
				case PreviewStringId.WMForm_PageRangeRgrItem_Pages:
					return "ҳ�� (&P):";

					// = 152
				case PreviewStringId.dlgSaveAs:
					return "";

					// = 153
				case PreviewStringId.SaveDlg_Title:
					return "���Ϊ";

					// = 154
				case PreviewStringId.SaveDlg_FilterPdf:
					return "PDF�ĵ�";

					// = 155
				case PreviewStringId.SaveDlg_FilterTxt:
					return "Text�ĵ�";

					// = 156
				case PreviewStringId.SaveDlg_FilterCsv:
					return "CSV�ĵ�";

					// = 157
				case PreviewStringId.SaveDlg_FilterMht:
					return "MHT�ĵ�";

					// = 158
				case PreviewStringId.SaveDlg_FilterXls:
					return "Excel�ĵ�";

					// = 159
				case PreviewStringId.SaveDlg_FilterRtf:
					return "RTF�ĵ�";

					// = 160
				case PreviewStringId.SaveDlg_FilterHtm:
					return "HTML�ĵ�";

					// = 161
				case PreviewStringId.MenuItem_File:
					return "�ļ� (&F)";

					// = 162
				case PreviewStringId.MenuItem_View:
					return "��ͼ (&V)";

					// = 163
				case PreviewStringId.MenuItem_Background:
					return "���� (&B)";

					// = 164
				case PreviewStringId.MenuItem_PageSetup:
					return "ҳ������ (&U)";

					// = 165
				case PreviewStringId.MenuItem_Print:
					return "��ӡ (&P)...";

					// = 166
				case PreviewStringId.MenuItem_PrintDirect:
					return "ֱ�Ӵ�ӡ (&R)";

					// = 167
				case PreviewStringId.MenuItem_Export:
					return "���� (&E)";

					// = 168
				case PreviewStringId.MenuItem_Send:
					return "���� (&D)";

					// = 169
				case PreviewStringId.MenuItem_Exit:
					return "�˳� (&X)";

					// = 170
				case PreviewStringId.MenuItem_ViewToolbar:
					return "������ (&T)";

					// = 171
				case PreviewStringId.MenuItem_ViewStatusbar:
					return "״̬�� (&S)";

					// = 172
				case PreviewStringId.MenuItem_ViewContinuous:
					// return "&Continuous";
					return "����";

					// = 173
				case PreviewStringId.MenuItem_ViewFacing:
					//return "&Facing";
					return "��ҳ";

					// = 174
				case PreviewStringId.MenuItem_BackgrColor:
					return "��ɫ (&C)...";

					// = 175
				case PreviewStringId.MenuItem_Watermark:
					return "ˮӡ (&W)...";

					// = 176
				case PreviewStringId.MenuItem_ZoomPageWidth:
					// return "Page Width";
					return "ҳ��";

					// = 177
				case PreviewStringId.MenuItem_ZoomTextWidth:
					// return "Text Width";
					return "���ֿ��";

					// = 178
				case PreviewStringId.MenuItem_ZoomWholePage:
					// return "Whole Page";
					return "��ҳ";

					// = 179
				case PreviewStringId.MenuItem_ZoomTwoPages:
					// return "Two Pages";
					return "˫ҳ";

					// = 180
				case PreviewStringId.PageInfo_PageNumber:
					// return "[Page #]";
					return "[ҳ��]";

					// = 181
				case PreviewStringId.PageInfo_PageNumberOfTotal:
					// return "[Page # of Pages #]";
					return "[��ǰҳ�� ��ҳ��]";

					// = 182
				case PreviewStringId.PageInfo_PageDate:
					// return "[Date Printed]";
					return "[��ӡ����]";

					// = 183
				case PreviewStringId.PageInfo_PageTime:
					// return "[Time Printed]";
					return "[��ӡʱ��]";

					// = 184
				case PreviewStringId.PageInfo_PageUserName:
					// return "[User Name]";
					return "[��ӡ��]";

					// = 185
				case PreviewStringId.dlgSendFrom:
					return "";

					// = 186
				case PreviewStringId.EMail_From:
					// return "From";
					return "�ĵ�������";

					// = 187
				case PreviewStringId.BarText_Toolbar:
					return "������";

					// = 188
				case PreviewStringId.BarText_MainMenu:
					return "���˵�";

					// = 189
				case PreviewStringId.BarText_StatusBar:
					return "״̬��";
			}

			return base.GetLocalizedString(id);
		}

		public override string Language
		{
			get
			{
				return "��������";
			}
		} 

	}

	public class XtraReportsLocalizer : ReportLocalizer
	{
		public override string GetLocalizedString(ReportStringId id)
		{
			switch (id)
			{
					// = 0
				case ReportStringId.Msg_FileNotFound:
					// return "File not found.";
					return "�ļ�û���ҵ���";

					// = 1
				case ReportStringId.Msg_WrongReportClassName:
					// return "An error occurred during deserialization - possible wrong report class name";
					return "�����л�ʱ������ - �����Ǵ���ı�������";

					// = 2
				case ReportStringId.Msg_CreateReportInstance:
					// return "The report currently being edited is of a different type than the one you are trying to open.\r\nDo you want to open the selected report anyway?";
					return "����ͼ�򿪵ı��������뵱ǰ�༭�ı������Ͳ���ͬ��\r\n�Ƿ�ȷ��Ҫ�򿪸ñ���";

					// = 3
				case ReportStringId.Msg_FileCorrupted:
					// return "Can't load the report. The file is possibly corrupted or report's assembly is missing.";
					return "���ܼ��ر����ļ��������𻵻򱨱������ʧ��";

					// = 4
				case ReportStringId.Msg_FileContentCorrupted:
					// return "Can't load the report's layout. The file is possibly corrupted or contains incorrect information.";
					return "���ܼ��ر����֣��ļ��������𻵻��������ȷ����Ϣ��";

					// = 5
				case ReportStringId.Msg_IncorrectArgument:
					// return "Incorrect argument's value";
					return "����ȷ�Ĳ���ֵ";

					// = 6
				case ReportStringId.Msg_InvalidMethodCall:
					// return "This method call is invalid for the object's current state";
					return "����ĵ�ǰ״̬�´˷����ĵ�����Ч";

					// = 7
				case ReportStringId.Msg_ScriptError:
					// return "There are following errors in script(s):\r\n{0}";
					return "�ű��г������´���\r\n{0}";

					// = 8
				case ReportStringId.Msg_ScriptExecutionError:
					// return "The following error occurred when the script in procedure {0}:\r\n {1}\r\nProcedure {0} was executed, it will not be called again.";
					return "ִ�нű�ʱ�������� {0}:\r\n {1}\r\n���� {0} ��ִ�У����ܱ��ٴε��á�";

					// = 9xxx
				case ReportStringId.Msg_InvalidReportSource:
					// return "Can not be set to a descendant of the current report";
					return "��������Ϊ��ǰ���������";

					// = 10xxxx
				case ReportStringId.Msg_IncorrectBandType:
					// return "Incorrect band type";
					return "����ȷ��Band����";

					// = 11
				case ReportStringId.Msg_InvPropName:
					// return "Invalid property name";
					return "��Ч��������";

					// = 12
				case ReportStringId.Msg_CantFitBarcodeToControlBounds:
					// return "Control's boundaries are too small for the barcode";
					return "������ؼ��ı߽�̫С";

					// = 13
				case ReportStringId.Msg_InvalidBarcodeText:
					// return "There are invalid characters in the text";
					return "�ı��г�����Ч�ַ�";

					// = 14
				case ReportStringId.Msg_InvalidBarcodeTextFormat:
					// return "Invalid text format";
					return "��Ч���ı���ʽ";

					// = 15
				case ReportStringId.Msg_CreateSomeInstance:
					// return "Can't create two instances of a class on a form";
					return "�ڴ����в��ܴ���ͬһ���������ʵ����";

					// = 16
				case ReportStringId.Msg_DontSupportMulticolumn:
					// return "Detail reports don't support multicolumn.";
					return "��ϸ����֧�ֶ��ֶΡ�";

					// = 17
				case ReportStringId.Msg_FillDataError:
					// return "Error when trying to populate the datasource. The following exception was thrown:";
					return "��ͼ��������ʱ���������׳������쳣��";

					// = 18
				case ReportStringId.Msg_CyclicBoormarks:
					// return "There are cyclic bookmarks in the report.";
					return "�����г���ѭ����ǩ��";

					// = 19
				case ReportStringId.Msg_LargeText:
					// return "Text is too large.";
					return "�ı�̫��";

					// = 20
				case ReportStringId.Msg_ScriptingPermissionErrorMessage:
					// return "You don't have sufficient permission to execute the scripts in this report.\r\n\r\nDetails:\r\n\r\n{0}";
					return "û���㹻��Ȩ��ִ�нű���\r\n\r\n��ϸ��\r\n\r\n{0}";

					// = 21
				case ReportStringId.Msg_ReportImporting:
					// return "Importing a report layout. Please, wait...";
					return "���ڵ��뱨���֣����Ժ�...";

					// = 22
				case ReportStringId.Msg_IncorrectPadding:
					// return "The padding should be greater than or equal to 0";
					return "�ĵ�Ӧ���ڵ���0";

					// = 23
				case ReportStringId.Msg_WarningControlsAreOverlapped:
					// return "Export warning: The following controls are overlapped and may be exported to HTML, XLS and RTF incorrectly - {0}.";
					return "�������棺���¿ؼ������ص������ܲ�����ȷ�ص���ΪHTML��XLS��RTF - {0}��";

					// = 24
				case ReportStringId.Msg_WarningControlsAreOutOfMargin:
					// return "Printing warning: The following controls are outside the right page margin, and this will cause extra pages to be printed - {0}.";
					return "��ӡ���棺���¿ؼ�����ҳ����ұ߽磬����Ҫ�����ֽ������ɴ�ӡ - {0}��";

					// = 25
				case ReportStringId.Msg_ShapeRotationToolTip:
					// return "Use Ctrl with the left mouse button to rotate the shape";
					return "���������������ת��";

					// = 26
				case ReportStringId.Msg_ScriptingErrorTitle:
					return "";

					// = 27
				case ReportStringId.Msg_ErrorTitle:
					// return "Error";
					return "����";

					// = 28
				case ReportStringId.Msg_SerializationErrorTitle:
					// return "Serialization Error";
					return "���л�����";

					// = 29
				case ReportStringId.Cmd_InsertDetailReport:
					// return "Insert Detail Report";
					return "������ϸ����";

					// = 30
				case ReportStringId.Cmd_InsertUnboundDetailReport:
					// return "Unbound";
					return "�ǰ�";

					// = 31
				case ReportStringId.Cmd_ViewCode:
					// return "View &Code";
					return "��ͼ���� (&C)";

					// = 32
				case ReportStringId.Cmd_BringToFront:
					// return "&Bring To Front";
					return "���ڶ��� (&B)";

					// = 33
				case ReportStringId.Cmd_SendToBack:
					// return "&Send To Back";
					return "���ڵײ� (&S)";

					// = 34
				case ReportStringId.Cmd_AlignToGrid:
					// return "Align To &Grid";
					return "���뵽���� (&G)";

					// = 35
				case ReportStringId.Cmd_TopMargin:
					// return "TopMargin";
					return "���˿հ�";

					// = 36
				case ReportStringId.Cmd_BottomMargin:
					// return "BottomMargin";
					return "�׶˿հ�";

					// = 37
				case ReportStringId.Cmd_ReportHeader:
					// return "ReportHeader";
					return "����β";

					// = 38
				case ReportStringId.Cmd_ReportFooter:
					// return "ReportFooter";
					return "����β";

					// = 39
				case ReportStringId.Cmd_PageHeader:
					// return "PageHeader";
					return "ҳ��";

					// = 40
				case ReportStringId.Cmd_PageFooter:
					// return "PageFooter";
					return "ҳβ";

					// = 41
				case ReportStringId.Cmd_GroupHeader:
					// return "GroupHeader";
					return "Ⱥ����";

					// = 42
				case ReportStringId.Cmd_GroupFooter:
					// return "GroupFooter";
					return "Ⱥ��β";

					// = 43
				case ReportStringId.Cmd_Detail:
					// return "Detail";
					return "��ϸ";

					// = 44
				case ReportStringId.Cmd_DetailReport:
					// return "DetailReport";
					return "��ϸ����";

					// = 45
				case ReportStringId.Cmd_RtfClear:
					// return "Clear";
					return "���";

					// = 46
				case ReportStringId.Cmd_RtfLoad:
					// return "Load File...";
					return "�����ļ�...";

					// = 47
				case ReportStringId.Cmd_TableInsert:
					// return "&Insert";
					return "���� (&I)";

					// = 48
				case ReportStringId.Cmd_TableInsertRowAbove:
					// return "Row &Above";
					return "���� (&A)";

					// = 49
				case ReportStringId.Cmd_TableInsertRowBelow:
					// return "Row &Below";
					return "���� (&B)";

					// = 50
				case ReportStringId.Cmd_TableInsertColumnToLeft:
					// return "Column To &Left";
					return "���� (&L)";

					// = 51
				case ReportStringId.Cmd_TableInsertColumnToRight:
					// return "Column To &Right";
					return "���� (&R)";

					// = 52
				case ReportStringId.Cmd_TableInsertCell:
					// return "&Cell";
					return "��Ԫ�� (&C)";

					// = 53
				case ReportStringId.Cmd_TableDelete:
					// return "De&lete";
					return "ɾ�� (&L)";

					// = 54
				case ReportStringId.Cmd_TableDeleteRow:
					// return "&Row";
					return "�� (&R)";

					// = 55
				case ReportStringId.Cmd_TableDeleteColumn:
					// return "&Column";
					return "�� (&C)";

					// = 56
				case ReportStringId.Cmd_TableDeleteCell:
					// return "Ce&ll";
					return "��Ԫ�� (&L)";

					// = 57
				case ReportStringId.Cmd_Cut:
					// return "Cu&t";
					return "���� (&T)";

					// = 58
				case ReportStringId.Cmd_Copy:
					// return "Cop&y";
					return "���� (&Y)";

					// = 59
				case ReportStringId.Cmd_Paste:
					// return "&Paste";
					return "ճ�� (&P)";

					// = 60
				case ReportStringId.Cmd_Delete:
					// return "&Delete";
					return "ɾ�� (&D)";

					// = 61
				case ReportStringId.Cmd_Properties:
					// return "P&roperties";
					return "���� (&P)";

					// = 62
				case ReportStringId.Cmd_InsertBand:
					// return "Insert &Band";
					return "����Band (&B)";

					// = 63
				case ReportStringId.CatLayout:
					// return "Layout";
					return "����";

					// = 64
				case ReportStringId.CatAppearance:
					// return "Appearance";
					return "���";

					// = 65
				case ReportStringId.CatData:
					// return "Data";
					return "����";

					// = 66xxxx
				case ReportStringId.CatBehavior:
					// return "Behavior";
					return "״̬";

					// = 67
				case ReportStringId.CatNavigation:
					// return "Navigation";
					return "����";

					// = 68
				case ReportStringId.CatPageSettings:
					// return "PageSettings";
					return "ҳ������";

					// = 69
				case ReportStringId.CatUserDesigner:
					// return "UserDesigner";
					return "�û����";

					// = 70
				case ReportStringId.BandDsg_QuantityPerPage:
					// return "one band per page";
					return "ҳ���Band";

					// = 71
				case ReportStringId.BandDsg_QuantityPerReport:
					// return "one band per report";
					return "�����Band";

					// = 72
				case ReportStringId.UD_ReportDesigner:
					// return "Report Designer";
					return "���������";

					// = 73
				case ReportStringId.UD_Msg_ReportChanged:
					// return "Report has been changed. Do you want to save changes ?";
					return "����������ѱ��޸ģ��Ƿ񱣴���ģ�";

					// = 74
				case ReportStringId.UD_TTip_FileOpen:
					// return "Open File";
					return "���ļ�";

					// = 75
				case ReportStringId.UD_TTip_FileSave:
					// return "Save File";
					return "�����ļ�";

					// = 76
				case ReportStringId.UD_TTip_EditCut:
					// return "Cut";
					return "����";

					// = 77
				case ReportStringId.UD_TTip_EditCopy:
					// return "Copy";
					return "����";

					// = 78
				case ReportStringId.UD_TTip_EditPaste:
					// return "Paste";
					return "ճ��";

					// = 79
				case ReportStringId.UD_TTip_Undo:
					// return "Undo";
					return "����";

					// = 80
				case ReportStringId.UD_TTip_Redo:
					// return "Redo";
					return "�ظ�";

					// = 81
				case ReportStringId.UD_TTip_AlignToGrid:
					// return "Align to Grid";
					return "���뵽����";

					// = 82
				case ReportStringId.UD_TTip_AlignLeft:
					// return "Align Lefts";
					return "�����";

					// = 83
				case ReportStringId.UD_TTip_AlignVerticalCenters:
					// return "Align Centers";
					return "���ж���";

					// = 84
				case ReportStringId.UD_TTip_AlignRight:
					// return "Align Rights";
					return "�Ҷ���";

					// = 85
				case ReportStringId.UD_TTip_AlignTop:
					// return "Align Tops";
					return "���˶���";

					// = 86
				case ReportStringId.UD_TTip_AlignHorizontalCenters:
					// return "Align Middles";
					return "�м����";

					// = 87
				case ReportStringId.UD_TTip_AlignBottom:
					// return "Align Bottoms";
					return "�׶˶���";

					// = 88
				case ReportStringId.UD_TTip_SizeToControlWidth:
					// return "Make Same Width";
					return "ʹ�����ͬ";

					// = 89
				case ReportStringId.UD_TTip_SizeToGrid:
					// return "Size to Grid";
					return "�����������С";

					// = 90
				case ReportStringId.UD_TTip_SizeToControlHeight:
					// return "Make Same Height";
					return "ʹ�߶���ͬ";

					// = 91
				case ReportStringId.UD_TTip_SizeToControl:
					// return "Make Same size";
					return "ʹ��С��ͬ";

					// = 92
				case ReportStringId.UD_TTip_HorizSpaceMakeEqual:
					// return "Make Horizontal Spacing Equal";
					return "ʹˮƽ�����ͬ";

					// = 93
				case ReportStringId.UD_TTip_HorizSpaceIncrease:
					// return "Increase Horizontal Spacing";
					return "����ˮƽ���";

					// = 94
				case ReportStringId.UD_TTip_HorizSpaceDecrease:
					// return "Decrease Horizontal Spacing";
					return "��Сˮƽ���";

					// = 95
				case ReportStringId.UD_TTip_HorizSpaceConcatenate:
					// return "Remove Horizontal Spacing";
					return "�Ƴ�ˮƽ���";

					// = 96
				case ReportStringId.UD_TTip_VertSpaceMakeEqual:
					// return "Make Vertical Spacing Equal";
					return "ʹ��ֱ�����ͬ";

					// = 97
				case ReportStringId.UD_TTip_VertSpaceIncrease:
					// return "Increase Vertical Spacing";
					return "���Ӵ�ֱ���";

					// = 98
				case ReportStringId.UD_TTip_VertSpaceDecrease:
					// return "Decrease Vertical Spacing";
					return "��С��ֱ���";

					// = 99
				case ReportStringId.UD_TTip_VertSpaceConcatenate:
					// return "Remove Vertical Spacing";
					return "�Ƴ���ֱ���";

					// = 100
				case ReportStringId.UD_TTip_CenterHorizontally:
					// return "Center Horizontally";
					return "ˮƽ����";

					// = 101
				case ReportStringId.UD_TTip_CenterVertically:
					// return "CenterVertically";
					return "��ֱ����";

					// = 102
				case ReportStringId.UD_TTip_BringToFront:
					// return "Bring to Front";
					return "���ڶ���";

					// = 103
				case ReportStringId.UD_TTip_SendToBack:
					// return "Send to Back";
					return "���ڵײ� ";

					// = 104
				case ReportStringId.UD_TTip_FormatBold:
					// return "Bold";
					return "�Ӵ�";

					// = 105
				case ReportStringId.UD_TTip_FormatItalic:
					// return "Italic";
					return "��б";

					// = 106
				case ReportStringId.UD_TTip_FormatUnderline:
					// return "Underline";
					return "�»���";

					// = 107
				case ReportStringId.UD_TTip_FormatAlignLeft:
					// return "Align Left";
					return "����";

					// = 108
				case ReportStringId.UD_TTip_FormatCenter:
					// return "Center";
					return "����";

					// = 109
				case ReportStringId.UD_TTip_FormatAlignRight:
					// return "Align Right";
					return "����";

					// = 110
				case ReportStringId.UD_TTip_FormatFontName:
					// return "Font Name";
					return "����";

					// = 111
				case ReportStringId.UD_TTip_FormatFontSize:
					// return "Font Size";
					return "�ֺ�";

					// = 112
				case ReportStringId.UD_TTip_FormatForeColor:
					// return "Foreground Color";
					return "������ɫ";

					// = 113
				case ReportStringId.UD_TTip_FormatBackColor:
					// return "Background Color";
					return "������ɫ";

					// = 114
				case ReportStringId.UD_TTip_FormatJustify:
					// return "Justify";
					return "����";

					// = 115
				case ReportStringId.UD_FormCaption:
					// return "Report Designer";
					return "���������";

					// = 116
				case ReportStringId.VS_XtraReportsToolboxCategoryName:
					// return "Developer Express: Reports";
					return "Developer Express: ����";

					// = 117
				case ReportStringId.UD_XtraReportsToolboxCategoryName:
					// return "Standard Controls";
					return "��׼�ؼ�";

					// = 118
				case ReportStringId.UD_XtraReportsPointerItemCaption:
					// return "Pointer";
					return "ָ��";

					// = 119
				case ReportStringId.Verb_EditBands:
					// return "Edit Bands...";
					return "�༭Bands";

					// = 120
				case ReportStringId.Verb_EditGroupFields:
					// return "Edit GroupFields...";
					return "�༭���ֶ�";

					// = 121
				case ReportStringId.Verb_Import:
					// return "Import...";
					return "����...";

					// = 122
				case ReportStringId.Verb_Save:
					// return "Save...";
					return "����...";

					// = 123
				case ReportStringId.Verb_About:
					// return "About...";
					return "����...";

					// = 124
				case ReportStringId.Verb_RTFClear:
					// return "Clear";
					return "���";

					// = 125
				case ReportStringId.Verb_RTFLoad:
					// return "Load File...";
					return "�����ļ�...";

					// = 126
				case ReportStringId.Verb_FormatString:
					// return "Format String...";
					return "��ʽ�� �ַ���...";

					// = 127
				case ReportStringId.Verb_SummaryWizard:
					// return "Summary...";
					return "ժҪ...";

					// = 128
				case ReportStringId.Verb_ReportWizard:
					// return "Customize report with Wizard";
					return "ʹ�����Զ��屨��";

					// = 129
				case ReportStringId.Verb_Insert:
					// return "Insert...";
					return "����...";

					// = 130
				case ReportStringId.Verb_Delete:
					// return "Delete...";
					return "ɾ��...";

					// = 131
				case ReportStringId.Verb_Bind:
					// return "Bind";
					return "��";

					// = 132
				case ReportStringId.Verb_EditText:
					// return "Edit Text";
					return "�༭�ı�";

					// = 133
				case ReportStringId.FSForm_Lbl_Category:
					// return "Category";
					return "����XX";

					// = 134
				case ReportStringId.FSForm_Lbl_Prefix:
					// return "Prefix";
					return "ǰ׺";

					// = 135
				case ReportStringId.FSForm_Lbl_Suffix:
					// return "Suffix";
					return "��׺";

					// = 136
				case ReportStringId.FSForm_Lbl_CustomGeneral:
					// return "General format has no specific number format";
					return "һ���ʽ�����ر����ָ�ʽ";

					// = 137
				case ReportStringId.FSForm_GrBox_Sample:
					// return "Sample";
					return "ʾ��";

					// = 138
				case ReportStringId.FSForm_Tab_StandardTypes:
					// return "Standard Types";
					return "��׼����";

					// = 139
				case ReportStringId.FSForm_Tab_Custom:
					// return "Custom";
					return "�Զ���";

					// = 140
				case ReportStringId.FSForm_Msg_BadSymbol:
					// return "Bad symbol";
					return "�𻵵ķ���";

					// = 141
				case ReportStringId.FSForm_Btn_Delete:
					// return "Delete";
					return "ɾ��";

					// = 142
				case ReportStringId.BCForm_Lbl_Property:
					// return "Property";
					return "����";

					// = 143
				case ReportStringId.BCForm_Lbl_Binding:
					// return "Binding";
					return "��";

					// = 144
				case ReportStringId.SSForm_Caption:
					// return "Styles Editor";
					return "��ʽ�༭";

					// = 145
				case ReportStringId.SSForm_Btn_Close:
					// return "Close";
					return "�ر�";

					// = 146
				case ReportStringId.SSForm_Msg_NoStyleSelected:
					// return "No styles selected";
					return "û����ʽ��ѡ��";

					// = 147
				case ReportStringId.SSForm_Msg_MoreThanOneStyle:
					// return "You selected more than one style";
					return "��ѡ���˳���һ������ʽ";

					// = 148
				case ReportStringId.SSForm_Msg_SelectedStylesText:
					// return " selected styles...";
					return "ѡ�е���ʽ...";

					// = 149
				case ReportStringId.SSForm_Msg_StyleSheetError:
					// return "StyleSheet error";
					return "StyleSheet����";

					// = 150
				case ReportStringId.SSForm_Msg_InvalidFileFormat:
					// return "Invalid file format";
					return "��Ч���ļ���ʽ";

					// = 151
				case ReportStringId.SSForm_Msg_StyleNamePreviewPostfix:
					// return " style";
					return " ��ʽ";

					// = 152
				case ReportStringId.SSForm_Msg_FileFilter:
					// return "Report StyleSheet files (*.repss)|*.repss|All files (*.*)|*.*";
					return "����StyleSheet files (*.repss)|*.repss|�����ļ� (*.*)|*.*";

					// = 153
				case ReportStringId.SSForm_TTip_AddStyle:
					// return "Add style";
					return "�����ʽ";

					// = 154
				case ReportStringId.SSForm_TTip_RemoveStyle:
					// return "Remove style";
					return "ɾ����ʽ";

					// = 155
				case ReportStringId.SSForm_TTip_ClearStyles:
					// return "Clear styles";
					return "�����ʽ";

					// = 156
				case ReportStringId.SSForm_TTip_PurgeStyles:
					// return "Delete unused styles";
					return "ɾ��δʹ�õ���ʽ";

					// = 157
				case ReportStringId.SSForm_TTip_SaveStyles:
					// return "Save styles to file";
					return "����ʽ���浽�ļ�";

					// = 158
				case ReportStringId.SSForm_TTip_LoadStyles:
					// return "Load styles from file";
					return "���ļ��м�����ʽ";

					// = 159
				case ReportStringId.FindForm_Msg_FinishedSearching:
					// return "Finished searching through the document";
					return "�����ļ����";

					// = 160
				case ReportStringId.FindForm_Msg_TotalFound:
					// return "Total found: ";
					return "�ϼƲ��ң�";

					// = 161
				case ReportStringId.RepTabCtl_HtmlView:
					// return "HTML View";
					return "HTML��ͼ";

					// = 162
				case ReportStringId.RepTabCtl_Preview:
					// return "Preview";
					return "Ԥ��";

					// = 163
				case ReportStringId.RepTabCtl_Designer:
					// return "Designer";
					return "�����";

					// = 164
				case ReportStringId.PanelDesignMsg:
					// return "Place controls here to keep them together";
					return "�ڴ˷��ò�ͬ�ؼ�";

					// = 165
				case ReportStringId.MultiColumnDesignMsg1:
					// return "Space for repeating columns.";
					return "�ظ���֮��Ŀ�λ��";

					// = 166
				case ReportStringId.MultiColumnDesignMsg2:
					// return "Controls placed here will be printed incorrectly.";
					return "�˴��Ŀؼ�������ȷ��ӡ��";

					// = 167
				case ReportStringId.UD_Group_File:
					// return "&File";
					return "�ļ�(&F)";

					// = 168
				case ReportStringId.UD_Group_Edit:
					// return "&Edit";
					return "�༭(&E)";

					// = 169
				case ReportStringId.UD_Group_View:
					// return "&View";
					return "��ͼ(&V)";

					// = 170
				case ReportStringId.UD_Group_Format:
					// return "Fo&rmat";
					return "��ʽ(&R)";

					// = 171
				case ReportStringId.UD_Group_Font:
					// return "&Font";
					return "����(&F)";

					// = 172
				case ReportStringId.UD_Group_Justify:
					// return "&Justify";
					return "���˶���(&J)";

					// = 173
				case ReportStringId.UD_Group_Align:
					// return "&Align";
					return "����(&A)";

					// = 174
				case ReportStringId.UD_Group_MakeSameSize:
					// return "&Make Same Size";
					return "ʹ��С��ͬ (&M)";

					// = 175
				case ReportStringId.UD_Group_HorizontalSpacing:
					// return "&Horizontal Spacing";
					return "ˮƽ���(&H)";

					// = 176
				case ReportStringId.UD_Group_VerticalSpacing:
					// return "&Vertical Spacing";
					return "��ֱ���(&H)";

					// = 177
				case ReportStringId.UD_Group_CenterInForm:
					// return "&Center in Form";
					return "���봰������(&C)";

					// = 178
				case ReportStringId.UD_Group_Order:
					// return "&Order";
					return "˳��(&O)";

					// = 179
				case ReportStringId.UD_Group_ToolbarsList:
					// return "&Toolbars";
					return "������(&T)";

					// = 180
				case ReportStringId.UD_Group_DockPanelsList:
					// return "&Windows";
					return "����(&W)";

					// = 181
				case ReportStringId.UD_Capt_MainMenuName:
					// return "Main Menu";
					return "���˵�";

					// = 182
				case ReportStringId.UD_Capt_ToolbarName:
					// return "Toolbar";
					return "������";

					// = 183
				case ReportStringId.UD_Capt_LayoutToolbarName:
					// return "Layout Toolbar";
					return "���ֹ�����";

					// = 184
				case ReportStringId.UD_Capt_FormattingToolbarName:
					// return "Formatting Toolbar";
					return "��ʽ������";

					// = 185
				case ReportStringId.UD_Capt_StatusBarName:
					// return "Status Bar";
					return "״̬��";

					// = 186
				case ReportStringId.UD_Capt_ZoomToolbarName:
					// return "Zoom Bar";
					return "������";

					// = 187
				case ReportStringId.UD_Capt_NewReport:
					// return "&New";
					return "�½�(&N)";

					// = 188
				case ReportStringId.UD_Capt_NewWizardReport:
					// return "New with &Wizard...";
					return "ʹ�����½�(&W)";

					// = 189
				case ReportStringId.UD_Capt_OpenFile:
					// return "&Open...";
					return "����(&O)";

					// = 190
				case ReportStringId.UD_Capt_SaveFile:
					// return "&Save";
					return "����(&S)";

					// = 191
				case ReportStringId.UD_Capt_SaveFileAs:
					// return "Save &As...";
					return "���Ϊ(&A)...";

					// = 192
				case ReportStringId.UD_Capt_Exit:
					// return "E&xit";
					return "�˳�(&X)";

					// = 193
				case ReportStringId.UD_Capt_Cut:
					// return "Cu&t";
					return "���� (&T)";

					// = 194
				case ReportStringId.UD_Capt_Copy:
					// return "&Copy";
					return "���� (&Y)";

					// = 195
				case ReportStringId.UD_Capt_Paste:
					// return "&Paste";
					return "ճ�� (&P)";

					// = 196
				case ReportStringId.UD_Capt_Delete:
					// return "&Delete";
					return "ɾ�� (&D)";

					// = 197
				case ReportStringId.UD_Capt_SelectAll:
					// return "Select &All";
					return "ȫѡ (&A)";

					// = 198
				case ReportStringId.UD_Capt_Undo:
					// return "&Undo";
					return "���� (&U)";

					// = 199
				case ReportStringId.UD_Capt_Redo:
					// return "&Redo";
					return "�ظ� (&R)";

					// = 200
				case ReportStringId.UD_Capt_ForegroundColor:
					// return "For&eground Color";
					return "������ɫ (&E)";

					// = 201
				case ReportStringId.UD_Capt_BackGroundColor:
					// return "Bac&kground Color";
					return "������ɫ (&K)";

					// = 202
				case ReportStringId.UD_Capt_FontBold:
					// return "&Bold";
					return "�Ӵ� (&B)";

					// = 203
				case ReportStringId.UD_Capt_FontItalic:
					// return "&Italic";
					return "��б (&I)";

					// = 204
				case ReportStringId.UD_Capt_FontUnderline:
					// return "&Undeline";
					return "�»��� (&U)";

					// = 205
				case ReportStringId.UD_Capt_JustifyLeft:
					// return "&Left";
					return "����� (&L)";

					// = 206
				case ReportStringId.UD_Capt_JustifyCenter:
					// return "&Center";
					return "���� (&C)";

					// = 207
				case ReportStringId.UD_Capt_JustifyRight:
					// return "&Rights";
					return "�Ҷ��� (&R)";

					// = 208
				case ReportStringId.UD_Capt_JustifyJustify:
					// return "&Justify";
					return "���˶��� (&J)";

					// = 209
				case ReportStringId.UD_Capt_AlignLefts:
					// return "&Lefts";
					return "����� (&L)";

					// = 210
				case ReportStringId.UD_Capt_AlignCenters:
					// return "&Centers";
					return "���� (&C)";

					// = 211
				case ReportStringId.UD_Capt_AlignRights:
					// return "&Rights";
					return "�Ҷ��� (&R)";

					// = 212
				case ReportStringId.UD_Capt_AlignTops:
					// return "&Tops";
					return "�������� (&T)";

					// = 213
				case ReportStringId.UD_Capt_AlignMiddles:
					// return "&Middles";
					return "�м���� (&M)";

					// = 214
				case ReportStringId.UD_Capt_AlignBottoms:
					// return "&Bottoms";
					return "�ײ����� (&B)";

					// = 215
				case ReportStringId.UD_Capt_AlignToGrid:
					// return "to &Grid";
					return "���뵽���� (&G)";

					// = 216
				case ReportStringId.UD_Capt_MakeSameSizeWidth:
					// return "&Width";
					return "��� (&W)";

					// = 217
				case ReportStringId.UD_Capt_MakeSameSizeSizeToGrid:
					// return "Size to Gri&d";
					return "�����������С(&D)";

					// = 218
				case ReportStringId.UD_Capt_MakeSameSizeHeight:
					// return "&Height";
					return "�߶� (&H)";

					// = 219
				case ReportStringId.UD_Capt_MakeSameSizeBoth:
					// return "&Both";
					return "����(&B)";

					// = 220
				case ReportStringId.UD_Capt_SpacingMakeEqual:
					// return "Make &Equal";
					return "ʹ���(&E)";

					// = 221
				case ReportStringId.UD_Capt_SpacingIncrease:
					// return "&Increase";
					return "����(&I)";

					// = 222
				case ReportStringId.UD_Capt_SpacingDecrease:
					// return "&Decrease";
					return "����(&D)";

					// = 223
				case ReportStringId.UD_Capt_SpacingRemove:
					// return "&Remove";
					return "�Ƴ�(&R)";

					// = 224
				case ReportStringId.UD_Capt_CenterInFormHorizontally:
					// return "&Horizontally";
					return "ˮƽ(&H)";

					// = 225
				case ReportStringId.UD_Capt_CenterInFormVertically:
					// return "&Vertically";
					return "��ֱ(&V)";

					// = 226
				case ReportStringId.UD_Capt_OrderBringToFront:
					// return "&Bring to Front";
					return "���ڶ��� (&B)";

					// = 227
				case ReportStringId.UD_Capt_OrderSendToBack:
					// return "&Send to Back";
					return "���ڵײ� (&S)";

					// = 228
				case ReportStringId.UD_Capt_Zoom:
					// return "Zoom";
					return "����";

					// = 229
				case ReportStringId.UD_Capt_ZoomIn:
					// return "Zoom In";
					return "�Ŵ�";

					// = 230
				case ReportStringId.UD_Capt_ZoomOut:
					// return "Zoom Out";
					return "��С";

					// = 231
				case ReportStringId.UD_Capt_ZoomFactor:
					// return "Zoom Factor: {0}%";
					return "���ű�����{0}%";

					// = 232
				case ReportStringId.UD_Hint_NewReport:
					// return "Create a new blank report";
					return "�����±���";

					// = 233
				case ReportStringId.UD_Hint_NewWizardReport:
					// return "Create a new report using the Wizard";
					return "ʹ���򵼴����±���";

					// = 234
				case ReportStringId.UD_Hint_OpenFile:
					// return "Open a report";
					return "�򿪱���";

					// = 235
				case ReportStringId.UD_Hint_SaveFile:
					// return "Save a report";
					return "���汨��";

					// = 236
				case ReportStringId.UD_Hint_SaveFileAs:
					// return "Save a report with a new name";
					return "�������Ʊ��汨��";

					// = 237
				case ReportStringId.UD_Hint_Exit:
					// return "Close the designer";
					return "�ر������";

					// = 238
				case ReportStringId.UD_Hint_Cut:
					// return "Delete the control and copy it to the clipboard";
					return "ɾ���ؼ����������Ƶ�������";

					// = 239
				case ReportStringId.UD_Hint_Copy:
					// return "Copy the control to the clipboard";
					return "���ؼ����Ƶ�������";

					// = 240
				case ReportStringId.UD_Hint_Paste:
					// return "Add the control from the clipboard";
					return "�Ӽ�������ӿؼ�";

					// = 241
				case ReportStringId.UD_Hint_Delete:
					// return "Delete the control";
					return "ɾ���ؼ�";

					// = 242
				case ReportStringId.UD_Hint_SelectAll:
					// return "Select all the controls in the document";
					return "ѡ�����пؼ�";

					// = 243
				case ReportStringId.UD_Hint_Undo:
					// return "Undo the last operation";
					return "����������";

					// = 244
				case ReportStringId.UD_Hint_Redo:
					// return "Redo the last operation";
					return "�ظ�������";

					// = 245
				case ReportStringId.UD_Hint_ForegroundColor:
					// return "Set the foreground color of the control";
					return "����ǰ��ɫ";

					// = 246
				case ReportStringId.UD_Hint_BackGroundColor:
					// return "Set the background color of the control";
					return "���ñ���ɫ";

					// = 247
				case ReportStringId.UD_Hint_FontBold:
					// return "Make the font bold";
					return "ʹ����Ӵ�";

					// = 248
				case ReportStringId.UD_Hint_FontItalic:
					// return "Make the font italic";
					return "ʹ������б";

					// = 249
				case ReportStringId.UD_Hint_FontUnderline:
					// return "Underline the font";
					return "�����¼��»���";

					// = 250
				case ReportStringId.UD_Hint_JustifyLeft:
					// return "Align the control's text to the left";
					return "����ؼ����ı������";

					// = 251
				case ReportStringId.UD_Hint_JustifyCenter:
					// return "Align the control's text to the center";
					return "����ؼ����ı����м�";

					// = 252
				case ReportStringId.UD_Hint_JustifyRight:
					// return "Align the control's text to the right";
					return "����ؼ����ı����ұ�";

					// = 253
				case ReportStringId.UD_Hint_JustifyJustify:
					// return "Justify the control's text";
					return "����ؼ����ı�������";

					// = 254
				case ReportStringId.UD_Hint_AlignLefts:
					// return "Left align the selected controls";
					return "ʹѡ�еĿؼ������";

					// = 255
				case ReportStringId.UD_Hint_AlignCenters:
					// return "Align the centers of the selected controls vertically";
					return "ʹѡ�еĿؼ���ֱ����";

					// = 256
				case ReportStringId.UD_Hint_AlignRights:
					// return "Right align the selected controls";
					return "ʹѡ�еĿؼ��Ҷ���";

					// = 257
				case ReportStringId.UD_Hint_AlignTops:
					// return "Align the tops of the selected controls";
					return "ʹѡ�еĿؼ���������";

					// = 258
				case ReportStringId.UD_Hint_AlignMiddles:
					// return "Align the centers of the selected controls horizontally";
					return "ʹѡ�еĿؼ�ˮƽ����";

					// = 259
				case ReportStringId.UD_Hint_AlignBottoms:
					// return "Align the bottoms of the selected controls";
					return "ʹѡ�еĿؼ��ײ�����";

					// = 260
				case ReportStringId.UD_Hint_AlignToGrid:
					// return "Align the positions of the selected controls to the grid";
					return "ʹѡ�еĿؼ����뵽����";

					// = 261
				case ReportStringId.UD_Hint_MakeSameSizeWidth:
					// return "Make the selected controls have the same width";
					return "ʹѡ�еĿؼ������ͬ";

					// = 262
				case ReportStringId.UD_Hint_MakeSameSizeSizeToGrid:
					// return "Size the selected controls to the grid";
					return "����ѡ�еĿؼ��Ĵ�С";

					// = 263
				case ReportStringId.UD_Hint_MakeSameSizeHeight:
					// return "Make the selected controls have the same height";
					return "ʹѡ�еĿؼ��߶���ͬ";

					// = 264
				case ReportStringId.UD_Hint_MakeSameSizeBoth:
					// return "Make the selected controls the same size";
					return "ʹѡ�еĿؼ���С��ͬ";

					// = 265
				case ReportStringId.UD_Hint_SpacingMakeEqual:
					// return "Make the spacing between the selected controls equal";
					return "ʹѡ�еĿؼ������ͬ";

					// = 266
				case ReportStringId.UD_Hint_SpacingIncrease:
					// return "Increase the spacing between the selected controls";
					return "����ѡ�еĿؼ����";

					// = 267
				case ReportStringId.UD_Hint_SpacingDecrease:
					// return "Decrease the spacing between the selected controls";
					return "��Сѡ�еĿؼ����";

					// = 268
				case ReportStringId.UD_Hint_SpacingRemove:
					// return "Remove the spacing between the selected controls";
					return "�Ƴ�ѡ�еĿؼ����";

					// = 269
				case ReportStringId.UD_Hint_CenterInFormHorizontally:
					// return "Horizontally center the selected controls within a band";
					return "ʹѡ�еĿؼ���Band������ˮƽ����";

					// = 270
				case ReportStringId.UD_Hint_CenterInFormVertically:
					// return "Vertically center the selected controls within a band";
					return "ʹѡ�еĿؼ���Band�����ڴ�ֱ����";

					// = 271
				case ReportStringId.UD_Hint_OrderBringToFront:
					// return "Bring the selected controls to the front";
					return "ʹѡ�еĿؼ����ڶ���";

					// = 272
				case ReportStringId.UD_Hint_OrderSendToBack:
					// return "Move the selected controls to the back";
					return "ʹѡ�еĿؼ����ڵײ�";

					// = 273
				case ReportStringId.UD_Hint_Zoom:
					// return "Select or input the zoom factor";
					return "ѡ����������ű���";

					// = 274
				case ReportStringId.UD_Hint_ZoomIn:
					// return "Zoom in the design surface";
					return "�Ŵ���ƽ���";

					// = 275
				case ReportStringId.UD_Hint_ZoomOut:
					// return "Zoom out the design surface";
					return "��С��ƽ���";

					// = 276
				case ReportStringId.UD_Hint_ViewBars:
					// return "Hide or show the {0}";
					return "����/��ʾ {0}";

					// = 277
				case ReportStringId.UD_Hint_ViewDockPanels:
					// return "Hide or show the {0} window";
					return "��ʾ/���� {0} ����";

					// = 278
				case ReportStringId.UD_Hint_ViewTabs:
					// return "Switch to the {0} tab";
					return "ת�� {0} ��ǩ";

					// = 279
				case ReportStringId.UD_Title_FieldList:
					// return "Field List";
					return "�ֶ��б�";

					// = 280
				case ReportStringId.UD_Title_ReportExplorer:
					// return "Report Explorer";
					return "������Դ������";

					// = 281
				case ReportStringId.UD_Title_PropertyGrid:
					// return "Property Grid";
					return "���Ա��";

					// = 282
				case ReportStringId.UD_Title_ToolBox:
					// return "Tool Box";
					return "������";

					// = 283
				case ReportStringId.STag_Name_Text:
					// return "Text";
					return "�ı�";

					// = 284
				case ReportStringId.STag_Name_DataBinding:
					// return "Data Binding";
					return "���ݰ�";

					// = 285
				case ReportStringId.STag_Name_FormatString:
					// return "Format String";
					return "�ַ�����ʽ��";

					// = 286
				case ReportStringId.STag_Name_ForeColor:
					// return "Fore Color";
					return "ǰ��ɫ";

					// = 287
				case ReportStringId.STag_Name_BackColor:
					// return "Back Color";
					return "����ɫ";

					// = 288
				case ReportStringId.STag_Name_Font:
					// return "Font";
					return "����";

					// = 289
				case ReportStringId.STag_Name_LineDirection:
					// return "Line Direction";
					return "��������";

					// = 290
				case ReportStringId.STag_Name_LineStyle:
					// return "Line Style";
					return "������ʽ";

					// = 291
				case ReportStringId.STag_Name_LineWidth:
					// return "Line Width";
					return "�������";

					// = 292
				case ReportStringId.STag_Name_CanGrow:
					// return "Can Grow";
					return "����";

					// = 293
				case ReportStringId.STag_Name_CanShrink:
					// return "Can Shrink";
					return "����";

					// = 294
				case ReportStringId.STag_Name_Multiline:
					// return "Multiline";
					return "����";

					// = 295
				case ReportStringId.STag_Name_Summary:
					// return "Summary";
					return "ժҪ";

					// = 296
				case ReportStringId.STag_Name_Symbology:
					// return "Symbology";
					return "����";

					// = 297
				case ReportStringId.STag_Name_Module:
					// return "Module";
					return "ģ��";

					// = 298
				case ReportStringId.STag_Name_ShowText:
					// return "Show Text";
					return "��ʾ�ı�";

					// = 299
				case ReportStringId.STag_Name_SegmentWidth:
					// return "Segment Width";
					return "�ֶο��";

					// = 300
				case ReportStringId.STag_Name_Checked:
					// return "Checked";
					return "��ѡ��";

					// = 301
				case ReportStringId.STag_Name_Image:
					// return "Image";
					return "ͼ��";

					// = 302
				case ReportStringId.STag_Name_ImageUrl:
					// return "Image Url";
					return "ͼ��URL";

					// = 303
				case ReportStringId.STag_Name_ImageSizing:
					// return "Image Sizing";
					return "ͼ��ߴ�";

					// = 304
				case ReportStringId.STag_Name_ReportSource:
					// return "Report Source";
					return "������Դ";

					// = 305
				case ReportStringId.STag_Name_PreviewRowCount:
					// return "Preview Row Count";
					return "Ԥ������";

					// = 306
				case ReportStringId.STag_Name_ShrinkSubReportIconArea:
					// return "Shrink subreport icon's area";
					return "�����ӱ����ͼ������";

					// = 307
				case ReportStringId.STag_Name_PageInfo:
					// return "Page Info";
					return "ҳ����Ϣ";

					// = 308
				case ReportStringId.STag_Name_StartPageNumber:
					// return "Start Page Number";
					return "��ʼҳ��";

					// = 309
				case ReportStringId.STag_Name_Format:
					// return "Format";
					return "��ʽ";

					// = 310
				case ReportStringId.STag_Name_KeepTogether:
					// return "Keep Together";
					return "����һ��";

					// = 311
				case ReportStringId.STag_Name_Bands:
					return "Bands";

					// = 312
				case ReportStringId.STag_Name_Height:
					// return "Height";
					return "�߶�";

					// = 313
				case ReportStringId.STag_Name_RepeatEveryPage:
					// return "Repeat Every Page";
					return "�ظ�ÿ��ҳ��";

					// = 314
				case ReportStringId.STag_Name_PrintAtBottom:
					// return "Print At Bottom";
					return "��ӡ�ڵ׶�";

					// = 315
				case ReportStringId.STag_Name_GroupFields:
					// return "Group Fields";
					return "Ⱥ���ֶ�";

					// = 316
				case ReportStringId.STag_Name_SortFields:
					// return "Sort Fields";
					return "�����ֶ�";

					// = 317
				case ReportStringId.STag_Name_GroupUnion:
					// return "Group Union";
					return "Ⱥ�鲢��";

					// = 318
				case ReportStringId.STag_Name_Level:
					// return "Level";
					return "���";

					// = 319
				case ReportStringId.STag_Name_ColumnMode:
					// return "Column Mode";
					return "��ģʽ";

					// = 320
				case ReportStringId.STag_Name_ColumnCount:
					// return "Column Count";
					return "�м���";

					// = 321
				case ReportStringId.STag_Name_ColumnWidth:
					// return "Column Width";
					return "�п�";

					// = 322
				case ReportStringId.STag_Name_ColumnSpacing:
					// return "Column Spacing";
					return "�м��";

					// = 323
				case ReportStringId.STag_Name_Direction:
					// return "Direction";
					return "����";

					// = 324
				case ReportStringId.STag_Name_Watermark:
					// return "Watermark";
					return "ˮӡ";

					// = 325
				case ReportStringId.STag_Name_ReportUnit:
					// return "Report Unit";
					return "����Ԫ";

					// = 326
				case ReportStringId.STag_Name_DataSource:
					// return "Data Source";
					return "����Դ";

					// = 327
				case ReportStringId.STag_Name_DataMember:
					// return "Data Member";

					// = 328
				case ReportStringId.STag_Name_DataAdapter:
					// return "Data Adapter";
					return "������";

					// = 329
				case ReportStringId.STag_Name_Angle:
					// return "Angle";
					return "�Ƕ�";

					// = 330
				case ReportStringId.STag_Name_Stretch:
					// return "Stretch";
					return "����";

					// = 331
				case ReportStringId.STag_Name_Shape:
					return "Shape";


					// = 332
				case ReportStringId.STag_Name_Fillet:
					// return "Fillet";
					return "��Ƭ";

					// = 333
				case ReportStringId.STag_Name_TailLength:
					// return "Tail Length";
					return "β�ͳ���";

					// = 334
				case ReportStringId.STag_Name_TipLength:
					// return "Tip Length";
					return "��ʾ����";

					// = 335
				case ReportStringId.STag_Name_NumberOfSides:
					// return "Number of Sides";
					return "�ߵ���Ŀ";

					// = 336
				case ReportStringId.STag_Name_StarPointCount:
					// return "Star Point Count";
					return "�ǵ���";

					// = 337
				case ReportStringId.STag_Name_Concavity:
					// return "Concavity";
					return "����";

					// = 338
				case ReportStringId.STag_Name_ArrowHeight:
					// return "Arrow Height";
					return "��ͷ�߶�";

					// = 339
				case ReportStringId.STag_Name_ArrowWidth:
					// return "Arrow Width";
					return "��ͷ���";

					// = 340
				case ReportStringId.STag_Name_VerticalLineWidth:
					// return "Vertical Line Width";
					return "��ֱ�ߵĿ��";

					// = 341
				case ReportStringId.STag_Name_HorizontalLineWidth:
					// return "Horizontal Line Width";
					return "ˮƽ�ߵĿ��";

					// = 342
				case ReportStringId.STag_Name_FillColor:
					// return "Fill Color";
					return "���ɫ";
			}

			return base.GetLocalizedString(id);
		}

		public override string Language
		{
			get
			{
				return "��������";
			}
		}
	}


	// XtraScheduler
    //public class XtraSchedulerLocalizer : SchedulerLocalizer
    //{
    //    public override string GetLocalizedString(SchedulerStringId id)
    //    {
    //        switch (id)
    //        {
    //                // = 0
    //            case SchedulerStringId.Msg_IsNotValid:
    //                // return "'{0}' is not a valid value for '{1}'";
    //                return "'{0}' ����� '{1}' ����һ����Чֵ.";

    //                // = 1xxxx
    //            case SchedulerStringId.Msg_InvalidDayOfWeekForDailyRecurrence:
    //                return "Invalid day of week for a daily recurrence. Only WeekDays.EveryDay, WeekDays.WeekendDays and WeekDays.WorkDays are valid in this context.";

    //                // = 2
    //            case SchedulerStringId.Msg_InternalError:
    //                // return "Internal error!";
    //                return "�ڲ�����!";

    //                // = 3
    //            case SchedulerStringId.Msg_NoMappingForObject:
    //                // return "The following required mappings for the object \r\n {0} are not assigned";
    //                return "�������������Mapping \r\n {0} û�и�ֵ��";

    //                // = 4
    //            case SchedulerStringId.Msg_XtraSchedulerNotAssigned:
    //                // return "The SchedulerStorage component is not assigned to the SchedulerControl";
    //                return "���SchedulerStorageû�и���SchedulerControl�ؼ�";

    //                // = 5
    //            case SchedulerStringId.Msg_InvalidTimeOfDayInterval:
    //                // return "Invalid duration for the TimeOfDayInterval";
    //                return "��Ч��TimeOfDayIntervalʱ��";

    //                // = 6
    //            case SchedulerStringId.Msg_OverflowTimeOfDayInterval:
    //                // return "Invalid value for the TimeOfDayInterval. Should be less than or equal to a day";
    //                return "��Ч��TimeOfDayInterval��ֵ�� ��ֵ�������ڻ������һ��";

    //                // = 7
    //            case SchedulerStringId.Msg_LoadCollectionFromXml:
    //                // return "The scheduler needs to be in unbound mode to load collection items from xml";
    //                return "��XML������Ŀʱ���������������ڷǰ�ģʽ";

    //                // = 8
    //            case SchedulerStringId.AppointmentLabel_None:
    //                // return "None";
    //                return "��";

    //                // = 9
    //            case SchedulerStringId.AppointmentLabel_Important:
    //                // return "Important";
    //                return "��Ҫ";

    //                // = 10
    //            case SchedulerStringId.AppointmentLabel_Business:
    //                // return "Business";
    //                return "����";

    //                // = 11
    //            case SchedulerStringId.AppointmentLabel_Personal:
    //                // return "Personal";
    //                return "����";

    //                // = 12
    //            case SchedulerStringId.AppointmentLabel_Vacation:
    //                // return "Vacation";
    //                return "�ݼ�";

    //                // = 13
    //            case SchedulerStringId.AppointmentLabel_MustAttend:
    //                // return "Must Attend";
    //                return "�����ϯ";

    //                // = 14
    //            case SchedulerStringId.AppointmentLabel_TravelRequired:
    //                // return "Travel Required";
    //                return "��������";

    //                // = 15
    //            case SchedulerStringId.AppointmentLabel_NeedsPreparation:
    //                // return "Needs Preparation";
    //                return "��Ҫ׼��";

    //                // = 16
    //            case SchedulerStringId.AppointmentLabel_Birthday:
    //                // return "Birthday";
    //                return "����";

    //                // = 17
    //            case SchedulerStringId.AppointmentLabel_Anniversary:
    //                // return "Anniversary";
    //                return "�������";

    //                // = 18
    //            case SchedulerStringId.AppointmentLabel_PhoneCall:
    //                // return "Phone Call";
    //                return "ͨ��";

    //                // = 19
    //            case SchedulerStringId.Msg_InvalidEndDate:
    //                // return "The date you entered occurs before the start date.";
    //                return "������ʼ���ڡ�";

    //                // = 20
    //            case SchedulerStringId.Caption_Appointment:
    //                // return "{0} - Appointment";
    //                return "{0} - Լ��";

    //                // = 21
    //            case SchedulerStringId.Caption_Event:
    //                // return "{0} - Event";
    //                return "{0} - Ҫ��";

    //                // = 22
    //            case SchedulerStringId.Caption_UntitledAppointment:
    //                // return "Untitled";
    //                return "δ����";

    //                // = 23
    //            case SchedulerStringId.Caption_WeekDaysEveryDay:
    //                // return "Day";
    //                return "�ܵ�ÿ��";

    //                // = 24
    //            case SchedulerStringId.Caption_WeekDaysWeekendDays:
    //                // return "Weekend day";
    //                return "��ĩ";

    //                // = 25
    //            case SchedulerStringId.Caption_WeekDaysWorkDays:
    //                // return "Weekday";
    //                return "�ܹ�����";

    //                // = 26
    //            case SchedulerStringId.Caption_WeekOfMonthFirst:
    //                // return "First";
    //                return "��һ��";

    //                // = 27
    //            case SchedulerStringId.Caption_WeekOfMonthSecond:
    //                // return "Second";
    //                return "�ڶ���";

    //                // = 28
    //            case SchedulerStringId.Caption_WeekOfMonthThird:
    //                // return "Third";
    //                return "������";

    //                // = 29
    //            case SchedulerStringId.Caption_WeekOfMonthFourth:
    //                // return "Fourth";
    //                return "������";

    //                // = 30
    //            case SchedulerStringId.Caption_WeekOfMonthLast:
    //                // return "Last";
    //                return "���һ��";

    //                // = 31
    //            case SchedulerStringId.Msg_InvalidDayCount:
    //                // return "Invalid day count. Please enter a positive integer value.";
    //                return "��Ч��������������һ����������";

    //                // = 32
    //            case SchedulerStringId.Msg_InvalidDayCountValue:
    //                // return "Invalid day count. Please enter a positive integer value.";
    //                return "��Ч��������������һ����������";

    //                // = 33
    //            case SchedulerStringId.Msg_InvalidWeekCount:
    //                // return "Invalid week count. Please enter a positive integer value.";
    //                return "��Ч��������������һ����������";

    //                // = 34
    //            case SchedulerStringId.Msg_InvalidWeekCountValue:
    //                // return "Invalid week count. Please enter a positive integer value.";
    //                return "��Ч��������������һ����������";

    //                // = 35
    //            case SchedulerStringId.Msg_InvalidMonthCount:
    //                // return "Invalid month count. Please enter a positive integer value.";
    //                return "��Ч��������������һ����������";

    //                // = 36
    //            case SchedulerStringId.Msg_InvalidMonthCountValue:
    //                // return "Invalid month count. Please enter a positive integer value.";
    //                return "��Ч��������������һ����������";

    //                // = 37
    //            case SchedulerStringId.Msg_InvalidYearCount:
    //                // return "Invalid year count. Please enter a positive integer value.";
    //                return "��Ч��������������һ����������";

    //                // = 38
    //            case SchedulerStringId.Msg_InvalidYearCountValue:
    //                // return "Invalid year count. Please enter a positive integer value.";
    //                return "��Ч��������������һ����������";

    //                // = 39
    //            case SchedulerStringId.Msg_InvalidOccurrencesCount:
    //                // return "Invalid occurrences count. Please enter a positive integer value.";
    //                return "��Ч���¼�����������һ����������";

    //                // = 40
    //            case SchedulerStringId.Msg_InvalidOccurrencesCountValue:
    //                // return "Invalid occurrences count. Please enter a positive integer value.";
    //                return "��Ч����������������һ����������";

    //                // = 41
    //            case SchedulerStringId.Msg_InvalidDayNumber:
    //                // return "Invalid day number. Please enter an integer value from 1 to {0}.";
    //                return "�� ������Ч�� ������ 1 �� {0} ֮�����ֵ��";

    //                // = 42
    //            case SchedulerStringId.Msg_InvalidDayNumberValue:
    //                // return "Invalid day number. Please enter an integer value from 1 to {0}.";
    //                return "�� ������Ч�� ������ 1 �� {0} ֮�����ֵ��";

    //                // = 43
    //            case SchedulerStringId.Msg_WarningDayNumber:
    //                // return "Some months have fewer than {0} days. For these months, the occurrences will fall on the last day of the month.";
    //                return "��Щ�·����� {0} �졣 ����������Щ�µ����һ�졣";

    //                // = 44
    //            case SchedulerStringId.Msg_InvalidDayOfWeek:
    //                // return "No day selected. Please select at least one day in the week.";
    //                return "û��ѡ�����ӡ� ������������ѡ��һ�����ӡ�";

    //                // = 45
    //            case SchedulerStringId.MenuCmd_OpenAppointment:
    //                // return "&Open";
    //                return "�� (&O)";

    //                // = 46
    //            case SchedulerStringId.MenuCmd_PrintAppointment:
    //                // return "&Print";
    //                return "��ӡ (&O)";

    //                // = 47
    //            case SchedulerStringId.MenuCmd_DeleteAppointment:
    //                // return "&Delete";
    //                return "ɾ�� (&D)";

    //                // = 48
    //            case SchedulerStringId.MenuCmd_EditSeries:
    //                // return "&Edit Series";
    //                return "�༭���� (&E)";

    //                // = 49
    //            case SchedulerStringId.MenuCmd_RestoreOccurrence:
    //                // return "&Restore Default State";
    //                return "�ָ���Ĭ��״̬ (&R)";

    //                // = 50
    //            case SchedulerStringId.MenuCmd_NewAppointment:
    //                // return "New App&ointment";
    //                return "�½�Լ�� (&O)";

    //                // = 51
    //            case SchedulerStringId.MenuCmd_NewAllDayEvent:
    //                // return "New All Day &Event";
    //                return "�½�ȫ��Ҫ�� (&E)";

    //                // = 52
    //            case SchedulerStringId.MenuCmd_NewRecurringAppointment:
    //                // return "New Recurring &Appointment";
    //                return "�½�������Լ�� (&A)";

    //                // = 53
    //            case SchedulerStringId.MenuCmd_NewRecurringEvent:
    //                // return "New Recurring E&vent";
    //                return "�½�������Ҫ�� (&A)";

    //                // = 54
    //            case SchedulerStringId.MenuCmd_GotoThisDay:
    //                // return "Go to This &Day";
    //                return "ת�������� (&D)";

    //                // = 55
    //            case SchedulerStringId.MenuCmd_GotoToday:
    //                // return "Go to &Today";
    //                return "ת������ (&T)";

    //                // = 56
    //            case SchedulerStringId.MenuCmd_GotoDate:
    //                // return "&Go to Date...";
    //                return "ת������ (&G)...";

    //                // = 57
    //            case SchedulerStringId.MenuCmd_OtherSettings:
    //                // return "Other Sett&ings...";
    //                return "�������� (&I)..��";

    //                // = 58
    //            case SchedulerStringId.MenuCmd_CustomizeCurrentView:
    //                // return "&Customize Current View...";
    //                return "�Զ��嵱ǰ��ͼ (&C)...";

    //                // = 59
    //            case SchedulerStringId.MenuCmd_CustomizeTimeRuler:
    //                // return "Customize Time Ruler...";
    //                return "�Զ���ʱ����...";

    //                // = 60
    //            case SchedulerStringId.MenuCmd_5Minutes:
    //                // return "&5 Minutes";
    //                return "5���� (&5)";

    //                // = 61
    //            case SchedulerStringId.MenuCmd_6Minutes:
    //                // return "&6 Minutes";
    //                return "6���� (&6)";

    //                // = 62
    //            case SchedulerStringId.MenuCmd_10Minutes:
    //                // return "10 &Minutes";
    //                return "10���� (&M)";

    //                // = 63
    //            case SchedulerStringId.MenuCmd_15Minutes:
    //                // return "&15 Minutes";
    //                return "15���� (&1)";

    //                // = 64
    //            case SchedulerStringId.MenuCmd_20Minutes:
    //                // return "&20 Minutes";
    //                return "20���� (&2)";

    //                // = 65
    //            case SchedulerStringId.MenuCmd_30Minutes:
    //                // return "&30 Minutes";
    //                return "30���� (&3)";

    //                // = 66
    //            case SchedulerStringId.MenuCmd_60Minutes:
    //                // return "6&0 Minutes";
    //                return "60���� (&6)";

    //                // = 67
    //            case SchedulerStringId.MenuCmd_SwitchViewMenu:
    //                // return "Change View To";
    //                return "�ı���ͼΪ";

    //                // = 68
    //            case SchedulerStringId.MenuCmd_SwitchToDayView:
    //                // return "&Day View";
    //                return "������ͼ (&D)";

    //                // = 69
    //            case SchedulerStringId.MenuCmd_SwitchToWorkWeekView:
    //                // return "Wo&rk Week View";
    //                return "����������ͼ (&R)";

    //                // = 70
    //            case SchedulerStringId.MenuCmd_SwitchToWeekView:
    //                // return "&Week View";
    //                return "������ͼ (&W)";

    //                // = 71
    //            case SchedulerStringId.MenuCmd_SwitchToMonthView:
    //                // return "&Month View";
    //                return "������ͼ (&M)";

    //                // = 72
    //            case SchedulerStringId.MenuCmd_ShowTimeAs:
    //                // return "&Show Time As";
    //                return "��ʾʱ��Ϊ (&S)";

    //                // = 73
    //            case SchedulerStringId.MenuCmd_Free:
    //                // return "&Free";
    //                return "���� (&F)";

    //                // = 74
    //            case SchedulerStringId.MenuCmd_Busy:
    //                // return "&Busy";
    //                return "æµ (&B)";

    //                // = 75
    //            case SchedulerStringId.MenuCmd_Tentative:
    //                // return "&Tentative";
    //                return "�ݶ� (&T)";

    //                // = 76
    //            case SchedulerStringId.MenuCmd_OutOfOffice:
    //                // return "&Out Of Office";
    //                return "���ڰ칫�� (&O)";

    //                // = 77
    //            case SchedulerStringId.MenuCmd_LabelAs:
    //                // return "&Label As";
    //                return "��עΪ (&L)";

    //                // = 78
    //            case SchedulerStringId.MenuCmd_AppointmentLabelNone:
    //                // return "&None";
    //                return "�� (&N)";

    //                // = 79
    //            case SchedulerStringId.MenuCmd_AppointmentLabelImportant:
    //                // return "&Important";
    //                return "��Ҫ (&I)";

    //                // = 80
    //            case SchedulerStringId.MenuCmd_AppointmentLabelBusiness:
    //                // return "&Business";
    //                return "���� (&B)";

    //                // = 81
    //            case SchedulerStringId.MenuCmd_AppointmentLabelPersonal:
    //                // return "&Personal";
    //                return "����(P)";

    //                // = 82
    //            case SchedulerStringId.MenuCmd_AppointmentLabelVacation:
    //                // return "&Vacation";
    //                return "�ݼ� (&V)";

    //                // = 83
    //            case SchedulerStringId.MenuCmd_AppointmentLabelMustAttend:
    //                // return "Must &Attend";
    //                return "�����ϯ (&A)";

    //                // = 84
    //            case SchedulerStringId.MenuCmd_AppointmentLabelTravelRequired:
    //                // return "&Travel Required";
    //                return "�������� (&T)";

    //                // = 85
    //            case SchedulerStringId.MenuCmd_AppointmentLabelNeedsPreparation:
    //                // return "&Needs Preparation";
    //                return "��Ҫ׼�� (&N)";

    //                // = 86
    //            case SchedulerStringId.MenuCmd_AppointmentLabelBirthday:
    //                // return "&Birthday";
    //                return "���� (&B)";

    //                // = 87
    //            case SchedulerStringId.MenuCmd_AppointmentLabelAnniversary:
    //                // return "&Anniversary";
    //                return "������� (&A)";

    //                // = 88
    //            case SchedulerStringId.MenuCmd_AppointmentLabelPhoneCall:
    //                // return "Phone &Call";
    //                return "ͨ�� (&P)";

    //                // = 89
    //            case SchedulerStringId.MenuCmd_AppointmentMove:
    //                // return "Mo&ve";
    //                return "�ƶ� (&V)";

    //                // = 90
    //            case SchedulerStringId.MenuCmd_AppointmentCopy:
    //                // return "&Copy";
    //                return "���� (&C)";

    //                // = 91
    //            case SchedulerStringId.MenuCmd_AppointmentCancel:
    //                // return "C&ancel";
    //                return "ȡ�� (&A)";

    //                // = 92
    //            case SchedulerStringId.Caption_5Minutes:
    //                // return "5 Minutes";
    //                return "5����";

    //                // = 93
    //            case SchedulerStringId.Caption_6Minutes:
    //                // return "6 Minutes";
    //                return "6����";

    //                // = 94
    //            case SchedulerStringId.Caption_10Minutes:
    //                // return "10 Minutes";
    //                return "10����";

    //                // = 95
    //            case SchedulerStringId.Caption_15Minutes:
    //                // return "15 Minutes";
    //                return "15����";

    //                // = 96
    //            case SchedulerStringId.Caption_20Minutes:
    //                // return "20 Minutes";
    //                return "20����";

    //                // = 97
    //            case SchedulerStringId.Caption_30Minutes:
    //                // return "30 Minutes";
    //                return "30����";

    //                // = 98
    //            case SchedulerStringId.Caption_60Minutes:
    //                // return "60 Minutes";
    //                return "60����";

    //                // = 99
    //            case SchedulerStringId.Caption_Free:
    //                // return "Free";
    //                return "����";

    //                // = 100
    //            case SchedulerStringId.Caption_Busy:
    //                // return "Busy";
    //                return "æµ";

    //                // = 101
    //            case SchedulerStringId.Caption_Tentative:
    //                // return "Tentative";
    //                return "�ݶ�";

    //                // = 102
    //            case SchedulerStringId.Caption_OutOfOffice:
    //                // return "Out Of Office";
    //                return "���ڰ칫��";

    //                // = 103
    //            case SchedulerStringId.ViewDisplayName_Day:
    //                // return "Day Calendar";
    //                return "����";

    //                // = 104
    //            case SchedulerStringId.ViewDisplayName_WorkDays:
    //                // return "Work Week Calendar";
    //                return "��������";

    //                // = 105
    //            case SchedulerStringId.ViewDisplayName_Week:
    //                // return "Week Calendar";
    //                return "����";

    //                // = 106
    //            case SchedulerStringId.ViewDisplayName_Month:
    //                // return "Month Calendar";
    //                return "����";

    //                // = 107
    //            case SchedulerStringId.Abbr_MinutesShort1:
    //                // return "m";
    //                return "��";

    //                // = 108
    //            case SchedulerStringId.Abbr_MinutesShort2:
    //                // return "min";
    //                return "��";

    //                // = 109
    //            case SchedulerStringId.Abbr_Minute:
    //                // return "minute";
    //                return "����";

    //                // = 110
    //            case SchedulerStringId.Abbr_Minutes:
    //                // return "minutes";
    //                return "����";

    //                // = 111
    //            case SchedulerStringId.Abbr_HoursShort:
    //                // return "h";
    //                return "ʱ";

    //                // = 112
    //            case SchedulerStringId.Abbr_Hour:
    //                // return "hour";
    //                return "Сʱ";

    //                // = 113
    //            case SchedulerStringId.Abbr_Hours:
    //                // return "hours";
    //                return "Сʱ";

    //                // = 114
    //            case SchedulerStringId.Abbr_DaysShort:
    //                // return "d";
    //                return "��";

    //                // = 115
    //            case SchedulerStringId.Abbr_Day:
    //                // return "day";
    //                return "��";

    //                // = 116
    //            case SchedulerStringId.Abbr_Days:
    //                // return "days";
    //                return "��";

    //                // = 117
    //            case SchedulerStringId.Abbr_WeeksShort:
    //                // return "w";
    //                return "��";

    //                // = 118
    //            case SchedulerStringId.Abbr_Week:
    //                // return "week";
    //                return "��";

    //                // = 119
    //            case SchedulerStringId.Abbr_Weeks:
    //                // return "weeks";
    //                return "��";

    //                // = 120
    //            case SchedulerStringId.Abbr_Month:
    //                // return "month";
    //                return "��";

    //                // = 121
    //            case SchedulerStringId.Abbr_Months:
    //                // return "months";
    //                return "����";

    //                // = 122
    //            case SchedulerStringId.Abbr_Year:
    //                // return "year";
    //                return "��";

    //                // = 123
    //            case SchedulerStringId.Abbr_Years:
    //                // return "years";
    //                return "��";

    //                // = 124
    //            case SchedulerStringId.Caption_Reminder:
    //                // return "{0} Reminder";
    //                return "{0} ����";

    //                // = 125
    //            case SchedulerStringId.Caption_Reminders:
    //                // return "{0} Reminders";
    //                return "{0} ����";

    //                // = 126
    //            case SchedulerStringId.Caption_StartTime:
    //                // return "Start time: {0}";
    //                return "��ʼʱ�䣺{0}";

    //                // = 127
    //            case SchedulerStringId.Caption_NAppointmentsAreSelected:
    //                // return "{0} appointments are selected";
    //                return "Լ�� {0} ��ѡ��";

    //                // = 128
    //            case SchedulerStringId.Format_TimeBeforeStart:
    //                // return "{0} before start";
    //                return "{0} ����ʼ֮ǰ";

    //                // = 129
    //            case SchedulerStringId.Msg_Conflict:
    //                // return "An edited appointment conflicts with one or several other appointments.";
    //                return "�༭���Լ��������һ������Լ����ֳ�ͻ��";

    //                // = 130
    //            case SchedulerStringId.Msg_InvalidAppointmentDuration:
    //                // return "Invalid value specified for the interval duration. Please enter a positive value.";
    //                return "��Ч�ĳ���ʱ�䡣������һ��������";

    //                // = 131
    //            case SchedulerStringId.Msg_InvalidReminderTimeBeforeStart:
    //                // return "Invalid value specified for the before event reminder's time. Please enter a positive value.";
    //                return "��Ч������ʱ�䡣������һ��������";

    //                // = 132
    //            case SchedulerStringId.TextDuration_FromTo:
    //                // return "from {0} to {1}";
    //                return "��{0}��{1}";

    //                // = 133
    //            case SchedulerStringId.TextDuration_FromForDays:
    //                // return "from {0} for {1} ";
    //                return "��{0}��ʼ ����{1}";

    //                // = 134
    //            case SchedulerStringId.TextDuration_FromForDaysHours:
    //                // return "from {0} for {1} {2}";
    //                return "��{0}��ʼ ����{1}{2}";

    //                // = 135
    //            case SchedulerStringId.TextDuration_FromForDaysMinutes:
    //                // return "from {0} for {1} {3}";
    //                return "��{0}��ʼ ����{1}{3}";

    //                // = 136
    //            case SchedulerStringId.TextDuration_FromForDaysHoursMinutes:
    //                // return "from {0} for {1} {2} {3}";
    //                return "��{0}��ʼ ����{1}{2}{3}";

    //                // = 137
    //            case SchedulerStringId.TextDuration_ForPattern:
    //                // return "{0} {1}";
    //                return "{0}{1}";

    //                // = 138
    //            case SchedulerStringId.TextDailyPatternString_EveryDay:
    //                // return "every {0} {1}";
    //                return "ÿ{0}{1}";

    //                // = 139
    //            case SchedulerStringId.TextDailyPatternString_EveryDays:
    //                // return "every {0} {1} {2}";
    //                return "ÿ{0}{1} {2}";

    //                // = 140
    //            case SchedulerStringId.TextDailyPatternString_EveryWeekDay:
    //                // return "every weekday {0}";
    //                return "ÿ������ {0}";

    //                // = 141
    //            case SchedulerStringId.TextDailyPatternString_EveryWeekend:
    //                // return "every weekend {0}";
    //                return "ÿ��ĩ {0}";

    //                // = 142
    //            case SchedulerStringId.TextWeekly_1Day:
    //                return "{0}";

    //                // = 143
    //            case SchedulerStringId.TextWeekly_2Day:
    //                // return "{0} and {1}";
    //                return "{0}��{1}";

    //                // = 144
    //            case SchedulerStringId.TextWeekly_3Day:
    //                // return "{0}, {1}, and {2}";
    //                return "{0}��{1}��{2}";

    //                // = 145
    //            case SchedulerStringId.TextWeekly_4Day:
    //                // return "{0}�� {1}�� {2}�� and {3}";
    //                return "{0}��{1}��{2}��{3}";

    //                // = 146
    //            case SchedulerStringId.TextWeekly_5Day:
    //                // return "{0}�� {1}�� {2}�� {3}�� and {4}";
    //                return "{0}��{1}��{2}��{3}��{4}";

    //                // = 147
    //            case SchedulerStringId.TextWeekly_6Day:
    //                // return "{0}�� {1}�� {2}�� {3}�� {4}�� and {5}";
    //                return "{0}��{1}��{2}��{3}��{4}��{5}";

    //                // = 148
    //            case SchedulerStringId.TextWeekly_7Day:
    //                // return "{0}�� {1}�� {2}�� {3}�� {4}�� {5}�� and {6}";
    //                return "{0}��{1}��{2}��{3}��{4}��{5}��{6}";

    //                // = 149
    //            case SchedulerStringId.TextWeeklyPatternString_EveryWeek:
    //                // return "every {2} {3}";
    //                return "ÿ{2} {3}";

    //                // = 150
    //            case SchedulerStringId.TextWeeklyPatternString_EveryWeeks:
    //                // return "every {0} {1} on {2} {3}";
    //                return "ÿ{0}{1} ��{2} {3}";

    //                // = 151
    //            case SchedulerStringId.TextMonthlyPatternString_SubPattern:
    //                // return "of every {0} {1} {2}";
    //                return "ÿ{0}{1} {2} ";

    //                // = 152
    //            case SchedulerStringId.TextMonthlyPatterString1:
    //                // return "day {0} {1}";
    //                return "{0}�� {1}";

    //                // = 153
    //            case SchedulerStringId.TextMonthlyPatterString2:
    //                // return "the {0} {1} {2}";
    //                return "{0} {1} {2}";

    //                // = 154
    //            case SchedulerStringId.TextYearlyPattern_YearString1:
    //                // return "every {0} {1} {4}";
    //                return "ÿ��{0}{1}�� {4}";

    //                // = 155
    //            case SchedulerStringId.TextYearlyPattern_YearString2:
    //                // return "the {0} {1} of {2} {5}";
    //                return "ÿ��{2}��{0}{1} {5}";

    //                // = 156
    //            case SchedulerStringId.TextYearlyPattern_YearsString1:
    //                // return "{0} {1} of every {2} {3} {4}";
    //                return "ÿ{2} {3} {4} �� {0} {1}";

    //                // = 157
    //            case SchedulerStringId.TextYearlyPattern_YearsString2:
    //                //return "the {0} {1} of {2} every {3} {4} {5}";
    //                return "ÿ{3} {4} {5}�� {2} �� {0} {1}";

    //                // = 158
    //            case SchedulerStringId.Caption_AllDay:
    //                // return "All day";
    //                return "ȫ��";

    //                // = 159
    //            case SchedulerStringId.Caption_PleaseSeeAbove:
    //                // return "Please see above";
    //                return "�뿴����";

    //                // = 160
    //            case SchedulerStringId.Caption_RecurrenceSubject:
    //                // return "Subject:";
    //                return "���⣺";

    //                // = 161
    //            case SchedulerStringId.Caption_RecurrenceLocation:
    //                // return "Location:";
    //                return "�ص㣺";

    //                // = 162
    //            case SchedulerStringId.Caption_RecurrenceStartTime:
    //                // return "Start:";
    //                return "��ʼ��";

    //                // = 163
    //            case SchedulerStringId.Caption_RecurrenceEndTime:
    //                // return "End:";
    //                return "������";

    //                // = 164
    //            case SchedulerStringId.Caption_RecurrenceShowTimeAs:
    //                // return "Show Time As:";
    //                return "��ʾʱ��Ϊ��";

    //                // = 165
    //            case SchedulerStringId.Caption_Recurrence:
    //                // return "Recurrence:";
    //                return "�����ԣ�";

    //                // = 166
    //            case SchedulerStringId.Caption_RecurrencePattern:
    //                // return "Recurrence Pattern:";
    //                return "����ģʽ��";

    //                // = 167
    //            case SchedulerStringId.Caption_NoneRecurrence:
    //                // return "(none)";
    //                return "(��)";

    //                // = 168
    //            case SchedulerStringId.MemoPrintDateFormat:
    //                return "{0} {1} {2}";

    //                // = 169
    //            case SchedulerStringId.Caption_EmptyResource:
    //                // return "(Any)";
    //                return "�κ�";

    //                // = 170
    //            case SchedulerStringId.Caption_DailyPrintStyle:
    //                // return "Daily Style";
    //                return "ÿ����ʽ";

    //                // = 171
    //            case SchedulerStringId.Caption_WeeklyPrintStyle:
    //                // return "Weekly Style";
    //                return "ÿ����ʽ";

    //                // = 172
    //            case SchedulerStringId.Caption_MonthlyPrintStyle:
    //                // return "Monthly Style";
    //                return "ÿ����ʽ";

    //                // = 173
    //            case SchedulerStringId.Caption_TrifoldPrintStyle:
    //                // return "Tri-fold Style";
    //                return "������ʽ";

    //                // = 174
    //            case SchedulerStringId.Caption_CalendarDetailsPrintStyle:
    //                // return "Calendar Details Style";
    //                return "������ϸ��ʽ";

    //                // = 175
    //            case SchedulerStringId.Caption_MemoPrintStyle:
    //                // return "Memo Style";
    //                return "����¼��ʽ";

    //                // = 176
    //            case SchedulerStringId.Caption_ColorConverterFullColor:
    //                // return "Full Color";
    //                return "ȫ��";

    //                // = 177
    //            case SchedulerStringId.Caption_ColorConverterGrayScale:
    //                // return "Gray Scale";
    //                return "�ҽ�";

    //                // = 178
    //            case SchedulerStringId.Caption_ColorConverterBlackAndWhite:
    //                // return "Black And White";
    //                return "�ڰ�";

    //                // = 179
    //            case SchedulerStringId.Caption_ResourceNone:
    //                // return "(None)";
    //                return "(��)";

    //                // = 180
    //            case SchedulerStringId.Caption_ResourceAll:
    //                // return "(All)";
    //                return "(����)";

    //                // = 181
    //            case SchedulerStringId.PrintPageSetupFormatTabControlCustomizeShading:
    //                // return "<Customize...>";
    //                return "<�Զ���...>";

    //                // = 182
    //            case SchedulerStringId.PrintPageSetupFormatTabControlSizeAndFontName:
    //                // return "{0} pt. {1}";
    //                return "{0} pt. {1}";

    //                // = 183
    //            case SchedulerStringId.PrintRangeControlInvalidDate:
    //                // return "End date must be greater or equals to start date";
    //                return "�������ڱ�����ڻ������ʼ����";

    //                // = 184
    //            case SchedulerStringId.PrintCalendarDetailsControlDayPeriod:
    //                // return "Day";
    //                return "��";

    //                // = 185
    //            case SchedulerStringId.PrintCalendarDetailsControlWeekPeriod:
    //                // return "Week";
    //                return "��";

    //                // = 186
    //            case SchedulerStringId.PrintCalendarDetailsControlMonthPeriod:
    //                // return "Month";
    //                return "�·�";

    //                // = 187
    //            case SchedulerStringId.PrintMonthlyOptControlOnePagePerMonth:
    //                // return "1 page/month";
    //                return "1ҳÿ��";

    //                // = 188
    //            case SchedulerStringId.PrintMonthlyOptControlTwoPagesPerMonth:
    //                // return "2 pages/month";
    //                return "2ҳÿ��";

    //                // = 189
    //            case SchedulerStringId.PrintTimeIntervalControlInvalidDuration:
    //                // return "Duration must be not greater than day and greater than 0";
    //                return "ʱ�����볬��һ���Ҵ���0";

    //                // = 190
    //            case SchedulerStringId.PrintTimeIntervalControlInvalidStartEndTime:
    //                // return "End time must be greater than start time";
    //                return "����ʱ����������ʼʱ��";

    //                // = 191
    //            case SchedulerStringId.PrintTriFoldOptControlDailyCalendar:
    //                // return "Daily Calendar";
    //                return "����";

    //                // = 192
    //            case SchedulerStringId.PrintTriFoldOptControlWeeklyCalendar:
    //                // return "Weekly Calendar";
    //                return "����";

    //                // = 193
    //            case SchedulerStringId.PrintTriFoldOptControlMonthlyCalendar:
    //                // return "Monthly Calendar";
    //                return "����";

    //                // = 194
    //            case SchedulerStringId.PrintWeeklyOptControlOneWeekPerPage:
    //                // return "1 page/week";
    //                return "1ҳÿ��";

    //                // = 195
    //            case SchedulerStringId.PrintWeeklyOptControlTwoWeekPerPage:
    //                // return "2 pages/week";
    //                return "2ҳÿ��";

    //                // = 196
    //            case SchedulerStringId.PrintPageSetupFormCaption:
    //                // return "Print Options: {0}";
    //                return "��ӡѡ��: {0}";

    //                // = 197
    //            case SchedulerStringId.PrintMoreItemsMsg:
    //                // return "More items...";
    //                return "������Ŀ...";

    //                // = 198
    //            case SchedulerStringId.PrintNoPrintersInstalled:
    //                // return "No printers installed";
    //                return "û�а�װ��ӡ��";

    //                // = 199
    //            case SchedulerStringId.Caption_IncreaseVisibleResourcesCount:
    //                // return "Increase visible resources count";
    //                return "���ӿɼ���Դ��";

    //                // = 200
    //            case SchedulerStringId.Caption_DecreaseVisibleResourcesCount:
    //                // return "Decrease visible resources count";
    //                return "���ٿɼ���Դ��";

    //                // = 201
    //            case SchedulerStringId.Caption_ShadingApplyToAllDayArea:
    //                // return "All Day Area";
    //                return "ȫ����";

    //                // = 202
    //            case SchedulerStringId.Caption_ShadingApplyToAppointments:
    //                // return "Appointments";
    //                return "Լ��";

    //                // = 203
    //            case SchedulerStringId.Caption_ShadingApplyToAppointmentStatuses:
    //                // return "Appointment statuses";
    //                return "Լ��״̬";

    //                // = 204
    //            case SchedulerStringId.Caption_ShadingApplyToHeaders:
    //                // return "Headers";
    //                return "����";

    //                // = 205
    //            case SchedulerStringId.Caption_ShadingApplyToTimeRulers:
    //                // return "Time Rulers";
    //                return "ʱ����";

    //                // = 206
    //            case SchedulerStringId.Caption_ShadingApplyToCells:
    //                // return "Cells";
    //                return "��Ԫ��";

    //                // = 207
    //            case SchedulerStringId.Msg_InvalidSize:
    //                // return "Invalid value specified for the size.";
    //                return "��Ч�ĳߴ�ֵ��";

    //                // = 208
    //            case SchedulerStringId.Msg_ApplyToAllStyles:
    //                // return "Apply current printer settings to all styles?";
    //                return "����ǰ�Ĵ�ӡ������Ӧ�õ�������ʽ��";

    //                // = 209
    //            case SchedulerStringId.Msg_MemoPrintNoSelectedItems:
    //                // return "Cannot print unless an item is selected. Select an item, and then try to print again.";
    //                return "δѡ����Ŀ�޷���ӡ��ѡ����ĿȻ���ٴγ��Դ�ӡ��";

    //                // = 210
    //            case SchedulerStringId.Caption_AllResources:
    //                // return "All resources";
    //                return "������Դ";

    //                // = 211
    //            case SchedulerStringId.Caption_VisibleResources:
    //                // return "Visible resources";
    //                return "�ɼ���Դ";

    //                // = 212
    //            case SchedulerStringId.Caption_OnScreenResources:
    //                // return "OnScreen resources";
    //                return "��Ļ��Դ";

    //                // = 213
    //            case SchedulerStringId.Caption_GroupByNone:
    //                // return "None";
    //                return "��";

    //                // = 214
    //            case SchedulerStringId.Caption_GroupByDate:
    //                // return "Date";
    //                return "����";

    //                // = 215
    //            case SchedulerStringId.Caption_GroupByResources:
    //                // return "Resources";
    //                return "��Դ";

    //                // = 216
    //            case SchedulerStringId.Msg_InvalidInputFile:
    //                // return "Input file is invalid";
    //                return "�����ļ���Ч";
    //        }

    //        return base.GetLocalizedString(id);
    //    }

    //    public override string Language
    //    {
    //        get
    //        {
    //            return "��������";
    //        }
    //    }
    //}

	public class XtraTreeListLocalizer : TreeListLocalizer
	{
		public override string GetLocalizedString(TreeListStringId id)
		{
			switch (id)
			{
					// = 0
				case TreeListStringId.MenuFooterSum:
					// return "Sum";
					return "�ϼ�";

					// = 1
				case TreeListStringId.MenuFooterMin:
					// return "Min";
					return "��Сֵ";

					// = 2
				case TreeListStringId.MenuFooterMax:
					// return "Max";
					return "���ֵ";

					// = 3
				case TreeListStringId.MenuFooterCount:
					// return "Count";
					return "����";

					// = 4
				case TreeListStringId.MenuFooterAverage:
					// return "Average";
					return "ƽ��";

					// = 5
				case TreeListStringId.MenuFooterNone:
					// return "None";
					return "��";

					// = 6
				case TreeListStringId.MenuFooterAllNodes:
					// return "AllNodes";
					return "ȫ���ڵ�";

					// = 7
				case TreeListStringId.MenuFooterSumFormat:
					// return "SUM={0:#.##}";
					return "�ϼ�={0:#.##}";

					// = 8
				case TreeListStringId.MenuFooterMinFormat:
					// return "MIN={0}";
					return "��Сֵ={0}";

					// = 9
				case TreeListStringId.MenuFooterMaxFormat:
					// return "MAX={0}";
					return "���ֵ={0}";

					// = 10
				case TreeListStringId.MenuFooterCountFormat:
					return "{0}";

					// = 11
				case TreeListStringId.MenuFooterAverageFormat:
					// return "AVR={0:#.##}";
					return "ƽ��ֵ={0:#.##}";

					// = 12
				case TreeListStringId.MenuColumnSortAscending:
					// return "Sort Ascending";
					return "����";

					// = 13
				case TreeListStringId.MenuColumnSortDescending:
					// return "Sort Descending";
					return "����";

					// = 14
				case TreeListStringId.MenuColumnColumnCustomization:
					// return "Column Chooser";
					return "ѡ����ʾ��";

					// = 15
				case TreeListStringId.MenuColumnBestFit:
					// return "Best Fit";
					return "�����п�";

					// = 16
				case TreeListStringId.MenuColumnBestFitAllColumns:
					// return "Best Fit (all columns)";
					return "���������п�";

					// = 17
				case TreeListStringId.ColumnCustomizationText:
					// return "Customization";
					return "ѡ����ʾ��";

					// = 18
				case TreeListStringId.ColumnNamePrefix:
					// return "col";
					return "�����ױ�";

					// = 19
				case TreeListStringId.PrintDesignerHeader:
					// return "Print Settings";
					return "��ӡ����";

					// = 20
				case TreeListStringId.PrintDesignerDescription:
					// return "Set up various printing options for the current treelist.";
					return "Ϊ��ǰ����״�б����ø��ֵĴ�ӡѡ��.";

					// = 21
				case TreeListStringId.InvalidNodeExceptionText:
					// return " Do you want to correct the value ?";
					return "�Ƿ�ȷ���޸�ֵ��";

					// = 22
				case TreeListStringId.MultiSelectMethodNotSupported:
					// return "Specified method will not work when OptionsBehavior.MultiSelect is inactive.";
					return "OptionsBehavior.MultiSelectδ����ʱ��ָ�������޷�������";
			}

			return base.GetLocalizedString(id);
		}

		public override string Language
		{
			get
			{
				return "��������";
			}
		}
	}

	public class XtraVerticalGridLocalizer : VGridLocalizer
	{
		public override string GetLocalizedString(VGridStringId id)
		{
			string text1 = string.Empty;
			switch (id)
			{
					// = 0
				case VGridStringId.RowCustomizationText:
					// return "Customization";
					return "�Զ���";

					// = 1
				case VGridStringId.RowCustomizationNewCategoryFormText:
					// return "New Category";
					return "�½����";

					// = 2
				case VGridStringId.RowCustomizationNewCategoryFormLabelText:
					// return "Caption:";
					return "����:";

					// = 3
				case VGridStringId.RowCustomizationNewCategoryText:
					// return "&New...";
					return "�½� (&N)...";

					// = 4
				case VGridStringId.RowCustomizationDeleteCategoryText:
					// return "&Delete";
					return "ɾ�� (&D)...";

					// = 5
				case VGridStringId.RowCustomizationTabPageCategoriesText:
					// return "Categories";
					return "���";

					// = 6
				case VGridStringId.RowCustomizationTabPageRowsText:
					// return "Rows";
					return "��";

					// = 7
				case VGridStringId.InvalidRecordExceptionText:
					// return " Do you want to correct the value ?";
					return "�Ƿ�ȷ���޸�ֵ��";

					// = 8
				case VGridStringId.StyleCreatorName:
					// return "customStyleCreator";
					return "�Զ�����ʽ";
			}

			return base.GetLocalizedString(id);
		}

		public override string Language
		{
			get
			{
				return "��������";
			}
		}

	}
}
