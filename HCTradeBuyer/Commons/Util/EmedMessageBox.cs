using System;
using System.Windows.Forms;

namespace Emedchina.Commons
{
    /// <summary>
    /// 系统提示辅助类
    /// </summary>
    public class EmedMessageBox
    {
        /// <summary>
        /// 错误提示
        /// </summary>
        /// <param name="inStr"></param>
        public static void ShowError(string inStr)
        {
            MessageBox.Show(inStr, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        /// <summary>
        /// 信息提示
        /// </summary>
        /// <param name="inStr"></param>
        public static void ShowInformation(string inStr)
        {
            MessageBox.Show(inStr, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        /// <summary>
        /// 问题提示
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static bool ShowQuestion(string inStr)
        {
            if (MessageBox.Show(inStr, "系统提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 警告提示
        /// </summary>
        /// <param name="inStr"></param>
        public static void ShowWarning(string inStr)
        {
            MessageBox.Show(inStr, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void ShowWarning(Form inForm, string inStr)
        {
            MessageBox.Show(inForm, inStr, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        /// <summary>
        /// “是”“否”提示
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static bool ShowYesNo(string inStr)
        {
            if (MessageBox.Show(inStr, "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }

    }
}

