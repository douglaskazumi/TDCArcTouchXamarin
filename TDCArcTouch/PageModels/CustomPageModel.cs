using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TDCArcTouch
{
    public class CustomPageModel : StockPageModel
    {
        private bool isLoading = true;
        private HtmlWebViewSource html;
		private IColorPicker colorPicker;
		private Color color;

        public CustomPageModel() : base()
        {
			ShowColorPickerCommand = new Command(ShowColorPickerCommandTapped);

			Color = Colors.ORANGE;
			colorPicker = DependencyService.Get<IColorPicker>();

            LoadData();
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

		public ICommand ShowColorPickerCommand { get; set; }

        public bool IsLoading
        {
            get
            { 
                return this.isLoading; 
            }
            set
            {
                if (this.isLoading != value)
                {
                    this.isLoading = value;
                    RaisePropertyChanged();
                }
            }
        }

		private void ShowColorPickerCommandTapped()
		{
			colorPicker.Show();
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

        protected override void GoToNextPage()
        {
            (App.Current as App).NavigateTo<AdvancedPage>();
        }

        private async Task LoadData()
        {
            await Task.Delay(1500);

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

            IsLoading = false;
        }
    }
}

