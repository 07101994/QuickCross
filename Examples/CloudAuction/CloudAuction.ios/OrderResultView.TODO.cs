﻿/* TODO: To complete adding the OrderResult storyboard view, follow these steps:
 *
 * 1 From Xamarin Studio, open the storyboard file to which you want to add the view.
 * 2 XCode will now open. In XCode, add your view to the storyboard.
 * 3 Set the Class name and the Storyboard ID for the controller to OrderResultView 
 *   (it is recommended to also check 'Use Storyboard ID' so you will use the same name for the Restoration ID).
 * 4 Save and switch back from XCode to Xamarin Studio to have the OrderResultView.cs and OrderResultView.designer.cs files generated.
 * 5 Copy and paste the complete code below over the content in the generated OrderResultView.cs file.
 * 6 Review the generated NavigateToOrderResultView method in your CloudAuctionNavigator class to see
 *   if it uses the navigation method that you intend (segue / push / ...).
 * 7 Delete this OrderResultView.TODO.cs file.

using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using QuickCross;
using CloudAuction;
using CloudAuction.Shared;
using CloudAuction.Shared.ViewModels;

namespace CloudAuction
{
    public partial class OrderResultView : ViewBase
    {
        private OrderResultViewModel ViewModel { get { return CloudAuctionApplication.Instance.OrderResultViewModel; } }

        public OrderResultView(IntPtr handle) : base(handle) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            InitializeBindings(View, ViewModel);
        }
    }
}

*/
