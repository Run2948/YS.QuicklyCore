/* ==============================================================================
* 命名空间：Quick.Utility.System
* 类 名 称：DataEncrypt
* 创 建 者：Qing
* 创建时间：2018-10-10 10:13:18
* CLR 版本：4.0.30319.42000
* 保存的文件名：DataEncrypt
* 文件版本：V1.0.0.0
*
* 功能描述：DES对称加密
*
* 修改历史：
*
*
* ==============================================================================
*         CopyRight @ 班纳工作室 2018. All rights reserved
* ==============================================================================*/



using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Quick.Utility.System
{
    public class DataEncrypt
    {
        #region Field

        private const string Key = "1c5D3230A9534CC6abc7E108103604Dd";

        private const string Iv = "bc5YTx+RoeQ=";

        private readonly SymmetricAlgorithm _sym = null;

        #endregion


        #region Encrypt

        public DataEncrypt()
        {
            _sym = new TripleDESCryptoServiceProvider();
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="encryptString">需要加密的字符串</param>
        /// <returns></returns>
        public string EncryptString(string encryptString)
        {
            _sym.Key = Convert.FromBase64String(Key);
            _sym.IV = Convert.FromBase64String(Iv);
            _sym.Mode = CipherMode.ECB;
            _sym.Padding = PaddingMode.PKCS7;

            ICryptoTransform iCrypt = _sym.CreateEncryptor(_sym.Key, _sym.IV);
            byte[] bytes = Encoding.UTF8.GetBytes(encryptString);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, iCrypt, CryptoStreamMode.Write);
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
            cryptoStream.Close();
            return Convert.ToBase64String(memoryStream.ToArray());
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="decryptString">需要解密的字符串</param>
        /// <returns></returns>
        public string DecryptString(string decryptString)
        {
            _sym.Key = Convert.FromBase64String("1c5D3230A9534CC6abc7E108103604Dd");
            _sym.IV = Convert.FromBase64String("bc5YTx+RoeQ=");
            _sym.Mode = CipherMode.ECB;
            _sym.Padding = PaddingMode.PKCS7;
            ICryptoTransform transform = _sym.CreateDecryptor(_sym.Key, _sym.IV);
            byte[] buffer = Convert.FromBase64String(decryptString);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            stream2.Close();
            return Encoding.UTF8.GetString(stream.ToArray());
        }

        #endregion
    }
}
