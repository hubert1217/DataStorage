﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.Abstractions.DataAccess;
using Web.Infrastructure.Database.Context;

namespace Web.Infrastructure.Database
{
    public class AddressDao(DataStorageAppContext context): BaseDao<AddressDao>(context), IAddressDao
    {
    }
}
