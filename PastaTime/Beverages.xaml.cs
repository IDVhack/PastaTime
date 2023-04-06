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

namespace PastaTime
{
    /// <summary>
    /// Логика взаимодействия для Beverages.xaml
    /// </summary>
    public partial class Beverages : Page
    {
        public Beverages()
        {
            InitializeComponent();
            string path = "../../../PastaTime/File_bd/Beverages.txt";
            List<Food> bevs = new List<Food>();
            using (StreamReader reader = new StreamReader(path))
            {
                int count = 0;
                string line;
                Food curFood = new Food();
                while ((line = reader.ReadLine()) != null)
                {
                    switch (count % 3)
                    {
                        case 0:
                            curFood.Name = line;
                            break;
                        case 1:
                            curFood.Price = decimal.Parse(line);
                            break;
                        case 2:
                            curFood.PathToImage = line;
                            bevs.Add(curFood);
                            curFood = new Food();
                            break;
                    }
                    count++;
                }
            }
            Image1.Source = new BitmapImage(new Uri(@bevs[0].PathToImage, UriKind.Relative));
            Text1.Text = bevs[0].Name;
            Price1.Text = bevs[0].Price.ToString();

            Image2.Source = new BitmapImage(new Uri(@bevs[1].PathToImage, UriKind.Relative));
            Text2.Text = bevs[1].Name;
            Price2.Text = bevs[1].Price.ToString();


            Image3.Source = new BitmapImage(new Uri(@bevs[2].PathToImage, UriKind.Relative));
            Text3.Text = bevs[2].Name;
            Price3.Text = bevs[2].Price.ToString();


            Image4.Source = new BitmapImage(new Uri(@bevs[3].PathToImage, UriKind.Relative));
            Text4.Text = bevs[3].Name;
            Price4.Text = bevs[3].Price.ToString();
        }
    }
}
