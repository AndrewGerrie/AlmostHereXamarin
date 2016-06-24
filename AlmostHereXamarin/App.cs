using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace AlmostHereXamarin
{
	public class App : Application
	{
		public App ()
		{

            MainPage = new AlmostHereMap();
     
            var locator = CrossGeolocator.Current;
            locator.StartListeningAsync(minTime: 30000, minDistance: 0, includeHeading: true);
            locator.PositionChanged += (sender, e) => {
                Location.updateUserLocation(e.Position);
        };

        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
