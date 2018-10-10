/* ==============================================================================
* 命名空间：Quick.Utility
* 类 名 称：CheckUtility
* 创 建 者：Qing
* 创建时间：2018-10-10 10:08:11
* CLR 版本：4.0.30319.42000
* 保存的文件名：CheckUtility
* 文件版本：V1.0.0.0
*
* 功能描述：数据校验帮助类
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
using System.Text.RegularExpressions;

namespace Quick.Utility
{
    public class CheckUtility
    {
        #region Service

        /// <summary>
        /// 判断Email地址是否合法
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static bool IsEmail(string address)
        {
            return Regex.IsMatch(address, @"^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$");
        }

        /// <summary>
        /// 判断是否为Ip地址
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIpAddress(string ip)
        {
            return !string.IsNullOrEmpty(ip) && Regex.IsMatch(ip.Replace(" ", ""), @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){1,3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        /// <summary>
        /// 验证手机号格式是否合法
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool IsPhone(string phone)
        {
            return Regex.IsMatch(phone, @"^[1][3,5,7,9]\d{9}$");
        }

        #endregion
    }
}
