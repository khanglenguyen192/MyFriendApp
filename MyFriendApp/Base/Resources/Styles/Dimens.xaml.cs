using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyFriendApp.Base.Styles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dimens : ResourceDictionary
    {
        public Dimens()
        {
            InitializeComponent();
        }
    }
}