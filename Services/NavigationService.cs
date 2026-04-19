using PhatDat_FoodStore.ViewModels;
using PhatDat_FoodStore.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhatDat_FoodStore.Services
{
    class NavigationService : BaseViewModel
    {
        public static void Navigate(Window currentWindow, Window nextWindow)
        {
            nextWindow.Show();
            currentWindow.Close();
        }

        // Nếu bạn muốn mở cửa sổ mới mà không đóng cửa sổ cũ (để Back)
        public static void OpenChild(Window nextWindow)
        {
            nextWindow.Show();
        }
    }
}
