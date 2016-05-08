using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TDCArcTouch
{
    public partial class SelectableAvatar : ContentView
    {
        public static readonly BindableProperty SourceProperty = BindableProperty.Create(nameof(Source), typeof(string), typeof(SelectableAvatar), default(string), BindingMode.OneWay, null,
            propertyChanged: (bindable, oldValue, newValue) => {
                (bindable as SelectableAvatar).SetSource((string)newValue);
            }
        );

        public static readonly BindableProperty SelectedProperty = BindableProperty.Create(nameof(Selected), typeof(bool), typeof(SelectableAvatar), default(bool), BindingMode.TwoWay, null,
            propertyChanged: (bindable, oldValue, newValue) => {
                (bindable as SelectableAvatar).SetSelection((bool)newValue);
            }
        );

        public SelectableAvatar()
        {
            InitializeComponent();
            SetSelection(Selected);
        }

        public string Source
        {
            get { return (string)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }
        
        public bool Selected
        {
            get { return (bool)GetValue(SelectedProperty); }
            set { SetValue(SelectedProperty, value); }
        }

        public void OnTapped(object sender, EventArgs e)
        {
            SetSelection(!Selected);
        }

        public void SetSelection(bool selected)
        {
            Selected = selected;
            this.checkImage.IsVisible = Selected;
        }

        public void SetSource(string source)
        {
            this.avatar.Source = source;  
        }
    }
}

