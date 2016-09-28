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
    public class StoreImg_DAL : IStoreImg
    {
        public int AddStoreImg(StoreImg img)
        {
            var imgID = 0;
            try
            {
                var sql = "INSERT INTO StoreImg(Img,StoreID,CreateDate) VALUES(@Img,@StoreID,GETDATE()) SELECT @@IDENTITY";
                DynamicParameters pars = new DynamicParameters();
                pars.Add("@Img",img);
                pars.Add("@StoreID",img.Store.StoreID);
                imgID = DapperHelper.ExecuteScalar(sql,pars);
            }
            catch (Exception ex)
            {

            }
            return imgID;
        }

        public List<StoreImg> GetStoreImg(int sID)
        {
            List<StoreImg> images = null;
            try
            {
                var sql = string.Format("SELECT [ID],[Img],[CreateDate] FROM StoreImg WHERE [StoreID]={0}",sID);
                images = DapperHelper.Query<StoreImg>(sql);
            }
            catch (Exception ex)
            {

            }
            return images;
        }
    }
}
