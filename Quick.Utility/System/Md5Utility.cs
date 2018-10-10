/* ==============================================================================
* 命名空间：Quick.Utility.System
* 类 名 称：Md5Utility
* 创 建 者：Qing
* 创建时间：2018-10-09 19:41:33
* CLR 版本：4.0.30319.42000
* 保存的文件名：Md5Utility
* 文件版本：V1.0.0.0
*
* 功能描述：MD5校验
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
using System.Security.Cryptography;
using System.Text;

namespace Quick.Utility.System
{
    public class Md5Utility
    {
        #region Service

        /// <summary>
        /// 创建SALT加密字符串
        /// </summary>
        /// <param name="item">需要加密的字符串</param>
        /// <param name="salt">加密的参数</param>
        /// <returns></returns>
        public static string Sign(string item, string salt = "")
        {
            var md5 = new MD5CryptoServiceProvider();

            if (!string.IsNullOrEmpty(salt))
                item = item + "{" + salt.Trim() + "}";

            var bt = Encoding.Default.GetBytes(item);
            var b = md5.ComputeHash(bt);

            return b.Aggregate("", (current, t) => current + t.ToString("X").PadLeft(2, '0'));
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="prestr">需要签名的字符串</param>
        /// <param name="sign">签名结果</param>
        /// <param name="key">密钥</param>
        /// <returns>验证结果</returns>
        public static bool Verify(string prestr, string sign, string key)
        {
            var mysign = Sign(prestr, key);
            return mysign == sign ? true : false;
        }

        #endregion
    }
}
