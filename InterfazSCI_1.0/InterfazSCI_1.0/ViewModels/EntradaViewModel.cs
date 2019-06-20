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
    public class EntradaViewModel : ViewModel
    {
        private readonly BusinessContext context;
        public ICollection<entrada> Entradas { get; private set; }
        public ICollection<string> Productos { get; private set; }
        public ICollection<string> Proveedores { get; private set; }
        public entrada _entrada = new entrada();
        

        public entrada Entrada
        {
            get
            {
                return _entrada;
            }
            private set
            {
                _entrada = value;
                NotifyPropertyChanged("Entrada");
            }
        }



        public EntradaViewModel() : this(new BusinessContext())
        {
        }

        public EntradaViewModel(BusinessContext context)
        {
            this.context = context;
            this.Productos = new ObservableCollection<string>();
            this.Proveedores = new ObservableCollection<string>();
            this.Entradas = new ObservableCollection<entrada>();
            GetProductosNames();
        }

        public ActionCommand addEntradaCommand
        {
            get
            {
                return new ActionCommand(p => AddEntrada(Entrada));
            }
        }

        public void AddEntrada(entrada _entrada)
        {
            using (var api = new BusinessContext())
            {
                try
                {
                    api.AddEntrada(_entrada);
                }
                catch (Exception ex)
                {
                    return;
                }
                Entradas.Add(_entrada);
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
