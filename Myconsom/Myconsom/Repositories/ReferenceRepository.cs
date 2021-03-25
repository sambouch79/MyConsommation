using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Myconsom.Models;
using SQLite;

namespace Myconsom.Repositories
{
    public class ReferenceRepository
    {
        readonly SQLiteAsyncConnection _database;

        public ReferenceRepository(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Reference>().Wait();

        }

        public Task<List<Reference>> GetReferenceAsync()
        {
            return _database.Table<Reference>().ToListAsync();
        }

        public Task<Reference> GetReferenceAsync(int id)
        {
            return _database.Table<Reference>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SavereferenceAsync(Reference reference)
        {
            if (reference.ID != 0)
            {
                return _database.UpdateAsync(reference);
            }
            else
            {
                return _database.InsertAsync(reference);
            }
        }

        public Task<int> DeletereferenceAsync(Reference reference)
        {
            return _database.DeleteAsync(reference);
        }
     
      

      
     
    }
}
