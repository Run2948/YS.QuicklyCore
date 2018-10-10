﻿/* ==============================================================================
* 命名空间：Quick.Utility.Web
* 类 名 称：HtmlUtility
* 创 建 者：Qing
* 创建时间：2018-10-10 10:08:54
* CLR 版本：4.0.30319.42000
* 保存的文件名：HtmlUtility
* 文件版本：V1.0.0.0
*
* 功能描述：Html帮助类
*
* 修改历史：
*
*
* ==============================================================================
*         CopyRight @ 班纳工作室 2018. All rights reserved
* ==============================================================================*/



using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Quick.Utility.Web
{
    public class HtmlUtility
    {
        #region Service

        /// <summary>
        /// 去除用户输入隐患
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string InputText(string str)
        {
            string returnVal = str;
            returnVal = ConvertStr(returnVal);
            returnVal = returnVal.Replace("[url]", "");
            returnVal = returnVal.Replace("[/url]", "");
            return returnVal;
        }

        /// <summary>
        /// 将存储的html代码展示在网页上
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string OutputText(string str)
        {
            var returnVal = HttpUtility.HtmlDecode(str);
            if (returnVal == null)
            {
                return "";
            }

            returnVal = returnVal.Replace("<br>", "");
            returnVal = returnVal.Replace("&amp", "&;");
            returnVal = returnVal.Replace("&quot;", "\"");
            returnVal = returnVal.Replace("&lt;", "<");
            returnVal = returnVal.Replace("&gt;", ">");
            returnVal = returnVal.Replace("&nbsp;", " ");
            returnVal = returnVal.Replace("&nbsp;&nbsp;", "  ");
            return returnVal;
        }

        /// <summary>
        /// 将用户输入的字符串转换为可换行、替换Html编码、无危害数据库特殊字符、去掉首尾空白、的安全方便代码
        /// </summary>
        /// <param name="str">用户输入字符串</param>
        /// <returns></returns>
        private static string ConvertStr(string str)
        {
            string returnVal = str;
            returnVal = returnVal.Replace("\"", "&quot;");
            returnVal = returnVal.Replace("<", "&lt;");
            returnVal = returnVal.Replace(">", "&gt;");
            returnVal = returnVal.Replace(" ", "&nbsp;");
            returnVal = returnVal.Replace("  ", "&nbsp;&nbsp;");
            returnVal = returnVal.Replace("\t", "&nbsp;&nbsp;");
            returnVal = returnVal.Replace("\r", "<br>");
            return returnVal;
        }

        #endregion
    }
}
