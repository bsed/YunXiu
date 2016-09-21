using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Interface;
using YunXiu.Model;
using YunXiu.DAL;

namespace YunXiu.BLL
{
    public class Category_BLL : ICategory
    {
        Category_DAL dal = new Category_DAL();
        public bool AddCategory(Category category)
        {
            var result = false;
            try
            {
                result = dal.AddCategory(category);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteCategory(int cID)
        {
            return dal.DeleteCategory(cID);
        }

        public List<Category> GetCategory()
        {
            var list = new List<Category>();
            try
            {
                list = dal.GetCategory();
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public Category GetCategoryByID(int cID)
        {
            return dal.GetCategoryByID(cID);
        }

        public List<int> GetCategoryChildren(int cID)
        {
            return dal.GetCategoryChildren(cID);
        }

        public bool UpdateCategory(Category category)
        {
            return dal.UpdateCategory(category);
        }
    }
}
