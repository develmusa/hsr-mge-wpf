using ch.hsr.wpf.gadgeothek.domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch.hsr.wpf.gadgeothek.manager.model
{
    public class GadgetModel
    {
        private List<Gadget> _gadgets;
        public List<Gadget> Gadgets
        {
            get { return _gadgets; }
            set { _gadgets = value; Debug.WriteLine("AllGadgets set"); }
        }


    }
}
