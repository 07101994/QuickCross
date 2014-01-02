#if TEMPLATE // To add a new storyboard table view class: in the Visual Studio Package Manager Console (menu View | Other Windows), use the New-View command with option -ViewType StoryBoardTable (enter "Get-Help New-View" for details) and then follow the instructions in the generated <name>View.TODO.cs file. Alternatively you can do all the actions that the New-View command does manually - either in Visual Studio or in Xamarin Studio: copy this file, then in the copy remove the enclosing #if TEMPLATE ... #endif lines and replace _VIEWNAME_ and _APPNAME_ with the viewmodel resp application name. Then follow the instructions in the comments on the first line and in the comments that start with "TODO: For each view, " in these files: Shared project: QuickCross\Templates\_VIEWNAME_ViewModel.cs, I_APPNAME_Navigator.cs and _APPNAME_Application.cs; App project: _APPNAME_Navigator.cs.
/* TODO: To complete adding the _VIEWNAME_ storyboard view, follow these steps:
 *
 * 1 From Xamarin Studio, open the storyboard file to which you want to add the view.
 * 2 XCode will now open. In XCode, add your view to the storyboard.
 * 3 Set the Class name and the Storyboard ID for the controller to _VIEWNAME_View 
 *   (it is recommended to also check 'Use Storyboard ID' so you will use the same name for the Restoration ID).
 * 4 Switch back from XCode to Xamarin Studio to have the _VIEWNAME_View.cs and _VIEWNAME_View.designer.cs files generated.
 * 5 Copy and paste the complete code below over the content in the generated _VIEWNAME_View.cs file.
 * 6 Review the generated NavigateTo_VIEWNAME_View method in your _APPNAME_Navigator class to see
 *   if it uses the navigation method that you intend (segue / push / ...).
 * 7 Delete this _VIEWNAME_View.TODO.cs file.

using System;
using QuickCross;
using QuickCross.Templates;
using QuickCrossLibrary.Templates;
using QuickCrossLibrary.Templates.ViewModels;

namespace QuickCross.Templates
{
	public partial class _VIEWNAME_View : TableViewBase
    {
		private _VIEWNAME_ViewModel ViewModel { get { return _APPNAME_Application.Instance._VIEWNAME_ViewModel; } }

		public _VIEWNAME_View(IntPtr handle) : base(handle) { }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			InitializeBindings(View, ViewModel);
		}
    }
}

*/
#endif // TEMPLATE