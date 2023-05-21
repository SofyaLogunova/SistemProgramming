using System;
using System.Collections.Generic;
using System.Windows;
using RoomLibrary_;
using static RoomLibrary_.Room;

namespace Pract4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Room> lstRooms = new List<Room>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BRoom_Click(object sender, RoutedEventArgs e)
        {
            Room room = new Room();
            room.RoomLength = Convert.ToDouble(TBleghtR.Text);
            room.RoomWidth = Convert.ToDouble(TBWedhtR.Text);
            lstRooms.Add(room);
        }

        private void BLivRom_Click(object sender, RoutedEventArgs e)
        {
            LivigRoom livingRoom = new LivigRoom();
            livingRoom.RoomLength = Convert.ToDouble(TBleghtL.Text);
            livingRoom.RoomWidth = Convert.ToDouble(TBWedhtL.Text);
            livingRoom.NumWin = Convert.ToInt32(TBNumW.Text);
            lstRooms.Add(livingRoom);
        }

        private void BOffice_Click(object sender, RoutedEventArgs e)
        {
            Office office = new Office();
            office.RoomLength = Convert.ToDouble(TBleghtO.Text);
            office.RoomWidth = Convert.ToDouble(TBWedhtO.Text);
            office.NumSockets = Convert.ToInt32(TBNumS.Text);
            lstRooms.Add(office);
        }

        private void BGet_Click(object sender, RoutedEventArgs e)
        {
            ListRoom2.Content = "";
            foreach (Room r in lstRooms)
                ListRoom2.Content += r.Info() + "\n";
        }
    }
}
