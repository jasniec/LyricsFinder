using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using SystemInformation = System.Windows.Forms.SystemInformation;
using System.Windows.Input;
using System.Windows.Media;
using LyricsFinder.Core;

namespace LyricsFinder.Main.Controls
{
    /// <summary>
    /// Interaction logic for TitleControl.xaml
    /// </summary>
    public partial class TitleControl : UserControl
    {
        public delegate void ShowOptionsRequestedEventHandler();

        public event ShowOptionsRequestedEventHandler ShowOptionsRequested;

        public static readonly DependencyProperty ShowOptionsProperty = DependencyProperty.Register("ShowOptions",
            typeof(bool), typeof(TitleControl), new PropertyMetadata(false));

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title",
            typeof(string), typeof(TitleControl), new PropertyMetadata("title"));

        public bool ShowOptions
        {
            get { return (bool)base.GetValue(ShowOptionsProperty); }
            set
            {
                if (ShowOptions != value)
                {
                    base.SetValue(ShowOptionsProperty, value);
                    OnPropertyChanged();
                }
            }
        }

        public string Title
        {
            get { return (string)base.GetValue(TitleProperty); }
            set
            {
                if (Title != value)
                {
                    base.SetValue(TitleProperty, value);
                    OnPropertyChanged();
                }
            }
        }

        #region Button Brushes

        public static readonly DependencyProperty RegularButtonHoverBackgroundProperty = DependencyProperty.Register(
            "RegularButtonHoverBackground", typeof(Brush), typeof(TitleControl), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(128, 255, 255, 255))));

        public Brush RegularButtonHoverBackground
        {
            get { return (Brush)base.GetValue(RegularButtonHoverBackgroundProperty); }
            set { base.SetValue(RegularButtonHoverBackgroundProperty, value); }
        }

        public static readonly DependencyProperty CloseButtonHoverBackgroundProperty = DependencyProperty.Register(
            "CloseButtonHoverBackground", typeof(Brush), typeof(TitleControl), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(224, 67, 67))));

        public Brush CloseButtonHoverBackground
        {
            get { return (Brush)base.GetValue(CloseButtonHoverBackgroundProperty); }
            set { base.SetValue(CloseButtonHoverBackgroundProperty, value); }
        }

        public static readonly DependencyProperty RegularButtonClickBackgroundProperty = DependencyProperty.Register(
            "RegularButtonClickBackground", typeof(Brush), typeof(TitleControl), new PropertyMetadata(ColorPalette.DarkBrush));

        public Brush RegularButtonClickBackground
        {
            get { return (Brush)base.GetValue(RegularButtonClickBackgroundProperty); }
            set { base.SetValue(RegularButtonClickBackgroundProperty, value); }
        }

        public static readonly DependencyProperty CloseButtonClickBackgroundProperty = DependencyProperty.Register(
            "CloseButtonClickBackground", typeof(Brush), typeof(TitleControl), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(153, 61, 61))));

        public Brush CloseButtonClickBackground
        {
            get { return (Brush)base.GetValue(CloseButtonClickBackgroundProperty); }
            set { base.SetValue(CloseButtonClickBackgroundProperty, value); }
        }

        public static readonly DependencyProperty DefaultButtonForegroundProperty = DependencyProperty.Register(
            "DefaultButtonForeground", typeof(Brush), typeof(TitleControl), new PropertyMetadata(ColorPalette.FontBrush));

        public Brush DefaultButtonForeground
        {
            get { return (Brush)base.GetValue(DefaultButtonForegroundProperty); }
            set { base.SetValue(DefaultButtonForegroundProperty, value); }
        }

        public static readonly DependencyProperty RegularButtonHoverForegroundProperty = DependencyProperty.Register(
            "RegularButtonHoverForeground", typeof(Brush), typeof(TitleControl), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(0, 0, 0))));

        public Brush RegularButtonHoverForeground
        {
            get { return (Brush)base.GetValue(RegularButtonHoverForegroundProperty); }
            set { base.SetValue(RegularButtonHoverForegroundProperty, value); }
        }

        public static readonly DependencyProperty CloseButtonHoverForegroundProperty = DependencyProperty.Register(
            "CloseButtonHoverForeground", typeof(Brush), typeof(TitleControl), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(255, 255, 255))));

        public Brush CloseButtonHoverForeground
        {
            get { return (Brush)base.GetValue(CloseButtonHoverForegroundProperty); }
            set { base.SetValue(CloseButtonHoverForegroundProperty, value); }
        }

        public static readonly DependencyProperty RegularButtonClickForegroundProperty = DependencyProperty.Register(
            "RegularButtonClickForeground", typeof(Brush), typeof(TitleControl), new PropertyMetadata(ColorPalette.FontBrush));

        public Brush RegularButtonClickForeground
        {
            get { return (Brush)base.GetValue(RegularButtonClickForegroundProperty); }
            set { base.SetValue(RegularButtonClickForegroundProperty, value); }
        }

        public static readonly DependencyProperty CloseButtonClickForegroundProperty = DependencyProperty.Register(
            "CloseButtonClickForeground", typeof(Brush), typeof(TitleControl), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(255, 255, 255))));

        public Brush CloseButtonClickForeground
        {
            get { return (Brush)base.GetValue(CloseButtonClickForegroundProperty); }
            set { base.SetValue(CloseButtonClickForegroundProperty, value); }
        }

        #endregion

        protected virtual void OnShowOptionsRequested()
        {
            ShowOptionsRequested?.Invoke();
        }

        public TitleControl()
        {
            InitializeComponent();

            base.Height = SystemInformation.CaptionHeight;
            base.DataContext = this;

            base.Loaded += TitleControl_Loaded;
        }

        void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            Window.DragMove();
        }

        void TitleControl_Loaded(object sender, RoutedEventArgs e)
        {
            //take control of dragging.
            MouseLeftButtonDown += Window_MouseLeftButtonDown;
        }

        private Window Window
        {
            get { return FindAncestor<Window>(this as System.Windows.Controls.UserControl); }
        }

        private static T FindAncestor<T>(DependencyObject dependencyObject)
            where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(dependencyObject);

            if (parent == null) return null;

            var parentT = parent as T;
            return parentT ?? FindAncestor<T>(parent);
        }

        private void OptionsClick(object sender, RoutedEventArgs e)
        {
            OnShowOptionsRequested();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            Window.Close();
        }

        private void MinimizeClick(object sender, RoutedEventArgs e)
        {
            Window.WindowState = WindowState.Minimized;
        }
    }
}
