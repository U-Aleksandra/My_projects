using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace graduate_work
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageRegist : ContentPage
	{
		public PageRegist ()
		{
			InitializeComponent ();
		}

        private bool _nameIsValid;
        private bool _phoneIsValid;
        private bool _passwordIsValid;
        private async void buttonRegist_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(entryName.Text) ||
			string.IsNullOrWhiteSpace(entryName.Text))
			{
				errorName.Text = "Введите имя";
                _nameIsValid = false;
			}
			else
			{
				errorName.Text = " ";
                _nameIsValid = true;
			}

            if (string.IsNullOrEmpty(phoneEntry.Text) ||
            string.IsNullOrWhiteSpace(phoneEntry.Text))
            {
                errorPhone.Text = "Введите номер телефона";
            }
            else if (phoneEntry.Text.Length < 16)
            {
                errorPhone.Text = "Неправильный формат";
                _phoneIsValid = false;
            }
            else
            {
                errorPhone.Text = " ";
                _phoneIsValid= true;
            }

            if (string.IsNullOrEmpty(passwordEntry.Text) ||
            string.IsNullOrWhiteSpace(passwordEntry.Text))
            {
                errorPassword.TextColor = Color.Red;
                errorPassword.Text = "Введите пароль";
            }

            if (_nameIsValid && _phoneIsValid && _passwordIsValid)
            {
                if (checkBoxSpecial.IsChecked)
                    await Navigation.PushAsync(new PageRegistSpecialist());
                else
                    await Navigation.PushAsync(new PageRegistSpecialist());
            }
           
        }
        private void passwordEntryReturn_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (passwordEntryReturn.Text != passwordEntry.Text && !string.IsNullOrEmpty(passwordEntryReturn.Text))
            {
                errorPassword.TextColor = Color.Red;
                errorPassword.Text = "Пароли не совпадают";
                _passwordIsValid = false;
            }
            else if(!string.IsNullOrEmpty(passwordEntryReturn.Text))
            {
                errorPassword.TextColor = Color.Green;
                errorPassword.Text = "Пароли совпадают";
                _passwordIsValid = true;
            }
        }
    }
}