using System.Collections.Generic;
using ApprovalUtilities.Utilities;

namespace ExtremeFakeItTillYouMakeIt
{
    public class Bowling
    {
        int frameNumber = 1;
        private static List<int> Rolls = new List<int>();

        public void Roll(params int[] rolls)
        {
            Rolls.Add(rolls[0]);
            Rolls.Add(rolls[1]);
        }

        public override string ToString()
        {
            var expected = @"
{0}) {1} [{2}] = 8
2) 10 [20] = 28
3) 3, 7 [18] = 46
4) 8, 1 [9] = 55
5) 10 [26] = 81
6) 10 [18] = 99
7) 6, 2 [8] = 107
8) 5, 4 [9] = 116
9) 7, 3 [20] = 136
10) 10, 6, 3 [19] = 155".TrimStart();
            return expected.FormatWith(frameNumber, GetRollsToString(), 8);
        }

        private static string GetRollsToString()
        {
            return "{0}, {1}".FormatWith(Rolls[0], Rolls[1]);
        }
    }
}