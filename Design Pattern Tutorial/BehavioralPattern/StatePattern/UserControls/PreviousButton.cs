﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.UserControls
{
    public class PreviousButton : IButton
    {
        public void OnClick(AudioPlayer audioPlayer)
        {
            Console.WriteLine("Device clicked Previous");
            audioPlayer.ClickPrevious();
        }
    }
}
