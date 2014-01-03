﻿using System;
using QuickCross;

namespace QCTest1.Shared.ViewModels
{
    public class TestXib2ViewModel : ViewModelBase
    {
        public TestXib2ViewModel()
        {
            // TODO: Pass any services that the TestXib2 viewmodel needs as contructor parameters. 
        }

        #region Data-bindable properties and commands
        // TODO: Generate TestXib2 viewmodel data-bindable properties and commands here with prop* and cmd* code snippets
        
        // Example data-bound property and command:
        public int Count /* One-way data-bindable property generated with propdb1 snippet. Keep on one line - see http://goo.gl/Yg6QMd for why. */ { get { return _Count; } set { if (_Count != value) { _Count = value; RaisePropertyChanged(PROPERTYNAME_Count); } } } private int _Count; public const string PROPERTYNAME_Count = "Count";
        public RelayCommand IncreaseCountCommand /* Data-bindable command that calls IncreaseCount(), generated with cmd snippet. Keep on one line - see http://goo.gl/Yg6QMd for why. */ { get { if (_IncreaseCountCommand == null) _IncreaseCountCommand = new RelayCommand(IncreaseCount); return _IncreaseCountCommand; } } private RelayCommand _IncreaseCountCommand; public const string COMMANDNAME_IncreaseCountCommand = "IncreaseCountCommand";
        #endregion

		private void IncreaseCount() { Count++; QCTest1Application.Instance.ContinueToProductList(); } // Example command method
    }
}

// Design-time data support
#if DEBUG
namespace QCTest1.Shared.ViewModels.Design
{
    public class TestXib2ViewModelDesign : TestXib2ViewModel
    {
        public TestXib2ViewModelDesign()
        {
            // TODO: Initialize the TestXib2 viewmodel with hardcoded design-time data
        }
    }
}
#endif
