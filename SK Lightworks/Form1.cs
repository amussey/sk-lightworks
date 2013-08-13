using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StageKit;
using System.IO;
using System.Net;


namespace SK_Lightworks
{
    public partial class Form1 : Form
    {

        StageKitController controller;
        LedDisplay display;
        Random random;
        int led_delay;

        bool led_red_circle_bool;
        bool led_blue_circle_bool;
        bool led_green_circle_bool;
        bool led_yellow_circle_bool;
        Thread led_red_circle_thread;
        Thread led_blue_circle_thread;
        Thread led_green_circle_thread;
        Thread led_yellow_circle_thread;


        bool led_red_laser_bool;
        bool led_blue_laser_bool;
        bool led_green_laser_bool;
        bool led_yellow_laser_bool;
        Thread led_red_laser_thread;
        Thread led_blue_laser_thread;
        Thread led_green_laser_thread;
        Thread led_yellow_laser_thread;


        bool led_red_rand_bool;
        bool led_blue_rand_bool;
        bool led_green_rand_bool;
        bool led_yellow_rand_bool;
        Thread led_red_rand_thread;
        Thread led_blue_rand_thread;
        Thread led_green_rand_thread;
        Thread led_yellow_rand_thread;

        bool led_red_all_bool;
        bool led_blue_all_bool;
        bool led_green_all_bool;
        bool led_yellow_all_bool;
        Thread led_red_all_thread;
        Thread led_blue_all_thread;
        Thread led_green_all_thread;
        Thread led_yellow_all_thread;

        int fog_burst_length;
        Thread fog_thread;

        


        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
            display = new LedDisplay();
            controller = new StageKitController(1);
            random = new Random();
            led_delay = 50;


            led_yellow_circle_bool = false;
            led_red_circle_bool    = false;
            led_blue_circle_bool   = false;
            led_green_circle_bool  = false;

            led_yellow_laser_bool  = false;
            led_red_laser_bool     = false;
            led_blue_laser_bool    = false;
            led_green_laser_bool   = false;

            led_yellow_rand_bool   = false;
            led_red_rand_bool      = false;
            led_blue_rand_bool     = false;
            led_green_rand_bool    = false;

            led_yellow_all_bool    = false;
            led_red_all_bool       = false;
            led_blue_all_bool      = false;
            led_green_all_bool     = false;

            fog_burst_length = 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult result = MessageBox.Show("Really close SK Lightworks?", string.Empty, MessageBoxButtons.YesNo);

            if (result == DialogResult.No) {
                e.Cancel = true;
            } else {
                kill_all_helper();
            }
        }



