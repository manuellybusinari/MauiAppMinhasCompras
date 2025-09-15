using SQLite;
namespace MauiAppMinhasCompras.Models
{
    public class Produto
    {
        string _descricao;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Descricao
        {
            get => _descricao; // Retorno da descrição 

            set
            {
                if(value == null) // 'null' diferente de 'vazio'
                {
                    throw new Exception("Por favor, preencha os campos");
                }

                _descricao = value;
            }
        }
        public double Quantidade { get; set; }

        public double Preco { get; set; }
        public double Total { get => Quantidade * Preco; }
    
        public DateTime DataCadastro { get; set; }// Esse campo vai registrar a data em que o produto foi comprado.
    }

}
