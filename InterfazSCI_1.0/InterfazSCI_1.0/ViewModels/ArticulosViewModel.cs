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
    public class ArticulosViewModel : ViewModel
    {
        public readonly BusinessContext context;
        public ICollection<producto> Productos { get; private set; }
        public producto _producto = new producto();
        static private producto selectedProducto = new producto();

        public producto Producto
        {
            get
            {
                return _producto;
            }
            private set
            {
                _producto = value;
                NotifyPropertyChanged("Producto");
            }
        }

        public producto SelectedProducto
        {
            get
            {
                return selectedProducto;
            }
            set
            {
                selectedProducto = value;
                NotifyPropertyChanged("SelectedProducto");
            }
        }

        public ArticulosViewModel() : this(new BusinessContext())
        {
        }

        public ArticulosViewModel(BusinessContext context)
        {
            this.context = context;
            this.Productos = new ObservableCollection<producto>();
        }

        public ActionCommand addProductoCommand
        {
            get
            {
                return new ActionCommand(p => AddProducto(Producto));
            }
        }

        public ActionCommand GetProductosCommand
        {
            get
            {
                return new ActionCommand(p => GetProductos());
            }
        }

        public ActionCommand deleteProductoCommand
        {
            get
            {
                return new ActionCommand(p => deleteProducto());
            }
        }

        public ActionCommand editProductoCommand
        {
            get
            {
                return new ActionCommand(p => UpdateProducto(selectedProducto));
            }
        }

        private void UpdateProducto(producto SelectedProducto)
        {
            using (var api = new BusinessContext())
            {
                try
                {
                    api.updateProducto(SelectedProducto);
                }
                catch (Exception ex)
                {
                    return;
                }
                GetProductos();
            }
        }

        public void AddProducto(producto _producto)
        {
            using (var api = new BusinessContext())
            {
                try
                {
                    api.AddProducto(_producto);
                }
                catch (Exception ex)
                {
                    return;
                }
                Productos.Add(_producto);
            }
        }

        public void deleteProducto()
        {

            using (var api = new BusinessContext())
            {
                try
                {
                    api.deleteProducto(selectedProducto);
                }
                catch (Exception ex)
                {
                    return;
                }
                Productos.Remove(selectedProducto);
                GetProductos();
            }
        }

        public void GetProductos()
        {
            Productos.Clear();

            foreach (var articulo in context.GetProductos())
                Productos.Add(articulo);
        }

    }
}
