using StatePattern.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class Program
    {
        public static void Main()
        {
            AudioPlayer audioPlayer = new();
            audioPlayer.UI_Check_By_Click();

            Console.WriteLine("\n");
            audioPlayer.ChangeState(new LockedState(audioPlayer));
            audioPlayer.UI_Check_By_Click();
        }
    }
}
