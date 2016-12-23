using ch.hsr.wpf.gadgeothek.service;
using GalaSoft.MvvmLight.Command;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ch.hsr.wpf.gadgeothek.manager.viewModel 
{
    

    public class AdminWindowViewModel
    {
        public GadgetViewModel GadgetViewModel { get; }
        public LoanViewModel LoanViewModel { get; private set; }
        public ServiceHandler ServiceHandler { get; private set; }        

        public AdminWindowViewModel(GadgetViewModel GadgetViewModel, LoanViewModel LoanViewModel, ServiceHandler ServiceHandler)
        {
            this.GadgetViewModel = GadgetViewModel;
            this.LoanViewModel = LoanViewModel;
            this.ServiceHandler = ServiceHandler;
        }
    }
}
