using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDrivingCar
{
    internal class CompassHelper
    {
        private static char[] Directions = { Constants.N, Constants.E, Constants.S, Constants.W };
        public static char DegreesToCompass(int degree)
        {
            
            var formula = (degree % 360) / 90;
            return Directions[formula];
        }

        public static int CompassToDegrees(char direction)
        {
            var index = Array.IndexOf(Directions, direction);
            return index * 90;
        }
    }
}
