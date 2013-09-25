using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace AirDrop
{
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        UIWindow window;
        MyViewController viewController;

        public static bool RunningOnIPad { get; private set; }


        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            window = new UIWindow(UIScreen.MainScreen.Bounds);

            RunningOnIPad = UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad;

            viewController = new MyViewController();
            window.RootViewController = viewController;

            window.MakeKeyAndVisible();

            return true;
        }
    }
}

