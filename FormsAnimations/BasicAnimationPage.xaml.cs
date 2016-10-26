using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsAnimations
{
    public partial class BasicAnimationPage : ContentPage
    {
        public BasicAnimationPage()
        {
            InitializeComponent();

            button.Clicked += async (sender, e) =>
            {
                button.Rotation = 0;
                await button.RotateTo(360);
            };

            buttonTempo.Clicked += async (sender, e) =>
            {
                //button.Rotation = 0;
                await buttonTempo.RotateTo(360, 2000);
            };

            buttonRelative.Clicked += async (sender, e) =>
            {
                //buttonRelative.Rotation = 0;
                await buttonRelative.RelRotateTo(90, 1000);
            };

            buttonComposto.Clicked += async (sender, e) =>
            {
                buttonComposto.Text = "RotateTo 90";
                await buttonComposto.RotateTo(90, 500);
                buttonComposto.Text = "RotateTo -90";
                await buttonComposto.RotateTo(-90, 1000);
                buttonComposto.Text = "RotateTo 0";
                await buttonComposto.RotateTo(0, 500);
            };

            buttonSimultaneo.Clicked += async (sender, e) =>
            {
                buttonSimultaneo.Rotation = 0;

                //await Task.WhenAny<bool>(
                //    buttonSimultaneo.RotateTo(360, 2000),
                //    buttonSimultaneo.ScaleTo(5, 1000)
                //);

                await buttonSimultaneo.RotateTo(360, 2000);
                await buttonSimultaneo.ScaleTo(5, 1000);

                await buttonSimultaneo.ScaleTo(1, 1000);
            };

            buttonFade.Clicked += async (sender, e) =>
            {
                await buttonFade.FadeTo(0, 1000);
                await buttonFade.FadeTo(1, 1000);
            };

            buttonShake.Clicked += async (sender, e) => await Shake(buttonShake);

            //buttonShakeEasing.Clicked += async (sender, e) => await ShakeEasing(buttonShakeEasing);
        }

        private async Task Shake(VisualElement view)
        {
            await view.TranslateTo(5, 0, 25);
            await view.TranslateTo(-5, 0, 50);
            await view.TranslateTo(5, 0, 50);
            await view.TranslateTo(-5, 0, 50);
            await view.TranslateTo(5, 0, 50);
            await view.TranslateTo(0, 0, 25);
        }

        //private async Task ShakeEasing(VisualElement view)
        //{
        //    await view.TranslateTo(5, 0, 25, Easing.SinIn);
        //    await view.TranslateTo(-5, 0, 50, Easing.SinInOut);
        //    await view.TranslateTo(5, 0, 50, Easing.SinInOut);
        //    await view.TranslateTo(-5, 0, 50, Easing.SinInOut);
        //    await view.TranslateTo(5, 0, 50, Easing.SinInOut);
        //    await view.TranslateTo(0, 0, 25, Easing.SinOut);
        //}
    }
}
