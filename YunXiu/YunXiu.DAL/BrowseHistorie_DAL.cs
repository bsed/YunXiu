using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Interface;
using YunXiu.Model;
using YunXiu.Commom;
using Dapper;

namespace YunXiu.DAL
{
    public class BrowseHistorie_DAL : IBrowseHistorie
    {
        public bool AddBrowseHistorie(BrowseHistorie historie)
        {
            var result = false;
            try
            {
                var sql = "INSERT INTO BrowseHistorie(UID,PID,CreateDate) VALUES(@UID,@PID,GETDATE())";
                DynamicParameters pars = new DynamicParameters();
                pars.Add("@UID", historie.User.UID);
                pars.Add("@PID", historie.Product.PID);
                result = DapperHelper.Execute(sql, pars);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<BrowseHistorie> GetBrowseHistorieByProduct(int pID)
        {
            throw new NotImplementedException();
        }

        public List<BrowseHistorie> GetBrowseHistorieByUser(int uID)
        {
            List<BrowseHistorie> list = null;
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT p.[PID],p.[Name],p.[ImgID] FROM BrowseHistorie bh ");
                sql.Append("LEFT JOIN Product p ON bh.[PID]=p.[PID] ");
                sql.Append(string.Format("WHERE bh.[UID]={0}",uID));
                list = DapperHelper.Query<BrowseHistorie>(sql.ToString());
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
