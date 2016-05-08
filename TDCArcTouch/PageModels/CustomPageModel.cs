using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TDCArcTouch
{
	public class CustomPageModel : BasePageModel
    {
        private bool mommSelected;
        private bool defaultSelected;
        private bool kazumiSelected;
		private string name;
		private HtmlWebViewSource html;
		private IColorPicker colorPicker;
		private Color color;

		public CustomPageModel()
		{
			NextButtonCommand = new Command(NextButtonTapped);
			ShowColorPickerCommand = new Command(ShowColorPickerCommandTapped);

			Color = Colors.ORANGE;
			colorPicker = DependencyService.Get<IColorPicker>();

			Html = new HtmlWebViewSource()
				{ 
					Html = @"
		                <html>
		                <head>
		                </head>
		                    <body>
		                        Clique <a href='http://www.arctouch.com/'>aqui</a> para abrir os Termos e Condições
		                    </body>
		                </html>"
				};
		}

		protected internal override void OnAppearing()
		{
			base.OnAppearing();

			MessagingCenter.Subscribe<App, Color>((App)App.Current, Messages.COLOR_PICKED, OnColorPicked);
		}

		protected internal override void OnDisappearing()
		{
			MessagingCenter.Unsubscribe<App, Color>((App)App.Current, Messages.COLOR_PICKED);

			base.OnDisappearing();
		}

		private void OnColorPicked(object sender, Color color)
		{
			Color = color;
		}

		public ICommand NextButtonCommand { get; set; }

		public ICommand ShowColorPickerCommand { get; set; }
        
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

		public HtmlWebViewSource Html
		{
			get
			{
				return this.html;
			}
			set
			{
				if (this.html != value)
				{
					this.html = value;
					RaisePropertyChanged();
				}
			}
		}

		public Color Color
		{
			get
			{
				return this.color;
			}
			set
			{
				if (this.color != value)
				{
					this.color = value;
					RaisePropertyChanged();
				}
			}
		}

        private async void NextButtonTapped()
        {
            var avatarSelected = MommSelected || KazumiSelected || DefaultSelected;
            if(avatarSelected && !string.IsNullOrWhiteSpace(Name))
            {
                await (App.Current as App).DisplayAlert("Foi.");
            }
            else
            {
                await (App.Current as App).DisplayAlert("Selecione um avatar e informe seu nome.");
            }
		}

		private void ShowColorPickerCommandTapped()
		{
			colorPicker.Show();
		}
    }
}

