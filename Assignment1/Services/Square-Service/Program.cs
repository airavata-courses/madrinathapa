﻿using Square_Service.Business;

namespace Square_Service
{
    class Program
    {
        static void Main(string[] args)
        {
            StartProcess();
        }
        public static void StartProcess(){
            Consumer objConsume = new Consumer();
            objConsume.ConsumeMessage();
        }
    }
}
