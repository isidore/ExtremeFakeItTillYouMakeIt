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
            Frame frame = new Frame(1, 0);
            frame.AddRoll(rolls[0]);
            frame.AddRoll(rolls[1]);
            frames.Add(frame);
        }

        public override string ToString()
        {
            var expected = frames.JoinStringsWith(f => "" + f, "\r\n") +"\r\n"+ @"
2) 10 [20] = 28
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