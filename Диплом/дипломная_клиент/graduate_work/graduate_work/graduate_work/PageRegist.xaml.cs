using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace graduate_work
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageRegist : ContentPage
	{
		public PageRegist ()
		{
			InitializeComponent ();
		}

        bool next1;
        bool next2;
        bool next3;
        private async void buttonRegist_Clicked(object sender, EventArgs e)
        {
            

            if ((string.IsNullOrEmpty(entryName.Text)) ||
			(string.IsNullOrWhiteSpace(entryName.Text)))
			{
				errorName.Text = "Введите имя";
                next1 = false;
			}
			else
			{
				errorName.Text = " ";
                next1 = true;
			}

            if ((string.IsNullOrEmpty(phoneEntry.Text)) ||
            (string.IsNullOrWhiteSpace(phoneEntry.Text)))
            {
                errorPhone.Text = "Введите номер телефона";
            }
            else if (phoneEntry.Text.Length < 16)
            {
                errorPhone.Text = "Неправильный формат";
                next2 = false;
            }
            else
            {
                errorPhone.Text = " ";
                next2= true;
            }

            if ((string.IsNullOrEmpty(passwordEntry.Text)) ||
            (string.IsNullOrWhiteSpace(passwordEntry.Text)))
            {
                errorPassword.TextColor = Color.Red;
                errorPassword.Text = "Введите пароль";
            }

            if (next1 && next2 && next3 && checkBoxSpecial.IsChecked == true)
            {
                await Navigation.PushAsync(new PageRegistSpecialist());
            }
           
        }
        private void passwordEntryReturn_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (passwordEntryReturn.Text != passwordEntry.Text)
            {
                errorPassword.TextColor = Color.Red;
                errorPassword.Text = "Пароли не совпадают";
                next3 = false;
            }
            else
            {
                errorPassword.TextColor = Color.Green;
                errorPassword.Text = "Пароли совпадают";
                next3 = true;
            }
        }
    }
}