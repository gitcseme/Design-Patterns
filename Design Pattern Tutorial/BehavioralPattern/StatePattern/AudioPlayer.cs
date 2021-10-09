using StatePattern.States;
using StatePattern.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class AudioPlayer
    {
        private State _state;
        private readonly UserInterface UI;

        public bool IsPlaying { get; set; }

        public AudioPlayer()
        {
            IsPlaying = false;
            _state = new ReadyState(this);
            UI = new UserInterface();
        }

        public void UI_Check_By_Click()
        {
            Console.WriteLine($"Current State: {_state.GetType().Name}");
            UI.LockButton.OnClick(this);
            UI.PlayButton.OnClick(this);
            UI.NextButton.OnClick(this);
            UI.PreviousButton.OnClick(this);
        }

        public State CurrentState() => _state;

        public void ChangeState(State state)
        {
            _state = state;
        }

        /// <summary>
        /// Delegate execution to active state
        /// </summary>
        public void ClickLock() => _state.ClickLock();
        public void ClickPlay() => _state.ClickPlay();
        public void ClickNext() => _state.ClickNext();
        public void ClickPrevious() => _state.ClickPrevious();
        

        public void NextSong()
        {
            Console.WriteLine("Playing the next song");
        }

        public void StartPlayback()
        {
            Console.WriteLine("Starting the playback");
        }

        public void StopPlayback()
        {
            Console.WriteLine("Stoping the playback");
        }

        public void PreviousSong()
        {
            Console.WriteLine("Playing previous song");
        }
    }
}
