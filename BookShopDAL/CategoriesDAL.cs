using BookShopCommon;
using BookShopModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopDAL
{
    public class CategoriesDAL
    {
        /// <summary>
        /// 图书类别列表数据
        /// </summary>
        /// <returns></returns>
        public List<Categories> GetCategoriesList()
        {
            try
            {
                string sqlstr = @"select * from Categories";

                List<Categories> list = new List<Categories>();
                DataTable dt = DBHelper.GetDataTable(sqlstr, null);

                foreach (DataRow item in dt.Rows)
                {
                    Categories ca = new Categories();
                    ca.Id = int.Parse(item["Id"].ToString());
                    ca.Name = item["Name"].ToString();
                    list.Add(ca);
                }

                return list;
                }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 根据id获取分类信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Categories GetCategoriesById(int id)
        {
            try
            {
                string sqlstr = @"select * from Categories t1 Where t1.Id=@Id";
                List<SqlParameter> para = new List<SqlParameter>()
                {
                    new SqlParameter("@Id",id),
                };
                Categories categories = null;
                DataTable dt = DBHelper.GetDataTable(sqlstr, para);
                foreach (DataRow item in dt.Rows)
                {
                    categories = new Categories()
                    {
                        Id = Convert.ToInt32(item["Id"]),
                        Name = item["Name"].ToString(),
                    };
                }
                return categories;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
