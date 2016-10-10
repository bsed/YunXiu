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
        public int AddProductImg(ProductImage img)
        {
            var imgID =0;
            try
            {
                var sql = "INSERT INTO ProductImages([PID],[ImgName],[IsMain],[Displayorder],[StoreID]) VALUES(@PID,@ImgName,@IsMain,@Displayorder,@StoreID) SELECT @@IDENTITY ";
                DynamicParameters pars = new DynamicParameters(img);
                pars.Add("@PID", img.Product.PID);
                imgID = DapperHelper.ExecuteScalar(sql, pars);
            }
            catch (Exception ex)
            {

            }
            return imgID;
        }

        public bool DeleteProductImg(int piID)
        {
            var result = false;
            try
            {
                var sql = string.Format("DELETE FROM ProductImages WHERE [PImgID]={0}",piID);
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
                var sql = string.Format("SELECT [PImgID],[ImgName],[IsMain],[Displayorder],[StoreID] FROM ProductImages WHERE [PID]={0}", pID);
                list = DapperHelper.Query<ProductImage>(sql).ToList();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
