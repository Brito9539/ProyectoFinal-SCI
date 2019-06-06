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
        private proveedor selectedProveedor = new proveedor();
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

        public proveedor SelectedProveedor
        {
            get
            {
                return selectedProveedor;
            }
            set
            {
                selectedProveedor = value;
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

        public ActionCommand addProveedorCommand
        {
            get
            {
                return new ActionCommand(p => AddProveedor(Proveedor));
            }
        }

        public ActionCommand editProveedorCommand
        {
            get
            {
                return new ActionCommand(p => AddProveedor(SelectedProveedor));
            }
        }

        public ActionCommand GetProveedoresCommand
        {
            get
            {
                return new ActionCommand(p => GetProveedores());
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

        public void DeleteProveedor(proveedor _proveedor)
        {

            using (var api = new BusinessContext())
            {
                try
                {
                    api.deleteProveedor(_proveedor);
                }
                catch (Exception ex)
                {
                    return;
                }
                GetProveedores();
            }
        }

        public void GetProveedores()
        {
            Proveedores.Clear();

            foreach (var usuario in context.GetProveedores())
                Proveedores.Add(Proveedor);
        }
    }
}
