// =======================
// DevExpress 6.3.5 本地化
// =======================
// 
// 所有控件已汉化，
// 界面术语参考至Windows、Office、Visual Studio等专业大型软件和http://fosoyo.cnblogs.com/ 的V6.2.4本地化
//
// 已经是一个相当专业的汉化版本
// 
// By Shoppe Chung, http://blog.csdn.net/allisnew, 2007-05-04
// 任何疑问请在http://blog.csdn.net/allisnew 上留言。
//
//
//
//
// 如何使用:
// 将本文件加入您的工程，并把你程序中引用的控件的汉化调用拷贝至程序的最前面， 注释掉程序中没有引用的控件的汉化
// 
// 比如：
//  我的建议是将汉化调用放在 [STAThread] static void Main()中 Application.Run(new ...());之前
//	[STAThread]
//	static void Main() 
//	{
//      // 汉化XtraBars
//	    DevExpress.XtraBars.Localization.BarLocalizer.Active = new DevExpress.LocalizationCHS.XtraBarsLocalizer();
//      
//	    Application.Run(new frmMain());
//	}
//
//
// 各控件的汉化调用：
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
	// XtraBars工具栏的“自定义”对话框
	public class XtraBarsCustomizationLocalizer : CustomizationControl
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public XtraBarsCustomizationLocalizer()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
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
			// “自定义”对话框 - WindowCaption
			// 
			//this.WindowCaption = "自定义";
			// 
			// “自定义”对话框 - btClose
			// 
			this.btClose.Text = "关闭";

			// 
			// Tab页头 = tpToolbars
			// 
			this.tpToolbars.Text = "工具栏 (&B)";
			// 
			// Tab页头 = tpCommands
			// 
			this.tpCommands.Text = "命令 (&C)";
			// 
			// Tab页头 = tpOptions
			// 
			this.tpOptions.Text = "选项 (&O)";


			// ===== 以下是“工具栏”Tab页内的各个项
			// 
			// “工具栏”Tab页内 - lbToolbarCaption
			// 
			this.lbToolbarCaption.Text = "工具栏:";
			// 
			// “工具栏”Tab页内 - btNewBar
			// 
			this.btNewBar.Text = "新建 (&N)...";
			// 
			// “工具栏”Tab页内 - “新建”对话框
			//
			this.lbNBDlgCaption.Text = "工具栏名称:";
			this.btNBDlgOk.Text = "确定";
			this.btNBDlgCancel.Text = "取消";
			// 
			// “工具栏”Tab页内 - btRenameBar
			// 
			this.btRenameBar.Text = "重命名 (&E)...";
			// 
			// “工具栏”Tab页内 - btDeleteBar
			// 
			this.btDeleteBar.Text = "删除 (&D)";
			// 
			// “工具栏”Tab页内 - btResetBar
			// 
			this.btResetBar.Text = "重新设置 (&R)...";


			// ===== 以下是“命令”Tab页内的各个项
			// 
			// “命令”Tab页内 - lbCategoriesCaption
			// 
			this.lbCategoriesCaption.Text = "类别 (&G):";
			// 
			// “命令”Tab页内 - lbCommandsCaption
			// 
			this.lbCommandsCaption.Text = "命令 (&D):";
			// 
			// “命令”Tab页内 - lbDescCaption
			// 
			this.lbDescCaption.Text = "说明";


			// ===== 以下是“选项”Tab页内的各个项
			// 
			// “选项”Tab页内 - lbOptions_PCaption
			// 
			this.lbOptions_PCaption.Text = "个性化菜单和工具栏";
			// 
			// “选项”Tab页内 - lcbOptionsShowFullMenus
			// 
			this.cbOptionsShowFullMenus.Properties.Caption = "始终显示整个菜单";
			// 
			// “选项”Tab页内 - lcbOptions_showFullMenusAfterDelay
			// 
			this.cbOptions_showFullMenusAfterDelay.Properties.Caption = "鼠标指针短暂停留后显示整个菜单";
			// 
			// “选项”Tab页内 - lbtOptions_Reset
			// 
			this.btOptions_Reset.Text = "重设惯用数据 (&R)";
			// 
			// “选项”Tab页内 - llbOptions_Other
			// 
			this.lbOptions_Other.Text = "其它";
			// 
			// “选项”Tab页内 - lcbOptions_largeIcons
			// 
			this.cbOptions_largeIcons.Properties.Caption = "大图标 (&L)";
			// 
			// “选项”Tab页内 - lcbOptions_showTips
			// 
			this.cbOptions_showTips.Properties.Caption = "显示关于工具栏的屏幕提示 (&T)";
			// 
			// “选项”Tab页内 - lcbOptions_ShowShortcutInTips
			// 
			this.cbOptions_ShowShortcutInTips.Properties.Caption = "在屏幕提示中显示快捷键 (&H)";
			// 
			// “选项”Tab页内 - llbOptions_MenuAnimation
			// 
			this.lbOptions_MenuAnimation.Text = "菜单打开方式 (&M):";

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


	// XtraBars工具栏
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
					return "添加或删除按钮 (&A)";

					// = 2
				case BarString.ResetBar:
					return "是否确认要取消对 “{0}” 工具栏所做修改吗？";

					// = 3
				case BarString.ResetBarCaption:
					return "自定义";

					// = 4
				case BarString.ResetButton:
					return "重设工具栏 (&R)";

					// = 5
				case BarString.CustomizeButton:
					return "自定义 (&C)...";

					// = 6
				case BarString.ToolBarMenu:
					//					return "&Reset$&Delete$!&Name$!Defau&lt style$&Text Only (Always)$Text &Only (in Menus)$Image &and Text$!Begin a &Group$&Visible$&Most recently used";
					return "重设 (&R)$删除 (&D)$!名称 (&N)$!默认风格 (&L)$始终显示文本 (&T)$仅菜单中显示文本 (&O)$图象与文本 (&A)$!开始一组 (&G)$可见的 (&V)$最近常用的 (&M)";

					// = 7
				case BarString.ToolbarNameCaption:
					return "工具栏名称 (&T):";

					// = 8
				case BarString.NewToolbarCaption:
					return "新建工具栏";

					// = 9
				case BarString.NewToolbarCustomNameFormat:
					return "自定义 {0}";

					// = 10
				case BarString.RenameToolbarCaption:
					return "重命名工具栏";

					// = 11
				case BarString.CustomizeWindowCaption:
					return "自定义";

					// = 12
				case BarString.PopupMenuEditor:
					//return "Popup Menu Editor";
					return "弹出菜单编辑器";

					// = 13
				case BarString.MenuAnimationSystem:
					return "(系统默认值)";

					// = 14
				case BarString.MenuAnimationNone:
					return "无效果";

					// = 15
				case BarString.MenuAnimationSlide:
					return "滚动";

					// = 16
				case BarString.MenuAnimationFade:
					return "淡出";

					// = 17
				case BarString.MenuAnimationUnfold:
					return "展开";

					// = 18
				case BarString.MenuAnimationRandom:
					return "随机";

					// = 19
				case BarString.RibbonToolbarAbove:
					return "在功能区上方显示快速访问工具栏 (&P)";

					// = 20
				case BarString.RibbonToolbarBelow:
					return "在功能区下方显示快速访问工具栏 (&P)";

					// = 21
				case BarString.RibbonToolbarAdd:
					return "添加到快速访问工具栏 (&A)";

					// = 22
				case BarString.RibbonToolbarMinimizeRibbon:
					return "功能区最小化 (&N)";

					// = 23
				case BarString.RibbonToolbarRemove:
					return "从快速访问工具栏删除 (&R)";

					// = 24
				case BarString.RibbonGalleryFilter:
					return "所有组";

					// = 25
				case BarString.RibbonGalleryFilterNone:
					return "无";

					// = 26
				case BarString.BarUnassignedItems:
					//return "(Unassigned Items)";
					return "(未分配项)";

					// = 27
				case BarString.BarAllItems:
					//return "(All Items)";
					return "(所有项)";
			}

			return base.GetLocalizedString(id);
		}		

		public override string Language
		{
			get
			{
				return "简体中文";
			}
		}
	}

	
	// XtraCharts图表
	public class XtraChartsLocalizer : ChartLocalizer
	{
		public override string GetLocalizedString(ChartStringId id)
		{
			switch (id)
			{
					// = 0
				case ChartStringId.SeriesPrefix:
					return "序列 ";

					// = 1
				case ChartStringId.PalettePrefix:
					return "调色板 ";

					// = 2
				case ChartStringId.ArgumentMember:
					return "参数";

					// = 3
				case ChartStringId.ValueMember:
					return "数值";

					// = 4
				case ChartStringId.LowValueMember:
					return "低值";

					// = 5
				case ChartStringId.HighValueMember:
					return "高值";

					// = 6
				case ChartStringId.OpenValueMember:
					return "打开";

					// = 7
				case ChartStringId.CloseValueMember:
					return "关闭";

					// = 8
				case ChartStringId.DefaultDataFilterName:
					return "数据筛选器";

					// = 9
				case ChartStringId.DefaultChartTitle:
					return "图表标题";

					// = 10
				case ChartStringId.MsgSeriesViewDoesNotExist:
					return "{0} 序列不存在。";

					// = 11
				case ChartStringId.MsgEmptyArrayOfValues:
					return "值的数组为空。";

					// = 12
				case ChartStringId.MsgItemNotInCollection:
					return "集合没有包含指定项。";

					// = 13
				case ChartStringId.MsgIncorrectValue:
					return "不正确的值 \"{0}\" 赋给参数 \"{1}\"。";

					// = 14
				case ChartStringId.MsgIncompatiblePointType:
					return "点(Point) \"{0}\" 的类型不兼容比例(Scale) {1} 。";
					//return "The type of the "{0}" point isn't compatible with the {1} scale.";

					// = 15
				case ChartStringId.MsgIncompatibleArgumentDataMember:
					return "参数 \"{0}\" 的类型不兼容比例(Scale) {1} 。";
					//return "The type of the \"{0}\" argument data member isn't compatible with the {1} scale.";

					// = 16
				case ChartStringId.MsgIncompatibleValueDataMember:
					return "值 \"{0}\" 的类型不兼容比例(Scale) {1} 。";
					//return "The type of the \"{0}\" value data member isn't compatible with the {1} scale.";

					// = 17
				case ChartStringId.MsgDesignTimeOnlySetting:
					return "此属性不能在运行时设置。";

					// = 18
				case ChartStringId.MsgInvalidDataSource:
					return "无效的数据源类型(接口没有实现)。";
					//return "Invalid datasource type (no supported interfaces are implemented).";

					// = 19
				case ChartStringId.MsgIncorrectDataMember:
					//return "The datasource doesn't contain a datamember with the \"{0}\" name.";
					return "数据源没有包含名为 \"{0}\" 的数据成员。";

					// = 20
				case ChartStringId.MsgInvalidColorEachValue:
					//return "This view assumes that the ColorEach property is always set to \"{0}\".";
					return "此视图假定ColorEach属性始终设为 \"{0}\"。";

					// = 21
				case ChartStringId.MsgInvalidSortingKey:
					//return "It's impossible to set the sorting key's value to {0}.";
					return "不能将 {0} 设为排序的键值。";

					// = 22
				case ChartStringId.MsgInvalidFilterCondition:
					//return "The {0} condition can't be applied to the \"{1}\" data.";
					return "条件 {0} 不能应用于数据 {1}。";

					// = 23
				case ChartStringId.MsgIncorrectDataAdapter:
					//return "The {0} object isn't a data adapter.";
					return "对象 {0} 不是数据适配器。";

					// = 24
				case ChartStringId.MsgDataSnapshot:
					//return "The data snapshot is complete. All series data now statically persist in the chart. Note, this also means that the chart is now in unbound mode.";
					return "数据快照已完成。注意，所有序列的数据仍在图表中，图表处于未绑定模式。";

					// = 25
				case ChartStringId.MsgModifyDefaultPaletteError:
					// return "The palette is default and then can't be modified.";
					return "默认调色板不能修改。";

					// = 26
				case ChartStringId.MsgAddExistingPaletteError:
					//return "The palette with the {0} name already exists in the repository.";
					return "调色板 {0} 已在调色板库中。";

					// = 27
				case ChartStringId.MsgInternalPropertyChangeError:
					//return "This property is intended for internal use only. You're not allowed to change its value.";
					return "此属性仅供内部使用，其值不允许修改。";

					// = 28
				case ChartStringId.MsgPaletteNotFound:
					//return "The chart doesn't contain a palette with the {0} name.";
					return "图表没有包含调色板 {0}。";

					// = 29
				case ChartStringId.MsgLabelSettingRuntimeError:
					//return "The \"Label\" property can't be set at runtime.";
					return "\"Label\"属性不能在运行时设置。";

					// = 30
				case ChartStringId.MsgPointOptionsSettingRuntimeError:
					//return "The \"PointOptions\" property can't be set at runtime.";
					return "\"PointOptions\"属性不能在运行时设置。";

					// = 31
				case ChartStringId.MsgIncorrectAxisRange:
					//return "The min value of the axis range ({0}) should be less than its max value ({1}).";
					return "轴的范围的最小值({0})应小于它的最大值({1})。";

					// = 32
				case ChartStringId.MsgIncorrectNumericPrecision:
					//return "The precision should be greater than or equal to 0.";
					return "精度(Precision)应大于等于0。";

					// = 33
				case ChartStringId.MsgIncorrectAxisThickness:
					//return "The axis thickness should be greater than 0.";
					return "轴宽度应大于0。";

					// = 34
				case ChartStringId.MsgIncorrectBarWidth:
					//return "The bar width should be greater than 0.";
					return "柱宽度应大于0。";

					// = 35
				case ChartStringId.MsgIncorrectBarDepth:
					//return "The bar depth should be greater than 0.";
					return "柱高度应大于0。";

					// = 36
				case ChartStringId.MsgIncorrectBorderThickness:
					//return "The border width should be greater than 0.";
					return "边框宽度应大于0。";

					// = 37
				case ChartStringId.MsgIncorrectChartTitleIndent:
					//return "The title indent should be greater than or equal to 0 and less than 1000.";
					return "标题的缩进应大于等于0，小于1000。";

					// = 38
				case ChartStringId.MsgIncorrectLegendMarkerSize:
					//return "The legend marker size should be greater than 0 and less than 1000.";
					return "图例的尺寸应大于0，小于1000。";

					// = 39
				case ChartStringId.MsgIncorrectLegendSpacingVertical:
					//return "The legend vertical spacing should be greater than or equal to 0 and less than 1000.";
					return "图例垂直间距应大于等于0，小于1000。";

					// = 40
				case ChartStringId.MsgIncorrectLegendSpacingHorizontal:
					//return "The legend horizontal spacing should be greater than or equal to 0 and less than 1000.";
					return "图例水平间距应大于等于0，小于1000。";

					// = 41
				case ChartStringId.MsgIncorrectMarkerSize:
					//return "The marker size should be greater than 1.";
					return "标记的尺寸应大于1。";

					// = 42
				case ChartStringId.MsgIncorrectMarkerStarPointCount:
					//return "The number of star points should be greater than 3 and less than 101.";
					return "点的数目应大于3，小于101。";

					// = 43
				case ChartStringId.MsgIncorrectPieSeriesLabelColumnIndent:
					//return "The column indent should be greater than or equal to 0.";
					return "柱的缩进应大于等于0。";

					// = 44
				case ChartStringId.MsgIncorrectRangeBarSeriesLabelIndent:
					//return "The indent should be greater than or equal to 0.";
					return "缩进应大于等于0。";

					// = 45
				case ChartStringId.MsgIncorrectPercentPrecision:
					//return "The precision of the percent value should be greater than 0.";
					return "百分数的精度(Precision)应大于0。";

					// = 46
				case ChartStringId.MsgIncorrectSeriesLabelLineLength:
					//return "The line length should be greater than or equal to 0 and less than 1000.";
					return "线的长度应大于等于0，小于1000。";

					// = 47
				case ChartStringId.MsgIncorrectStripConstructorParameters:
					//return "The minimum and maximum limits of the Strip can not be the same.";
					return "带(Strip)的最小最大限制不能一样。";

					// = 48
				case ChartStringId.MsgIncorrectStripLimitAxisValue:
					//return "The AxisValue property cannot be set to null for the StripLimit object.";
					return "StripLimit对象的AxisValue不能设为空。";

					// = 49
				case ChartStringId.MsgIncorrectStripMinLimit:
					//return "The min limit of the strip should be less than the max limit.";
					return "带(Strip)的最小限制应小于最大限制。";

					// = 50
				case ChartStringId.MsgIncorrectStripMaxLimit:
					//return "The max limit of the strip should be greater than the min limit.";
					return "带(Strip)的最大限制应大于最小限制。";

					// = 51
				case ChartStringId.MsgIncorrectLineThickness:
					//return "The line thickness should be greater than 0.";
					return "线宽度应大于0。";

					// = 52
				case ChartStringId.MsgIncorrectShadowSize:
					//return "The shadow size should be greater than 0.";
					return "阴影尺寸应大于0。";

					// = 53
				case ChartStringId.MsgIncorrectTickmarkThickness:
					//return "The tickmark thickness should be greater than 0.";
					return "刻度线宽度应大于0。";

					// = 54
				case ChartStringId.MsgIncorrectTickmarkLength:
					//return "The tickmark length should be greater than 0.";
					return "刻度线长度应大于0。";

					// = 55
				case ChartStringId.MsgIncorrectTickmarkMinorThickness:
					//return "The thickness of the minor tickmark should be greater than 0.";
					return "短刻度线宽度应大于0。";

					// = 56
				case ChartStringId.MsgIncorrectTickmarkMinorLength:
					//return "The length of the minor tickmark should be greater than 0.";
					return "短刻度线长度应大于0。";

					// = 57
				case ChartStringId.MsgIncorrectMinorCount:
					//return "The number of minor count should be greater than 0 and less than 100.";
					return "短刻度线的数目度应大于0。";

					// = 58
				case ChartStringId.MsgIncorrectPercentValue:
					//return "The percent value should be greater than or equal to 0 and less than or equal to 100.";
					return "百分数的值应大于等于0，小于等于100。";

					// = 59
				case ChartStringId.MsgIncorrectSimpleDiagramDimension:
					//return "The dimension of the simple diagram should be greater than 0 and less than 100.";
					return "简单图表的尺寸应大于0，小于100。";

					// = 60
				case ChartStringId.MsgIncorrectStockLevelLineLengthValue:
					//return "The stock level line length value should be greater than or equal to 0.";
					return "股票的水平线长度应大于等于0。";

					// = 61
				case ChartStringId.MsgIncorrectReductionColorValue:
					//return "The reduction color value can't be empty.";
					return "颜色降低值不能为空。";

					// = 62
				case ChartStringId.MsgIncorrectLabelAngle:
					//return "The angle of the label should be greater than or equal to -360 and less than or equal to 360.";
					return "标签的角度应大于等于-360度，小于等于360度。";

					// = 63
				case ChartStringId.MsgIncorrectImageBounds:
					//return "Can't create an image for the specified size.";
					return "不能创建指定尺寸的图像。";

					// = 64
                //case ChartStringId.MsgInternalFile:
                //    //return "The specified file is an internal file of the project and can't be used.";
                //    return "指定文件是工程的内部文件，不能使用。";

					// = 65
				case ChartStringId.MsgIncorrectUseImageProperty:
					//return "Image property can't be used for the WebChartControl. Please, use the ImageUrl property instead.";
					return "Image属性不能用在WebChartControl控件上，请用ImageUrl属性代替。";

					// = 66
				case ChartStringId.MsgIncorrectUseImageUrlProperty:
					//return "ImageUrl property can be used for the WebChartControl only. Please, use the Image property instead.";
					return "ImageUrl属性只能用在WebChartControl控件上，请用Image属性代替。";

					// = 67
				case ChartStringId.MsgIncorrectSeriesDistance:
					//return "The series distance should be greater than or equal to 0.";
					return "序列之间的距离应大于等于0。";

					// = 68
				case ChartStringId.MsgIncorrectSeriesDistanceFixed:
					//return "The fixed series distance should be greater than or equal to 0.";
					return "固定序列之间的距离应大于等于0。";

					// = 69
				case ChartStringId.MsgIncorrectSeriesIndentFixed:
					//return "The fixed series indent should be greater than or equal to 0.";
					return "固定序列的缩进应大于等于0。";

					// = 70xxxx
				case ChartStringId.MsgIncorrectPlaneDepthFixed:
					return "The fixed plane depth should be greater than or equal to 1.";

					// = 71
				case ChartStringId.MsgIncorrectBarDistanceFixed:
					//return "The fixed bar distance should be greater than or equal to 0.";
					return "固定柱之间的距离应大于等于0。";

					// = 72
				case ChartStringId.MsgIncorrectBarDistance:
					//return "The bar distance should be greater than or equal to 0.";
					return "柱之间的距离应大于等于0。";

					// = 73
				case ChartStringId.MsgArgumentSerializationError:
					//return "The argument of the series point can't be serialized correctly.";
					return "点序列的参数不能正确地序列化。";

					// = 74
				case ChartStringId.MsgArgumentDeserializationError:
					//return "The argument of the series point can't be deserialized correctly.";
					return "点序列的参数不能正确地反序列化。";

					// = 75
				case ChartStringId.MsgMinMaxDifferentTypes:
					//return "The types of the MinValue and MaxValue don't match.";
					return "MinValue和MaxValue的类型不匹配。";

					// = 76
				case ChartStringId.MsgEmptyArgument:
					//return "An argument can't be empty.";
					return "参数不能为空。";

					// = 77
				case ChartStringId.MsgIncorrectImageFormat:
					//return "Impossible to export a chart to the specified image format.";
					return "不能将图表导出为指定的图像格式。";

					// = 78
				case ChartStringId.MsgIncorrectValueDataMemberCount:
					//return "It's necessary to specify {0} value data members for the current series view.";
					return "必须指定当前序列视图 {0} 的值成员。";

					// = 79
				case ChartStringId.MsgPaletteEditingIsntAllowed:
					//return "Editing isn't allowed !";
					return "不允许编辑！";

					// = 80
				case ChartStringId.MsgPaletteDoubleClickToEdit:
					//return "Double-click to edit...";
					return "双击进行编辑...";

					// = 81
				case ChartStringId.MsgInvalidPaletteName:
					//return "Can't add a palette which has an empty name (\"\") to the palette repository. Please, specify a name for the palette.";
					return "不能将空名称\"\"的调色板加入到调色板库中，请指定其名称。";

					// = 82
				case ChartStringId.MsgInvalidScaleType:
					//return "The specified value to convert to the scale's internal representation isn't compatible with the current scale type.";
					return "转换的指定值在内部表示上不兼容当前的比例(Scale)类型。";

					// = 83
				case ChartStringId.MsgIncorrectTransformationMatrix:
					//return "Incorrect transformation matrix.";
					return "不正确的变换矩阵。";

					// = 84
				case ChartStringId.MsgIncorrectPerspectiveAngle:
					//return "The perspective angle should be greater than or equal to 0 and less than 180.";
					return "透视角应大于等于0度，小于180度。";

					// = 85
				case ChartStringId.MsgIncorrectPieDepth:
					//return "The pie depth should be greater than 0 and less than or equal to 100, since its value is measured in percents.";
					return "饼高度应大于等于0，小于100，因为它的值使用百分比衡量的。";

					// = 86
				case ChartStringId.MsgIncorrectGridSpacing:
					//return "The grid spacing should be greater than 0.";
					return "格的间距(Spacing)应大于0。";

					// = 87
				case ChartStringId.MsgIncompatibleValueScaleType:
					//return "The {0} scale type is incompatble with the {1} series view.";
					return "{0} 的比例(Scale)类型不兼容序列视图 {1}。";

					// = 88
				case ChartStringId.MsgIncorrectConstantLineAxisValue:
					//return "AxisValue can't be set to null for the ConstantLine object.";
					return "ConstantLine对象的AxisValue不能设为空。";

					// = 89
				case ChartStringId.MsgIncorrectCustomAxisLabelAxisValue:
					//return "AxisValue can't be set to null for the CustomAxisLabel object.";
					return "CustomAxisLabel对象的AxisValue不能设为空。";

					// = 90
				case ChartStringId.MsgIncorrectAxisRangeMinValue:
					//return "MinValue can't be set to null for the AxisRange object.";
					return "AxisRange对象的MinValue不能设为空。";

					// = 91
				case ChartStringId.MsgIncorrectAxisRangeMaxValue:
					//return "MaxValue can't be set to null for the AxisRange object.";
					return "AxisRange对象的MaxValue不能设为空。";

					// = 92
				case ChartStringId.Msg3DRotationToolTip:
					//return "Use Ctrl with the left mouse button\r\nto rotate the chart's diagram.";
					return "控制鼠标的左键来旋转图表。";

					// = 93
				case ChartStringId.MsgIncorrectPadding:
					//return "The padding should be greater than or equal to 0.";
					return "衬垫(padding)应大于等于0。";

					// = 94
				case ChartStringId.MsgIncorrectTaskLinkMinIndent:
					//return "The task link's minimum indent should be greater than or equal to 0.";
					return "任务链接的最小缩进应大于等于0。";

					// = 95
				case ChartStringId.MsgIncorrectArrowWidth:
					//return "The arrow width should be always odd and greater than 0.";
					return "箭头宽度应始终是奇数并大于0。";

					// = 96
				case ChartStringId.MsgIncorrectArrowHeight:
					//return "The arrow height should be greater than 0.";
					return "箭头高度应大于0。";

					// = 97
				case ChartStringId.MsgInvalidZeroAxisAlignment:
					//return "The Alignment can't be set to Alignment.Zero for the secondary axis.";
					return "次轴的Alignment不能设为Alignment.Zero。";

					// = 98
				case ChartStringId.MsgNullSeriesViewAxisX:
					//return "The series view's X-axis can't be set to null.";
					return "序列视图的X轴不能设为空。";

					// = 99
				case ChartStringId.MsgNullSeriesViewAxisY:
					//return "The series view's Y-axis can't be set to null.";
					return "序列视图的Y轴不能设为空。";

					// = 100
				case ChartStringId.MsgNonExistentSeriesViewAxisX:
					//return "Can't set the series view's X-axis, because the specified secondary axis isn't contained in the diagram's collection of secondary X-axes.";
					return "不能设置序列的X轴，因为指定的次轴没有包含在图的X次轴集合中。";

					// = 101
				case ChartStringId.MsgNonExistentSeriesViewAxisY:
					//return "Can't set the series view's Y-axis, because the specified secondary axis isn't contained in the diagram's collection of secondary Y-axes.";
					return "不能设置序列的Y轴，因为指定的次轴没有包含在图的Y次轴集合中。";

					// = 102
				case ChartStringId.MsgIncorrectSeriesViewAxisX:
					//return "Can't set the series view's X-axis, because the specified axis isn't the primary X-axis of the chart's diagram, or isn't the primary axis at all.";
					return "不能设置序列的X轴，因为指定的轴不是图的X主轴，或者根本不是主轴。";

					// = 103
				case ChartStringId.MsgIncorrectSeriesViewAxisY:
					//return "Can't set the series view's Y-axis, because the specified axis isn't the primary Y-axis of the chart's diagram, or isn't the primary axis at all.";
					return "不能设置序列的Y轴，因为指定的轴不是图的Y主轴，或者根本不是主轴。";

					// = 104
				case ChartStringId.MsgIncorrectParentSeriesPointOwner:
					//return "Owner of the parent series point can't be null and must be of the Series type.";
					return "父序列点的所有者不能为空且必须是序列类型(Series)。";

					// = 105
				case ChartStringId.MsgSeriesViewNotSupportRelations:
					//return "This series view doesn't support relations.";
					return "序列视图不支持关联。";

					// = 106
				case ChartStringId.MsgIncorrectChildSeriesPointOwner:
					//return "Owner of the child series point can't be null and must be of the Series type.";
					return "子序列点的所有者不能为空且必须是序列类型(Series)。";

					// = 107
				case ChartStringId.MsgIncorrectChildSeriesPointID:
					//return "Child series point's ID must be positive or equal to zero.";
					return "子序列点的ID必须是正数或0。";

					// = 108
				case ChartStringId.MsgIncorrectSeriesOfParentAndChildPoints:
					//return "Parent and child points must belong to the same series.";
					return "父序列点和子序列点的ID必须属于同一个序列。";

					// = 109
				case ChartStringId.MsgSelfRelatedSeriesPoint:
					//return "Series point can't have a relation to itself.";
					return "序列点不能关联自己。";

					// = 110
				case ChartStringId.MsgSeriesPointRelationAlreadyExists:
					//return "The SeriesPointRelations collection already contains this relation.";
					return "SeriesPointRelations 集合已经包含此关联。";

					// = 111
				case ChartStringId.MsgChildSeriesPointNotExist:
					//return "Child series point with ID equal to {0} doesn't exist.";
					return "ID为 {0} 的子序列点不存在。";

					// = 112
				case ChartStringId.MsgRelationChildPointIDNotUnique:
					//return "Relation's ChildPointID must be unique.";
					return "关联的子序列点ID必须唯一。";

					// = 113
				case ChartStringId.MsgSeriesPointIDNotUnique:
					//return "Series point's ID must be unique.";
					return "序列点ID必须唯一。";

					// = 114
				case ChartStringId.MsgIncorrectFont:
					//return "Font can't be null.";
					return "字体不能为空。";

					// = 115
				case ChartStringId.MsgCalcHitInfoNotSupported:
					//return "Hit testing for 3D Chart Types isn't supported. So, this method is supported for 2D Chart Types only.";
					return "3D图表类型不支持Hit Test，2D图表支持。";

					// = 116
				case ChartStringId.VerbAbout:
					//return "About";
					return "关于";

					// = 117
				case ChartStringId.VerbAboutDescription:
					//return "Shows basic information on the XtraCharts product.";
					return "在XtraCharts产品上显示基本信息。";

					// = 118
				case ChartStringId.VerbPopulate:
					//return "Populate";
					return "装载";

					// = 119
				case ChartStringId.VerbPopulateDescription:
					//return "Populates the chart's datasource with data.";
					return "装载图表数据源。";

					// = 120
				case ChartStringId.VerbClearDataSource:
					//return "Clear datasource";
					return "清除数据源";

					// = 121
				case ChartStringId.VerbClearDataSourceDescription:
					//return "Clears the chart's datasource.";
					return "清除图表数据源。";

					// = 122
				case ChartStringId.VerbDataSnapshot:
					//return "Data snapshot";
					return "数据快照";

					// = 123
				case ChartStringId.VerbDataSnapshotDescription:
					//return "Copies all the data from the bound datasource to the chart, and then unbinds the datasource.";
					return "从绑定数据源拷贝数据到图表，再解绑数据源。";

					// = 124
				case ChartStringId.VerbSeries:
					//return "Series...";
					return "序列...";

					// = 125
				case ChartStringId.VerbSeriesDescription:
					//return "Opens the Series Collection Editor.";
					return "打开序列集合的编辑器。";

					// = 126
				case ChartStringId.VerbEditPalettes:
					//return "Edit palettes...";
					return "编辑调色板...";

					// = 127
				case ChartStringId.VerbEditPalettesDescription:
					//return "Opens the Palettes Editor.";
					return "打开调色板编辑器。";

					// = 128
				case ChartStringId.VerbWizard:
					//return "Wizard...";
					return "向导...";

					// = 129
				case ChartStringId.VerbWizardDescription:
					//return "Runs the Chart Wizard, which allows the properties of the chart to be edited.";
					return "运行图表向导来编辑图表属性。";

					// = 130
				case ChartStringId.PieIncorrectValuesText:
					//return "The Pie view can't represent negative\r\nvalues. All values must be either greater\r\nthan or equal to zero.";
					return "饼图不能描绘负数。所有值必须大于等于0。";

					// = 131
				case ChartStringId.FontFormat:
					return "{0}, {1}pt, {2}";

					// = 132
				case ChartStringId.TrnSeriesChanged:
					//return "Series changed";
					return "序列已更改";

					// = 133
				case ChartStringId.TrnDataFiltersChanged:
					//return "DataFilters changed";
					return "数据筛选器已更改";

					// = 134
				case ChartStringId.TrnValueDataMembersChanged:
					//return "ValueDataMembers changed";
					return "数据值项已更改";

					// = 135
				case ChartStringId.TrnChartTitlesChanged:
					//return "Chart titles changed";
					return "图表标题已更改";

					// = 136
				case ChartStringId.TrnPalettesChanged:
					//return "Palettes changed";
					return "调色板已更改";

					// = 137
				case ChartStringId.TrnConstantLinesChanged:
					//return "Constant Lines changed";
					return "恒线(Constant Lines)已更改";

					// = 138
				case ChartStringId.TrnStripsChanged:
					//return "Strips changed";
					return "带(Strips)已更改";

					// = 139
				case ChartStringId.TrnCustomAxisLabelChanged:
					//return "Custom Axis Labels changed";
					return "自定义轴标签已更改";

					// = 140
				case ChartStringId.TrnSecondaryAxesXChanged:
					//return "Secondary axes X changed";
					return "X次轴已更改";

					// = 141
				case ChartStringId.TrnSecondaryAxesYChanged:
					//return "Secondary axes Y changed";
					return "Y次轴已更改";

					// = 142
				case ChartStringId.TrnChartWizard:
					//return "Chart wizard settings applied";
					return "图表向导设置已应用";

					// = 143
				case ChartStringId.TrnSeriesDeleted:
					//return "Series deleted";
					return "序列已删除";

					// = 144
				case ChartStringId.TrnChartTitleDeleted:
					//return "Chart title deleted";
					return "图表标题已删除";

					// = 145
				case ChartStringId.TrnConstantLineDeleted:
					//return "Constant line deleted";
					return "恒线(Constant Lines)已删除";

					// = 146
				case ChartStringId.TrnSecondryAxisXDeleted:
					//return "Secondary axis X deleted";
					return "X次轴已删除";

					// = 147
				case ChartStringId.TrnSecondryAxisYDeleted:
					//return "Secondary axis Y deleted";
					return "Y次轴已删除";

					// = 148
				case ChartStringId.AxisXDefaultTitle:
					//return "Axis of arguments";
					return "参数轴";

					// = 149
				case ChartStringId.AxisYDefaultTitle:
					//return "Axis of values";
					return "值轴";

					// = 150
				case ChartStringId.DefaultMinValue:
					//return "Min";
					return "最小";

					// = 151
				case ChartStringId.DefaultMaxValue:
					//return "Max";
					return "最大";

					// = 152
				case ChartStringId.MenuItemAdd:
					//return "Add";
					return "添加";

					// = 153
				case ChartStringId.MenuItemInsert:
					//return "Insert";
					return "插入";

					// = 154
				case ChartStringId.MenuItemDelete:
					//return "Delete";
					return "删除";

					// = 155
				case ChartStringId.MenuItemClear:
					//return "Clear";
					return "清空";

					// = 156
				case ChartStringId.MenuItemMoveUp:
					//return "Move Up";
					return "上移";

					// = 157
				case ChartStringId.MenuItemMoveDown:
					//return "Move Down";
					return "下移";

					// = 158
				case ChartStringId.WizBarSeriesLabelPositionTop:
					//return "Top";
					return "顶部";

					// = 159
				case ChartStringId.WizBarSeriesLabelPositionCenter:
					//return "Center";
					return "居中";

					// = 160
				case ChartStringId.WizPieSeriesLabelPositionInside:
					//return "Inside";
					return "内部";

					// = 161
				case ChartStringId.WizPieSeriesLabelPositionOutside:
					//return "Outside";
					return "外部";

					// = 162
				case ChartStringId.WizPieSeriesLabelPositionTwoColumns:
					//return "Two Columns";
					return "两列";

					// = 163
				case ChartStringId.WizBoundSeries:
					//return "Bound Series";
					return "绑定序列";

					// = 164
				case ChartStringId.WizSeriesLabelDefaultText:
					//return "<empty>";
					return "<空>";

					// = 165
				case ChartStringId.WizAddProjectDataSource:
					//return "Add New Data Source...";
					return "添加新数据源...";

					// = 166
				case ChartStringId.WizNullDataSourceConfirmation:
					//return "After setting the DataSource to null, all information on the bound series will be lost. Are you sure you want to proceed?";
					return "数据源设为空后，绑定序列所有信息将丢失。你确定要继续？";

					// = 167
				case ChartStringId.WizCurrentAppearance:
					//return "Current Appearance";
					return "当前外观";

					// = 168
				case ChartStringId.WizNoSuitableData:
					//return "No data suitable for creating series points has been found.";
					return "没有数据适合创建点序列。";

					// = 169
				case ChartStringId.SvnSideBySideBar:
					//return "Bar";
					return "柱状饼图";

					// = 170
				case ChartStringId.SvnStackedBar:
					//return "Bar Stacked";
					return "叠加柱状饼图";

					// = 171
				case ChartStringId.SvnFullStackedBar:
					//return "Bar Stacked 100%";
					return "100%叠加柱状饼图";

					// = 172
				case ChartStringId.SvnPie:
					//return "Pie";
					return "饼图";

					// = 173
				case ChartStringId.SvnPoint:
					//return "Point";
					return "散点图";

					// = 174
				case ChartStringId.SvnLine:
					//return "Line";
					return "折线图";

					// = 175
				case ChartStringId.SvnStepLine:
					//return "Step Line";
					return "阶梯线图";

					// = 176
				case ChartStringId.SvnArea:
					//return "Area";
					return "区域图";

					// = 177
				case ChartStringId.SvnStackedArea:
					//return "Area Stacked";
					return "叠加区域图";

					// = 178
				case ChartStringId.SvnFullStackedArea:
					//return "Area Stacked 100%";
					return "100%叠加区域图";

					// = 179
				case ChartStringId.SvnStock:
					//return "Stock";
					return "股票图";

					// = 180
				case ChartStringId.SvnCandleStick:
					//return "Candle Stick";
					return "蜡烛柱图";

					// = 181
				case ChartStringId.SvnSideBySideRangeBar:
					//return "Side By Side Range Bar";
					return "连续并排柱状图";

					// = 182
				case ChartStringId.SvnOverlappedRangeBar:
					//return "Range Bar";
					return "并排柱状图";

					// = 183
				case ChartStringId.SvnSideBySideGantt:
					//return "Side By Side Gantt";
					return "连续甘特图";

					// = 184
				case ChartStringId.SvnOverlappedGantt:
					//return "Gantt";
					return "甘特图";

					// = 185
				case ChartStringId.SvnManhattanBar:
					//return "Manhattan Bar";
					return "Manhattan柱状图";

					// = 186
				case ChartStringId.SvnPie3D:
					//return "Pie 3D";
					return "3D饼图";

					// = 187
				case ChartStringId.IncompatibleSeriesView:
					//return "(incompatible)";
					return "(不兼容)";

					// = 188
				case ChartStringId.InvisibleSeriesView:
					//return "(invisible)";
					return "(不可见)";

					// = 189
				case ChartStringId.IncompatibleSeriesHeader:
					//return "This series is incompatible:\r\n";
					return "此序列不兼容：\r\n";

					// = 190xxxx
				case ChartStringId.IncompatibleSeriesMessage:
					return "by {0} with \"{1}\"";

					// = 191
				case ChartStringId.PrimaryAxisXName:
					//return "PrimaryAxisX";
					return "X主轴";

					// = 192
				case ChartStringId.PrimaryAxisYName:
					//return "PrimaryAxisY";
					return "Y主轴";

					// = 193
				case ChartStringId.IOCaption:
					//return "Illegal Operation";
					return "非法操作";

					// = 194
				case ChartStringId.IODeleteAxis:
					//return "The primary axis can't be deleted. If you want to hide it, set its Visible property to false.";
					return "不能删除主轴。可通过将Visible属性设为false来隐藏它。";
			}

			return base.GetLocalizedString(id);
		}

		public override string Language
		{
			get
			{
				return "简体中文";
			}
		}
	}


	// XtraEditors基本编辑项
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
					return "错误";

					// = 2
				case StringId.InvalidValueText:
					// return "Invalid Value";
					return "无效值";

					// = 3
				case StringId.CheckChecked:
					// return "Checked";
					return "已选中";

					// = 4
				case StringId.CheckUnchecked:
					// return "Unchecked";
					return "未选中";

					// = 5
				case StringId.CheckIndeterminate:
					// return "Indeterminate";
					return "未选定";

					// = 6
				case StringId.DateEditToday:
					// return "Today";
					return "今天";

					// = 7
				case StringId.DateEditClear:
					// return "Clear";
					return "清除";

					// = 8
				case StringId.OK:
					// return "&OK";
					return "确定 (&O)";

					// = 9
				case StringId.Cancel:
					// return "&Cancel";
					return "取消 (&C)";

					// = 10
				case StringId.NavigatorFirstButtonHint:
					// return "First";
					return "第一条";

					// = 11
				case StringId.NavigatorPreviousButtonHint:
					// return "Previous";
					return "上一条";

					// = 12
				case StringId.NavigatorPreviousPageButtonHint:
					// return "Previous Page";
					return "上一页";

					// = 13
				case StringId.NavigatorNextButtonHint:
					// return "Next";
					return "下一条";

					// = 14
				case StringId.NavigatorNextPageButtonHint:
					// return "Next Page";
					return "下一页";

					// = 15
				case StringId.NavigatorLastButtonHint:
					// return "Last";
					return "最后一条";

					// = 16
				case StringId.NavigatorAppendButtonHint:
					// return "Append";
					return "添加";

					// = 17
				case StringId.NavigatorRemoveButtonHint:
					// return "Delete";
					return "删除";

					// = 18
				case StringId.NavigatorEditButtonHint:
					// return "Edit";
					return "编辑";

					// = 19
				case StringId.NavigatorEndEditButtonHint:
					// return "End Edit";
					return "结束编辑";

					// = 20
				case StringId.NavigatorCancelEditButtonHint:
					// return "Cancel Edit";
					return "取消编辑";

					// = 21
				case StringId.NavigatorTextStringFormat:
					// return "Record {0} of {1}";
					return "{0} / {1}";

					// = 22
				case StringId.PictureEditMenuCut:
					// return "Cut";
					return "剪切";

					// = 23
				case StringId.PictureEditMenuCopy:
					// return "Copy";
					return "复制";

					// = 24
				case StringId.PictureEditMenuPaste:
					// return "Paste";
					return "粘贴";

					// = 25
				case StringId.PictureEditMenuDelete:
					// return "Delete";
					return "删除";

					// = 26
				case StringId.PictureEditMenuLoad:
					// return "Load";
					return "加载";

					// = 27
				case StringId.PictureEditMenuSave:
					// return "Save";
					return "保存";

					// = 28
				case StringId.PictureEditOpenFileFilter:
					// return "Bitmap Files (*.bmp)|*.bmp|Graphics Interchange Format (*.gif)|*.gif|JPEG File Interchange Format (*.jpg;*.jpeg)|*.jpg;*.jpeg|Icon Files (*.ico)|*.ico|All Picture Files |*.bmp;*.gif;*.jpg;*.jpeg;*.ico;*.png;*.tif|All Files |*.*";
					return "位图文件 (*.bmp)|*.bmp|图形交换格式 (*.gif)|*.gif|JPEG 文件交换格式 (*.jpg;*.jpeg))|*.jpg;*.jpeg|图标文件 (*.ico)|*.ico|所有图片文件 |*.bmp;*.gif;*.jpg;*.jpeg;*.ico;*.png;*.tif|所有文件 |*.*";

					// = 29
				case StringId.PictureEditSaveFileFilter:
					// return "Bitmap Files (*.bmp)|*.bmp|Graphics Interchange Format (*.gif)|*.gif|JPEG File Interchange Format (*.jpg)|*.jpg";
					return "位图文件 (*.bmp)|*.bmp|图形交换格式 (*.gif)|*.gif|JPEG 文件交换格式 (*.jpg)|*.jpg";

					// = 30
				case StringId.PictureEditOpenFileTitle:
					// return "Open";
					return "打开";

					// = 31
				case StringId.PictureEditSaveFileTitle:
					// return "Save As";
					return "另存为";

					// = 32
				case StringId.PictureEditOpenFileError:
					// return "Wrong picture format";
					return "错误的图片格式";

					// = 33
				case StringId.PictureEditOpenFileErrorCaption:
					// return "Open error";
					return "打开错误";

					// = 34
				case StringId.LookUpEditValueIsNull:
					// return "[EditValue is null]";
					return "[空值]";

					// = 35
				case StringId.LookUpInvalidEditValueType:
					// return "Invalid LookUpEdit EditValue type.";
					return "无效的LookUpEdit EditValue类型";

					// = 36
				case StringId.LookUpColumnDefaultName:
					// return "Name";
					return "名称";

					// = 37
				case StringId.MaskBoxValidateError:
					// return "The entered value is incomplete.  Do you want to correct it?\r\n\r\nYes - // return to the editor and correct the value.\r\nNo - leave the value as is.\r\nCancel - reset to the previous value.";
					return "输入值不完整。是否需要改正？\r\n\r\n是 - 返回编辑器以改正。\r\n否 - 保持原值不变。\r\n取消 - 采用此前的值。";

					// = 38
				case StringId.UnknownPictureFormat:
					// return "Unknown picture format";
					return "未知的图片格式";

					// = 39
				case StringId.DataEmpty:
					// return "No image data";
					return "无图像数据";

					// = 40
				case StringId.NotValidArrayLength:
					// return "Not valid array length.";
					return "无效的数组长度.";

					// = 41
				case StringId.ImagePopupEmpty:
					// return "(Empty)";
					return "(空)";

					// = 42
				case StringId.ImagePopupPicture:
					// return "(Picture)";
					return "(图片)";

					// = 43
				case StringId.ColorTabCustom:
					// return "Custom";
					return "自定义";

					// = 44
				case StringId.ColorTabWeb:
					return "Web";

					// = 45
				case StringId.ColorTabSystem:
					// return "System";
					return "系统";

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
					return "开方";

					// = 51
				case StringId.CalcButtonBack:
					//return "Back"; 当前数值退位
					return "退位";

					// = 52
				case StringId.CalcButtonCE:
					// return "CE"; 将当前的输入置为零
					return "置0";

					// = 53
				case StringId.CalcButtonC:
					// return "C"; 清零，并将计算器恢复至开机状态
					return "清空"; 

					// = 54
				case StringId.CalcError:
					return "计算错误";

					// = 55
				case StringId.TabHeaderButtonPrev:
					// return "Scroll Left";
					return "向左滚动";

					// = 56
				case StringId.TabHeaderButtonNext:
					// return "Scroll Right";
					return "向右滚动";

					// = 57
				case StringId.TabHeaderButtonClose:
					// return "Close";
					return "关闭";

					// = 58
				case StringId.XtraMessageBoxOkButtonText:
					// return "&OK";
					return "确定 (&O)";

					// = 59
				case StringId.XtraMessageBoxCancelButtonText:
					// return "&Cancel";
					return "取消 (&C)";

					// = 60
				case StringId.XtraMessageBoxYesButtonText:
					// return "&Yes";
					return "是 (&Y)";

					// = 61
				case StringId.XtraMessageBoxNoButtonText:
					// return "&No";
					return "否 (&N)";

					// = 62
				case StringId.XtraMessageBoxAbortButtonText:
					// return "&Abort";
					return "中断 (&A)";

					// = 63
				case StringId.XtraMessageBoxRetryButtonText:
					// return "&Retry";
					return "重试 (&R)";

					// = 64
				case StringId.XtraMessageBoxIgnoreButtonText:
					// return "&Ignore";
					return "忽略 (&I)";

					// = 65
				case StringId.TextEditMenuUndo:
					// return "&Undo";
					return "撤消 (&U)";

					// = 66
				case StringId.TextEditMenuCut:
					// return "Cu&t";
					return "剪切 (&T)";

					// = 67
				case StringId.TextEditMenuCopy:
					// return "&Copy";
					return "复制 (&C)";

					// = 68
				case StringId.TextEditMenuPaste:
					// return "&Paste";
					return "粘贴 (&P)";

					// = 69
				case StringId.TextEditMenuDelete:
					// return "&Delete";
					return "删除 (&D)";

					// = 70
				case StringId.TextEditMenuSelectAll:
					// return "Select &All";
					return "全选 (&A)";

					// = 71
				case StringId.FilterGroupAnd:
					// return "And";
					return "与";

					// = 72
				case StringId.FilterGroupNotAnd:
					// return "Not And";
					return "与非";

					// = 73
				case StringId.FilterGroupNotOr:
					//return "Not Or";
					return "或非";

					// = 74
				case StringId.FilterGroupOr:
					// return "Or";
					return "或";

					// = 75
				case StringId.FilterClauseAnyOf:
					// return "Is any of";
					return "属于任一";

					// = 76
				case StringId.FilterClauseBeginsWith:
					// return "Begins with";
					return "起始于(字串)";

					// = 77
				case StringId.FilterClauseBetween:
					// return "Is between";
					return "介于(范围之内)";

					// = 78
				case StringId.FilterClauseBetweenAnd:
					// return "and";
					return "和";

					// = 79
				case StringId.FilterClauseContains:
					// return "Contains";
					return "包含";

					// = 80
				case StringId.FilterClauseEndsWith:
					// return "Ends with";
					return "结束于(字串)";

					// = 81
				case StringId.FilterClauseEquals:
					// return "Equals";
					return "等于";

					// = 82
				case StringId.FilterClauseGreater:
					// return "Is greater than";
					return "大于";

					// = 83
				case StringId.FilterClauseGreaterOrEqual:
					// return "Is greater than or equal to";
					return "大于等于";

					// = 84
				case StringId.FilterClauseIsNotNull:
					// return "Is not blank";
					return "不为空";

					// = 85
				case StringId.FilterClauseIsNull:
					// return "Is blank";
					return "为空";

					// = 86
				case StringId.FilterClauseLess:
					// return "Is less than";
					return "小于";

					// = 87
				case StringId.FilterClauseLessOrEqual:
					// return "Is less than or equal to";
					return "小于等于";

					// = 88
				case StringId.FilterClauseLike:
					// return "Is like";
					return "匹配(Like)";

					// = 89
				case StringId.FilterClauseNoneOf:
					// return "Is none of";
					return "不属于任一";

					// = 90
				case StringId.FilterClauseNotBetween:
					// return "Is not between";
					return "不介于(范围之外)";

					// = 91
				case StringId.FilterClauseDoesNotContain:
					// return "Does not contain";
					return "不包含";

					// = 92
				case StringId.FilterClauseDoesNotEqual:
					// return "Does not equal";
					return "不等于";

					// = 93
				case StringId.FilterClauseNotLike:
					// return "Is not like";
					return "不匹配(Like)";

					// = 94
				case StringId.FilterEmptyEnter:
					// return "<enter a value>";
					return "<输入一个值>";

					// = 95
				case StringId.FilterEmptyValue:
					// return "<empty>";
					return "<空>";

					// = 96
				case StringId.FilterMenuConditionAdd:
					// return "Add Condition";
					return "添加条件";

					// = 97
				case StringId.FilterMenuGroupAdd:
					// return "Add Group";
					return "添加条件组";

					// = 98
				case StringId.FilterMenuClearAll:
					// return "Clear All";
					return "全部清除";

					// = 99
				case StringId.FilterMenuRowRemove:
					// return "Remove Group";
					return "删除条件组";

					// = 100
				case StringId.FilterToolTipNodeAdd:
					// return "Adds a new condition to this group";
					return "添加新条件到此组";

					// = 101
				case StringId.FilterToolTipNodeRemove:
					// return "Removes this condition";
					return "删除此条件";

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
					return "(使用'Insert'键 / 数字区'+'键)";

					// = 106
				case StringId.FilterToolTipKeysRemove:
					// return "(Use the Delete or Subtract key)";
					return "(使用'Delete'键 / 数字区'-'键)";

					// = 107
				case StringId.ContainerAccessibleEditName:
					return "Editing control";

					// = 108
				case StringId.FilterCriteriaToStringGroupOperatorAnd:
					// return "与";
					return "与";

					// = 109
				case StringId.FilterCriteriaToStringGroupOperatorOr:
					// return "Or";
					return "或";

					// = 110
				case StringId.FilterCriteriaToStringUnaryOperatorBitwiseNot:
					return "~";

					// = 111
				case StringId.FilterCriteriaToStringUnaryOperatorIsNull:
					// return "Is Null";
					return "为空";

					// = 112
				case StringId.FilterCriteriaToStringUnaryOperatorMinus:
					return "-";

					// = 113
				case StringId.FilterCriteriaToStringUnaryOperatorNot:
					// return "Not";
					return "非";

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
					return "匹配(Like)";

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
					return "≠";

					// = 129
				case StringId.FilterCriteriaToStringBinaryOperatorPlus:
					return "+";

					// = 130
				case StringId.FilterCriteriaToStringBetween:
					// return "Between";
					return "介于";

					// = 131
				case StringId.FilterCriteriaToStringIn:
					// return "In";
					return "处于";

					// = 132
				case StringId.FilterCriteriaToStringIsNotNull:
					// return "Is Not Null";
					return "不为空";

					// = 133
				case StringId.FilterCriteriaToStringNotLike:
					// return "Not Like";
					return "不匹配(Like)";

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
				return "简体中文";
			}
		}
	}


	// XtraGrid表格
	public class XtraGridLocalizer : GridLocalizer
	{
		public override string GetLocalizedString(GridStringId id)
		{
			switch (id)
			{
					// = 0
				case GridStringId.FileIsNotFoundError:
					// return "File {0} is not found";
					return "文件{0}没有找到";

					// = 1
				case GridStringId.ColumnViewExceptionMessage:
					// return " Do you want to correct the value ?";
					return "是否确认要修改值？";

					// = 2
				case GridStringId.CustomizationCaption:
					// return "Customization";
					return "选择显示列";

					// = 3
				case GridStringId.CustomizationColumns:
					// return "Columns";
					return "列";

					// = 4
				case GridStringId.CustomizationBands:
					// return "Bands";
					return "带";

					// = 5
				case GridStringId.FilterPanelCustomizeButton:
					// return "Edit Filter";
					return "编辑条件";

					// = 6
				case GridStringId.PopupFilterAll:
					// return "(All)";
					return "(所有)";

					// = 7
				case GridStringId.PopupFilterCustom:
					// return "(Custom)";
					return "(自定义)";

					// = 8
				case GridStringId.PopupFilterBlanks:
					// return "(Blanks)";
					return "(空值)";

					// = 9
				case GridStringId.PopupFilterNonBlanks:
					// return "(Non blanks)";
					return "(非空值)";

					// = 10
				case GridStringId.CustomFilterDialogFormCaption:
					// return "Custom AutoFilter";
					return "自定义筛选条件";

					// = 11
				case GridStringId.CustomFilterDialogCaption:
					// return "Show rows where:";
					return "条件为:";

					// = 12
				case GridStringId.CustomFilterDialogRadioAnd:
					// return "&And";
					return "与 (&A)";

					// = 13
				case GridStringId.CustomFilterDialogRadioOr:
					// return "O&r";
					return "或 (&R)";

					// = 14
				case GridStringId.CustomFilterDialogOkButton:
					// return "&OK";
					return "确认 (&O)";

					// = 15
				case GridStringId.CustomFilterDialogClearFilter:
					// return "C&lear Filter";
					return "清空筛选器 (&L)";

					// = 16
				case GridStringId.CustomFilterDialog2FieldCheck:
					// return "Field";
					return "列";

					// = 17
				case GridStringId.CustomFilterDialogCancelButton:
					// return "&Cancel";
					return "取消 (&C)";

					// = 18
				case GridStringId.CustomFilterDialogConditionEQU:
					// return "equals";
					return "等于";

					// = 19
				case GridStringId.CustomFilterDialogConditionNEQ:
					// return "does not equal";
					return "不等于<>";

					// = 20
				case GridStringId.CustomFilterDialogConditionGT:
					// return "is greater than";
					return "大于>";

					// = 21
				case GridStringId.CustomFilterDialogConditionGTE:
					// return "is greater than or equal to";
					return "大于或等于>=";

					// = 22
				case GridStringId.CustomFilterDialogConditionLT:
					// return "is less than";
					return "小于<";

					// = 23
				case GridStringId.CustomFilterDialogConditionLTE:
					// return "is less than or equal to";
					return "小于或等于<=";

					// = 24
				case GridStringId.CustomFilterDialogConditionBlanks:
					// return "blanks";
					return "空值";

					// = 25
				case GridStringId.CustomFilterDialogConditionNonBlanks:
					// return "non blanks";
					return "非空值";

					// = 26
				case GridStringId.CustomFilterDialogConditionLike:
					// return "like";
					return "匹配(Like)";

					// = 27
				case GridStringId.CustomFilterDialogConditionNotLike:
					// return "not like";
					return "不匹配(Like)";

					// = 28
				case GridStringId.WindowErrorCaption:
					// return "";
					return "";

					// = 29
				case GridStringId.MenuFooterSum:
					// return "Sum";
					return "总和";

					// = 30
				case GridStringId.MenuFooterMin:
					// return "Min";
					return "最小";

					// = 31
				case GridStringId.MenuFooterMax:
					// return "Max";
					return "最大";

					// = 32
				case GridStringId.MenuFooterCount:
					// return "Count";
					return "计数";

					// = 33
				case GridStringId.MenuFooterAverage:
					// return "Average";
					return "平均";

					// = 34
				case GridStringId.MenuFooterNone:
					// return "None";
					return "空";

					// = 35
				case GridStringId.MenuFooterSumFormat:
					// return "SUM={0:#.##}";
					return "合计={0:#.##}";

					// = 36
				case GridStringId.MenuFooterMinFormat:
					// return "MIN={0}";
					return "最小={0}";

					// = 37
				case GridStringId.MenuFooterMaxFormat:
					// return "MAX={0}";
					return "最大={0}";

					// = 38
				case GridStringId.MenuFooterCountFormat:
					return "{0}";

					// = 39
				case GridStringId.MenuFooterAverageFormat:
					//return "AVR={0:#.##}";
					return "平均={0:#.##}";

					// = 40
				case GridStringId.MenuColumnSortAscending:
					//return "Sort Ascending";
					return "升序";

					// = 41
				case GridStringId.MenuColumnSortDescending:
					// return "Sort Descending";
					return "降序";

					// = 42
				case GridStringId.MenuColumnGroup:
					// return "Group By This Column";
					return "按此列分组";

					// = 43
				case GridStringId.MenuColumnUnGroup:
					// return "UnGroup";
					return "取消分组";

					// = 44
				case GridStringId.MenuColumnColumnCustomization:
					// return "Column Chooser";
					return "选择显示列";

					// = 45
				case GridStringId.MenuColumnBestFit:
					// return "Best Fit";
					return "最适列宽";

					// = 46
				case GridStringId.MenuColumnFilter:
					// return "Can Filter";
					return "打开筛选";

					// = 47
				case GridStringId.MenuColumnClearFilter:
					// return "Clear Filter";
					return "清除筛选条件";

					// = 48
				case GridStringId.MenuColumnBestFitAllColumns:
					// return "Best Fit (all columns)";
					return "调整所有列宽";

					// = 49
				case GridStringId.MenuGroupPanelFullExpand:
					// return "Full Expand";
					return "全部展开";

					// = 50
				case GridStringId.MenuGroupPanelFullCollapse:
					// return "Full Collapse";
					return "全部收缩";

					// = 51
				case GridStringId.MenuGroupPanelClearGrouping:
					// return "Clear Grouping";
					return "清除分组";

					// = 52
				case GridStringId.PrintDesignerGridView:
					// return "Print Settings (Grid View)";
					return "打印设置 (表格视图)";

					// = 53
				case GridStringId.PrintDesignerCardView:
					// return "Print Settings (Card View)";
					return "打印设置 (卡片视图)";

					// = 54
				case GridStringId.PrintDesignerBandedView:
					// return "Print Settings (Banded View)";
					return "打印设置 (带状视图)";

					// = 55
				case GridStringId.PrintDesignerBandHeader:
					// return "BandHeader";
					return "带标题";

					// = 56
				case GridStringId.MenuColumnGroupBox:
					// return "Group By Box";
					return "显示分组区";

					// = 57
				case GridStringId.CardViewNewCard:
					// return "New Card";
					return "新卡片";

					// = 58
				case GridStringId.CardViewQuickCustomizationButton:
					// return "Customize";
					return "自定义格式";

					// = 59
				case GridStringId.CardViewQuickCustomizationButtonFilter:
					// return "Filter";
					return "筛选";

					// = 60
				case GridStringId.CardViewQuickCustomizationButtonSort:
					// return "Sort:";
					return "排序:";

					// = 61
				case GridStringId.GridGroupPanelText:
					// return "Drag a column header here to group by that column";
					return "拖动列标题到此进行分组";

					// = 62
				case GridStringId.GridNewRowText:
					// return "Click here to add a new row";
					return "点击此处添加新行";

					// = 63
				case GridStringId.GridOutlookIntervals:
					// return "Older;Last Month;Earlier this Month;Three Weeks Ago;Two Weeks Ago;Last Week;;;;;;;;Yesterday;Today;Tomorrow;;;;;;;;Next Week;Two Weeks Away;Three Weeks Away;Later this Month;Next Month;Beyond Next Month;";
					return "更早;上个月;本月初;三周前;两周前;上周;;;;;;;;昨天;今天;明天; ;;;;;;;下周;两周后;三周后;下个月;下个月之后;";

					// = 64
				case GridStringId.PrintDesignerDescription:
					// return "Set up various printing options for the current view.";
					return "为当前视图设置打印选项。";

					// = 65
				case GridStringId.MenuFooterCustomFormat:
					// return "Custom={0}";
					return "自定义={0}";

					// = 66
				case GridStringId.MenuFooterCountGroupFormat:
					// return "Count={0}";
					return "计数: {0}";

					// = 67
				case GridStringId.MenuColumnClearSorting:
					// return "Clear Sorting";
					return "不排序";

					// = 68
				case GridStringId.MenuColumnFilterEditor:
					// return "Filter Editor";
					return "编辑筛选条件";

					// = 69
				case GridStringId.FilterBuilderOkButton:
					// return "&OK";
					return "确定 (&O)";

					// = 70
				case GridStringId.FilterBuilderCancelButton:
					// return "&Cancel";
					return "取消 (&C)";

					// = 71
				case GridStringId.FilterBuilderApplyButton:
					// return "&Apply";
					return "应用 (&A)";

					// = 72
				case GridStringId.FilterBuilderCaption:
					// return "Filter Builder";
					return "筛选条件编辑器";
			}

			return base.GetLocalizedString(id);
		}

		public override string Language
		{
			get
			{
				return "简体中文";
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
					return "自定义";

					// = 1
				case LayoutStringId.DefaultItemText:
					// return "Item ";
					return "项目";

					// = 2
				case LayoutStringId.DefaultActionText:
					// return "DefaultAction";
					return "默认方式";

					// = 3
				case LayoutStringId.DefaultEmptyText:
					// return "none";
					return "无";

					// = 4
				case LayoutStringId.LayoutItemDescription:
					// return "Layout control item element";
					return "布局";

					// = 5
				case LayoutStringId.LayoutGroupDescription:
					// return "Layout control group element";
					return "布局分组";

					// = 6
				case LayoutStringId.TabbedGroupDescription:
					// return "Layout control tabbedGroup element";
					return "布局标签组";

					// = 7
				case LayoutStringId.LayoutControlDescription:
					// return "Layout control";
					return "布局控件";

					// = 8
				case LayoutStringId.CustomizationFormTitle:
					// return "Customization";
					return "自定义布局";

					// = 9
				case LayoutStringId.HiddenItemsPageTitle:
					// return "Hidden Items";
					return "隐藏的项目";

					// = 10
				case LayoutStringId.TreeViewPageTitle:
					// return "Layout Tree View";
					return "布局树视图";

					// = 11
				case LayoutStringId.RenameSelected:
					// return "Rename";
					return "重命名";

					// = 12
				case LayoutStringId.HideItemMenutext:
					// return "Hide Item";
					return "隐藏项目";

					// = 13
				case LayoutStringId.LockItemSizeMenuText:
					// return "Lock Item Size";
					return "锁定项目大小";

					// = 14
				case LayoutStringId.UnLockItemSizeMenuText:
					// return "UnLock Item Size";
					return "解锁项目大小";

					// = 15
				case LayoutStringId.GroupItemsMenuText:
					// return "Group";
					return "分组";

					// = 16
				case LayoutStringId.UnGroupItemsMenuText:
					// return "Ungroup";
					return "取消分组";

					// = 17
				case LayoutStringId.CreateTabbedGroupMenuText:
					// return "Create Tab Control";
					return "创建标签";

					// = 18
				case LayoutStringId.AddTabMenuText:
					// return "Add Tab";
					return "添加标签";

					// = 19
				case LayoutStringId.UnGroupTabbedGroupMenuText:
					// return "Remove Tab Control";
					return "移除标签";

					// = 20
				case LayoutStringId.TreeViewRootNodeName:
					// return "Root";
					return "根目录";

					// = 21
				case LayoutStringId.ShowCustomizationFormMenuText:
					// return "Customize Layout";
					return "自定义布局";

					// = 22
				case LayoutStringId.HideCustomizationFormMenuText:
					// return "Hide Customization Form";
					return "隐藏自定义窗体";

					// = 23
				case LayoutStringId.EmptySpaceItemDefaultText:
					// return "Empty Space Item";
					return "空白项";

					// = 24
				case LayoutStringId.SplitterItemDefaultText:
					// return "Splitter";
					return "分割线";

					// = 25
				case LayoutStringId.ControlGroupDefaultText:
					// return "Group ";
					return "组 ";

					// = 26
				case LayoutStringId.EmptyRootGroupText:
					// return "Drop controls here";
					return "拖动到此";

					// = 27
				case LayoutStringId.EmptyTabbedGroupText:
					// return "Drag drop groups into the caption area";
					return "拖放分组到标题区";

					// = 28
				case LayoutStringId.ResetLayoutMenuText:
					// return "Reset Layout";
					return "复原布局";

					// = 29
				case LayoutStringId.RenameMenuText:
					// return "Rename";
					return "重命名";

					// = 30
				case LayoutStringId.TextPositionMenuText:
					// return "Text Position";
					return "文本位置";

					// = 31
				case LayoutStringId.TextPositionLeftMenuText:
					// return "Left";
					return "左";

					// = 32
				case LayoutStringId.TextPositionRightMenuText:
					// return "Right";
					return "右";

					// = 33
				case LayoutStringId.TextPositionTopMenuText:
					// return "Top";
					return "顶";

					// = 34
				case LayoutStringId.TextPositionBottomMenuText:
					// return "Bottom";
					return "底";

					// = 35
				case LayoutStringId.ShowTextMenuItem:
					// return "Show Text";
					return "显示文本";

					// = 36
				case LayoutStringId.HideTextMenuItem:
					// return "Hide Text";
					return "隐藏文本";

					// = 37
				case LayoutStringId.LockSizeMenuItem:
					// return "Lock Size";
					return "锁定大小";

					// = 38
				case LayoutStringId.LockWidthMenuItem:
					// return "Lock Width";
					return "锁定宽度";

					// = 39
				case LayoutStringId.LockHeightMenuItem:
					// return "Lock Height";
					return "锁定高度";

					// = 40
				case LayoutStringId.LockMenuGroup:
					return "";

					// = 41
				case LayoutStringId.ResetConstraintsToDefaultsMenuItem:
					return "";

					// = 42
				case LayoutStringId.FreeSizingMenuItem:
					// return "Free sizing";
					return "自由缩放大小";

					// = 43
				case LayoutStringId.CreateEmptySpaceItem:
					// return "Create EmptySpace Item";
					return "创建空项目";
			}

			return base.GetLocalizedString(id);
		}

		public override string Language
		{
			get
			{
				return "简体中文";
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
					return "显示更多按钮 (&M)";

					// = 1
				case NavBarStringId.NavPaneMenuShowFewerButtons:
					// return "Show &Fewer Buttons";
					return "显示更少按钮 (&F)";

					// = 2
				case NavBarStringId.NavPaneMenuAddRemoveButtons:
					// return "&Add or Remove Buttons";
					return "添加或删除按钮 (&A)";

					// = 3
				case NavBarStringId.NavPaneChevronHint:
					// return "Configure buttons";
					return "配置按钮";
			}

			return base.GetLocalizedString(id);
		}

		public override string Language
		{
			get
			{
				return "简体中文";
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
    //                return "拖动行至此";

    //                // = 1
    //            case PivotGridStringId.ColumnHeadersCustomization:
    //                // return "Drop Column Fields Here";
    //                return "拖动列至此";

    //                // = 2
    //            case PivotGridStringId.FilterHeadersCustomization:
    //                // return "Drop Filter Fields Here";
    //                return "拖动筛选字段至此";

    //                // = 3
    //            case PivotGridStringId.DataHeadersCustomization:
    //                // return "Drop Data Items Here";
    //                return "拖动数据项至此";

    //                // = 4
    //            case PivotGridStringId.RowArea:
    //                // return "Row Area";
    //                return "行区";

    //                // = 5
    //            case PivotGridStringId.ColumnArea:
    //                // return "Column Area";
    //                return "列区";

    //                // = 6
    //            case PivotGridStringId.FilterArea:
    //                // return "Filter Area";
    //                return "筛选区";

    //                // = 7
    //            case PivotGridStringId.DataArea:
    //                // return "Data Area";
    //                return "数据区";

    //                // = 8
    //            case PivotGridStringId.FilterShowAll:
    //                // return "(Show All)";
    //                return "(显示全部)";

    //                // = 9
    //            case PivotGridStringId.FilterShowBlanks:
    //                // return "Show Blanks";
    //                return "显示空白";

    //                // = 10
    //            case PivotGridStringId.CustomizationFormCaption:
    //                // return "PivotGrid Field List";
    //                return "自定义字段";

    //                // = 11
    //            case PivotGridStringId.CustomizationFormText:
    //                // return "Drag Items to the PivotGrid";
    //                return "拖动数据项";

    //                // = 12
    //            case PivotGridStringId.CustomizationFormAddTo:
    //                // return "Add To";
    //                return "添加到";

    //                // = 13
    //            case PivotGridStringId.Total:
    //                // return "Total";
    //                return "合计";

    //                // = 14
    //            case PivotGridStringId.GrandTotal:
    //                // return "Grand Total";
    //                return "总计";

    //                // = 15
    //            case PivotGridStringId.TotalFormat:
    //                // return "{0} Total";
    //                return "{0} 合计";

    //                // = 16
    //            case PivotGridStringId.TotalFormatCount:
    //                // return "{0} Count";
    //                return "{0} 计数";

    //                // = 17
    //            case PivotGridStringId.TotalFormatSum:
    //                // return "{0} Sum";
    //                return "{0} 总和";

    //                // = 18
    //            case PivotGridStringId.TotalFormatMin:
    //                // return "{0} Min";
    //                return "{0} 最小值";

    //                // = 19
    //            case PivotGridStringId.TotalFormatMax:
    //                // return "{0} Max";
    //                return "{0} 最大值";

    //                // = 20
    //            case PivotGridStringId.TotalFormatAverage:
    //                // return "{0} Average";
    //                return "{0} 平均值";

    //                // = 21
    //            case PivotGridStringId.TotalFormatStdDev:
    //                // return "{0} StdDev";
    //                return "{0} 标准差估计";

    //                // = 22
    //            case PivotGridStringId.TotalFormatStdDevp:
    //                // return "{0} StdDevp";
    //                return "{0} 扩展标准差";

    //                // = 23
    //            case PivotGridStringId.TotalFormatVar:
    //                // return "{0} Var";
    //                return "{0} 变异数估计";

    //                // = 24
    //            case PivotGridStringId.TotalFormatVarp:
    //                // return "{0} Varp";
    //                return "{0} 扩展变异数";

    //                // = 25
    //            case PivotGridStringId.TotalFormatCustom:
    //                // return "{0} Custom";
    //                return "{0} 自定义";

    //                // = 26
    //            case PivotGridStringId.PrintDesignerPageOptions:
    //                // return "Options";
    //                return "选项";

    //                // = 27
    //            case PivotGridStringId.PrintDesignerPageBehavior:
    //                // return "Behavior";
    //                return "状态";

    //                // = 28
    //            case PivotGridStringId.PrintDesignerCategoryDefault:
    //                // return "Default";
    //                return "默认";

    //                // = 29
    //            case PivotGridStringId.PrintDesignerCategoryLines:
    //                // return "Lines";
    //                return "线";

    //                // = 30
    //            case PivotGridStringId.PrintDesignerCategoryHeaders:
    //                // return "Headers";
    //                return "标题";

    //                // = 31
    //            case PivotGridStringId.PrintDesignerHorizontalLines:
    //                // return "Horizontal Lines";
    //                return "水平线";

    //                // = 32
    //            case PivotGridStringId.PrintDesignerVerticalLines:
    //                // return "Vertical Lines";
    //                return "垂直线";

    //                // = 33
    //            case PivotGridStringId.PrintDesignerFilterHeaders:
    //                // return "Filter Headers";
    //                return "筛选标题";

    //                // = 34
    //            case PivotGridStringId.PrintDesignerDataHeaders:
    //                // return "Data Headers";
    //                return "数据标题";

    //                // = 35
    //            case PivotGridStringId.PrintDesignerColumnHeaders:
    //                // return "Column Headers";
    //                return "列标题";

    //                // = 36
    //            case PivotGridStringId.PrintDesignerRowHeaders:
    //                // return "Row Headers";
    //                return "行标题";

    //                // = 37
    //            case PivotGridStringId.PrintDesignerUsePrintAppearance:
    //                // return "Use Print Appearance";
    //                return "使用打印外观";

    //                // = 38
    //            case PivotGridStringId.PopupMenuRefreshData:
    //                // return "Refresh Data";
    //                return "刷新数据";

    //                // = 39
    //            case PivotGridStringId.PopupMenuHideField:
    //                // return "Hide";
    //                return "隐藏";

    //                // = 40
    //            case PivotGridStringId.PopupMenuShowFieldList:
    //                // return "Show Field List";
    //                return "显示自定义字段框";

    //                // = 41
    //            case PivotGridStringId.PopupMenuHideFieldList:
    //                // return "Hide Field List";
    //                return "隐藏自定义字段框";

    //                // = 42
    //            case PivotGridStringId.PopupMenuFieldOrder:
    //                // return "Order";
    //                return "顺序";

    //                // = 43
    //            case PivotGridStringId.PopupMenuMovetoBeginning:
    //                // return "Move to Beginning";
    //                return "移至最左";

    //                // = 44
    //            case PivotGridStringId.PopupMenuMovetoLeft:
    //                // return "Move to Left";
    //                return "左移";

    //                // = 45
    //            case PivotGridStringId.PopupMenuMovetoRight:
    //                // return "Move to Right";
    //                return "右移";

    //                // = 46
    //            case PivotGridStringId.PopupMenuMovetoEnd:
    //                // return "Move to End";
    //                return "移至最右";

    //                // = 47
    //            case PivotGridStringId.PopupMenuCollapse:
    //                // return "Collapse";
    //                return "收缩";

    //                // = 48
    //            case PivotGridStringId.PopupMenuExpand:
    //                // return "Expand";
    //                return "展开";

    //                // = 49
    //            case PivotGridStringId.PopupMenuCollapseAll:
    //                // return "Collapse All";
    //                return "全部收缩";

    //                // = 50
    //            case PivotGridStringId.PopupMenuExpandAll:
    //                // return "Expand All";
    //                return "全部展开";

    //                // = 51
    //            case PivotGridStringId.DataFieldCaption:
    //                // return "Data";
    //                return "数据";

    //                // = 52
    //            case PivotGridStringId.TopValueOthersRow:
    //                // return "Others";
    //                return "其它";
    //        }

    //        return base.GetLocalizedString(id);
    //    }

    //    public override string Language
    //    {
    //        get
    //        {
    //            return "简体中文";
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
					return "取消";

					// = 1
				case PreviewStringId.Button_Ok:
					return "确定";

					// = 2
				case PreviewStringId.Button_Help:
					return "帮助";

					// = 3
				case PreviewStringId.Button_Apply:
					return "应用";

					// = 4
				case PreviewStringId.PPF_Preview_Caption:
					return "";

					// = 5
				case PreviewStringId.PreviewForm_Caption:
					return "预览";

					// = 6
				case PreviewStringId.TB_CustomizeBtn_ToolTip:
					return "";

					// = 7
				case PreviewStringId.TB_TTip_Customize:
					return "自定义";

					// = 8
				case PreviewStringId.TB_PrintBtn_ToolTip:
					return "";

					// = 9
				case PreviewStringId.TB_TTip_Print:
					return "打印";

					// = 10
				case PreviewStringId.TB_PrintDirectBtn_ToolTip:
					return "";

					// = 11
				case PreviewStringId.TB_TTip_PrintDirect:
					return "直接打印";

					// = 12
				case PreviewStringId.TB_PageSetupBtn_ToolTip:
					return "";

					// = 13
				case PreviewStringId.TB_TTip_PageSetup:
					return "页面设置";

					// = 14
				case PreviewStringId.TB_MagnifierBtn_ToolTip:
					return "";

					// = 15
				case PreviewStringId.TB_TTip_Magnifier:
					return "放大镜";

					// = 16
				case PreviewStringId.TB_ZoomInBtn_ToolTip:
					return "";

					// = 17
				case PreviewStringId.TB_TTip_ZoomIn:
					return "放大";

					// = 18
				case PreviewStringId.TB_ZoomOutBtn_ToolTip:
					return "";

					// = 19
				case PreviewStringId.TB_TTip_ZoomOut:
					return "缩小";

					// = 20
				case PreviewStringId.TB_ZoomBtn_ToolTip:
					return "";

					// = 21
				case PreviewStringId.TB_TTip_Zoom:
					return "缩放";

					// = 22
				case PreviewStringId.TB_SearchBtn_ToolTip:
					return "";

					// = 23
				case PreviewStringId.TB_TTip_Search:
					return "搜索";

					// = 24
				case PreviewStringId.TB_FirstPageBtn_ToolTip:
					return "";

					// = 25
				case PreviewStringId.TB_TTip_FirstPage:
					return "第一页";

					// = 26
				case PreviewStringId.TB_PreviousPageBtn_ToolTip:
					return "";

					// = 27
				case PreviewStringId.TB_TTip_PreviousPage:
					return "上一页";

					// = 28
				case PreviewStringId.TB_NextPageBtn_ToolTip:
					return "";

					// = 29
				case PreviewStringId.TB_TTip_NextPage:
					return "下一页";

					// = 30
				case PreviewStringId.TB_LastPageBtn_ToolTip:
					return "";

					// = 31
				case PreviewStringId.TB_TTip_LastPage:
					return "最后一页";

					// = 32
				case PreviewStringId.TB_MultiplePagesBtn_ToolTip:
					return "";

					// = 33
				case PreviewStringId.TB_TTip_MultiplePages:
					return "多页";

					// = 34
				case PreviewStringId.TB_BackGroundBtn_ToolTip:
					return "";

					// = 35
				case PreviewStringId.TB_TTip_Backgr:
					return "背景色";

					// = 36
				case PreviewStringId.TB_ClosePreviewBtn_ToolTip:
					return "";

					// = 37
				case PreviewStringId.TB_TTip_Close:
					return "退出预览";

					// = 38
				case PreviewStringId.TB_EditPageHFBtn_ToolTip:
					return "";

					// = 39
				case PreviewStringId.TB_TTip_EditPageHF:
					return "页眉页脚";

					// = 40
				case PreviewStringId.TB_HandToolBtn_ToolTip:
					return "";

					// = 41
				case PreviewStringId.TB_TTip_HandTool:
					return "手形工具";

					// = 42
				case PreviewStringId.TB_ExportBtn_ToolTip:
					return "";

					// = 43
				case PreviewStringId.TB_TTip_Export:
					return "导出文档...";

					// = 44
				case PreviewStringId.TB_SendBtn_ToolTip:
					return "";

					// = 45
				case PreviewStringId.TB_TTip_Send:
					return "发送 E-Mail...";

					// = 46
				case PreviewStringId.TB_DocMap_ToolTip:
					return "";

					// = 47xxxx
				case PreviewStringId.TB_TTip_Map:
					//return "Document Map";
					return "文档结构";

					// = 48
				case PreviewStringId.TB_Watermark_ToolTip:
					return "";

					// = 49
				case PreviewStringId.TB_TTip_Watermark:
					return "水印";

					// = 50
				case PreviewStringId.barExport_PDF_Document:
					return "";

					// = 51
				case PreviewStringId.MenuItem_PdfDocument:
					return "PDF文档";

					// = 52
				case PreviewStringId.MenuItem_PageLayout:
					return "页面显示 (&P)";

					// = 53
				case PreviewStringId.barExport_Text_Document:
					return "";

					// = 54
				case PreviewStringId.MenuItem_TxtDocument:
					return "Text文档";

					// = 55
				case PreviewStringId.MenuItem_GraphicDocument:
					return "图像文件";

					// = 56
				case PreviewStringId.barExport_CSV_Document:
					return "";

					// = 57
				case PreviewStringId.MenuItem_CsvDocument:
					return "CSV文档";

					// = 58
				case PreviewStringId.barExport_MHT_Document:
					return "";

					// = 59
				case PreviewStringId.MenuItem_MhtDocument:
					return "MHT文档";

					// = 60
				case PreviewStringId.barExport_Excel_Document:
					return "";

					// = 61
				case PreviewStringId.MenuItem_XlsDocument:
					return "Excel文档";

					// = 62
				case PreviewStringId.barExport_RichTextDocument:
					return "";

					// = 63
				case PreviewStringId.MenuItem_RtfDocument:
					return "RTF文档";

					// = 64
				case PreviewStringId.barExport_HTMLDocument:
					return "";

					// = 65
				case PreviewStringId.MenuItem_HtmDocument:
					return "HTML文档";

					// = 66
				case PreviewStringId.barExport_BMP:
					return "";

					// = 67
				case PreviewStringId.SaveDlg_FilterBmp:
					return "BMP 位图格式";

					// = 68
				case PreviewStringId.barExport_GIF:
					return "";

					// = 69
				case PreviewStringId.SaveDlg_FilterGif:
					return "GIF 图形交换格式";

					// = 70
				case PreviewStringId.barExport_JPEG:
					return "";

					// = 71
				case PreviewStringId.SaveDlg_FilterJpeg:
					return "JPEG 文件交换格式";

					// = 72
				case PreviewStringId.barExport_PNG:
					return "";

					// = 73
				case PreviewStringId.SaveDlg_FilterPng:
					return "PNG 可移植网络图形";

					// = 74
				case PreviewStringId.barExport_TIFF:
					return "";

					// = 75
				case PreviewStringId.SaveDlg_FilterTiff:
					return "TIFF Tag图像文件格式";

					// = 76
				case PreviewStringId.barExport_EMF:
					return "";

					// = 77
				case PreviewStringId.SaveDlg_FilterEmf:
					return "EMF Windows增强型图元文件";

					// = 78
				case PreviewStringId.barExport_WMF:
					return "";

					// = 79
				case PreviewStringId.SaveDlg_FilterWmf:
					return "WMF Windows图元文件";

					// = 80
				case PreviewStringId.SB_TotalPageNo:
					return "总页数:";

					// = 81
				case PreviewStringId.SB_CurrentPageNo:
					return "当前页:";

					// = 82
				case PreviewStringId.SB_ZoomFactor:
					return "缩放比例:";

					// = 83
				case PreviewStringId.SB_PageNone:
					return "无";

					// = 84
				case PreviewStringId.SB_PageInfo_OF:
					return "";

					// = 85
				case PreviewStringId.SB_PageInfo:
					return "第{0}页 共{1}页";

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
					return "页面";

					// = 101
				case PreviewStringId.Msg_EmptyDocument:
					return "文档没有页面。";

					// = 102
				case PreviewStringId.Msg_CreatingDocument:
					return "正在创建文档...";

					// = 103
				case PreviewStringId.Msg_UnavailableNetPrinter:
					return "网络打印机不可用。";

					// = 104
				case PreviewStringId.Msg_NeedPrinter:
					return "没有安装打印机。";

					// = 105
				case PreviewStringId.Msg_WrongPrinter:
					// return "The printer name is invalid. Please check the printer settings.";
					return "无效的打印机名称。请检查打印机的设置是否正确。";

					// = 106
				case PreviewStringId.Msg_WrongPageSettings:
					// return "The current printer doesn't support the selected paper size.\r\nProceed with printing anyway?";
					return "打印机不支持所选的纸张大小。\r\n是否继续打印？";

					// = 107
				case PreviewStringId.Msg_CustomDrawWarning:
					// return "Warning!";
					return "警告！";

					// = 108
				case PreviewStringId.Msg_PageMarginsWarning:
					//return "One or more margins are set outside the printable area of the page. Continue?";
					return "一个或以上的边界超出了打印范围。是否继续？";

					// = 109
				case PreviewStringId.Msg_IncorrectPageRange:
					//return "This is not a valid page range";
					return "无效的页码范围边界。";

					// = 110
				case PreviewStringId.Msg_FontInvalidNumber:
					// return "The font size cannot be set to zero or a negative number";
					return "字体大小不能为0或负数";

					// = 111
				case PreviewStringId.Msg_NotSupportedFont:
					// return "This font is not yet supported";
					return "不支持的字体";

					// = 112
				case PreviewStringId.Msg_IncorrectZoomFactor:
					// return "The number must be beetween {0} and {1}.";
					return "数字必须在 {0} 与 {1} 之间。";

					// = 113
				case PreviewStringId.Msg_InvalidMeasurement:
					// return "This is not a valid measurement.";
					return "无效的规范";

					// = 114
				case PreviewStringId.Msg_CannotAccessFile:
					// return "The process cannot access the file \"{0}\" because it is being used by another process.";
					return "当前处理无法访问文件\"{0}\"，因为它正被其它程序使用。";

					// = 115
				case PreviewStringId.Margin_Inch:
					return "英寸";

					// = 116
				case PreviewStringId.Margin_Millimeter:
					return "毫米";

					// = 117
				case PreviewStringId.Margin_TopMargin:
					// return"Top Margin";
					return "上边距";

					// = 118
				case PreviewStringId.Margin_BottomMargin:
					// return"Bottom Margin";
					return "下边距";

					// = 119
				case PreviewStringId.Margin_LeftMargin:
					// return"Left Margin";
					return "左边距";

					// = 120
				case PreviewStringId.Margin_RightMargin:
					// return"Right Margin";
					return "右边距";

					// = 121
				case PreviewStringId.Page_Scroll:
					return "";

					// = 122
				case PreviewStringId.ScrollingInfo_Page:
					return "页";

					// = 123
				case PreviewStringId.WMForm_PictureDlg_Title:
					return "选择图片";

					// = 124
				case PreviewStringId.WMForm_ImageStretch:
					// return "Stretch";
					return "拉伸";

					// = 125
				case PreviewStringId.WMForm_ImageClip:
					return "修剪";

					// = 126
				case PreviewStringId.WMForm_ImageZoom:
					return "缩放";

					// = 127
				case PreviewStringId.WMForm_Watermark_Asap:
					// return"ASAP";
					return "尽快";

					// = 128
				case PreviewStringId.WMForm_Watermark_Confidential:
					// return"CONFIDENTIAL";
					return "机密";

					// = 129
				case PreviewStringId.WMForm_Watermark_Copy:
					// return"COPY";
					return "副本";

					// = 130
				case PreviewStringId.WMForm_Watermark_DoNotCopy:
					// return"DO NOT COPY";
					return "严禁拷贝";

					// = 131
				case PreviewStringId.WMForm_Watermark_Draft:
					// return"DRAFT";
					return "草稿";

					// = 132
				case PreviewStringId.WMForm_Watermark_Evaluation:
					// return"EVALUATION";
					return "评估";

					// = 133
				case PreviewStringId.WMForm_Watermark_Original:
					// return"ORIGINAL";
					return "原始";

					// = 134
				case PreviewStringId.WMForm_Watermark_Personal:
					// return"PERSONAL";
					return "私人";

					// = 135
				case PreviewStringId.WMForm_Watermark_Sample:
					// return"SAMPLE";
					return "样品";

					// = 136
				case PreviewStringId.WMForm_Watermark_TopSecret:
					// return"TOP SECRET";
					return "绝密";

					// = 137
				case PreviewStringId.WMForm_Watermark_Urgent:
					// return"URGENT";
					return "紧急";

					// = 138
				case PreviewStringId.WMForm_Direction_Horizontal:
					return "横向";

					// = 139
				case PreviewStringId.WMForm_Direction_Vertical:
					return "纵向";

					// = 140
				case PreviewStringId.WMForm_Direction_BackwardDiagonal:
					return "对角方向";

					// = 141
				case PreviewStringId.WMForm_Direction_ForwardDiagonal:
					return "反对角方向";

					// = 142
				case PreviewStringId.WMForm_VertAlign_Bottom:
					return "置底";

					// = 143
				case PreviewStringId.WMForm_VertAlign_Middle:
					return "垂直居中";

					// = 144
				case PreviewStringId.WMForm_VertAlign_Top:
					return "置顶";

					// = 145
				case PreviewStringId.WMForm_HorzAlign_Left:
					return "靠左";

					// = 146
				case PreviewStringId.WMForm_HorzAlign_Center:
					return "水平居中";

					// = 147
				case PreviewStringId.WMForm_HorzAlign_Right:
					return "靠右";

					// = 148
				case PreviewStringId.WMForm_ZOrderRgrItem_InFront:
					return "置于顶层 (&F)";

					// = 149
				case PreviewStringId.WMForm_ZOrderRgrItem_Behind:
					return "置于底层 (&B)";

					// = 150
				case PreviewStringId.WMForm_PageRangeRgrItem_All:
					return "全部 (&A)";

					// = 151
				case PreviewStringId.WMForm_PageRangeRgrItem_Pages:
					return "页码 (&P):";

					// = 152
				case PreviewStringId.dlgSaveAs:
					return "";

					// = 153
				case PreviewStringId.SaveDlg_Title:
					return "另存为";

					// = 154
				case PreviewStringId.SaveDlg_FilterPdf:
					return "PDF文档";

					// = 155
				case PreviewStringId.SaveDlg_FilterTxt:
					return "Text文档";

					// = 156
				case PreviewStringId.SaveDlg_FilterCsv:
					return "CSV文档";

					// = 157
				case PreviewStringId.SaveDlg_FilterMht:
					return "MHT文档";

					// = 158
				case PreviewStringId.SaveDlg_FilterXls:
					return "Excel文档";

					// = 159
				case PreviewStringId.SaveDlg_FilterRtf:
					return "RTF文档";

					// = 160
				case PreviewStringId.SaveDlg_FilterHtm:
					return "HTML文档";

					// = 161
				case PreviewStringId.MenuItem_File:
					return "文件 (&F)";

					// = 162
				case PreviewStringId.MenuItem_View:
					return "视图 (&V)";

					// = 163
				case PreviewStringId.MenuItem_Background:
					return "背景 (&B)";

					// = 164
				case PreviewStringId.MenuItem_PageSetup:
					return "页面设置 (&U)";

					// = 165
				case PreviewStringId.MenuItem_Print:
					return "打印 (&P)...";

					// = 166
				case PreviewStringId.MenuItem_PrintDirect:
					return "直接打印 (&R)";

					// = 167
				case PreviewStringId.MenuItem_Export:
					return "导出 (&E)";

					// = 168
				case PreviewStringId.MenuItem_Send:
					return "发送 (&D)";

					// = 169
				case PreviewStringId.MenuItem_Exit:
					return "退出 (&X)";

					// = 170
				case PreviewStringId.MenuItem_ViewToolbar:
					return "工具栏 (&T)";

					// = 171
				case PreviewStringId.MenuItem_ViewStatusbar:
					return "状态栏 (&S)";

					// = 172
				case PreviewStringId.MenuItem_ViewContinuous:
					// return "&Continuous";
					return "连续";

					// = 173
				case PreviewStringId.MenuItem_ViewFacing:
					//return "&Facing";
					return "单页";

					// = 174
				case PreviewStringId.MenuItem_BackgrColor:
					return "颜色 (&C)...";

					// = 175
				case PreviewStringId.MenuItem_Watermark:
					return "水印 (&W)...";

					// = 176
				case PreviewStringId.MenuItem_ZoomPageWidth:
					// return "Page Width";
					return "页宽";

					// = 177
				case PreviewStringId.MenuItem_ZoomTextWidth:
					// return "Text Width";
					return "文字宽度";

					// = 178
				case PreviewStringId.MenuItem_ZoomWholePage:
					// return "Whole Page";
					return "整页";

					// = 179
				case PreviewStringId.MenuItem_ZoomTwoPages:
					// return "Two Pages";
					return "双页";

					// = 180
				case PreviewStringId.PageInfo_PageNumber:
					// return "[Page #]";
					return "[页码]";

					// = 181
				case PreviewStringId.PageInfo_PageNumberOfTotal:
					// return "[Page # of Pages #]";
					return "[当前页码 总页数]";

					// = 182
				case PreviewStringId.PageInfo_PageDate:
					// return "[Date Printed]";
					return "[打印日期]";

					// = 183
				case PreviewStringId.PageInfo_PageTime:
					// return "[Time Printed]";
					return "[打印时间]";

					// = 184
				case PreviewStringId.PageInfo_PageUserName:
					// return "[User Name]";
					return "[打印人]";

					// = 185
				case PreviewStringId.dlgSendFrom:
					return "";

					// = 186
				case PreviewStringId.EMail_From:
					// return "From";
					return "文档来自于";

					// = 187
				case PreviewStringId.BarText_Toolbar:
					return "工具栏";

					// = 188
				case PreviewStringId.BarText_MainMenu:
					return "主菜单";

					// = 189
				case PreviewStringId.BarText_StatusBar:
					return "状态栏";
			}

			return base.GetLocalizedString(id);
		}

		public override string Language
		{
			get
			{
				return "简体中文";
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
					return "文件没有找到。";

					// = 1
				case ReportStringId.Msg_WrongReportClassName:
					// return "An error occurred during deserialization - possible wrong report class name";
					return "反序列化时发生错 - 可能是错误的报表类名";

					// = 2
				case ReportStringId.Msg_CreateReportInstance:
					// return "The report currently being edited is of a different type than the one you are trying to open.\r\nDo you want to open the selected report anyway?";
					return "您试图打开的报表类型与当前编辑的报表类型不相同。\r\n是否确定要打开该报表？";

					// = 3
				case ReportStringId.Msg_FileCorrupted:
					// return "Can't load the report. The file is possibly corrupted or report's assembly is missing.";
					return "不能加载报表，文件可能已损坏或报表组件丢失。";

					// = 4
				case ReportStringId.Msg_FileContentCorrupted:
					// return "Can't load the report's layout. The file is possibly corrupted or contains incorrect information.";
					return "不能加载报表布局，文件可能已损坏或包含不正确的信息。";

					// = 5
				case ReportStringId.Msg_IncorrectArgument:
					// return "Incorrect argument's value";
					return "不正确的参数值";

					// = 6
				case ReportStringId.Msg_InvalidMethodCall:
					// return "This method call is invalid for the object's current state";
					return "对象的当前状态下此方法的调用无效";

					// = 7
				case ReportStringId.Msg_ScriptError:
					// return "There are following errors in script(s):\r\n{0}";
					return "脚本中出现以下错误：\r\n{0}";

					// = 8
				case ReportStringId.Msg_ScriptExecutionError:
					// return "The following error occurred when the script in procedure {0}:\r\n {1}\r\nProcedure {0} was executed, it will not be called again.";
					return "执行脚本时发生错误 {0}:\r\n {1}\r\n过程 {0} 已执行，不能被再次调用。";

					// = 9xxx
				case ReportStringId.Msg_InvalidReportSource:
					// return "Can not be set to a descendant of the current report";
					return "不能设置为当前报表的派生";

					// = 10xxxx
				case ReportStringId.Msg_IncorrectBandType:
					// return "Incorrect band type";
					return "不正确的Band类型";

					// = 11
				case ReportStringId.Msg_InvPropName:
					// return "Invalid property name";
					return "无效的属性名";

					// = 12
				case ReportStringId.Msg_CantFitBarcodeToControlBounds:
					// return "Control's boundaries are too small for the barcode";
					return "条形码控件的边界太小";

					// = 13
				case ReportStringId.Msg_InvalidBarcodeText:
					// return "There are invalid characters in the text";
					return "文本中出现无效字符";

					// = 14
				case ReportStringId.Msg_InvalidBarcodeTextFormat:
					// return "Invalid text format";
					return "无效的文本格式";

					// = 15
				case ReportStringId.Msg_CreateSomeInstance:
					// return "Can't create two instances of a class on a form";
					return "在窗体中不能创建同一个类的两个实例。";

					// = 16
				case ReportStringId.Msg_DontSupportMulticolumn:
					// return "Detail reports don't support multicolumn.";
					return "详细报表不支持多字段。";

					// = 17
				case ReportStringId.Msg_FillDataError:
					// return "Error when trying to populate the datasource. The following exception was thrown:";
					return "试图加载数据时发生错误。抛出以下异常：";

					// = 18
				case ReportStringId.Msg_CyclicBoormarks:
					// return "There are cyclic bookmarks in the report.";
					return "报表中出现循环书签。";

					// = 19
				case ReportStringId.Msg_LargeText:
					// return "Text is too large.";
					return "文本太长";

					// = 20
				case ReportStringId.Msg_ScriptingPermissionErrorMessage:
					// return "You don't have sufficient permission to execute the scripts in this report.\r\n\r\nDetails:\r\n\r\n{0}";
					return "没有足够的权限执行脚本。\r\n\r\n详细：\r\n\r\n{0}";

					// = 21
				case ReportStringId.Msg_ReportImporting:
					// return "Importing a report layout. Please, wait...";
					return "正在导入报表布局，请稍候...";

					// = 22
				case ReportStringId.Msg_IncorrectPadding:
					// return "The padding should be greater than or equal to 0";
					return "衬垫应大于等于0";

					// = 23
				case ReportStringId.Msg_WarningControlsAreOverlapped:
					// return "Export warning: The following controls are overlapped and may be exported to HTML, XLS and RTF incorrectly - {0}.";
					return "导出警告：以下控件发生重叠，可能不能正确地导出为HTML、XLS和RTF - {0}。";

					// = 24
				case ReportStringId.Msg_WarningControlsAreOutOfMargin:
					// return "Printing warning: The following controls are outside the right page margin, and this will cause extra pages to be printed - {0}.";
					return "打印警告：以下控件超出页面的右边界，将需要更多的纸张来完成打印 - {0}。";

					// = 25
				case ReportStringId.Msg_ShapeRotationToolTip:
					// return "Use Ctrl with the left mouse button to rotate the shape";
					return "控制鼠标的左键来旋转。";

					// = 26
				case ReportStringId.Msg_ScriptingErrorTitle:
					return "";

					// = 27
				case ReportStringId.Msg_ErrorTitle:
					// return "Error";
					return "错误";

					// = 28
				case ReportStringId.Msg_SerializationErrorTitle:
					// return "Serialization Error";
					return "序列化错误";

					// = 29
				case ReportStringId.Cmd_InsertDetailReport:
					// return "Insert Detail Report";
					return "插入详细报表";

					// = 30
				case ReportStringId.Cmd_InsertUnboundDetailReport:
					// return "Unbound";
					return "非绑定";

					// = 31
				case ReportStringId.Cmd_ViewCode:
					// return "View &Code";
					return "视图代码 (&C)";

					// = 32
				case ReportStringId.Cmd_BringToFront:
					// return "&Bring To Front";
					return "置于顶层 (&B)";

					// = 33
				case ReportStringId.Cmd_SendToBack:
					// return "&Send To Back";
					return "置于底层 (&S)";

					// = 34
				case ReportStringId.Cmd_AlignToGrid:
					// return "Align To &Grid";
					return "对齐到网格 (&G)";

					// = 35
				case ReportStringId.Cmd_TopMargin:
					// return "TopMargin";
					return "顶端空白";

					// = 36
				case ReportStringId.Cmd_BottomMargin:
					// return "BottomMargin";
					return "底端空白";

					// = 37
				case ReportStringId.Cmd_ReportHeader:
					// return "ReportHeader";
					return "报表尾";

					// = 38
				case ReportStringId.Cmd_ReportFooter:
					// return "ReportFooter";
					return "报表尾";

					// = 39
				case ReportStringId.Cmd_PageHeader:
					// return "PageHeader";
					return "页首";

					// = 40
				case ReportStringId.Cmd_PageFooter:
					// return "PageFooter";
					return "页尾";

					// = 41
				case ReportStringId.Cmd_GroupHeader:
					// return "GroupHeader";
					return "群组首";

					// = 42
				case ReportStringId.Cmd_GroupFooter:
					// return "GroupFooter";
					return "群组尾";

					// = 43
				case ReportStringId.Cmd_Detail:
					// return "Detail";
					return "详细";

					// = 44
				case ReportStringId.Cmd_DetailReport:
					// return "DetailReport";
					return "详细报表";

					// = 45
				case ReportStringId.Cmd_RtfClear:
					// return "Clear";
					return "清除";

					// = 46
				case ReportStringId.Cmd_RtfLoad:
					// return "Load File...";
					return "加载文件...";

					// = 47
				case ReportStringId.Cmd_TableInsert:
					// return "&Insert";
					return "插入 (&I)";

					// = 48
				case ReportStringId.Cmd_TableInsertRowAbove:
					// return "Row &Above";
					return "上行 (&A)";

					// = 49
				case ReportStringId.Cmd_TableInsertRowBelow:
					// return "Row &Below";
					return "下行 (&B)";

					// = 50
				case ReportStringId.Cmd_TableInsertColumnToLeft:
					// return "Column To &Left";
					return "左列 (&L)";

					// = 51
				case ReportStringId.Cmd_TableInsertColumnToRight:
					// return "Column To &Right";
					return "右列 (&R)";

					// = 52
				case ReportStringId.Cmd_TableInsertCell:
					// return "&Cell";
					return "单元格 (&C)";

					// = 53
				case ReportStringId.Cmd_TableDelete:
					// return "De&lete";
					return "删除 (&L)";

					// = 54
				case ReportStringId.Cmd_TableDeleteRow:
					// return "&Row";
					return "行 (&R)";

					// = 55
				case ReportStringId.Cmd_TableDeleteColumn:
					// return "&Column";
					return "列 (&C)";

					// = 56
				case ReportStringId.Cmd_TableDeleteCell:
					// return "Ce&ll";
					return "单元格 (&L)";

					// = 57
				case ReportStringId.Cmd_Cut:
					// return "Cu&t";
					return "剪切 (&T)";

					// = 58
				case ReportStringId.Cmd_Copy:
					// return "Cop&y";
					return "复制 (&Y)";

					// = 59
				case ReportStringId.Cmd_Paste:
					// return "&Paste";
					return "粘贴 (&P)";

					// = 60
				case ReportStringId.Cmd_Delete:
					// return "&Delete";
					return "删除 (&D)";

					// = 61
				case ReportStringId.Cmd_Properties:
					// return "P&roperties";
					return "属性 (&P)";

					// = 62
				case ReportStringId.Cmd_InsertBand:
					// return "Insert &Band";
					return "插入Band (&B)";

					// = 63
				case ReportStringId.CatLayout:
					// return "Layout";
					return "布局";

					// = 64
				case ReportStringId.CatAppearance:
					// return "Appearance";
					return "外观";

					// = 65
				case ReportStringId.CatData:
					// return "Data";
					return "数据";

					// = 66xxxx
				case ReportStringId.CatBehavior:
					// return "Behavior";
					return "状态";

					// = 67
				case ReportStringId.CatNavigation:
					// return "Navigation";
					return "导航";

					// = 68
				case ReportStringId.CatPageSettings:
					// return "PageSettings";
					return "页面设置";

					// = 69
				case ReportStringId.CatUserDesigner:
					// return "UserDesigner";
					return "用户设计";

					// = 70
				case ReportStringId.BandDsg_QuantityPerPage:
					// return "one band per page";
					return "页面的Band";

					// = 71
				case ReportStringId.BandDsg_QuantityPerReport:
					// return "one band per report";
					return "报表的Band";

					// = 72
				case ReportStringId.UD_ReportDesigner:
					// return "Report Designer";
					return "报表设计器";

					// = 73
				case ReportStringId.UD_Msg_ReportChanged:
					// return "Report has been changed. Do you want to save changes ?";
					return "报表的内容已被修改，是否保存更改？";

					// = 74
				case ReportStringId.UD_TTip_FileOpen:
					// return "Open File";
					return "打开文件";

					// = 75
				case ReportStringId.UD_TTip_FileSave:
					// return "Save File";
					return "保存文件";

					// = 76
				case ReportStringId.UD_TTip_EditCut:
					// return "Cut";
					return "剪切";

					// = 77
				case ReportStringId.UD_TTip_EditCopy:
					// return "Copy";
					return "复制";

					// = 78
				case ReportStringId.UD_TTip_EditPaste:
					// return "Paste";
					return "粘贴";

					// = 79
				case ReportStringId.UD_TTip_Undo:
					// return "Undo";
					return "撤消";

					// = 80
				case ReportStringId.UD_TTip_Redo:
					// return "Redo";
					return "重复";

					// = 81
				case ReportStringId.UD_TTip_AlignToGrid:
					// return "Align to Grid";
					return "对齐到网格";

					// = 82
				case ReportStringId.UD_TTip_AlignLeft:
					// return "Align Lefts";
					return "左对齐";

					// = 83
				case ReportStringId.UD_TTip_AlignVerticalCenters:
					// return "Align Centers";
					return "居中对齐";

					// = 84
				case ReportStringId.UD_TTip_AlignRight:
					// return "Align Rights";
					return "右对齐";

					// = 85
				case ReportStringId.UD_TTip_AlignTop:
					// return "Align Tops";
					return "顶端对齐";

					// = 86
				case ReportStringId.UD_TTip_AlignHorizontalCenters:
					// return "Align Middles";
					return "中间对齐";

					// = 87
				case ReportStringId.UD_TTip_AlignBottom:
					// return "Align Bottoms";
					return "底端对齐";

					// = 88
				case ReportStringId.UD_TTip_SizeToControlWidth:
					// return "Make Same Width";
					return "使宽度相同";

					// = 89
				case ReportStringId.UD_TTip_SizeToGrid:
					// return "Size to Grid";
					return "按网格调整大小";

					// = 90
				case ReportStringId.UD_TTip_SizeToControlHeight:
					// return "Make Same Height";
					return "使高度相同";

					// = 91
				case ReportStringId.UD_TTip_SizeToControl:
					// return "Make Same size";
					return "使大小相同";

					// = 92
				case ReportStringId.UD_TTip_HorizSpaceMakeEqual:
					// return "Make Horizontal Spacing Equal";
					return "使水平间距相同";

					// = 93
				case ReportStringId.UD_TTip_HorizSpaceIncrease:
					// return "Increase Horizontal Spacing";
					return "增加水平间距";

					// = 94
				case ReportStringId.UD_TTip_HorizSpaceDecrease:
					// return "Decrease Horizontal Spacing";
					return "减小水平间距";

					// = 95
				case ReportStringId.UD_TTip_HorizSpaceConcatenate:
					// return "Remove Horizontal Spacing";
					return "移除水平间距";

					// = 96
				case ReportStringId.UD_TTip_VertSpaceMakeEqual:
					// return "Make Vertical Spacing Equal";
					return "使垂直间距相同";

					// = 97
				case ReportStringId.UD_TTip_VertSpaceIncrease:
					// return "Increase Vertical Spacing";
					return "增加垂直间距";

					// = 98
				case ReportStringId.UD_TTip_VertSpaceDecrease:
					// return "Decrease Vertical Spacing";
					return "减小垂直间距";

					// = 99
				case ReportStringId.UD_TTip_VertSpaceConcatenate:
					// return "Remove Vertical Spacing";
					return "移除垂直间距";

					// = 100
				case ReportStringId.UD_TTip_CenterHorizontally:
					// return "Center Horizontally";
					return "水平居中";

					// = 101
				case ReportStringId.UD_TTip_CenterVertically:
					// return "CenterVertically";
					return "垂直居中";

					// = 102
				case ReportStringId.UD_TTip_BringToFront:
					// return "Bring to Front";
					return "置于顶层";

					// = 103
				case ReportStringId.UD_TTip_SendToBack:
					// return "Send to Back";
					return "置于底层 ";

					// = 104
				case ReportStringId.UD_TTip_FormatBold:
					// return "Bold";
					return "加粗";

					// = 105
				case ReportStringId.UD_TTip_FormatItalic:
					// return "Italic";
					return "倾斜";

					// = 106
				case ReportStringId.UD_TTip_FormatUnderline:
					// return "Underline";
					return "下划线";

					// = 107
				case ReportStringId.UD_TTip_FormatAlignLeft:
					// return "Align Left";
					return "靠左";

					// = 108
				case ReportStringId.UD_TTip_FormatCenter:
					// return "Center";
					return "居中";

					// = 109
				case ReportStringId.UD_TTip_FormatAlignRight:
					// return "Align Right";
					return "靠右";

					// = 110
				case ReportStringId.UD_TTip_FormatFontName:
					// return "Font Name";
					return "字体";

					// = 111
				case ReportStringId.UD_TTip_FormatFontSize:
					// return "Font Size";
					return "字号";

					// = 112
				case ReportStringId.UD_TTip_FormatForeColor:
					// return "Foreground Color";
					return "字体颜色";

					// = 113
				case ReportStringId.UD_TTip_FormatBackColor:
					// return "Background Color";
					return "背景颜色";

					// = 114
				case ReportStringId.UD_TTip_FormatJustify:
					// return "Justify";
					return "调整";

					// = 115
				case ReportStringId.UD_FormCaption:
					// return "Report Designer";
					return "报表设计器";

					// = 116
				case ReportStringId.VS_XtraReportsToolboxCategoryName:
					// return "Developer Express: Reports";
					return "Developer Express: 报表";

					// = 117
				case ReportStringId.UD_XtraReportsToolboxCategoryName:
					// return "Standard Controls";
					return "标准控件";

					// = 118
				case ReportStringId.UD_XtraReportsPointerItemCaption:
					// return "Pointer";
					return "指针";

					// = 119
				case ReportStringId.Verb_EditBands:
					// return "Edit Bands...";
					return "编辑Bands";

					// = 120
				case ReportStringId.Verb_EditGroupFields:
					// return "Edit GroupFields...";
					return "编辑组字段";

					// = 121
				case ReportStringId.Verb_Import:
					// return "Import...";
					return "导入...";

					// = 122
				case ReportStringId.Verb_Save:
					// return "Save...";
					return "保存...";

					// = 123
				case ReportStringId.Verb_About:
					// return "About...";
					return "关于...";

					// = 124
				case ReportStringId.Verb_RTFClear:
					// return "Clear";
					return "清除";

					// = 125
				case ReportStringId.Verb_RTFLoad:
					// return "Load File...";
					return "加载文件...";

					// = 126
				case ReportStringId.Verb_FormatString:
					// return "Format String...";
					return "格式化 字符串...";

					// = 127
				case ReportStringId.Verb_SummaryWizard:
					// return "Summary...";
					return "摘要...";

					// = 128
				case ReportStringId.Verb_ReportWizard:
					// return "Customize report with Wizard";
					return "使用向导自定义报表";

					// = 129
				case ReportStringId.Verb_Insert:
					// return "Insert...";
					return "插入...";

					// = 130
				case ReportStringId.Verb_Delete:
					// return "Delete...";
					return "删除...";

					// = 131
				case ReportStringId.Verb_Bind:
					// return "Bind";
					return "绑定";

					// = 132
				case ReportStringId.Verb_EditText:
					// return "Edit Text";
					return "编辑文本";

					// = 133
				case ReportStringId.FSForm_Lbl_Category:
					// return "Category";
					return "分类XX";

					// = 134
				case ReportStringId.FSForm_Lbl_Prefix:
					// return "Prefix";
					return "前缀";

					// = 135
				case ReportStringId.FSForm_Lbl_Suffix:
					// return "Suffix";
					return "后缀";

					// = 136
				case ReportStringId.FSForm_Lbl_CustomGeneral:
					// return "General format has no specific number format";
					return "一般格式不含特别数字格式";

					// = 137
				case ReportStringId.FSForm_GrBox_Sample:
					// return "Sample";
					return "示例";

					// = 138
				case ReportStringId.FSForm_Tab_StandardTypes:
					// return "Standard Types";
					return "标准类型";

					// = 139
				case ReportStringId.FSForm_Tab_Custom:
					// return "Custom";
					return "自定义";

					// = 140
				case ReportStringId.FSForm_Msg_BadSymbol:
					// return "Bad symbol";
					return "损坏的符号";

					// = 141
				case ReportStringId.FSForm_Btn_Delete:
					// return "Delete";
					return "删除";

					// = 142
				case ReportStringId.BCForm_Lbl_Property:
					// return "Property";
					return "属性";

					// = 143
				case ReportStringId.BCForm_Lbl_Binding:
					// return "Binding";
					return "绑定";

					// = 144
				case ReportStringId.SSForm_Caption:
					// return "Styles Editor";
					return "样式编辑";

					// = 145
				case ReportStringId.SSForm_Btn_Close:
					// return "Close";
					return "关闭";

					// = 146
				case ReportStringId.SSForm_Msg_NoStyleSelected:
					// return "No styles selected";
					return "没有样式被选中";

					// = 147
				case ReportStringId.SSForm_Msg_MoreThanOneStyle:
					// return "You selected more than one style";
					return "你选择了超过一个的样式";

					// = 148
				case ReportStringId.SSForm_Msg_SelectedStylesText:
					// return " selected styles...";
					return "选中的样式...";

					// = 149
				case ReportStringId.SSForm_Msg_StyleSheetError:
					// return "StyleSheet error";
					return "StyleSheet错误";

					// = 150
				case ReportStringId.SSForm_Msg_InvalidFileFormat:
					// return "Invalid file format";
					return "无效的文件格式";

					// = 151
				case ReportStringId.SSForm_Msg_StyleNamePreviewPostfix:
					// return " style";
					return " 样式";

					// = 152
				case ReportStringId.SSForm_Msg_FileFilter:
					// return "Report StyleSheet files (*.repss)|*.repss|All files (*.*)|*.*";
					return "报表StyleSheet files (*.repss)|*.repss|所有文件 (*.*)|*.*";

					// = 153
				case ReportStringId.SSForm_TTip_AddStyle:
					// return "Add style";
					return "添加样式";

					// = 154
				case ReportStringId.SSForm_TTip_RemoveStyle:
					// return "Remove style";
					return "删除样式";

					// = 155
				case ReportStringId.SSForm_TTip_ClearStyles:
					// return "Clear styles";
					return "清空样式";

					// = 156
				case ReportStringId.SSForm_TTip_PurgeStyles:
					// return "Delete unused styles";
					return "删除未使用的样式";

					// = 157
				case ReportStringId.SSForm_TTip_SaveStyles:
					// return "Save styles to file";
					return "将样式保存到文件";

					// = 158
				case ReportStringId.SSForm_TTip_LoadStyles:
					// return "Load styles from file";
					return "从文件中加载样式";

					// = 159
				case ReportStringId.FindForm_Msg_FinishedSearching:
					// return "Finished searching through the document";
					return "搜索文件完成";

					// = 160
				case ReportStringId.FindForm_Msg_TotalFound:
					// return "Total found: ";
					return "合计查找：";

					// = 161
				case ReportStringId.RepTabCtl_HtmlView:
					// return "HTML View";
					return "HTML视图";

					// = 162
				case ReportStringId.RepTabCtl_Preview:
					// return "Preview";
					return "预览";

					// = 163
				case ReportStringId.RepTabCtl_Designer:
					// return "Designer";
					return "设计器";

					// = 164
				case ReportStringId.PanelDesignMsg:
					// return "Place controls here to keep them together";
					return "在此放置不同控件";

					// = 165
				case ReportStringId.MultiColumnDesignMsg1:
					// return "Space for repeating columns.";
					return "重复列之间的空位。";

					// = 166
				case ReportStringId.MultiColumnDesignMsg2:
					// return "Controls placed here will be printed incorrectly.";
					return "此处的控件不能正确打印。";

					// = 167
				case ReportStringId.UD_Group_File:
					// return "&File";
					return "文件(&F)";

					// = 168
				case ReportStringId.UD_Group_Edit:
					// return "&Edit";
					return "编辑(&E)";

					// = 169
				case ReportStringId.UD_Group_View:
					// return "&View";
					return "视图(&V)";

					// = 170
				case ReportStringId.UD_Group_Format:
					// return "Fo&rmat";
					return "格式(&R)";

					// = 171
				case ReportStringId.UD_Group_Font:
					// return "&Font";
					return "字体(&F)";

					// = 172
				case ReportStringId.UD_Group_Justify:
					// return "&Justify";
					return "两端对齐(&J)";

					// = 173
				case ReportStringId.UD_Group_Align:
					// return "&Align";
					return "对齐(&A)";

					// = 174
				case ReportStringId.UD_Group_MakeSameSize:
					// return "&Make Same Size";
					return "使大小相同 (&M)";

					// = 175
				case ReportStringId.UD_Group_HorizontalSpacing:
					// return "&Horizontal Spacing";
					return "水平间距(&H)";

					// = 176
				case ReportStringId.UD_Group_VerticalSpacing:
					// return "&Vertical Spacing";
					return "垂直间距(&H)";

					// = 177
				case ReportStringId.UD_Group_CenterInForm:
					// return "&Center in Form";
					return "对齐窗体中央(&C)";

					// = 178
				case ReportStringId.UD_Group_Order:
					// return "&Order";
					return "顺序(&O)";

					// = 179
				case ReportStringId.UD_Group_ToolbarsList:
					// return "&Toolbars";
					return "工具栏(&T)";

					// = 180
				case ReportStringId.UD_Group_DockPanelsList:
					// return "&Windows";
					return "窗口(&W)";

					// = 181
				case ReportStringId.UD_Capt_MainMenuName:
					// return "Main Menu";
					return "主菜单";

					// = 182
				case ReportStringId.UD_Capt_ToolbarName:
					// return "Toolbar";
					return "工具栏";

					// = 183
				case ReportStringId.UD_Capt_LayoutToolbarName:
					// return "Layout Toolbar";
					return "布局工具栏";

					// = 184
				case ReportStringId.UD_Capt_FormattingToolbarName:
					// return "Formatting Toolbar";
					return "格式工具栏";

					// = 185
				case ReportStringId.UD_Capt_StatusBarName:
					// return "Status Bar";
					return "状态栏";

					// = 186
				case ReportStringId.UD_Capt_ZoomToolbarName:
					// return "Zoom Bar";
					return "缩放栏";

					// = 187
				case ReportStringId.UD_Capt_NewReport:
					// return "&New";
					return "新建(&N)";

					// = 188
				case ReportStringId.UD_Capt_NewWizardReport:
					// return "New with &Wizard...";
					return "使用向导新建(&W)";

					// = 189
				case ReportStringId.UD_Capt_OpenFile:
					// return "&Open...";
					return "开启(&O)";

					// = 190
				case ReportStringId.UD_Capt_SaveFile:
					// return "&Save";
					return "保存(&S)";

					// = 191
				case ReportStringId.UD_Capt_SaveFileAs:
					// return "Save &As...";
					return "另存为(&A)...";

					// = 192
				case ReportStringId.UD_Capt_Exit:
					// return "E&xit";
					return "退出(&X)";

					// = 193
				case ReportStringId.UD_Capt_Cut:
					// return "Cu&t";
					return "剪切 (&T)";

					// = 194
				case ReportStringId.UD_Capt_Copy:
					// return "&Copy";
					return "复制 (&Y)";

					// = 195
				case ReportStringId.UD_Capt_Paste:
					// return "&Paste";
					return "粘贴 (&P)";

					// = 196
				case ReportStringId.UD_Capt_Delete:
					// return "&Delete";
					return "删除 (&D)";

					// = 197
				case ReportStringId.UD_Capt_SelectAll:
					// return "Select &All";
					return "全选 (&A)";

					// = 198
				case ReportStringId.UD_Capt_Undo:
					// return "&Undo";
					return "撤消 (&U)";

					// = 199
				case ReportStringId.UD_Capt_Redo:
					// return "&Redo";
					return "重复 (&R)";

					// = 200
				case ReportStringId.UD_Capt_ForegroundColor:
					// return "For&eground Color";
					return "字体颜色 (&E)";

					// = 201
				case ReportStringId.UD_Capt_BackGroundColor:
					// return "Bac&kground Color";
					return "背景颜色 (&K)";

					// = 202
				case ReportStringId.UD_Capt_FontBold:
					// return "&Bold";
					return "加粗 (&B)";

					// = 203
				case ReportStringId.UD_Capt_FontItalic:
					// return "&Italic";
					return "倾斜 (&I)";

					// = 204
				case ReportStringId.UD_Capt_FontUnderline:
					// return "&Undeline";
					return "下划线 (&U)";

					// = 205
				case ReportStringId.UD_Capt_JustifyLeft:
					// return "&Left";
					return "左对齐 (&L)";

					// = 206
				case ReportStringId.UD_Capt_JustifyCenter:
					// return "&Center";
					return "居中 (&C)";

					// = 207
				case ReportStringId.UD_Capt_JustifyRight:
					// return "&Rights";
					return "右对齐 (&R)";

					// = 208
				case ReportStringId.UD_Capt_JustifyJustify:
					// return "&Justify";
					return "两端对齐 (&J)";

					// = 209
				case ReportStringId.UD_Capt_AlignLefts:
					// return "&Lefts";
					return "左对齐 (&L)";

					// = 210
				case ReportStringId.UD_Capt_AlignCenters:
					// return "&Centers";
					return "居中 (&C)";

					// = 211
				case ReportStringId.UD_Capt_AlignRights:
					// return "&Rights";
					return "右对齐 (&R)";

					// = 212
				case ReportStringId.UD_Capt_AlignTops:
					// return "&Tops";
					return "顶部对齐 (&T)";

					// = 213
				case ReportStringId.UD_Capt_AlignMiddles:
					// return "&Middles";
					return "中间对齐 (&M)";

					// = 214
				case ReportStringId.UD_Capt_AlignBottoms:
					// return "&Bottoms";
					return "底部对齐 (&B)";

					// = 215
				case ReportStringId.UD_Capt_AlignToGrid:
					// return "to &Grid";
					return "对齐到网格 (&G)";

					// = 216
				case ReportStringId.UD_Capt_MakeSameSizeWidth:
					// return "&Width";
					return "宽度 (&W)";

					// = 217
				case ReportStringId.UD_Capt_MakeSameSizeSizeToGrid:
					// return "Size to Gri&d";
					return "按网格调整大小(&D)";

					// = 218
				case ReportStringId.UD_Capt_MakeSameSizeHeight:
					// return "&Height";
					return "高度 (&H)";

					// = 219
				case ReportStringId.UD_Capt_MakeSameSizeBoth:
					// return "&Both";
					return "两者(&B)";

					// = 220
				case ReportStringId.UD_Capt_SpacingMakeEqual:
					// return "Make &Equal";
					return "使相等(&E)";

					// = 221
				case ReportStringId.UD_Capt_SpacingIncrease:
					// return "&Increase";
					return "增加(&I)";

					// = 222
				case ReportStringId.UD_Capt_SpacingDecrease:
					// return "&Decrease";
					return "减少(&D)";

					// = 223
				case ReportStringId.UD_Capt_SpacingRemove:
					// return "&Remove";
					return "移除(&R)";

					// = 224
				case ReportStringId.UD_Capt_CenterInFormHorizontally:
					// return "&Horizontally";
					return "水平(&H)";

					// = 225
				case ReportStringId.UD_Capt_CenterInFormVertically:
					// return "&Vertically";
					return "垂直(&V)";

					// = 226
				case ReportStringId.UD_Capt_OrderBringToFront:
					// return "&Bring to Front";
					return "置于顶层 (&B)";

					// = 227
				case ReportStringId.UD_Capt_OrderSendToBack:
					// return "&Send to Back";
					return "置于底层 (&S)";

					// = 228
				case ReportStringId.UD_Capt_Zoom:
					// return "Zoom";
					return "缩放";

					// = 229
				case ReportStringId.UD_Capt_ZoomIn:
					// return "Zoom In";
					return "放大";

					// = 230
				case ReportStringId.UD_Capt_ZoomOut:
					// return "Zoom Out";
					return "缩小";

					// = 231
				case ReportStringId.UD_Capt_ZoomFactor:
					// return "Zoom Factor: {0}%";
					return "缩放比例：{0}%";

					// = 232
				case ReportStringId.UD_Hint_NewReport:
					// return "Create a new blank report";
					return "创建新报表";

					// = 233
				case ReportStringId.UD_Hint_NewWizardReport:
					// return "Create a new report using the Wizard";
					return "使用向导创建新报表";

					// = 234
				case ReportStringId.UD_Hint_OpenFile:
					// return "Open a report";
					return "打开报表";

					// = 235
				case ReportStringId.UD_Hint_SaveFile:
					// return "Save a report";
					return "保存报表";

					// = 236
				case ReportStringId.UD_Hint_SaveFileAs:
					// return "Save a report with a new name";
					return "用新名称保存报表";

					// = 237
				case ReportStringId.UD_Hint_Exit:
					// return "Close the designer";
					return "关闭设计器";

					// = 238
				case ReportStringId.UD_Hint_Cut:
					// return "Delete the control and copy it to the clipboard";
					return "删除控件并将它复制到剪贴板";

					// = 239
				case ReportStringId.UD_Hint_Copy:
					// return "Copy the control to the clipboard";
					return "将控件复制到剪贴板";

					// = 240
				case ReportStringId.UD_Hint_Paste:
					// return "Add the control from the clipboard";
					return "从剪贴板添加控件";

					// = 241
				case ReportStringId.UD_Hint_Delete:
					// return "Delete the control";
					return "删除控件";

					// = 242
				case ReportStringId.UD_Hint_SelectAll:
					// return "Select all the controls in the document";
					return "选择所有控件";

					// = 243
				case ReportStringId.UD_Hint_Undo:
					// return "Undo the last operation";
					return "撤销最后操作";

					// = 244
				case ReportStringId.UD_Hint_Redo:
					// return "Redo the last operation";
					return "重复最后操作";

					// = 245
				case ReportStringId.UD_Hint_ForegroundColor:
					// return "Set the foreground color of the control";
					return "设置前景色";

					// = 246
				case ReportStringId.UD_Hint_BackGroundColor:
					// return "Set the background color of the control";
					return "设置背景色";

					// = 247
				case ReportStringId.UD_Hint_FontBold:
					// return "Make the font bold";
					return "使字体加粗";

					// = 248
				case ReportStringId.UD_Hint_FontItalic:
					// return "Make the font italic";
					return "使字体倾斜";

					// = 249
				case ReportStringId.UD_Hint_FontUnderline:
					// return "Underline the font";
					return "字体下加下划线";

					// = 250
				case ReportStringId.UD_Hint_JustifyLeft:
					// return "Align the control's text to the left";
					return "对齐控件的文本到左边";

					// = 251
				case ReportStringId.UD_Hint_JustifyCenter:
					// return "Align the control's text to the center";
					return "对齐控件的文本到中间";

					// = 252
				case ReportStringId.UD_Hint_JustifyRight:
					// return "Align the control's text to the right";
					return "对齐控件的文本到右边";

					// = 253
				case ReportStringId.UD_Hint_JustifyJustify:
					// return "Justify the control's text";
					return "对齐控件的文本到两边";

					// = 254
				case ReportStringId.UD_Hint_AlignLefts:
					// return "Left align the selected controls";
					return "使选中的控件左对齐";

					// = 255
				case ReportStringId.UD_Hint_AlignCenters:
					// return "Align the centers of the selected controls vertically";
					return "使选中的控件垂直居中";

					// = 256
				case ReportStringId.UD_Hint_AlignRights:
					// return "Right align the selected controls";
					return "使选中的控件右对齐";

					// = 257
				case ReportStringId.UD_Hint_AlignTops:
					// return "Align the tops of the selected controls";
					return "使选中的控件顶部对齐";

					// = 258
				case ReportStringId.UD_Hint_AlignMiddles:
					// return "Align the centers of the selected controls horizontally";
					return "使选中的控件水平居中";

					// = 259
				case ReportStringId.UD_Hint_AlignBottoms:
					// return "Align the bottoms of the selected controls";
					return "使选中的控件底部对齐";

					// = 260
				case ReportStringId.UD_Hint_AlignToGrid:
					// return "Align the positions of the selected controls to the grid";
					return "使选中的控件对齐到网格";

					// = 261
				case ReportStringId.UD_Hint_MakeSameSizeWidth:
					// return "Make the selected controls have the same width";
					return "使选中的控件宽度相同";

					// = 262
				case ReportStringId.UD_Hint_MakeSameSizeSizeToGrid:
					// return "Size the selected controls to the grid";
					return "调整选中的控件的大小";

					// = 263
				case ReportStringId.UD_Hint_MakeSameSizeHeight:
					// return "Make the selected controls have the same height";
					return "使选中的控件高度相同";

					// = 264
				case ReportStringId.UD_Hint_MakeSameSizeBoth:
					// return "Make the selected controls the same size";
					return "使选中的控件大小相同";

					// = 265
				case ReportStringId.UD_Hint_SpacingMakeEqual:
					// return "Make the spacing between the selected controls equal";
					return "使选中的控件间距相同";

					// = 266
				case ReportStringId.UD_Hint_SpacingIncrease:
					// return "Increase the spacing between the selected controls";
					return "增加选中的控件间距";

					// = 267
				case ReportStringId.UD_Hint_SpacingDecrease:
					// return "Decrease the spacing between the selected controls";
					return "减小选中的控件间距";

					// = 268
				case ReportStringId.UD_Hint_SpacingRemove:
					// return "Remove the spacing between the selected controls";
					return "移除选中的控件间距";

					// = 269
				case ReportStringId.UD_Hint_CenterInFormHorizontally:
					// return "Horizontally center the selected controls within a band";
					return "使选中的控件在Band区域内水平居中";

					// = 270
				case ReportStringId.UD_Hint_CenterInFormVertically:
					// return "Vertically center the selected controls within a band";
					return "使选中的控件在Band区域内垂直居中";

					// = 271
				case ReportStringId.UD_Hint_OrderBringToFront:
					// return "Bring the selected controls to the front";
					return "使选中的控件置于顶层";

					// = 272
				case ReportStringId.UD_Hint_OrderSendToBack:
					// return "Move the selected controls to the back";
					return "使选中的控件置于底层";

					// = 273
				case ReportStringId.UD_Hint_Zoom:
					// return "Select or input the zoom factor";
					return "选择或输入缩放比例";

					// = 274
				case ReportStringId.UD_Hint_ZoomIn:
					// return "Zoom in the design surface";
					return "放大设计界面";

					// = 275
				case ReportStringId.UD_Hint_ZoomOut:
					// return "Zoom out the design surface";
					return "缩小设计界面";

					// = 276
				case ReportStringId.UD_Hint_ViewBars:
					// return "Hide or show the {0}";
					return "隐藏/显示 {0}";

					// = 277
				case ReportStringId.UD_Hint_ViewDockPanels:
					// return "Hide or show the {0} window";
					return "显示/隐藏 {0} 窗口";

					// = 278
				case ReportStringId.UD_Hint_ViewTabs:
					// return "Switch to the {0} tab";
					return "转到 {0} 标签";

					// = 279
				case ReportStringId.UD_Title_FieldList:
					// return "Field List";
					return "字段列表";

					// = 280
				case ReportStringId.UD_Title_ReportExplorer:
					// return "Report Explorer";
					return "报表资源管理器";

					// = 281
				case ReportStringId.UD_Title_PropertyGrid:
					// return "Property Grid";
					return "属性表格";

					// = 282
				case ReportStringId.UD_Title_ToolBox:
					// return "Tool Box";
					return "工具箱";

					// = 283
				case ReportStringId.STag_Name_Text:
					// return "Text";
					return "文本";

					// = 284
				case ReportStringId.STag_Name_DataBinding:
					// return "Data Binding";
					return "数据绑定";

					// = 285
				case ReportStringId.STag_Name_FormatString:
					// return "Format String";
					return "字符串格式化";

					// = 286
				case ReportStringId.STag_Name_ForeColor:
					// return "Fore Color";
					return "前景色";

					// = 287
				case ReportStringId.STag_Name_BackColor:
					// return "Back Color";
					return "背景色";

					// = 288
				case ReportStringId.STag_Name_Font:
					// return "Font";
					return "字体";

					// = 289
				case ReportStringId.STag_Name_LineDirection:
					// return "Line Direction";
					return "线条方向";

					// = 290
				case ReportStringId.STag_Name_LineStyle:
					// return "Line Style";
					return "线条样式";

					// = 291
				case ReportStringId.STag_Name_LineWidth:
					// return "Line Width";
					return "线条宽度";

					// = 292
				case ReportStringId.STag_Name_CanGrow:
					// return "Can Grow";
					return "增长";

					// = 293
				case ReportStringId.STag_Name_CanShrink:
					// return "Can Shrink";
					return "收缩";

					// = 294
				case ReportStringId.STag_Name_Multiline:
					// return "Multiline";
					return "多线";

					// = 295
				case ReportStringId.STag_Name_Summary:
					// return "Summary";
					return "摘要";

					// = 296
				case ReportStringId.STag_Name_Symbology:
					// return "Symbology";
					return "符号";

					// = 297
				case ReportStringId.STag_Name_Module:
					// return "Module";
					return "模块";

					// = 298
				case ReportStringId.STag_Name_ShowText:
					// return "Show Text";
					return "显示文本";

					// = 299
				case ReportStringId.STag_Name_SegmentWidth:
					// return "Segment Width";
					return "分段宽度";

					// = 300
				case ReportStringId.STag_Name_Checked:
					// return "Checked";
					return "已选中";

					// = 301
				case ReportStringId.STag_Name_Image:
					// return "Image";
					return "图像";

					// = 302
				case ReportStringId.STag_Name_ImageUrl:
					// return "Image Url";
					return "图像URL";

					// = 303
				case ReportStringId.STag_Name_ImageSizing:
					// return "Image Sizing";
					return "图象尺寸";

					// = 304
				case ReportStringId.STag_Name_ReportSource:
					// return "Report Source";
					return "报表来源";

					// = 305
				case ReportStringId.STag_Name_PreviewRowCount:
					// return "Preview Row Count";
					return "预览行数";

					// = 306
				case ReportStringId.STag_Name_ShrinkSubReportIconArea:
					// return "Shrink subreport icon's area";
					return "收缩子报表的图标区域";

					// = 307
				case ReportStringId.STag_Name_PageInfo:
					// return "Page Info";
					return "页码信息";

					// = 308
				case ReportStringId.STag_Name_StartPageNumber:
					// return "Start Page Number";
					return "起始页码";

					// = 309
				case ReportStringId.STag_Name_Format:
					// return "Format";
					return "格式";

					// = 310
				case ReportStringId.STag_Name_KeepTogether:
					// return "Keep Together";
					return "保持一致";

					// = 311
				case ReportStringId.STag_Name_Bands:
					return "Bands";

					// = 312
				case ReportStringId.STag_Name_Height:
					// return "Height";
					return "高度";

					// = 313
				case ReportStringId.STag_Name_RepeatEveryPage:
					// return "Repeat Every Page";
					return "重复每个页面";

					// = 314
				case ReportStringId.STag_Name_PrintAtBottom:
					// return "Print At Bottom";
					return "打印在底端";

					// = 315
				case ReportStringId.STag_Name_GroupFields:
					// return "Group Fields";
					return "群组字段";

					// = 316
				case ReportStringId.STag_Name_SortFields:
					// return "Sort Fields";
					return "排序字段";

					// = 317
				case ReportStringId.STag_Name_GroupUnion:
					// return "Group Union";
					return "群组并集";

					// = 318
				case ReportStringId.STag_Name_Level:
					// return "Level";
					return "层次";

					// = 319
				case ReportStringId.STag_Name_ColumnMode:
					// return "Column Mode";
					return "列模式";

					// = 320
				case ReportStringId.STag_Name_ColumnCount:
					// return "Column Count";
					return "列计数";

					// = 321
				case ReportStringId.STag_Name_ColumnWidth:
					// return "Column Width";
					return "列宽";

					// = 322
				case ReportStringId.STag_Name_ColumnSpacing:
					// return "Column Spacing";
					return "列间距";

					// = 323
				case ReportStringId.STag_Name_Direction:
					// return "Direction";
					return "方向";

					// = 324
				case ReportStringId.STag_Name_Watermark:
					// return "Watermark";
					return "水印";

					// = 325
				case ReportStringId.STag_Name_ReportUnit:
					// return "Report Unit";
					return "报表单元";

					// = 326
				case ReportStringId.STag_Name_DataSource:
					// return "Data Source";
					return "数据源";

					// = 327
				case ReportStringId.STag_Name_DataMember:
					// return "Data Member";

					// = 328
				case ReportStringId.STag_Name_DataAdapter:
					// return "Data Adapter";
					return "数据项";

					// = 329
				case ReportStringId.STag_Name_Angle:
					// return "Angle";
					return "角度";

					// = 330
				case ReportStringId.STag_Name_Stretch:
					// return "Stretch";
					return "拉伸";

					// = 331
				case ReportStringId.STag_Name_Shape:
					return "Shape";


					// = 332
				case ReportStringId.STag_Name_Fillet:
					// return "Fillet";
					return "切片";

					// = 333
				case ReportStringId.STag_Name_TailLength:
					// return "Tail Length";
					return "尾巴长度";

					// = 334
				case ReportStringId.STag_Name_TipLength:
					// return "Tip Length";
					return "提示长度";

					// = 335
				case ReportStringId.STag_Name_NumberOfSides:
					// return "Number of Sides";
					return "边的数目";

					// = 336
				case ReportStringId.STag_Name_StarPointCount:
					// return "Star Point Count";
					return "星点数";

					// = 337
				case ReportStringId.STag_Name_Concavity:
					// return "Concavity";
					return "凹度";

					// = 338
				case ReportStringId.STag_Name_ArrowHeight:
					// return "Arrow Height";
					return "箭头高度";

					// = 339
				case ReportStringId.STag_Name_ArrowWidth:
					// return "Arrow Width";
					return "箭头宽度";

					// = 340
				case ReportStringId.STag_Name_VerticalLineWidth:
					// return "Vertical Line Width";
					return "垂直线的宽度";

					// = 341
				case ReportStringId.STag_Name_HorizontalLineWidth:
					// return "Horizontal Line Width";
					return "水平线的宽度";

					// = 342
				case ReportStringId.STag_Name_FillColor:
					// return "Fill Color";
					return "填充色";
			}

			return base.GetLocalizedString(id);
		}

		public override string Language
		{
			get
			{
				return "简体中文";
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
    //                return "'{0}' 相对于 '{1}' 不是一个有效值.";

    //                // = 1xxxx
    //            case SchedulerStringId.Msg_InvalidDayOfWeekForDailyRecurrence:
    //                return "Invalid day of week for a daily recurrence. Only WeekDays.EveryDay, WeekDays.WeekendDays and WeekDays.WorkDays are valid in this context.";

    //                // = 2
    //            case SchedulerStringId.Msg_InternalError:
    //                // return "Internal error!";
    //                return "内部错误!";

    //                // = 3
    //            case SchedulerStringId.Msg_NoMappingForObject:
    //                // return "The following required mappings for the object \r\n {0} are not assigned";
    //                return "对象所需的以下Mapping \r\n {0} 没有赋值。";

    //                // = 4
    //            case SchedulerStringId.Msg_XtraSchedulerNotAssigned:
    //                // return "The SchedulerStorage component is not assigned to the SchedulerControl";
    //                return "组件SchedulerStorage没有赋给SchedulerControl控件";

    //                // = 5
    //            case SchedulerStringId.Msg_InvalidTimeOfDayInterval:
    //                // return "Invalid duration for the TimeOfDayInterval";
    //                return "无效的TimeOfDayInterval时段";

    //                // = 6
    //            case SchedulerStringId.Msg_OverflowTimeOfDayInterval:
    //                // return "Invalid value for the TimeOfDayInterval. Should be less than or equal to a day";
    //                return "无效的TimeOfDayInterval数值。 数值必须少于或相等于一天";

    //                // = 7
    //            case SchedulerStringId.Msg_LoadCollectionFromXml:
    //                // return "The scheduler needs to be in unbound mode to load collection items from xml";
    //                return "从XML加载项目时，调度器必须是在非绑定模式";

    //                // = 8
    //            case SchedulerStringId.AppointmentLabel_None:
    //                // return "None";
    //                return "无";

    //                // = 9
    //            case SchedulerStringId.AppointmentLabel_Important:
    //                // return "Important";
    //                return "重要";

    //                // = 10
    //            case SchedulerStringId.AppointmentLabel_Business:
    //                // return "Business";
    //                return "商务";

    //                // = 11
    //            case SchedulerStringId.AppointmentLabel_Personal:
    //                // return "Personal";
    //                return "个人";

    //                // = 12
    //            case SchedulerStringId.AppointmentLabel_Vacation:
    //                // return "Vacation";
    //                return "休假";

    //                // = 13
    //            case SchedulerStringId.AppointmentLabel_MustAttend:
    //                // return "Must Attend";
    //                return "必须出席";

    //                // = 14
    //            case SchedulerStringId.AppointmentLabel_TravelRequired:
    //                // return "Travel Required";
    //                return "旅游需求";

    //                // = 15
    //            case SchedulerStringId.AppointmentLabel_NeedsPreparation:
    //                // return "Needs Preparation";
    //                return "需要准备";

    //                // = 16
    //            case SchedulerStringId.AppointmentLabel_Birthday:
    //                // return "Birthday";
    //                return "生日";

    //                // = 17
    //            case SchedulerStringId.AppointmentLabel_Anniversary:
    //                // return "Anniversary";
    //                return "周年纪念";

    //                // = 18
    //            case SchedulerStringId.AppointmentLabel_PhoneCall:
    //                // return "Phone Call";
    //                return "通话";

    //                // = 19
    //            case SchedulerStringId.Msg_InvalidEndDate:
    //                // return "The date you entered occurs before the start date.";
    //                return "早于起始日期。";

    //                // = 20
    //            case SchedulerStringId.Caption_Appointment:
    //                // return "{0} - Appointment";
    //                return "{0} - 约会";

    //                // = 21
    //            case SchedulerStringId.Caption_Event:
    //                // return "{0} - Event";
    //                return "{0} - 要事";

    //                // = 22
    //            case SchedulerStringId.Caption_UntitledAppointment:
    //                // return "Untitled";
    //                return "未命名";

    //                // = 23
    //            case SchedulerStringId.Caption_WeekDaysEveryDay:
    //                // return "Day";
    //                return "周的每天";

    //                // = 24
    //            case SchedulerStringId.Caption_WeekDaysWeekendDays:
    //                // return "Weekend day";
    //                return "周末";

    //                // = 25
    //            case SchedulerStringId.Caption_WeekDaysWorkDays:
    //                // return "Weekday";
    //                return "周工作日";

    //                // = 26
    //            case SchedulerStringId.Caption_WeekOfMonthFirst:
    //                // return "First";
    //                return "第一周";

    //                // = 27
    //            case SchedulerStringId.Caption_WeekOfMonthSecond:
    //                // return "Second";
    //                return "第二周";

    //                // = 28
    //            case SchedulerStringId.Caption_WeekOfMonthThird:
    //                // return "Third";
    //                return "第三周";

    //                // = 29
    //            case SchedulerStringId.Caption_WeekOfMonthFourth:
    //                // return "Fourth";
    //                return "第四周";

    //                // = 30
    //            case SchedulerStringId.Caption_WeekOfMonthLast:
    //                // return "Last";
    //                return "最后一周";

    //                // = 31
    //            case SchedulerStringId.Msg_InvalidDayCount:
    //                // return "Invalid day count. Please enter a positive integer value.";
    //                return "无效的天数。请输入一个正整数。";

    //                // = 32
    //            case SchedulerStringId.Msg_InvalidDayCountValue:
    //                // return "Invalid day count. Please enter a positive integer value.";
    //                return "无效的天数。请输入一个正整数。";

    //                // = 33
    //            case SchedulerStringId.Msg_InvalidWeekCount:
    //                // return "Invalid week count. Please enter a positive integer value.";
    //                return "无效的周数。请输入一个正整数。";

    //                // = 34
    //            case SchedulerStringId.Msg_InvalidWeekCountValue:
    //                // return "Invalid week count. Please enter a positive integer value.";
    //                return "无效的周数。请输入一个正整数。";

    //                // = 35
    //            case SchedulerStringId.Msg_InvalidMonthCount:
    //                // return "Invalid month count. Please enter a positive integer value.";
    //                return "无效的月数。请输入一个正整数。";

    //                // = 36
    //            case SchedulerStringId.Msg_InvalidMonthCountValue:
    //                // return "Invalid month count. Please enter a positive integer value.";
    //                return "无效的月数。请输入一个正整数。";

    //                // = 37
    //            case SchedulerStringId.Msg_InvalidYearCount:
    //                // return "Invalid year count. Please enter a positive integer value.";
    //                return "无效的年数。请输入一个正整数。";

    //                // = 38
    //            case SchedulerStringId.Msg_InvalidYearCountValue:
    //                // return "Invalid year count. Please enter a positive integer value.";
    //                return "无效的年数。请输入一个正整数。";

    //                // = 39
    //            case SchedulerStringId.Msg_InvalidOccurrencesCount:
    //                // return "Invalid occurrences count. Please enter a positive integer value.";
    //                return "无效的事件数。请输入一个正整数。";

    //                // = 40
    //            case SchedulerStringId.Msg_InvalidOccurrencesCountValue:
    //                // return "Invalid occurrences count. Please enter a positive integer value.";
    //                return "无效的事务数。请输入一个正整数。";

    //                // = 41
    //            case SchedulerStringId.Msg_InvalidDayNumber:
    //                // return "Invalid day number. Please enter an integer value from 1 to {0}.";
    //                return "日 输入无效。 必须是 1 至 {0} 之间的数值。";

    //                // = 42
    //            case SchedulerStringId.Msg_InvalidDayNumberValue:
    //                // return "Invalid day number. Please enter an integer value from 1 to {0}.";
    //                return "日 输入无效。 必须是 1 至 {0} 之间的数值。";

    //                // = 43
    //            case SchedulerStringId.Msg_WarningDayNumber:
    //                // return "Some months have fewer than {0} days. For these months, the occurrences will fall on the last day of the month.";
    //                return "有些月份少于 {0} 天。 事务将排在这些月的最后一天。";

    //                // = 44
    //            case SchedulerStringId.Msg_InvalidDayOfWeek:
    //                // return "No day selected. Please select at least one day in the week.";
    //                return "没有选择日子。 请在周中至少选择一个日子。";

    //                // = 45
    //            case SchedulerStringId.MenuCmd_OpenAppointment:
    //                // return "&Open";
    //                return "打开 (&O)";

    //                // = 46
    //            case SchedulerStringId.MenuCmd_PrintAppointment:
    //                // return "&Print";
    //                return "打印 (&O)";

    //                // = 47
    //            case SchedulerStringId.MenuCmd_DeleteAppointment:
    //                // return "&Delete";
    //                return "删除 (&D)";

    //                // = 48
    //            case SchedulerStringId.MenuCmd_EditSeries:
    //                // return "&Edit Series";
    //                return "编辑序列 (&E)";

    //                // = 49
    //            case SchedulerStringId.MenuCmd_RestoreOccurrence:
    //                // return "&Restore Default State";
    //                return "恢复至默认状态 (&R)";

    //                // = 50
    //            case SchedulerStringId.MenuCmd_NewAppointment:
    //                // return "New App&ointment";
    //                return "新建约会 (&O)";

    //                // = 51
    //            case SchedulerStringId.MenuCmd_NewAllDayEvent:
    //                // return "New All Day &Event";
    //                return "新建全天要事 (&E)";

    //                // = 52
    //            case SchedulerStringId.MenuCmd_NewRecurringAppointment:
    //                // return "New Recurring &Appointment";
    //                return "新建周期性约会 (&A)";

    //                // = 53
    //            case SchedulerStringId.MenuCmd_NewRecurringEvent:
    //                // return "New Recurring E&vent";
    //                return "新建周期性要事 (&A)";

    //                // = 54
    //            case SchedulerStringId.MenuCmd_GotoThisDay:
    //                // return "Go to This &Day";
    //                return "转到该日期 (&D)";

    //                // = 55
    //            case SchedulerStringId.MenuCmd_GotoToday:
    //                // return "Go to &Today";
    //                return "转到今天 (&T)";

    //                // = 56
    //            case SchedulerStringId.MenuCmd_GotoDate:
    //                // return "&Go to Date...";
    //                return "转到日期 (&G)...";

    //                // = 57
    //            case SchedulerStringId.MenuCmd_OtherSettings:
    //                // return "Other Sett&ings...";
    //                return "其它设置 (&I)..。";

    //                // = 58
    //            case SchedulerStringId.MenuCmd_CustomizeCurrentView:
    //                // return "&Customize Current View...";
    //                return "自定义当前视图 (&C)...";

    //                // = 59
    //            case SchedulerStringId.MenuCmd_CustomizeTimeRuler:
    //                // return "Customize Time Ruler...";
    //                return "自定义时间线...";

    //                // = 60
    //            case SchedulerStringId.MenuCmd_5Minutes:
    //                // return "&5 Minutes";
    //                return "5分钟 (&5)";

    //                // = 61
    //            case SchedulerStringId.MenuCmd_6Minutes:
    //                // return "&6 Minutes";
    //                return "6分钟 (&6)";

    //                // = 62
    //            case SchedulerStringId.MenuCmd_10Minutes:
    //                // return "10 &Minutes";
    //                return "10分钟 (&M)";

    //                // = 63
    //            case SchedulerStringId.MenuCmd_15Minutes:
    //                // return "&15 Minutes";
    //                return "15分钟 (&1)";

    //                // = 64
    //            case SchedulerStringId.MenuCmd_20Minutes:
    //                // return "&20 Minutes";
    //                return "20分钟 (&2)";

    //                // = 65
    //            case SchedulerStringId.MenuCmd_30Minutes:
    //                // return "&30 Minutes";
    //                return "30分钟 (&3)";

    //                // = 66
    //            case SchedulerStringId.MenuCmd_60Minutes:
    //                // return "6&0 Minutes";
    //                return "60分钟 (&6)";

    //                // = 67
    //            case SchedulerStringId.MenuCmd_SwitchViewMenu:
    //                // return "Change View To";
    //                return "改变视图为";

    //                // = 68
    //            case SchedulerStringId.MenuCmd_SwitchToDayView:
    //                // return "&Day View";
    //                return "日历视图 (&D)";

    //                // = 69
    //            case SchedulerStringId.MenuCmd_SwitchToWorkWeekView:
    //                // return "Wo&rk Week View";
    //                return "工作周历视图 (&R)";

    //                // = 70
    //            case SchedulerStringId.MenuCmd_SwitchToWeekView:
    //                // return "&Week View";
    //                return "周历视图 (&W)";

    //                // = 71
    //            case SchedulerStringId.MenuCmd_SwitchToMonthView:
    //                // return "&Month View";
    //                return "月历视图 (&M)";

    //                // = 72
    //            case SchedulerStringId.MenuCmd_ShowTimeAs:
    //                // return "&Show Time As";
    //                return "显示时间为 (&S)";

    //                // = 73
    //            case SchedulerStringId.MenuCmd_Free:
    //                // return "&Free";
    //                return "空闲 (&F)";

    //                // = 74
    //            case SchedulerStringId.MenuCmd_Busy:
    //                // return "&Busy";
    //                return "忙碌 (&B)";

    //                // = 75
    //            case SchedulerStringId.MenuCmd_Tentative:
    //                // return "&Tentative";
    //                return "暂定 (&T)";

    //                // = 76
    //            case SchedulerStringId.MenuCmd_OutOfOffice:
    //                // return "&Out Of Office";
    //                return "不在办公室 (&O)";

    //                // = 77
    //            case SchedulerStringId.MenuCmd_LabelAs:
    //                // return "&Label As";
    //                return "标注为 (&L)";

    //                // = 78
    //            case SchedulerStringId.MenuCmd_AppointmentLabelNone:
    //                // return "&None";
    //                return "无 (&N)";

    //                // = 79
    //            case SchedulerStringId.MenuCmd_AppointmentLabelImportant:
    //                // return "&Important";
    //                return "重要 (&I)";

    //                // = 80
    //            case SchedulerStringId.MenuCmd_AppointmentLabelBusiness:
    //                // return "&Business";
    //                return "商务 (&B)";

    //                // = 81
    //            case SchedulerStringId.MenuCmd_AppointmentLabelPersonal:
    //                // return "&Personal";
    //                return "个人(P)";

    //                // = 82
    //            case SchedulerStringId.MenuCmd_AppointmentLabelVacation:
    //                // return "&Vacation";
    //                return "休假 (&V)";

    //                // = 83
    //            case SchedulerStringId.MenuCmd_AppointmentLabelMustAttend:
    //                // return "Must &Attend";
    //                return "必须出席 (&A)";

    //                // = 84
    //            case SchedulerStringId.MenuCmd_AppointmentLabelTravelRequired:
    //                // return "&Travel Required";
    //                return "旅游需求 (&T)";

    //                // = 85
    //            case SchedulerStringId.MenuCmd_AppointmentLabelNeedsPreparation:
    //                // return "&Needs Preparation";
    //                return "需要准备 (&N)";

    //                // = 86
    //            case SchedulerStringId.MenuCmd_AppointmentLabelBirthday:
    //                // return "&Birthday";
    //                return "生日 (&B)";

    //                // = 87
    //            case SchedulerStringId.MenuCmd_AppointmentLabelAnniversary:
    //                // return "&Anniversary";
    //                return "周年纪念 (&A)";

    //                // = 88
    //            case SchedulerStringId.MenuCmd_AppointmentLabelPhoneCall:
    //                // return "Phone &Call";
    //                return "通话 (&P)";

    //                // = 89
    //            case SchedulerStringId.MenuCmd_AppointmentMove:
    //                // return "Mo&ve";
    //                return "移动 (&V)";

    //                // = 90
    //            case SchedulerStringId.MenuCmd_AppointmentCopy:
    //                // return "&Copy";
    //                return "复制 (&C)";

    //                // = 91
    //            case SchedulerStringId.MenuCmd_AppointmentCancel:
    //                // return "C&ancel";
    //                return "取消 (&A)";

    //                // = 92
    //            case SchedulerStringId.Caption_5Minutes:
    //                // return "5 Minutes";
    //                return "5分钟";

    //                // = 93
    //            case SchedulerStringId.Caption_6Minutes:
    //                // return "6 Minutes";
    //                return "6分钟";

    //                // = 94
    //            case SchedulerStringId.Caption_10Minutes:
    //                // return "10 Minutes";
    //                return "10分钟";

    //                // = 95
    //            case SchedulerStringId.Caption_15Minutes:
    //                // return "15 Minutes";
    //                return "15分钟";

    //                // = 96
    //            case SchedulerStringId.Caption_20Minutes:
    //                // return "20 Minutes";
    //                return "20分钟";

    //                // = 97
    //            case SchedulerStringId.Caption_30Minutes:
    //                // return "30 Minutes";
    //                return "30分钟";

    //                // = 98
    //            case SchedulerStringId.Caption_60Minutes:
    //                // return "60 Minutes";
    //                return "60分钟";

    //                // = 99
    //            case SchedulerStringId.Caption_Free:
    //                // return "Free";
    //                return "空闲";

    //                // = 100
    //            case SchedulerStringId.Caption_Busy:
    //                // return "Busy";
    //                return "忙碌";

    //                // = 101
    //            case SchedulerStringId.Caption_Tentative:
    //                // return "Tentative";
    //                return "暂定";

    //                // = 102
    //            case SchedulerStringId.Caption_OutOfOffice:
    //                // return "Out Of Office";
    //                return "不在办公室";

    //                // = 103
    //            case SchedulerStringId.ViewDisplayName_Day:
    //                // return "Day Calendar";
    //                return "日历";

    //                // = 104
    //            case SchedulerStringId.ViewDisplayName_WorkDays:
    //                // return "Work Week Calendar";
    //                return "工作周历";

    //                // = 105
    //            case SchedulerStringId.ViewDisplayName_Week:
    //                // return "Week Calendar";
    //                return "周历";

    //                // = 106
    //            case SchedulerStringId.ViewDisplayName_Month:
    //                // return "Month Calendar";
    //                return "月历";

    //                // = 107
    //            case SchedulerStringId.Abbr_MinutesShort1:
    //                // return "m";
    //                return "分";

    //                // = 108
    //            case SchedulerStringId.Abbr_MinutesShort2:
    //                // return "min";
    //                return "分";

    //                // = 109
    //            case SchedulerStringId.Abbr_Minute:
    //                // return "minute";
    //                return "分钟";

    //                // = 110
    //            case SchedulerStringId.Abbr_Minutes:
    //                // return "minutes";
    //                return "分钟";

    //                // = 111
    //            case SchedulerStringId.Abbr_HoursShort:
    //                // return "h";
    //                return "时";

    //                // = 112
    //            case SchedulerStringId.Abbr_Hour:
    //                // return "hour";
    //                return "小时";

    //                // = 113
    //            case SchedulerStringId.Abbr_Hours:
    //                // return "hours";
    //                return "小时";

    //                // = 114
    //            case SchedulerStringId.Abbr_DaysShort:
    //                // return "d";
    //                return "日";

    //                // = 115
    //            case SchedulerStringId.Abbr_Day:
    //                // return "day";
    //                return "天";

    //                // = 116
    //            case SchedulerStringId.Abbr_Days:
    //                // return "days";
    //                return "天";

    //                // = 117
    //            case SchedulerStringId.Abbr_WeeksShort:
    //                // return "w";
    //                return "周";

    //                // = 118
    //            case SchedulerStringId.Abbr_Week:
    //                // return "week";
    //                return "周";

    //                // = 119
    //            case SchedulerStringId.Abbr_Weeks:
    //                // return "weeks";
    //                return "周";

    //                // = 120
    //            case SchedulerStringId.Abbr_Month:
    //                // return "month";
    //                return "月";

    //                // = 121
    //            case SchedulerStringId.Abbr_Months:
    //                // return "months";
    //                return "个月";

    //                // = 122
    //            case SchedulerStringId.Abbr_Year:
    //                // return "year";
    //                return "年";

    //                // = 123
    //            case SchedulerStringId.Abbr_Years:
    //                // return "years";
    //                return "年";

    //                // = 124
    //            case SchedulerStringId.Caption_Reminder:
    //                // return "{0} Reminder";
    //                return "{0} 提醒";

    //                // = 125
    //            case SchedulerStringId.Caption_Reminders:
    //                // return "{0} Reminders";
    //                return "{0} 提醒";

    //                // = 126
    //            case SchedulerStringId.Caption_StartTime:
    //                // return "Start time: {0}";
    //                return "起始时间：{0}";

    //                // = 127
    //            case SchedulerStringId.Caption_NAppointmentsAreSelected:
    //                // return "{0} appointments are selected";
    //                return "约会 {0} 被选中";

    //                // = 128
    //            case SchedulerStringId.Format_TimeBeforeStart:
    //                // return "{0} before start";
    //                return "{0} 在起始之前";

    //                // = 129
    //            case SchedulerStringId.Msg_Conflict:
    //                // return "An edited appointment conflicts with one or several other appointments.";
    //                return "编辑后的约会与其它一项或多项约会出现冲突。";

    //                // = 130
    //            case SchedulerStringId.Msg_InvalidAppointmentDuration:
    //                // return "Invalid value specified for the interval duration. Please enter a positive value.";
    //                return "无效的持续时间。请输入一个整数。";

    //                // = 131
    //            case SchedulerStringId.Msg_InvalidReminderTimeBeforeStart:
    //                // return "Invalid value specified for the before event reminder's time. Please enter a positive value.";
    //                return "无效的提醒时间。请输入一个整数。";

    //                // = 132
    //            case SchedulerStringId.TextDuration_FromTo:
    //                // return "from {0} to {1}";
    //                return "从{0}到{1}";

    //                // = 133
    //            case SchedulerStringId.TextDuration_FromForDays:
    //                // return "from {0} for {1} ";
    //                return "从{0}开始 持续{1}";

    //                // = 134
    //            case SchedulerStringId.TextDuration_FromForDaysHours:
    //                // return "from {0} for {1} {2}";
    //                return "从{0}开始 持续{1}{2}";

    //                // = 135
    //            case SchedulerStringId.TextDuration_FromForDaysMinutes:
    //                // return "from {0} for {1} {3}";
    //                return "从{0}开始 持续{1}{3}";

    //                // = 136
    //            case SchedulerStringId.TextDuration_FromForDaysHoursMinutes:
    //                // return "from {0} for {1} {2} {3}";
    //                return "从{0}开始 持续{1}{2}{3}";

    //                // = 137
    //            case SchedulerStringId.TextDuration_ForPattern:
    //                // return "{0} {1}";
    //                return "{0}{1}";

    //                // = 138
    //            case SchedulerStringId.TextDailyPatternString_EveryDay:
    //                // return "every {0} {1}";
    //                return "每{0}{1}";

    //                // = 139
    //            case SchedulerStringId.TextDailyPatternString_EveryDays:
    //                // return "every {0} {1} {2}";
    //                return "每{0}{1} {2}";

    //                // = 140
    //            case SchedulerStringId.TextDailyPatternString_EveryWeekDay:
    //                // return "every weekday {0}";
    //                return "每工作日 {0}";

    //                // = 141
    //            case SchedulerStringId.TextDailyPatternString_EveryWeekend:
    //                // return "every weekend {0}";
    //                return "每周末 {0}";

    //                // = 142
    //            case SchedulerStringId.TextWeekly_1Day:
    //                return "{0}";

    //                // = 143
    //            case SchedulerStringId.TextWeekly_2Day:
    //                // return "{0} and {1}";
    //                return "{0}和{1}";

    //                // = 144
    //            case SchedulerStringId.TextWeekly_3Day:
    //                // return "{0}, {1}, and {2}";
    //                return "{0}、{1}和{2}";

    //                // = 145
    //            case SchedulerStringId.TextWeekly_4Day:
    //                // return "{0}， {1}， {2}， and {3}";
    //                return "{0}、{1}、{2}和{3}";

    //                // = 146
    //            case SchedulerStringId.TextWeekly_5Day:
    //                // return "{0}， {1}， {2}， {3}， and {4}";
    //                return "{0}、{1}、{2}、{3}和{4}";

    //                // = 147
    //            case SchedulerStringId.TextWeekly_6Day:
    //                // return "{0}， {1}， {2}， {3}， {4}， and {5}";
    //                return "{0}、{1}、{2}、{3}、{4}和{5}";

    //                // = 148
    //            case SchedulerStringId.TextWeekly_7Day:
    //                // return "{0}， {1}， {2}， {3}， {4}， {5}， and {6}";
    //                return "{0}、{1}、{2}、{3}、{4}、{5}和{6}";

    //                // = 149
    //            case SchedulerStringId.TextWeeklyPatternString_EveryWeek:
    //                // return "every {2} {3}";
    //                return "每{2} {3}";

    //                // = 150
    //            case SchedulerStringId.TextWeeklyPatternString_EveryWeeks:
    //                // return "every {0} {1} on {2} {3}";
    //                return "每{0}{1} 在{2} {3}";

    //                // = 151
    //            case SchedulerStringId.TextMonthlyPatternString_SubPattern:
    //                // return "of every {0} {1} {2}";
    //                return "每{0}{1} {2} ";

    //                // = 152
    //            case SchedulerStringId.TextMonthlyPatterString1:
    //                // return "day {0} {1}";
    //                return "{0}日 {1}";

    //                // = 153
    //            case SchedulerStringId.TextMonthlyPatterString2:
    //                // return "the {0} {1} {2}";
    //                return "{0} {1} {2}";

    //                // = 154
    //            case SchedulerStringId.TextYearlyPattern_YearString1:
    //                // return "every {0} {1} {4}";
    //                return "每年{0}{1}日 {4}";

    //                // = 155
    //            case SchedulerStringId.TextYearlyPattern_YearString2:
    //                // return "the {0} {1} of {2} {5}";
    //                return "每年{2}的{0}{1} {5}";

    //                // = 156
    //            case SchedulerStringId.TextYearlyPattern_YearsString1:
    //                // return "{0} {1} of every {2} {3} {4}";
    //                return "每{2} {3} {4} 的 {0} {1}";

    //                // = 157
    //            case SchedulerStringId.TextYearlyPattern_YearsString2:
    //                //return "the {0} {1} of {2} every {3} {4} {5}";
    //                return "每{3} {4} {5}， {2} 的 {0} {1}";

    //                // = 158
    //            case SchedulerStringId.Caption_AllDay:
    //                // return "All day";
    //                return "全天";

    //                // = 159
    //            case SchedulerStringId.Caption_PleaseSeeAbove:
    //                // return "Please see above";
    //                return "请看上述";

    //                // = 160
    //            case SchedulerStringId.Caption_RecurrenceSubject:
    //                // return "Subject:";
    //                return "主题：";

    //                // = 161
    //            case SchedulerStringId.Caption_RecurrenceLocation:
    //                // return "Location:";
    //                return "地点：";

    //                // = 162
    //            case SchedulerStringId.Caption_RecurrenceStartTime:
    //                // return "Start:";
    //                return "起始：";

    //                // = 163
    //            case SchedulerStringId.Caption_RecurrenceEndTime:
    //                // return "End:";
    //                return "结束：";

    //                // = 164
    //            case SchedulerStringId.Caption_RecurrenceShowTimeAs:
    //                // return "Show Time As:";
    //                return "显示时间为：";

    //                // = 165
    //            case SchedulerStringId.Caption_Recurrence:
    //                // return "Recurrence:";
    //                return "周期性：";

    //                // = 166
    //            case SchedulerStringId.Caption_RecurrencePattern:
    //                // return "Recurrence Pattern:";
    //                return "周期模式：";

    //                // = 167
    //            case SchedulerStringId.Caption_NoneRecurrence:
    //                // return "(none)";
    //                return "(无)";

    //                // = 168
    //            case SchedulerStringId.MemoPrintDateFormat:
    //                return "{0} {1} {2}";

    //                // = 169
    //            case SchedulerStringId.Caption_EmptyResource:
    //                // return "(Any)";
    //                return "任何";

    //                // = 170
    //            case SchedulerStringId.Caption_DailyPrintStyle:
    //                // return "Daily Style";
    //                return "每日样式";

    //                // = 171
    //            case SchedulerStringId.Caption_WeeklyPrintStyle:
    //                // return "Weekly Style";
    //                return "每周样式";

    //                // = 172
    //            case SchedulerStringId.Caption_MonthlyPrintStyle:
    //                // return "Monthly Style";
    //                return "每月样式";

    //                // = 173
    //            case SchedulerStringId.Caption_TrifoldPrintStyle:
    //                // return "Tri-fold Style";
    //                return "三重样式";

    //                // = 174
    //            case SchedulerStringId.Caption_CalendarDetailsPrintStyle:
    //                // return "Calendar Details Style";
    //                return "日历详细样式";

    //                // = 175
    //            case SchedulerStringId.Caption_MemoPrintStyle:
    //                // return "Memo Style";
    //                return "备忘录样式";

    //                // = 176
    //            case SchedulerStringId.Caption_ColorConverterFullColor:
    //                // return "Full Color";
    //                return "全彩";

    //                // = 177
    //            case SchedulerStringId.Caption_ColorConverterGrayScale:
    //                // return "Gray Scale";
    //                return "灰阶";

    //                // = 178
    //            case SchedulerStringId.Caption_ColorConverterBlackAndWhite:
    //                // return "Black And White";
    //                return "黑白";

    //                // = 179
    //            case SchedulerStringId.Caption_ResourceNone:
    //                // return "(None)";
    //                return "(无)";

    //                // = 180
    //            case SchedulerStringId.Caption_ResourceAll:
    //                // return "(All)";
    //                return "(所有)";

    //                // = 181
    //            case SchedulerStringId.PrintPageSetupFormatTabControlCustomizeShading:
    //                // return "<Customize...>";
    //                return "<自定义...>";

    //                // = 182
    //            case SchedulerStringId.PrintPageSetupFormatTabControlSizeAndFontName:
    //                // return "{0} pt. {1}";
    //                return "{0} pt. {1}";

    //                // = 183
    //            case SchedulerStringId.PrintRangeControlInvalidDate:
    //                // return "End date must be greater or equals to start date";
    //                return "结束日期必须大于或等于起始日期";

    //                // = 184
    //            case SchedulerStringId.PrintCalendarDetailsControlDayPeriod:
    //                // return "Day";
    //                return "日";

    //                // = 185
    //            case SchedulerStringId.PrintCalendarDetailsControlWeekPeriod:
    //                // return "Week";
    //                return "周";

    //                // = 186
    //            case SchedulerStringId.PrintCalendarDetailsControlMonthPeriod:
    //                // return "Month";
    //                return "月份";

    //                // = 187
    //            case SchedulerStringId.PrintMonthlyOptControlOnePagePerMonth:
    //                // return "1 page/month";
    //                return "1页每月";

    //                // = 188
    //            case SchedulerStringId.PrintMonthlyOptControlTwoPagesPerMonth:
    //                // return "2 pages/month";
    //                return "2页每月";

    //                // = 189
    //            case SchedulerStringId.PrintTimeIntervalControlInvalidDuration:
    //                // return "Duration must be not greater than day and greater than 0";
    //                return "时长必须超过一天且大于0";

    //                // = 190
    //            case SchedulerStringId.PrintTimeIntervalControlInvalidStartEndTime:
    //                // return "End time must be greater than start time";
    //                return "结束时间必须大于起始时间";

    //                // = 191
    //            case SchedulerStringId.PrintTriFoldOptControlDailyCalendar:
    //                // return "Daily Calendar";
    //                return "日历";

    //                // = 192
    //            case SchedulerStringId.PrintTriFoldOptControlWeeklyCalendar:
    //                // return "Weekly Calendar";
    //                return "周历";

    //                // = 193
    //            case SchedulerStringId.PrintTriFoldOptControlMonthlyCalendar:
    //                // return "Monthly Calendar";
    //                return "月历";

    //                // = 194
    //            case SchedulerStringId.PrintWeeklyOptControlOneWeekPerPage:
    //                // return "1 page/week";
    //                return "1页每周";

    //                // = 195
    //            case SchedulerStringId.PrintWeeklyOptControlTwoWeekPerPage:
    //                // return "2 pages/week";
    //                return "2页每周";

    //                // = 196
    //            case SchedulerStringId.PrintPageSetupFormCaption:
    //                // return "Print Options: {0}";
    //                return "打印选项: {0}";

    //                // = 197
    //            case SchedulerStringId.PrintMoreItemsMsg:
    //                // return "More items...";
    //                return "更多项目...";

    //                // = 198
    //            case SchedulerStringId.PrintNoPrintersInstalled:
    //                // return "No printers installed";
    //                return "没有安装打印机";

    //                // = 199
    //            case SchedulerStringId.Caption_IncreaseVisibleResourcesCount:
    //                // return "Increase visible resources count";
    //                return "增加可见资源数";

    //                // = 200
    //            case SchedulerStringId.Caption_DecreaseVisibleResourcesCount:
    //                // return "Decrease visible resources count";
    //                return "减少可见资源数";

    //                // = 201
    //            case SchedulerStringId.Caption_ShadingApplyToAllDayArea:
    //                // return "All Day Area";
    //                return "全天区";

    //                // = 202
    //            case SchedulerStringId.Caption_ShadingApplyToAppointments:
    //                // return "Appointments";
    //                return "约会";

    //                // = 203
    //            case SchedulerStringId.Caption_ShadingApplyToAppointmentStatuses:
    //                // return "Appointment statuses";
    //                return "约会状态";

    //                // = 204
    //            case SchedulerStringId.Caption_ShadingApplyToHeaders:
    //                // return "Headers";
    //                return "标题";

    //                // = 205
    //            case SchedulerStringId.Caption_ShadingApplyToTimeRulers:
    //                // return "Time Rulers";
    //                return "时间线";

    //                // = 206
    //            case SchedulerStringId.Caption_ShadingApplyToCells:
    //                // return "Cells";
    //                return "单元格";

    //                // = 207
    //            case SchedulerStringId.Msg_InvalidSize:
    //                // return "Invalid value specified for the size.";
    //                return "无效的尺寸值。";

    //                // = 208
    //            case SchedulerStringId.Msg_ApplyToAllStyles:
    //                // return "Apply current printer settings to all styles?";
    //                return "将当前的打印机设置应用到所有样式？";

    //                // = 209
    //            case SchedulerStringId.Msg_MemoPrintNoSelectedItems:
    //                // return "Cannot print unless an item is selected. Select an item, and then try to print again.";
    //                return "未选择项目无法打印。选中项目然后再次尝试打印。";

    //                // = 210
    //            case SchedulerStringId.Caption_AllResources:
    //                // return "All resources";
    //                return "所有资源";

    //                // = 211
    //            case SchedulerStringId.Caption_VisibleResources:
    //                // return "Visible resources";
    //                return "可见资源";

    //                // = 212
    //            case SchedulerStringId.Caption_OnScreenResources:
    //                // return "OnScreen resources";
    //                return "屏幕资源";

    //                // = 213
    //            case SchedulerStringId.Caption_GroupByNone:
    //                // return "None";
    //                return "无";

    //                // = 214
    //            case SchedulerStringId.Caption_GroupByDate:
    //                // return "Date";
    //                return "日期";

    //                // = 215
    //            case SchedulerStringId.Caption_GroupByResources:
    //                // return "Resources";
    //                return "资源";

    //                // = 216
    //            case SchedulerStringId.Msg_InvalidInputFile:
    //                // return "Input file is invalid";
    //                return "输入文件无效";
    //        }

    //        return base.GetLocalizedString(id);
    //    }

    //    public override string Language
    //    {
    //        get
    //        {
    //            return "简体中文";
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
					return "合计";

					// = 1
				case TreeListStringId.MenuFooterMin:
					// return "Min";
					return "最小值";

					// = 2
				case TreeListStringId.MenuFooterMax:
					// return "Max";
					return "最大值";

					// = 3
				case TreeListStringId.MenuFooterCount:
					// return "Count";
					return "计数";

					// = 4
				case TreeListStringId.MenuFooterAverage:
					// return "Average";
					return "平均";

					// = 5
				case TreeListStringId.MenuFooterNone:
					// return "None";
					return "无";

					// = 6
				case TreeListStringId.MenuFooterAllNodes:
					// return "AllNodes";
					return "全部节点";

					// = 7
				case TreeListStringId.MenuFooterSumFormat:
					// return "SUM={0:#.##}";
					return "合计={0:#.##}";

					// = 8
				case TreeListStringId.MenuFooterMinFormat:
					// return "MIN={0}";
					return "最小值={0}";

					// = 9
				case TreeListStringId.MenuFooterMaxFormat:
					// return "MAX={0}";
					return "最大值={0}";

					// = 10
				case TreeListStringId.MenuFooterCountFormat:
					return "{0}";

					// = 11
				case TreeListStringId.MenuFooterAverageFormat:
					// return "AVR={0:#.##}";
					return "平均值={0:#.##}";

					// = 12
				case TreeListStringId.MenuColumnSortAscending:
					// return "Sort Ascending";
					return "升序";

					// = 13
				case TreeListStringId.MenuColumnSortDescending:
					// return "Sort Descending";
					return "降序";

					// = 14
				case TreeListStringId.MenuColumnColumnCustomization:
					// return "Column Chooser";
					return "选择显示列";

					// = 15
				case TreeListStringId.MenuColumnBestFit:
					// return "Best Fit";
					return "最适列宽";

					// = 16
				case TreeListStringId.MenuColumnBestFitAllColumns:
					// return "Best Fit (all columns)";
					return "调整所有列宽";

					// = 17
				case TreeListStringId.ColumnCustomizationText:
					// return "Customization";
					return "选择显示列";

					// = 18
				case TreeListStringId.ColumnNamePrefix:
					// return "col";
					return "列名首标";

					// = 19
				case TreeListStringId.PrintDesignerHeader:
					// return "Print Settings";
					return "打印设置";

					// = 20
				case TreeListStringId.PrintDesignerDescription:
					// return "Set up various printing options for the current treelist.";
					return "为当前的树状列表设置各种的打印选项.";

					// = 21
				case TreeListStringId.InvalidNodeExceptionText:
					// return " Do you want to correct the value ?";
					return "是否确定修改值？";

					// = 22
				case TreeListStringId.MultiSelectMethodNotSupported:
					// return "Specified method will not work when OptionsBehavior.MultiSelect is inactive.";
					return "OptionsBehavior.MultiSelect未激活时，指定方法无法工作。";
			}

			return base.GetLocalizedString(id);
		}

		public override string Language
		{
			get
			{
				return "简体中文";
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
					return "自定义";

					// = 1
				case VGridStringId.RowCustomizationNewCategoryFormText:
					// return "New Category";
					return "新建类别";

					// = 2
				case VGridStringId.RowCustomizationNewCategoryFormLabelText:
					// return "Caption:";
					return "标题:";

					// = 3
				case VGridStringId.RowCustomizationNewCategoryText:
					// return "&New...";
					return "新建 (&N)...";

					// = 4
				case VGridStringId.RowCustomizationDeleteCategoryText:
					// return "&Delete";
					return "删除 (&D)...";

					// = 5
				case VGridStringId.RowCustomizationTabPageCategoriesText:
					// return "Categories";
					return "类别";

					// = 6
				case VGridStringId.RowCustomizationTabPageRowsText:
					// return "Rows";
					return "行";

					// = 7
				case VGridStringId.InvalidRecordExceptionText:
					// return " Do you want to correct the value ?";
					return "是否确定修改值？";

					// = 8
				case VGridStringId.StyleCreatorName:
					// return "customStyleCreator";
					return "自定义样式";
			}

			return base.GetLocalizedString(id);
		}

		public override string Language
		{
			get
			{
				return "简体中文";
			}
		}

	}
}
