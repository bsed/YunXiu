using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using YunXiu.Model;
using YunXiu.Commom;
using YunXiu.Interface;
using System.Data;
using Dapper;

namespace YunXiu.DAL
{
    public class Product_DAL : IProduct
    {
        /// <summary>
        /// 获取商品
        /// </summary>
        /// <returns>所有商品</returns>
        public List<Product> GetProduct()
        {
            var products = new List<Product>();
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT [PID],[Psn],[CateID],[BrandID],[StoreID],[StorestID],[SkugID],[Name],[ShopPrice],[MarketPrice]");
                sql.Append(",[CostPrice],[State],[IsBest],[IsHot],[IsNew],[Sort],[Weight],[ImgID],[ImgName],[SaleCount]");
                sql.Append(",[VisitCount],[ReviewCount],[Description],[OfficialGuarantee],[FAQs],[CreateDate],[LastUpdateDate] FROM Product WHERE [State]!=-1");

                var dt = SQLHelper.GetTable(sql.ToString());
                #region 提取数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = new Product
                    {
                        PID = Convert.ToInt32(dt.Rows[i]["PID"]),
                        Psn = Convert.ToString(dt.Rows[i]["Psn"]),
                        Category = new Category
                        {

                        },
                        Brand = new Brand
                        {

                        },
                        Store = new Store
                        {

                        },
                        StoreStID = Convert.IsDBNull(dt.Rows[i]["StorestID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["StorestID"]),
                        SkuGID = Convert.IsDBNull(dt.Rows[i]["SkugID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["SkugID"]),
                        Name = Convert.IsDBNull(dt.Rows[i]["Name"]) ? "" : Convert.ToString(dt.Rows[i]["Name"]),
                        ShopPrice = Convert.IsDBNull(dt.Rows[i]["ShopPrice"]) ? 0 : Convert.ToDecimal(dt.Rows[i]["ShopPrice"]),
                        MarketPrice = Convert.IsDBNull(dt.Rows[i]["MarketPrice"]) ? 0 : Convert.ToDecimal(dt.Rows[i]["MarketPrice"]),
                        CostPrice = Convert.IsDBNull(dt.Rows[i]["CostPrice"]) ? 0 : Convert.ToDecimal(dt.Rows[i]["CostPrice"]),
                        // State = Convert.IsDBNull(dt.Rows[i]["State"]) ? 0 : Convert.ToInt32(dt.Rows[i]["State"]),
                        IsBest = Convert.IsDBNull(dt.Rows[i]["IsBest"]) ? false : Convert.ToBoolean(dt.Rows[i]["IsBest"]),
                        IsHot = Convert.IsDBNull(dt.Rows[i]["IsHot"]) ? false : Convert.ToBoolean(dt.Rows[i]["IsHot"]),
                        IsNew = Convert.IsDBNull(dt.Rows[i]["IsNew"]) ? false : Convert.ToBoolean(dt.Rows[i]["IsNew"]),
                        Sort = Convert.IsDBNull(dt.Rows[i]["Sort"]) ? 0 : Convert.ToInt32(dt.Rows[i]["Sort"]),
                        Weight = Convert.IsDBNull(dt.Rows[i]["Weight"]) ? 0 : Convert.ToSingle(dt.Rows[i]["Weight"]),
                        ImgID = Convert.IsDBNull(dt.Rows[i]["ImgID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["ImgID"]),
                        ImgName = Convert.IsDBNull(dt.Rows[i]["ImgName"]) ? "" : Convert.ToString(dt.Rows[i]["ImgName"]),
                        SaleCount = Convert.IsDBNull(dt.Rows[i]["SaleCount"]) ? 0 : Convert.ToInt32(dt.Rows[i]["SaleCount"]),
                        VisitCount = Convert.IsDBNull(dt.Rows[i]["VisitCount"]) ? 0 : Convert.ToInt32(dt.Rows[i]["VisitCount"]),
                        Description = Convert.IsDBNull(dt.Rows[i]["Description"]) ? "" : Convert.ToString(dt.Rows[i]["Description"]),
                        OfficialGuarantee = Convert.IsDBNull(dt.Rows[i]["OfficialGuarantee"]) ? "" : Convert.ToString(dt.Rows[i]["OfficialGuarantee"]),
                        FAQs = Convert.IsDBNull(dt.Rows[i]["FAQs"]) ? "" : Convert.ToString(dt.Rows[i]["FAQs"]),
                    };
                    products.Add(obj);
                }
                #endregion
            }
            catch (Exception ex)
            {

            }
            return products;
        }

        /// <summary>
        /// 根据商品ID获取商品
        /// </summary>
        /// <param name="pID">商品ID</param>
        /// <returns></returns>
        public Product GetProductByID(int pID)
        {
            Product product = null;
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT c.[CateID],c.[Name],b.[BrandID] ,b.[Name],s.[StoreID],s.[State],s.[Name],s.[Logo],s.[Mobile],s.[Phone],p.[PID],p.[Psn],p.[StorestID],p.[SkugID],p.[Name],p.[ShopPrice],p.[MarketPrice],");
                sql.Append("p.[CostPrice],p.[IsBest],p.[IsHot],p.[IsNew],p.[Sort],p.[Weight],p.[ImgID],p.[ImgName],p.[SaleCount],p.[VisitCount],p.[ReviewCount],p.[Description],p.[OfficialGuarantee],");
                sql.Append("p.[FAQs],p.[OneStar],p.[TwoStar],p.[ThreeStar],p.[FourStar],p.[FiveStar],p.[CreateDate],p.[LastUpdateDate] FROM Product p ");
                sql.Append("LEFT JOIN Category c ON c.[CateID]=p.[CateID] ");
                sql.Append("LEFT JOIN Brand b ON b.[BrandID]=p.[BrandID] ");
                sql.Append("LEFT JOIN Store s ON s.[StoreID]=p.[StoreID] ");
                sql.Append(string.Format("WHERE p.[PID] ={0} ", pID));


                using (IDbConnection dbConn = DapperHelper.GetDbConnection())
                {
                    product = dbConn.Query<Category, Brand, Store, Product, Product>(sql.ToString(),
                        (c, b, s, p) =>
                        {
                            p.Category = c;
                            p.Brand = b;
                            p.Store = s;
                            return p;
                        },
                        null,
                        null,
                        true,
                        "CateID,BrandID,StoreID,PID",
                        null,
                        null).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

            }
            return product;
        }

        /// <summary>
        /// 获取热销商品
        /// </summary>
        /// <returns></returns>
        public List<Product> GetHotProduct(int count)
        {
            var products = new List<Product>();
            try
            {
                var sql = new StringBuilder();
                sql.Append(string.Format("SELECT TOP {0} [PID],[Psn],[CateID],[BrandID],[StoreID],[StorestID],[SkugID],[Name],[ShopPrice],[MarketPrice]", count));
                sql.Append(",[CostPrice],[State],[IsBest],[IsHot],[IsNew],[Sort],[Weight],[ImgID],[ImgName],[SaleCount]");
                sql.Append(",[VisitCount],[ReviewCount],[Description],[OfficialGuarantee],[FAQs],[CreateDate],[LastUpdateDate] FROM Product WHERE IsHot=1 AND [State]!=-1");

                var dt = SQLHelper.GetTable(sql.ToString());
                #region 提取数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = new Product
                    {
                        PID = Convert.ToInt32(dt.Rows[i]["PID"]),
                        Psn = Convert.ToString(dt.Rows[i]["Psn"]),
                        Category = new Category
                        {

                        },
                        Brand = new Brand
                        {

                        },
                        Store = new Store
                        {

                        },
                        StoreStID = Convert.IsDBNull(dt.Rows[i]["StorestID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["StorestID"]),
                        SkuGID = Convert.IsDBNull(dt.Rows[i]["SkugID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["SkugID"]),
                        Name = Convert.IsDBNull(dt.Rows[i]["Name"]) ? "" : Convert.ToString(dt.Rows[i]["Name"]),
                        ShopPrice = Convert.IsDBNull(dt.Rows[i]["ShopPrice"]) ? 0 : Convert.ToDecimal(dt.Rows[i]["ShopPrice"]),
                        MarketPrice = Convert.IsDBNull(dt.Rows[i]["MarketPrice"]) ? 0 : Convert.ToDecimal(dt.Rows[i]["MarketPrice"]),
                        CostPrice = Convert.IsDBNull(dt.Rows[i]["CostPrice"]) ? 0 : Convert.ToDecimal(dt.Rows[i]["CostPrice"]),
                        // State = Convert.IsDBNull(dt.Rows[i]["State"]) ? 0 : Convert.ToInt32(dt.Rows[i]["State"]),
                        IsBest = Convert.IsDBNull(dt.Rows[i]["IsBest"]) ? false : Convert.ToBoolean(dt.Rows[i]["IsBest"]),
                        IsHot = Convert.IsDBNull(dt.Rows[i]["IsHot"]) ? false : Convert.ToBoolean(dt.Rows[i]["IsHot"]),
                        IsNew = Convert.IsDBNull(dt.Rows[i]["IsNew"]) ? false : Convert.ToBoolean(dt.Rows[i]["IsNew"]),
                        Sort = Convert.IsDBNull(dt.Rows[i]["Sort"]) ? 0 : Convert.ToInt32(dt.Rows[i]["Sort"]),
                        Weight = Convert.IsDBNull(dt.Rows[i]["Weight"]) ? 0 : Convert.ToSingle(dt.Rows[i]["Weight"]),
                        ImgID = Convert.IsDBNull(dt.Rows[i]["ImgID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["ImgID"]),
                        ImgName = Convert.IsDBNull(dt.Rows[i]["ImgName"]) ? "" : Convert.ToString(dt.Rows[i]["ImgName"]),
                        SaleCount = Convert.IsDBNull(dt.Rows[i]["SaleCount"]) ? 0 : Convert.ToInt32(dt.Rows[i]["SaleCount"]),
                        VisitCount = Convert.IsDBNull(dt.Rows[i]["VisitCount"]) ? 0 : Convert.ToInt32(dt.Rows[i]["VisitCount"]),
                        Description = Convert.IsDBNull(dt.Rows[i]["Description"]) ? "" : Convert.ToString(dt.Rows[i]["Description"]),
                        OfficialGuarantee = Convert.IsDBNull(dt.Rows[i]["OfficialGuarantee"]) ? "" : Convert.ToString(dt.Rows[i]["OfficialGuarantee"]),
                        FAQs = Convert.IsDBNull(dt.Rows[i]["FAQs"]) ? "" : Convert.ToString(dt.Rows[i]["FAQs"]),
                    };
                    products.Add(obj);
                }
                #endregion
            }
            catch (Exception ex)
            {

            }
            return products;
        }

        public List<Product> GetHotProduct()
        {
            var products = new List<Product>();
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT [PID],[Psn],[CateID],[BrandID],[StoreID],[StorestID],[SkugID],[Name],[ShopPrice],[MarketPrice]");
                sql.Append(",[CostPrice],[State],[IsBest],[IsHot],[IsNew],[Sort],[Weight],[ImgID],[ImgName],[SaleCount]");
                sql.Append(",[VisitCount],[ReviewCount],[Description],[OfficialGuarantee],[FAQs],[CreateDate],[LastUpdateDate] FROM Product WHERE IsHot=1 AND [State]<>1");

                var dt = SQLHelper.GetTable(sql.ToString());
                #region 提取数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = new Product
                    {
                        PID = Convert.ToInt32(dt.Rows[i]["PID"]),
                        Psn = Convert.ToString(dt.Rows[i]["Psn"]),
                        Category = new Category
                        {

                        },
                        Brand = new Brand
                        {

                        },
                        Store = new Store
                        {

                        },
                        StoreStID = Convert.IsDBNull(dt.Rows[i]["StorestID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["StorestID"]),
                        SkuGID = Convert.IsDBNull(dt.Rows[i]["SkugID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["SkugID"]),
                        Name = Convert.IsDBNull(dt.Rows[i]["Name"]) ? "" : Convert.ToString(dt.Rows[i]["Name"]),
                        ShopPrice = Convert.IsDBNull(dt.Rows[i]["ShopPrice"]) ? 0 : Convert.ToDecimal(dt.Rows[i]["ShopPrice"]),
                        MarketPrice = Convert.IsDBNull(dt.Rows[i]["MarketPrice"]) ? 0 : Convert.ToDecimal(dt.Rows[i]["MarketPrice"]),
                        CostPrice = Convert.IsDBNull(dt.Rows[i]["CostPrice"]) ? 0 : Convert.ToDecimal(dt.Rows[i]["CostPrice"]),
                        //  State = Convert.IsDBNull(dt.Rows[i]["State"]) ? 0 : Convert.ToInt32(dt.Rows[i]["State"]),
                        IsBest = Convert.IsDBNull(dt.Rows[i]["IsBest"]) ? false : Convert.ToBoolean(dt.Rows[i]["IsBest"]),
                        IsHot = Convert.IsDBNull(dt.Rows[i]["IsHot"]) ? false : Convert.ToBoolean(dt.Rows[i]["IsHot"]),
                        IsNew = Convert.IsDBNull(dt.Rows[i]["IsNew"]) ? false : Convert.ToBoolean(dt.Rows[i]["IsNew"]),
                        Sort = Convert.IsDBNull(dt.Rows[i]["Sort"]) ? 0 : Convert.ToInt32(dt.Rows[i]["Sort"]),
                        Weight = Convert.IsDBNull(dt.Rows[i]["Weight"]) ? 0 : Convert.ToSingle(dt.Rows[i]["Weight"]),
                        ImgID = Convert.IsDBNull(dt.Rows[i]["ImgID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["ImgID"]),
                        ImgName = Convert.IsDBNull(dt.Rows[i]["ImgName"]) ? "" : Convert.ToString(dt.Rows[i]["ImgName"]),
                        SaleCount = Convert.IsDBNull(dt.Rows[i]["SaleCount"]) ? 0 : Convert.ToInt32(dt.Rows[i]["SaleCount"]),
                        VisitCount = Convert.IsDBNull(dt.Rows[i]["VisitCount"]) ? 0 : Convert.ToInt32(dt.Rows[i]["VisitCount"]),
                        Description = Convert.IsDBNull(dt.Rows[i]["Description"]) ? "" : Convert.ToString(dt.Rows[i]["Description"]),
                        OfficialGuarantee = Convert.IsDBNull(dt.Rows[i]["OfficialGuarantee"]) ? "" : Convert.ToString(dt.Rows[i]["OfficialGuarantee"]),
                        FAQs = Convert.IsDBNull(dt.Rows[i]["FAQs"]) ? "" : Convert.ToString(dt.Rows[i]["FAQs"]),
                    };
                    products.Add(obj);
                }
                #endregion
            }
            catch (Exception ex)
            {

            }
            return products;
        }

        public int AddProduct(Product product)
        {
            var result = 0;
            try
            {
                var nowDate = DateTime.Now;
                var sql = new StringBuilder();
                sql.Append("INSERT INTO Product([Psn],[CateID],[BrandID],[StoreID],[StorestID],[SkugID],[Name],[ShopPrice], ");
                sql.Append("[MarketPrice],[CostPrice],[State],[IsBest],[IsHot],[IsNew],[IsRecommend],[Sort],[Weight],[ImgID],");
                sql.Append("[SaleCount],[VisitCount],[Description],[OfficialGuarantee],[FAQs],[CreateDate],[CreateUserID],[LastUpdateDate]) ");
                sql.Append("VALUES(@Psn,@CateID,@BrandID,@StoreID,@StorestID,@SkugID,@Name,@ShopPrice,@MarketPrice,");
                sql.Append("@CostPrice,@State,@IsBest,@IsHot,@IsNew,@IsRecommend,@Sort,@Weight,@ImgID,@SaleCount,@VisitCount,");
                sql.Append("@Description,@OfficialGuarantee,@FAQs,@CreateDate,@CreateUserID,@LastUpdateDate) SELECT @@IDENTITY AS ID ");

                var pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@Psn", product.Psn));
                pars.Add(new SqlParameter("@CateID", product.Category != null ? product.Category.CateId : 0));
                pars.Add(new SqlParameter("@BrandID", product.Brand != null ? product.Brand.BrandID : 0));
                pars.Add(new SqlParameter("@StoreID", product.Store != null ? product.Store.StoreID : 0));
                pars.Add(new SqlParameter("@StorestID", product.StoreStID));
                pars.Add(new SqlParameter("@SkugID", product.SkuGID));
                pars.Add(new SqlParameter("@Name", product.Name));
                pars.Add(new SqlParameter("@ShopPrice", product.ShopPrice));
                pars.Add(new SqlParameter("@MarketPrice", product.MarketPrice));
                pars.Add(new SqlParameter("@CostPrice", product.CostPrice));
                pars.Add(new SqlParameter("@State", product.State));
                pars.Add(new SqlParameter("@IsBest", product.IsBest));
                pars.Add(new SqlParameter("@IsHot", product.IsHot));
                pars.Add(new SqlParameter("@IsNew", product.IsNew));
                pars.Add(new SqlParameter("@IsRecommend", product.IsRecommend));
                pars.Add(new SqlParameter("@Sort", product.Sort));
                pars.Add(new SqlParameter("@Weight", product.Weight));
                pars.Add(new SqlParameter("@ImgID", product.ImgID));
                pars.Add(new SqlParameter("@SaleCount", product.SaleCount));
                pars.Add(new SqlParameter("@VisitCount", product.VisitCount));
                pars.Add(new SqlParameter("@Description", product.Description));
                pars.Add(new SqlParameter("@OfficialGuarantee", product.OfficialGuarantee));
                pars.Add(new SqlParameter("@FAQs", product.FAQs));
                pars.Add(new SqlParameter("@CreateDate", nowDate));
                pars.Add(new SqlParameter("@CreateUserID", product.CreateUser != null ? product.CreateUser.UID : 0));
                pars.Add(new SqlParameter("@LastUpdateDate", nowDate));

                result = SQLHelper.ExcuteScalarSQL(sql.ToString(), pars.ToArray());
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteProduct(int pID)
        {
            var result = false;
            try
            {
                var sql = string.Format("DELETE FROM Product WHERE PID={0}", pID);
                result = SQLHelper.ExcuteSQL(sql) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool UpdateProduct(Product product)
        {
            var result = false;
            try
            {
                var nowDate = DateTime.Now;
                var sql = new StringBuilder();
                sql.Append("UPDATE Product SET [Psn]=@Psn,[CateID]=@CateID,[BrandID]=@BrandID,[StoreID]=@StoreID,[StorestID]=@StorestID,[SkugID]=@SkugID,[Name]=@Name,[ShopPrice]=@ShopPrice, ");
                sql.Append("[MarketPrice]=@MarketPrice,[CostPrice]=@CostPrice,[State]=@State,[IsBest]=@IsBest,[IsHot]=@IsHot,[IsNew]=@IsNew,[IsRecommend]=@IsRecommend,[Sort]=@Sort,[Weight]=@Weight,[ImgID]=@ImgID, ");
                sql.Append("[SaleCount]=@SaleCount,[VisitCount]=@VisitCount,[Description]=@Description,[OfficialGuarantee]=@OfficialGuarantee,[FAQs]=@FAQs,[CreateDate]=@CreateDate,[CreateUser]=@CreateUser,[LastUpdateDate]=@LastUpdateDate,[LastUpdateUser]=@LastUpdateUser ");
                sql.Append("WHERE PID=@PID");

                var pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@PID", product.PID));
                pars.Add(new SqlParameter("@Psn", product.Psn));
                pars.Add(new SqlParameter("@CateID", product.Category != null ? product.Category.CateId : 0));
                pars.Add(new SqlParameter("@BrandID", product.Brand != null ? product.Brand.BrandID : 0));
                pars.Add(new SqlParameter("@StoreID", product.Store != null ? product.Store.StoreID : 0));
                pars.Add(new SqlParameter("@StorestID", product.StoreStID));
                pars.Add(new SqlParameter("@SkugID", product.SkuGID));
                pars.Add(new SqlParameter("@Name", product.Name));
                pars.Add(new SqlParameter("@ShopPrice", product.ShopPrice));
                pars.Add(new SqlParameter("@MarketPrice", product.MarketPrice));
                pars.Add(new SqlParameter("@CostPrice", product.CostPrice));
                pars.Add(new SqlParameter("@State", product.State));
                pars.Add(new SqlParameter("@IsBest", product.IsBest));
                pars.Add(new SqlParameter("@IsHot", product.IsHot));
                pars.Add(new SqlParameter("@IsNew", product.IsNew));
                pars.Add(new SqlParameter("@IsRecommend", product.IsRecommend));
                pars.Add(new SqlParameter("@Sort", product.Sort));
                pars.Add(new SqlParameter("@Weight", product.Weight));
                pars.Add(new SqlParameter("@ImgID", product.ImgID));
                pars.Add(new SqlParameter("@SaleCount", product.SaleCount));
                pars.Add(new SqlParameter("@VisitCount", product.VisitCount));
                pars.Add(new SqlParameter("@Description", product.Description));
                pars.Add(new SqlParameter("@OfficialGuarantee", product.OfficialGuarantee));
                pars.Add(new SqlParameter("@FAQs", product.FAQs));
                pars.Add(new SqlParameter("@CreateDate", nowDate));
                pars.Add(new SqlParameter("@CreateUser", product.CreateUser != null ? product.CreateUser.UID : 0));
                pars.Add(new SqlParameter("@LastUpdateDate", nowDate));
                pars.Add(new SqlParameter("@LastUpdateUser", product.CreateUser != null ? product.CreateUser.UID : 0));

                result = SQLHelper.ExcuteSQL(sql.ToString(), pars.ToArray()) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<Product> GetProductByCate(List<int> cateID)
        {

            var products = new List<Product>();
            try
            {
                var id = string.Join(",", cateID);
                var sql = new StringBuilder();
                sql.Append("SELECT [PID],[Psn],[CateID],[BrandID],[StoreID],[StorestID],[SkugID],[Name],[ShopPrice],[MarketPrice]");
                sql.Append(",[CostPrice],[State],[IsBest],[IsHot],[IsNew],[Sort],[Weight],[ImgID],[ImgName],[SaleCount]");
                sql.Append(string.Format(",[VisitCount],[ReviewCount],[Description],[OfficialGuarantee],[FAQs],[CreateDate],[LastUpdateDate] FROM Product Where CateID IN({0}) AND [State]!=-1", id));

                var dt = SQLHelper.GetTable(sql.ToString());
                #region 提取数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = new Product
                    {
                        PID = Convert.ToInt32(dt.Rows[i]["PID"]),
                        Psn = Convert.ToString(dt.Rows[i]["Psn"]),
                        Category = new Category
                        {

                        },
                        Brand = new Brand
                        {

                        },
                        Store = new Store
                        {

                        },
                        StoreStID = Convert.IsDBNull(dt.Rows[i]["StorestID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["StorestID"]),
                        SkuGID = Convert.IsDBNull(dt.Rows[i]["SkugID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["SkugID"]),
                        Name = Convert.IsDBNull(dt.Rows[i]["Name"]) ? "" : Convert.ToString(dt.Rows[i]["Name"]),
                        ShopPrice = Convert.IsDBNull(dt.Rows[i]["ShopPrice"]) ? 0 : Convert.ToDecimal(dt.Rows[i]["ShopPrice"]),
                        MarketPrice = Convert.IsDBNull(dt.Rows[i]["MarketPrice"]) ? 0 : Convert.ToDecimal(dt.Rows[i]["MarketPrice"]),
                        CostPrice = Convert.IsDBNull(dt.Rows[i]["CostPrice"]) ? 0 : Convert.ToDecimal(dt.Rows[i]["CostPrice"]),
                        //  State = Convert.IsDBNull(dt.Rows[i]["State"]) ? 0 : Convert.ToInt32(dt.Rows[i]["State"]),
                        IsBest = Convert.IsDBNull(dt.Rows[i]["IsBest"]) ? false : Convert.ToBoolean(dt.Rows[i]["IsBest"]),
                        IsHot = Convert.IsDBNull(dt.Rows[i]["IsHot"]) ? false : Convert.ToBoolean(dt.Rows[i]["IsHot"]),
                        IsNew = Convert.IsDBNull(dt.Rows[i]["IsNew"]) ? false : Convert.ToBoolean(dt.Rows[i]["IsNew"]),
                        Sort = Convert.IsDBNull(dt.Rows[i]["Sort"]) ? 0 : Convert.ToInt32(dt.Rows[i]["Sort"]),
                        Weight = Convert.IsDBNull(dt.Rows[i]["Weight"]) ? 0 : Convert.ToSingle(dt.Rows[i]["Weight"]),
                        ImgID = Convert.IsDBNull(dt.Rows[i]["ImgID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["ImgID"]),
                        ImgName = Convert.IsDBNull(dt.Rows[i]["ImgName"]) ? "" : Convert.ToString(dt.Rows[i]["ImgName"]),
                        SaleCount = Convert.IsDBNull(dt.Rows[i]["SaleCount"]) ? 0 : Convert.ToInt32(dt.Rows[i]["SaleCount"]),
                        VisitCount = Convert.IsDBNull(dt.Rows[i]["VisitCount"]) ? 0 : Convert.ToInt32(dt.Rows[i]["VisitCount"]),
                        Description = Convert.IsDBNull(dt.Rows[i]["Description"]) ? "" : Convert.ToString(dt.Rows[i]["Description"]),
                        OfficialGuarantee = Convert.IsDBNull(dt.Rows[i]["OfficialGuarantee"]) ? "" : Convert.ToString(dt.Rows[i]["OfficialGuarantee"]),
                        FAQs = Convert.IsDBNull(dt.Rows[i]["FAQs"]) ? "" : Convert.ToString(dt.Rows[i]["FAQs"]),
                    };
                    products.Add(obj);
                }
                #endregion
            }
            catch (Exception ex)
            {

            }
            return products;
        }

        public List<Product> GetProductByCate(List<int> cateID, int count)
        {
            var products = new List<Product>();
            try
            {
                var id = string.Join(",", cateID);
                var sql = new StringBuilder();
                sql.Append(string.Format("SELECT TOP {0} [PID],[Psn],[CateID],[BrandID],[StoreID],[StorestID],[SkugID],[Name],[ShopPrice],[MarketPrice]", count));
                sql.Append(",[CostPrice],[State],[IsBest],[IsHot],[IsNew],[Sort],[Weight],[ImgID],[ImgName],[SaleCount]");
                sql.Append(string.Format(",[VisitCount],[ReviewCount],[Description],[OfficialGuarantee],[FAQs],[CreateDate],[LastUpdateDate] FROM Product Where CateID IN({0}) AND [State]!=-1", id));

                var dt = SQLHelper.GetTable(sql.ToString());
                #region 提取数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = new Product
                    {
                        PID = Convert.ToInt32(dt.Rows[i]["PID"]),
                        Psn = Convert.ToString(dt.Rows[i]["Psn"]),
                        Category = new Category
                        {

                        },
                        Brand = new Brand
                        {

                        },
                        Store = new Store
                        {

                        },
                        StoreStID = Convert.IsDBNull(dt.Rows[i]["StorestID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["StorestID"]),
                        SkuGID = Convert.IsDBNull(dt.Rows[i]["SkugID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["SkugID"]),
                        Name = Convert.IsDBNull(dt.Rows[i]["Name"]) ? "" : Convert.ToString(dt.Rows[i]["Name"]),
                        ShopPrice = Convert.IsDBNull(dt.Rows[i]["ShopPrice"]) ? 0 : Convert.ToDecimal(dt.Rows[i]["ShopPrice"]),
                        MarketPrice = Convert.IsDBNull(dt.Rows[i]["MarketPrice"]) ? 0 : Convert.ToDecimal(dt.Rows[i]["MarketPrice"]),
                        CostPrice = Convert.IsDBNull(dt.Rows[i]["CostPrice"]) ? 0 : Convert.ToDecimal(dt.Rows[i]["CostPrice"]),
                        //  State = Convert.IsDBNull(dt.Rows[i]["State"]) ? 0 : Convert.ToInt32(dt.Rows[i]["State"]),
                        IsBest = Convert.IsDBNull(dt.Rows[i]["IsBest"]) ? false : Convert.ToBoolean(dt.Rows[i]["IsBest"]),
                        IsHot = Convert.IsDBNull(dt.Rows[i]["IsHot"]) ? false : Convert.ToBoolean(dt.Rows[i]["IsHot"]),
                        IsNew = Convert.IsDBNull(dt.Rows[i]["IsNew"]) ? false : Convert.ToBoolean(dt.Rows[i]["IsNew"]),
                        Sort = Convert.IsDBNull(dt.Rows[i]["Sort"]) ? 0 : Convert.ToInt32(dt.Rows[i]["Sort"]),
                        Weight = Convert.IsDBNull(dt.Rows[i]["Weight"]) ? 0 : Convert.ToSingle(dt.Rows[i]["Weight"]),
                        ImgID = Convert.IsDBNull(dt.Rows[i]["ImgID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["ImgID"]),
                        ImgName = Convert.IsDBNull(dt.Rows[i]["ImgName"]) ? "" : Convert.ToString(dt.Rows[i]["ImgName"]),
                        SaleCount = Convert.IsDBNull(dt.Rows[i]["SaleCount"]) ? 0 : Convert.ToInt32(dt.Rows[i]["SaleCount"]),
                        VisitCount = Convert.IsDBNull(dt.Rows[i]["VisitCount"]) ? 0 : Convert.ToInt32(dt.Rows[i]["VisitCount"]),
                        Description = Convert.IsDBNull(dt.Rows[i]["Description"]) ? "" : Convert.ToString(dt.Rows[i]["Description"]),
                        OfficialGuarantee = Convert.IsDBNull(dt.Rows[i]["OfficialGuarantee"]) ? "" : Convert.ToString(dt.Rows[i]["OfficialGuarantee"]),
                        FAQs = Convert.IsDBNull(dt.Rows[i]["FAQs"]) ? "" : Convert.ToString(dt.Rows[i]["FAQs"]),
                    };
                    products.Add(obj);
                }
                #endregion
            }
            catch (Exception ex)
            {

            }
            return products;
        }

        public List<Product> GetProductsByID(List<int> pID)
        {
            var products = new List<Product>();
            try
            {
                var id = string.Join(",", pID);
                var sql = new StringBuilder();
                sql.Append("SELECT c.[Name],c.[CateID],b.[BrandID] ,b[Name],s.[StoreID],s.[State],s.[Name],[PID],[Psn],[StorestID],[SkugID],p.[Name],[ShopPrice],[MarketPrice],");
                sql.Append("[CostPrice],[State],[IsBest],[IsHot],[IsNew],[Sort],[Weight],[ImgID],[ImgName],[SaleCount],");
                sql.Append("[VisitCount],[ReviewCount],[Description],[OfficialGuarantee],[FAQs],[CreateDate],[LastUpdateDate] FROM Product p");
                sql.Append("LEFT JOIN Category c ON c.[CateID]=p.[CateID] ");
                sql.Append("LEFT JOIN Brand b ON b.[BrandID]=p.[BrandID] ");
                sql.Append("LEFT JOIN Store s ON s.[StoreID]=p.[StoreID] ");
                sql.Append(string.Format("WHERE p.[PID] IN({0}) ", id));
                using (IDbConnection dbConn = DapperHelper.GetDbConnection())
                {
                    products = dbConn.Query<Product, Category, Brand, Store, Product>(sql.ToString(),
                        (p, c, b, s) =>
                        {
                            p.Category = c;
                            p.Brand = b;
                            p.Store = s;
                            return p;
                        },
                        null,
                        null,
                        true,
                        "ID,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,State,Name",
                        null,
                        null).ToList();
                }
                var dt = SQLHelper.GetTable(sql.ToString());

                #region 提取数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = new Product
                    {
                        PID = Convert.ToInt32(dt.Rows[i]["PID"]),
                        Psn = Convert.ToString(dt.Rows[i]["Psn"]),
                        Category = new Category
                        {

                        },
                        Brand = new Brand
                        {

                        },
                        Store = new Store
                        {

                        },
                        StoreStID = Convert.IsDBNull(dt.Rows[i]["StorestID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["StorestID"]),
                        SkuGID = Convert.IsDBNull(dt.Rows[i]["SkugID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["SkugID"]),
                        Name = Convert.IsDBNull(dt.Rows[i]["Name"]) ? "" : Convert.ToString(dt.Rows[i]["Name"]),
                        ShopPrice = Convert.IsDBNull(dt.Rows[i]["ShopPrice"]) ? 0 : Convert.ToDecimal(dt.Rows[i]["ShopPrice"]),
                        MarketPrice = Convert.IsDBNull(dt.Rows[i]["MarketPrice"]) ? 0 : Convert.ToDecimal(dt.Rows[i]["MarketPrice"]),
                        CostPrice = Convert.IsDBNull(dt.Rows[i]["CostPrice"]) ? 0 : Convert.ToDecimal(dt.Rows[i]["CostPrice"]),
                        //  State = Convert.IsDBNull(dt.Rows[i]["State"]) ? 0 : Convert.ToInt32(dt.Rows[i]["State"]),
                        IsBest = Convert.IsDBNull(dt.Rows[i]["IsBest"]) ? false : Convert.ToBoolean(dt.Rows[i]["IsBest"]),
                        IsHot = Convert.IsDBNull(dt.Rows[i]["IsHot"]) ? false : Convert.ToBoolean(dt.Rows[i]["IsHot"]),
                        IsNew = Convert.IsDBNull(dt.Rows[i]["IsNew"]) ? false : Convert.ToBoolean(dt.Rows[i]["IsNew"]),
                        Sort = Convert.IsDBNull(dt.Rows[i]["Sort"]) ? 0 : Convert.ToInt32(dt.Rows[i]["Sort"]),
                        Weight = Convert.IsDBNull(dt.Rows[i]["Weight"]) ? 0 : Convert.ToSingle(dt.Rows[i]["Weight"]),
                        ImgID = Convert.IsDBNull(dt.Rows[i]["ImgID"]) ? 0 : Convert.ToInt32(dt.Rows[i]["ImgID"]),
                        ImgName = Convert.IsDBNull(dt.Rows[i]["ImgName"]) ? "" : Convert.ToString(dt.Rows[i]["ImgName"]),
                        SaleCount = Convert.IsDBNull(dt.Rows[i]["SaleCount"]) ? 0 : Convert.ToInt32(dt.Rows[i]["SaleCount"]),
                        VisitCount = Convert.IsDBNull(dt.Rows[i]["VisitCount"]) ? 0 : Convert.ToInt32(dt.Rows[i]["VisitCount"]),
                        Description = Convert.IsDBNull(dt.Rows[i]["Description"]) ? "" : Convert.ToString(dt.Rows[i]["Description"]),
                        OfficialGuarantee = Convert.IsDBNull(dt.Rows[i]["OfficialGuarantee"]) ? "" : Convert.ToString(dt.Rows[i]["OfficialGuarantee"]),
                        FAQs = Convert.IsDBNull(dt.Rows[i]["FAQs"]) ? "" : Convert.ToString(dt.Rows[i]["FAQs"]),
                    };
                    products.Add(obj);
                }
                #endregion
            }
            catch (Exception ex)
            {

            }
            return products;
        }

        public List<Product> GetProductByStore(int storeID)
        {
            List<Product> list = new List<Product>();
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT p.[PID],p.[Psn],p.[CateID],p.[BrandID],p.[StorestID],p.[SkugID],p.[Name],p.[ShopPrice],p.[MarketPrice],p.[CostPrice],p.[ProductStateID],p.[IsBest],p.[IsHot],p.[IsNew],p.[Sort],");
                sql.Append("p.[Weight],p.[ImgID],p.[ImgName],p.[SaleCount],p.[VisitCount],p.[ReviewCount],p.[Description],p.[OfficialGuarantee],p.[FAQs],p.[CreateDate],");
                sql.Append("s.[StoreID],s.[State],s.[Name] ");
                sql.Append("FROM Product p ");
                sql.Append("LEFT JOIN Store s ON p.StoreID=s.StoreID ");
                sql.Append(string.Format("WHERE p.[StoreID]={0}", storeID));

                using (IDbConnection conn = DapperHelper.GetDbConnection())
                {
                    list = conn.Query<Product, Store, Product>(
                        sql.ToString(),
                        (p, s) => { p.Store = s; return p; },
                        null,
                        null,
                        true,
                        "StoreID",
                        null,
                        null
                        ).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public bool SetProductMainImage(int imgID)
        {
            var result = false;
            try
            {
                var sql = string.Format("UPDATE Product SET ImgID={0}", imgID);
                result = DapperHelper.Execute(sql);
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
