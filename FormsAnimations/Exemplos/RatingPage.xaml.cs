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
        private HeartAnimation heartAnimation;

        public RatingPage()
        {
            InitializeComponent();

            ((NavigationPage)App.Current.MainPage).BarBackgroundColor = Color.FromHex("010101");

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
                // TODO: Focar estrelas na abertura para estimular o voto
            }
        }

        private bool IsSelected(Image star) => (star.Source as FileImageSource).File == "star_selected.png";

        private string SwapState(Image star) => IsSelected(star) ? "star.png" : "star_selected.png";

        private async Task SelectStars(int voting)
        {
            ClearStars(voting);

            for (int i = 0; i < voting; i++)
            {
                starStates[i].Scale = 0.1;

                if (!IsSelected(starStates[i]))
                    starStates[i].Source = SwapState(starStates[i]);

                if (App.IsAnimated)
                {
                    // TODO: Estrelas selecionadas com animação
                }
                else
                    starStates[i].Scale = 1;
            }
        }

        private void ClearStars(int voting)
        {
            for (int i = voting; i < starStates.Count; i++)
            {
                if (IsSelected(starStates[i]))
                    starStates[i].Source = SwapState(starStates[i]);
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
                // TODO: Exibir a caixa de elogios com Cubic 250
            }
            else
            {
                complimentBox.Opacity = 1;
            }

            if (App.IsAnimatedBonitao)
            {
                if (heartAnimation == null)
                {
                    // TODO: Animação para estimular elogios
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
                elogio.Scale = 0;

                atendimento.Scale = atendimentoScale;
                atendimento.TranslationX = atendimentoTranslationX;

                servico.Scale = servicoScale;
                servico.TranslationX = servicoTranslationX;

                musica.Scale = musicaScale;
                musica.TranslationX = musicaTranslationX;
            }
            else
            {
                elogio.AbortAnimation("Hearth");

                if (App.IsAnimatedBonitao)
                {
                    // TODO: Sumir botão de elogio SpringIn
                    // TODO: Movers elementos de elogios e escalonar simultaneamente
                }
                else
                {
                    await elogio.ScaleTo(0, 100, GetEasing(Easing.SpringIn));

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
