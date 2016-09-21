using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using YunXiu.Model;
using YunXiu.Commom;
using YunXiu.Interface;

namespace YunXiu.DAL
{
    public class Brand_DAL : IBrand
    {
        public bool AddBrand(Brand brand)
        {
            var result = false;
            try
            {
                var nowDate = DateTime.Now;
                var sql = "INSERT INTO Brand([Sort],[Name],[Logo],[IsHotBrand],[CateID],[BrandDynamic],[IsShowDynamic],[ShowDynamicSort],[CreateDate],[CreateUser],[LastUpdateDate],[LastUpdateUser]) VALUES(@Sort,@Name,@Logo,@IsHotBrand,@CateID,@BrandDynamic,@IsShowDynamic,@ShowDynamicSort,@CreateDate,@CreateUser,@LastUpdateDate,@LastUpdateUser)";
                var pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@Sort", brand.Sort));
                pars.Add(new SqlParameter("@Name", brand.Name));
                pars.Add(new SqlParameter("@Logo", brand.Logo));
                pars.Add(new SqlParameter("@IsHotBrand", brand.IsHotBrand));
                pars.Add(new SqlParameter("@CateID", brand.Category != null ? brand.Category.CateID : 0));
                pars.Add(new SqlParameter("@BrandDynamic", brand.BrandDynamic));
                pars.Add(new SqlParameter("@IsShowDynamic", brand.IsShowDynamic));
                pars.Add(new SqlParameter("@ShowDynamicSort", brand.ShowDynamicSort));
                pars.Add(new SqlParameter("@CreateDate", nowDate));
                pars.Add(new SqlParameter("@CreateUser", brand.CreateUser != null ? brand.CreateUser.UID : 0));
                pars.Add(new SqlParameter("@LastUpdateDate", nowDate));
                pars.Add(new SqlParameter("@LastUpdateUser", brand.LastUpdateUser != null ? brand.LastUpdateUser.UID : 0));

                result = SQLHelper.ExcuteSQL(sql, pars.ToArray()) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteBrand(int bID)
        {
            var result = false;
            try
            {
                var sql = string.Format("DELETE FROM Brand WHERE [BrandID]={0}", bID);
                result = SQLHelper.ExcuteSQL(sql) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<Brand> GetBrand()
        {
            var list = new List<Brand>();
            try
            {
                var sql = "SELECT [BrandID],[Sort],[Name],[Logo],[BrandDynamic],[IsShowDynamic],[ShowDynamicSort] FROM Brand ORDER BY [Sort]";
                var dt = SQLHelper.GetTable(sql.ToString());
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = new Brand
                    {
                        BrandID = Convert.ToInt32(dt.Rows[i]["BrandID"]),
                        Sort = Convert.IsDBNull(dt.Rows[i]["Sort"]) ? 0 : Convert.ToInt32(dt.Rows[i]["Sort"]),
                        Name = Convert.IsDBNull(dt.Rows[i]["Name"]) ? "" : Convert.ToString(dt.Rows[i]["Name"]),
                        Logo = Convert.IsDBNull(dt.Rows[i]["Logo"]) ? "" : Convert.ToString(dt.Rows[i]["Logo"]),
                        BrandDynamic = Convert.IsDBNull(dt.Rows[i]["BrandDynamic"]) ? "" : Convert.ToString(dt.Rows[i]["BrandDynamic"]),
                        IsShowDynamic = Convert.IsDBNull(dt.Rows[i]["IsShowDynamic"]) ? false : Convert.ToBoolean(dt.Rows[i]["IsShowDynamic"]),
                        ShowDynamicSort = Convert.IsDBNull(dt.Rows[i]["ShowDynamicSort"]) ? 0 : Convert.ToInt32(dt.Rows[i]["ShowDynamicSort"])
                    };
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }

        public List<Brand> GetBrand(int count)
        {
            var list = new List<Brand>();
            try
            {
                var sql = string.Format("SELECT TOP {0} [BrandID],[Sort],[Name],[Logo] FROM Brand ORDER BY [Sort]", count);
                var dt = SQLHelper.GetTable(sql.ToString());
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = new Brand
                    {
                        BrandID = Convert.ToInt32(dt.Rows[i]["BrandID"]),
                        Sort = Convert.ToInt32(dt.Rows[i]["Sort"]),
                        Name = Convert.ToString(dt.Rows[i]["Name"]),
                        Logo = Convert.ToString(dt.Rows[i]["Logo"])
                    };
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public List<Brand> GetBrandByCategory(List<int> cID)
        {
            var list = new List<Brand>();
            try
            {
                var listStr = "";
                cID.ForEach(s => listStr += s + ",");
                listStr = listStr.Substring(0, listStr.Length - 1);
                var sql = string.Format("SELECT [BrandID],[Sort],[Name],[Logo] FROM Brand WHERE CateID IN ({0}) ORDER BY [Sort]", listStr);
                var dt = SQLHelper.GetTable(sql.ToString());
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = new Brand
                    {
                        BrandID = Convert.ToInt32(dt.Rows[i]["BrandID"]),
                        Sort = Convert.ToInt32(dt.Rows[i]["Sort"]),
                        Name = Convert.ToString(dt.Rows[i]["Name"]),
                        Logo = Convert.ToString(dt.Rows[i]["Logo"])
                    };
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public List<Brand> GetBrandByCategory(List<int> cID, int count)
        {
            var list = new List<Brand>();
            try
            {
                var listStr = "";
                cID.ForEach(s => listStr += s + ",");
                listStr = listStr.Substring(0, listStr.Length - 1);
                var sql = string.Format("SELECT TOP {0} [BrandID],[Sort],[Name],[Logo] FROM Brand WHERE WHERE CateID IN ({1}) ORDER BY [Sort]", count, listStr);
                var dt = SQLHelper.GetTable(sql.ToString());
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = new Brand
                    {
                        BrandID = Convert.ToInt32(dt.Rows[i]["BrandID"]),
                        Sort = Convert.ToInt32(dt.Rows[i]["Sort"]),
                        Name = Convert.ToString(dt.Rows[i]["Name"]),
                        Logo = Convert.ToString(dt.Rows[i]["Logo"])
                    };
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public Brand GetBrandByID(int bID)
        {
            var brand = new Brand();
            try
            {
                var sql = string.Format("SELECT [BrandID],[Sort],[Name],[Logo] FROM Brand WHERE [BrandID]={0} ORDER BY [Sort]", bID);
                var dt = SQLHelper.GetTable(sql.ToString());

                brand = new Brand
                {
                    BrandID = Convert.ToInt32(dt.Rows[0]["BrandID"]),
                    Sort = Convert.ToInt32(dt.Rows[0]["Sort"]),
                    Name = Convert.ToString(dt.Rows[0]["Name"]),
                    Logo = Convert.ToString(dt.Rows[0]["Logo"])
                };
            }
            catch (Exception ex)
            {

            }
            return brand;
        }

        public List<Brand> GetHotBrand()
        {
            var list = new List<Brand>();
            try
            {
                var sql = "SELECT [BrandID],[Sort],[Name],[Logo] FROM Brand WHERE IsHotBrand=1 ORDER BY [Sort]";
                var dt = SQLHelper.GetTable(sql.ToString());
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = new Brand
                    {
                        BrandID = Convert.ToInt32(dt.Rows[i]["BrandID"]),
                        Sort = Convert.ToInt32(dt.Rows[i]["Sort"]),
                        Name = Convert.ToString(dt.Rows[i]["Name"]),
                        Logo = Convert.ToString(dt.Rows[i]["Logo"])
                    };
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public List<Brand> GetHotBrand(int count)
        {
            var list = new List<Brand>();
            try
            {
                var sql = string.Format("SELECT TOP {0} [BrandID],[Sort],[Name],[Logo] FROM Brand WHERE IsHotBrand=1 ORDER BY [Sort]", count);
                var dt = SQLHelper.GetTable(sql.ToString());
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = new Brand
                    {
                        BrandID = Convert.ToInt32(dt.Rows[i]["BrandID"]),
                        Sort = Convert.ToInt32(dt.Rows[i]["Sort"]),
                        Name = Convert.ToString(dt.Rows[i]["Name"]),
                        Logo = Convert.ToString(dt.Rows[i]["Logo"])
                    };
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        /// <summary>
        /// 获取需要展示的品牌
        /// </summary>
        /// <returns></returns>
        public List<Brand> GetShowDynamicBrand()
        {
            var list = new List<Brand>();
            try
            {
                var sql = "SELECT [BrandID],[Sort],[Name],[Logo],[BrandDynamic] FROM Brand WHERE IsShowDynamic=1 ORDER BY [ShowDynamicSort]";
                var dt = SQLHelper.GetTable(sql.ToString());
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = new Brand
                    {
                        BrandID = Convert.ToInt32(dt.Rows[i]["BrandID"]),
                        Sort = Convert.ToInt32(dt.Rows[i]["Sort"]),
                        Name = Convert.ToString(dt.Rows[i]["Name"]),
                        Logo = Convert.ToString(dt.Rows[i]["Logo"]),
                        BrandDynamic = Convert.IsDBNull(dt.Rows[i]["BrandDynamic"]) ? "" : Convert.ToString(dt.Rows[i]["BrandDynamic"])
                    };
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }

        public List<Brand> GetShowDynamicBrand(int count)
        {
            var list = new List<Brand>();
            try
            {
                var sql = string.Format("SELECT TOP {0} [BrandID],[Sort],[Name],[Logo],[BrandDynamic] FROM Brand WHERE IsShowDynamic=1 ORDER BY [ShowDynamicSort]", count);
                var dt = SQLHelper.GetTable(sql.ToString());
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = new Brand
                    {
                        BrandID = Convert.ToInt32(dt.Rows[i]["BrandID"]),
                        Sort = Convert.ToInt32(dt.Rows[i]["Sort"]),
                        Name = Convert.ToString(dt.Rows[i]["Name"]),
                        Logo = Convert.ToString(dt.Rows[i]["Logo"]),
                        BrandDynamic = Convert.IsDBNull(dt.Rows[i]["BrandDynamic"]) ? "" : Convert.ToString(dt.Rows[i]["BrandDynamic"])
                    };
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }

        public bool UpdateBrand(Brand brand)
        {
            var result = false;
            try
            {
                var sql = "UPDATE Brand SET [Sort]=@Sort,[Name]=@Name,[Logo]=@Logo,[BrandDynamic]=@BrandDynamic,[IsShowDynamic]=@IsShowDynamic,[ShowDynamicSort]=@ShowDynamicSort,[LastUpdateDate]=@LastUpdateDate,[LastUpdateUser]=@LastUpdateUser WHERE [BrandID]=@BrandID";
                var pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@BrandID", brand.BrandID));
                pars.Add(new SqlParameter("@Sort", brand.Sort));
                pars.Add(new SqlParameter("@Name", brand.Name));
                pars.Add(new SqlParameter("@Logo", brand.Logo));
                pars.Add(new SqlParameter("@BrandDynamic", brand.BrandDynamic));
                pars.Add(new SqlParameter("@IsShowDynamic", brand.IsShowDynamic));
                pars.Add(new SqlParameter("@ShowDynamicSort", brand.ShowDynamicSort));
                pars.Add(new SqlParameter("@LastUpdateDate", DateTime.Now));
                pars.Add(new SqlParameter("@LastUpdateUser", brand.LastUpdateUser != null ? brand.LastUpdateUser.UID : 0));

                result = SQLHelper.ExcuteSQL(sql, pars.ToArray()) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
