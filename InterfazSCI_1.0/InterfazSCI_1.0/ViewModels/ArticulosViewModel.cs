using SCI.Data;
using SCI.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.DesktopClient.ViewModels
{
    class ArticulosViewModel : ViewModel
    {
        private readonly BusinessContext context;
        public ICollection<producto> Usuarios { get; private set; }
        public producto _usuario = new producto();
        private producto selectedUsuario = new producto();
        public producto Usuario
        {
            get
            {
                return _usuario;
            }
            private set
            {
                _usuario = value;
                NotifyPropertyChanged("Articulo");
            }
        }

        public producto SelectedUsuario
        {
            get
            {
                return selectedUsuario;
            }
            set
            {
                selectedUsuario = value;
                NotifyPropertyChanged("SelectedUsuario");
            }
        }

        public ArticulosViewModel() : this(new BusinessContext())
        {
        }

        public ArticulosViewModel(BusinessContext context)
        {
            this.context = context;
            this.Usuarios = new ObservableCollection<producto>();
        }

        public ActionCommand addProducto
        {
            get
            {
                return new ActionCommand(p => AddProducto(Usuario));
            }
        }

        public ActionCommand GetProductosCommand
        {
            get
            {
                return new ActionCommand(p => GetProductos());
            }
        }

        public void AddProducto(producto _usuario)
        {
            using (var api = new BusinessContext())
            {
                try
                {
                    api.AddProducto(_usuario);
                }
                catch (Exception ex)
                {
                    return;
                }
                Usuarios.Add(_usuario);
            }
        }

        public void GetProductos()
        {
            Usuarios.Clear();

            foreach (var usuario in context.GetProductos())
                Usuarios.Add(usuario);
        }

    }
}
