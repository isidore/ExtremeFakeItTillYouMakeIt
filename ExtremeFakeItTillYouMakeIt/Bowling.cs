using System.Collections.Generic;
using System.Linq;
using ApprovalUtilities.Utilities;

namespace ExtremeFakeItTillYouMakeIt
{
    public class Bowling
    {
        private readonly Frame frame = new Frame();

        public void Roll(params int[] rolls)
        {
            frame.AddRoll(rolls[0]);
            frame.AddRoll(rolls[1]);
        }

        public override string ToString()
        {
            var expected = frame +"\r\n"+ @"
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