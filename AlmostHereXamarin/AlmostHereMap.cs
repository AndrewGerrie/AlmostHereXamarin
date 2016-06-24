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
            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            Content = stack;

            Console.WriteLine("map rendered");

        }

        internal static void updateMap(Plugin.Geolocator.Abstractions.Position currentPos)
        {

            Console.WriteLine("incoming lat" + currentPos.Latitude);

            Distance zoom = new Distance(500);
            Position userLocation = new Position(currentPos.Latitude, currentPos.Longitude);

            map.MoveToRegion(MapSpan.FromCenterAndRadius(userLocation, zoom));

            Console.WriteLine("moving map to " + userLocation.Latitude);
        }

   

    }
}

