using SharpGoldSrc.Sprites;
using System.Windows.Media;

namespace GoldSrcSpriteViewer.Core.Services
{
    public interface ISpriteFrameConverter
    {
        ImageSource ConvertFrameToBitmap(SpriteFrame frame, SpritePalette palette);
    }
}
