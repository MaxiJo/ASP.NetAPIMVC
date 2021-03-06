﻿using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    interface IItemRepositories
    {
        IEnumerable<SupplierItem> Get();
        Task<IEnumerable<SupplierItem>> Get(int id);
        int Create(Item item);
        int Update(Item item, int id);
        int Delete( int id);
    }
}
