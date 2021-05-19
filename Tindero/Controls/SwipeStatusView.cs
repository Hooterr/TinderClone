using System;
using Tindero.Models;
using Xamarin.Forms;

namespace Tindero.Controls
{
    public class SwipeStatusView : ContentView
    {
        public static readonly BindableProperty StatusProperty = BindableProperty.Create(
            nameof(Status),
            typeof(SwipeStatus),
            typeof(SwipeStatusView),
            SwipeStatus.None,
            propertyChanged: StatusPropertyChanged);

        private static void StatusPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is SwipeStatusView control)
            {
                control.HandleStatusChanged();
            }
        }

        public SwipeStatus Status
        {
            get => (SwipeStatus)GetValue(StatusProperty);
            set => SetValue(StatusProperty, value);
        }

        private readonly Button content;

        public SwipeStatusView()
        {
            content = new Button()
            {
                BackgroundColor = Color.Transparent,
                BorderWidth = 5,
                TextTransform = TextTransform.Uppercase,
                CornerRadius = 5,
            };

            Content = content;
        }

        private void HandleStatusChanged()
        {
            switch (Status)
            {
                case SwipeStatus.None:
                    content.IsVisible = false;
                    break;
                case SwipeStatus.Like:
                    content.Text = "like";
                    content.BorderColor = (Color)Application.Current.Resources["Green"];
                    content.TextColor = (Color)Application.Current.Resources["Green"];
                    content.Rotation = -45;
                    HorizontalOptions = LayoutOptions.Start;
                    content.IsVisible = true;
                    break;
                case SwipeStatus.SuperLike:
                    content.Text = "super like";
                    content.BorderColor = (Color)Application.Current.Resources["Blue"];
                    content.TextColor = (Color)Application.Current.Resources["Blue"];
                    content.Rotation = -45;
                    HorizontalOptions = LayoutOptions.Start;
                    content.IsVisible = true;
                    break;
                case SwipeStatus.Nope:

                    content.Text = "nope";
                    content.BorderColor = (Color)Application.Current.Resources["Primary"];
                    content.TextColor = (Color)Application.Current.Resources["Primary"];
                    content.Rotation = 45;
                    HorizontalOptions = LayoutOptions.End;
                    content.IsVisible = true;
                    break;
            }
        }
    }
}
