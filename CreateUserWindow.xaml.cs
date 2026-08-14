using _2.semEksamenProjekt.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _2.semEksamenProjekt
{
    /// <summary>
    /// Interaction logic for CreateUserWindow.xaml
    /// </summary>
    public partial class CreateUserWindow : Window
    {
        UserRepository userRepository;
        public CreateUserWindow(UserRepository userRepo)
        {
            InitializeComponent();
            userRepository = userRepo;
        }

        private void CreateUserButton_Click(object sender, RoutedEventArgs e)
        {
            userRepository.CreateUser(usernameTextbox.Text, passwordTextbox.Text);
            this.Close();
        }
    }
}
