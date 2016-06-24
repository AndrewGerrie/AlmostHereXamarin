using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace AlmostHereXamarin
{
    class Location
    {

        internal static void updateUserLocation(Position pos)
        {

            Console.WriteLine("speed" + pos.Speed);
            ServerInteraction.updateRemoteLocation(pos.Longitude, pos.Latitude, pos.Speed);
            updateMap(pos);
        }

        internal static void updateMap(Position CurrentPos)
        {
            AlmostHereMap.updateMap(CurrentPos);

        }
    }
}
