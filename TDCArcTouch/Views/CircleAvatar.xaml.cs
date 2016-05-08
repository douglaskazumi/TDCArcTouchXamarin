using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TDCArcTouch
{
    public partial class CircleAvatar : ContentView
    {
		public static readonly BindableProperty SourceProperty = BindableProperty.Create(nameof(Source), typeof(string), typeof(CircleAvatar), default(string), BindingMode.OneWay, null,
            propertyChanged: (bindable, oldValue, newValue) => {
				(bindable as CircleAvatar).SetSource((string)newValue);
            }
        );

        public static readonly BindableProperty SelectedProperty = BindableProperty.Create(nameof(Selected), typeof(bool), typeof(CircleAvatar), default(bool), BindingMode.TwoWay, null,
            propertyChanged: (bindable, oldValue, newValue) => {
				(bindable as CircleAvatar).SetSelection((bool)newValue);
            }
        );

		public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(CircleAvatar), Colors.ORANGE, BindingMode.OneWay, null,
            propertyChanged: (bindable, oldValue, newValue) => {
            var self = bindable as CircleAvatar;
            self.SetBorderColor((Color)newValue);
        }
        );

        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(CircleAvatar), null, BindingMode.OneWay, null, delegate(BindableObject bindable, object oldValue, object newValue)
            {
                ((CircleAvatar)bindable).OnCommandChanged((ICommand)oldValue, (ICommand)newValue);
            });

        public CircleAvatar()
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

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public ICommand Command
        {
            get
            {
                return (ICommand)base.GetValue(CommandProperty);
            }

            set
            {
                base.SetValue(CommandProperty, value);
            }
        }

        public void OnTapped(object sender, EventArgs e)
        {
            if (!IsEnabled)
            {
                return;
            }

            SetSelection(!Selected);

            ICommand command = Command;
            if (command != null)
            {
                command.Execute(null);
            }
        }

        public void SetSelection(bool selected)
        {
            Selected = selected;
            SetBorderColor(selected ? BorderColor : Color.Gray);
        }

        public void SetBorderColor(Color borderColor)
        {
            this.avatar.BorderColor = borderColor;
        }

        public void SetSource(string source)
        {
            this.avatar.Source = source;  
        }

        private void OnCommandChanged(ICommand oldCommand, ICommand newCommand)
        {
            if (oldCommand != null)
            {
                oldCommand.CanExecuteChanged -= CommandCanExecuteChanged;
            }

            if (Command != null)
            {
                Command.CanExecuteChanged += CommandCanExecuteChanged;

                CommandCanExecuteChanged(this, EventArgs.Empty);

                return;
            }

            IsEnabled = true;
        }

        private void CommandCanExecuteChanged(object sender, EventArgs eventArgs)
        {
            if (Command != null)
            {
                IsEnabled = Command.CanExecute(null);
            }
        }
    }
}

