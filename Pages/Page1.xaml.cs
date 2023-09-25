using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace WpfAppToolBar.Pages
{
    public partial class Page1 : Page
    {
        //Erzeuge Bauteil-Liste
        List<Bauteil> bauteileListe = new List<Bauteil>();

        //Erzeuge Ja-Nein-Liste
        List<JaNein> verzinkenListe = new List<JaNein>();

        public Page1()
        {
            InitializeComponent();
            DataContext = new ViewModel();

            Verzinken.ItemsSource = verzinkenListe;

            verzinkenListe.Add(new JaNein("Ja"));
            verzinkenListe.Add(new JaNein("Nein"));

            //Verbinde ItemsControl mit der Liste! 
            Bauteilart.ItemsSource = bauteileListe;

            //Befülle Liste mit Objekten 
            bauteileListe.Add(new Bauteil("Hauptträger"));
            bauteileListe.Add(new Bauteil("Nebenträger"));
            bauteileListe.Add(new Bauteil("Stützen"));
            bauteileListe.Add(new Bauteil("Fachwerk"));
        }

        private void ReturnToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            // Zurück zum MainWindow navigieren
            ((MainWindow)Application.Current.MainWindow).NavigateToMainWindow();
        }

        private void Bauteilart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Bauteil item = Bauteilart.SelectedItem as Bauteil;
            XYLänge.Content = item.Name + "länge [m]:";
            XYBreite.Content = item.Name + "breite [m]:";
            XYHöhe.Content = item.Name + "höhe [m]:";
        }

        private void Berechnen_Click(object sender, RoutedEventArgs e)
        {
            bool alleBedingungenErfuellt = true; 

            if (string.IsNullOrEmpty(Gewicht.Text))
            {
                MessageBox.Show("Bitte geben Sie das Laufmetergewicht ein.");
                alleBedingungenErfuellt = false; // Eine Bedingung wurde nicht erfüllt
            }
            else if (double.TryParse(Gewicht.Text, out double gewichtWert))
            {
                if (gewichtWert > 500)
                {
                    MessageBox.Show("Das eingegebene Laufmetergewicht übersteigt die Kapazitäten der Produktion. Die Obergrenze liegt bei 500 kg/m.");
                    alleBedingungenErfuellt = false; // Eine Bedingung wurde nicht erfüllt
                }
            }
            else
            {
                MessageBox.Show("Bitte geben Sie eine gültige Zahl für das Laufmetergewicht ein.");
                alleBedingungenErfuellt = false; // Eine Bedingung wurde nicht erfüllt
            }

            if (string.IsNullOrEmpty(Bauteillänge.Text))
            {
                MessageBox.Show("Bitte geben Sie die Bauteillänge ein.");
                alleBedingungenErfuellt = false; // Eine Bedingung wurde nicht erfüllt
            }
            else if (double.TryParse(Bauteillänge.Text, out double bauteilLänge) && bauteilLänge <= 1)
            {
                MessageBox.Show("Bitte geben Sie eine gültige Zahl größer als 1 für die Bauteillänge an.");
                alleBedingungenErfuellt = false; // Eine Bedingung wurde nicht erfüllt
            }

            if (string.IsNullOrEmpty(Bauteilbreite.Text))
            {
                MessageBox.Show("Bitte geben Sie die Bauteilbreite ein.");
                alleBedingungenErfuellt = false; // Eine Bedingung wurde nicht erfüllt
            }
            else if (double.TryParse(Bauteilbreite.Text, out double bauteilBreite) && bauteilBreite <= 0.1)
            {
                MessageBox.Show("Bitte geben Sie eine gültige Zahl größer als 0,1 für die Bauteilbreite an.");
                alleBedingungenErfuellt = false; // Eine Bedingung wurde nicht erfüllt
            }

            if (string.IsNullOrEmpty(Bauteilhöhe.Text))
            {
                MessageBox.Show("Bitte geben Sie die Bauteilhöhe ein.");
                alleBedingungenErfuellt = false; // Eine Bedingung wurde nicht erfüllt
            }
            else if (double.TryParse(Bauteilhöhe.Text, out double bauteilHöhe) && bauteilHöhe <= 0.1)
            {
                MessageBox.Show("Bitte geben Sie eine gültige Zahl größer als 0,1 für die Bauteilhöhe an.");
                alleBedingungenErfuellt = false; // Eine Bedingung wurde nicht erfüllt
            }

            if (alleBedingungenErfuellt)
            {
                string message = "Eingaben erfolgreich. Siehe Berechnung auf Seite 2";
                txtBox_berechnen.Text = message;
            }
        }


    }
    public class Bauteil
    {
        public string Name { get; set; }

        public Bauteil(string _name)
        {
            Name = _name;
        }
    }

    public class JaNein
    {
        public string No { get; set; }

        public JaNein(string _yes)
        {
            No = _yes;
        }
    }

}
