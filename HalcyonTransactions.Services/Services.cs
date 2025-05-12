using HalcyonCore.SharedEntities;
using Newtonsoft.Json;
using System.Text;

namespace HalcyonTransactions.Services
{
    public class Services : IServices
    {
        private HttpClient _httpClient;
        private readonly ApplicationSettings _applicationSettings;
        public Services(HttpClient httpClient, ApplicationSettings applicationSettings)
        {
            _httpClient = httpClient;
            _applicationSettings = applicationSettings;
        }


        public async Task<string> ReturnDashboardData()
        {
            try
            {
                DashBoard result = new DashBoard();
                string url = "https://halcyontransactions.azurewebsites.net/api/GetDashBoardData?code=fXB5yroHKAH8GBb3M9VouDv2WTNjOR0AeBa_McAn6i6bAzFuJ2yxJg%3D%3D";
                string? deviceName = _applicationSettings?.DeviceName;

                if (string.IsNullOrEmpty(deviceName))
                {
                    deviceName = "Halcyon";
                }

                WorkTaskModel model = new WorkTaskModel();
                model.DeviceName = deviceName;
                string content = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(url, stringContent);

                return response.Content.ReadAsStringAsync().Result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
