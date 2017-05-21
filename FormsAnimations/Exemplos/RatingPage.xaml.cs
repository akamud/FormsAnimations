using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamanimation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsAnimations.Exemplos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RatingPage : ContentPage
    {
        private List<Image> starStates;
        private bool givenCompliment = false;

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

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (App.IsAnimatedBonitao)
            {
                for (int i = 0; i < starStates.Count; i++)
                {
                    starStates[i].Scale = 0.2;
                    await Task.WhenAny(starStates[i].ScaleTo(1, 500, Easing.SpringOut), Task.Delay(100));
                }
            }
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
                    await Task.WhenAny(starStates[i].ScaleTo(1, 500, GetEasing(Easing.SpringOut)), Task.Delay(100));
            }
        }

        async void Choose1Star(object sender, EventArgs args) => await SelectStars(1);

        async void Choose2Stars(object sender, EventArgs args) => await SelectStars(2);

        async void Choose3Stars(object sender, EventArgs args) => await SelectStars(3);

        async void Choose4Stars(object sender, EventArgs args) => await SelectStars(4);

        async void Choose5Stars(object sender, EventArgs args)
        {
            await SelectStars(5);

            if (App.IsAnimated)
            {
                await complimentBox.FadeTo(1, 250, Easing.CubicIn);
            }
            else
            {
                complimentBox.Opacity = 1;
            }

            if (App.IsAnimatedBonitao)
            {
                var heartAnimation = new HeartAnimation();
                while (!givenCompliment)
                {
                    await plus.Animate(heartAnimation);
                    await Task.Delay(3000);
                }
            }
        }

        async void GiveCompliment(object sender, EventArgs args)
        {
            givenCompliment = true;

            var atendimentoTranslationX = -80;
            var servicoTranslationX = -35;
            var musicaTranslationX = 115;

            var atendimentoScale = 1.5;
            var servicoScale = 1.5;
            var musicaScale = 5;

            if (!App.IsAnimated)
            {
                plus.Scale = 0;

                atendimento.Scale = atendimentoScale;
                atendimento.TranslationX = atendimentoTranslationX;

                servico.Scale = servicoScale;
                servico.TranslationX = servicoTranslationX;

                musica.Scale = musicaScale;
                musica.TranslationX = musicaTranslationX;
            }
            else
            {
                if (App.IsAnimatedBonitao)
                {
                    await Task.WhenAny(
                        plus.ScaleTo(0, 200, GetEasing(Easing.SpringIn)),
                        atendimento.TranslateTo(atendimentoTranslationX, 0, 500, GetEasing(Easing.SpringOut)),
                        atendimento.ScaleTo(atendimentoScale, 500, GetEasing(Easing.SpringOut)),
                        servico.TranslateTo(servicoTranslationX, 0, 500, GetEasing(Easing.SpringOut)),
                        servico.ScaleTo(servicoScale, 500, GetEasing(Easing.SpringOut)),
                        musica.TranslateTo(musicaTranslationX, 0, 500, GetEasing(Easing.SpringOut)),
                        musica.ScaleTo(musicaScale, 500, GetEasing(Easing.SpringOut)),
                        Task.Delay(100)
                    );
                }
                else
                {
                    await plus.ScaleTo(0, 100, GetEasing(Easing.SpringIn));

                    await atendimento.TranslateTo(atendimentoTranslationX, 0, 100, GetEasing(Easing.SpringOut));
                    await atendimento.ScaleTo(atendimentoScale, 100, GetEasing(Easing.SpringOut));

                    await servico.TranslateTo(servicoTranslationX, 0, 100, GetEasing(Easing.SpringOut));
                    await servico.ScaleTo(servicoScale, 100, GetEasing(Easing.SpringOut));

                    await musica.TranslateTo(musicaTranslationX, 0, 100, GetEasing(Easing.SpringOut));
                    await musica.ScaleTo(musicaScale, 100, GetEasing(Easing.SpringOut));
                }
            }
        }

        private Easing GetEasing(Easing defaultEasing) => App.IsAnimatedBonitao ? defaultEasing : Easing.Linear;
    }
}
