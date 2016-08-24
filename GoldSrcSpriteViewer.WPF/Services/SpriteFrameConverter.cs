using GoldSrcSpriteViewer.Core.Services;
using SharpGoldSrc.Sprites;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GoldSrcSpriteViewer.WPF.Services
{
    public class SpriteFrameConverter : ISpriteFrameConverter
    {
        public ImageSource ConvertFrameToBitmap(SpriteFrame frame, SpritePalette palette)
        {
            var pixelDataSize = frame.Width * frame.Height * 4;
            var pixelData = new byte[pixelDataSize];
            var offset = 0;
            foreach (var paletteIndex in frame.Data)
            {
                var pixelColor = palette.Entries[paletteIndex];
                pixelData[offset] = pixelColor.B;
                pixelData[offset + 1] = pixelColor.G;
                pixelData[offset + 2] = pixelColor.R;
                pixelData[offset + 3] = 0xFF;

                offset += 4;
            }

            var frameBitmap = WriteableBitmap.Create((int)frame.Width, (int)frame.Height, 96.0, 96.0, PixelFormats.Bgra32, null, pixelData, (int)frame.Width * 4);

            return frameBitmap;
        }
    }
}
