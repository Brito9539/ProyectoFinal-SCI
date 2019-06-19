using SCI.Data;
using SCI.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.DesktopClient.ViewModels
{
    public class UbicacionViewModel: ViewModel
    {
        private readonly BusinessContext context;
        public ICollection<ubicacion> Ubicaciones { get; private set; }
        public ubicacion _ubicacion = new ubicacion();
        static private ubicacion selectedUbicacion = new ubicacion();
        public ubicacion Ubicacion
        {
            get
            {
                return _ubicacion;
            }
            private set
            {
                _ubicacion = value;
                NotifyPropertyChanged("Ubicacion");
            }
        }

        public ubicacion SelectedUbicacion
        {
            get
            {
                return selectedUbicacion;
            }
            set
            {
                selectedUbicacion = value;
                NotifyPropertyChanged("SelectedUbicacion");
            }
        }

        public UbicacionViewModel() : this(new BusinessContext())
        {
        }

        public UbicacionViewModel(BusinessContext context)
        {
            this.context = context;
            this.Ubicaciones = new ObservableCollection<ubicacion>();
        }

        public ActionCommand addUbicacionCommand
        {
            get
            {
                return new ActionCommand(p => AddUbicacion(Ubicacion));
            }
        }

        public ActionCommand editUbicacionCommand
        {
            get
            {
                return new ActionCommand(p => UpdateUbicacion(SelectedUbicacion));
            }
        }

        private void UpdateUbicacion(ubicacion selectedUbicacion)
        {
            using (var api = new BusinessContext())
            {
                try
                {
                    api.updateUbicacion(selectedUbicacion);
                }
                catch (Exception ex)
                {
                    return;
                }
                GetUbicaciones();
            }
        }

        public ActionCommand deleteUbicacionCommand
        {
            get
            {
                return new ActionCommand(p => deleteUbicacion());
            }
        }

        public ActionCommand GetUbicacionesCommand
        {
            get
            {
                return new ActionCommand(p => GetUbicaciones());
            }
        }

        public void AddUbicacion(ubicacion _ubicacion)
        {
            using (var api = new BusinessContext())
            {
                try
                {
                    api.AddUbicacion(_ubicacion);
                }
                catch (Exception ex)
                {
                    return;
                }
                Ubicaciones.Add(_ubicacion);
                GetUbicaciones();
            }
        }

        private void deleteUbicacion()
        {
            using (var api = new BusinessContext())
            {
                try
                {
                    api.deleteUbicacion(selectedUbicacion);
                }
                catch (Exception ex)
                {
                    return;
                }
                Ubicaciones.Remove(selectedUbicacion);
                GetUbicaciones();
            }
        }

        public void GetUbicaciones()
        {
            Ubicaciones.Clear();

            foreach (var ubicacion in context.GetUbicaciones())
                Ubicaciones.Add(ubicacion);
        }

    }
}
