using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Data
{
    public class BusinessContext : IDisposable
    {
        private sci_bdEntities context;
        private bool disposed;

        public BusinessContext()
        {
            context = new sci_bdEntities();
        }

        public void AddUsuario(usuario usuario)
        {
            Check.Require(usuario.Matricula);
            Check.Require(usuario.Nombre);
            Check.Require(usuario.Apellido_Paterno);
            Check.Require(usuario.Contraseña);
            if (usuario.Admin == null)
                throw new ArgumentNullException();

            context.usuario.Add(usuario);
            context.SaveChanges();
        }

        public void AddProducto(producto producto)
        {
            //TODO: añadir validaciones a campos obligatorios

            context.producto.Add(producto);
            context.SaveChanges();
        }

        public void AddProveedor(proveedor proveedor)
        {
            Check.Require(proveedor.Codigo);
            Check.Require(proveedor.Correo);
            Check.Require(proveedor.Telefono);

            context.proveedor.Add(proveedor);
            context.SaveChanges();
        }

        public ICollection<usuario> GetUsuarios()
        {
            return context.usuario.ToArray();
        }

        public ICollection<proveedor> GetProveedores()
        {
            return context.proveedor.ToArray();
        }

        public ICollection<producto> GetProductos()
        {
            return context.producto.ToArray();
        }

        public void deleteUsuario(usuario selectedUsuario)
        {
            context.usuario.Remove(selectedUsuario);
            context.SaveChanges();
        }

        public void deleteProveedor(proveedor selectedProveedor)
        {
            context.proveedor.Remove(selectedProveedor);
            context.SaveChanges();
        }

        public void deleteProducto(producto selectedProducto)
        {
            context.producto.Remove(selectedProducto);
            context.SaveChanges();
        }

        //patr[on de chequeo para validar si un campo es nulo o esta vacio
        public static class Check
        {
            public static void Require(string value)
            {
                if (value == null)
                    throw new ArgumentNullException();
                if (value.Trim().Length == 0)
                    throw new ArgumentException();
            }
        }

        #region IDisposable code

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposed || !disposing)
                return;

            if (context != null)
                context.Dispose();

            disposed = true;
        }
        #endregion
    }
}
