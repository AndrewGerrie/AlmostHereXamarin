using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace AlmostHereXamarin
{
    class Location
    {
        internal string _id;

        internal static void updateUserLocation(Position pos)
        {
            ServerInteraction.updateRemoteLocation(pos.Longitude, pos.Latitude, pos.Speed);
            updateMap(pos);
        }

        internal static void updateMap(Position CurrentPos)
        {
            AlmostHereMap.updateMap(CurrentPos);

        }
    }
}
