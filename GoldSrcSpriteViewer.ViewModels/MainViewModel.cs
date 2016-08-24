using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;

namespace GoldSrcSpriteViewer.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private RelayCommand openSpriteCommand;
        public RelayCommand OpenSpriteCommand
        {
            get
            {
                if (this.openSpriteCommand == null)
                {
                    this.openSpriteCommand = new RelayCommand(() =>
                    {
                        OpenFileDialog dlg = new OpenFileDialog();
                        dlg.Filter = "GoldSrc sprites|*.spr";
                        var result = dlg.ShowDialog();
                        if (result != null && result.Value == true)
                        {
                            this.Sprite = new SpriteViewModel(SharpGoldSrc.Sprites.Sprite.FromStream(dlg.OpenFile()));
                            this.CurrentFrameIndex = 0;
                        }
                    });
                }

                return this.openSpriteCommand;
            }
        }

        private SpriteViewModel sprite;
        public SpriteViewModel Sprite
        {
            get { return this.sprite; }
            private set
            {
                this.Set(ref this.sprite, value);
            }
        }

        private SpriteFrameViewModel currentFrame;
        public SpriteFrameViewModel CurrentFrame
        {
            get { return this.currentFrame; }
            private set
            {
                this.Set(ref this.currentFrame, value);
            }
        }

        private int currentFrameIndex;
        public int CurrentFrameIndex
        {
            get { return this.currentFrameIndex; }
            private set
            {
                this.Set(ref this.currentFrameIndex, value);
                this.CurrentFrame = this.Sprite.Frames[this.CurrentFrameIndex];
            }
        }
    }
}
