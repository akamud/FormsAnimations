using System;
using System.Collections.Generic;

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
        }

        double RandomEase(double t)
            => t == 0 || t == 1 ? t : t + 0.25 * (random.NextDouble() - 0.5);
    }
}
