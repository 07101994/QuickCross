﻿using System;
using MonoTouch.Foundation;
using CloudAuction;
using CloudAuction.Shared;
using MonoTouch.UIKit;
using CloudAuction.Shared.ViewModels;

namespace CloudAuction
{
    public class CloudAuctionNavigator : NSObject, ICloudAuctionNavigator
    {
        private static readonly Lazy<CloudAuctionNavigator> lazy = new Lazy<CloudAuctionNavigator>(() => new CloudAuctionNavigator());

        public static CloudAuctionNavigator Instance { get { return lazy.Value; } }

        private CloudAuctionNavigator() { }
            // If your app requires multiple navigation contexts, add additional constructor parameters or public properties
            // to pass them in, and then let the navigator manage when which context should be used.
            // E.g. you could use this in a universal app running in PAD mode when you have a master view and a detail view on the same screen.

		public UINavigationController NavigationContext { get; set; }
		public UITabBarController MainNavigationContext { get; set; }

        #region Generic navigation helpers

        private static bool IsPhone { get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; } }

        /// <summary>
        /// Navigate to a view controller instance.
        /// </summary>
        /// <param name="viewController"></param>
        /// <param name="animated"></param>
        private void Navigate(UIViewController viewController, bool animated = false)
        {
			if (NavigationContext == null || Object.ReferenceEquals(NavigationContext.TopViewController, viewController)) return;
            if (NavigationContext.ViewControllers != null)
            {
                foreach (var stackViewController in NavigationContext.ViewControllers)
                {
                    if (Object.ReferenceEquals(stackViewController, viewController))
                    {
                        NavigationContext.PopToViewController(viewController, animated);
                        return;
                    }
                }
            }
            NavigationContext.PushViewController(viewController, animated);
        }

        /// <summary>
        /// Navigate to a view based on a storyboard identifier and/or a view controller type.
        /// Assumes that no more than one instance of the specified controller type should exist in the navigation stack.
        /// </summary>
        /// <param name="viewControllerIdentifier">The storyboard identifier for a storyboard view controller; otherwise null.</param>
        /// <param name="viewControllerType">The view controller type. Specify for automatically navigating back to an existing instance if that exists on the navigation stack. Also specify to create non-storyboard view controller if none exists in the navigation stack.</param>
        /// <param name="animated">An optional boolean indicating whether the navigation transition should be animated</param>
        /// <param name="storyBoard">An optional storyBoard instance for instantiating view controllers. If not specified, NavigationContext.Storyboard will be used if needed.</param>
        private void Navigate(string viewControllerIdentifier, Type viewControllerType = null, bool animated = false, UIStoryboard storyBoard = null)
        {
			if (NavigationContext == null) return;
            if (viewControllerType != null)
            {
                if (NavigationContext.TopViewController != null && viewControllerType == NavigationContext.TopViewController.GetType()) return;
                if (NavigationContext.ViewControllers != null)
                {
                    foreach (var stackViewController in NavigationContext.ViewControllers)
                    {
                        if (stackViewController.GetType() == viewControllerType)
                        {
                            NavigationContext.PopToViewController(stackViewController, animated);
                            return;
                        }
                    }
                }
            }

            if (storyBoard == null) storyBoard = NavigationContext.Storyboard;

            var viewController = (viewControllerIdentifier != null && storyBoard != null) ?
                                 (UIViewController)storyBoard.InstantiateViewController(viewControllerIdentifier) :
                                 (UIViewController)Activator.CreateInstance(viewControllerType);
            NavigationContext.PushViewController(viewController, animated);
        }

        /// <summary>
        /// Navigate to a view based on a view controller type.
        /// Assumes that no more than one instance of the specified controller type should exist in the navigation stack.
        /// </summary>
        /// <param name="viewControllerType">The view controller type</param>
        /// <param name="animated">A boolean indicating whether the navigation transition should be animated</param>
        private void Navigate(Type viewControllerType, bool animated = false)
        {
            Navigate(null, viewControllerType, animated);
        }

        private void NavigateBack(bool animated = false)
        {
			if (NavigationContext == null) return;
            NavigationContext.PopViewControllerAnimated(animated);
        }

        private void NavigateSegue(string segueIdentifier, Type viewControllerType = null)
        {
			if (NavigationContext == null) return;
            if (NavigationContext.TopViewController != null)
            {
                if (viewControllerType != null && viewControllerType == NavigationContext.TopViewController.GetType()) return;
                NavigationContext.TopViewController.PerformSegue(segueIdentifier, this);
            }
        }

        #endregion Generic navigation helpers

        public void NavigateToPreviousView()
        {
            if (NavigationContext == null || NavigationContext.ViewControllers == null || NavigationContext.ViewControllers.Length < 2) return;
            NavigationContext.PopViewControllerAnimated(true);
        }

        public void NavigateToMainView(MainViewModel.SubView? subView)
        {
            Navigate("AuctionView", typeof(AuctionView)); // First return to the Auction view, if we pushed from that to another view
            if (subView.HasValue) // Then select the specified tab, if any
			{
				int tabIndex = (int)subView.Value;
				if (MainNavigationContext.SelectedIndex != tabIndex) MainNavigationContext.SelectedIndex = tabIndex;
			}
        }

        public void NavigateToProductView()
        {
            throw new NotImplementedException();
        }

        public void NavigateToOrderView()
        {
			Navigate("OrderView", typeof(OrderView));
        }

        public void NavigateToOrderResultView()
        {
            Navigate("OrderResultView", typeof(OrderResultView));
        }


        /* TODO: For each view, add a method to navigate to that view like this:

        public void NavigateTo_VIEWNAME_View()
        {
            Navigate("_VIEWNAME_View", typeof(_VIEWNAME_View), true); // TODO: If this is not a storyboard view, remove the viewControllerIdentifier parameter
        }
         * Note that the New-View command adds the above code automatically (see http://github.com/MacawNL/QuickCross#new-view). */

    }
}
