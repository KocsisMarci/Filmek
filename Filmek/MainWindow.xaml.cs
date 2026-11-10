using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Filmek
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


        public class FilmAdatok
        {
            public string Cím { get; set; }

            public string Műfaj { get; set; }

            public int Hossz { get; set; }

            public double Értékelés { get; set; }

            public FilmAdatok(string c, string m, int h, double e)
            {
                this.Cím = c;
                this.Műfaj = m;
                this.Hossz = h;
                this.Értékelés = e;

            }
        };

        List<FilmAdatok> filmek = new List<FilmAdatok>(){
new FilmAdatok("Csillagok háborúja", "sci-fi", 121, 8.6),
new FilmAdatok("Titanic", "dráma", 195, 7.8),
new FilmAdatok("A Gyűrűk Ura", "fantasy", 201, 8.8),
new FilmAdatok("Mátrix", "sci-fi", 136, 8.7),
new FilmAdatok("Shrek", "animáció", 90, 7.9)
};


        private void Button_Click(object sender, RoutedEventArgs e){
            dataGrid.ItemsSource = filmek;
            dataGrid.Items.Refresh();
            progress.Maximum = 10;
            progress.Minimum = 0;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Összesen {filmek.Count} film van");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            var leghosszabb = filmek.Max(film => film.Hossz);

            foreach (FilmAdatok film in filmek) {
                if (film.Hossz == leghosszabb) {
                    MessageBox.Show($"A leghosszabb film: {film.Cím} ({film.Hossz} perc).");
                    break;
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            double atlag = filmek.Average(film => film.Értékelés);

            MessageBox.Show($"A filmek átlagos értékelése: {Math.Round(atlag,1)}");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var scifik = filmek.Where(film => film.Műfaj == "sci-fi").ToList();

            dataGrid.ItemsSource = scifik;

            dataGrid.Items.Refresh();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var CsakShrek = filmek.Where(film => film.Cím.Contains("Shrek")).ToList();

            dataGrid.ItemsSource = CsakShrek;
            dataGrid.Items.Refresh();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            var cimSzerint = filmek.OrderBy(film => film.Cím).ToList();

            dataGrid.ItemsSource = cimSzerint;
            dataGrid.Items.Refresh();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            FilmAdatok kivalasztott=(FilmAdatok)dataGrid.SelectedItem;
            progress.Value = kivalasztott.Értékelés;
        }
    }        
    
}