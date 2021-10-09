namespace StatePattern.States
{
    public abstract class State
    {
        protected AudioPlayer audioPlayer;

        public State(AudioPlayer audioPlayer)
        {
            this.audioPlayer = audioPlayer;
        }

        public abstract void ClickLock();
        public abstract void ClickPlay();
        public abstract void ClickNext();
        public abstract void ClickPrevious();
    }
}