﻿using UWPCore.Demo.Controls;
using UWPCore.Framework.Controls;
using UWPCore.Framework.Graphics;
using UWPCore.Framework.Storage;
using UWPCore.Framework.UI;
using Windows.Graphics.Imaging;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;

namespace UWPCore.Demo.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GraphicsPage : UniversalPage
    {
        public const string TEST_FILE_NAME = "TestRenderFrameworkElement.png";

        private IGraphicsService _graphicsService;
        private IStorageService _localStorageService;
        private IDialogService _dialogService;

        public GraphicsPage()
        {
            InitializeComponent();
            _graphicsService = Injector.Get<IGraphicsService>();
            _localStorageService = Injector.Get<ILocalStorageService>();
            _dialogService = Injector.Get<IDialogService>();
        }

        private async void RenderClicked(object sender, RoutedEventArgs e)
        {
            var title = TitleTextBox.Text;
            var subtitle = SubtitleTextBox.Text;
            var uiElementToRender = new TileSquareMedium(title, subtitle);
            HiddenRenderContainer.Children.Add(uiElementToRender);
            // TODO: Check if there is a way that rendering of a UI element not requires to add it to the visual tree? Or is there a nice way to hide these UI elements?

            var file = await _localStorageService.CreateOrGetFileAsync(TEST_FILE_NAME);
            RenderTargetBitmap renderResult;
            renderResult = await _graphicsService.RenderToFileAsync(uiElementToRender, file, BitmapEncoder.PngEncoderId);

            // show info about rendered image   
            await _dialogService.ShowAsync(
                string.Format("Image resolution: {0}x{1}.\nUse WMPowerTools to verify the rendered file: {2}",
                    renderResult.PixelWidth,
                    renderResult.PixelHeight,
                    TEST_FILE_NAME),
                "Information");
        }
    }
}
