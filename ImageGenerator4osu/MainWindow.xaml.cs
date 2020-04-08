using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ImageGenerator4osu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ScrollViewer_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Debug.WriteLine($"mouse wheel {e.Delta}");
        }

        private void ScrollViewer_MouseEnter(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("mouse enter");
        }

        private void ScrollViewer_MouseLeave(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("mouse leave");
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            Debug.WriteLine($"preview mouse wheel {e.Delta}");
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                e.Handled = true;
                if (e.Delta > 0)
                {
                    CanvasScaleTransform.ScaleX = Math.Min(CanvasScaleTransform.ScaleX + 0.1, 64);
                    CanvasScaleTransform.ScaleY = Math.Min(CanvasScaleTransform.ScaleY + 0.1, 64);
                }
                else if (e.Delta < 0)
                {
                    CanvasScaleTransform.ScaleX = Math.Max(CanvasScaleTransform.ScaleX - 0.1, 0);
                    CanvasScaleTransform.ScaleY = Math.Max(CanvasScaleTransform.ScaleY - 0.1, 0);
                }

                return;
            }

            if (Keyboard.IsKeyDown(Key.LeftShift))
            {
                e.Handled = true;
                ScrollViewer.ScrollToHorizontalOffset(ScrollViewer.HorizontalOffset - e.Delta);
                return;
            }
        }
    }
}