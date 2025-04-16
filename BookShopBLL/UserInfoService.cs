using BookShopDAL;
using BookShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL
{
    public class UserInfoService
    {
        public string GetLoginUserById(string loginid, string pwd)
        {

            try
            {
                if (string.IsNullOrEmpty(loginid))
                {
                    return "账号不能为空";
                }
                if (string.IsNullOrEmpty(pwd))
                {
                    return "密码不能为空";
                }

                UserInfoDAL dal = new UserInfoDAL();
                UserInfo res = dal.GetLoginUserById(loginid, pwd);
                if (res != null)
                {
                    return "成功";
                }
                else
                {
                    return "没有找到该用户信息，请重新输入账号和密码";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public string AddUser(UserInfo userInfo)
        {
            try
            {
                if (string.IsNullOrEmpty(userInfo.LoginId))
                {
                    return "用户名不能为空";
                }
                if (string.IsNullOrEmpty(userInfo.LoginPwd))
                {
                    return "密码不能为空";
                }
                if (string.IsNullOrEmpty(userInfo.TrueName))
                {
                    return "真实姓名不能为空";
                }
                if (string.IsNullOrEmpty(userInfo.Phone))
                {
                    return "电话不能为空";
                }
                UserInfoDAL userInfoDAL = new UserInfoDAL();

                int res = userInfoDAL.AddUser(userInfo);
                if (res>0)
                {
                    return "OK";
                }
                else
                {
                    return "添加失败";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 管理员登录方法
        /// </summary>
        /// <param name="loginid"></param>
        /// <param name="pwd"></param>
        public string AdminLogin(string loginid, string pwd)
        {
            try
            {
                if (string.IsNullOrEmpty(loginid))
                {
                    return "账号不能为空";
                }
                if (string.IsNullOrEmpty(pwd))
                {
                    return "密码不能为空";
                }

                UserInfoDAL userInfoDAL = new UserInfoDAL();

                UserInfo userInfo = userInfoDAL.GetLoginUserById(loginid, pwd);

                if (userInfo!= null)
                {
                    if (userInfo.UserStateId!= 1)
                    {
                        return "该账号被禁用或者已删除";
                    }else if (userInfo.UserRoleId != 3)
                    {
                        return "权限不足";
                    }
                    else
                    {
                        return "OK";
                    }
                }
                else
                {
                    return "没有找到这个账号，请重新检查账号密码";
                }
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
                UserInfoDAL dal = new UserInfoDAL();
                //List<UserInfoDetails> res = dal.GetUserList();
                //return res;
                return dal.GetUserList();
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
        public string DelectedById(UserInfo userInfo)
        {
            try
            {
                UserInfoDAL dal = new UserInfoDAL();
                int res = dal.DelectedById(userInfo);
                if (res > 0)
                {
                    return "OK";
                }
                else
                {
                    return "删除失败";
                }
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
        public string UpdateState(int id, int oldState)
        {
            try
            {
                //当一个用户的当前状态为“正常”的时候去点击 状态编辑，修改到数据库的状态应该是“暂停”
                //当一个用户的当前状态为“暂停”的时候去点击 状态编辑，修改到数据库的状态应该是“正常”

                //使用简单的if判断
                //先定义一个变量来存储最新给到的数据访问层的状态
                int newState = 0;
                #region
                //方式一
                //if (oldState==1)
                //{
                //    //如果前端给的值是1，那么就把当前用户的状态改为2
                //    newState = 2;
                //}
                //else
                //{
                //    //如果前端给的值是2，那么就把当前用户的状态改为1
                //    newState = 1;
                //}
                #endregion

                //方式二
                //如果前端给的值是1，那么就把当前用户的状态改为2
                //如果前端给的值是2，那么就把当前用户的状态改为1
                newState = oldState == 1 ? 2 : 1;
                UserInfoDAL userInfoDAL = new UserInfoDAL();
                int res = userInfoDAL.UpdateState(id, newState);
                if (res > 0)
                {
                    return "OK";
                }
                else
                {
                    return "修改失败";
                }
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
                //获取数据
                UserInfoDAL dal = new UserInfoDAL();
                UserInfoDetails user = dal.GetUserInfoById(Id);

                if (user!=null)
                {
                    return user;
                }
                else
                {
                    //通过报异常的方式返回出去
                    throw new Exception("没有找到这个用户");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
