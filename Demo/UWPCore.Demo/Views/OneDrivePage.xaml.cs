﻿using System.IO;
using UWPCore.Framework.Controls;
using UWPCore.Framework.Storage;
using Windows.UI.Xaml;

//https://github.com/OneDrive/onedrive-sdk-csharp/blob/master/docs/auth.md

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPCore.Demo.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OneDrivePage : UniversalPage
    {
        public OneDrivePage()
        {
            this.InitializeComponent();

            this.Loaded += OneDrivePage_Loaded;
        }

        private async void OneDrivePage_Loaded(object sender, RoutedEventArgs e)
        {
            // create example data if no exist
            var localStorageService = new LocalStorageService();
            var folder = localStorageService.GetFolderAsync("Data");            
            if(folder == null)
            {
                await localStorageService.CreateOrGetFolderAsync("Data");

                var file = await localStorageService.CreateOrGetFileAsync("loremipsum.txt");
                using (var stream = await file.OpenStreamForWriteAsync())
                {
                    using (var sw = new StreamWriter(stream))
                    {
                        await sw.WriteAsync("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.");
                    }
                }                
            }
        }
    }
}
