using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DataTracker.DataCore.Repositories
{
    public interface IRepository<T>
    {

        IEnumerable<T> GetAll();


        bool InsertRange(IEnumerable<T> ts);

        bool DeleteAll();
    }
}
