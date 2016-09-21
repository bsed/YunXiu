using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using YunXiu.Model;
using YunXiu.Interface;
using YunXiu.Commom;

namespace YunXiu.DAL
{
    public class PurchasePlan_DAL : IPurchasePlan
    {
        /// <summary>
        /// 发布采购计划
        /// </summary>
        /// <param name="PurchasePlanModel">采购计划总的实体</param>
        /// <returns></returns>
        public int AddPurchasePlan(PurchasePlan plan)
        {
            var pID = 0;
            try
            {
                var nowDate = DateTime.Now;
                StringBuilder str = new StringBuilder();
                str.Append("INSERT INTO PurchasePlan([Title],[PName],[State],[PurchaseDetails],[Spec],[Qty],[Unit],[HopePrice],[PurchaseName],[ContantName],[ContantWay],");
                str.Append("[EndDateTime],[PurchaseType],[RequestManufactureArea],[RequestReceiveArea],[RequestContant],[CreateDate],[CreateUserID],[LastUpdateDate] ,[LastUpdateUserID]) ");
                str.Append("VALUES(@Title,@PName,@State,@PurchaseDetails,@Spec,@Qty,@Unit,@HopePrice,@PurchaseName,@ContantName,@ContantWay@)");
                str.Append("@EndDateTime,@PurchaseType,@RequestManufactureArea,@RequestReceiveArea,@RequestContant,@CreateDate,@CreateUserID,@LastUpdateDate,@LastUpdateUserID) SELECT @@IDENTITY");
                SqlParameter[] parms = new SqlParameter[]
                {
                     new SqlParameter("@Title",plan.Title),
                     new SqlParameter("@PName",plan.PName),
                     new SqlParameter("@State",plan.State),
                     new SqlParameter("@PurchaseDetails",plan.PurchaseDetails),
                     new SqlParameter("@Spec",plan.Spec),
                     new SqlParameter("@Qty",plan.Qty),
                     new SqlParameter("@Unit",plan.Unit),
                       new SqlParameter("@HopePrice",plan.HopePrice),
                    new SqlParameter("@PurchaseName",plan.PurchaseName),
                    new SqlParameter("@ContantName",plan.ContantName),
                    new SqlParameter("@ContantWay",plan.ContantWay),
                    new SqlParameter("@EndDateTime",plan.EndDateTime),
                    new SqlParameter("@PurchaseType",plan.PurchaseType),
                    new SqlParameter("@RequestManufactureArea",plan.RequestManufactureArea),
                    new SqlParameter("@RequestReceiveArea",plan.RequestReceiveArea),
                    new SqlParameter("@RequestContant",plan.RequestContant),
                    new SqlParameter("@CreateDate",nowDate),
                    new SqlParameter("@CreateUserID",plan.CreateUser!=null?plan.CreateUser.UID:0),
                    new SqlParameter("@LastUpdateDate",nowDate),
                    new SqlParameter("@LastUpdateUserID",plan.LastUpdateUser!=null?plan.LastUpdateUser.UID:0),
                };

                pID = SQLHelper.ExcuteScalarSQL(str.ToString(), parms);


            }
            catch (Exception)
            {

            }
            return pID;
        }


