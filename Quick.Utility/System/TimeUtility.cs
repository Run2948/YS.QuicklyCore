/* ==============================================================================
* 命名空间：Quick.Utility.System
* 类 名 称：TimeUtility
* 创 建 者：Qing
* 创建时间：2018-10-09 19:46:10
* CLR 版本：4.0.30319.42000
* 保存的文件名：TimeUtility
* 文件版本：V1.0.0.0
*
* 功能描述：时间帮助类
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

namespace Quick.Utility.System
{
    public class TimeUtility
    {
        #region Service

        /// <summary>
        /// 获取当前日期时间
        /// </summary>
        /// <param name="hasTime">是否包含时间</param>
        /// <returns></returns>
        public static DateTime Format(bool hasTime = false)
        {
            return hasTime == true ? Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")) : Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        }

        /// <summary>
        /// 获取当前时间的序列
        /// </summary>
        /// <returns></returns>
        public static long GetTimespans()
        {
            return Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
        }

        #endregion
    }
}
