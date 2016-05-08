using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TDCArcTouch
{
    public class AdvancedPageModel : CustomPageModel
    {
        private bool selected;
        private Color borderColor = Color.FromHex("55565A");
        private string avatarSource = "camera";

        public AdvancedPageModel() : base()
        {
            OpenGalleryCommand = new Command(OpenGallery);
        }

        public ICommand OpenGalleryCommand { get; set; }
         
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

        protected override void GoToNextPage()
        {
            (App.Current as App).NavigateTo<StockPage>();
        }

        private async void OpenGallery()
        {
            await (App.Current as App).DisplayAlert("Camera");
        }
    }
}