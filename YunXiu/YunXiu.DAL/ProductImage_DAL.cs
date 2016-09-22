using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;
using YunXiu.Interface;
using YunXiu.Commom;
using Dapper;

namespace YunXiu.DAL
{
    public class ProductImage_DAL : IProductImage
    {
        public bool AddProductImg(ProductImage img)
        {
            var result = false;
            try
            {
                var sql = "INSERT INTO ProductImages([PID],[ShowImg],[IsMain],[Displayorder],[StoreID]) VALUES(@PID,@ShowImg,@IsMain,@Displayorder,@StoreID)";
                DynamicParameters pars = new DynamicParameters(img);
                pars.Add("@PID", img.Product.PID);
                result = DapperHelper.Execute(sql, pars);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteProductImg(int piID)
        {
            var result = false;
            try
            {
                var sql = string.Format("DELETE FROM ProductImage WHERE [PImgID]={0}",piID);
                result = DapperHelper.Execute(sql);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<ProductImage> GetProductImg(int pID)
        {
            List<ProductImage> list = null;
            try
            {
                var sql = string.Format("SELECT [ShowImg],[IsMain],[Displayorder],[StoreID] FROM ProductImages WHERE [PID]={0}", pID);
                list = DapperHelper.Query<ProductImage>(sql).ToList();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
