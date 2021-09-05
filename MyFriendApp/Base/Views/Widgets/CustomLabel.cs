using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyFriendApp.Base.Widgets
{
    public class CustomLabel : Label
    {
        public static readonly BindableProperty ContentKeyProperty = 
                BindableProperty.Create(
                    nameof(ContentKey),
                    typeof(string),
                    typeof(CustomLabel)
                    );

        public string ContentKey
        {
            get => (string)GetValue(ContentKeyProperty);
            set
            {
                SetValue(ContentKeyProperty, value);
            }
        }

        public CustomLabel()
        {
            TextColor = Color.Red;
        }
    }
}
