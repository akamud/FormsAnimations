using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsAnimations
{
    public partial class EasingAnimationPage : ContentPage
    {
        public EasingAnimationPage()
        {
            InitializeComponent();

            button.Clicked += async (sender, e) =>
            {
                await MoveRight(button);
            };

            buttonSinOut.Clicked += async (sender, e) =>
            {
                await MoveRight(buttonSinOut, Easing.SinOut);
            };

            buttonCubicOut.Clicked += async (sender, e) =>
            {
                await MoveRight(buttonCubicOut, Easing.CubicOut);
            };

            buttonBounceOut.Clicked += async (sender, e) =>
            {
                await MoveRight(buttonBounceOut, Easing.BounceOut);
            };

            buttonPlayAll.Clicked += async (sender, e) =>
            {
                await Task.WhenAll(
                    MoveRight(button),
                    MoveRight(buttonSinOut, Easing.SinOut),
                    MoveRight(buttonCubicOut, Easing.CubicOut),
                    MoveRight(buttonBounceOut, Easing.BounceOut),
                    MoveRight(buttonBounceOut, Easing.BounceOut)
                );
            };

            buttonReset.Clicked += (sender, e) =>
            {
                foreach (var view in layout.Children.ToList())
                {
                    view.TranslationX = 0;
                }
            };
        }

        private async Task MoveRight(View view, Easing easing = null)
        {
            view.AnchorX = 0;
            await view.TranslateTo(this.Width - view.Width, 0, 700, easing ?? Easing.Linear);
        }
    }
}
