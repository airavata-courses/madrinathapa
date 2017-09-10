using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace SgaApi.Business
{
    public class HttpCall
    {
        public string GetGreetingAsync(string name)
        {
            try
            {
                Publisher objPub = new Publisher();
                objPub.SendMessage("greet", name);

                string response = "";
                return response;
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }

        public string GetCircleArea(float radius)
        {
            try
			{
				Publisher objPub = new Publisher();
                objPub.SendMessage("circle", radius.ToString());
				Consumer objConsume = new Consumer();
				string response = objConsume.ConsumeMessage("circleresponse");
				return response;
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }

        public string GetSquareArea(float side)
        {
            try
			{
				Publisher objPub = new Publisher();
                objPub.SendMessage("square", side.ToString());
                Consumer objConsume = new Consumer();
                string response = objConsume.ConsumeMessage("squareresponse");
                return response;
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
