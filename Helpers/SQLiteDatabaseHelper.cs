using SQLite;
using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        private SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }
        
        public Task<int> Insert(Produto p) 
        {
            return _conn.InsertAsync(p);
        }
        //ok

        public Task<List<Produto>> Update (Produto p) 
        {
            string sql = "UPTADE Produto SET Descricao=?, Quantidade=?, Preco=? WHERE Id=?";

            return _conn.QueryAsync<Produto>(
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id
                
             );
        }
        //ok

        public Task<int> Delete(int id) 
        { 
           return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        
        }
        //ok

        public Task<List<Produto>> GetAll() 
        {
           return _conn.Table<Produto>().ToListAsync();     
        }
        //ok
        public Task<List<Produto>> Search(string q) 
        {
            string sql = "SELECT * Produto WHERE descricao LIKE '%" + q + "%'";

            return _conn.QueryAsync<Produto>(sql);
        }

      
        }
    }
