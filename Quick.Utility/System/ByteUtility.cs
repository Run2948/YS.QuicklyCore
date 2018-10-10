/* ==============================================================================
* 命名空间：Quick.Utility.System
* 类 名 称：ByteUtility
* 创 建 者：Qing
* 创建时间：2018-10-10 10:11:12
* CLR 版本：4.0.30319.42000
* 保存的文件名：ByteUtility
* 文件版本：V1.0.0.0
*
* 功能描述：Byte数组与对象转换
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
using Newtonsoft.Json;

namespace Quick.Utility.System
{
    public class ByteUtility
    {
        #region Service

        /// <summary>
        /// 将对象转换为byte数组
        /// </summary>
        /// <param name="obj">被转换对象</param>
        /// <returns>转换后byte数组</returns>
        public static byte[] Object2Bytes(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            byte[] serializedResult = Encoding.UTF8.GetBytes(json);
            return serializedResult;
        }

        /// <summary>
        /// 将byte数组转换成对象
        /// </summary>
        /// <param name="buff">被转换byte数组</param>
        /// <returns>转换完成后的对象</returns>
        public static object Bytes2Object(byte[] buff)
        {
            string json = Encoding.UTF8.GetString(buff);
            return JsonConvert.DeserializeObject<object>(json);
        }

        /// <summary>
        /// 将byte数组转换成对象
        /// </summary>
        /// <param name="buff">被转换byte数组</param>
        /// <returns>转换完成后的对象</returns>
        public static T Bytes2Object<T>(byte[] buff)
        {
            string json = Encoding.UTF8.GetString(buff);
            return JsonConvert.DeserializeObject<T>(json);
        }

        #endregion
    }
}
