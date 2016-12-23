using ch.hsr.wpf.gadgeothek.domain;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ch.hsr.wpf.gadgeothek.manager.viewModel
{
    class GadgetAddViewModel
    {
        public ICommand AddCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public Gadget gadget;
        public string InventoryNumber{ get; set; }
        public int Price { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        ServiceHandler serviceHandler;

        public GadgetAddViewModel()
        {
            Debug.WriteLine("GadgetAddViewModel| Constructor");
            AddCommand = new RelayCommand(this.Add);
            CancelCommand = new RelayCommand(this.Cancel);
            serviceHandler = ServiceHandler.Instance;
        }

        private void Add()
        {
            Debug.WriteLine("GadgetAddViewModel| Add:" + InventoryNumber + "    " + Price + "   " + Manufacturer +"     " + Name);
            var gadget = new Gadget(Name) { Manufacturer = Manufacturer, Price = Price, InventoryNumber = InventoryNumber };
            serviceHandler.AddGadget(gadget);
            Messenger.Default.Send(new NotificationMessage("Add_Gadget_Ok"));
        }

        private void Cancel()
        {
            Debug.WriteLine("GadgetAddViewModel| Cancel");
            Messenger.Default.Send(new NotificationMessage("Add_Gadget_Cancel"));
        }
    }
}
