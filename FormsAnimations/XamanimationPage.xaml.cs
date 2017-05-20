using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamanimation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsAnimations
{
    public partial class XamanimationPage : TabbedPage
    {
        public XamanimationPage()
        {
            InitializeComponent();

            AnimationExtensionButton.Clicked += (sender, args) =>
            {
                AnimationBox.Animate(new HeartAnimation());
            };
        }
    }
}
