using BookShopCommon;
using BookShopModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopDAL
{
    public class UserRolesDAL
    {
        /// <summary>
        /// 获取角色信息列表
        /// </summary>
        /// <returns></returns>
        public List<UserRoles> GetUserRolesList()
        {
            try
            {
                string sqlstr = "SELECT * FROM UserRoles";
                DataTable dt = DBHelper.GetDataTable(sqlstr, null);

                List<UserRoles> userRolesList = new List<UserRoles>();
                foreach (DataRow item in dt.Rows)
                {
                    UserRoles userRoles = new UserRoles()
                    {
                        Id = Convert.ToInt32(item["Id"]),
                        Name = item["Name"].ToString(),
                    };
                    userRolesList.Add(userRoles);
                }
                return userRolesList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       
    }
}
