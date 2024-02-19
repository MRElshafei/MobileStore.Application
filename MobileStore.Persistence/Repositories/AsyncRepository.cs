using MobileStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Persistence.Repositories
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : class
    {
        public Task<string> Add(T item)
        {
            throw new NotImplementedException();
        }

        public Task<string> Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetById(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<string> Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
