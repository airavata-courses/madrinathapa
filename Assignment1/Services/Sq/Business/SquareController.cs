using System;
using System.Globalization;
using Square_Service.Entities;

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
				EnSquare objSq = new EnSquare();
				objSq.Side = s;
				objSq.Area = s * s;
                result = Newtonsoft.Json.JsonConvert.SerializeObject(objSq);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return result;
        }
    }
}
