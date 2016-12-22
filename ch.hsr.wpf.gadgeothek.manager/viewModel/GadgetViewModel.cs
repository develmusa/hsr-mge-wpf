using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.manager.model;
using ch.hsr.wpf.gadgeothek.service;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ch.hsr.wpf.gadgeothek.manager.viewModel
{
    public class GadgetViewModel
    {
        private GadgetModel GadgetModel;
        public List<Gadget> GadgetsList { get; set; }
        public ServiceHandler serviceHandler;
        public ICommand DeleteGadgetCommand { get; set; }
        public Gadget SelectedGadget { get; set; }

        public GadgetViewModel(GadgetModel GadgetModel, ServiceHandler serviceHandler)
        {            
            this.GadgetModel = GadgetModel;
            this.serviceHandler = serviceHandler;
            DeleteGadgetCommand = new RelayCommand(this.DeleteGadget);

        }

        private void DeleteGadget()
        {
            Debug.WriteLine("Delete:    " + SelectedGadget + "    Type:   " + SelectedGadget.GetType());
            serviceHandler.DeleteGadget(SelectedGadget);


        }

        public void Update()
        {
                        GadgetsList = GadgetModel.Gadgets;
        }
    }
}
