using System.Collections.Generic;
using System.Linq;
using ApprovalUtilities.Utilities;

namespace ExtremeFakeItTillYouMakeIt
{
    public class Bowling
    {
        private readonly List<Frame> frames = new List<Frame>();

        public void Roll(params int[] rolls)
        {
            var previousScore = 0;
            var rollIndex = 0;
            for (int frameNumber = 1; frameNumber <= 10; frameNumber++)
            {


                Frame frame = new Frame(frameNumber, previousScore);
                frame.AddRoll(rolls[rollIndex++]);
                if (frame.IsStrike)
                {
                    frame.AddRoll(rolls[rollIndex]);
                    frame.AddRoll(rolls[rollIndex + 1]);
                }
                else
                {
                    frame.AddRoll(rolls[rollIndex++]);
                    if (frame.IsSpare)
                    {
                        frame.AddRoll(rolls[rollIndex]);  
                    }
                }
                frames.Add(frame);
                previousScore = frame.TotalScore;
            }
           
        }

        public override string ToString()
        {
            return frames.JoinStringsWith(f => "" + f, "\r\n");
        }
    }
}