using System;
using System.Globalization;

namespace Square_Service.Business
{
    public class SquareController
    {
        public string GetSquareArea(string side)
        {
            string result = string.Empty;
            try
            {
                float s = float.Parse(side, CultureInfo.InvariantCulture.NumberFormat);
                float area = s * s;
                result = "Area of a square with side " + side + " is: " + area;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return result;
        }
    }
}
