using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MarketSlip.Class_s;
using Newtonsoft.Json.Linq;
namespace MarketSlipApp.Class_s
{
    public class ApiServices
    {
        public async Task<string> LoginAsync(string userName, string password)
        {
            try
            {
                var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password),

            };

                var request = new HttpRequestMessage(
                HttpMethod.Post, GlobalVar.BaseIPaddress + "login?username=" + userName + "&password=" + password);
                request.Content = new FormUrlEncodedContent(keyValues);
                var client = new HttpClient();
                var response = await client.SendAsync(request);
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);

                return content;
            }
            catch (Exception eee)
            {
                return eee.ToString();
            }

        }
        public async Task<string> CustomerNotesAsync(string strCustomernotes, string strguid, string strfilename, string millisecond, string struser, string strRecipient)
        {
            try
            {
                var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("strCustomernotes", strCustomernotes),
                new KeyValuePair<string, string>("strguid", strguid),
                new KeyValuePair<string, string>("strfilename", strfilename),
                new KeyValuePair<string, string>("millisecond", millisecond),
                new KeyValuePair<string, string>("struser",struser),
                new KeyValuePair<string, string>("strRecipient", strRecipient),

            };

                var request = new HttpRequestMessage(
                HttpMethod.Post, GlobalVar.BaseIPaddress + "CustomerNotes?CustomerNotes=" + strCustomernotes + "&strguid=" + strguid + "&strfilename=" + strfilename + "&millisecond=" + millisecond + "&struser=" + struser + "&strRecipient=" + strRecipient);
                request.Content = new FormUrlEncodedContent(keyValues);
                var client = new HttpClient();
                var response = await client.SendAsync(request);
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);

                return content;
            }
            catch (Exception eee)
            {
                return eee.ToString();
            }
        }
    }
}
