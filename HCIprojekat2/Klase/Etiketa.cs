using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIprojekat2.Klase
{
    public class Etiketa
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string _idEtikete;
        private string _bojaEtikete;
        private string _opisEtikete;

        public string IdEtikete
        {
            get
            {
                return _idEtikete;
            }
            set
            {
                if (value != _idEtikete)
                {
                    _idEtikete = value;
                    OnPropertyChanged("IdEtikete");
                }
            }
        }

        public string BojaEtikete
        {
            get
            {
                return _bojaEtikete;
            }
            set
            {
                if (value != _bojaEtikete)
                {
                    _bojaEtikete = value;
                    OnPropertyChanged("BojaEtikete");
                }
            }
        }

        public string OpisEtikete
        {
            get
            {
                return _opisEtikete;
            }
            set
            {
                if (value != _opisEtikete)
                {
                    _opisEtikete = value;
                    OnPropertyChanged("OpisEtikete");
                }
            }
        }

        public Etiketa()
        {

        }

    }
}
