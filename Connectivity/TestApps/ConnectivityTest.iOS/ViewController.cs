﻿using System;

using UIKit;
using Connectivity.Plugin;

namespace ConnectivityTest.iOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        bool reg;
        partial void ButtonRegister_TouchUpInside(UIButton sender)
        {
            if(!reg)
            {
                CrossConnectivity.Current.ConnectivityChanged += CrossConnectivity_Current_ConnectivityChanged;
            }
            else
            {    
                CrossConnectivity.Current.ConnectivityChanged -= CrossConnectivity_Current_ConnectivityChanged;
            }

            reg = !reg;
        }

        void CrossConnectivity_Current_ConnectivityChanged (object sender, Connectivity.Plugin.Abstractions.ConnectivityChangedEventArgs e)
        {
            InvokeOnMainThread(() =>
                {
                    new UIAlertView("status", "Connected: " + e.IsConnected + " Connected: " + CrossConnectivity.Current.IsConnected, null, "OK").Show();
                });
        }

        partial void ButtonStatus_TouchUpInside(UIButton sender)
        {
            LabelStatus.Text = "connected: " + CrossConnectivity.Current.IsConnected;
        }
    }
}

