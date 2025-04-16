using BookShopCommon;
using BookShopModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopDAL
{
    public class UserInfoDAL
    {
        public UserInfo GetLoginUserById(string loginid,string pwd)
        {
            try
            {

                string sqlstr = "select * from UserInfo t1 where t1.LoginId=@LoginId and t1.LoginPwd=@LoginPwd";

                List<SqlParameter> para = new List<SqlParameter>()
                {
                new SqlParameter("@LoginId",loginid),
                new SqlParameter("@LoginPwd", pwd),
                };

                DataTable dt = DBHelper.GetDataTable(sqlstr, para);

                UserInfo user = null;

                foreach (DataRow item in dt.Rows)
                {
                    user = new UserInfo();
                    user.Id = Convert.ToInt32(item["Id"]);
                    user.LoginId = item["LoginId"].ToString();
                    user.TrueName= item["TrueName"].ToString();
                    user.Gender = Convert.ToInt32(item["Gender"]);
                    //user.Birthday = item["Birthday"].;
                    user.Degree = item["Degree"].ToString();
                    user.Phone= item["Phone"].ToString();
                    user.Email= item["Email"].ToString();
                    user.Address = item["Address"].ToString();
                    user.Description = item["Description"].ToString();
                    user.Origin = item["Origin"].ToString();
                    //user.RegDate=item["RegDate"]
                    user.UserRoleId = Convert.ToInt32(item["UserRoleId"]);
                    user.UserStateId = Convert.ToInt32(item["UserStateId"]);
                }

                return user;

            }
            catch (Exception ex)
            {
                throw ex;
            }


            

            //if (loginid=="yummyyummy"&&pwd=="123123")
            //{
            //    return 1;
            //}
            //else
            //{
            //    return 0;
            //}
        }


        public int AddUser(UserInfo userInfo)
        {
            try
            {
                string sqlstr = @"INSERT INTO UserInfo  
                                    VALUES 
                                    (@LoginId,
                                    @LoginPwd,
                                    @TrueName,
                                    @Gender,
                                    @Birthday,
                                    @Degree,
                                    @Phone,
                                    @Email,
                                    @Address,
                                    @Description,
                                    @Origin,
                                    @RegDate,
                                    @UserRoleId,
                                    @UserStateId)";

                List<SqlParameter> para = new List<SqlParameter>()
                {
                    new SqlParameter("@LoginId",userInfo.LoginId),
                    new SqlParameter("@LoginPwd",userInfo.LoginPwd),
                    new SqlParameter("@TrueName",userInfo.TrueName),
                    new SqlParameter("@Gender",userInfo.Gender),
                    new SqlParameter("@Birthday",userInfo.Birthday),
                    new SqlParameter("@Degree",userInfo.Degree),
                    new SqlParameter("@Phone",userInfo.Phone),
                    new SqlParameter("@Email",userInfo.Email),
                    new SqlParameter("@Address",userInfo.Address),
                    new SqlParameter("@Description",userInfo.Description),
                    new SqlParameter("@Origin",userInfo.Origin),
                    new SqlParameter("@RegDate",DateTime.Now),
                    new SqlParameter("@UserRoleId",userInfo.UserRoleId),
                    new SqlParameter("@UserStateId",userInfo.UserStateId),
                };

                //如果你需要获取某个方法的返回值来做其他处理（加减乘除、数据校验），可以使用以下写法
                //int res = DBHelper.ExecuteSqlCount(sqlstr, para);
                //return res;

                //如果需要获取某方法的返回值，然后将其返回的话，就可以使用以下写法
                return DBHelper.ExecuteSqlCount(sqlstr, para);
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        /// <summary>
        /// 用户列表数据
        /// </summary>
        /// <returns></returns>
        public List<UserInfoDetails> GetUserList()
        {
            try
            {
                string sqlstr = @"select
                                    t1.Id,
                                    t1.LoginId,
                                    t1.TrueName,
                                    t1.Gender,
                                    t1.Address,
                                    t1.Phone,
                                    t1.Email,
                                    t1.RegDate,
                                    t1.UserStateId,
                                    t2.Name as Rname,
                                    t3.Name as Sname
                                    from UserInfo t1
                                    inner join UserRoles t2
                                    on t1.UserRoleId=t2.Id 
                                    inner join UserStates t3
                                    on t1.UserStateId=t3.Id
                                    where t1.UserStateId!=3";

                DataTable dt = DBHelper.GetDataTable(sqlstr,null);

                List<UserInfoDetails> userlist = new List<UserInfoDetails>();

                foreach (DataRow item in dt.Rows)
                {
                    UserInfoDetails userInfo = new UserInfoDetails()
                    {
                        Id = Convert.ToInt32(item["Id"]),
                        Address = item["Address"].ToString(),
                        Email = item["Email"].ToString(),
                        Gender = Convert.ToInt32(item["Gender"]) == 1 ? "男" : "女",
                        LoginId = item["LoginId"].ToString(),
                        Phone = item["Phone"].ToString(),
                        RegDate = Convert.ToDateTime(item["RegDate"]),
                        Rname = item["Rname"].ToString(),
                        Sname = item["Sname"].ToString(),
                        TrueName = item["TrueName"].ToString(),
                        UserStateId = Convert.ToInt32(item["UserStateId"]),
                    };
                    userlist.Add(userInfo);
                }

                return userlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 根据ID删除用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        public int DelectedById(UserInfo userInfo)
        {
            try
            {
                string sqlstr = @"UPDATE
                                UserInfo
                                SET UserStateId = 3
                                WHERE Id = @Id";
                List<SqlParameter> para = new List<SqlParameter>()
                {
                    new SqlParameter("@Id",userInfo.Id),
                };

                return DBHelper.ExecuteSqlCount(sqlstr, para);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 根据ID编辑状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newstate"></param>
        /// <returns></returns>
        public int UpdateState(int id,int newState)
        {
            try
            {
                string sqlstr = "UPDATE UserInfo SET UserStateId=@UserStateId WHERE Id=@Id";

                List<SqlParameter> para = new List<SqlParameter>()
                {
                    new SqlParameter("@UserStateId",newState),
                    new SqlParameter("@Id",id),
                };

                return DBHelper.ExecuteSqlCount(sqlstr, para);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 获取用户详情
        /// </summary>
        /// <param name="Id"></param>
        public UserInfoDetails GetUserInfoById(int Id)
        {
            try
            {
                string sqlstr = @"select
                                    t1.Id,
                                    t1.LoginId,
                                    t1.TrueName,
                                    t1.Gender,
                                    t1.Address,
                                    t1.Phone,
                                    t1.Email,
                                    t1.RegDate,
                                    t2.Name as Rname
                                    from UserInfo t1
                                    inner join UserRoles t2
                                    on t1.UserRoleId=t2.Id
                                    where t1.UserStateId!=3 and t1.Id=@Id";

                List<SqlParameter> para = new List<SqlParameter>()
                {
                    new SqlParameter("@Id",Id),
                };

                DataTable dt = DBHelper.GetDataTable(sqlstr, para);

                //定义一个空对象，用于存储用户数据
                UserInfoDetails userInfo = null;

                //只返回一条数据，就没必要使用List了，一个对象表示一行数据，多条数据用集合
                foreach (DataRow item in dt.Rows)
                {
                    userInfo = new UserInfoDetails()
                    {
                        Address = item["Address"].ToString(),
                        Email = item["Email"].ToString(),
                        LoginId = item["LoginId"].ToString(),
                        Phone = item["Phone"].ToString(),
                        RegDate = Convert.ToDateTime(item["RegDate"]),
                        Rname = item["Rname"].ToString(),
                        TrueName = item["TrueName"].ToString(),
                    };
                }

                return userInfo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
