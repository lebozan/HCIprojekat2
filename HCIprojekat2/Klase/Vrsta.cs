using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIprojekat2.Klase
{
    public class Vrsta
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string _id;
        private string _ime;
        private string _opis;
        private TipVrste _tip;
        private string _statusUgrozenosti;
        private string _ikonica;
        private bool _opasnoZaLjude;
        private bool _iucnLista;
        private bool _naseljeniRegion;
        private string _turistickiStatus;
        private string _godisnjiPrihod;
        private string _datumOtkrivanja;
        private ObservableCollection<Etiketa> _etikete;

        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string Ime
        {
            get
            {
                return _ime;
            }
            set
            {
                if (value != _ime)
                {
                    _ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }

        public string Opis
        {
            get
            {
                return _opis;
            }
            set
            {
                if (value != _opis)
                {
                    _opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }

        public TipVrste Tip
        {
            get
            {
                return _tip;
            }
            set
            {
                if (value != _tip)
                {
                    _tip = value;
                    OnPropertyChanged("Tip");
                }
            }
        }

        public string Statusugrozenosti
        {
            get
            {
                return _statusUgrozenosti;
            }
            set
            {
                if (value != _statusUgrozenosti)
                {
                    _statusUgrozenosti = value;
                    OnPropertyChanged("StatusUgrozenosti");
                }
            }
        }

        public string Ikonica
        {
            get
            {
                return _ikonica;
            }
            set
            {
                if (value != _ikonica)
                {
                    _ikonica = value;
                    OnPropertyChanged("Ikonica");
                }
            }
        }

        public bool OpasnoZaLjude
        {
            get
            {
                return _opasnoZaLjude;
            }
            set
            {
                if (value != _opasnoZaLjude)
                {
                    _opasnoZaLjude = value;
                    OnPropertyChanged("OpasnoZaLjude");
                }
            }
        }

        public bool IUCNLista
        {
            get
            {
                return _iucnLista;
            }
            set
            {
                if (value != _iucnLista)
                {
                    _iucnLista = value;
                    OnPropertyChanged("IUCNLista");
                }
            }
        }

        public bool NaseljeniRegion
        {
            get
            {
                return _naseljeniRegion;
            }
            set
            {
                if (value != _naseljeniRegion)
                {
                    _naseljeniRegion = value;
                    OnPropertyChanged("NaseljeniRegion");
                }
            }
        }

        public string TuristickiStatus
        {
            get
            {
                return _turistickiStatus;
            }
            set
            {
                if (value != _turistickiStatus)
                {
                    _turistickiStatus = value;
                    OnPropertyChanged("TuristickiStatus");
                }
            }
        }

        public string GodisnjiPrihod
        {
            get
            {
                return _godisnjiPrihod;
            }
            set
            {
                if (value != _godisnjiPrihod)
                {
                    _godisnjiPrihod = value;
                    OnPropertyChanged("GodisnjiPrihod");
                }
            }
        }

        public string DatumOtkrivanja
        {
            get
            {
                return _datumOtkrivanja;
            }
            set
            {
                if (value != _datumOtkrivanja)
                {
                    _datumOtkrivanja = value;
                    OnPropertyChanged("DatumOtkrivanja");
                }
            }
        }

        public ObservableCollection<Etiketa> Etikete
        {
            get
            {
                return _etikete;
            }
            set
            {
                if (value != _etikete)
                {
                    _etikete = value;
                    OnPropertyChanged("Etikete");
                }
            }
        }

        public Vrsta()
        {
            Etikete = new ObservableCollection<Etiketa>();
        }

    }
}
