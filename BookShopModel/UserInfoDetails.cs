using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopModel
{
    public class UserInfoDetails
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string LoginId { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string LoginPwd { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string TrueName { get; set; }

        /// <summary>
        /// 性别
        /// ?：表示该属性可以为空，意思是可以为NULL
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 联系地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 注册日期
        /// </summary>
        public DateTime RegDate { get; set; }

        /// <summary>
        /// 用户角色编号
        /// </summary>
        public string Rname { get; set; }

        /// <summary>
        /// 用户状态编号
        /// </summary>
        public string Sname { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public int UserStateId { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 学历/学位
        /// </summary>
        public string Degree { get; set; }
    }
}
