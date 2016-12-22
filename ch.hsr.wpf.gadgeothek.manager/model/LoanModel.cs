using ch.hsr.wpf.gadgeothek.domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch.hsr.wpf.gadgeothek.manager.model
{
    public class LoanModel
    {
        private List<Loan> _loans;
        public List<Loan> Loans
        {
            get { return _loans; }
            set { _loans = value; Debug.WriteLine("AllLoans set"); }
        }

    }
}
