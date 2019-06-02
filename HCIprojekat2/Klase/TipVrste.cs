using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIprojekat2.Klase
{
    public class TipVrste
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string _idTipa;
        private string _imeTipa;
        private string _ikonicaTipa;
        private string _opisTipa;

        public string IdTipa
        {
            get
            {
                return _idTipa;
            }
            set
            {
                if (value != _idTipa)
                {
                    _idTipa = value;
                    OnPropertyChanged("IdTipa");
                }
            }
        }

        public string ImeTipa
        {
            get
            {
                return _imeTipa;
            }
            set
            {
                if (value != _imeTipa)
                {
                    _imeTipa = value;
                    OnPropertyChanged("ImeTipa");
                }
            }
        }

        public string IkonicaTipa
        {
            get
            {
                return _ikonicaTipa;
            }
            set
            {
                if (value != _ikonicaTipa)
                {
                    _ikonicaTipa = value;
                    OnPropertyChanged("IkonicaTipa");
                }
            }
        }

        public string OpisTipa
        {
            get
            {
                return _opisTipa;
            }
            set
            {
                if (value != _opisTipa)
                {
                    _opisTipa = value;
                    OnPropertyChanged("OpisTipa");
                }
            }
        }

        public TipVrste()
        {

        }
    }
}
