﻿#pragma checksum "..\..\..\..\..\Windows\Pages\TopicEditPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D7F760F2A9C38BB27FA291A6178A079CE043CD5D"
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


namespace OrganizerCore.Windows.Pages {
    
    
    /// <summary>
    /// TopicEditPage
    /// </summary>
    public partial class TopicEditPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\..\..\Windows\Pages\TopicEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CourseTitleTextBox;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\..\Windows\Pages\TopicEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TitleTextBox;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\..\Windows\Pages\TopicEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid LessonsDataGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/OrganizerCore;component/windows/pages/topiceditpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Windows\Pages\TopicEditPage.xaml"
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
            
            #line 9 "..\..\..\..\..\Windows\Pages\TopicEditPage.xaml"
            ((OrganizerCore.Windows.Pages.TopicEditPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_OnLoaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CourseTitleTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TitleTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 59 "..\..\..\..\..\Windows\Pages\TopicEditPage.xaml"
            this.TitleTextBox.LostFocus += new System.Windows.RoutedEventHandler(this.TitleTextBox_OnLostFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LessonsDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            
            #line 85 "..\..\..\..\..\Windows\Pages\TopicEditPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditLessonsTypeButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 91 "..\..\..\..\..\Windows\Pages\TopicEditPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OkButton_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

