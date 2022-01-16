using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PrismCore.Demo.Common
{
    public class PasswordBoxHelper
    {
        // 包含两个依赖附加属性 password, attach
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.RegisterAttached("Password",
            typeof(string), typeof(PasswordBoxHelper),
            new PropertyMetadata(new PropertyChangedCallback(OnPropertyChanged))
             );

        public static string GetPassword(DependencyObject dp)
        {
            return (string)dp.GetValue(PasswordProperty);
        }
        public static void SetPassword(DependencyObject dp, string value)
        {
            dp.SetValue(PasswordProperty, value);
        }

        public static readonly DependencyProperty AttachProperty = DependencyProperty.RegisterAttached("Attach",
            typeof(string), typeof(PasswordBoxHelper),
            new PropertyMetadata(new PropertyChangedCallback(OnAttachChanged))
             );

        public static string GetAttach(DependencyObject dp)
        {
            return (string)dp.GetValue(PasswordProperty);
        }
        public static void SetAttach(DependencyObject dp, string value)
        {
            dp.SetValue(PasswordProperty, value);
        }

        static bool _isUpdating = false;

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox pb = (d as PasswordBox);
            pb.PasswordChanged -= Pb_PasswordChanged;
            if (!_isUpdating)
            {
                (d as PasswordBox).Password = e.NewValue.ToString();
            }
            pb.PasswordChanged += Pb_PasswordChanged;
        }

        private static void OnAttachChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox pb = (d as PasswordBox);
            pb.PasswordChanged += Pb_PasswordChanged;
        }

        private static void Pb_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox pb = (sender as PasswordBox);
            _isUpdating = true;
            SetPassword(pb, pb.Password);
            _isUpdating = false;
        }
    }
}
