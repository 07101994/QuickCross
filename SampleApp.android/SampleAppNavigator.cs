﻿using System;

using Android.Content;
using QuickCross;
using SampleApp.Shared;


namespace SampleApp
{
    sealed class SampleAppNavigator : ISampleAppNavigator
    {
        private static readonly Lazy<SampleAppNavigator> lazy = new Lazy<SampleAppNavigator>(() => new SampleAppNavigator());

        public static SampleAppNavigator Instance { get { return lazy.Value; } }

        private SampleAppNavigator() { }

        public Context NavigationContext { get; set; }

        private void Navigate(Type type)
        {
            if (NavigationContext == null) return;
            if (AndroidHelpers.CurrentActivity != null && AndroidHelpers.CurrentActivity.GetType() == type) return;
            NavigationContext.StartActivity(type);
        }

        public void NavigateToSampleItemListView()
        {
            Navigate(typeof(SampleItemListView));
        }

        public void NavigateToSampleItemView()
        {
            Navigate(typeof(SampleItemView));
        }

        /* TODO: For each view, add a method to navigate to that view like this:

        public void NavigateTo_VIEWNAME_View()
        {
            Navigate(typeof(_VIEWNAME_View));
        }
         * Note that the New-View command adds the above code automatically (see http://github.com/MacawNL/QuickCross#new-view). */
    }
}
