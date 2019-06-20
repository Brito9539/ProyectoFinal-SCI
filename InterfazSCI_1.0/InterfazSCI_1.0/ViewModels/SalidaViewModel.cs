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
    class SalidaViewModel : ViewModel
    {
        public readonly BusinessContext context;
        public ICollection<salida> Salidas { get; private set; }
        public ICollection<string> Productos { get; private set; }
        public ICollection<string> Proveedores { get; private set; }
        public salida _salida = new salida();


        public salida Salida
        {
            get
            {
                return _salida;
            }
            private set
            {
                _salida = value;
                NotifyPropertyChanged("Salida");
            }
        }



        public SalidaViewModel() : this(new BusinessContext())
        {
        }

        public SalidaViewModel(BusinessContext context)
        {
            this.context = context;
            this.Productos = new ObservableCollection<string>();
            this.Proveedores = new ObservableCollection<string>();
            this.Salidas = new ObservableCollection<salida>();
            GetProductosNames();
        }

        public ActionCommand addSalidaCommand
        {
            get
            {
                return new ActionCommand(p => AddSalida(Salida));
            }
        }

        public void AddSalida(salida _salida)
        {
            using (var api = new BusinessContext())
            {
                try
                {
                    api.AddSalida(_salida);
                }
                catch (Exception ex)
                {
                    return;
                }
                Salidas.Add(_salida);
            }
        }

        public void GetProveedoresNames()
        {
            Proveedores.Clear();

            foreach (var proveedor in context.GetProveedores())
                Proveedores.Add(proveedor.Nombre);
        }

        public void GetProductosNames()
        {
            Productos.Clear();

            foreach (var articulo in context.GetProductos())
                Productos.Add(articulo.Nombre);
        }
    }
}
