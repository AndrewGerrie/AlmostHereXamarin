using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;

namespace AlmostHereXamarin
{
	public class AlmostHereMap : ContentPage
	{
		public AlmostHereMap ()
        {
            var map = new Map(
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
    }
}

