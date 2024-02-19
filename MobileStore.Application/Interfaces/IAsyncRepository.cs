using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Application.Interfaces
{
    public interface IAsyncRepository<T>
    {
        Task<string> GetById(long Id);
        Task<List<T>> GetAll();
        Task<string> Add(T item);
        Task<string> Update(T item);
        Task<string> Delete(long Id);
    }
}