        /// <summary>
        /// 查询采购计划
        /// </summary>
        /// <param name="KeyWord">关键字</param>
        /// <param name="PageSize">显示在页面上的数量</param>
        /// <param name="PageNumber">页码</param>
        /// <param name="State">状态</param>
        /// <param name="TotalCount">总数量</param>
        /// <returns></returns>
        public List<PurchasePlanView> ShowPurchasePlan(string KeyWord, int PageSize, int PageNumber, string State, out int TotalCount)
        {
            TotalCount = 0;
            try
            {
                SqlParameter[] parms = new SqlParameter[]
                {
                    new SqlParameter("@KeyWord",KeyWord),
                    new SqlParameter("@PageSize",PageSize),
                    new SqlParameter("@PageNumber",PageNumber)
                };
                List<PurchasePlanView> Res = new List<PurchasePlanView>();
                StringBuilder sb = new StringBuilder();



                sb.Append(" SELECT  PPId ,Title ,PName ,[State],Spec ,Qty ,Unit ,HopePrice ,PurchaseName , ");
                sb.Append(" ContantName ,ContantWay ,EndDateTime ,PurchaseType ,RequestManufactureArea , ");
                sb.Append(" RequestReceiveArea ,RequestContant ,CreateDate ,CreateUid ,PurchaseDetails, ");
                sb.Append(" LastUpdateDate ,LastUpdateUId,ROW_NUMBER() OVER(ORDER BY CreateDate DESC) RowNum ");
                sb.Append(" FROM dbo.PurchasePlan ");

                if (State != "")
                {

                }

                StringBuilder CountSb = new StringBuilder();
                CountSb.Append(sb.ToString());
                CountSb.Insert(0, "select count(*) from (");
                CountSb.Append(")tb");

                sb.Insert(0, " SELECT * FROM ( ");
                sb.Append(") tb ");
                sb.Append(" WHERE tb.RowNum BETWEEN ((@PageNumber-1)*@PageSize+1) AND @PageNumber*@PageSize ");


                sb.Append(" select * from ExtTable where ContantTableName='PurchasePlan' ");


                sb.Append(CountSb.ToString());
                var ds = SQLHelper.GetDataSet(sb.ToString(), parms);

                var dt = ds.Tables[0];

                var ExtDt = ds.Tables[1];

                var TotalDt = ds.Tables[2];


                TotalCount = Convert.ToInt32(TotalDt.Rows[0][0].ToString());

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var dr = dt.Rows[i];
                    var TempItem = new PurchasePlanView();
                    TempItem.PlanItem = new PurchasePlan()
                    {
                        ContantName = Convert.IsDBNull(dr["ContantName"]) ? "" : dr["ContantName"].ToString(),
                        ContantWay = Convert.IsDBNull(dr["ContantWay"]) ? "" : dr["ContantWay"].ToString(),
                        CreateDate = Convert.IsDBNull(dr["CreateDate"]) ? new DateTime(1900, 1, 1) : Convert.ToDateTime(dr["CreateDate"]),
                        EndDateTime = Convert.IsDBNull(dr["EndDateTime"]) ? new DateTime(1900, 1, 1) : Convert.ToDateTime(dr["EndDateTime"]),
                        HopePrice = Convert.IsDBNull(dr["HopePrice"]) ? 0 : Convert.ToDecimal(dr["HopePrice"]),
                        LastUpdateDate = Convert.IsDBNull(dr["LastUpdateDate"]) ? new DateTime(1900, 1, 1) : Convert.ToDateTime(dr["LastUpdateDate"]),
                        PName = Convert.IsDBNull(dr["PName"]) ? "" : dr["PName"].ToString(),
                        PPId = Convert.IsDBNull(dr["PPId"]) ? 0 : Convert.ToInt32(dr["PPId"]),
                        PurchaseName = Convert.IsDBNull(dr["PurchaseName"]) ? "" : dr["PurchaseName"].ToString(),
                        //  PurchaseType = Convert.IsDBNull(dr["PurchaseType"]) ? "" : dr["PurchaseType"].ToString(),
                        Qty = Convert.IsDBNull(dr["Qty"]) ? 0 : Convert.ToInt32(dr["Qty"]),
                        RequestContant = Convert.IsDBNull(dr["RequestContant"]) ? "" : dr["RequestContant"].ToString(),
                        RequestManufactureArea = Convert.IsDBNull(dr["RequestManufactureArea"]) ? "" : dr["RequestManufactureArea"].ToString(),
                        RequestReceiveArea = Convert.IsDBNull(dr["RequestReceiveArea"]) ? "" : dr["RequestReceiveArea"].ToString(),
                        Spec = Convert.IsDBNull(dr["Spec"]) ? "" : dr["Spec"].ToString(),
                        State = Convert.IsDBNull(dr["State"]) ? "" : dr["State"].ToString(),
                        Title = Convert.IsDBNull(dr["Title"]) ? "" : dr["Title"].ToString(),
                        Unit = Convert.IsDBNull(dr["Unit"]) ? "" : dr["Unit"].ToString(),
                        PurchaseDetails = Convert.IsDBNull(dr["PurchaseDetails"]) ? "" : dr["PurchaseDetails"].ToString(),
                    };


                    var drs = ExtDt.Select(" ContantId='" + dr["PPId"].ToString() + "'  ");

                    List<ExtTable> ExtList = new List<ExtTable>();

                    for (int k = 0; k < drs.Length; k++)
                    {
                        var TempDr = drs[k];
                        ExtList.Add(new ExtTable()
                        {
                            ContantId = Convert.IsDBNull(TempDr["ContantId"]) ? 0 : Convert.ToInt32(TempDr["ContantId"]),
                            ContantTableName = "PurchasePlan",
                            ExtId = Convert.IsDBNull(TempDr["ExtId"]) ? 0 : Convert.ToInt32(TempDr["ExtId"]),
                            ExtName = Convert.IsDBNull(TempDr["ExtName"]) ? "" : TempDr["ExtName"].ToString(),
                            ExtValue = Convert.IsDBNull(TempDr["ExtValue"]) ? "" : TempDr["ExtValue"].ToString(),

                        });
                    }
                    TempItem.ExtList = ExtList;

                    Res.Add(TempItem);
                }

                return Res;
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// 根据PPID取得采购计划
        /// </summary>
        /// <param name="PPId">采购计划ID</param>
        /// <returns></returns>
        public PurchasePlanView GetPurchasePlanByPPId(int PPId)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                SqlParameter[] parms = new SqlParameter[]
                {
                    new SqlParameter("@PPId",PPId),
                };
                sb.Append(" SELECT * FROM dbo.PurchasePlan WHERE PPId=@PPId ");

                sb.Append(" select * from dbo.ExtTable WHERE ContantId=@PPId");

                var ds = SQLHelper.GetDataSet(sb.ToString(), parms);
                var dt1 = ds.Tables[0];

                var ExtDt = ds.Tables[1];

                PurchasePlanView Res = new PurchasePlanView();

                if (dt1.Rows.Count > 0)
                {
                    var dr = dt1.Rows[0];
                    Res.PlanItem = new PurchasePlan()
                    {
                        ContantName = Convert.IsDBNull(dr["ContantName"]) ? "" : dr["ContantName"].ToString(),
                        ContantWay = Convert.IsDBNull(dr["ContantWay"]) ? "" : dr["ContantWay"].ToString(),
                        CreateDate = Convert.IsDBNull(dr["CreateDate"]) ? new DateTime(1900, 1, 1) : Convert.ToDateTime(dr["CreateDate"]),
                        EndDateTime = Convert.IsDBNull(dr["EndDateTime"]) ? new DateTime(1900, 1, 1) : Convert.ToDateTime(dr["EndDateTime"]),
                        HopePrice = Convert.IsDBNull(dr["HopePrice"]) ? 0 : Convert.ToDecimal(dr["HopePrice"]),
                        LastUpdateDate = Convert.IsDBNull(dr["LastUpdateDate"]) ? new DateTime(1900, 1, 1) : Convert.ToDateTime(dr["LastUpdateDate"]),
                        PName = Convert.IsDBNull(dr["PName"]) ? "" : dr["PName"].ToString(),
                        PPId = Convert.IsDBNull(dr["PPId"]) ? 0 : Convert.ToInt32(dr["PPId"]),
                        PurchaseName = Convert.IsDBNull(dr["PurchaseName"]) ? "" : dr["PurchaseName"].ToString(),
                        // PurchaseType = Convert.IsDBNull(dr["PurchaseType"]) ? "" : dr["PurchaseType"].ToString(),
                        Qty = Convert.IsDBNull(dr["Qty"]) ? 0 : Convert.ToInt32(dr["Qty"]),
                        RequestContant = Convert.IsDBNull(dr["RequestContant"]) ? "" : dr["RequestContant"].ToString(),
                        RequestManufactureArea = Convert.IsDBNull(dr["RequestManufactureArea"]) ? "" : dr["RequestManufactureArea"].ToString(),
                        RequestReceiveArea = Convert.IsDBNull(dr["RequestReceiveArea"]) ? "" : dr["RequestReceiveArea"].ToString(),
                        Spec = Convert.IsDBNull(dr["Spec"]) ? "" : dr["Spec"].ToString(),
                        State = Convert.IsDBNull(dr["State"]) ? "" : dr["State"].ToString(),
                        Title = Convert.IsDBNull(dr["Title"]) ? "" : dr["Title"].ToString(),
                        Unit = Convert.IsDBNull(dr["Unit"]) ? "" : dr["Unit"].ToString(),
                        PurchaseDetails = Convert.IsDBNull(dr["PurchaseDetails"]) ? "" : dr["PurchaseDetails"].ToString(),
                    };
                }


                List<ExtTable> ExtList = new List<ExtTable>();
                for (int i = 0; i < ExtDt.Rows.Count; i++)
                {
                    var dr = ExtDt.Rows[i];
                    ExtTable ExtItem = new ExtTable();
                    ExtItem.ExtId = Convert.IsDBNull(dr["ExtId"]) ? 0 : Convert.ToInt32(dr["ExtId"]);
                    ExtItem.ExtName = Convert.IsDBNull(dr["ExtName"]) ? "" : dr["ExtName"].ToString();
                    ExtItem.ExtValue = Convert.IsDBNull(dr["ExtValue"]) ? "" : dr["ExtValue"].ToString();
                    ExtItem.ContantId = Convert.IsDBNull(dr["ContantId"]) ? 0 : Convert.ToInt32(dr["ContantId"]);

                    ExtList.Add(ExtItem);
                }

                Res.ExtList = ExtList;

                return Res;
            }
            catch (Exception)
            {
                return null;
            }
        }



