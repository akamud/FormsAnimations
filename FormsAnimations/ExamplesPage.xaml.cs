using FormsAnimations.Exemplos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsAnimations
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExamplesPage : ContentPage
    {
        public ExamplesPage()
        {
            InitializeComponent();

            isAnimatedSwitch.IsToggled = App.IsAnimated;
            isAnimatedBonitaoSwitch.IsToggled = App.IsAnimatedBonitao;
            btnRating.Clicked += async (sender, e) => await GoToPage(new RatingPage());
        }

        private async Task GoToPage(Page page)
        {
            App.IsAnimated = isAnimatedSwitch.IsToggled;
            App.IsAnimatedBonitao = isAnimatedBonitaoSwitch.IsToggled;

            await Navigation.PushAsync(page);
        }
    }
}
