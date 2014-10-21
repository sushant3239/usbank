using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class UserDetails : UserControl
    {
        public UserDetails()
        {
            this.InitializeComponent();
        }

        public string FirstName
        {
            get { return (string)GetValue(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }

        public static readonly DependencyProperty FirstNameProperty =
            DependencyProperty.Register("FirstName", typeof(string), typeof(UserDetails), null);


        public string LastName
        {
            get { return (string)GetValue(LastNameProperty); }
            set { SetValue(LastNameProperty, value); }
        }

        public static readonly DependencyProperty LastNameProperty =
            DependencyProperty.Register("LastName", typeof(string), typeof(UserDetails), null);


        public ImageSource UserImage
        {
            get { return (ImageSource)GetValue(UserImageProperty); }
            set { SetValue(UserImageProperty, value); }
        }

        public static readonly DependencyProperty UserImageProperty =
            DependencyProperty.Register("UserImage", typeof(ImageSource), typeof(UserDetails), null);
        
    }
}
