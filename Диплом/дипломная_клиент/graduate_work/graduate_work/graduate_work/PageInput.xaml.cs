using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace graduate_work
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageInput : ContentPage
    {
		public PageInput ()
		{
			InitializeComponent ();
			
		}

        private async void buttonInput_Clicked(object sender, EventArgs e)
        {

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
				errorPassword.Text = "Введите пароль";
			}
			else
			{
				errorPassword.Text = " ";
			}

			await Shell.Current.Navigation.PushAsync(new PageHome());
        }
    }
}