        private void led_red_led1_state(bool s) { controller.DisplayRedLed1(ref display, s); led_red_led1.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Red" + (display.RedLedArray.Led1 ? "On" : "Off" ) + "1.png"); }
        private void led_red_led2_state(bool s) { controller.DisplayRedLed2(ref display, s); led_red_led2.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Red" + (display.RedLedArray.Led2 ? "On" : "Off" ) + "2.png"); }
        private void led_red_led3_state(bool s) { controller.DisplayRedLed3(ref display, s); led_red_led3.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Red" + (display.RedLedArray.Led3 ? "On" : "Off" ) + "3.png"); }
        private void led_red_led4_state(bool s) { controller.DisplayRedLed4(ref display, s); led_red_led4.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Red" + (display.RedLedArray.Led4 ? "On" : "Off" ) + "4.png"); }
        private void led_red_led5_state(bool s) { controller.DisplayRedLed5(ref display, s); led_red_led5.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Red" + (display.RedLedArray.Led5 ? "On" : "Off" ) + "5.png"); }
        private void led_red_led6_state(bool s) { controller.DisplayRedLed6(ref display, s); led_red_led6.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Red" + (display.RedLedArray.Led6 ? "On" : "Off" ) + "6.png"); }
        private void led_red_led7_state(bool s) { controller.DisplayRedLed7(ref display, s); led_red_led7.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Red" + (display.RedLedArray.Led7 ? "On" : "Off" ) + "7.png"); }
        private void led_red_led8_state(bool s) { controller.DisplayRedLed8(ref display, s); led_red_led8.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Red" + (display.RedLedArray.Led8 ? "On" : "Off" ) + "8.png"); }
        private void led_yellow_led1_state(bool s) { controller.DisplayYellowLed1(ref display, s); led_yellow_led1.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Yellow" + (display.YellowLedArray.Led1 ? "On" : "Off") + "1.png"); }
        private void led_yellow_led2_state(bool s) { controller.DisplayYellowLed2(ref display, s); led_yellow_led2.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Yellow" + (display.YellowLedArray.Led2 ? "On" : "Off") + "2.png"); }
        private void led_yellow_led3_state(bool s) { controller.DisplayYellowLed3(ref display, s); led_yellow_led3.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Yellow" + (display.YellowLedArray.Led3 ? "On" : "Off") + "3.png"); }
        private void led_yellow_led4_state(bool s) { controller.DisplayYellowLed4(ref display, s); led_yellow_led4.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Yellow" + (display.YellowLedArray.Led4 ? "On" : "Off") + "4.png"); }
        private void led_yellow_led5_state(bool s) { controller.DisplayYellowLed5(ref display, s); led_yellow_led5.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Yellow" + (display.YellowLedArray.Led5 ? "On" : "Off") + "5.png"); }
        private void led_yellow_led6_state(bool s) { controller.DisplayYellowLed6(ref display, s); led_yellow_led6.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Yellow" + (display.YellowLedArray.Led6 ? "On" : "Off") + "6.png"); }
        private void led_yellow_led7_state(bool s) { controller.DisplayYellowLed7(ref display, s); led_yellow_led7.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Yellow" + (display.YellowLedArray.Led7 ? "On" : "Off") + "7.png"); }
        private void led_yellow_led8_state(bool s) { controller.DisplayYellowLed8(ref display, s); led_yellow_led8.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Yellow" + (display.YellowLedArray.Led8 ? "On" : "Off") + "8.png"); }
        private void led_blue_led1_state(bool s) { controller.DisplayBlueLed1(ref display, s); led_blue_led1.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Blue" + (display.BlueLedArray.Led1 ? "On" : "Off") + "1.png"); }
        private void led_blue_led2_state(bool s) { controller.DisplayBlueLed2(ref display, s); led_blue_led2.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Blue" + (display.BlueLedArray.Led2 ? "On" : "Off") + "2.png"); }
        private void led_blue_led3_state(bool s) { controller.DisplayBlueLed3(ref display, s); led_blue_led3.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Blue" + (display.BlueLedArray.Led3 ? "On" : "Off") + "3.png"); }
        private void led_blue_led4_state(bool s) { controller.DisplayBlueLed4(ref display, s); led_blue_led4.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Blue" + (display.BlueLedArray.Led4 ? "On" : "Off") + "4.png"); }
        private void led_blue_led5_state(bool s) { controller.DisplayBlueLed5(ref display, s); led_blue_led5.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Blue" + (display.BlueLedArray.Led5 ? "On" : "Off") + "5.png"); }
        private void led_blue_led6_state(bool s) { controller.DisplayBlueLed6(ref display, s); led_blue_led6.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Blue" + (display.BlueLedArray.Led6 ? "On" : "Off") + "6.png"); }
        private void led_blue_led7_state(bool s) { controller.DisplayBlueLed7(ref display, s); led_blue_led7.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Blue" + (display.BlueLedArray.Led7 ? "On" : "Off") + "7.png"); }
        private void led_blue_led8_state(bool s) { controller.DisplayBlueLed8(ref display, s); led_blue_led8.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Blue" + (display.BlueLedArray.Led8 ? "On" : "Off") + "8.png"); }
        private void led_green_led1_state(bool s) { controller.DisplayGreenLed1(ref display, s); led_green_led1.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Green" + (display.GreenLedArray.Led1 ? "On" : "Off" ) + "1.png"); }
        private void led_green_led2_state(bool s) { controller.DisplayGreenLed2(ref display, s); led_green_led2.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Green" + (display.GreenLedArray.Led2 ? "On" : "Off" ) + "2.png"); }
        private void led_green_led3_state(bool s) { controller.DisplayGreenLed3(ref display, s); led_green_led3.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Green" + (display.GreenLedArray.Led3 ? "On" : "Off" ) + "3.png"); }
        private void led_green_led4_state(bool s) { controller.DisplayGreenLed4(ref display, s); led_green_led4.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Green" + (display.GreenLedArray.Led4 ? "On" : "Off" ) + "4.png"); }
        private void led_green_led5_state(bool s) { controller.DisplayGreenLed5(ref display, s); led_green_led5.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Green" + (display.GreenLedArray.Led5 ? "On" : "Off" ) + "5.png"); }
        private void led_green_led6_state(bool s) { controller.DisplayGreenLed6(ref display, s); led_green_led6.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Green" + (display.GreenLedArray.Led6 ? "On" : "Off" ) + "6.png"); }
        private void led_green_led7_state(bool s) { controller.DisplayGreenLed7(ref display, s); led_green_led7.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Green" + (display.GreenLedArray.Led7 ? "On" : "Off" ) + "7.png"); }
        private void led_green_led8_state(bool s) { controller.DisplayGreenLed8(ref display, s); led_green_led8.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Green" + (display.GreenLedArray.Led8 ? "On" : "Off" ) + "8.png"); }

        private void led_red_led1_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayRedLed1(ref display_panel, s); led_red_led1.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Red" + (display_panel.RedLedArray.Led1 ? "On" : "Off") + "1.png"); }
        private void led_red_led2_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayRedLed2(ref display_panel, s); led_red_led2.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Red" + (display_panel.RedLedArray.Led2 ? "On" : "Off") + "2.png"); }
        private void led_red_led3_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayRedLed3(ref display_panel, s); led_red_led3.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Red" + (display_panel.RedLedArray.Led3 ? "On" : "Off") + "3.png"); }
        private void led_red_led4_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayRedLed4(ref display_panel, s); led_red_led4.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Red" + (display_panel.RedLedArray.Led4 ? "On" : "Off") + "4.png"); }
        private void led_red_led5_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayRedLed5(ref display_panel, s); led_red_led5.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Red" + (display_panel.RedLedArray.Led5 ? "On" : "Off") + "5.png"); }
        private void led_red_led6_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayRedLed6(ref display_panel, s); led_red_led6.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Red" + (display_panel.RedLedArray.Led6 ? "On" : "Off") + "6.png"); }
        private void led_red_led7_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayRedLed7(ref display_panel, s); led_red_led7.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Red" + (display_panel.RedLedArray.Led7 ? "On" : "Off") + "7.png"); }
        private void led_red_led8_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayRedLed8(ref display_panel, s); led_red_led8.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Red" + (display_panel.RedLedArray.Led8 ? "On" : "Off") + "8.png"); }
        private void led_yellow_led1_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayYellowLed1(ref display_panel, s); led_yellow_led1.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Yellow" + (display_panel.YellowLedArray.Led1 ? "On" : "Off") + "1.png"); }
        private void led_yellow_led2_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayYellowLed2(ref display_panel, s); led_yellow_led2.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Yellow" + (display_panel.YellowLedArray.Led2 ? "On" : "Off") + "2.png"); }
        private void led_yellow_led3_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayYellowLed3(ref display_panel, s); led_yellow_led3.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Yellow" + (display_panel.YellowLedArray.Led3 ? "On" : "Off") + "3.png"); }
        private void led_yellow_led4_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayYellowLed4(ref display_panel, s); led_yellow_led4.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Yellow" + (display_panel.YellowLedArray.Led4 ? "On" : "Off") + "4.png"); }
        private void led_yellow_led5_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayYellowLed5(ref display_panel, s); led_yellow_led5.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Yellow" + (display_panel.YellowLedArray.Led5 ? "On" : "Off") + "5.png"); }
        private void led_yellow_led6_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayYellowLed6(ref display_panel, s); led_yellow_led6.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Yellow" + (display_panel.YellowLedArray.Led6 ? "On" : "Off") + "6.png"); }
        private void led_yellow_led7_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayYellowLed7(ref display_panel, s); led_yellow_led7.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Yellow" + (display_panel.YellowLedArray.Led7 ? "On" : "Off") + "7.png"); }
        private void led_yellow_led8_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayYellowLed8(ref display_panel, s); led_yellow_led8.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Yellow" + (display_panel.YellowLedArray.Led8 ? "On" : "Off") + "8.png"); }
        private void led_blue_led1_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayBlueLed1(ref display_panel, s); led_blue_led1.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Blue" + (display_panel.BlueLedArray.Led1 ? "On" : "Off") + "1.png"); }
        private void led_blue_led2_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayBlueLed2(ref display_panel, s); led_blue_led2.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Blue" + (display_panel.BlueLedArray.Led2 ? "On" : "Off") + "2.png"); }
        private void led_blue_led3_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayBlueLed3(ref display_panel, s); led_blue_led3.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Blue" + (display_panel.BlueLedArray.Led3 ? "On" : "Off") + "3.png"); }
        private void led_blue_led4_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayBlueLed4(ref display_panel, s); led_blue_led4.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Blue" + (display_panel.BlueLedArray.Led4 ? "On" : "Off") + "4.png"); }
        private void led_blue_led5_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayBlueLed5(ref display_panel, s); led_blue_led5.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Blue" + (display_panel.BlueLedArray.Led5 ? "On" : "Off") + "5.png"); }
        private void led_blue_led6_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayBlueLed6(ref display_panel, s); led_blue_led6.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Blue" + (display_panel.BlueLedArray.Led6 ? "On" : "Off") + "6.png"); }
        private void led_blue_led7_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayBlueLed7(ref display_panel, s); led_blue_led7.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Blue" + (display_panel.BlueLedArray.Led7 ? "On" : "Off") + "7.png"); }
        private void led_blue_led8_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayBlueLed8(ref display_panel, s); led_blue_led8.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Blue" + (display_panel.BlueLedArray.Led8 ? "On" : "Off") + "8.png"); }
        private void led_green_led1_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayGreenLed1(ref display_panel, s); led_green_led1.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Green" + (display_panel.GreenLedArray.Led1 ? "On" : "Off") + "1.png"); }
        private void led_green_led2_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayGreenLed2(ref display_panel, s); led_green_led2.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Green" + (display_panel.GreenLedArray.Led2 ? "On" : "Off") + "2.png"); }
        private void led_green_led3_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayGreenLed3(ref display_panel, s); led_green_led3.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Green" + (display_panel.GreenLedArray.Led3 ? "On" : "Off") + "3.png"); }
        private void led_green_led4_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayGreenLed4(ref display_panel, s); led_green_led4.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Green" + (display_panel.GreenLedArray.Led4 ? "On" : "Off") + "4.png"); }
        private void led_green_led5_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayGreenLed5(ref display_panel, s); led_green_led5.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Green" + (display_panel.GreenLedArray.Led5 ? "On" : "Off") + "5.png"); }
        private void led_green_led6_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayGreenLed6(ref display_panel, s); led_green_led6.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Green" + (display_panel.GreenLedArray.Led6 ? "On" : "Off") + "6.png"); }
        private void led_green_led7_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayGreenLed7(ref display_panel, s); led_green_led7.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Green" + (display_panel.GreenLedArray.Led7 ? "On" : "Off") + "7.png"); }
        private void led_green_led8_state(bool s, ref LedDisplay display_panel, ref StageKitController controller_ref) { controller_ref.DisplayGreenLed8(ref display_panel, s); led_green_led8.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Green" + (display_panel.GreenLedArray.Led8 ? "On" : "Off") + "8.png"); }
        
        private void led_yellow_led1_Click(object sender, EventArgs e) { led_yellow_led1_state(!display.YellowLedArray.Led1); }
        private void led_yellow_led2_Click(object sender, EventArgs e) { led_yellow_led2_state(!display.YellowLedArray.Led2); }
        private void led_yellow_led3_Click(object sender, EventArgs e) { led_yellow_led3_state(!display.YellowLedArray.Led3); }
        private void led_yellow_led4_Click(object sender, EventArgs e) { led_yellow_led4_state(!display.YellowLedArray.Led4); }
        private void led_yellow_led5_Click(object sender, EventArgs e) { led_yellow_led5_state(!display.YellowLedArray.Led5); }
        private void led_yellow_led6_Click(object sender, EventArgs e) { led_yellow_led6_state(!display.YellowLedArray.Led6); }
        private void led_yellow_led7_Click(object sender, EventArgs e) { led_yellow_led7_state(!display.YellowLedArray.Led7); }
        private void led_yellow_led8_Click(object sender, EventArgs e) { led_yellow_led8_state(!display.YellowLedArray.Led8); }
        private void led_red_led1_Click(object sender, EventArgs e) { led_red_led1_state(!display.RedLedArray.Led1); }
        private void led_red_led2_Click(object sender, EventArgs e) { led_red_led2_state(!display.RedLedArray.Led2); }
        private void led_red_led3_Click(object sender, EventArgs e) { led_red_led3_state(!display.RedLedArray.Led3); }
        private void led_red_led4_Click(object sender, EventArgs e) { led_red_led4_state(!display.RedLedArray.Led4); }
        private void led_red_led5_Click(object sender, EventArgs e) { led_red_led5_state(!display.RedLedArray.Led5); }
        private void led_red_led6_Click(object sender, EventArgs e) { led_red_led6_state(!display.RedLedArray.Led6); }
        private void led_red_led7_Click(object sender, EventArgs e) { led_red_led7_state(!display.RedLedArray.Led7); }
        private void led_red_led8_Click(object sender, EventArgs e) { led_red_led8_state(!display.RedLedArray.Led8); }
        private void led_green_led1_Click(object sender, EventArgs e) { led_green_led1_state(!display.GreenLedArray.Led1); }
        private void led_green_led2_Click(object sender, EventArgs e) { led_green_led2_state(!display.GreenLedArray.Led2); }
        private void led_green_led3_Click(object sender, EventArgs e) { led_green_led3_state(!display.GreenLedArray.Led3); }
        private void led_green_led4_Click(object sender, EventArgs e) { led_green_led4_state(!display.GreenLedArray.Led4); }
        private void led_green_led5_Click(object sender, EventArgs e) { led_green_led5_state(!display.GreenLedArray.Led5); }
        private void led_green_led6_Click(object sender, EventArgs e) { led_green_led6_state(!display.GreenLedArray.Led6); }
        private void led_green_led7_Click(object sender, EventArgs e) { led_green_led7_state(!display.GreenLedArray.Led7); }
        private void led_green_led8_Click(object sender, EventArgs e) { led_green_led8_state(!display.GreenLedArray.Led8); }
        private void led_blue_led1_Click(object sender, EventArgs e) { led_blue_led1_state(!display.BlueLedArray.Led1); }
        private void led_blue_led2_Click(object sender, EventArgs e) { led_blue_led2_state(!display.BlueLedArray.Led2); }
        private void led_blue_led3_Click(object sender, EventArgs e) { led_blue_led3_state(!display.BlueLedArray.Led3); }
        private void led_blue_led4_Click(object sender, EventArgs e) { led_blue_led4_state(!display.BlueLedArray.Led4); }
        private void led_blue_led5_Click(object sender, EventArgs e) { led_blue_led5_state(!display.BlueLedArray.Led5); }
        private void led_blue_led6_Click(object sender, EventArgs e) { led_blue_led6_state(!display.BlueLedArray.Led6); }
        private void led_blue_led7_Click(object sender, EventArgs e) { led_blue_led7_state(!display.BlueLedArray.Led7); }
        private void led_blue_led8_Click(object sender, EventArgs e) { led_blue_led8_state(!display.BlueLedArray.Led8); }


        
        private void strobe_slow_Click(object sender, EventArgs e)
        {
            strobe_slow_on.BackColor = Color.Lime;
            strobe_medium_on.BackColor = Color.Maroon;
            strobe_fast_on.BackColor = Color.Maroon;
            strobe_faster_on.BackColor = Color.Maroon;
            controller.TurnStrobeOn(StrobeSpeed.Slow);
        }

        private void strobe_medium_Click(object sender, EventArgs e)
        {
            strobe_slow_on.BackColor = Color.Maroon;
            strobe_medium_on.BackColor = Color.Lime;
            strobe_fast_on.BackColor = Color.Maroon;
            strobe_faster_on.BackColor = Color.Maroon;
            controller.TurnStrobeOn(StrobeSpeed.Medium);
        }

        private void strobe_fast_Click(object sender, EventArgs e)
        {
            strobe_slow_on.BackColor = Color.Maroon;
            strobe_medium_on.BackColor = Color.Maroon;
            strobe_fast_on.BackColor = Color.Lime;
            strobe_faster_on.BackColor = Color.Maroon;
            controller.TurnStrobeOn(StrobeSpeed.Faster);
        }

        private void strobe_faster_Click(object sender, EventArgs e)
        {
            strobe_slow_on.BackColor = Color.Maroon;
            strobe_medium_on.BackColor = Color.Maroon;
            strobe_fast_on.BackColor = Color.Maroon;
            strobe_faster_on.BackColor = Color.Lime;
            controller.TurnStrobeOn(StrobeSpeed.Fastest);
        }

        private void strobe_off_Click(object sender, EventArgs e)
        {
            strobe_slow_on.BackColor = Color.Maroon;
            strobe_medium_on.BackColor = Color.Maroon;
            strobe_fast_on.BackColor = Color.Maroon;
            strobe_faster_on.BackColor = Color.Maroon;
            controller.TurnStrobeOff();
        }






        private void led_red_circle_thread_helper(bool launch)
        {
            if (launch)
            {
                if (led_red_circle_thread == null)
                {
                    led_red_circle_on.BackColor = Color.Lime;
                    led_red_circle_bool = true;
                    led_red_circle_thread = new Thread(new ThreadStart(led_red_circle_helper));
                    led_red_circle_thread.Start();
                }
            }
            else
            {
                if (led_red_circle_thread != null)
                {
                    if (led_red_circle_thread.IsAlive)
                    {
                        led_red_circle_on.BackColor = Color.Maroon;
                        led_red_circle_bool = false;
                        led_red_circle_thread.Abort("Red circle killed.");
                        led_red_circle_thread.Join();
                        led_red_circle_thread = null;
                    }
                }
            }
        }

        private void led_red_circle_helper()
        {
            try
            {
                StageKitController controller = new StageKitController(1);
                LedDisplay display = new LedDisplay();
                led_red_all_helper(false, ref display, ref controller);
                while (true)
                {
                    led_red_led1_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_red_led2_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_red_led3_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_red_led4_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_red_led5_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_red_led6_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_red_led7_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_red_led8_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);

                    led_red_led1_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_red_led2_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_red_led3_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_red_led4_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_red_led5_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_red_led6_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_red_led7_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_red_led8_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                }
            }
            catch (ThreadAbortException abortException)
            {
                led_red_all_helper(false, ref display, ref controller);
            }
        }

        private void led_red_laser_thread_helper(bool launch)
        {
            if (launch)
            {
                if (led_red_laser_thread == null)
                {
                    led_red_laser_on.BackColor = Color.Lime;
                    led_red_laser_thread = new Thread(new ThreadStart(led_red_laser_helper));
                    led_red_laser_thread.Start();
                }
            }
            else
            {
                if (led_red_laser_thread != null)
                {
                    if (led_red_laser_thread.IsAlive)
                    {
                        led_red_laser_on.BackColor = Color.Maroon;
                        led_red_laser_thread.Abort("Red circle killed.");
                        led_red_laser_thread.Join();
                        led_red_laser_thread = null;
                    }
                }
            }
        }

        private void led_red_laser_helper()
        {
            StageKitController controller = new StageKitController(1);
            LedDisplay display = new LedDisplay();
            led_red_all_helper(false, ref display, ref controller);
            try
            {
                while (true)
                {
                    int nextLED = random.Next(1, 9);
                    if (nextLED == 1)
                    {
                        led_red_led1_state(true, ref display, ref controller);
                    }
                    else if (nextLED == 2)
                    {
                        led_red_led2_state(true, ref display, ref controller);
                    }
                    else if (nextLED == 3)
                    {
                        led_red_led3_state(true, ref display, ref controller);
                    }
                    else if (nextLED == 4)
                    {
                        led_red_led4_state(true, ref display, ref controller);
                    }
                    else if (nextLED == 5)
                    {
                        led_red_led5_state(true, ref display, ref controller);
                    }
                    else if (nextLED == 6)
                    {
                        led_red_led6_state(true, ref display, ref controller);
                    }
                    else if (nextLED == 7)
                    {
                        led_red_led7_state(true, ref display, ref controller);
                    }
                    else if (nextLED == 8)
                    {
                        led_red_led8_state(true, ref display, ref controller);
                    }
                    Thread.Sleep(led_delay);
                    led_red_all_helper(false, ref display, ref controller);
                }
            }
            catch (ThreadAbortException abortException)
            {
                led_red_all_helper(false, ref display, ref controller);
            }
        }

        private void led_red_rand_thread_helper(bool launch)
        {
            if (launch)
            {
                if (led_red_rand_thread == null)
                {
                    led_red_rand_on.BackColor = Color.Lime;
                    led_red_rand_thread = new Thread(new ThreadStart(led_red_rand_helper));
                    led_red_rand_thread.Start();
                }
            }
            else
            {
                if (led_red_rand_thread != null)
                {
                    if (led_red_rand_thread.IsAlive)
                    {
                        led_red_rand_on.BackColor = Color.Maroon;
                        led_red_rand_thread.Abort("Red circle killed.");
                        led_red_rand_thread.Join();
                        led_red_rand_thread = null;
                    }
                }
            }
        }

        private void led_red_rand_helper()
        {
            StageKitController controller = new StageKitController(1);
            LedDisplay display = new LedDisplay();
            led_red_all_helper(false, ref display, ref controller);
            try
            {
                while (true)
                {
                    int nextLED = random.Next(1, 9);
                    if (nextLED == 1)
                    {
                        led_red_led1_state(!((bool)display.RedLedArray.Led1), ref display, ref controller);
                    }
                    else if (nextLED == 2)
                    {
                        led_red_led2_state(!((bool)display.RedLedArray.Led2), ref display, ref controller);
                    }
                    else if (nextLED == 3)
                    {
                        led_red_led3_state(!((bool)display.RedLedArray.Led3), ref display, ref controller);
                    }
                    else if (nextLED == 4)
                    {
                        led_red_led4_state(!((bool)display.RedLedArray.Led4), ref display, ref controller);
                    }
                    else if (nextLED == 5)
                    {
                        led_red_led5_state(!((bool)display.RedLedArray.Led5), ref display, ref controller);
                    }
                    else if (nextLED == 6)
                    {
                        led_red_led6_state(!((bool)display.RedLedArray.Led6), ref display, ref controller);
                    }
                    else if (nextLED == 7)
                    {
                        led_red_led7_state(!((bool)display.RedLedArray.Led7), ref display, ref controller);
                    }
                    else if (nextLED == 8)
                    {
                        led_red_led8_state(!((bool)display.RedLedArray.Led8), ref display, ref controller);
                    }
                    Thread.Sleep(led_delay);
                }
            }
            catch (ThreadAbortException abortException)
            {
                led_red_all_helper(false, ref display, ref controller);
            }
        }

        private void led_red_all_helper(bool state, ref LedDisplay display_param, ref StageKitController controller_param)
        {
            if (state)
            {
                led_red_all_on.BackColor = Color.Lime;
            }
            else
            {
                led_red_all_on.BackColor = Color.Maroon;
            }
            controller_param.DisplayRedAll(ref display_param, state);
            led_red_led1.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Red" + (state ? "On" : "Off") + "1.png");
            led_red_led2.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Red" + (state ? "On" : "Off") + "2.png");
            led_red_led3.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Red" + (state ? "On" : "Off") + "3.png");
            led_red_led4.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Red" + (state ? "On" : "Off") + "4.png");
            led_red_led5.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Red" + (state ? "On" : "Off") + "5.png");
            led_red_led6.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Red" + (state ? "On" : "Off") + "6.png");
            led_red_led7.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Red" + (state ? "On" : "Off") + "7.png");
            led_red_led8.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Red" + (state ? "On" : "Off") + "8.png");
        }


        private void led_red_circle_Click(object sender, EventArgs e)
        {
            led_red_laser_thread_helper(false);
            led_red_all_helper(false, ref display, ref controller);
            led_red_rand_thread_helper(false);
            led_red_circle_thread_helper(led_red_circle_thread == null);
        }

        private void led_red_rand_Click(object sender, EventArgs e)
        {
            led_red_circle_thread_helper(false);
            led_red_laser_thread_helper(false);
            led_red_all_helper(false, ref display, ref controller);
            led_red_rand_thread_helper(led_red_rand_thread == null);
        }

        private void led_red_laser_Click(object sender, EventArgs e)
        {
            led_red_circle_thread_helper(false);
            led_red_all_helper(false, ref display, ref controller);
            led_red_rand_thread_helper(false);
            led_red_laser_thread_helper(led_red_laser_thread == null);
        }

        private void led_red_all_Click(object sender, EventArgs e)
        {
            led_red_circle_thread_helper(false);
            led_red_laser_thread_helper(false);
            led_red_rand_thread_helper(false);
            if (led_red_all_on.BackColor == Color.Maroon)
            {
                led_red_all_helper(true, ref display, ref controller);
            }
            else
            {
                led_red_all_helper(false, ref display, ref controller);
            }

        }

        private void led_red_circle_ignore_Click(object sender, EventArgs e)
        {
            led_red_circle_thread_helper(led_red_circle_thread == null);
        }

        private void led_red_rand_ignore_Click(object sender, EventArgs e)
        {
            led_red_rand_thread_helper(led_red_rand_thread == null);
        }

        private void led_red_laser_ignore_Click(object sender, EventArgs e)
        {
            led_red_laser_thread_helper(led_red_laser_thread == null);
        }







        private void led_blue_circle_thread_helper(bool launch)
        {
            if (launch)
            {
                if (led_blue_circle_thread == null)
                {
                    led_blue_circle_on.BackColor = Color.Lime;
                    led_blue_circle_bool = true;
                    led_blue_circle_thread = new Thread(new ThreadStart(led_blue_circle_helper));
                    led_blue_circle_thread.Start();
                }
            }
            else
            {
                if (led_blue_circle_thread != null)
                {
                    if (led_blue_circle_thread.IsAlive)
                    {
                        led_blue_circle_on.BackColor = Color.Maroon;
                        led_blue_circle_bool = false;
                        led_blue_circle_thread.Abort("Blue circle killed.");
                        led_blue_circle_thread.Join();
                        led_blue_circle_thread = null;
                    }
                }
            }
        }

        private void led_blue_circle_helper()
        {
            try
            {
                StageKitController controller = new StageKitController(1);
                LedDisplay display = new LedDisplay();
                led_blue_all_helper(false, ref display, ref controller);
                while (true)
                {
                    led_blue_led1_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_blue_led2_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_blue_led3_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_blue_led4_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_blue_led5_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_blue_led6_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_blue_led7_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_blue_led8_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);

                    led_blue_led1_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_blue_led2_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_blue_led3_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_blue_led4_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_blue_led5_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_blue_led6_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_blue_led7_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_blue_led8_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                }
            }
            catch (ThreadAbortException abortException)
            {
                led_blue_all_helper(false, ref display, ref controller);
            }
        }

        private void led_blue_laser_thread_helper(bool launch)
        {
            if (launch)
            {
                if (led_blue_laser_thread == null)
                {
                    led_blue_laser_on.BackColor = Color.Lime;
                    led_blue_laser_thread = new Thread(new ThreadStart(led_blue_laser_helper));
                    led_blue_laser_thread.Start();
                }
            }
            else
            {
                if (led_blue_laser_thread != null)
                {
                    if (led_blue_laser_thread.IsAlive)
                    {
                        led_blue_laser_on.BackColor = Color.Maroon;
                        led_blue_laser_thread.Abort("Blue circle killed.");
                        led_blue_laser_thread.Join();
                        led_blue_laser_thread = null;
                    }
                }
            }
        }

        private void led_blue_laser_helper()
        {
            StageKitController controller = new StageKitController(1);
            LedDisplay display = new LedDisplay();
            led_blue_all_helper(false, ref display, ref controller);
            try
            {
                while (true)
                {
                    int nextLED = random.Next(1, 9);
                    if (nextLED == 1)
                    {
                        led_blue_led1_state(true, ref display, ref controller);
                    }
                    else if (nextLED == 2)
                    {
                        led_blue_led2_state(true, ref display, ref controller);
                    }
                    else if (nextLED == 3)
                    {
                        led_blue_led3_state(true, ref display, ref controller);
                    }
                    else if (nextLED == 4)
                    {
                        led_blue_led4_state(true, ref display, ref controller);
                    }
                    else if (nextLED == 5)
                    {
                        led_blue_led5_state(true, ref display, ref controller);
                    }
                    else if (nextLED == 6)
                    {
                        led_blue_led6_state(true, ref display, ref controller);
                    }
                    else if (nextLED == 7)
                    {
                        led_blue_led7_state(true, ref display, ref controller);
                    }
                    else if (nextLED == 8)
                    {
                        led_blue_led8_state(true, ref display, ref controller);
                    }
                    Thread.Sleep(led_delay);
                    led_blue_all_helper(false, ref display, ref controller);
                }
            }
            catch (ThreadAbortException abortException)
            {
                led_blue_all_helper(false, ref display, ref controller);
            }
        }

        private void led_blue_rand_thread_helper(bool launch)
        {
            if (launch)
            {
                if (led_blue_rand_thread == null)
                {
                    led_blue_rand_on.BackColor = Color.Lime;
                    led_blue_rand_thread = new Thread(new ThreadStart(led_blue_rand_helper));
                    led_blue_rand_thread.Start();
                }
            }
            else
            {
                if (led_blue_rand_thread != null)
                {
                    if (led_blue_rand_thread.IsAlive)
                    {
                        led_blue_rand_on.BackColor = Color.Maroon;
                        led_blue_rand_thread.Abort("Blue circle killed.");
                        led_blue_rand_thread.Join();
                        led_blue_rand_thread = null;
                    }
                }
            }
        }

        private void led_blue_rand_helper()
        {
            StageKitController controller = new StageKitController(1);
            LedDisplay display = new LedDisplay();
            led_blue_all_helper(false, ref display, ref controller);
            try
            {
                while (true)
                {
                    int nextLED = random.Next(1, 9);
                    if (nextLED == 1)
                    {
                        led_blue_led1_state(!((bool)display.BlueLedArray.Led1), ref display, ref controller);
                    }
                    else if (nextLED == 2)
                    {
                        led_blue_led2_state(!((bool)display.BlueLedArray.Led2), ref display, ref controller);
                    }
                    else if (nextLED == 3)
                    {
                        led_blue_led3_state(!((bool)display.BlueLedArray.Led3), ref display, ref controller);
                    }
                    else if (nextLED == 4)
                    {
                        led_blue_led4_state(!((bool)display.BlueLedArray.Led4), ref display, ref controller);
                    }
                    else if (nextLED == 5)
                    {
                        led_blue_led5_state(!((bool)display.BlueLedArray.Led5), ref display, ref controller);
                    }
                    else if (nextLED == 6)
                    {
                        led_blue_led6_state(!((bool)display.BlueLedArray.Led6), ref display, ref controller);
                    }
                    else if (nextLED == 7)
                    {
                        led_blue_led7_state(!((bool)display.BlueLedArray.Led7), ref display, ref controller);
                    }
                    else if (nextLED == 8)
                    {
                        led_blue_led8_state(!((bool)display.BlueLedArray.Led8), ref display, ref controller);
                    }
                    Thread.Sleep(led_delay);
                }
            }
            catch (ThreadAbortException abortException)
            {
                led_blue_all_helper(false, ref display, ref controller);
            }
        }

        private void led_blue_all_helper(bool state, ref LedDisplay display_param, ref StageKitController controller_param)
        {
            if (state)
            {
                led_blue_all_on.BackColor = Color.Lime;
            }
            else
            {
                led_blue_all_on.BackColor = Color.Maroon;
            }
            controller_param.DisplayBlueAll(ref display_param, state);
            led_blue_led1.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Blue" + (state ? "On" : "Off") + "1.png");
            led_blue_led2.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Blue" + (state ? "On" : "Off") + "2.png");
            led_blue_led3.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Blue" + (state ? "On" : "Off") + "3.png");
            led_blue_led4.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Blue" + (state ? "On" : "Off") + "4.png");
            led_blue_led5.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Blue" + (state ? "On" : "Off") + "5.png");
            led_blue_led6.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Blue" + (state ? "On" : "Off") + "6.png");
            led_blue_led7.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Blue" + (state ? "On" : "Off") + "7.png");
            led_blue_led8.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Blue" + (state ? "On" : "Off") + "8.png");
        }


        private void led_blue_circle_Click(object sender, EventArgs e)
        {
            led_blue_laser_thread_helper(false);
            led_blue_all_helper(false, ref display, ref controller);
            led_blue_rand_thread_helper(false);
            led_blue_circle_thread_helper(led_blue_circle_thread == null);
        }

        private void led_blue_rand_Click(object sender, EventArgs e)
        {
            led_blue_circle_thread_helper(false);
            led_blue_laser_thread_helper(false);
            led_blue_all_helper(false, ref display, ref controller);
            led_blue_rand_thread_helper(led_blue_rand_thread == null);
        }

        private void led_blue_laser_Click(object sender, EventArgs e)
        {
            led_blue_circle_thread_helper(false);
            led_blue_all_helper(false, ref display, ref controller);
            led_blue_rand_thread_helper(false);
            led_blue_laser_thread_helper(led_blue_laser_thread == null);
        }

        private void led_blue_all_Click(object sender, EventArgs e)
        {
            led_blue_circle_thread_helper(false);
            led_blue_laser_thread_helper(false);
            led_blue_rand_thread_helper(false);
            if (led_blue_all_on.BackColor == Color.Maroon)
            {
                led_blue_all_helper(true, ref display, ref controller);
            }
            else
            {
                led_blue_all_helper(false, ref display, ref controller);
            }

        }

        private void led_blue_circle_ignore_Click(object sender, EventArgs e)
        {
            led_blue_circle_thread_helper(led_blue_circle_thread == null);
        }

        private void led_blue_rand_ignore_Click(object sender, EventArgs e)
        {
            led_blue_rand_thread_helper(led_blue_rand_thread == null);
        }

        private void led_blue_laser_ignore_Click(object sender, EventArgs e)
        {
            led_blue_laser_thread_helper(led_blue_laser_thread == null);
        }





        private void led_green_circle_thread_helper(bool launch)
        {
            if (launch)
            {
                if (led_green_circle_thread == null)
                {
                    led_green_circle_on.BackColor = Color.Lime;
                    led_green_circle_bool = true;
                    led_green_circle_thread = new Thread(new ThreadStart(led_green_circle_helper));
                    led_green_circle_thread.Start();
                }
            }
            else
            {
                if (led_green_circle_thread != null)
                {
                    if (led_green_circle_thread.IsAlive)
                    {
                        led_green_circle_on.BackColor = Color.Maroon;
                        led_green_circle_bool = false;
                        led_green_circle_thread.Abort("Green circle killed.");
                        led_green_circle_thread.Join();
                        led_green_circle_thread = null;
                    }
                }
            }
        }

        private void led_green_circle_helper()
        {
            try
            {
                StageKitController controller = new StageKitController(1);
                LedDisplay display = new LedDisplay();
                led_green_all_helper(false, ref display, ref controller);
                while (true)
                {
                    led_green_led1_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_green_led2_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_green_led3_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_green_led4_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_green_led5_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_green_led6_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_green_led7_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_green_led8_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);

                    led_green_led1_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_green_led2_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_green_led3_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_green_led4_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_green_led5_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_green_led6_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_green_led7_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_green_led8_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                }
            }
            catch (ThreadAbortException abortException)
            {
                led_green_all_helper(false, ref display, ref controller);
            }
        }

        private void led_green_laser_thread_helper(bool launch)
        {
            if (launch)
            {
                if (led_green_laser_thread == null)
                {
                    led_green_laser_on.BackColor = Color.Lime;
                    led_green_laser_thread = new Thread(new ThreadStart(led_green_laser_helper));
                    led_green_laser_thread.Start();
                }
            }
            else
            {
                if (led_green_laser_thread != null)
                {
                    if (led_green_laser_thread.IsAlive)
                    {
                        led_green_laser_on.BackColor = Color.Maroon;
                        led_green_laser_thread.Abort("Green circle killed.");
                        led_green_laser_thread.Join();
                        led_green_laser_thread = null;
                    }
                }
            }
        }

        private void led_green_laser_helper()
        {
            StageKitController controller = new StageKitController(1);
            LedDisplay display = new LedDisplay();
            led_green_all_helper(false, ref display, ref controller);
            try
            {
                while (true)
                {
                    int nextLED = random.Next(1, 9);
                    if (nextLED == 1)
                    {
                        led_green_led1_state(true, ref display, ref controller);
                    }
                    else if (nextLED == 2)
                    {
                        led_green_led2_state(true, ref display, ref controller);
                    }
                    else if (nextLED == 3)
                    {
                        led_green_led3_state(true, ref display, ref controller);
                    }
                    else if (nextLED == 4)
                    {
                        led_green_led4_state(true, ref display, ref controller);
                    }
                    else if (nextLED == 5)
                    {
                        led_green_led5_state(true, ref display, ref controller);
                    }
                    else if (nextLED == 6)
                    {
                        led_green_led6_state(true, ref display, ref controller);
                    }
                    else if (nextLED == 7)
                    {
                        led_green_led7_state(true, ref display, ref controller);
                    }
                    else if (nextLED == 8)
                    {
                        led_green_led8_state(true, ref display, ref controller);
                    }
                    Thread.Sleep(led_delay);
                    led_green_all_helper(false, ref display, ref controller);
                }
            }
            catch (ThreadAbortException abortException)
            {
                led_green_all_helper(false, ref display, ref controller);
            }
        }

        private void led_green_rand_thread_helper(bool launch)
        {
            if (launch)
            {
                if (led_green_rand_thread == null)
                {
                    led_green_rand_on.BackColor = Color.Lime;
                    led_green_rand_thread = new Thread(new ThreadStart(led_green_rand_helper));
                    led_green_rand_thread.Start();
                }
            }
            else
            {
                if (led_green_rand_thread != null)
                {
                    if (led_green_rand_thread.IsAlive)
                    {
                        led_green_rand_on.BackColor = Color.Maroon;
                        led_green_rand_thread.Abort("Green circle killed.");
                        led_green_rand_thread.Join();
                        led_green_rand_thread = null;
                    }
                }
            }
        }

        private void led_green_rand_helper()
        {
            StageKitController controller = new StageKitController(1);
            LedDisplay display = new LedDisplay();
            led_green_all_helper(false, ref display, ref controller);
            try
            {
                while (true)
                {
                    int nextLED = random.Next(1, 9);
                    if (nextLED == 1)
                    {
                        led_green_led1_state(!((bool)display.GreenLedArray.Led1), ref display, ref controller);
                    }
                    else if (nextLED == 2)
                    {
                        led_green_led2_state(!((bool)display.GreenLedArray.Led2), ref display, ref controller);
                    }
                    else if (nextLED == 3)
                    {
                        led_green_led3_state(!((bool)display.GreenLedArray.Led3), ref display, ref controller);
                    }
                    else if (nextLED == 4)
                    {
                        led_green_led4_state(!((bool)display.GreenLedArray.Led4), ref display, ref controller);
                    }
                    else if (nextLED == 5)
                    {
                        led_green_led5_state(!((bool)display.GreenLedArray.Led5), ref display, ref controller);
                    }
                    else if (nextLED == 6)
                    {
                        led_green_led6_state(!((bool)display.GreenLedArray.Led6), ref display, ref controller);
                    }
                    else if (nextLED == 7)
                    {
                        led_green_led7_state(!((bool)display.GreenLedArray.Led7), ref display, ref controller);
                    }
                    else if (nextLED == 8)
                    {
                        led_green_led8_state(!((bool)display.GreenLedArray.Led8), ref display, ref controller);
                    }
                    Thread.Sleep(led_delay);
                }
            }
            catch (ThreadAbortException abortException)
            {
                led_green_all_helper(false, ref display, ref controller);
            }
        }

        private void led_green_all_helper(bool state, ref LedDisplay display_param, ref StageKitController controller_param)
        {
            if (state)
            {
                led_green_all_on.BackColor = Color.Lime;
            }
            else
            {
                led_green_all_on.BackColor = Color.Maroon;
            }
            controller_param.DisplayGreenAll(ref display_param, state);
            led_green_led1.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Green" + (state ? "On" : "Off") + "1.png");
            led_green_led2.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Green" + (state ? "On" : "Off") + "2.png");
            led_green_led3.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Green" + (state ? "On" : "Off") + "3.png");
            led_green_led4.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Green" + (state ? "On" : "Off") + "4.png");
            led_green_led5.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Green" + (state ? "On" : "Off") + "5.png");
            led_green_led6.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Green" + (state ? "On" : "Off") + "6.png");
            led_green_led7.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Green" + (state ? "On" : "Off") + "7.png");
            led_green_led8.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Green" + (state ? "On" : "Off") + "8.png");
        }


        private void led_green_circle_Click(object sender, EventArgs e)
        {
            led_green_laser_thread_helper(false);
            led_green_all_helper(false, ref display, ref controller);
            led_green_rand_thread_helper(false);
            led_green_circle_thread_helper(led_green_circle_thread == null);
        }

        private void led_green_rand_Click(object sender, EventArgs e)
        {
            led_green_circle_thread_helper(false);
            led_green_laser_thread_helper(false);
            led_green_all_helper(false, ref display, ref controller);
            led_green_rand_thread_helper(led_green_rand_thread == null);
        }

        private void led_green_laser_Click(object sender, EventArgs e)
        {
            led_green_circle_thread_helper(false);
            led_green_all_helper(false, ref display, ref controller);
            led_green_rand_thread_helper(false);
            led_green_laser_thread_helper(led_green_laser_thread == null);
        }

        private void led_green_all_Click(object sender, EventArgs e)
        {
            led_green_circle_thread_helper(false);
            led_green_laser_thread_helper(false);
            led_green_rand_thread_helper(false);
            if (led_green_all_on.BackColor == Color.Maroon)
            {
                led_green_all_helper(true, ref display, ref controller);
            }
            else
            {
                led_green_all_helper(false, ref display, ref controller);
            }

        }

        private void led_green_circle_ignore_Click(object sender, EventArgs e)
        {
            led_green_circle_thread_helper(led_green_circle_thread == null);
        }

        private void led_green_rand_ignore_Click(object sender, EventArgs e)
        {
            led_green_rand_thread_helper(led_green_rand_thread == null);
        }

        private void led_green_laser_ignore_Click(object sender, EventArgs e)
        {
            led_green_laser_thread_helper(led_green_laser_thread == null);
        }




        private void led_yellow_circle_thread_helper(bool launch)
        {
            if (launch)
            {
                if (led_yellow_circle_thread == null)
                {
                    led_yellow_circle_on.BackColor = Color.Lime;
                    led_yellow_circle_bool = true;
                    led_yellow_circle_thread = new Thread(new ThreadStart(led_yellow_circle_helper));
                    led_yellow_circle_thread.Start();
                }
            }
            else
            {
                if (led_yellow_circle_thread != null)
                {
                    if (led_yellow_circle_thread.IsAlive)
                    {
                        led_yellow_circle_on.BackColor = Color.Maroon;
                        led_yellow_circle_bool = false;
                        led_yellow_circle_thread.Abort("Yellow circle killed.");
                        led_yellow_circle_thread.Join();
                        led_yellow_circle_thread = null;
                    }
                }
            }
        }

        private void led_yellow_circle_helper()
        {
            try
            {
                StageKitController controller = new StageKitController(1);
                LedDisplay display = new LedDisplay();
                led_yellow_all_helper(false, ref display, ref controller);
                while (true)
                {
                    led_yellow_led1_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_yellow_led2_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_yellow_led3_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_yellow_led4_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_yellow_led5_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_yellow_led6_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_yellow_led7_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_yellow_led8_state(true, ref display, ref controller);
                    Thread.Sleep(led_delay);

                    led_yellow_led1_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_yellow_led2_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_yellow_led3_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_yellow_led4_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_yellow_led5_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_yellow_led6_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_yellow_led7_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                    led_yellow_led8_state(false, ref display, ref controller);
                    Thread.Sleep(led_delay);
                }
            }
            catch (ThreadAbortException abortException)
            {
                led_yellow_all_helper(false, ref display, ref controller);
            }
        }

        private void led_yellow_laser_thread_helper(bool launch)
        {
            if (launch)
            {
                if (led_yellow_laser_thread == null)
                {
                    led_yellow_laser_on.BackColor = Color.Lime;
                    led_yellow_laser_thread = new Thread(new ThreadStart(led_yellow_laser_helper));
                    led_yellow_laser_thread.Start();
                }
            }
            else
            {
                if (led_yellow_laser_thread != null)
                {
                    if (led_yellow_laser_thread.IsAlive)
                    {
                        led_yellow_laser_on.BackColor = Color.Maroon;
                        led_yellow_laser_thread.Abort("Yellow circle killed.");
                        led_yellow_laser_thread.Join();
                        led_yellow_laser_thread = null;
                    }
                }
            }
        }

        private void led_yellow_laser_helper()
        {
            StageKitController controller = new StageKitController(1);
            LedDisplay display = new LedDisplay();
            led_yellow_all_helper(false, ref display, ref controller);
            try
            {
                while (true)
                {
                    int nextLED = random.Next(1, 9);
                    if (nextLED == 1)
                    {
                        led_yellow_led1_state(true, ref display, ref controller);
                    }
                    else if (nextLED == 2)
                    {
                        led_yellow_led2_state(true, ref display, ref controller);
                    }
                    else if (nextLED == 3)
                    {
                        led_yellow_led3_state(true, ref display, ref controller);
                    }
                    else if (nextLED == 4)
                    {
                        led_yellow_led4_state(true, ref display, ref controller);
                    }
                    else if (nextLED == 5)
                    {
                        led_yellow_led5_state(true, ref display, ref controller);
                    }
                    else if (nextLED == 6)
                    {
                        led_yellow_led6_state(true, ref display, ref controller);
                    }
                    else if (nextLED == 7)
                    {
                        led_yellow_led7_state(true, ref display, ref controller);
                    }
                    else if (nextLED == 8)
                    {
                        led_yellow_led8_state(true, ref display, ref controller);
                    }
                    Thread.Sleep(led_delay);
                    led_yellow_all_helper(false, ref display, ref controller);
                }
            }
            catch (ThreadAbortException abortException)
            {
                led_yellow_all_helper(false, ref display, ref controller);
            }
        }

        private void led_yellow_rand_thread_helper(bool launch)
        {
            if (launch)
            {
                if (led_yellow_rand_thread == null)
                {
                    led_yellow_rand_on.BackColor = Color.Lime;
                    led_yellow_rand_thread = new Thread(new ThreadStart(led_yellow_rand_helper));
                    led_yellow_rand_thread.Start();
                }
            }
            else
            {
                if (led_yellow_rand_thread != null)
                {
                    if (led_yellow_rand_thread.IsAlive)
                    {
                        led_yellow_rand_on.BackColor = Color.Maroon;
                        led_yellow_rand_thread.Abort("Yellow circle killed.");
                        led_yellow_rand_thread.Join();
                        led_yellow_rand_thread = null;
                    }
                }
            }
        }

        private void led_yellow_rand_helper()
        {
            StageKitController controller = new StageKitController(1);
            LedDisplay display = new LedDisplay();
            led_yellow_all_helper(false, ref display, ref controller);
            try
            {
                while (true)
                {
                    int nextLED = random.Next(1, 9);
                    if (nextLED == 1)
                    {
                        led_yellow_led1_state(!((bool)display.YellowLedArray.Led1), ref display, ref controller);
                    }
                    else if (nextLED == 2)
                    {
                        led_yellow_led2_state(!((bool)display.YellowLedArray.Led2), ref display, ref controller);
                    }
                    else if (nextLED == 3)
                    {
                        led_yellow_led3_state(!((bool)display.YellowLedArray.Led3), ref display, ref controller);
                    }
                    else if (nextLED == 4)
                    {
                        led_yellow_led4_state(!((bool)display.YellowLedArray.Led4), ref display, ref controller);
                    }
                    else if (nextLED == 5)
                    {
                        led_yellow_led5_state(!((bool)display.YellowLedArray.Led5), ref display, ref controller);
                    }
                    else if (nextLED == 6)
                    {
                        led_yellow_led6_state(!((bool)display.YellowLedArray.Led6), ref display, ref controller);
                    }
                    else if (nextLED == 7)
                    {
                        led_yellow_led7_state(!((bool)display.YellowLedArray.Led7), ref display, ref controller);
                    }
                    else if (nextLED == 8)
                    {
                        led_yellow_led8_state(!((bool)display.YellowLedArray.Led8), ref display, ref controller);
                    }
                    Thread.Sleep(led_delay);
                }
            }
            catch (ThreadAbortException abortException)
            {
                led_yellow_all_helper(false, ref display, ref controller);
            }
        }

        private void led_yellow_all_helper(bool state, ref LedDisplay display_param, ref StageKitController controller_param)
        {
            if (state)
            {
                led_yellow_all_on.BackColor = Color.Lime;
            }
            else
            {
                led_yellow_all_on.BackColor = Color.Maroon;
            }
            controller_param.DisplayYellowAll(ref display_param, state);
            led_yellow_led1.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Yellow" + (state ? "On" : "Off") + "1.png");
            led_yellow_led2.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Yellow" + (state ? "On" : "Off") + "2.png");
            led_yellow_led3.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Yellow" + (state ? "On" : "Off") + "3.png");
            led_yellow_led4.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Yellow" + (state ? "On" : "Off") + "4.png");
            led_yellow_led5.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Yellow" + (state ? "On" : "Off") + "5.png");
            led_yellow_led6.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Yellow" + (state ? "On" : "Off") + "6.png");
            led_yellow_led7.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Yellow" + (state ? "On" : "Off") + "7.png");
            led_yellow_led8.BackgroundImage = System.Drawing.Image.FromFile("Resources/LED_Yellow" + (state ? "On" : "Off") + "8.png");
        }


        private void led_yellow_circle_Click(object sender, EventArgs e)
        {
            led_yellow_laser_thread_helper(false);
            led_yellow_all_helper(false, ref display, ref controller);
            led_yellow_rand_thread_helper(false);
            led_yellow_circle_thread_helper(led_yellow_circle_thread == null);
        }

        private void led_yellow_rand_Click(object sender, EventArgs e)
        {
            led_yellow_circle_thread_helper(false);
            led_yellow_laser_thread_helper(false);
            led_yellow_all_helper(false, ref display, ref controller);
            led_yellow_rand_thread_helper(led_yellow_rand_thread == null);
        }

        private void led_yellow_laser_Click(object sender, EventArgs e)
        {
            led_yellow_circle_thread_helper(false);
            led_yellow_all_helper(false, ref display, ref controller);
            led_yellow_rand_thread_helper(false);
            led_yellow_laser_thread_helper(led_yellow_laser_thread == null);
        }

        private void led_yellow_all_Click(object sender, EventArgs e)
        {
            led_yellow_circle_thread_helper(false);
            led_yellow_laser_thread_helper(false);
            led_yellow_rand_thread_helper(false);
            led_yellow_all_helper((led_yellow_all_on.BackColor == Color.Maroon), ref display, ref controller);
        }

        private void led_yellow_circle_ignore_Click(object sender, EventArgs e)
        {
            led_yellow_circle_thread_helper(led_yellow_circle_thread == null);
        }

        private void led_yellow_rand_ignore_Click(object sender, EventArgs e)
        {
            led_yellow_rand_thread_helper(led_yellow_rand_thread == null);
        }

        private void led_yellow_laser_ignore_Click(object sender, EventArgs e)
        {
            led_yellow_laser_thread_helper(led_yellow_laser_thread == null);
        }









        




        private void led_reverse_circle_Click(object sender, EventArgs e)
        {
            led_red_all_helper(false, ref display, ref controller);
            led_red_rand_thread_helper(false);
            led_red_laser_thread_helper(false);
            led_blue_all_helper(false, ref display, ref controller);
            led_blue_rand_thread_helper(false);
            led_blue_laser_thread_helper(false);
            led_green_all_helper(false, ref display, ref controller);
            led_green_rand_thread_helper(false);
            led_green_laser_thread_helper(false);
            led_yellow_all_helper(false, ref display, ref controller);
            led_yellow_rand_thread_helper(false);
            led_yellow_laser_thread_helper(false);

            led_red_circle_thread_helper(led_red_circle_thread == null);
            led_blue_circle_thread_helper(led_blue_circle_thread == null);
            led_green_circle_thread_helper(led_green_circle_thread == null);
            led_yellow_circle_thread_helper(led_yellow_circle_thread == null);
        }

        private void led_reverse_rand_Click(object sender, EventArgs e)
        {
            led_red_all_helper(false, ref display, ref controller);
            led_red_circle_thread_helper(false);
            led_red_laser_thread_helper(false);
            led_blue_all_helper(false, ref display, ref controller);
            led_blue_circle_thread_helper(false);
            led_blue_laser_thread_helper(false);
            led_green_all_helper(false, ref display, ref controller);
            led_green_circle_thread_helper(false);
            led_green_laser_thread_helper(false);
            led_yellow_all_helper(false, ref display, ref controller);
            led_yellow_circle_thread_helper(false);
            led_yellow_laser_thread_helper(false);

            led_red_rand_thread_helper(led_red_circle_thread == null);
            led_blue_rand_thread_helper(led_blue_circle_thread == null);
            led_green_rand_thread_helper(led_green_circle_thread == null);
            led_yellow_rand_thread_helper(led_yellow_circle_thread == null);
        }

        private void led_reverse_laser_Click(object sender, EventArgs e)
        {
            led_red_all_helper(false, ref display, ref controller);
            led_red_circle_thread_helper(false);
            led_red_rand_thread_helper(false);
            led_blue_all_helper(false, ref display, ref controller);
            led_blue_circle_thread_helper(false);
            led_blue_rand_thread_helper(false);
            led_green_all_helper(false, ref display, ref controller);
            led_green_circle_thread_helper(false);
            led_green_rand_thread_helper(false);
            led_yellow_all_helper(false, ref display, ref controller);
            led_yellow_circle_thread_helper(false);
            led_yellow_rand_thread_helper(false);

            led_red_laser_thread_helper(led_red_circle_thread == null);
            led_blue_laser_thread_helper(led_blue_circle_thread == null);
            led_green_laser_thread_helper(led_green_circle_thread == null);
            led_yellow_laser_thread_helper(led_yellow_circle_thread == null);
        }

        private void led_reverse_all_Click(object sender, EventArgs e)
        {
            led_red_circle_thread_helper(false);
            led_red_rand_thread_helper(false);
            led_red_laser_thread_helper(false);
            led_blue_circle_thread_helper(false);
            led_blue_rand_thread_helper(false);
            led_blue_laser_thread_helper(false);
            led_green_circle_thread_helper(false);
            led_green_rand_thread_helper(false);
            led_green_laser_thread_helper(false);
            led_yellow_circle_thread_helper(false);
            led_yellow_rand_thread_helper(false);
            led_yellow_laser_thread_helper(false);

            led_green_all_helper((led_green_all_on.BackColor == Color.Maroon), ref display, ref controller);
            led_blue_all_helper((led_blue_all_on.BackColor == Color.Maroon), ref display, ref controller);
            led_red_all_helper((led_red_all_on.BackColor == Color.Maroon), ref display, ref controller);
            led_yellow_all_helper((led_yellow_all_on.BackColor == Color.Maroon), ref display, ref controller);
        }

        private void led_all_off_Click(object sender, EventArgs e)
        {
            led_all_off_helper();
        }

        private void kill_all_Click(object sender, EventArgs e)
        {
            kill_all_helper();
        }



        private void led_all_off_helper()
        {
            led_red_circle_thread_helper(false);
            led_red_rand_thread_helper(false);
            led_red_laser_thread_helper(false);
            led_blue_circle_thread_helper(false);
            led_blue_rand_thread_helper(false);
            led_blue_laser_thread_helper(false);
            led_green_circle_thread_helper(false);
            led_green_rand_thread_helper(false);
            led_green_laser_thread_helper(false);
            led_yellow_circle_thread_helper(false);
            led_yellow_rand_thread_helper(false);
            led_yellow_laser_thread_helper(false);

            led_green_all_helper(false, ref display, ref controller);
            led_blue_all_helper(false, ref display, ref controller);
            led_red_all_helper(false, ref display, ref controller);
            led_yellow_all_helper(false, ref display, ref controller);
        }

        private void kill_all_helper() {
            led_all_off_helper();
            fog_burst_thread_helper(0);
            strobe_slow_on.BackColor = Color.Maroon;
            strobe_medium_on.BackColor = Color.Maroon;
            strobe_fast_on.BackColor = Color.Maroon;
            strobe_faster_on.BackColor = Color.Maroon;
            controller.TurnStrobeOff();
        }

        private void fog_burst_1sec_Click(object sender, EventArgs e)
        {
            fog_burst_thread_helper(1000);
        }

        private void fog_burst_3sec_Click(object sender, EventArgs e)
        {
            fog_burst_thread_helper(3000);
        }

        private void fog_burst_5sec_Click(object sender, EventArgs e)
        {
            fog_burst_thread_helper(5000);
        }

        private void fog_burst_on_Click(object sender, EventArgs e)
        {
            fog_burst_thread_helper(100000);
        }

        private void fog_burst_off_Click(object sender, EventArgs e)
        {
            fog_burst_thread_helper(0);
        }

        private void fog_burst_thread_helper(int fog_burst_length_param) {
            if (fog_thread != null) {
                if (fog_thread.IsAlive) {
                    fog_thread.Abort("Fog thread killed.");
                }
                fog_thread.Join();
                fog_thread = null;
            }
            fog_burst_length = fog_burst_length_param;
            if (fog_burst_length_param > 0) {
                fog_thread = new Thread(new ThreadStart(fog_burst_helper));
                fog_thread.Start();
            }

        }


        private void fog_burst_helper() {
            StageKitController controller = new StageKitController(1);
            try {
                controller.TurnFogOn();
                Thread.Sleep(fog_burst_length);
                controller.TurnFogOff();
            } catch (ThreadAbortException abortException) {
                controller.TurnFogOff();
            }
        }








        /*
        private void led_green_circle_helper()
        {
            while (led_green_circle_bool)
            {
                led_green_led1_state(true);
                System.Threading.Thread.Sleep(led_delay);
                led_green_led2_state(true);
                System.Threading.Thread.Sleep(led_delay);
                led_green_led3_state(true);
                System.Threading.Thread.Sleep(led_delay);
                led_green_led4_state(true);
                System.Threading.Thread.Sleep(led_delay);
                led_green_led5_state(true);
                System.Threading.Thread.Sleep(led_delay);
                led_green_led6_state(true);
                System.Threading.Thread.Sleep(led_delay);
                led_green_led7_state(true);
                System.Threading.Thread.Sleep(led_delay);
                led_green_led8_state(true);
                System.Threading.Thread.Sleep(led_delay);

                led_green_led1_state(false);
                System.Threading.Thread.Sleep(led_delay);
                led_green_led2_state(false);
                System.Threading.Thread.Sleep(led_delay);
                led_green_led3_state(false);
                System.Threading.Thread.Sleep(led_delay);
                led_green_led4_state(false);
                System.Threading.Thread.Sleep(led_delay);
                led_green_led5_state(false);
                System.Threading.Thread.Sleep(led_delay);
                led_green_led6_state(false);
                System.Threading.Thread.Sleep(led_delay);
                led_green_led7_state(false);
                System.Threading.Thread.Sleep(led_delay);
                led_green_led8_state(false);
                System.Threading.Thread.Sleep(led_delay);
            }
        }*/
    }
}
