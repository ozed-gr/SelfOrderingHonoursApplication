using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.Common
{
    public interface IDataRepository<T> where T : class
    {
        Task<T> GetAll();
        Task<T> GetById(int p_id);
        Task<T> Create(int p_id);
    }
}
