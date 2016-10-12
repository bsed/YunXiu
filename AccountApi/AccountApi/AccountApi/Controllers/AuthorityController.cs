using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using YunXiu.Model;
using YunXiu.BLL;
using YunXiu.Commom;

namespace AccountApi.Controllers
{
    public class AuthorityController : ApiController
    {
        Lazy<Role_BLL> roleBll = new Lazy<Role_BLL>();
        Lazy<Permission_BLL> permissionBll = new Lazy<Permission_BLL>();

        #region  角色
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddRole()
        {
            HttpResponseMessage response = null;
            var result = false;
            try
            {
                var role = WebCommom.HttpRequestBodyConvertToObj<Role>(HttpContext.Current);
                result = roleBll.Value.AddRole(role);
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetResponse(result);
            return response;
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UpdateRole()
        {

            HttpResponseMessage response = null;
            var result = false;
            try
            {
                var role = WebCommom.HttpRequestBodyConvertToObj<Role>(HttpContext.Current);
                result = roleBll.Value.UpdateRole(role);
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetResponse(result);
            return response;
        }


        /// <summary>
        /// 删除角色
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage DeleteRole()
        {
            HttpResponseMessage response = null;
            var result = false;
            try
            {
                var rID = WebCommom.HttpRequestBodyConvertToObj<int>(HttpContext.Current);
                result = roleBll.Value.DeleteRole(rID);
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetResponse(result);
            return response;
        }

        /// <summary>
        /// 获取角色
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetRole()
        {
            HttpResponseMessage response = null;
            List<Role> list = null;
            try
            {
                list = roleBll.Value.GetRole();
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetResponse(list);
            return response;
        }

        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetRoleByUser()
        {
            HttpResponseMessage response = null;
            List<Role> list = null;
            try
            {
                var uID = WebCommom.HttpRequestBodyConvertToObj<int>(HttpContext.Current);
                roleBll.Value.GetRoleByUser(uID);
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetJsonResponse(list);
            return response;
        }

        #endregion

        #region 权限

        /// <summary>
        /// 添加权限
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddPermission()
        {
            HttpResponseMessage response = null;
            var result = false;
            try
            {
                var permission = WebCommom.HttpRequestBodyConvertToObj<Permission>(HttpContext.Current);
                result = permissionBll.Value.AddPermission(permission);
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetResponse(result);
            return response;
        }

        /// <summary>
        /// 修改权限
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UpdatePermission()
        {
            HttpResponseMessage response = null;
            var result = false;
            try
            {
                var permission = WebCommom.HttpRequestBodyConvertToObj<Permission>(HttpContext.Current);
                result = permissionBll.Value.UpdatePermission(permission);
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetResponse(result);
            return response;
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage DeletePermission()
        {
            HttpResponseMessage response = null;
            var result = false;
            try
            {
                var pID = WebCommom.HttpRequestBodyConvertToObj<int>(HttpContext.Current);
                result = permissionBll.Value.DeletePermission(pID);
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetResponse(result);
            return response;
        }

        /// <summary>
        /// 获取权限
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetPermissions()
        {
            HttpResponseMessage response = null;
            List<Permission> list = null;
            try
            {
                list = permissionBll.Value.GetPermission();
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetResponse(list);
            return response;
        }

        /// <summary>
        /// 获取角色权限
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetPermissionByRole()
        {
            HttpResponseMessage response = null;
            List<Permission> list = null;
            try
            {
                var rID = WebCommom.HttpRequestBodyConvertToObj<int>(HttpContext.Current);
                list = permissionBll.Value.GetPermissionByRole(rID);
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetResponse(list);
            return response;
        }

        /// <summary>
        /// 获取角色权限
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetPermissionByUser()
        {
            HttpResponseMessage response = null;
            List<Permission> list = null;
            try
            {
                var uID = WebCommom.HttpRequestBodyConvertToObj<int>(HttpContext.Current);
                list = permissionBll.Value.GetPermissionByUser(uID);
            }
            catch (Exception ex)
            {

            }
            response = WebCommom.GetResponse(list);
            return response;
        }

        /// <summary>
        /// 添加角色权限
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddRolePermission()
        {
            HttpResponseMessage response = null;
            var result = false;
            var list = WebCommom.HttpRequestBodyConvertToObj<List<int>>(HttpContext.Current);
            if (list.Count > 0)
            {
                result = permissionBll.Value.AddRolePermission(list[0], list[1]);
            }
            response = WebCommom.GetResponse(result);
            return response;
        }

        /// <summary>
        /// 添加用户权限
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddUserPermission()
        {
            HttpResponseMessage response = null;
            var result = false;
            var list = WebCommom.HttpRequestBodyConvertToObj<List<int>>(HttpContext.Current);
            if (list.Count > 0)
            {
                result = permissionBll.Value.AddUserPermission(list[0], list[1]);
            }
            response = WebCommom.GetResponse(result);
            return response;
        }

        /// <summary>
        /// 添加角色权限
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage DeleteRolePermission()
        {
            HttpResponseMessage response = null;
            var result = false;
            var list = WebCommom.HttpRequestBodyConvertToObj<List<int>>(HttpContext.Current);
            if (list.Count > 0)
            {
                result = permissionBll.Value.DeleteRolePermission(list[0], list[1]);
                if (result)
                {
                    var users = roleBll.Value.GetUserByRole(list[1]);
                    List<int> uIDList = new List<int>();
                    users.ForEach(u => uIDList.Add(u.UID));
                    result = permissionBll.Value.DeleteMultipleUserPermission(uIDList, list[0]);
                }
            }
            response = WebCommom.GetResponse(result);
            return response;
        }

        /// <summary>
        /// 添加角色权限
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage DeleteUserPermission()
        {
            HttpResponseMessage response = null;
            var result = false;
            var list = WebCommom.HttpRequestBodyConvertToObj<List<int>>(HttpContext.Current);
            if (list.Count > 0)
            {
                result = permissionBll.Value.DeleteUserPermission(list[0], list[1]);
            }
            response = WebCommom.GetResponse(result);
            return response;
        }

        /// <summary>
        /// 添加用户角色
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddUserRole()
        {
            HttpResponseMessage response = null;
            var result = false;
            var list = WebCommom.HttpRequestBodyConvertToObj<List<int>>(HttpContext.Current);
            if (list.Count > 0)
            {
                result = roleBll.Value.AddUserRole(list[0], list[1]);
            }
            response = WebCommom.GetResponse(result);
            return response;
        }
        #endregion
    }
}
