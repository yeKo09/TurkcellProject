using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellProject.DAL.IRepos
{
    public interface ISelectSingleItemWithIDRepo<T> where T : class
    {

        T SelectSingleItem(int id);

    }
}
