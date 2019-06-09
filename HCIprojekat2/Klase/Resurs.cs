using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIprojekat2.Klase
{
    public enum Frekvencija
    {
        Redak,
        Cest,
        Univerzalan
    }

    public enum JedinicaMere
    {
        Merica,
        Barel,
        Tona,
        Kilogram
    }

    public class Resurs
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
        private Frekvencija _frekvencijaPojavljivanja;
        private string _ikonica;
        private bool _obnovljiv;
        private bool _strVaznost;
        private bool _eksploatisanje;
        private JedinicaMere _jedinica;
        private double _cena;
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

        public Frekvencija Frekvencija
        {
            get
            {
                return _frekvencijaPojavljivanja;
            }
            set
            {
                if (value != _frekvencijaPojavljivanja)
                {
                    _frekvencijaPojavljivanja = value;
                    OnPropertyChanged("Tip");
                }
            }
        }

        public JedinicaMere JedMere
        {
            get
            {
                return _jedinica;
            }
            set
            {
                if (value != _jedinica)
                {
                    _jedinica = value;
                    OnPropertyChanged("Tip");
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

        public bool Obnovljiv
        {
            get
            {
                return _obnovljiv;
            }
            set
            {
                if (value != _obnovljiv)
                {
                    _obnovljiv = value;
                    OnPropertyChanged("NaseljeniRegion");
                }
            }
        }

        public bool StrVaznost
        {
            get
            {
                return _strVaznost;
            }
            set
            {
                if (value != _strVaznost)
                {
                    _strVaznost = value;
                    OnPropertyChanged("NaseljeniRegion");
                }
            }
        }

        public bool Eksploatisanje
        {
            get
            {
                return _eksploatisanje;
            }
            set
            {
                if (value != _eksploatisanje)
                {
                    _eksploatisanje = value;
                    OnPropertyChanged("NaseljeniRegion");
                }
            }
        }

        public double Cena
        {
            get
            {
                return _cena;
            }
            set
            {
                if (value != _cena)
                {
                    _cena = value;
                    OnPropertyChanged("NaseljeniRegion");
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

        public Resurs()
        {
            Etikete = new ObservableCollection<Etiketa>();
        }
    }
}
