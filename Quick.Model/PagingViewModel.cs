/* ==============================================================================
* 命名空间：Quick.Model
* 类 名 称：PagingViewModel
* 创 建 者：Qing
* 创建时间：2018-10-10 10:19:01
* CLR 版本：4.0.30319.42000
* 保存的文件名：PagingViewModel
* 文件版本：V1.0.0.0
*
* 功能描述：列表分页字段基类
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

namespace Quick.Model
{
    public class PagingViewModel
    {
        #region Page

        /// <summary>
        /// 每页显示条数
        /// Linq分页查询时Take的参数
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// 每页开始的记录序号
        /// Linq分页查询时Skip的参数
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// 当前页
        /// 返回前端显示当前页码
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 总数据个数
        /// </summary>
        public int Total { get; set; }

        #endregion
    }
}
