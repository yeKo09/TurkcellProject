using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellProject.DTO;

namespace TurkcellProject.DAL.IRepos
{
    public interface IInsertRepo<T> where T : class
    {
        MyResult Insert(T insertedData);
    }
}
