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
    public class ProductConsult_BLL:IProductConsult
    {
        ProductConsult_DAL _dal = new ProductConsult_DAL();

        public ProductConsultsModel GetProductConsultByPid(int Pid, int type, int PageSize, int PageNumber)
        {
            return _dal.GetProductConsultByPid( Pid,  type,  PageSize,  PageNumber);
        }

        public ProductConsultsModel GetProductConsultListByUid(int Uid, int type, int PageSize, int PageNumber)
        {
            return _dal.GetProductConsultListByUid( Uid,  type,  PageSize,  PageNumber);
        }

        public ProductConsults GetProductConsultByPCId(int PCId)
        {
            return _dal.GetProductConsultByPCId(PCId);
        }

        public int AddProductConsult(ProductConsults Item)
        {
            return _dal.AddProductConsult(Item);
        }

        public int UpdateProductConsult(ProductConsults Item)
        {
            return _dal.UpdateProductConsult(Item);
        }

        public int DeleteProductConsult(int PCId)
        {
            return _dal.DeleteProductConsult( PCId);
        }

        public int ReplyProductConsult(ProductConsults Item)
        {
            return _dal.ReplyProductConsult( Item);
        }

        
    }
}
