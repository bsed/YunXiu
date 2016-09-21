using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IProductConsult
    {
        
        /// <summary>
        /// 根据商品ID取得咨询列表
        /// </summary>
        /// <param name="Pid"></param>
        /// <param name="type">类型</param>
        /// <param name="PageSize">每页显示数</param>
        /// <param name="PageNumber">页码</param>
        /// <returns></returns>
        ProductConsultsModel GetProductConsultByPid(int Pid,int type,int PageSize,int PageNumber);

        /// <summary>
        /// 根据用户ID取得咨询列表
        /// </summary>
        /// <param name="Uid"></param>
        /// <param name="type"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageNumber"></param>
        /// <returns></returns>
        ProductConsultsModel GetProductConsultListByUid(int Uid,int type,int PageSize,int PageNumber);


        /// <summary>
        /// 根据咨询ID取得咨询详情
        /// </summary>
        /// <param name="PCId"></param>
        /// <returns></returns>
        ProductConsults GetProductConsultByPCId(int PCId);


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        int AddProductConsult(ProductConsults Item);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        int UpdateProductConsult(ProductConsults Item);


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="PCId"></param>
        /// <returns></returns>
        int DeleteProductConsult(int PCId);


        /// <summary>
        /// 回复咨询
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        int ReplyProductConsult(ProductConsults Item);


    }
}
