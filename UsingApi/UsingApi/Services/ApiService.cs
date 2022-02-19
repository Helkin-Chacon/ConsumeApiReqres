using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UsingApi.Constants;
using UsingApi.Utils;

namespace UsingApi.Services
{
    public class ApiService
    {
        public async Task<ApiResponseModel> GetObject<T>(string controller)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(ApiConstant.ApiBaseUri + controller);
                string result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new ApiResponseModel
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var resultObject = JsonConvert.DeserializeObject<T>(result);
                return new ApiResponseModel
                {
                    IsSuccess = true,
                    Result = resultObject
                };
            }
            catch (Exception ex)
            {
                return new ApiResponseModel
                {
                    IsSuccess = false,
                    Message = ex.ToString()
                };
            }
        }
    }
}
