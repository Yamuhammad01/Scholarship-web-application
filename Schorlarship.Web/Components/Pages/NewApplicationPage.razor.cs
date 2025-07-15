using Microsoft.AspNetCore.Components;
using Schorlarship.ViewModels;
using System.Text.Json;
using System.Text;

namespace Schorlarship.Web.Components.Pages
{
    public partial class NewApplicationPage
    {
        public RegistrationVm registration { get; set; } = new();
        [Inject] HttpClient HttpClient { get; set; } = new HttpClient();

        public async Task SubmitRegistration(RegistrationVm regVm)
        {
            var regDatails = regVm;
            // call you api and pass the detail to the api
            var jsonRegDatails = JsonSerializer.Serialize(regDatails);
            var apiurl = "https://localhost:7020/api/Scholarship/CreateRegistration";
           var response = await HttpClient.PostAsync(apiurl, new StringContent(jsonRegDatails, Encoding.UTF8,  "application/json"));


        }

    }
}