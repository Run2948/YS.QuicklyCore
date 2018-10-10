/* ==============================================================================
* 命名空间：Quick.Entity
* 类 名 称：SysField
* 创 建 者：Qing
* 创建时间：2018-10-09 19:43:20
* CLR 版本：4.0.30319.42000
* 保存的文件名：SysField
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

namespace Quick.Entity
{
    public class SysField
    {
        #region Attribute

        /// <summary>
        /// 创建人Id
        /// </summary>
        public long CreatedId { get; set; }

        /// <summary>
        /// 创建人主键
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// 创建人姓名
        /// </summary>
        [MaxLength(50)]
        public string CreatedName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        /// <summary>
        /// 修改人Id
        /// </summary>
        public long ModifiedId { get; set; }

        /// <summary>
        /// 修改人主键
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// 修改人姓名
        /// </summary>
        [MaxLength(50)]
        public string ModifiedName { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifiedOn { get; set; }

        #endregion
    }
}
