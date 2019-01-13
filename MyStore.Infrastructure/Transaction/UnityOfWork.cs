using MyStore.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Infrastructure.Transaction
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly MyStoreDataContext _context;

        public UnityOfWork(MyStoreDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            // do anything
        }
    }
}
