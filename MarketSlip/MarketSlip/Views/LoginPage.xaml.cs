
using MarketSlip.Class_s;
using MarketSlipApp.Class_s;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarketSlip.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
    {
     
      
        private ApiServices api = new ApiServices();
        public LoginPage()
        {
            
         
            InitializeComponent();
            //DependencyService.Get<IMediaService>().ClearFiles(_images);

        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {


            try
            {
                btnLogin.IsEnabled = false;
                btnLogin.Text = "Logging In...";
                string strResult = await api.LoginAsync(entry_user.Text, entry_password.Text);
                //  await DisplayAlert("Login Failed", strResult, "Ok");
                strResult = strResult.Replace("/", "-");
                strResult = strResult.Replace(" ", null);
                strResult = strResult.Trim('"');
                RegexOptions options = RegexOptions.Multiline;
                string pattern = @"(?<=^|_)(\""""(?:[^\""""]|\""""\"""")*\""""|[^,]*)_(?<=^|_)(\""""(?:[^\""""]|\""""\"""")*\""""|[^,]*)_(?<=^|_)(\""""(?:[^\""""]|\""""\"""")*\""""|[^,]*)";
                foreach (Match m in Regex.Matches(strResult, pattern, options))
                {
                    GlobalVar.ExpiryDate = m.Groups[1].Value;
                    GlobalVar.strGuid = m.Groups[2].Value;
                    GlobalVar.intpaid = Convert.ToInt32(m.Groups[3].Value);

                }

                DateTime dateResult;

                if (DateTime.TryParseExact(GlobalVar.ExpiryDate, "dd -MM-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateResult))
                {


                    await DisplayAlert("Login Failed", "Username Or Password Incorrect", "Ok");
                    entry_user.Text = null;
                    entry_password.Text = null;
                    return;

                }

                if (Convert.ToDateTime(GlobalVar.ExpiryDate) < DateTime.Today)
                {

                    await DisplayAlert("Subscription Expired", "Your Subscription Has Expired, Please Visit Website To Resubscribe", "Ok");
                    entry_user.Text = null;
                    entry_password.Text = null;
                    return;
                }
                if (GlobalVar.intpaid == 1)
                {

                    await DisplayAlert("Payemnt Issue", "Problem WIth Payments Please Contact Assistance@sonixsoftwareltd.com", "Ok");
                    entry_user.Text = null;
                    entry_password.Text = null;
                    return;
                }

                else
                {
                    GlobalVar.User = entry_user.Text;
                    await Navigation.PushAsync(new MainPage());
                }
                btnLogin.IsEnabled = true;
                btnLogin.Text = "Login";
            }
            catch (Exception)
            {
                btnLogin.IsEnabled = true;
                btnLogin.Text = "Login";
                await DisplayAlert("Please Check Internet Connection And Try Again", "Error", "Ok");

            }
        }





    }
}