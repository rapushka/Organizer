﻿#pragma checksum "..\..\..\..\..\..\Windows\Pages\Courses Tab\CoursesListPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "36BBF86769030D90D0ED381BF007A0B5D068C4E3"
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


namespace OrganizerCore.Windows.Pages {
    
    
    /// <summary>
    /// CoursesListPage
    /// </summary>
    public partial class CoursesListPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\..\..\..\Windows\Pages\Courses Tab\CoursesListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchByNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\..\..\Windows\Pages\Courses Tab\CoursesListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid CoursesDataGrid;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\..\..\Windows\Pages\Courses Tab\CoursesListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid TopicsOfCourseDataGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/OrganizerCore;component/windows/pages/courses%20tab/courseslistpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Windows\Pages\Courses Tab\CoursesListPage.xaml"
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
            
            #line 8 "..\..\..\..\..\..\Windows\Pages\Courses Tab\CoursesListPage.xaml"
            ((OrganizerCore.Windows.Pages.CoursesListPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SearchByNameTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\..\..\..\..\Windows\Pages\Courses Tab\CoursesListPage.xaml"
            this.SearchByNameTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchByTitleTextBox_OnTextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CoursesDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 55 "..\..\..\..\..\..\Windows\Pages\Courses Tab\CoursesListPage.xaml"
            this.CoursesDataGrid.LostFocus += new System.Windows.RoutedEventHandler(this.CoursesDataGrid_OnLostFocus);
            
            #line default
            #line hidden
            
            #line 56 "..\..\..\..\..\..\Windows\Pages\Courses Tab\CoursesListPage.xaml"
            this.CoursesDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CoursesDataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 66 "..\..\..\..\..\..\Windows\Pages\Courses Tab\CoursesListPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddCourseButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 70 "..\..\..\..\..\..\Windows\Pages\Courses Tab\CoursesListPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditSelectedCourseButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 74 "..\..\..\..\..\..\Windows\Pages\Courses Tab\CoursesListPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RemoveSelectedCourseButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.TopicsOfCourseDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            
            #line 100 "..\..\..\..\..\..\Windows\Pages\Courses Tab\CoursesListPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddTopicButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 104 "..\..\..\..\..\..\Windows\Pages\Courses Tab\CoursesListPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditSelectedTopicButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 108 "..\..\..\..\..\..\Windows\Pages\Courses Tab\CoursesListPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RemoveSelectedTopicButton_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

