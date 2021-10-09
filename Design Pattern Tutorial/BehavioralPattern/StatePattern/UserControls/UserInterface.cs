using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.UserControls
{
    public class UserInterface
    {
        public UserInterface()
        {
            LockButton = new LockButton();
            PlayButton = new PlayButton();
            NextButton = new NextButton();
            PreviousButton = new PreviousButton();
        }

        public IButton LockButton { get; set; }
        public IButton PlayButton { get; set; }
        public IButton NextButton { get; set; }
        public IButton PreviousButton { get; set; }
    }
}
