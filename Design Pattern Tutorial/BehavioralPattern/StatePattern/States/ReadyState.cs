using System;

namespace StatePattern.States
{
    public class ReadyState : State
    {
        public ReadyState(AudioPlayer audioPlayer) : base(audioPlayer)
        {
        }

        public override void ClickLock()
        {
            this.audioPlayer.ChangeState(new LockedState(this.audioPlayer));
        }

        public override void ClickNext()
        {
            this.audioPlayer.NextSong();
        }

        public override void ClickPlay()
        {
            this.audioPlayer.StartPlayback();
            this.audioPlayer.ChangeState(new PlayingState(this.audioPlayer));
        }

        public override void ClickPrevious()
        {
            this.audioPlayer.PreviousSong();
        }
    }
}