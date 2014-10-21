using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UsBank.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace UsBank.Controls
{
    public sealed partial class HeaderControl : UserControl
    {
        public HeaderControl()
        {
            this.InitializeComponent();
            Loaded += (sender, e) =>
            {
                var typeResolver = Container.TypeResolver.Instance;
                var accountManager = typeResolver.Resolve<IAccountManager>();
                var user = accountManager.CurrentUser;
                UserName = user.UserId;
                UserRole = "Region Manager";
            };
        }


        public string UserName
        {
            get { return (string)GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }

        public static readonly DependencyProperty UserNameProperty =
            DependencyProperty.Register("UserName", typeof(string), typeof(HeaderControl),null);


        public string UserRole
        {
            get { return (string)GetValue(UserRoleProperty); }
            set { SetValue(UserRoleProperty, value); }
        }

        public static readonly DependencyProperty UserRoleProperty =
            DependencyProperty.Register("UserRole", typeof(string), typeof(HeaderControl), null);



        public ImageSource UserImage
        {
            get { return (ImageSource)GetValue(UserImageProperty); }
            set { SetValue(UserImageProperty, value); }
        }

        public static readonly DependencyProperty UserImageProperty =
            DependencyProperty.Register("UserImage", typeof(ImageSource), typeof(HeaderControl), null);
    }
}
