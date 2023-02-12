using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private void buttonRegist_Clicked(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(entryName.Text)) ||
			(string.IsNullOrWhiteSpace(entryName.Text)))
			{
				errorName.Text = "Введите имя";
			}
			else
			{
				errorName.Text = " ";
			}

            if ((string.IsNullOrEmpty(phoneEntry.Text)) ||
            (string.IsNullOrWhiteSpace(phoneEntry.Text)))
            {
                errorPhone.Text = "Введите номер телефона";
            }
            else if (phoneEntry.Text.Length < 16)
            {
                errorPhone.Text = "Неправильный формат";
            }
            else
            {
                errorPhone.Text = " ";
            }

            if ((string.IsNullOrEmpty(passwordEntry.Text)) ||
            (string.IsNullOrWhiteSpace(passwordEntry.Text)))
            {
                errorPassword.TextColor = Color.Red;
                errorPassword.Text = "Введите пароль";
            }
            else
            {
                errorPassword.Text = " ";
                if (passwordEntryReturn.Text != passwordEntry.Text)
                {
                    errorPassword.TextColor = Color.Red;
                    errorPassword.Text = "Пароли не совпадают";
                }
                else
                {
                    errorPassword.TextColor = Color.Green;
                    errorPassword.Text = "Пароли совпадают";
                }
            }

           
        }
    }
}