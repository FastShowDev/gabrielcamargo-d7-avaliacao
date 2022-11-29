using AvaliacaoD7.Commands;
using AvaliacaoD7.Models;
using AvaliacaoD7.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace AvaliacaoD7.ViewModels;

public class LoginViewModel : BaseViewModel
{

    #region Properties
    private string _userEmail;
    public string UserEmail
    {
        get { return _userEmail; }
        set { _userEmail = value; OnPropertyChanged(nameof(UserEmail)); }
    }

    private string _userPassword;
    public string UserPassword
    {
        get { return _userPassword; }
        set { _userPassword = value; OnPropertyChanged(nameof(UserPassword)); }
    }
    #endregion

    #region Commands
    public LoginCommand Login { get; set; }
    #endregion

    public LoginViewModel()
    {
        Login = new LoginCommand(this);
    }
    public void LoginUser(string email, string password)
    {
        if (ValidateUser(email, password))
        {
            MessageBox.Show("Usuário Autenticado!", "Login", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        else
        {
            MessageBox.Show("Credenciais incorretas!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private bool ValidateUser(string email, string password)
    {
        if(_context == null)
        {
            MessageBox.Show("Contexto (banco de dados) nulo!", "DB ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        return _context.Users.Any(x => x.Email == email && x.Password == password);
    }
    
}

