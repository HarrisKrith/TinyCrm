using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace TinyCRM
{
    class Program
    {
        static void Main(string[] args)
        {
            string fPath = @"C:\Users\Ninel\Desktop\TinyCRM\Products.txt";
            List<string> lines = File.ReadAllLines(fPath).ToList();//list used to enter values @ product
            List<Product> products = new List<Product>();//where values go - list products

            foreach (var line in lines)
            {
                string[] entries = line.Split(';');
                Product newProduct = new Product();

                newProduct.ProductId = entries[0];
                newProduct.Name = entries[1];
                newProduct.Description = entries[2];
                newProduct.Price = GetRandomPrice();
                products.Add(newProduct);
            }
            var listNoDoubleEntries = products
                .GroupBy(x => x.ProductId) // group by .ProductId
                .Select(y => y.First()) // Select the first option if dublicate
                .ToList();  // add to list

            foreach (var p in listNoDoubleEntries) //print the new list
            {
                Console.WriteLine(
                    $@"{p.ProductId} | {p.Name} | {p.Description} | {p.Price}");
            }
            Console.WriteLine(" ");

            var rng = new Random();

            List<Product> orderCust1 = new List<Product>();//list for cust1 - bought products
            for (int i = 0; i < 10; i++)
            {
                var randomLine = rng.Next(listNoDoubleEntries.Count);//get random No
                var randomChoice = listNoDoubleEntries.ElementAt(randomLine);//incert random No.Line
                orderCust1.Add(randomChoice);//add to list the random line
            }
            Customer customer1 = new Customer()
            {
                //gemise tis metablhtes
                Orders = new List<Order>
                {
                    new Order(){
                         Products  =  orderCust1
                    }
                }
            };
            foreach (var p in orderCust1) //print the new list - cust1 - bought products
            {
                {
                    Console.WriteLine(
                        $@"{p.ProductId} | {p.Name} | {p.Description} | {p.Price}");
                }
            }

            Console.WriteLine(" ");


            List<Product> orderCust2 = new List<Product>();//list for cust1 - bought products
            for (int i = 0; i < 10; i++)
            {
                var randomPosition = rng.Next(listNoDoubleEntries.Count);//get random No
                var randomChoice = listNoDoubleEntries.ElementAt(randomPosition);//incert random No.Line
                orderCust2.Add(randomChoice);//add to list the random line
            }
            Customer customer2 = new Customer()
            {
                //gemise tis metablhtes
                Orders = new List<Order>
                {
                    new Order(){
                         Products  =  orderCust2
                    }
                }
            };
            foreach (var p in orderCust2) //print the new list - cust2 - bought products
            {
                {
                    Console.WriteLine(
                        $@"{p.ProductId} | {p.Name} | {p.Description} | {p.Price}");
                }
            }

            decimal sumCust1 = customer1.Orders
                .SelectMany(order => order.Products) //all purchased products
                .Select(product => product.Price)
                .Sum();

            decimal sumCust2 = customer2.Orders
               .SelectMany(order => order.Products) //all purchased products
               .Select(product => product.Price)
               .Sum();

            Console.WriteLine(" ");


            if (sumCust1 < sumCust2)
            {
                Console.WriteLine("Customer 1 is the biggest spender");
            }
            else
            {
                Console.WriteLine("Customer 2 is the biggest spender");
            }

            Console.ReadLine();
        }

        public static decimal GetRandomPrice()
        {
            var random = new Random();
            var randomNumber = random.NextDouble() * 100; // vgazi double apo 1-100
            var roundNumber = Math.Round(randomNumber, 2); // 2 dekadika psifia
            return (decimal)roundNumber;
        }
    }
}
