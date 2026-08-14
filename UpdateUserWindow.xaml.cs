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
    /// Interaction logic for UpdateUserWindow.xaml
    /// </summary>
    public partial class UpdateUserWindow : Window
    {
        User currentUser;
        UserRepository userRepository;
        public UpdateUserWindow(User u, UserRepository userRepo)
        {
            InitializeComponent();
            currentUser = u;
            userRepository = userRepo;
            UsernameTextBox.Text = currentUser.username;
            PasswordTextBox.Text = currentUser.password;
            RoleTextBox.Text = currentUser.role;
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            string oldUsername = currentUser.username;
            currentUser.username = UsernameTextBox.Text;
            currentUser.password = PasswordTextBox.Text;
            currentUser.role = RoleTextBox.Text;
            userRepository.UpdateUser(currentUser, oldUsername);
            this.DialogResult = true;
        }
    }
}