        /// <summary>
        /// 删除采购计划
        /// </summary>
        /// <param name="PPId">采购计划ID</param>
        /// <returns></returns>
        public int DeletePurchasePlanByPPId(int PPId)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                SqlParameter[] parms = new SqlParameter[]
                {
                    new SqlParameter("@PPId",PPId),
                };
                sb.Append(" DELETE dbo.ExtTable WHERE ContantId=@PPId AND ContantTableName='PurchasePlan' ");
                sb.Append(" DELETE dbo.PurchasePlan WHERE PPId=@PPId  ");

                return SQLHelper.ExcuteSQL(sb.ToString(), parms);
            }
            catch (Exception)
            {
                return -1;
            }
        }



        /// <summary>
        /// 更新采购计划
        /// </summary>
        /// <param name="BigModel"></param>
        /// <returns></returns>
        public int UpdatePurchasePlan(PurchasePlanModel BigModel)
        {
            try
            {
                var ExtList = BigModel.ExtList;
                var Item = BigModel.Item;
                SqlParameter[] parms = new SqlParameter[]
                {
                    new SqlParameter("@ContantName",Item.ContantName),
                    new SqlParameter("@ContantWay",Item.ContantWay),
                    new SqlParameter("@EndDateTime",Item.EndDateTime),
                    new SqlParameter("@HopePrice",Item.HopePrice),
                    new SqlParameter("@PName",Item.PName),
                    new SqlParameter("@PurchaseName",Item.PurchaseName),
                    new SqlParameter("@PurchaseType",Item.PurchaseType),
                    new SqlParameter("@Qty",Item.Qty),
                    new SqlParameter("@RequestContant",Item.RequestContant),
                    new SqlParameter("@RequestManufactureArea",Item.RequestManufactureArea),
                    new SqlParameter("@RequestReceiveArea",Item.RequestReceiveArea),
                    new SqlParameter("@Spec",Item.Spec),
                    new SqlParameter("@Title",Item.Title),
                    new SqlParameter("@Unit",Item.Unit),
                    new SqlParameter("@State",Item.State),
                    new SqlParameter("@PurchaseDetails",Item.PurchaseDetails),
                    new SqlParameter("@PPId",Item.PPId),
                };
                StringBuilder sb = new StringBuilder();
                sb.Append(" UPDATE dbo.PurchasePlan ");
                sb.Append(" SET Title=@Title,PName=@PName,State=@State,PurchaseDetails=@PurchaseDetails, ");
                sb.Append(" Spec=@Spec,Qty=@Qty,Unit=@Unit,HopePrice=@HopePrice,PurchaseName=@PurchaseName, ");
                sb.Append(" ContantName=@ContantName,ContantWay=@ContantWay,EndDateTime=@EndDateTime, ");
                sb.Append(" PurchaseType=@PurchaseType,RequestManufactureArea=@RequestManufactureArea, ");
                sb.Append(" RequestReceiveArea=@RequestReceiveArea,RequestContant=@RequestContant, ");
                sb.Append(" LastUpdateDate=GETDATE(),LastUpdateUId=@LastUpdateUid ");
                sb.Append(" WHERE PPId=@PPId ");

                sb.Append(" DELETE dbo.ExtTable WHERE ContantId=@PPId and ContantTableName='PurchasePlan' ");

                for (int i = 0; i < ExtList.Count; i++)
                {
                    sb.Append(" INSERT INTO dbo.ExtTable( ContantId ,ContantTableName ,ExtName ,ExtValue , ");
                    sb.Append(" CreateDate ,CreateUid ,LastUpdateDate ,LastUpdateUId) ");
                    sb.AppendFormat(" Value(@PPId,'PurchasePlan','{0}','{1}',GETDATE(),@CreateUid,GETDATE(),@CreateUid) ", ExtList[i].ExtName, ExtList[i].ExtValue);
                }

                return SQLHelper.ExcuteSQL(sb.ToString(), parms);

            }
            catch (Exception)
            {
                return -1;
            }
        }

        public List<PurchasePlan> GetPurchasePlanByStoreID(int storeID)
        {
            var list = new List<PurchasePlan>();
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT ");
                sql.Append("p2.[Title],p2.[PName],p2.[State],p2.[PurchaseDetails],p2.[Spec],p2.[Qty],p2.[Unit],p2.[HopePrice],p2.[PurchaseName],p2.[ContantName],p2.[ContantWay],p2.[EndDateTime],p2.[PurchaseType],");
                sql.Append("p2.[RequestManufactureArea],p2.[RequestReceiveArea],p2.[RequestContant],p2.[CreateDate],p2.[CreateUserID],p2.[LastUpdateDate],p2.[LastUpdateUserID] ");
                sql.Append("FROM PurchasePlanStore p ");
                sql.Append("LEFT JOIN PurchasePlan p2 ON p.PlanID=p2.ID ");
                sql.Append(string.Format("WHERE StoreID={0}", storeID));

                var dt = SQLHelper.GetTable(sql.ToString());
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = new PurchasePlan
                    {
                        Title = Convert.IsDBNull(dt.Rows[i]["Title"]) ? "" : Convert.ToString(dt.Rows[i]["Title"]),
                        PName = Convert.IsDBNull(dt.Rows[i]["PName"]) ? "" : Convert.ToString(dt.Rows[i]["PName"]),
                        State = Convert.IsDBNull(dt.Rows[i]["State"]) ? "" : Convert.ToString(dt.Rows[i]["State"]),
                        PurchaseDetails = Convert.IsDBNull(dt.Rows[i]["PurchaseDetails"]) ? "" : Convert.ToString(dt.Rows[i]["PurchaseDetails"]),
                        Spec = Convert.IsDBNull(dt.Rows[i]["Spec"]) ? "" : Convert.ToString(dt.Rows[i]["Spec"]),
                        Qty = Convert.IsDBNull(dt.Rows[i]["Qty"]) ? 0 : Convert.ToInt32(dt.Rows[i]["Qty"]),
                        Unit = Convert.IsDBNull(dt.Rows[i]["Unit"]) ? "" : Convert.ToString(dt.Rows[i]["Unit"]),
                        HopePrice = Convert.IsDBNull(dt.Rows[i]["Unit"]) ? 0 : Convert.ToDecimal(dt.Rows[i]["Unit"]),
                        PurchaseName = Convert.IsDBNull(dt.Rows[i]["PurchaseName"]) ? "" : Convert.ToString(dt.Rows[i]["PurchaseName"]),
                        ContantName = Convert.IsDBNull(dt.Rows[i]["ContantName"]) ? "" : Convert.ToString(dt.Rows[i]["ContantName"]),
                        ContantWay = Convert.IsDBNull(dt.Rows[i]["ContantWay"]) ? "" : Convert.ToString(dt.Rows[i]["ContantWay"]),
                        EndDateTime = Convert.IsDBNull(dt.Rows[i]["EndDateTime"]) ? new DateTime() : Convert.ToDateTime(dt.Rows[i]["EndDateTime"]),
                        PurchaseType = new Category
                        {
                        },
                        RequestManufactureArea = Convert.IsDBNull(dt.Rows[i]["RequestManufactureArea"]) ? "" : Convert.ToString(dt.Rows[i]["RequestManufactureArea"]),
                        RequestReceiveArea = Convert.IsDBNull(dt.Rows[i]["RequestReceiveArea"]) ? "" : Convert.ToString(dt.Rows[i]["RequestReceiveArea"]),
                        RequestContant = Convert.IsDBNull(dt.Rows[i]["RequestContant"]) ? "" : Convert.ToString(dt.Rows[i]["RequestContant"]),
                        CreateDate = Convert.IsDBNull(dt.Rows[i]["CreateDate"]) ? new DateTime() : Convert.ToDateTime(dt.Rows[i]["CreateDate"]),
                        CreateUser = new User { }
                    };
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
