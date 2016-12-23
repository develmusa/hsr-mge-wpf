using ch.hsr.wpf.gadgeothek.manager.model;
using ch.hsr.wpf.gadgeothek.manager.view;
using ch.hsr.wpf.gadgeothek.manager.viewModel;
using ch.hsr.wpf.gadgeothek.service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch.hsr.wpf.gadgeothek.manager
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {     
            var ServerUrl = "http://mge1.dev.ifs.hsr.ch";

            GadgetModel gadgetModel = new GadgetModel();
            LoanModel loanModel = new LoanModel();

            ServiceHandler serviceHandler = new ServiceHandler(ServerUrl, gadgetModel, loanModel);

            GadgetViewModel gadgetViewModel = new GadgetViewModel(gadgetModel, serviceHandler);
            LoanViewModel loanViewModel = new LoanViewModel(loanModel, serviceHandler);
          
            AdminWindowViewModel adminWindowViewModel = new AdminWindowViewModel(gadgetViewModel, loanViewModel, serviceHandler);
            
            AdminWindow mW = new AdminWindow(adminWindowViewModel);

            serviceHandler.RefreshAll();
            gadgetViewModel.Update();
            loanViewModel.Update();
            mW.ShowDialog();
           
            

        }
    }
}
