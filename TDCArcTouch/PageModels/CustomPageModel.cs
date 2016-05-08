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

        public CustomPageModel() : base()
        {
            LoadData();
        }

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
                            <style type=""text/css"">
                                body { 
                                    font-family: ""Arial Black"", Gadget, sans-serif; 
                                    font-size: 90%; 
                                    background-color: #F6F6F6;
                                }
                            </style>
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

