using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs.Configurations;

namespace UsingApi.Controls
{
    public class ConfigurationLoading
    {
        public static MaterialLoadingDialogConfiguration materialLoadingDialogConfiguration()
        {
            var loadingConfig = new MaterialLoadingDialogConfiguration
            {
                BackgroundColor = Color.FromHex("#d668f6"),
                MessageTextColor = Color.White,
                TintColor =  Color.FromHex("#80d7f9"),
                Margin = new Thickness(20, 0, 20, 0),
                CornerRadius = 10,
            };
            return loadingConfig;
        }
    }
}
