using System.Windows;

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
