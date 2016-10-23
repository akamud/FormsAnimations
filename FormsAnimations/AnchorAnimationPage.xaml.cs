using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FormsAnimations
{
    public partial class AnchorAnimationPage : ContentPage
    {
        Point pageCenter;
        double pageRadius;

        public AnchorAnimationPage()
        {
            InitializeComponent();


            buttonAnchor.Clicked += async (sender, e) =>
            {
                buttonAnchor.Rotation = 0;
                buttonAnchor.AnchorY = pageRadius / buttonAnchor.Height;
                await buttonAnchor.RotateTo(360, 1000);
            };
        }

        void OnSizeChanged(object sender, EventArgs args)
        {
            pageCenter = new Point(layout.Width / 2, layout.Height / 2);
            pageRadius = Math.Min(layout.Width, layout.Height) / 2;

            AbsoluteLayout.SetLayoutBounds(buttonAnchor,
                new Rectangle(pageCenter.X - buttonAnchor.Width / 2, pageCenter.Y - pageRadius,
                    AbsoluteLayout.AutoSize,
                    AbsoluteLayout.AutoSize));
        }
    }
}
