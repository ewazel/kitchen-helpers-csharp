using System;

namespace Codecool.KitchenManagement
{
    public class Util
    {
        public static int RandomInt(int minValue, int maxValue)
        {
            Random random = new Random();
            return random.Next(minValue, maxValue);
        }
        
        public static bool RandomBool()
        {
            return Util.RandomInt(0, 2) > 0;
        }
    }
}