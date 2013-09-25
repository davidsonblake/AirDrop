using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

namespace AirDrop
{
    public class MyViewController : UIViewController
    {
        UIButton _button;
        private UIImageView _imageView;
        private const float ButtonWidth = 200;
        private const float ButtonHeight = 50;

        public MyViewController()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var bounds = UIScreen.MainScreen.Bounds;

            //Initialize ImageView and set it as a 'background'
            _imageView = new UIImageView(bounds) {Image = UIImage.FromFile("IMG_5398.JPG")};
            _imageView.Image.Scale(bounds.Size);
            Add(_imageView);

            _button = UIButton.FromType(UIButtonType.RoundedRect);

            //Place button in the middle
            _button.Frame = new RectangleF(
                View.Frame.Width / 2 - ButtonWidth / 2,
                View.Frame.Height / 2 - ButtonHeight / 2,
                ButtonWidth,
                ButtonHeight);
            _button.BackgroundColor = UIColor.White;

            _button.SetTitle("Click me", UIControlState.Normal);

            _button.TouchUpInside += (sender, e) =>
            {
                //This constructor will give us the option to share the _imageView.Image via AirDrop
                var a = new UIActivityViewController(new NSObject[] { _imageView.Image }, null);
                PresentViewController(a, true, null);
            };

            _button.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleTopMargin |
                UIViewAutoresizing.FlexibleBottomMargin;

            View.AddSubview(_button);
        }
    }
}

