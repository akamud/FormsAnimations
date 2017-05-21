using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsAnimations.Exemplos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RatingPage : ContentPage
    {
        private List<Image> starStates;

        public RatingPage()
        {
            InitializeComponent();

            starStates = new List<Image>();
            starStates.Add(star1);
            starStates.Add(star2);
            starStates.Add(star3);
            starStates.Add(star4);
            starStates.Add(star5);
        }

        private bool IsSelected(Image star) => (star.Source as FileImageSource).File == "star_selected.png";

        private string SwapState(Image star) => IsSelected(star) ? "star.png" : "star_selected.png";

        private async Task SelectStars(int voting)
        {
            for (int i = voting; i < starStates.Count; i++)
            {
                if (IsSelected(starStates[i]))
                    starStates[i].Source = SwapState(starStates[i]);
            }

            for (int i = 0; i < voting; i++)
            {
                if (App.IsAnimated)
                    starStates[i].Scale = 0.1;

                if (!IsSelected(starStates[i]))
                    starStates[i].Source = SwapState(starStates[i]);

                if (App.IsAnimated)
                    await Task.WhenAny(starStates[i].ScaleTo(1, 500, Easing.SpringOut), Task.Delay(100));
            }
        }

        async void Choose1Star(object sender, EventArgs args) => await SelectStars(1);

        async void Choose2Stars(object sender, EventArgs args) => await SelectStars(2);

        async void Choose3Stars(object sender, EventArgs args) => await SelectStars(3);

        async void Choose4Stars(object sender, EventArgs args) => await SelectStars(4);

        async void Choose5Stars(object sender, EventArgs args) => await SelectStars(5);

    }
}
