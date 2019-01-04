using MarketSlip.Class_s;
using MarketSlipApp;
using MarketSlipApp.Class_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarketSlip.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomerNotes : ContentPage
	{
		public CustomerNotes ()
		{
			InitializeComponent ();
		}
        private ApiServices api = new ApiServices();


        private async void btnCustomerNotes_Clicked(object sender, EventArgs e)
        {


            try
            {
                btnCreateNotes.IsEnabled = false;
                btnCreateNotes.Text = "Saving...";
                await api.CustomerNotesAsync(entry_notes.Text, GlobalVar.strGuid, GlobalVar.strfilename, GlobalVar.strMillisecond, GlobalVar.User,GlobalVar.strRecipient);
                await DisplayAlert("      Notes Added Successfully", "", "OK");
                await Navigation.PushAsync(new MainPage());
                btnCreateNotes.IsEnabled = true;
                btnCreateNotes.Text = "Save";
            }
            catch (Exception)
            {

                await DisplayAlert("Error", "Error", "Ok");

            }
        }
    }
}