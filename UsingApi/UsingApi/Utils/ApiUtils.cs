using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UsingApi.Models;
using UsingApi.Services;

namespace UsingApi.Utils
{
    public class ApiUtils
    {
        public static async Task<GroupUserModel> GetProductsByPage(ApiService apiService, int page)
        {
            ApiResponseModel apiResponse = await apiService.GetObject<GroupUserModel>("users?page=" + page.ToString());
            if (!apiResponse.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Alerta", apiResponse.Message, "Aceptar");
                return null;
            }
            GroupUserModel infoReturn = (GroupUserModel)apiResponse.Result;
            return infoReturn;
        }

    }
    //(https://reqres.in/api/users?page=1).
}
