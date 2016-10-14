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
        Lazy<PermissionType_BLL> typeBll = new Lazy<PermissionType_BLL>();

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
        public HttpResponseMessage GetRoles()
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
                var users = roleBll.Value.GetUserByRole(list[0]);//获取拥有该角色的用户                            
                if (users.Count < 1)
                {
                    result = permissionBll.Value.AddRolePermission(list[0], list[1]);
                }
                else
                {
                    for (var i = 0; i < users.Count; i++)
                    {
                        var isAddPermission = true;
                        var userR = roleBll.Value.GetRoleByUser(users[i].UID);
                        for (int j = 0; j < userR.Count; j++)
                        {
                            var roleP = permissionBll.Value.GetPermissionByRole(userR[j].RID);//获取用户角色权限
                            for (int l = 0; l < roleP.Count; l++)
                            {
                                if (list[1] == roleP[l].PID)
                                {
                                    isAddPermission = false;
                                    break;
                                }
                            }
                            if (!isAddPermission)
                            {
                                break;
                            }
                        }
                        if (isAddPermission)
                        {
                            result = permissionBll.Value.AddRolePermission(list[0], list[1]);
                            result = permissionBll.Value.AddUserPermission(users[i].UID, list[1]);
                        }
                    }
                }
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
                    var users = roleBll.Value.GetUserByRole(list[0]);
                    if (users.Count > 0)
                    {
                        List<int> uIDList = new List<int>();
                        users.ForEach(u => uIDList.Add(u.UID));
                        result = permissionBll.Value.DeleteMultipleUserPermission(uIDList, list[1]);
                    }                            
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

                //  if (result)
                //  {
                var pList = permissionBll.Value.GetPermissionByRole(list[1]);
                //var users = roleBll.Value.GetUserByRole(list[1]);//获取拥有该角色的用户
                //  for (int i = 0; i < users.Count; i++)
                //{
                var userR = roleBll.Value.GetRoleByUser(list[0]); //获取该用户的所有角色
                userR.RemoveAll(r => r.RID == list[1]);
                for (int j = 0; j < userR.Count; j++)
                {
                    var roleP = permissionBll.Value.GetPermissionByRole(userR[j].RID);//获取用户角色权限
                    for (int l = 0; l < roleP.Count; l++)
                    {
                        pList.RemoveAll(p => p.PID == roleP[l].PID);
                        if (pList.Count == 0)
                        {
                            break;
                        }
                    }
                    if (pList.Count == 0)
                    {
                        break;
                    }
                }
                //if (pList.Count == 0)
                //{
                //    break;
                //}
                if (pList.Count > 0)
                {
                    var tempList = new List<int>();
                    pList.ForEach(p => tempList.Add(p.PID));
                    result = permissionBll.Value.AddMultipleUserPermission(list[0], tempList);
                }

                // }
                result = roleBll.Value.AddUserRole(list[0], list[1]);
                //var tempList = new List<int>();
                //pList.ForEach(p => tempList.Add(p.PID));
                //result = permissionBll.Value.AddMultipleUserPermission(list[0], tempList);
                //  }
            }
            response = WebCommom.GetResponse(result);
            return response;
        }


        /// <summary>
        /// 删除用户角色
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage DeleteUserRole()
        {
            HttpResponseMessage response = null;
            var result = false;
            var list = WebCommom.HttpRequestBodyConvertToObj<List<int>>(HttpContext.Current);
            if (list.Count > 0)
            {

                //  
                //  if (result)
                //   {
                var pList = permissionBll.Value.GetPermissionByRole(list[1]);//获取角色权限
                                                                             //   var users = roleBll.Value.GetUserByRole(list[1]);//获取拥有该角色的用户            
                                                                             //  for (int i = 0; i < users.Count; i++)
                                                                             //    {
                var userR = roleBll.Value.GetRoleByUser(list[0]); //获取该用户的所有角色
                userR.RemoveAll(r => r.RID == list[1]);
                for (int j = 0; j < userR.Count; j++)
                {
                    var roleP = permissionBll.Value.GetPermissionByRole(userR[j].RID);//获取用户角色权限
                    for (int l = 0; l < roleP.Count; l++)
                    {
                        pList.RemoveAll(p => p.PID == roleP[l].PID);
                        if (pList.Count == 0)
                        {
                            break;
                        }
                    }
                    if (pList.Count == 0)
                    {
                        break;
                    }
                }
                //if (pList.Count == 0)
                //{
                //    break;
                //}
                if (pList.Count > 0)
                {
                    var tempList = new List<int>();
                    pList.ForEach(p => tempList.Add(p.PID));
                    result = permissionBll.Value.DeleteMultipleUserPermission(list[0], tempList);
                }

                // }
                result = roleBll.Value.DeleteUserRole(list[0], list[1]);
                //   }
            }
            response = WebCommom.GetResponse(result);
            return response;
        }

        /// <summary>
        /// 获取权限类型
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetPermissionType()
        {
            HttpResponseMessage response = null;
            List<PermissionType> list = null;
            list = typeBll.Value.GetPermissionType();
            response = WebCommom.GetJsonResponse(list);
            return response;
        }
        #endregion
    }
}
