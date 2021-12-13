using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech;
using System.Speech.Synthesis;
namespace Evolution.General
{
  public  class SpreechText
    {
        public void SpeackText(string Talk )
        {
            SpeechSynthesizer hablar = new SpeechSynthesizer();
            hablar.Speak(Talk);
        }
    }
}
