using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4AvancAPI.Services
{
    public interface ILabb4Avanc<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetSingle(int id);
        Task<T> Add(T newEntity);
        Task<T> Delete(int id);
        Task<T> Update(T newEntity);
    }
}
