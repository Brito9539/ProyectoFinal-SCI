using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.DesktopClient.ViewModels
{
    class MainViewModel
    {
        ObservableCollection<object> _children;
        public MainViewModel()
        {
            //_children = new ObservableCollection<object>();
            UsuariosViewModel usuariovm = new UsuariosViewModel();
            ProveedorViewModel proveedorvm = new ProveedorViewModel();
            //_children.Add(new ProveedorViewModel());
        }

        public ObservableCollection<object> Children { get { return _children; } }
    }
}
