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

namespace Maps_Navigation
{
    /// <summary>
    /// Interaction logic for MapHome.xaml
    /// </summary>
    public partial class MapHome : Page
    {
        public MapHome()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MapTraverser map = new MapTraverser();
            try
            {
                map.Traverse(instructionsBox.Text);
                distanceLabel.Text = map.GetDistanceFromStart().ToString();
            }
            catch(Exception ex)
            {
                distanceLabel.Text = "Exception Occurred! " + ex.Message;
            }
        }
    }
}
