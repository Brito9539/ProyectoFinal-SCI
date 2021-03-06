﻿using SCI.Data;
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
    public class UsuariosViewModel : ViewModel
    {
        public readonly BusinessContext context;
        public ICollection<usuario> Usuarios { get; private set; }
        public usuario _usuario = new usuario();
        static private usuario selectedUsuario = new usuario();

        public usuario Usuario
        {
            get
            {
                return _usuario;
            }
            private set
            {
                _usuario = value;
                NotifyPropertyChanged("Usuario");
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

        public UsuariosViewModel() : this(new BusinessContext())
        {
        }

        public UsuariosViewModel(BusinessContext context)
        {
            this.context = context;
            this.Usuarios = new ObservableCollection<usuario>();
        }

        public ActionCommand addUsuarioCommand
        {
            get
            {
                return new ActionCommand(p => AddUsuario(Usuario));
            }
        }

        public ActionCommand editUsuarioCommand
        {
            get
            {
                return new ActionCommand(p => UpdateUsuario(SelectedUsuario));
            }
        }

        private void UpdateUsuario(usuario selectedUsuario)
        {
            using (var api = new BusinessContext())
            {
                try
                {
                    api.updateUsuario(selectedUsuario);
                }
                catch (Exception ex)
                {
                    return;
                }
                GetUsuarios();
            }
        }

        public ActionCommand deleteUsuarioCommand
        {
            get
            {
                return new ActionCommand(p => deleteUsuario());
            }
        }

        public ActionCommand GetUsuariosCommand
        {
            get
            {
                return new ActionCommand(p => GetUsuarios());
            }
        }

        public void AddUsuario(usuario _usuario)
        {
            using (var api = new BusinessContext())
            {
                try
                {
                    api.AddUsuario(_usuario);
                }
                catch (Exception ex)
                {
                    return;
                }
                Usuarios.Add(_usuario);
                GetUsuarios();
            }
        }

        private void deleteUsuario()
        {
            using (var api = new BusinessContext())
            {
                try
                {
                    api.deleteUsuario(selectedUsuario);
                }
                catch (Exception ex)
                {
                    return;
                }
                Usuarios.Remove(selectedUsuario);
                GetUsuarios();
            }
        }
        
        public void GetUsuarios()
        {
            Usuarios.Clear();

            foreach (var usuario in context.GetUsuarios())
                Usuarios.Add(usuario);
        }
    }
}
