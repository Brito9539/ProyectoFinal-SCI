﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Data
{
    public class BusinessContext : IDisposable
    {
        public sci_bdEntities context;
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

        public void updateUsuario(usuario usuario)
        {
            var objeto = context.usuario.Find(usuario.Matricula);

            Check.Require(usuario.Matricula);
            Check.Require(usuario.Nombre);
            Check.Require(usuario.Apellido_Paterno);
            Check.Require(usuario.Contraseña);
            if (usuario.Admin == null)
                throw new ArgumentNullException();

            context.Entry(objeto).CurrentValues.SetValues(usuario);
            context.SaveChanges();
        }

        public void updateProducto(producto producto)
        {
            var objeto = context.producto.Find(producto.idProducto);

            Check.Require(producto.idProducto);
            Check.Require(producto.Nombre);
            Check.Require(producto.Unidad);
            Check.Require(producto.PuntoReorden.ToString());

            context.Entry(objeto).CurrentValues.SetValues(producto);
            context.SaveChanges();
        }

        public void updateProveedor(proveedor proveedor)
        {
            var objeto = context.proveedor.Find(proveedor.Codigo);

            Check.Require(proveedor.Codigo);
            Check.Require(proveedor.Nombre);

            context.Entry(objeto).CurrentValues.SetValues(proveedor);
            context.SaveChanges();
        }

        public void updateUbicacion(ubicacion ubicacion)
        {
            var objeto = context.ubicacion.Find(ubicacion.idUbicacion);

            Check.Require(ubicacion.Colonia);

            context.Entry(objeto).CurrentValues.SetValues(ubicacion);
            context.SaveChanges();
        }

        public void AddProducto(producto producto)
        {
            //TODO: añadir validaciones a campos obligatorios
            Check.Require(producto.idProducto);
            Check.Require(producto.Nombre);
            Check.Require(producto.Unidad);
            Check.Require(producto.PuntoReorden.ToString());

            context.producto.Add(producto);
            context.SaveChanges();
        }

        public void AddProveedor(proveedor proveedor)
        {
            Check.Require(proveedor.Codigo);
            Check.Require(proveedor.Nombre);
          
            context.proveedor.Add(proveedor);
            context.SaveChanges();
        }

        public void AddUbicacion(ubicacion ubicacion)
        {
            Check.Require(ubicacion.Colonia);

            context.ubicacion.Add(ubicacion);
            
            context.SaveChanges();
        }

        public void AddEntrada(entrada entrada)
        {
            context.entrada.Add(entrada);
            context.SaveChanges();
        }

        public void AddSalida(salida salida)
        {
            context.salida.Add(salida);
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

        public ICollection<ubicacion> GetUbicaciones()
        {
            return context.ubicacion.ToArray();
        }

        public void deleteUsuario(usuario selectedUsuario)
        {
            usuario _usuario = context.usuario.Where(u => u.Matricula == selectedUsuario.Matricula).FirstOrDefault();
            context.usuario.Remove(_usuario);
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

        public void deleteUbicacion(ubicacion selectedUbicacion)
        {
            context.ubicacion.Remove(selectedUbicacion);
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
