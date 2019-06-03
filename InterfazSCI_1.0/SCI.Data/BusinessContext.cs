using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Data
{
    public class BusinessContext : IDisposable
    {
        private readonly sci_bdEntities context;
        private bool disposed;

        public BusinessContext()
        {
            context = new sci_bdEntities();
        }

        public void AddUsuario(Usuario usuario)
        {
            //TODO: añadir validaciones a campos obligatorios
            Check.Require(usuario.Matricula);
            Check.Require(usuario.Nombre);
            Check.Require(usuario.Apellido_Paterno);
            Check.Require(usuario.Contraseña);
            if (usuario.Admin == null)
                throw new ArgumentNullException();

            context.Usuario.Add(usuario);
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
