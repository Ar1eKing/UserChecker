using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace UserChecker.Controls
{
    public class ExtendedTextBox : TextBox
    {
        public static readonly DependencyProperty IsNumericOnlyProperty
            = DependencyProperty.Register(nameof(IsNumericOnly), typeof(bool), typeof(ExtendedTextBox));

        public bool IsNumericOnly
        {
            get { return (bool)GetValue(IsNumericOnlyProperty); }
            set { SetValue(IsNumericOnlyProperty, value); }
        }

        public ExtendedTextBox() => Init();

        private void Init()
        {
            IsNumericOnly = false;
            base.PreviewTextInput += ExtendedTextBox_PreviewTextInput;
        }

        private void ExtendedTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (IsNumericOnly)
            {
                Regex regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
            }
        }
    }
}