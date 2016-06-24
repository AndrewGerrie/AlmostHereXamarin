using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;
using AlmostHereXamarin;

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
            var stack = new StackLayout { Spacing = 10 };
            stack.Children.Add(map);
            stack.Children.Add(speed);
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

   

    }
}

