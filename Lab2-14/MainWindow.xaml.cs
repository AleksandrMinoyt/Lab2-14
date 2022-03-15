using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Lab2_14
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

           new Products("Молоко", 80, "images\\food\\milk.jpg", Categories.food);
           new Products("Хлеб", 45, "images\\food\\bread.jpg", Categories.food);
           new Products("Хлодильник", 32000, "images\\appliances\\fridge.jpg", Categories.appliances);
           new Products("Мясо", 329, "images\\food\\meat.jpg", Categories.food);


            prodList.ItemsSource = Products.ProductsList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Products("Микроволнавая печь", 11000, "images\\appliances\\micro.jpg", Categories.appliances);
        }
    }

    public enum Categories
    {
        food,
        appliances
    }

    public class Products
    {
        private static ObservableCollection<Products> _products;

        private string _name;
        private double _price;
        private string _pathToImage;
        private Categories _categorie;

        public string Name { get => _name; set => _name = value; }
        public double Price { get => _price; set => _price = CheckPrice(value); }
        public string PathToImage { get => _pathToImage; set => _pathToImage = value; }
        public Categories Categorie { get => _categorie; set => _categorie = value; }
        public static ObservableCollection<Products> ProductsList { get => _products; }

        public Products(string Name, double Price, string PathToImage, Categories Categogie)
        {
            _name = Name;
            _price = CheckPrice(Price);
            _pathToImage = PathToImage;
            _categorie = Categogie;
            AddNewToCollection(this);
        }

        private double CheckPrice(double Price)
        {
            if (Price < 0)
                return 0;
            return Price;
        }

        private void AddNewToCollection(Products product)
        {
            if (_products == null)
            {
                _products = new ObservableCollection<Products>();
            }

            _products.Add(product);

        }

    }
}
