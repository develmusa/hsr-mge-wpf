using ch.hsr.wpf.gadgeothek.domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch.hsr.wpf.gadgeothek.manager.model
{
    public class LoanModel :INotifyPropertyChanged
    {
        private List<Loan> _loans;
        public List<Loan> Loans
        {
            get
            {
                return _loans;
            }
            set
            {
                _loans = value;
                OnPropertyChanged(nameof(Loans));
                Debug.WriteLine("AllLoans set");
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
