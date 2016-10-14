using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.DAL;
using YunXiu.Interface;
using YunXiu.Model;

namespace YunXiu.BLL
{
    public class ShoppingCart_BLL : IShoppingCart
    {
        ShoppingCart_DAL dal = new ShoppingCart_DAL();
        public bool AddProductToShoppingCart(ShoppingCart sc)
        {
            var result = false;
            try
            {
                result = dal.AddProductToShoppingCart(sc);
            }
            catch (Exception ex) { }
            return result;
        }

        public bool DeleteShoppingCartProduct(int uID,int pID)
        {
            var result = false;
            try
            {
                result = dal.DeleteShoppingCartProduct(uID,pID);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<ShoppingCart> GetShoppingCartByProduct(List<int> pID)
        {
            return dal.GetShoppingCartByProduct(pID);
        }

        public List<ShoppingCart> GetShoppingCartByUser(int userID)
        {
            return dal.GetShoppingCartByUser(userID);
        }

        public List<ShoppingCart> GetShoppingCartByUserID(int userID)
        {
            var list = new List<ShoppingCart>();
            try
            {
                list = dal.GetShoppingCartByUser(userID);
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
