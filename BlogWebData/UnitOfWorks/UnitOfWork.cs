using BlogWebData.Context;
using BlogWebData.Repositories.Abstractions;
using BlogWebData.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebData.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        //Repository yapı DbContext'i kullandığı gibi UnitOfWork yapısı da Dbcontext'i kullancak çünkü veritabanını etkileyen işlemler yapmış olacağız. 

        private readonly AppDbContext dbContext;
        
        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async ValueTask DisposeAsync()
        {
            await this.dbContext.DisposeAsync();
        }

        public int Save()
        {
            return dbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        IRepository<T> IUnitOfWork.GetRepository<T>()
        {
            //IRepository'nin somut hali olan Repository'imizi çağırıp işlemleri bizim için T'ye göre gerçekleştirmesini işticez.
            return new Repository<T>(dbContext);
        }
    }
}
