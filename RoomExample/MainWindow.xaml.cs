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
using System.Windows.Navigation;
using System.Windows.Shapes;
using RoomLibrary_;

namespace RoomExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Room room1 = new Room();
        Room room2 = new Room();
        Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonOpen1_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpen2.IsEnabled = true; 
            room1.RoomLength = rnd.Next(2, 11);
            room1.RoomWidth = rnd.Next(2, 11); 
            int numP = rnd.Next(1, 9);
            
            LabelLeght1.Content = room1.RoomLength;
            LabaelWidht1.Content = room1.RoomWidth;
            LabaelNumPerson1.Content = numP;


            LabaelPerimetr1.Content = room1.RoomPerimeter(); 
            labelArea1.Content = room1.RoomArea();
            labelPersonArea1.Content = (room1.PersonArea(numP),3);
        }

        private void ButtonOpen2_Click(object sender, RoutedEventArgs e)
        {
            ButtonAll.IsEnabled = true;
            room2.RoomLength = Convert.ToDouble(TBLeignt2.Text);
            room2.RoomWidth = Convert.ToDouble(TBWedht2.Text);
            int numP = Convert.ToInt32(TBNumPerson2.Text);

            LabaelPerimetr2.Content = room2.RoomPerimeter();
            labelArea2.Content = room2.RoomArea();
            labelPersonArea2.Content = (room2.PersonArea(numP), 3);

        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonAll_Click(object sender, RoutedEventArgs e)
        {
            LabaelAllArea.Content = room1.RoomArea() + room2.RoomArea();
        }
    }
}
