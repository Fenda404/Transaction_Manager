using PhatDat_FoodStore.Commands;
using PhatDat_FoodStore.Regex;
using PhatDat_FoodStore.Services;
using PhatDat_FoodStore.Views;
using PhatDat_FoodStore.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PhatDat_FoodStore.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        private readonly UserRepository _userRepository = new UserRepository();
        public ICommand LoginCommand { get; set; }

        // Biến static để lưu tên đăng nhập dùng chung toàn ứng dụng
        public static string CurrentUser { get; set; }

        private string _getUsername;
        public string GetUsername
        {
            get => _getUsername;
            set
            {
                _getUsername = value;
                OnPropertyChanged(nameof(GetUsername));
            }
        }
        public LoginViewModel()
        {
            
            // LoginCommand: Xử lý đăng nhập
            LoginCommand = new RelayCommand<object>(
                (p) => ExecuteLogin(p),
                (p) => true
            );
        }



        private void ExecuteLogin(object parameter)
        {

            var passwordBox = parameter as PasswordBox;
            if (passwordBox == null) return;

            string password = passwordBox.Password;
            var user = _userRepository.Authenticate(GetUsername, password);

            if (user != null)
            {
                LoginViewModel.CurrentUser = GetUsername;
                // 1. Khởi tạo MainView
                MainView mainView = new MainView();

                // 2. CỰC KỲ QUAN TRỌNG: Gán MainWindow mới cho Application 
                // để khi đóng LoginView, App không bị tắt theo.
                Application.Current.MainWindow = mainView;

                // 3. Hiển thị MainView
                mainView.Show();

                // 4. Tìm và đóng cửa sổ cũ
                // Thay vì OfType<Window>().SingleOrDefault(x => x.IsActive), 
                // ta nên dùng cách an toàn hơn là tìm theo DataContext hoặc Close trực tiếp nếu có tham số.
                Window currentWin = Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x != mainView);
                
                currentWin?.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Thông báo",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                passwordBox.Clear();
            }
        }
    }
}
