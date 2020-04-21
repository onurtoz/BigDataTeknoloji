using BigDataTeknoloji.Business.Model.ExternalModel.LocationIQ;
using BigDataTeknoloji.Business.Model.Model.Response;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigDataTeknoloji.Business.Services.ExternalServices.LocationIQ
{
    public class LocationService : ILocationService
    {
        private RestSharp.RestClient client;
        private readonly LocationIQConfig _config;

        public LocationService(IOptions<LocationIQConfig> config)
        {
            _config = config.Value;
            client = new RestSharp.RestClient(_config.ServiceUrl);
           
        }

        public ServiceResponse<LocationIQModel> GetLocation(string locationName)
        {
            var responseService= new ServiceResponse<LocationIQModel>();
            var req = new RestSharp.RestRequest("v1/search.php", RestSharp.Method.GET);
            req.AddParameter("key",_config.Key);
            req.AddParameter("q", locationName);
            req.AddParameter("format", _config.Format);

            try
            {
                var responseclient = client.Execute(req);

                if (responseclient.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = JsonConvert.DeserializeObject<List<LocationIQModel>>(responseclient.Content);
                    responseService.Entity = content[0];
                }
                else { responseService.ExceptionMessage = System.Net.HttpStatusCode.NotFound.ToString() + "Not Found"; }
            }
            catch (Exception ex)
            {
                responseService.ExceptionMessage = ex.Message;
            }
            return responseService;
        }
    }
}
