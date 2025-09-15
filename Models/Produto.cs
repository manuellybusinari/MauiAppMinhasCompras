using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Produto
    {
        private string _descricao;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Descricao
        {
            get => _descricao;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("A descrição não pode ser nula ou vazia.");
                }

                _descricao = value;
            }
        }

        public double Quantidade { get; set; }
        public double Preco { get; set; }
        public double Total { get => Quantidade * Preco; }

        public DateTime DataCadastro { get; set; }

        // Construtor para inicializar as propriedades, incluindo a DataCadastro
        public Produto()
        {
            DataCadastro = DateTime.Now;
        }
    }
}