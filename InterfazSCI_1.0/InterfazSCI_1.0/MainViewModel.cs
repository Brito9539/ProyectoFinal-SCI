using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazSCI_1._0
{
    class MainViewModel
    {
        ObservableCollection<object> _children;
        public MainViewModel()
        {
            _children = new ObservableCollection<object>();
            _children.Add(new EntradaViewModel());
        }

        public ObservableCollection<object> Children { get { return _children; } }
    }
}
