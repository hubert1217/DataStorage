using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Infrastructure.Database.Context;

namespace Web.Infrastructure.Database
{
    public abstract class BaseDao<TEntity>(DataStorageAppContext dbContext) where TEntity : class
    {
        protected readonly DataStorageAppContext Context = dbContext;
    }
}
