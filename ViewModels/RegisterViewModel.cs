using PhatDat_FoodStore.Commands;
using PhatDat_FoodStore.Services;
using PhatDat_FoodStore.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Text.RegularExpressions;

namespace PhatDat_FoodStore.ViewModels
{
    class RegisterViewModel : BaseViewModel
    {
        private readonly UserRepository _userRepository = new UserRepository();

        private string _username;
        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(nameof(Username)); }
        }

        public ICommand RegisterCommand { get; set; }
        public RegisterViewModel()
        {
            RegisterCommand = new RelayCommand<object>((p) => ExecuteRegister(p), (p) => true);
        }

        private void ExecuteRegister(object parameter)
        {
            var values = parameter as object[];
            if (values == null || values.Length < 2) return;

            var passwordBox = values[0] as PasswordBox;
            var confirmPasswordBox = values[1] as PasswordBox;



            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(passwordBox?.Password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo");
                return;
            }

            // SO SÁNH CHUỖI MẬT KHẨU (dùng thuộc tính .Password)
            if (passwordBox.Password != confirmPasswordBox.Password)
            {
                MessageBox.Show("Cả hai mật khẩu không trùng khớp!", "Cảnh báo");
                return;
            }

            ValidRegister validRegister = new ValidRegister();
            if (!validRegister.CheckValid(passwordBox.Password))
            {
                MessageBox.Show("Mật khẩu không đạt yêu cầu!", "Cảnh báo");
                return;
            }
            string password = passwordBox.Password;
            bool isSuccess = _userRepository.Register(Username, password);

            if (isSuccess)
            {
                MessageBox.Show("Đăng ký thành công!", "Thông báo");
                // Đạt có thể thêm logic xóa trắng form ở đây
                passwordBox.Clear();
                confirmPasswordBox.Clear();
                Username = "";
            }
            else
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!", "Lỗi");
            }
        }
    }
}
