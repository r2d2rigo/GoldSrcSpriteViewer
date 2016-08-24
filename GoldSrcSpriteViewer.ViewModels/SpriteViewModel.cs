using GalaSoft.MvvmLight;
using SharpGoldSrc.Sprites;
using System.Collections.ObjectModel;

namespace GoldSrcSpriteViewer.ViewModels
{
    public class SpriteViewModel : ViewModelBase
    {
        private Sprite sprite;

        private ObservableCollection<SpriteFrameViewModel> frames;
        public ObservableCollection<SpriteFrameViewModel> Frames
        {
            get { return this.frames; }
            private set
            {
                this.Set(ref this.frames, value);
            }
        }

        public SpriteViewModel(Sprite sprite)
        {
            this.sprite = sprite;

            this.Frames = new ObservableCollection<SpriteFrameViewModel>();
            foreach (var spriteFrame in this.sprite.Frames)
            {
                this.Frames.Add(new SpriteFrameViewModel(spriteFrame, this.sprite.Palette));
            }
        }
    }
}
