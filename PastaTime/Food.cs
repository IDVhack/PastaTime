using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaTime
{
    public class Food
    {
        public Food(string name, string image, decimal price)
        {
            Name = name;
            PathToImage = image;
            Price = price;
        }
        public Food()
        {
            Name = "";
            PathToImage = "";
            Price = 0;
            Count = 0;
        }

        public string Name { get; set; }
        public string PathToImage { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}
