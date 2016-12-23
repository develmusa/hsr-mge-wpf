using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.manager.model;
using ch.hsr.wpf.gadgeothek.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch.hsr.wpf.gadgeothek.manager.viewModel
{
    public class LoanViewModel :INotifyPropertyChanged
    {
        private LoanModel LoanModel;
        private List<Loan> _loans;
        public List<Loan> LoansList
        {
            get
            {
                return _loans;
            }
            set
            {
                _loans = value;
                NotifyPropertyChanged("LoansList");
            }
        }
        public ServiceHandler serviceHandler;

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public LoanViewModel(LoanModel LoanModel, ServiceHandler serviceHandler)
        {
            this.LoanModel = LoanModel;
            this.serviceHandler = serviceHandler;
            LoanModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Loan_PropertyChanged);

        }

        public void Update()
        {
            LoansList = LoanModel.Loans;
        }

        private void Loan_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Update();
        }
    }
}
