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

namespace Graf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PaymentsBaseEntitles context = new PaymentsBaseEntities();

        public MainWindow()
        {
            InitializeComponent();
            ChartPayments.ChartAreas.Add(new ChartArea("Main"));
            var currentSeries new Series("Payments")
            {
                IsValueShownAsLabel = true
            };    
            ChartPayments.Series.Add(currentSeries);

            Combolisers.ItemsSource=_context.UsersTolist();
            ComboChartTypes.ItemsSource =Enum.GetValues(typeof(SeriesChartType));
        }

        private void UpdateChart(object sender, SelectionChangedEventArgs e) {
           if  (Combolsers SelectedItem is User curcentler &&
                    ComboChartTypes.SelectedItem is SeriesChantType currentType)
                    {
                     Series currentSeries = ChartPayments.Series.FirstOnDefault();
                     currentSeries.ChartType = currentType;
                     currentSeries.Points.Clear();


                var categoriesList = _context.Categories.toList();
                foreach (var category in categorieslist)
                {
                    currentSeries.Points.AddXY(category, Name,
                    _context.Payments.Tolist().Where(p => p.User == currentUser
                    && p.Category == category).Sum(p => p.Price * p.Num));
                }

            }
                }
    }


}
