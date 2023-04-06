using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace PastaTime
{
    /// <summary>
    /// Логика взаимодействия для Check.xaml
    /// </summary>
    public partial class Check : Window
    {
        public Check(List<Food> foods)
        {
            InitializeComponent();
            StringBuilder allCheck = new StringBuilder();
            decimal Cost = 0;
            int count = 0;
            foreach (var cur in foods)
            {
                Cost += cur.Count * cur.Price;
                count++;
                allCheck.Append(count + ". " + cur.Name + " по цене " + cur.Price + "р в количестве " + cur.Count + " = " + cur.Count * cur.Price + "\n");
            }
            allCheck.Append("\n\n\n\n///////////////////////////////////\n");
            allCheck.Append("ИТОГО: " + Cost + " рублей");
            Checks.Text = allCheck.ToString();
        }
    }
}
