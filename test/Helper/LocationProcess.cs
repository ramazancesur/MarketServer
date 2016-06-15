using Geocoding;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace test.Helper
{
    public class LocationProcess
    {
        /// <summary>
        /// İki konum arası mesafe hesaplama
        /// </summary>
        /// <param name="lat1">Bulunulan Enlem</param>
        /// <param name="lon1">Bulunulan Boylam</param>
        /// <param name="lat2">Hedef(Market) Enlem </param>
        /// <param name="lon2">Hedef (Market) Boylam</param>
        /// <param name="unit">'M' is statute miles (default)  'K' is kilometers  'N' is nautical miles  </param>
        /// <returns></returns>

        public double distance(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            Location currentLocation = new Location(lat1, lon1);
            Location marketLocation = new Location(lat2, lon2);
            return currentLocation.DistanceBetween(marketLocation, DistanceUnits.Kilometers).Value;
        
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts decimal degrees to radians             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts radians to decimal degrees             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }



        public double ConvertDegreeAngleToDouble(string point)
        {
            //Example: 17.21.18S

            var multiplier = (point.Contains("S") || point.Contains("W")) ? -1 : 1; //handle south and west

            point = Regex.Replace(point, "[^0-9.]", ""); //remove the characters

            var pointArray = point.Split('.'); //split the string.

            //Decimal degrees = 
            //   whole number of degrees, 
            //   plus minutes divided by 60, 
            //   plus seconds divided by 3600

            var degrees = Double.Parse(pointArray[0]);
            var minutes = Double.Parse(pointArray[1]) / 60;
            var seconds = Double.Parse(pointArray[2]) / 3600;

            return (degrees + minutes + seconds) * multiplier;
        }

      
    }
}