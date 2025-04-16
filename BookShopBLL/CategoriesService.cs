using BookShopDAL;
using BookShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL
{
    public class CategoriesService
    {
        /// <summary>
        /// 图书类别列表数据
        /// </summary>
        /// <returns></returns>
        public List<Categories> GetCategoriesList()
        {
            try
            {
                CategoriesDAL dal = new CategoriesDAL();
                return dal.GetCategoriesList();
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
                CategoriesDAL dal = new CategoriesDAL();
                Categories categories = dal.GetCategoriesById(id);

                if (categories!=null)
                {
                    return categories;
                }
                else
                {
                    throw new Exception("没有找到该图书类别");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        }
}
