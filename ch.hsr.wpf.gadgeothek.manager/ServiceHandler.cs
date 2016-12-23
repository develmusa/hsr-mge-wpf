using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ch.hsr.wpf.gadgeothek.manager.model;
using ch.hsr.wpf.gadgeothek.service;
using System.Diagnostics;
using ch.hsr.wpf.gadgeothek.domain;

namespace ch.hsr.wpf.gadgeothek.manager
{
    public class ServiceHandler
    {
        public static ServiceHandler Instance { get; set; }

        private GadgetModel GadgetModel;
        private LoanModel LoanModel;
        private LibraryAdminService libraryAdminService;

        public string ServerUrl { get; set; }

        public ServiceHandler(string serverUrl, GadgetModel gadgetModel, LoanModel loanModel)
        {
            GadgetModel = gadgetModel;
            LoanModel = loanModel;
            ServerUrl = serverUrl;
            libraryAdminService = new LibraryAdminService(ServerUrl);
            Instance = this;
        }

        public void RefreshAll()
        {
            RefreshGadgets();
            RefreshLoans();            
        }

        public void RefreshGadgets()
        {
            Debug.WriteLine("ServiceHandler| RefreshAllGadgets");
            var gadgets = libraryAdminService.GetAllGadgets();
            GadgetModel.Gadgets = gadgets;
        }

        public void RefreshLoans()
        {
            Debug.WriteLine("ServiceHandler| GetAllLoans");
            var loans = libraryAdminService.GetAllLoans();
            LoanModel.Loans = loans;
        }

        internal void DeleteGadget(Gadget selectedGadget)
        {
            Debug.WriteLine("ServiceHandler| DeleteGadget:  " + selectedGadget);
            if (libraryAdminService.DeleteGadget(selectedGadget))            
                Debug.WriteLine("ServiceHandler| Gadget Deleted");            
            else
                Debug.WriteLine("ServiceHandler| Deletion Failed");            
        }

        public void AddGadget(Gadget gadget)
        {
            
            if (libraryAdminService.AddGadget(gadget))
                Debug.WriteLine("ServiceHandler| Gadget Added");
            else
                Debug.WriteLine("ServiceHandler| Adding Failed");

        }
    }
}
