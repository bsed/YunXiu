﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IStoreUserGroupStoreUser
    {
        bool AddStoreUserGroupStoreUser(StoreUserGroupStoreUser groupUser);

        List<StoreUser> GetStoreUserByGroup();
    }
}
