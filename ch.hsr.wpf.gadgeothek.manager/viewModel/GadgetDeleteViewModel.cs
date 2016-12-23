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
using ch.hsr.wpf.gadgeothek.manager.view;

namespace ch.hsr.wpf.gadgeothek.manager.viewModel
{
    public class GadgetDeleteViewModel
    {
        public ICommand DeleteCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        
        public GadgetDeleteViewModel()
        {
            Debug.WriteLine("GadgetDeleteViewModel| Constructor");
            DeleteCommand = new RelayCommand(this.Delete);
            CancelCommand = new RelayCommand(this.Cancel);
            
        }

        private void Delete()
        {
            Debug.WriteLine("GadgetDeleteViewModel| Delete:");
            Messenger.Default.Send(new NotificationMessage("Delete_Gadget_Ok"));
        }

        private void Cancel()
        {
            Debug.WriteLine("GadgetDeleteViewModel| Cancel");
            Messenger.Default.Send(new NotificationMessage("Delete_Gadget_Cancel"));
        }
    }
}
