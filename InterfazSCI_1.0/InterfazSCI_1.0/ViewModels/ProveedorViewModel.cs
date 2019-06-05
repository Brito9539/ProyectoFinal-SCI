using SCI.Data;
using SCI.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SCI.DesktopClient.ViewModels
{
    public class ProveedorViewModel : ViewModel
    {
        private readonly BusinessContext context;
        public ICollection<proveedor> Proveedores { get; private set; }
        public proveedor _proveedor = new proveedor();
        private usuario selectedUsuario = new usuario();
        public proveedor Proveedor
        {
            get
            {
                return _proveedor;
            }
            private set
            {
                _proveedor = value;
                NotifyPropertyChanged("Proveedor");
            }
        }

        public usuario SelectedUsuario
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

        public ProveedorViewModel() : this(new BusinessContext())
        {
        }

        public ProveedorViewModel(BusinessContext context)
        {
            this.context = context;
            this.Proveedores = new ObservableCollection<proveedor>();
        }

        public ActionCommand addUsduarioCommand
        {
            get
            {
                return new ActionCommand(p => AddProveedor(Proveedor));
            }
        }

        public ActionCommand GetUsuariosCommand
        {
            get
            {
                return new ActionCommand(p => GetUsuarios());
            }
        }

        public void AddProveedor(proveedor _proveedor)
        {
            using (var api = new BusinessContext())
            {
                try
                {
                    api.AddProveedor(_proveedor);
                }
                catch (Exception ex)
                {
                    return;
                }
                Proveedores.Add(_proveedor);
            }
        }

        public void GetUsuarios()
        {
            Proveedores.Clear();

            foreach (var usuario in context.GetUsuarios())
                Proveedores.Add(Proveedor);
        }
    }
}
