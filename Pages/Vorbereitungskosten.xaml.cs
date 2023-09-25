using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;



namespace WpfAppToolBar.Pages
{
 
    public partial class Vorbereitungskosten : Page
    {

            public string ErgebnisLabelContent  
        {
        get { return (string)GetValue(ErgebnisLabelContentProperty); }
        set { SetValue(ErgebnisLabelContentProperty, value); }
        }

        public static readonly DependencyProperty ErgebnisLabelContentProperty =
        DependencyProperty.Register("ErgebnisLabelContent", typeof(string), typeof(Vorbereitungskosten), new PropertyMetadata(""));

            
        public Vorbereitungskosten() 
        {
            InitializeComponent();
            ViewModel viewModel = new ViewModel(); // Erstellen Sie eine neue ViewModel-Instanz
            string ergebnis = viewModel.Ergebnis; // Hier ist das Ergebnis der if-Bedingung

            ErgebnisLabelContent = ergebnis; // Setze den Wert der Abhängigkeitseigenschaft
                                              
                          
            DataContext = new ViewModel();
                      
        }

        private void Stoßart_Selected(object sender, RoutedEventArgs e)
        {

            Debug.WriteLine("Stoßart_Selected wurde aufgerufen.");


            ComboBoxItem selectedItem = (ComboBoxItem)Stoßart.SelectedItem;

            // Standardmäßig alle Bilder ausblenden
            Stirnplattenstoß.Visibility = Visibility.Collapsed;
            Laschenstoß.Visibility = Visibility.Collapsed;
            Flanschwinkelanschluss.Visibility = Visibility.Collapsed;

            if (selectedItem != null)
            {
                string selectedStoßart = selectedItem.Content.ToString();

                switch (selectedStoßart)
                {
                    case "Stirnplattenstoß":
                        string imagePath1 = "Bilder/Stoß/Stirnplattenstoß.png";
                        BitmapImage imageSource1 = new BitmapImage(new Uri(imagePath1, UriKind.Relative));
                        Stirnplattenstoß.Source = imageSource1;
                        Stirnplattenstoß.Visibility = Visibility.Visible;
                        break;

                    case "Laschenstoß":
                        string imagePath2 = "Bilder/Stoß/Laschenstoß.png";
                        BitmapImage imageSource2 = new BitmapImage(new Uri(imagePath2, UriKind.Relative));
                        Laschenstoß.Source = imageSource2;
                        Laschenstoß.Visibility = Visibility.Visible;
                        break;

                    case "Geschraubter Flanschwinkelanschluss":
                        string imagePath3 = "Bilder/Stoß/Flanschwinkelanschluss.png";
                        BitmapImage imageSource3 = new BitmapImage(new Uri(imagePath3, UriKind.Relative));
                        Flanschwinkelanschluss.Source = imageSource3;
                        Flanschwinkelanschluss.Visibility = Visibility.Visible;
                        break;

                    default:

                        MessageBox.Show("Keine Stoßart ausgewählt.");
                        break;
                }
            }
        }

    }
       
}
