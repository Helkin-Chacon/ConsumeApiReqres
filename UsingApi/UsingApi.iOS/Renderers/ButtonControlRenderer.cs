using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using UsingApi.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Material.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Button), typeof(ButtonControlRenderer), new[] { typeof(VisualMarker.MaterialVisual) })]


namespace UsingApi.iOS.Renderers
{
    internal class ButtonControlRenderer : MaterialButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.UppercaseTitle = false;
            }
        }
    }
}