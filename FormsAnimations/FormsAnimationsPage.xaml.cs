using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsAnimations
{
    public partial class FormsAnimationsPage : ContentPage
    {
        public FormsAnimationsPage()
        {
            InitializeComponent();

            btnBasicAnimation.Clicked += async (sender, e) => await Navigation.PushAsync(new BasicAnimationPage());
            btnAnchorAnimation.Clicked += async (sender, e) => await Navigation.PushAsync(new AnchorAnimationPage());
            btnEasingAnimation.Clicked += async (sender, e) => await Navigation.PushAsync(new EasingAnimationPage());
            btnEasingAnimation2.Clicked += async (sender, e) => await Navigation.PushAsync(new EasingAnimation2Page());
            btnSlidingEntrance.Clicked += async (sender, e) => await Navigation.PushAsync(new SlidingEntrancePage(), false);
            btnXamanimation.Clicked += async (sender, e) => await Navigation.PushAsync(new XamanimationPage());
            btnExamples.Clicked += async (sender, e) => await Navigation.PushAsync(new ExamplesPage());
        }
    }
}

