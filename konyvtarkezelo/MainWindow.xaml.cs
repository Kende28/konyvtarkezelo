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
            Beolvas("olvasok.txt");
        }

        private void Beolvas(string file)
        {
            if (File.Exists(file))
            {
                StreamReader sr = new StreamReader(file);
                if (sr.EndOfStream!)
                {
                    string[] data = sr.ReadLine().Split(";");
                    List<string> notif = data[3].Split(",").ToList<string>();
                    Olvaso newOlvaso = new Olvaso(data[0], int.Parse(data[1]), data[2], notif, data[4]);
                    olvasok.Add(newOlvaso);
                }
            }
        }

    }
}