using System.Windows;

namespace FoodForwardApp
{
    public partial class RegistrationPage : Window
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string phoneNumber = PhoneNumberTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;
            string reEnterPassword = ReEnterPasswordBox.Password;
            bool acceptTerms = AcceptTermsCheckBox.IsChecked ?? false;

            if (!acceptTerms)
            {
                MessageBox.Show("You must accept the terms and conditions.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (password != reEnterPassword)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Registration logic here (e.g., save to database)

            MessageBox.Show("Registration successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
