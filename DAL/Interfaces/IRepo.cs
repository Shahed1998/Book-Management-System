using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo <Class>
    {
        List<Class> Get(int page = 1, int pageSize = 10);

        Class Get(int id);

        Class Add(Class c);

        Class Update(Class c);

        Class Delete(int id);
    }
}
