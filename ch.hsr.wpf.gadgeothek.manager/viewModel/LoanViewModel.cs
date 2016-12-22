using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.manager.model;
using ch.hsr.wpf.gadgeothek.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch.hsr.wpf.gadgeothek.manager.viewModel
{
    public class LoanViewModel
    {
        private LoanModel LoanModel;
        public List<Loan> LoansList { get; set; }
        public ServiceHandler serviceHandler;

        public LoanViewModel(LoanModel LoanModel, ServiceHandler serviceHandler)
        {
            this.LoanModel = LoanModel;
            this.serviceHandler = serviceHandler;

        }

        public void Update()
        {
            LoansList = LoanModel.Loans;
        }
    }
}
