using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopModel
{
    public class Categories
    {
        /// <summary>
        /// 图书类别Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 图书类别名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        public string DeleteFlag { get; set; }
    }
}
