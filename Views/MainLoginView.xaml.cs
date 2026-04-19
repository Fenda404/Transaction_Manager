using PhatDat_FoodStore.ViewModels;
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

namespace PhatDat_FoodStore.Views
{
    /// <summary>
    /// Interaction logic for MainLoginView.xaml
    /// </summary>
    public partial class MainLoginView : Window
    {
        MainLoginViewModel mlgvm;
        public MainLoginView()
        {
            InitializeComponent();
            mlgvm =(MainLoginViewModel)DataContext;
        }
    }
}
