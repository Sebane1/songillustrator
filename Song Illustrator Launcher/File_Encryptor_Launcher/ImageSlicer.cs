using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace SongIllustrator
{
    public class ImageSlicer
    {
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
