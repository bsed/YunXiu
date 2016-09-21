using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using YunXiu.Commom;
using YunXiu.Interface;
using YunXiu.Model;


namespace YunXiu.DAL
{
    public class ProductConsult_DAL:IProductConsult
    {

        public ProductConsultsModel GetProductConsultByPid(int Pid, int type, int PageSize, int PageNumber)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder CountSb = new StringBuilder();
            SqlParameter[] parms = new SqlParameter[] 
            { 
                new SqlParameter("@Pid",Pid),
                new SqlParameter("@type",type),
                new SqlParameter("@PageSize",PageSize),
                new SqlParameter("@PageNumber",PageNumber),
            };

            sb.Append(" select * from ( ");

            sb.Append(" SELECT  ConsultId ,Pid ,ConsultTypeId ,State ,ConsultUid ,ReplyUid , ");
            sb.Append(" StoreId ,ConsultTime ,ReplyTime ,ConsultMessage ,ReplyMessage , ");
            sb.Append(" ConsultNickName ,ReplyNickName ,PName ,PShowImg ,ConsultIp ,ReplyIp, ");
            sb.Append(" ROW_NUMBER() OVER(ORDER BY ConsultTime desc) AS RowNum ");
            sb.Append(" FROM dbo.ProductConsults ");

            sb.Append(" ) tb ");


            CountSb.Append(" select count(*) from( ");
            CountSb.Append(sb.ToString());
            CountSb.Append(" )tb ");


            sb.Append(" WHERE tb.RowNum BETWEEN ((@PageNumber-1)*@PageSize+1) AND @PageNumber*@PageSize ");

