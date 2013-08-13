using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StageKit;

namespace StageKitTest
{
    [TestClass]
    public class StageKitTest
    {
        [TestMethod]
        public void TestFog()
        {
            //StageKitController controller = new StageKitController(1);
            //controller.TurnFogOn();
            //System.Threading.Thread.Sleep(1000);
            //controller.TurnFogOff();
        }

        [TestMethod]
        public void TestStrobe()
        {
            /*StageKitController controller = new StageKitController(1);
            controller.TurnStrobeOn(StrobeSpeed.Slow);
            System.Threading.Thread.Sleep(1000);
            controller.TurnStrobeOn(StrobeSpeed.Medium);
            System.Threading.Thread.Sleep(1000);
            controller.TurnStrobeOn(StrobeSpeed.Faster);
            System.Threading.Thread.Sleep(1000);
            controller.TurnStrobeOn(StrobeSpeed.Fastest);
            System.Threading.Thread.Sleep(1000);
            controller.TurnStrobeOff();*/
        }

        [TestMethod]
        public void TestLeds()
        {
            StageKitController controller = new StageKitController(1);
            LedDisplay display = new LedDisplay();

            //display.RedLedArray.Led1 = true;
            //controller.DisplayLeds(display);
            controller.DisplayRedLed1(ref display, true);
            System.Threading.Thread.Sleep(100);
            controller.DisplayGreenLed1(ref display, true);
            System.Threading.Thread.Sleep(100);
            controller.DisplayRedLed1(ref display, true);
            System.Threading.Thread.Sleep(100);
            controller.DisplayYellowLed1(ref display, true);


            System.Threading.Thread.Sleep(100);
            display.RedLedArray.Led2 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.RedLedArray.Led3 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.RedLedArray.Led4 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.RedLedArray.Led5 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.RedLedArray.Led6 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.RedLedArray.Led7 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.RedLedArray.Led8 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);

            display.YellowLedArray.Led1 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.YellowLedArray.Led2 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.YellowLedArray.Led3 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.YellowLedArray.Led4 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.YellowLedArray.Led5 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.YellowLedArray.Led6 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.YellowLedArray.Led7 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.YellowLedArray.Led8 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);

            display.GreenLedArray.Led1 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.GreenLedArray.Led2 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.GreenLedArray.Led3 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.GreenLedArray.Led4 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.GreenLedArray.Led5 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.GreenLedArray.Led6 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.GreenLedArray.Led7 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.GreenLedArray.Led8 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);

            display.BlueLedArray.Led1 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.BlueLedArray.Led2 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.BlueLedArray.Led3 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.BlueLedArray.Led4 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.BlueLedArray.Led5 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.BlueLedArray.Led6 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.BlueLedArray.Led7 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.BlueLedArray.Led8 = true;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);

            display.RedLedArray.Led1 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.RedLedArray.Led2 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.RedLedArray.Led3 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.RedLedArray.Led4 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.RedLedArray.Led5 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.RedLedArray.Led6 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.RedLedArray.Led7 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.RedLedArray.Led8 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);

            display.YellowLedArray.Led1 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.YellowLedArray.Led2 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.YellowLedArray.Led3 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.YellowLedArray.Led4 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.YellowLedArray.Led5 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.YellowLedArray.Led6 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.YellowLedArray.Led7 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.YellowLedArray.Led8 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);

            display.GreenLedArray.Led1 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.GreenLedArray.Led2 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.GreenLedArray.Led3 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.GreenLedArray.Led4 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.GreenLedArray.Led5 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.GreenLedArray.Led6 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.GreenLedArray.Led7 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.GreenLedArray.Led8 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);

            display.BlueLedArray.Led1 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.BlueLedArray.Led2 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.BlueLedArray.Led3 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.BlueLedArray.Led4 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.BlueLedArray.Led5 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.BlueLedArray.Led6 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.BlueLedArray.Led7 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);
            display.BlueLedArray.Led8 = false;
            controller.DisplayLeds(display);
            System.Threading.Thread.Sleep(100);

            controller.TurnAllOff();
        }
    }
}
