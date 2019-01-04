using MarketSlip.Class_s;
using MarketSlipApp.Class_s;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MarketSlip.Models
{
    class LoginModel
    {
        private ApiServices api = new ApiServices();
        public string Username { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var Varexpirydate = await api.LoginAsync(Username, Password);
                    GlobalVar.ExpiryDate = Varexpirydate;

                });
            }
        }
    }
}
