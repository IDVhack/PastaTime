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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public enum StateFood
    {
        Soup,
        Pasta,
        Salad,
        Beverages
    }
    public partial class MainWindow : Window
    {
        public List<Food> foods { get; set; }
        public List<Food> foodsInCard { get; set; }
        public decimal total { get; set; }

        public StateFood state_food;
        string pathToSoup = "../../../PastaTime/File_bd/Soup.txt";
        string pathToSalad = "../../../PastaTime/File_bd/Salad.txt";
        string pathToBeverages= "../../../PastaTime/File_bd/Beverages.txt";
        string pathToPasta = "../../../PastaTime/File_bd/Pasta.txt";

        public MainWindow()
        {
            InitializeComponent();
            state_food = StateFood.Soup;
            TotalPrice.Text = "";
            total = 0;
            foods = new List<Food>();
            foodsInCard = new List<Food>();
            GetFromFile(pathToSoup);
            GetFromFile(pathToBeverages);
            GetFromFile(pathToSalad);
            GetFromFile(pathToPasta);
            setToView();
            DataContext = this;
        }

        int currentPosition()
        {
            int start;
            if (state_food == StateFood.Soup)
                start = 0;
            else if (state_food == StateFood.Beverages)
                start = 4;
            else if (state_food == StateFood.Salad)
                start = 8;
            else
                start = 12;
            return start;
        }
        void setToView()
        {
            int start = currentPosition();
            Image1.Source = new BitmapImage(new Uri(@foods[start].PathToImage, UriKind.Relative));
            Text1.Text = foods[start].Name;
            Price1.Text = foods[start].Price.ToString() + " рублей";

            Image2.Source = new BitmapImage(new Uri(@foods[start + 1].PathToImage, UriKind.Relative));
            Text2.Text = foods[start + 1].Name;
            Price2.Text = foods[start + 1].Price.ToString() + " рублей";


            Image3.Source = new BitmapImage(new Uri(@foods[start + 2].PathToImage, UriKind.Relative));
            Text3.Text = foods[start + 2].Name;
            Price3.Text = foods[start + 2].Price.ToString() + " рублей";


            Image4.Source = new BitmapImage(new Uri(@foods[start + 3].PathToImage, UriKind.Relative));
            Text4.Text = foods[start + 3].Name;
            Price4.Text = foods[start + 3].Price.ToString() + " рублей";
        }


        void GetFromFile(string pathToFile)
        {
            using (StreamReader reader = new StreamReader(pathToFile))
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
                            foods.Add(curFood);
                            curFood = new Food();
                            break;
                    }
                    count++;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int start = currentPosition();
            if (!foodsInCard.Contains(foods[start]))
            {
                foodsInCard.Add(foods[start]);
            }
            foodsInCard.Find(i => i.Name == foods[start].Name).Count++;
            ListCard.Items.Refresh();
            total += foods[start].Price;
            TotalPrice.Text = total.ToString() + " рублей";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int start = currentPosition();
            if (!foodsInCard.Contains(foods[start + 1]))
            {
                foodsInCard.Add(foods[start + 1]);
            }
            foodsInCard.Find(i => i.Name == foods[start + 1].Name).Count++;
            ListCard.Items.Refresh();
            total += foods[start + 1].Price;
            TotalPrice.Text = total.ToString() + " рублей";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int start = currentPosition();
            if (!foodsInCard.Contains(foods[start + 2]))
            {
                foodsInCard.Add(foods[start + 2]);
            }
            foodsInCard.Find(i => i.Name == foods[start + 2].Name).Count++;
            ListCard.Items.Refresh();
            total += foods[start + 2].Price;
            TotalPrice.Text = total.ToString() + " рублей";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            int start = currentPosition();
            if (!foodsInCard.Contains(foods[start + 3]))
            {
                foodsInCard.Add(foods[start + 3]);
            }
            foodsInCard.Find(i => i.Name == foods[start + 3].Name).Count++;
            ListCard.Items.Refresh();
            total += foods[start + 3].Price;
            TotalPrice.Text = total.ToString() + " рублей";
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            ListCard.SelectedItem = ((Button)sender).DataContext;
            foodsInCard.ElementAt(ListCard.SelectedIndex).Count--;
            ListCard.Items.Refresh();
            total -= foodsInCard.ElementAt(ListCard.SelectedIndex).Price;
            TotalPrice.Text = total.ToString() + " рублей";
            if (foodsInCard.ElementAt(ListCard.SelectedIndex).Count <= 0)
                foodsInCard.RemoveAt(ListCard.SelectedIndex);
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ListCard.SelectedItem = ((Button)sender).DataContext;
            foodsInCard.ElementAt(ListCard.SelectedIndex).Count++;
            ListCard.Items.Refresh();
            total += foodsInCard.ElementAt(ListCard.SelectedIndex).Price;
            TotalPrice.Text = total.ToString() + " рублей";
        }

        private void Soup_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            state_food = StateFood.Soup;
            setToView();
        }
        

        private void Order_Click(object sender, RoutedEventArgs e)
        {

            Check check = new Check(foodsInCard);
            check.Show();
        }

        private void Pasta_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            state_food = StateFood.Pasta;
            setToView();
        }

        private void Salad_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            state_food = StateFood.Salad;
            setToView();
        }

        private void Beverages_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            state_food = StateFood.Beverages;
            setToView();
        }

    }
    
}
