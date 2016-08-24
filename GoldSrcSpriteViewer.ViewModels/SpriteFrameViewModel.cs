using GalaSoft.MvvmLight;
using GoldSrcSpriteViewer.Core.Services;
using Microsoft.Practices.ServiceLocation;
using SharpGoldSrc.Sprites;
using System.Windows.Media;

namespace GoldSrcSpriteViewer.ViewModels
{
    public class SpriteFrameViewModel : ViewModelBase
    {
        private ImageSource bitmap;
        public ImageSource Bitmap
        {
            get { return this.bitmap; }
            private set { this.Set(ref this.bitmap, value); }
        }

        public SpriteFrameViewModel(SpriteFrame frame, SpritePalette palette)
        {
            var spriteConverter = ServiceLocator.Current.GetInstance<ISpriteFrameConverter>();

            this.Bitmap = spriteConverter.ConvertFrameToBitmap(frame, palette);
        }
    }
}
