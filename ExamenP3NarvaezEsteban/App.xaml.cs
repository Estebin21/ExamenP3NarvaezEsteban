using ExamenP3NarvaezEsteban.Views;

namespace ExamenP3NarvaezEsteban
{
    public partial class App : Application
    {
        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, "ExamenEN.db3");
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new PaginaPrincipalEN();
        }
    }
}
