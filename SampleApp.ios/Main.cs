using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using QuickCross;

namespace SampleApp.ios
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
			ViewDataBindings.RegisterBindKey();
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