            try
            {
                var ds= SQLHelper.GetDataSet(sb.ToString(), parms);

                var dt = ds.Tables[0];
                
                var CountDt = ds.Tables[1];

                ProductConsultsModel res = new ProductConsultsModel();
                res.lss = DataTableToList(dt);
                res.TotalCount =Convert.ToInt32( ds.Tables[1].Rows[0][0]);
                return res;
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// 根据用户ID取得咨询列表
        /// </summary>
        /// <param name="Uid"></param>
        /// <param name="type"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageNumber"></param>
        /// <returns></returns>
        public ProductConsultsModel GetProductConsultListByUid(int Uid, int type, int PageSize, int PageNumber)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder CountSb = new StringBuilder();
            SqlParameter[] parms = new SqlParameter[] 
            { 
                new SqlParameter("@Uid",Uid),
                new SqlParameter("@type",type),
                new SqlParameter("@PageSize",PageSize),
                new SqlParameter("@PageNumber",PageNumber),
            };
            sb.Append(" select * from ( ");

            sb.Append(" SELECT  ConsultId ,Pid ,ConsultTypeId ,State ,ConsultUid ,ReplyUid , ");
            sb.Append(" StoreId ,ConsultTime ,ReplyTime ,ConsultMessage ,ReplyMessage , ");
            sb.Append(" ConsultNickName ,ReplyNickName ,PName ,PShowImg ,ConsultIp ,ReplyIp, ");
            sb.Append(" ROW_NUMBER() OVER(ORDER BY ConsultTime desc) AS RowNum ");
            sb.Append(" FROM dbo.ProductConsults ");
            sb.Append(" WHERE ConsultUid=@Uid ");

            sb.Append(" ) tb ");


            CountSb.Append(" select count(*) from( ");
            CountSb.Append(sb.ToString());
            CountSb.Append(" )tb ");


            sb.Append(" WHERE tb.RowNum BETWEEN ((@PageNumber-1)*@PageSize+1) AND @PageNumber*@PageSize ");

            try
            {
                var ds = SQLHelper.GetDataSet(sb.ToString(), parms);

                var dt = ds.Tables[0];

                var CountDt = ds.Tables[1];

                ProductConsultsModel res = new ProductConsultsModel();
                res.lss = DataTableToList(dt);
                res.TotalCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                return res;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public ProductConsults GetProductConsultByPCId(int PCId)
        {
            StringBuilder sb = new StringBuilder();
            
            SqlParameter[] parms = new SqlParameter[] 
            { 
                new SqlParameter("@PCId",PCId),
            };
            sb.Append(" SELECT  ConsultId ,Pid ,ConsultTypeId ,State ,ConsultUid ,ReplyUid , ");
            sb.Append(" StoreId ,ConsultTime ,ReplyTime ,ConsultMessage ,ReplyMessage , ");
            sb.Append(" ConsultNickName ,ReplyNickName ,PName ,PShowImg ,ConsultIp ,ReplyIp, ");
            sb.Append(" ROW_NUMBER() OVER(ORDER BY ConsultTime desc) AS RowNum ");
            sb.Append(" FROM dbo.ProductConsults ");
            sb.Append(" WHERE ConsultId=@PCId ");
            try
            {
                var dt = SQLHelper.GetTable(sb.ToString(), parms);
                var lss = DataTableToList(dt);
                if (lss.Count > 0)
                {
                    return lss[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int AddProductConsult(ProductConsults Item)
        {
            StringBuilder sb = new StringBuilder();

            SqlParameter[] parms = new SqlParameter[] 
            { 
                new SqlParameter("@StoreId",Item.StoreId),
                new SqlParameter("@State",Item.State),
                new SqlParameter("@PShowImg",Item.PShowImg),
                new SqlParameter("@PName",Item.PName),
                new SqlParameter("@Pid",Item.Pid),
                new SqlParameter("@ConsultUid",Item.ConsultUid),
                new SqlParameter("@ConsultTypeId",Item.ConsultTypeId),
                new SqlParameter("@ConsultTime",Item.ConsultTime),
                new SqlParameter("@ConsultNickName",Item.ConsultNickName),
                new SqlParameter("@ConsultMessage",Item.ConsultMessage),
                new SqlParameter("@ConsultIp",Item.ConsultIp),
            };
            sb.Append(" INSERT INTO ProductConsults( Pid ,ConsultTypeId ,State ,ConsultUid ,ReplyUid , ");
            sb.Append(" StoreId ,ConsultTime ,ReplyTime ,ConsultMessage ,ReplyMessage , ");
            sb.Append(" ConsultNickName ,ReplyNickName ,PName ,PShowImg ,ConsultIp ,ReplyIp) ");

            sb.Append(" Values( @Pid ,@ConsultTypeId ,@State ,@ConsultUid ,0 ,");
            sb.Append(" @StoreId ,GETDATE() ,GETDATE() ,@ConsultMessage ,'' , ");
            sb.Append(" @ConsultNickName ,'' ,@PName ,@PShowImg ,@ConsultIp ,'' ");
            sb.Append(" ) ");
            sb.Append("  ");
            try
            {
                return SQLHelper.ExcuteSQL(sb.ToString(), parms);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int UpdateProductConsult(ProductConsults Item)
        {
            StringBuilder sb = new StringBuilder();

            SqlParameter[] parms = new SqlParameter[] 
            { 
                new SqlParameter("@State",Item.State),
                new SqlParameter("@ConsultTypeId",Item.ConsultTypeId),
                new SqlParameter("@ConsultMessage",Item.ConsultMessage),
                new SqlParameter("@ConsultId",Item.ConsultId),
                new SqlParameter("@ReplyIp",Item.ReplyIp),
                new SqlParameter("@ReplyMessage",Item.ReplyMessage),
                new SqlParameter("@ReplyNickName",Item.ReplyNickName),
                new SqlParameter("@ReplyTime",Item.ReplyTime),
                new SqlParameter("@ReplyUid",Item.ReplyUid),
            };
            sb.Append(" UPDATE ProductConsults ");
            sb.Append(" SET State=@State,ConsultTypeId=@ConsultTypeId,ConsultMessage=@ConsultMessage,ReplyIp=@ReplyIp,ReplyMessage=@ReplyMessage, ");
            sb.Append(" ReplyNickName=@ReplyNickName,ReplyTime=@ReplyTime,ReplyUid=@ReplyUid ");
            sb.Append(" WHERE ConsultId=@ConsultId ");
            sb.Append("  ");
            sb.Append("  ");
            try
            {
                return SQLHelper.ExcuteSQL(sb.ToString(), parms);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int DeleteProductConsult(int PCId)
        {
            StringBuilder sb = new StringBuilder();

            SqlParameter[] parms = new SqlParameter[] 
            { 
                new SqlParameter("@PCId",PCId),
            };
            sb.Append(" DELETE dbo.ProductConsults WHERE ConsultId=@PCId ");
            try
            {
                return SQLHelper.ExcuteSQL(sb.ToString(), parms);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int ReplyProductConsult(ProductConsults Item)
        {
            StringBuilder sb = new StringBuilder();

            SqlParameter[] parms = new SqlParameter[] 
            { 
                new SqlParameter("@ReplyIp",Item.ReplyIp),
                new SqlParameter("@ReplyMessage",Item.ReplyMessage),
                new SqlParameter("@ReplyNickName",Item.ReplyNickName),
                new SqlParameter("@ReplyUid",Item.ReplyUid),
                new SqlParameter("@ConsultId",Item.ConsultId),
                new SqlParameter("@State",Item.State),
            };
            sb.Append(" UPDATE dbo.ProductConsults SET ReplyIp=@ReplyIp,ReplyMessage=@ReplyMessage, ");
            sb.Append(" ReplyNickName=@ReplyNickName,ReplyUid=@ReplyUid,State=@State,ReplyTime=GETDATE() ");
            sb.Append(" WHERE ConsultId=@ConsultId ");
            try
            {
                return SQLHelper.ExcuteSQL(sb.ToString(), parms);
            }
            catch (Exception)
            {
                return -1;
            }

        }

        private List<ProductConsults> DataTableToList(DataTable dt)
        {
            List<ProductConsults> lss = new List<ProductConsults>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var dr = dt.Rows[i];
                lss.Add(new ProductConsults() {
                    ConsultId = Convert.IsDBNull(dr["ConsultId"]) ? 0 : Convert.ToInt32(dr["ConsultId"]),
                    ConsultIp = Convert.IsDBNull(dr["ConsultIp"]) ? "" :dr["ConsultIp"].ToString(),
                    ConsultMessage = Convert.IsDBNull(dr["ConsultMessage"]) ? "" : dr["ConsultMessage"].ToString(),
                    ConsultNickName = Convert.IsDBNull(dr["ConsultNickName"]) ? "" : dr["ConsultNickName"].ToString(),
                    ConsultTime = Convert.IsDBNull(dr["ConsultTime"]) ? new DateTime(1900, 1, 1) : Convert.ToDateTime(dr["ConsultTime"]),
                    ConsultTypeId = Convert.IsDBNull(dr["ConsultTypeId"]) ? 0 : Convert.ToInt32(dr["ConsultTypeId"]),
                    ConsultUid = Convert.IsDBNull(dr["ConsultUid"]) ? 0 : Convert.ToInt32(dr["ConsultUid"]),
                    Pid = Convert.IsDBNull(dr["Pid"]) ? 0 : Convert.ToInt32(dr["Pid"]),
                    PName = Convert.IsDBNull(dr["PName"]) ? "" : dr["PName"].ToString(),
                    PShowImg = Convert.IsDBNull(dr["PShowImg"]) ? "" : dr["PShowImg"].ToString(),
                    ReplyIp = Convert.IsDBNull(dr["ReplyIp"]) ? "" : dr["ReplyIp"].ToString(),
                    ReplyMessage = Convert.IsDBNull(dr["ReplyMessage"]) ? "" : dr["ReplyMessage"].ToString(),
                    ReplyNickName = Convert.IsDBNull(dr["ReplyNickName"]) ? "" : dr["ReplyNickName"].ToString(),
                    ReplyTime = Convert.IsDBNull(dr["ReplyTime"]) ? new DateTime(1900, 1, 1) : Convert.ToDateTime(dr["ReplyTime"]),
                    ReplyUid = Convert.IsDBNull(dr["ReplyUid"]) ? 0 : Convert.ToInt32(dr["ReplyUid"]),
                    State = Convert.IsDBNull(dr["State"]) ? 0 : Convert.ToInt32(dr["State"]),
                    StoreId = Convert.IsDBNull(dr["StoreId"]) ? 0 : Convert.ToInt32(dr["StoreId"])
                });   
            }
            return lss;
        }

    }
}
