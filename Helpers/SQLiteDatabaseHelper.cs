using MauiAppMinhasCompras.Models;    // classe Produto
using SQLite;                         // acesso ao SQLite

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDatabaseHelper
    {
        // (_conn -> _db)
        private readonly SQLiteAsyncConnection _db;  // inicializado no construtor


        // Construtor público: recebe o caminho do .db e cria a tabela se não existir
        public SQLiteDatabaseHelper(string path)
        {
            _db = new SQLiteAsyncConnection(path);
            _db.CreateTableAsync<Produto>().Wait();
        }


        // INSERT: retorna qtd de linhas afetadas
        public Task<int> Insert(Produto p)
        {
            return _db.InsertAsync(p);
        }


        // UPDATE: usa ExecuteAsync (não QueryAsync) e retorna qtd de linhas afetadas
        public Task<int> Update(Produto p)
        {
            const string sql = "UPDATE Produto SET Descricao=?, Quantidade=?, Preco=?, DataCadastro=? WHERE Id=?";
            return _db.ExecuteAsync(sql, p.Descricao, p.Quantidade, p.Preco, p.DataCadastro, p.Id);
        }


        // DELETE por Id
        public Task<int> Delete(int id)
        {
            return _db.Table<Produto>().DeleteAsync(i => i.Id == id);
        }


        // SELECT * (todos)
        public Task<List<Produto>> GetAll()
        {
            return _db.Table<Produto>().ToListAsync();
        }


        // SEARCH por Descricao com LIKE e parâmetro (evita SQL Injection)
        public Task<List<Produto>> Search(string q)
        {
            const string sql = "SELECT * FROM Produto WHERE Descricao LIKE ?";
            return _db.QueryAsync<Produto>(sql, "%" + q + "%");
        }
    }
}
