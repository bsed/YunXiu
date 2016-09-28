using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;
using YunXiu.Interface;
using YunXiu.DAL;

namespace YunXiu.BLL
{
    public class Brand_BLL : IBrand
    {
        Brand_DAL dal = new Brand_DAL();
        public int AddBrand(Brand brand)
        {
            return dal.AddBrand(brand);
        }

        public bool DeleteBrand(int bID)
        {
            return dal.DeleteBrand(bID);
        }

        public List<Brand> GetBrand()
        {
            return dal.GetBrand();
        }

        public List<Brand> GetBrand(int count)
        {
            return dal.GetBrand(count);
        }

        public List<Brand> GetBrandByCategory(List<int> cID)
        {
            return dal.GetBrandByCategory(cID);
        }

        public List<Brand> GetBrandByCategory(List<int> cID, int count)
        {
            return dal.GetBrandByCategory(cID,count);
        }

        public Brand GetBrandByID(int bID)
        {
            return dal.GetBrandByID(bID);
        }

        public List<Brand> GetHotBrand()
        {
            return dal.GetHotBrand();
        }

        public List<Brand> GetHotBrand(int count)
        {
            return dal.GetHotBrand(count);
        }

        public List<Brand> GetShowDynamicBrand()
        {
            return dal.GetShowDynamicBrand();
        }

        public List<Brand> GetShowDynamicBrand(int count)
        {
            return dal.GetShowDynamicBrand(count);
        }

        public bool UpdateBrand(Brand brand)
        {
            return dal.UpdateBrand(brand);
        }
    }
}
