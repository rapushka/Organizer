﻿#pragma checksum "..\..\..\..\..\..\Windows\Pages\GroupsTab\GroupsListPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "972420AA091FBAFBAE34F01EEE5892C2A886DDEC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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


namespace OrganizerCore.Windows.Pages.GroupsTab {
    
    
    /// <summary>
    /// GroupsListPage
    /// </summary>
    public partial class GroupsListPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\..\..\Windows\Pages\GroupsTab\GroupsListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox GroupTitleTextBox;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\..\..\Windows\Pages\GroupsTab\GroupsListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CourseTitleTextBox;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\..\..\Windows\Pages\GroupsTab\GroupsListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid GroupsDataGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/OrganizerCore;V1.0.0.0;component/windows/pages/groupstab/groupslistpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Windows\Pages\GroupsTab\GroupsListPage.xaml"
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
            
            #line 8 "..\..\..\..\..\..\Windows\Pages\GroupsTab\GroupsListPage.xaml"
            ((OrganizerCore.Windows.Pages.GroupsTab.GroupsListPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.GroupsListPage_OnLoaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.GroupTitleTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\..\..\..\..\Windows\Pages\GroupsTab\GroupsListPage.xaml"
            this.GroupTitleTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Search_OnTextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CourseTitleTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 42 "..\..\..\..\..\..\Windows\Pages\GroupsTab\GroupsListPage.xaml"
            this.CourseTitleTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Search_OnTextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.GroupsDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            
            #line 59 "..\..\..\..\..\..\Windows\Pages\GroupsTab\GroupsListPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 63 "..\..\..\..\..\..\Windows\Pages\GroupsTab\GroupsListPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 68 "..\..\..\..\..\..\Windows\Pages\GroupsTab\GroupsListPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RemoveButton_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

