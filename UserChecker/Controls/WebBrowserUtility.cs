﻿using System.Windows;
using System.Windows.Controls;

namespace UserChecker.Controls
{
    public static class WebBrowserUtility
    {
        public static readonly DependencyProperty BindableSourceProperty =
            DependencyProperty.RegisterAttached("BindableSource", typeof(string), typeof(WebBrowserUtility), new UIPropertyMetadata(null, BindableSourcePropertyChanged));

        public static string GetBindableSource(DependencyObject obj) => (string)obj.GetValue(BindableSourceProperty);

        public static void SetBindableSource(DependencyObject obj, string value) => obj.SetValue(BindableSourceProperty, value);

        public static void BindableSourcePropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            WebBrowser browser = o as WebBrowser;
            if (browser != null)
            {
                string uri = e.NewValue as string;
                if (!string.IsNullOrEmpty(uri))
                    browser.NavigateToString(uri);
            }
        }
    }
}