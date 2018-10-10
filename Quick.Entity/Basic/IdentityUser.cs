﻿/* ==============================================================================
* 命名空间：Quick.Entity.Basic
* 类 名 称：IdentityUser
* 创 建 者：Qing
* 创建时间：2018-10-09 19:44:04
* CLR 版本：4.0.30319.42000
* 保存的文件名：IdentityUser
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
    public class IdentityUser : SysField
    {
        #region Attribute-Common

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public string IdentityUserOID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        public long Id { get; set; } = TimeUtility.GetTimespans();

        /// <summary>
        /// 用户姓名
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 帐户名
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Account { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [MaxLength(20)]
        public string Phone { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        [MaxLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// 加密参数
        /// </summary>
        [Required]
        public string Salt { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string IdNumber { get; set; }

        /// <summary>
        /// 生日日期
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 头像地址
        /// </summary>
        public string ImageSrc { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public bool Gender { get; set; }

        /// <summary>
        /// 微信号
        /// </summary>
        [MaxLength(50)]
        public string Wechat { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        public long QQ { get; set; }

        /// <summary>
        /// 省份代码
        /// </summary>
        public int ProvinceId { get; set; }

        /// <summary>
        /// 省份名称
        /// </summary>
        [MaxLength(50)]
        public string Province { get; set; }

        /// <summary>
        /// 城市代码
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// 城市名称
        /// </summary>
        [MaxLength(50)]
        public string City { get; set; }

        /// <summary>
        /// 县区Id
        /// </summary>
        public int DistrictId { get; set; }

        /// <summary>
        /// 县区名称
        /// </summary>
        [MaxLength(50)]
        public string District { get; set; }

        /// <summary>
        /// 家庭住址
        /// </summary>
        [MaxLength(200)]
        public string Address { get; set; }

        /// <summary>
        /// 所属院系、部门编号
        /// </summary>
        [Required]
        public long DepartmentId { get; set; }

        /// <summary>
        /// 所属院系、部门名称
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Department { get; set; }

        /// <summary>
        /// 账户类型
        /// 0：管理员账户；1：教职工账户；2：学生用户
        /// </summary>
        [Required]
        public short AccountType { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        [Required]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 主页地址
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string HomePage { get; set; }

        #endregion

        #region Attribute-Instructor

        /// <summary>
        /// 是否为院系负责人
        /// </summary>
        public bool IsMaster { get; set; }

        #endregion

        #region Attribute-Student

        /// <summary>
        /// 准考证号
        /// </summary>
        public long TicketId { get; set; }

        /// <summary>
        /// 辅导员Id
        /// </summary>
        public long InstructorId { get; set; }

        /// <summary>
        /// 辅导员姓名
        /// </summary>
        [MaxLength(20)]
        public string InstructorName { get; set; }

        /// <summary>
        /// 高中名称
        /// </summary>
        [MaxLength(50)]
        public string HighSchool { get; set; }

        /// <summary>
        /// 入学年月
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 毕业年月
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// 专业班级编号
        /// </summary>
        public long MajorClassId { get; set; }

        /// <summary>
        /// 专业班级名称
        /// </summary>
        [MaxLength(20)]
        public string MajorClass { get; set; }

        /// <summary>
        /// 兴趣爱好
        /// </summary>
        [MaxLength(100)]
        public string Hobbies { get; set; }

        /// <summary>
        /// 获奖情况
        /// </summary>
        [MaxLength(500)]
        public string Winning { get; set; }

        #endregion
    }
}
