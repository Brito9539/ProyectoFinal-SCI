using SCI.Data;
using SCI.Windows;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SCI.DesktopClient
{
    public class UsuariosViewModel : ViewModel
    {
        public ICollection<Usuario> Usuarios { get; private set; }
        public Usuario usuario = new Usuario();

        public UsuariosViewModel()
        {
                
        }

        public ActionCommand addUsduarioCommand
        {
            get
            {
                return new ActionCommand(p => AddUsuario(usuario));
            }
        }

        public void AddUsuario(Usuario _usuario)
        {
            using (var api = new BusinessContext())
            {
                try
                {
                    api.AddUsuario(_usuario);
                }
                catch(Exception ex)
                {
                    return;
                }
                Usuarios.Add(_usuario);
            }
        }
    }
}
