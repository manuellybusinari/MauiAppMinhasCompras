using MauiAppMinhasCompras.Helpers;

namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {

        static SQLiteDatabaseHelper _db; //_db -> campo

        public static SQLiteDatabaseHelper Db // -->Db: propriedade de leitura
        { get // contendo uma instância da classe SQLiteDatabaseHelper
            {
                if (_db == null) // se não houver nenhum objeto dentro do campo
                {
                    //fazer o mecanismo de multiplataforma funcionar corretamente: 
                    //caminho até o arquivo db3 (dado em vídeoaula)

                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData), //Local que contém os arquivos da aplicação
                              "banco_sqlite_compras.db3"); // nome do arquivo

                    // Combine: Encapsulamento com caminhos diretos e completos
                    // Environment: informações sobre o ambiente
                    // GetFolderPath: Informações contidas em uma pasta
                    // Environment.SpecialFolder: Local/caminho

                   


                    _db= new SQLiteDatabaseHelper(path);
                }
                return _db; // retorna
            }            
            
                }
                                             
        public App()
        {
            InitializeComponent();

            //  MainPage = new AppShell();

            MainPage = new NavigationPage(new Views.ListaProduto());
            //Página inicial Alterada
        }
    }
}
