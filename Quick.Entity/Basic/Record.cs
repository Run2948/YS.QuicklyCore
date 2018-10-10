/* ==============================================================================
* 命名空间：Quick.Entity.Basic
* 类 名 称：Record
* 创 建 者：Qing
* 创建时间：2018-10-10 10:28:32
* CLR 版本：4.0.30319.42000
* 保存的文件名：Record
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



using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Quick.Utility.System;

namespace Quick.Entity.Basic
{
    public class Record
    {
        #region Attrbite

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public string RecordOID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        public long Id { get; set; } = TimeUtility.GetTimespans();

        /// <summary>
        /// 操作修改表
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string TableName { get; set; }

        /// <summary>
        /// 操作方法所在类
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string ClassName { get; set; }

        /// <summary>
        /// 操作方法名称
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string MethodName { get; set; }

        /// <summary>
        /// 数据项对应编号
        /// </summary>
        [Required]
        public long DataId { get; set; }

        /// <summary>
        /// 操作人主键
        /// </summary>
        [Required]
        public string UserOID { get; set; }

        /// <summary>
        /// 操作人编号
        /// </summary>
        [Required]
        public long UserId { get; set; }

        /// <summary>
        /// 操作人姓名
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime DateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 操作类型
        /// 1：修改；2：删除
        /// </summary>
        [Required]
        public short Type { get; set; }

        /// <summary>
        /// 所做操作
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Operate { get; set; }

        #endregion
    }
}
