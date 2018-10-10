/* ==============================================================================
* 命名空间：Quick.Model
* 类 名 称：LoginViewModel
* 创 建 者：Qing
* 创建时间：2018-10-10 10:18:24
* CLR 版本：4.0.30319.42000
* 保存的文件名：LoginViewModel
* 文件版本：V1.0.0.0
*
* 功能描述：登录视图模型
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

namespace Quick.Model
{
    public class LoginViewModel
    {
        #region Attribute

        /// <summary>
        /// 帐户名
        /// </summary>
        [Required(ErrorMessage = "登录名不能为空")]
        [Display(Name = "登录名")]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        /// <summary>
        /// 是否记住帐户名
        /// </summary>
        [Display(Name = "记住登录名")]
        public bool RememberMe { get; set; }

        #endregion
    }
}
