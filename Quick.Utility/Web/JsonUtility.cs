/* ==============================================================================
* 命名空间：Quick.Utility.Web
* 类 名 称：JsonUtility
* 创 建 者：Qing
* 创建时间：2018-10-10 10:10:20
* CLR 版本：4.0.30319.42000
* 保存的文件名：JsonUtility
* 文件版本：V1.0.0.0
*
* 功能描述：Json帮助类
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

namespace Quick.Utility.Web
{
    public class JsonUtility
    {
        #region Service

        /// <summary>
        /// 将T对象序列化成Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string ToJson<T>(T model)
        {
            return JsonConvert.SerializeObject(model);
        }

        /// <summary>
        /// 将Json字符串反序列化成T对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T ToObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        #endregion
    }
}
