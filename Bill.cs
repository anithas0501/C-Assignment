using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppFrameWork.Medical_Research_Application;

namespace ConsoleAppFrameWork.AssocaitionProgram
{ 
    class BillItem
    {
        public int itemID { get; set; }
        public string itemName { get; set; }
       public  int quantity { get; set; }
       public double price { get; set; }
    }
    class BillUI
    {
        public static Dictionary<int,int> ItemList = new Dictionary<int,int>();
       static  ArrayList resultList = new ArrayList();
        public static void Display()
        {
            int Itemid = Utilities.GetNumber("Enter the Id [1 to 10]");
            int quantity = Utilities.GetNumber("Enter the Quantity");
            //Item.Quantity = quantity;
            GetValue(Itemid,quantity);
        
        }
        public static void Store(int id, string itemName, int Value, double price)
        {
           
            resultList.Add(new BillItem {itemID=id, itemName=itemName, quantity=Value, price=price});
        }
        public static void UIComponent()
        {
            bool value = true;
            string name = Utilities.Prompt("Enter the Name");
            Bill.Name = name;
           
            do
            {
               int choice = Utilities.GetNumber("Enter 1 to Add items or press any key to exit");
                if (choice == 1)
                {
                    Display();
                    value = true;
                }
                else
                {
                    value = false;
                }

            } while (value) ;
           BillUI.getQuantity();

        }
       public  static void GetValue(int id, int quantity)
        {
              foreach (var item in ItemList)
            {
                
                {
                    if (item.Key==id)
                    {
                        ItemList[id] = item.Value + quantity;
                      
                    }
                    else
                    {
                        ItemList.Add(id, quantity);
                       
                    }
                }
            }
        }
        public static void getQuantity()
        {
            foreach (var item in ItemList)

            {
                foreach (var item1 in Item.ItemArray)
                {
                    Console.WriteLine(item1.id);
                    Console.WriteLine(item1.itemName);
                    if (item.Key == item1.id)
                    {
                        var copy = item1 as Item;
                        double price = (item.Value * copy.Price);
                        
                        Store(copy.id,copy.itemName,item.Value,price);
                        Bill.BillAmount += price;

                    }
                }
               
            }

        }
        public static void UIInterface()
        {
            Console.WriteLine($"User Name:{Bill.Name}");
            Console.WriteLine($"Date:{Bill.BillDate}");
            Console.WriteLine($"Bill No {Bill.BillNo}");
            Console.WriteLine($"ItemId\t ItemName\t Quantity\tPrice");
            foreach (var item in BillUI.resultList)
            {
                var copy = item as BillItem;
                Console.WriteLine(copy.itemID);
                Console.WriteLine($"{copy.itemID}\t{copy.itemName}\t{copy.quantity}\t{copy.price}");
            }
            Console.WriteLine($"Total Billing Amonut is: {Bill.BillAmount}");


        }
       


    }
        
    class Bill
    {
        public static int BillNo { get; set; } = 1;
        public static DateTime BillDate { get; set; } = DateTime.Now;
        public static string Name { get; set; }
        public static double BillAmount { get;  set; } 
        
    }
    class Item
    {
        public int id { get; set; }
        public string itemName { get; set; }
        public double Price { get; set; }
        public static int Quantity { get; set; } = 1;
        public static Item[] ItemArray = new Item[10];
        public static void SetItems()
        {
          
            ItemArray[0] = new Item { id=1, itemName="Book", Price=200 };
            ItemArray[1] = new Item { id = 2, itemName = "Pen", Price = 20 };
            ItemArray[2] = new Item { id = 3, itemName = "Samsung Mobile", Price = 30000};
            ItemArray[3] = new Item { id = 4, itemName = "Bottle", Price = 50};
            ItemArray[4] = new Item { id = 5, itemName = "Laptop", Price = 80000 };
            ItemArray[5] = new Item { id = 6, itemName = "LG TV", Price = 20000 };
            ItemArray[6] = new Item { id = 7, itemName = "Earphone", Price = 500 };
            ItemArray[7] = new Item { id = 8, itemName = "Bag", Price = 1000 };
            ItemArray[8] = new Item { id = 9, itemName = "Shoes", Price = 2000 };
            ItemArray[9] = new Item { id = 10, itemName = "Chips", Price = 200 };

        }
    }
    class MainSolution
    {
       
        static void Main(string[] args)
        {

            BillUI.UIComponent();
            BillUI.UIInterface();



        }
    }
    
    
    
    
}
