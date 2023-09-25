using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WpfAppToolBar
{
    public class ViewModel : INotifyPropertyChanged
    {
        private double _bauteilLänge;
        public double Bauteillänge

        {
            get { return _bauteilLänge; }
            set
            {
                if (_bauteilLänge != value)
                {
                    _bauteilLänge = value;
                    OnPropertyChanged(nameof(Bauteillänge));
                    UpdateErgebnis();
                }
            }
        }

        private string _ergebnis;
        public string Ergebnis
        {
            get { return _ergebnis; }
            set
            {
                if (_ergebnis != value)
                {
                    _ergebnis = value;
                    OnPropertyChanged(nameof(Ergebnis));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateErgebnis()
        {
            if (Bauteillänge >= 14)
            {
                Ergebnis = "Bauteil zu lang";
            }
            else
            {
                Ergebnis = "Bauteil in Ordnung";
            }
        }
    }

}

