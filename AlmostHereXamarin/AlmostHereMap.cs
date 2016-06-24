using System;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Threading.Tasks;
using Plugin.Share;

namespace AlmostHereXamarin
{

    public class AlmostHereMap : ContentPage
	{
        static Map map;
        static Label speed;

        public AlmostHereMap ()
        {
             map = new Map(
                MapSpan.FromCenterAndRadius(
                        new Position(1, 1), Distance.FromMiles(1000)))
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            speed = new Label
            {
                Text = "Currently Traveling at 0 MPH",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            Button share = new Button
            {
                Text = "Share Tracking Link",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            share.Clicked += OnButtonClicked;
            var stack = new StackLayout { Spacing = 5 };
            stack.Children.Add(map);
            stack.Children.Add(speed);
            stack.Children.Add(share);
            Content = stack;

            Console.WriteLine("map rendered");

        }

        internal static void updateMap(Plugin.Geolocator.Abstractions.Position currentPos)
        {

            Distance zoom = new Distance(500);
            Position userLocation = new Position(currentPos.Latitude, currentPos.Longitude);

            map.MoveToRegion(MapSpan.FromCenterAndRadius(userLocation, zoom));
            speed.Text = "Currently Traveling at " + currentPos.Speed + " MPH";

        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            CrossShare.Current.ShareLink("blah", "Share your tracking link", "Almost Here Tracking Link");
        }



    }
}

