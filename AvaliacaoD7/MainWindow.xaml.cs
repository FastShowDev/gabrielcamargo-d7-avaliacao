using System;
using System.Windows;
using System.Collections.Generic;
using AvaliacaoD7.Data;
using AvaliacaoD7.ViewModels;
using AvaliacaoD7.Models;
using System.Linq;

namespace AvaliacaoD7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Context context;
        public MainWindow(Context context)
        {
            InitializeComponent();
            this.context = context;
            
        }
    }
}
