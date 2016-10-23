using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsAnimations
{
    public partial class FormsAnimationsPage : ContentPage
    {
        Random random = new Random();

        public FormsAnimationsPage()
        {
            InitializeComponent();

            btnBasicAnimation.Clicked += async (sender, e) => await Navigation.PushAsync(new BasicAnimationPage());

            //btnAnimation.Clicked += async (sender, e) =>
            //{
            //    //await btnAnimation.RotateTo(90, 250, Easing.SinIn);
            //    //await btnAnimation.RotateTo(-90, 500, Easing.SinInOut);
            //    //await btnAnimation.RotateTo(0, 250, Easing.SinOut);

            //    //double scale = Math.Min(Width / btnAnimation.Width, Height / btnAnimation.Height);
            //    //await btnAnimation.ScaleTo(scale, 1000, new Easing(t => (int)(5 * t) / 5.0));
            //    //await btnAnimation.ScaleTo(1, 1000, (Easing)RandomEase);

            //    await FallOverAnimation();
            //};
        }

        //async Task FallOverAnimation()
        //{
        //    btnAnimation.AnchorX = 0;
        //    btnAnimation.AnchorY = 1;
        //    await btnAnimation.RotateTo(90, 3000,
        //                                new Easing(t => 1 - Math.Cos(10 * Math.PI * t)
        //                                           * Math.Exp(-5 * t)));
        //    await btnAnimation.TranslateTo(0, Height - btnAnimation.Height / 2 - btnAnimation.Width,
        //                                   1000, Easing.BounceOut);

        //    btnAnimation.AnchorX = 1;
        //    btnAnimation.AnchorY = 0;
        //    btnAnimation.TranslationX -= btnAnimation.Width - btnAnimation.Height;
        //    btnAnimation.TranslationY += btnAnimation.Width - btnAnimation.Height;

        //    await btnAnimation.RotateTo(180, 1000, Easing.BounceOut);
        //}

        //double RandomEase(double t)
        //    => t == 0 || t == 1 ? t : t + 0.25 * (random.NextDouble() - 0.5);
    }
}

