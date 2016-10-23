using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsAnimations
{
    public partial class EasingAnimation2Page : ContentPage
    {
        Random random = new Random();

        public EasingAnimation2Page()
        {
            InitializeComponent();

            button.Clicked += async (sender, e) =>
            {
                double scale = Math.Min(Width / buttonCustom.Width, Height / buttonCustom.Height);

                await button.ScaleTo(scale, 1000, Easing.CubicOut);
            };

            buttonInOut.Clicked += async (sender, e) =>
            {
                double scale = Math.Min(Width / buttonCustom.Width, Height / buttonCustom.Height);

                await buttonInOut.ScaleTo(scale, 1000, Easing.CubicInOut);
                await buttonInOut.ScaleTo(1, 1000, Easing.CubicIn);
            };

            buttonCustom.Clicked += async (sender, e) =>
            {
                double scale = Math.Min(Width / buttonCustom.Width, Height / buttonCustom.Height);
                    
                await buttonCustom.ScaleTo(scale, 1000, new Easing(t => (int)(5 * t) / 5.0));
                await buttonCustom.ScaleTo(1, 1000, (Easing)RandomEase);
            };

            buttonDrop.Clicked += async (sender, e) =>
            {
                await FallOverAnimation();
            };
        }

        double RandomEase(double t)
            => t == 0 || t == 1 ? t : t + 0.25 * (random.NextDouble() - 0.5);

        async Task FallOverAnimation()
        {
            var navigationHeight = 170;

            buttonDrop.AnchorX = 0;
            buttonDrop.AnchorY = 1;
            await buttonDrop.RotateTo(90, 3000, CustomEasing());
            await buttonDrop.TranslateTo(0, Height - buttonDrop.Height / 2 - buttonDrop.Width - navigationHeight,
                                           1000, Easing.BounceOut); // BounceOut
        }

        private Easing CustomEasing()
            => new Easing(t => 1 - Math.Cos(10 * Math.PI * t) * Math.Exp(-5 * t));
    }
}
