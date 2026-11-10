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
            
            }
    }        
    
}