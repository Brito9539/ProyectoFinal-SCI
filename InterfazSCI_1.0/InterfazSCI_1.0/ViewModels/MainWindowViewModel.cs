using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SCI.Windows;
using SCI.DesktopClient.Views;

namespace SCI.DesktopClient.ViewModels
{
    public class MainWindowViewModel: ViewModel
    {
        private ArticulosView ArtView { get { return new ArticulosView(); } }
        private UsuariosView UsuarioView{ get { return new UsuariosView(); } }
        private ProveedoresView ProvView{ get { return new ProveedoresView(); } }
        private EntradasView EntraView {get { return new EntradasView(); } }
        private SalidasView SaliView { get { return new SalidasView(); } }
        private HistorialView HistoView { get { return new HistorialView(); } }

        public MainWindowViewModel()
        {


        }

        public ICommand SetArtView
        {
            get { return new ActionCommand((o) => CurrentView = ArtView); } 
        }
        public ICommand SetUsuarioView
        {
            get { return new ActionCommand((o) => CurrentView = UsuarioView); }
        }
        public ICommand SetProvView
        {
            get { return new ActionCommand((o) => CurrentView = ProvView); }
        }
         public ICommand SetEntradaView
        {
            get { return new ActionCommand((o) => CurrentView = EntraView); }
        }
        public ICommand SetSalidaView
        {
            get { return new ActionCommand((o) => CurrentView =SaliView); }
        }
        public ICommand SetHistView
        {
            get { return new ActionCommand((o) => CurrentView = HistoView); }
        }


        private object currentView;
        public object CurrentView
        {
            get
            {
                return currentView;
            }
            set
            {
                currentView = value;
                NotifyPropertyChanged("CurrentView");
            }
        }

        
    }
}
