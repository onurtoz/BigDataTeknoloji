using BigDataTeknoloji.Business.Model.ExternalModel.LocationIQ;
using BigDataTeknoloji.Business.Model.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigDataTeknoloji.Business.Services.ExternalServices.LocationIQ
{
    public interface ILocationService
    {
        ServiceResponse<LocationIQModel> GetLocation(string locationName);
    }
}
