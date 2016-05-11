using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TDCArcTouch
{
    public class StockPageModel : BasePageModel
    {
        private bool mommSelected;
        private bool defaultSelected;
        private bool kazumiSelected;
        private string name;

        public StockPageModel()
		{
			NextButtonCommand = new Command(NextButtonTapped);
			TaCButtonCommand = new Command(TaCButtonTapped);
        }

		public ICommand NextButtonCommand { get; set; }

		public ICommand TaCButtonCommand { get; set; }
        
        public bool MommSelected
        {
            get
            {
                return this.mommSelected;
            }
            set
            {
                if (this.mommSelected != value)
                {
                    this.mommSelected = value;
                    RaisePropertyChanged();
                    
                    if(MommSelected)
                    {
                        KazumiSelected = false;
                        DefaultSelected = false;
                    }
                }
            }
        }

        public bool DefaultSelected
        {
            get
            {
                return this.defaultSelected;
            }
            set
            {
                if (this.defaultSelected != value)
                {
                    this.defaultSelected = value;
                    RaisePropertyChanged();

                    if(DefaultSelected)
                    {
                        KazumiSelected = false;
                        MommSelected = false;
                    }
                }
            }
        }

        public bool KazumiSelected
        {
            get
            {
                return this.kazumiSelected;
            }
            set
            {
                if (this.kazumiSelected != value)
                {
                    this.kazumiSelected = value;
                    RaisePropertyChanged();

                    if(KazumiSelected)
                    {
                        MommSelected = false;
                        DefaultSelected = false;
                    }
                }
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    RaisePropertyChanged();
                }
            }
        }

        protected virtual void GoToNextPage()
        {
            (App.Current as App).NavigateTo<CustomPage>();
        }

        private async void NextButtonTapped()
        {
            var avatarSelected = MommSelected || KazumiSelected || DefaultSelected;
            if(avatarSelected && !string.IsNullOrWhiteSpace(Name))
            {
				await Task.Delay(1000);
                GoToNextPage();
            }
            else
            {
                await (App.Current as App).DisplayAlert("Selecione um avatar e informe seu nome.");
            }
		}

		private void TaCButtonTapped()
		{
			Device.OpenUri(new Uri("http://www.arctouch.com"));
		}
    }
}

