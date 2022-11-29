using AvaliacaoD7.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.ComponentModel;
using System.Configuration;

namespace AvaliacaoD7.ViewModels;

public class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected Context _context;
    public BaseViewModel()
    {
        var contextOptions = new DbContextOptionsBuilder<Context>().UseSqlite("Data source = User.db").Options;
        _context = new Context(contextOptions);

    }

    protected void OnPropertyChanged(string propertyName) 
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
