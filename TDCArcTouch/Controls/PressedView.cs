using System;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace TDCArcTouch
{
	public class PressedView : ContentView
	{
		public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(PressedView), null, BindingMode.OneWay, null, delegate(BindableObject bindable, object oldValue, object newValue)
			{
				((PressedView)bindable).OnCommandChanged((ICommand)oldValue, (ICommand)newValue);
			}, null, null, null);

		public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create("CommandParameter", typeof(object), typeof(PressedView), null, BindingMode.OneWay, null, delegate(BindableObject bindable, object oldValue, object newValue)
			{
				((PressedView)bindable).CommandCanExecuteChanged(bindable, EventArgs.Empty);
			}, null, null, null);

		public PressedView()
		{
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

		public object CommandParameter
		{
			get
			{
				return base.GetValue(CommandParameterProperty);
			}

			set
			{
				base.SetValue(CommandParameterProperty, value);
			}
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
				IsEnabled = Command.CanExecute(CommandParameter);
			}
		}

		public virtual async Task SetPressed(bool pressed)
		{
			Opacity = pressed ? 0.5 : 1.0;
            if(pressed)
            {
                await this.ScaleTo(1.3, 250, Easing.BounceIn);
                await this.ScaleTo(1.0, 500, Easing.BounceOut);
            }
		}

		public void RaiseTapped()
		{
			if (!IsEnabled)
			{
				return;
			}

			ICommand command = Command;
			object parameter = CommandParameter;
			if (command != null)
			{
				command.Execute(parameter);
			}

			OnTapped();
		}

		#region Events

		public event EventHandler Tapped;

		protected virtual void OnTapped()
		{
			EventHandler tapped = Tapped;
			if (tapped != null)
			{
				tapped(this, EventArgs.Empty);
			}
		}

		#endregion
	}
}

