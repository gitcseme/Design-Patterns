using System;

namespace StatePattern.States
{
    public class LockedState : State
    {
        public LockedState(AudioPlayer audioPlayer) : base(audioPlayer)
        {
        }

        public override void ClickLock()
        {
            if (this.audioPlayer.IsPlaying)
                this.audioPlayer.ChangeState(new PlayingState(this.audioPlayer));
            else
                this.audioPlayer.ChangeState(new ReadyState(this.audioPlayer));
        }

        public override void ClickNext()
        {
            Console.WriteLine("Do nothing [device locked]");
        }

        public override void ClickPlay()
        {
            Console.WriteLine("Do nothing [device locked]");
        }

        public override void ClickPrevious()
        {
            Console.WriteLine("Do nothing [device locked]");
        }
    }
}