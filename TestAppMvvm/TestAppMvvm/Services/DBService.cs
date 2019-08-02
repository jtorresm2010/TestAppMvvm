using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestAppMvvm.Models;

namespace TestAppMvvm.Services
{
    public class DBService
    {
        readonly SQLiteAsyncConnection _database;

        public DBService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Usuario>().Wait();
        }



        public Task<List<Usuario>> GetUsersAsync()
        {
            return _database.Table<Usuario>().ToListAsync();
        }

        public int CountUserAsync(String usr)
        {
            return _database.Table<Usuario>()
                            .Where(i => i.NOMBRE_USUARIO == usr).CountAsync().Result;
        }
       
        public Task<Usuario> GetUserAsync(String usr)
        {
            return _database.Table<Usuario>()
                            .Where(i => i.NOMBRE_USUARIO == usr)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveUserAsync(Usuario usuario)
        {
            //return _database.InsertOrReplaceAsync(usuario);
            return _database.InsertAsync(usuario);
        }


        public Task<int> SaveReplaceUserAsync(Usuario usuario)
        {
            return _database.InsertOrReplaceAsync(usuario);
            //return _database.InsertAsync(usuario);
        }

        public Task<int> DeleteUserAsync(Usuario usuario)
        {
            return _database.DeleteAsync(usuario);
        }

        public Task<int> UpdateUserAsync(Usuario usuario)
        {
            return _database.UpdateAsync(usuario);
        }
    }
}
