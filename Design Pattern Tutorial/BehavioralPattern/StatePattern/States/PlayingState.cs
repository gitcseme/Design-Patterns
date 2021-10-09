namespace StatePattern.States
{
    public class PlayingState : State
    {
        public PlayingState(AudioPlayer audioPlayer) : base(audioPlayer)
        {
            audioPlayer.IsPlaying = true;
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
            this.audioPlayer.StopPlayback();
            this.audioPlayer.ChangeState(new ReadyState(this.audioPlayer));
        }

        public override void ClickPrevious()
        {
            this.audioPlayer.ClickPrevious();        
        }
    }
}