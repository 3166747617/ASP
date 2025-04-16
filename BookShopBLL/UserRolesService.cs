using BookShopDAL;
using BookShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL
{
    public class UserRolesService
    {
        /// <summary>
        /// 获取角色信息列表
        /// </summary>
        /// <returns></returns>
        public List<UserRoles> GetUserRolesList()
        {
            try
            {
                UserRolesDAL userRolesDAL = new UserRolesDAL();
                return userRolesDAL.GetUserRolesList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        }
}
