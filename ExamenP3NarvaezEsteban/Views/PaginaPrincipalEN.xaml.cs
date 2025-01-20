using ExamenP3NarvaezEsteban.ViewModels;

namespace ExamenP3NarvaezEsteban.Views
{
    public partial class PaginaPrincipalEN : TabbedPage
    {
        private PaginaBusquedaPaisViewModelEN _busquedaVM;
        private PaginaListaPaisesViewModelEN _listaVM;

        public PaginaPrincipalEN()
        {
            InitializeComponent();

            _busquedaVM = new PaginaBusquedaPaisViewModelEN();
            _busquedaVM.PaisGuardado += OnPaisGuardado;

            _listaVM = new PaginaListaPaisesViewModelEN();

            var busquedaPage = new PaginaBusquedaPaisEN { BindingContext = _busquedaVM };
            var listaPage = new PaginaListaPaisesEN { BindingContext = _listaVM };

            Children.Add(busquedaPage);
            Children.Add(listaPage);
        }

        private void OnPaisGuardado()
        {
            _listaVM.CargarPaises();
        }
    }
}
