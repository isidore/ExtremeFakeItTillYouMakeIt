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
            Frame frame = new Frame(1, 0);
            frame.AddRoll(rolls[rollIndex++]);
            if (frame.IsStrike)
            {
                frame.AddRoll(rolls[rollIndex]);
                frame.AddRoll(rolls[rollIndex + 1]);
            }
            else
            {
                frame.AddRoll(rolls[rollIndex++]);
            }
            frames.Add(frame);
             previousScore = frame.TotalScore;
            frame = new Frame(2, previousScore);
            frame.AddRoll(rolls[rollIndex++]);
            if (frame.IsStrike)
            {
                frame.AddRoll(rolls[rollIndex]);
                frame.AddRoll(rolls[rollIndex+1]);
            }
            else
            {
                frame.AddRoll(rolls[rollIndex++]);
            }
            frames.Add(frame);
        }

        public override string ToString()
        {
            var expected = frames.JoinStringsWith(f => "" + f, "\r\n") +"\r\n"+ @"
3) 3, 7 [18] = 46
4) 8, 1 [9] = 55
5) 10 [26] = 81
6) 10 [18] = 99
7) 6, 2 [8] = 107
8) 5, 4 [9] = 116
9) 7, 3 [20] = 136
10) 10, 6, 3 [19] = 155".TrimStart();
            return expected;
        }
    }
}