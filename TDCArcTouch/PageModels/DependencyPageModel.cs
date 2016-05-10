using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TDCArcTouch
{
    public class DependencyPageModel : CustomPageModel
    {
        private bool selected;
        private Color borderColor = Colors.GREY;
		private string avatarSource = Images.CAMERA;
		private string appVersion;
        private IColorPicker colorPicker;

        public DependencyPageModel() : base()
        {
            OpenGalleryCommand = new Command(OpenGallery);
            ShowColorPickerCommand = new Command(ShowColorPickerCommandTapped);

            BorderColor = Colors.ORANGE;
			this.colorPicker = DependencyService.Get<IColorPicker>();

			AppVersion = DependencyService.Get<IEnvironment>().GetAppVersion();
        }

        public ICommand OpenGalleryCommand { get; set; }

        public ICommand ShowColorPickerCommand { get; set; }
         
        public bool Selected
        {
            get
            {
                return this.selected;
            }
            set
            {
                if (this.selected != value)
                {
                    this.selected = value;
                    if (!value)
                    {
                        this.selected = true;
                    }
                    RaisePropertyChanged();
                }
            }
        }

        public Color BorderColor
        {
            get
            {
                return this.borderColor;
            }
            set
            {
                if (this.borderColor != value)
                {
                    this.borderColor = value;
                    RaisePropertyChanged();
                }
            }
        }
         
        public string AvatarSource
        {
            get
            {
                return this.avatarSource;
            }
            set
            {
                if (this.avatarSource != value)
                {
                    this.avatarSource = value;
                    RaisePropertyChanged();
                }
            }
		}

		public string AppVersion
		{
			get
			{
				return this.appVersion;
			}
			set
			{
				if (this.appVersion != value)
				{
					this.appVersion = value;
					RaisePropertyChanged();
				}
			}
		}

        protected override void GoToNextPage()
        {
            (Application.Current as App).NavigateTo<StockPage>();
        }

        protected internal override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<App, Color>((App)Application.Current, Messages.COLOR_PICKED, OnColorPicked);
        }

        protected internal override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<App, Color>((App)Application.Current, Messages.COLOR_PICKED);

            base.OnDisappearing();
        }

        private void OnColorPicked(object sender, Color color)
        {
            BorderColor = color;
        }

        private async void OpenGallery()
        {
            var selectedPicture = await DependencyService.Get<IMedia>().FromGallery();
            AvatarSource = selectedPicture;
        }

        private void ShowColorPickerCommandTapped()
        {
            this.colorPicker.Show();
        }
    }
}