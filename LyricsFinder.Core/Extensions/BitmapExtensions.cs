using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace LyricsFinder.Core.Extensions
{
    static class BitmapExtensions
    {
        public static BitmapSource ToBitmapSource(this Bitmap bitmap)
        {
            if (bitmap == null)
                throw new ArgumentNullException($"{nameof(bitmap)} can not be null.");

            var bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(
                               bitmap.GetHbitmap(),
                               IntPtr.Zero,
                               Int32Rect.Empty,
                               BitmapSizeOptions.FromEmptyOptions());

            bitmapSource.Freeze();

            return bitmapSource;
        }
    }
}
