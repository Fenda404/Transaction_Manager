using PhatDat_FoodStore.Commands;
using PhatDat_FoodStore.Services;
using PhatDat_FoodStore.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PhatDat_FoodStore.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private string getUsername;
        public string GetUsername
        { 
            get => getUsername;
            set
            {
                getUsername = value;
                OnPropertyChanged(nameof(GetUsername));
            }
        }

        public ICommand SignOutCommand {  get; set; }

        public MainViewModel()
        {
            GetUsername = LoginViewModel.CurrentUser;

            SignOutCommand = new RelayCommand(_ => SignOut(), _ => true);
        }


        private void SignOut()
        {
            MessageBoxResult ask = MessageBox.Show("Do you want to sign out?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (ask == MessageBoxResult.Yes)
            {
                MainLoginView mainLoginView = new MainLoginView();
                
                mainLoginView.Show();
                Application.Current.MainWindow = mainLoginView;
                Window currentWin = Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x != mainLoginView);

                currentWin?.Close();

            }
        }



    }
}
