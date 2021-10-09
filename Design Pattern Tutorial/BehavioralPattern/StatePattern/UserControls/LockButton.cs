using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.UserControls
{
    public class LockButton : IButton
    {
        public void OnClick(AudioPlayer audioPlayer)
        {
            Console.WriteLine("Device is LOCKED");
            audioPlayer.ClickPlay();
        }
    }
}
