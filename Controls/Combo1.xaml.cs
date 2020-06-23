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

namespace Controls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1(string putin, String nam)
        {

            InitializeComponent();
            Name1.Text = nam;
            var bitI = new BitmapImage();
            bitI.BeginInit();
            bitI.UriSource = new Uri(putin, UriKind.Relative);
            bitI.CacheOption = BitmapCacheOption.OnLoad;
            bitI.EndInit();
            Pict.Source = bitI;


        }
    }
}