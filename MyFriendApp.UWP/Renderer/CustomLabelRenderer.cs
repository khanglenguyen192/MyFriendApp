using MyFriendApp.Base.Widgets;
using MyFriendApp.UWP.Renderer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer))]
namespace MyFriendApp.UWP.Renderer
{
    public class CustomLabelRenderer : LabelRenderer
    {
        public CustomLabelRenderer() : base()
        {

        }

        protected virtual void OnContentKeyChanged()
        {
            var key = ((CustomLabel)Element).ContentKey;

            if (string.IsNullOrEmpty(key))
                return;
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Label> e)
        {
            base.OnElementChanged(e);

            if (Element != null)
            {
                OnContentKeyChanged();
            }
        }
    }
}
