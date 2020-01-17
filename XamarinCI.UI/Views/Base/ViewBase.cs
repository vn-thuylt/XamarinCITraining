using System;
using Xamarin.Forms;
using XamarinCI.UI.ViewModels.Base;

namespace XamarinCI.UI.Views.Base
{
    public class ViewBase : ContentPage
    {
        private double _lastWidth, _lastHeight;

        public ViewBase()
        {
            /* ==================================================================================================
             * Binding the base property 'Page.Title' with ViewModelBase.Title, 
             * 'Page.IsBusy' with ViewModelBase.IsBusy
             * By default, all of our pages must inherit this.
             * ================================================================================================*/
            this.SetBinding(TitleProperty, nameof(ViewModelBase.Title), BindingMode.TwoWay);
            this.SetBinding(IsBusyProperty, nameof(ViewModelBase.IsBusy), BindingMode.TwoWay);
            SetupTemplatedContent();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            /* ==================================================================================================
             * restrict execute many times of built-in Page.OnSizeAllocated()
             * ================================================================================================*/
            if (!_lastWidth.Equals(width) && !_lastHeight.Equals(height))
            {
                var orientation = width > height ? ScreenOrientation.LandScape : ScreenOrientation.Portrait;
                ScreenRotated?.Invoke(this, new ScreenRotatedEventArg { Orientation = orientation });

                /* ==================================================================================================
                 * This provide for viewmodel, it execute once with the new orientation parameter
                 * ================================================================================================*/
                var vm = this.BindingContext as ViewModelBase;
                vm?.OnScreenRotated(orientation);
            }

            _lastWidth = width;
            _lastHeight = height;
        }

        /// <summary>
        /// Occurs when screen rotated. <para/>
        /// this event provide for code behind usage <para/>
        /// => only using this in a case of no more solutions within viewmodel
        /// </summary>
        public event EventHandler<ScreenRotatedEventArg> ScreenRotated;

        void SetupTemplatedContent()
        {
            ControlTemplate = new ControlTemplate(typeof(BusyIndicatorTemplate));
        }

        private class BusyIndicatorTemplate : Grid
        {
            public BusyIndicatorTemplate()
            {
                HorizontalOptions = LayoutOptions.Fill;
                VerticalOptions = LayoutOptions.Fill;
                Padding = Margin = 0;
                RowSpacing = ColumnSpacing = 0;
                ColumnDefinitions = new ColumnDefinitionCollection { new ColumnDefinition { Width = GridLength.Star } };
                RowDefinitions = new RowDefinitionCollection { new RowDefinition { Height = GridLength.Star } };

                // add the main presenter
                var presenter = new ContentPresenter { HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.Fill, Padding = 0, Margin = 0 };
                SetRow(presenter, 0);
                SetColumn(presenter, 0);
                Children.Add(presenter);

                // dim-gray background
                var indicatorGrid = new Grid
                {
                    HorizontalOptions = LayoutOptions.Fill,
                    VerticalOptions = LayoutOptions.Fill,
                    Padding = Margin = 0,
                    RowSpacing = ColumnSpacing = 0,
                    InputTransparent = false,
                    ColumnDefinitions = new ColumnDefinitionCollection { new ColumnDefinition { Width = GridLength.Star } },
                    RowDefinitions = new RowDefinitionCollection { new RowDefinition { Height = GridLength.Star } },
                    IsVisible = false // avoid flash on init
                };

                var boxView = new BoxView
                {
                    HorizontalOptions = LayoutOptions.Fill,
                    VerticalOptions = LayoutOptions.Fill,
                    Margin = 0,
                    BackgroundColor = Color.Black,
                    Opacity = .15,
                };
                SetRow(boxView, 0);
                SetColumn(boxView, 0);
                indicatorGrid.Children.Add(boxView);

                // busy indicator
                var indicator = new ActivityIndicator { IsRunning = true, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Margin = 0 };
                SetRow(indicator, 0);
                SetColumn(indicator, 0);
                indicatorGrid.Children.Add(indicator);

                SetRow(indicatorGrid, 0);
                SetColumn(indicatorGrid, 0);
                indicatorGrid.SetBinding(IsVisibleProperty, new Binding("Content.Parent.IsBusy", source: presenter));
                Children.Add(indicatorGrid);
            }
        }

        /* ==================================================================================================
         *  todo: implement other base logics of a view, anythings you want.
         * ================================================================================================*/
    }
}
