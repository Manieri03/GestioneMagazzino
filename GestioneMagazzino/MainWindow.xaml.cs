using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestioneMagazzino
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnvisualizza_Click(object sender, RoutedEventArgs e)
        {
            StreamReader sr = new StreamReader("listaprodotti.txt");
            string line;
            
            while ((line = sr.ReadLine()) != null)
            {
                lbllista.Content+=$"{line} \n";
            }
            sr.Close();
        }
        private void btnaggiungi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string prodotto = txtnome.Text;
                double prezzo = double.Parse(txtprezzo.Text);

                StreamWriter sw = new StreamWriter("listaprodotti.txt", true, Encoding.UTF8);
                sw.WriteLine($"{prodotto}, {prezzo} euro");
                sw.Flush();
                sw.Close();
                txtnome.Clear();
                txtprezzo.Clear();
            }
            catch
            {
                MessageBox.Show("Errore", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btncancella_Click(object sender, RoutedEventArgs e)
        {
            String myPath = "listaprodotti.txt";
            File.Delete(myPath);

            lbllista.Content = "";
            MessageBox.Show("Ho eliminato tutti i dati del file di testo", "Avviso", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
