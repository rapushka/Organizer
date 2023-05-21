﻿#pragma checksum "..\..\..\..\..\..\Windows\Pages\StudentsTab\StudentsListPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FCBA686A8DFD10297409492FC24348A70D36A2AC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace OrganizerCore.Windows.Pages.StudentsTab {
    
    
    /// <summary>
    /// StudentsListPage
    /// </summary>
    public partial class StudentsListPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\..\..\Windows\Pages\StudentsTab\StudentsListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FullnameSearchTextBox;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\..\..\Windows\Pages\StudentsTab\StudentsListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker FromBirthdateDatePicker;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\..\..\Windows\Pages\StudentsTab\StudentsListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker ToBirthdateDatePicker;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\..\..\Windows\Pages\StudentsTab\StudentsListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid StudentsDataGrid;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\..\..\..\Windows\Pages\StudentsTab\StudentsListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid StudentCoursesDataGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.16.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/OrganizerCore;component/windows/pages/studentstab/studentslistpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Windows\Pages\StudentsTab\StudentsListPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.16.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\..\..\..\Windows\Pages\StudentsTab\StudentsListPage.xaml"
            ((OrganizerCore.Windows.Pages.StudentsTab.StudentsListPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.StudentsListPage_OnLoaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.FullnameSearchTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 30 "..\..\..\..\..\..\Windows\Pages\StudentsTab\StudentsListPage.xaml"
            this.FullnameSearchTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FullnameSearchTextBox_OnTextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.FromBirthdateDatePicker = ((System.Windows.Controls.DatePicker)(target));
            
            #line 39 "..\..\..\..\..\..\Windows\Pages\StudentsTab\StudentsListPage.xaml"
            this.FromBirthdateDatePicker.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.OnPickedBirthdateChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ToBirthdateDatePicker = ((System.Windows.Controls.DatePicker)(target));
            
            #line 46 "..\..\..\..\..\..\Windows\Pages\StudentsTab\StudentsListPage.xaml"
            this.ToBirthdateDatePicker.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.OnPickedBirthdateChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.StudentsDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            
            #line 62 "..\..\..\..\..\..\Windows\Pages\StudentsTab\StudentsListPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowIndividualCoursesButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 67 "..\..\..\..\..\..\Windows\Pages\StudentsTab\StudentsListPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowGroupCoursesButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.StudentCoursesDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

