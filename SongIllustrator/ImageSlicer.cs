using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace SongIllustrator
{
    public class ImageSlicer
    {
			/// <summary>
			/// Slices a bitmap image into a list of images.
			/// </summary>
			/// <param name="bitmap">The image to split.</param>
			/// <param name="canvasSize">The size the image needs to cover.</param>
			/// <param name="density">How many slices to the power of two are required.</param>
			/// <returns>The image list.</returns>
        public static List<Image> SliceImage(Bitmap bitmap, Size canvasSize, Size density) {
            List<Image> images = new List<Image>();
            Size buttonSize = new Size(canvasSize.Width / density.Width, canvasSize.Height / density.Height);
            for (int heightProgression = 0; heightProgression < density.Height; heightProgression++)
            {

                for (int widthProgression = 0; widthProgression < density.Width; widthProgression++)
                {
                    Bitmap button = new Bitmap(buttonSize.Width, buttonSize.Height);
                    Graphics graphics = Graphics.FromImage(button);
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.DrawImage(bitmap, new Rectangle(new Point(-widthProgression * button.Width, -heightProgression*button.Height), canvasSize));
                    images.Add(BitmapOpacity.SetImageOpacity(button, (float) 0.5));
                }
            }
            return images;
        }
    }
}
