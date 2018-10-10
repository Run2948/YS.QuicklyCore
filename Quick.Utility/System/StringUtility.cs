﻿/* ==============================================================================
* 命名空间：Quick.Utility.System
* 类 名 称：StringUtility
* 创 建 者：Qing
* 创建时间：2018-10-10 10:12:19
* CLR 版本：4.0.30319.42000
* 保存的文件名：StringUtility
* 文件版本：V1.0.0.0
*
* 功能描述：String帮助类
*
* 修改历史：
*
*
* ==============================================================================
*         CopyRight @ 班纳工作室 2018. All rights reserved
* ==============================================================================*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Quick.Utility.System
{
    public class StringUtility
    {
        #region Service

        /// <summary>
        /// 拆分主键集合
        /// </summary>
        /// <param name="oIds"></param>
        /// <returns></returns>
        public static string SeparateOIDs(string[] oIds)
        {
            var builder = new StringBuilder();

            for (var i = 0; i < oIds.Length; i++)
            {
                if (i > 0)
                    builder.Append(",");
                builder.Append("'").Append(oIds[i]).Append("'");
            }

            return builder.ToString();
        }

        /// <summary>
        /// 把字符串按照分隔符转换成 List
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="speater">分隔符</param>
        /// <param name="toLower">是否转换为小写</param>
        /// <returns></returns>
        public static List<string> GetStrArray(string str, char speater, bool toLower)
        {
            var list = new List<string>();
            var ss = str.Split(speater);
            foreach (var s in ss)
                if (!string.IsNullOrEmpty(s) && s != speater.ToString())
                {
                    var strVal = s;
                    if (toLower)
                        strVal = s.ToLower();
                    list.Add(strVal);
                }
            return list;
        }

        /// <summary>
        /// 将HTML标签转换成TEXT文本
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string HtmlToText(string strHtml)
        {
            string[] aryReg ={@"<script[^>]*?>.*?</script>",@"<(\/\s*)?!?((\w+:)?\w+)(\w+(\s*=?\s*(([""'])(\\[""'tbnr]|[^\7])*?\7|\w+)|.{0})|\s)*?(\/\s*)?>",
                @"([\r\n])[\s]+","&(quot|#34);",@"&(amp|#38);",@"&(lt|#60);",@"&(gt|#62);",@"&(nbsp|#160);", @"&(iexcl|#161);",@"&(cent|#162);",@"&(pound|#163);",@"&(copy|#169);",@"&#(\d+);",@"-->",@"<!--.*\n"
            };

            var newReg = aryReg[0];
            var strOutput = aryReg.Select(t => new Regex(t, RegexOptions.IgnoreCase)).Aggregate(strHtml, (current, regex) => regex.Replace(current, string.Empty));

            strOutput = strOutput.Replace("<", "");
            strOutput = strOutput.Replace(">", "");
            strOutput = strOutput.Replace("\r\n", "");

            return strOutput;
        }

        #endregion
    }
}
