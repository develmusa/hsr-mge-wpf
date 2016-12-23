using ch.hsr.wpf.gadgeothek.domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch.hsr.wpf.gadgeothek.manager.model
{
    public class GadgetModel : INotifyPropertyChanged
    {private List<Gadget> _gadgets;
        
        public List<Gadget> Gadgets
        {
            get { return _gadgets; }
            set
            {
                _gadgets = value;
                OnPropertyChanged(nameof(Gadgets));
                Debug.WriteLine("AllGadgets set");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }
    }
}
