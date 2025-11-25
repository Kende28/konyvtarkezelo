using System.IO;
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

namespace konyvtarkezelo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> mufajok = new List<string>()
        {
            "regény", 
            "sci-fi", 
            "fantasy", 
            "ismeretterjesztő",
            "mese"
        };

        List<Olvaso> olvasok = new List<Olvaso>();

        public MainWindow()
        {
            InitializeComponent();
            cb_genre.ItemsSource = mufajok;
            cb_genre.SelectedItem = mufajok[0];
            Beolvas("olvasok.txt");
        }

        private void Beolvas(string file)
        {
            if (File.Exists(file))
            {
                StreamReader sr = new StreamReader(file);
                if (!sr.EndOfStream && sr.ReadLineAsync().Result != null && sr.ReadLineAsync().Result != "")
                {
                    string[] data = sr.ReadLine().Split(";");
                    List<string> notif = data[3].Split(",").ToList<string>();
                    Olvaso newOlvaso = new Olvaso(data[0], int.Parse(data[1]), data[2], notif, data[4]);
                    olvasok.Add(newOlvaso);
                }
            }
            lb_result.ItemsSource = olvasok;
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            lb_result.ItemsSource = olvasok;
            List<string> notif = new List<string>();
            string member = "";
            foreach (var item in sp_notif.Children)
            {
                if (item is CheckBox cb && cb.IsChecked == true)
                {
                    notif.Add(cb.Content.ToString());
                }
            }
            foreach (var item in sp_member.Children)
            {
                if (item is RadioButton rb && rb.IsChecked == true)
                {
                    member = rb.Content.ToString();
                }
            }
            Olvaso newOlvaso = new Olvaso(tb_nev.Text, int.Parse(tb_kor.Text), cb_genre.SelectedItem.ToString(), notif, member);
            tb_success.Text = "Sikeres mentés";
            olvasok.Add(newOlvaso);
            StreamWriter sw = new StreamWriter("olvasok.txt",true, Encoding.UTF8);
            foreach (var item in olvasok)
            {
                sw.WriteLine(item.ToString());
            }
            sw.Close();
        }
    }
}