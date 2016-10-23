using System;

using Xamarin.Forms;

namespace FormsAnimations
{
    public class AnchorAnimationsPage : ContentPage
    {
        public AnchorAnimationsPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

