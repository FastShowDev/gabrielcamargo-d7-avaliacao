using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using AvaliacaoD7.ViewModels;

namespace AvaliacaoD7.Commands
{
    public class LoginCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly LoginViewModel _loginViewModel;

        public LoginCommand(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;
            _loginViewModel.PropertyChanged += ViewModel_PropertyChanged;
        }
        public bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_loginViewModel.UserEmail);
        }

        public void Execute(object? parameter)
        {
            _loginViewModel.UserPassword = (parameter as PasswordBox).Password;
            _loginViewModel.LoginUser(_loginViewModel.UserEmail, _loginViewModel.UserPassword);
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
