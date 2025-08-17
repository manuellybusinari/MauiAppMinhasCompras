using SQLite;
using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDatabaseHelper
    {
        private SQLiteAsyncConnection _database;

        public SQLiteDatabaseHelper(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> SalvarProdutoAsync(Produto produto)
        {
            if (produto.Id != 0)
                return _database.UpdateAsync(produto);
            else
                return _database.InsertAsync(produto);
        }

        public Task<List<Produto>> GetProdutosAsync()
        {
            return _database.Table<Produto>().ToListAsync();
        }

        public Task<int> DeleteProdutoAsync(Produto produto)
        {
            return _database.DeleteAsync(produto);
        }
    }
}
