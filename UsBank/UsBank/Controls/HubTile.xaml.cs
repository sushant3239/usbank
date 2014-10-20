using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace UsBank.Controls
{
    public sealed partial class HubTile : UserControl
    {
        private bool isActive = false;

        public HubTile()
        {
            this.InitializeComponent();
        }

        public string HeaderText
        {
            get { return (string)GetValue(HeaderTextProperty); }
            set { SetValue(HeaderTextProperty, value); }
        }

        public static readonly DependencyProperty HeaderTextProperty =
            DependencyProperty.Register("HeaderText", typeof(string), typeof(HubTile), new PropertyMetadata(String.Empty));


        public ImageSource ActiveTileImage
        {
            get { return (ImageSource)GetValue(ActiveTileImageProperty); }
            set { SetValue(ActiveTileImageProperty, value); }
        }

        public static readonly DependencyProperty ActiveTileImageProperty =
            DependencyProperty.Register("ActiveTileImage", typeof(ImageSource), typeof(HubTile), null);


        public ImageSource InActiveTileImage
        {
            get { return (ImageSource)GetValue(InActiveTileImageProperty); }
            set { SetValue(InActiveTileImageProperty, value); }
        }

        public static readonly DependencyProperty InActiveTileImageProperty =
            DependencyProperty.Register("InActiveTileImage", typeof(ImageSource), typeof(HubTile), null);

        private void StackPanelTapped(object sender, TappedRoutedEventArgs e)
        {
            var panel = sender as StackPanel;
            if (panel != null)
            {
                SwitchTileStatus();
            }
        }

        private void SwitchTileStatus()
        {
            if (isActive)
            {
                
            }
            else
            {

            }
        }
    }
}
