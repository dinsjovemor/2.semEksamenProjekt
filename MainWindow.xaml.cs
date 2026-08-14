using _2.semEksamenProjekt.Repositories;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2.semEksamenProjekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserRepository userRepository;
        public MainWindow()
        {
            InitializeComponent();
            userRepository = new UserRepository();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"LoginButtonClick {usernameTextbox.Text} og {passwordTextbox.Text} ");
            User? user = userRepository.LoginUser(usernameTextbox.Text, passwordTextbox.Text);
            if (user != null)
            {
                Debug.WriteLine($"Login {user.username}");
                EventOverviewWindow window = new EventOverviewWindow(user, userRepository);
                window.Show();
                this.Close();
            }
            else
            {
                usernameTextbox.Text = "";
                passwordTextbox.Text = "";
            }
        }

        private void CreateUserButton_Click(object sender, RoutedEventArgs e)
        {
            CreateUserWindow window = new CreateUserWindow(userRepository);
            window.ShowDialog();
        }
    }
}