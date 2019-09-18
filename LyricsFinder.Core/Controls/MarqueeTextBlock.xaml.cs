using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace LyricsFinder.Core.Controls
{
    /// <summary>
    /// Interaction logic for MarqueeTextBlock.xaml
    /// </summary>
    public partial class MarqueeTextBlock : UserControl
    {
        public MarqueeTextBlock()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text",
            typeof(string), typeof(MarqueeTextBlock), new FrameworkPropertyMetadata(string.Empty, (d, e) => { ((MarqueeTextBlock)d).Text = (string)e.NewValue; }));

        public string Text
        {
            get => _text;
            set
            {
                if (value != null)
                {
                    _text = value;
                    textBlock.Text = _text;
                    textBlockSecond.Text = _text;
                    SetWidth();
                }
            }
        }

        string _text;
        bool animationInProgress;
        DoubleAnimation doubleAnimation;
        DoubleAnimation doubleAnimationSecond;

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);

            if (textBlock.RenderSize.Width > canMain.RenderSize.Width && !animationInProgress)
            {
                animationInProgress = true;
                textBlock.BeginAnimation(Canvas.LeftProperty, doubleAnimation);
                textBlockSecond.BeginAnimation(Canvas.LeftProperty, doubleAnimationSecond);
            }
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);

            if (textBlock.RenderSize.Width <= canMain.RenderSize.Width)
            {
                animationInProgress = false;
                textBlock.BeginAnimation(Canvas.LeftProperty, null);
                textBlockSecond.BeginAnimation(Canvas.LeftProperty, null);
            }
        }

        private void DoubleAnimation_Completed(object sender, EventArgs e)
        {
            animationInProgress = false;

            if (IsMouseOver && textBlock.RenderSize.Width > canMain.RenderSize.Width)
            {
                animationInProgress = true;
                textBlock.BeginAnimation(Canvas.LeftProperty, doubleAnimation);
                textBlockSecond.BeginAnimation(Canvas.LeftProperty, doubleAnimationSecond);
            }
            else
            {
                textBlock.BeginAnimation(Canvas.LeftProperty, null);
                textBlockSecond.BeginAnimation(Canvas.LeftProperty, null);
            }
        }

        private void SetWidth()
        {
            textBlock.Dispatcher.Invoke(() => { }, DispatcherPriority.Render);

            doubleAnimation = new DoubleAnimation
            {
                From = 0,
                To = -textBlock.RenderSize.Width,
                Duration = new Duration(TimeSpan.Parse("0:0:10"))
            };
            doubleAnimationSecond = new DoubleAnimation
            {
                From = textBlock.RenderSize.Width,
                To = 0,
                Duration = new Duration(TimeSpan.Parse("0:0:10"))
            };
            doubleAnimation.Completed += DoubleAnimation_Completed;

            Canvas.SetLeft(textBlockSecond, textBlockSecond.RenderSize.Width);

            canHolder.Width = textBlock.RenderSize.Width;
        }

    }
}
