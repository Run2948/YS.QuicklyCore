/* ==============================================================================
* 命名空间：Quick.Entity.Basic
* 类 名 称：Logging
* 创 建 者：Qing
* 创建时间：2018-10-10 10:29:04
* CLR 版本：4.0.30319.42000
* 保存的文件名：Logging
* 文件版本：V1.0.0.0
*
* 功能描述：N/A 
*
* 修改历史：
*
*
* ==============================================================================
*         CopyRight @ 班纳工作室 2018. All rights reserved
* ==============================================================================*/



using Quick.Utility.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Quick.Entity.Basic
{
    public class Logging
    {
        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public string LoggingOID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        public long Id { get; set; } = TimeUtility.GetTimespans();

        /// <summary>
        /// 用户编号
        /// </summary>
        [Required]
        public long UserId { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 用户Ip地址
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// 用户登录时间
        /// </summary>
        public DateTime DateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 浏览器信息
        /// </summary>
        public string Browser { get; set; }

        /// <summary>
        /// 操作系统版本
        /// </summary>
        public string System { get; set; }

        /// <summary>
        /// 屏幕分辨率
        /// </summary>
        public string Screen { get; set; }

        #endregion
    }
}
