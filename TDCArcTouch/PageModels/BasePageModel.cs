using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TDCArcTouch
{
    public abstract class BasePageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected internal virtual void RaisePropertyChanged([CallerMemberName] string fieldName = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(fieldName));
            } 
		}

		protected internal virtual void OnAppearing()
		{
		}

		protected internal virtual void OnDisappearing()
		{
		}
    }
}

