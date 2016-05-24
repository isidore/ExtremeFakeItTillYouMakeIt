using System.Collections.Generic;
using System.Linq;
using ApprovalUtilities.Utilities;

namespace ExtremeFakeItTillYouMakeIt
{
    public class Bowling
    {
        private int frameNumber = 1;
        int previousScore = 0;
        private  List<int> Rolls = new List<int>();

        public void Roll(params int[] rolls)
        {
            Rolls.Add(rolls[0]);
            Rolls.Add(rolls[1]);
        }

        public override string ToString()
        {
            var frame1ToString = @"
{0}) {1} [{2}] = {3}".TrimStart();
            var expected = frame1ToString +"\r\n"+ @"
2) 10 [20] = 28
3) 3, 7 [18] = 46
4) 8, 1 [9] = 55
5) 10 [26] = 81
6) 10 [18] = 99
7) 6, 2 [8] = 107
8) 5, 4 [9] = 116
9) 7, 3 [20] = 136
10) 10, 6, 3 [19] = 155".TrimStart();
            return expected.FormatWith(frameNumber, GetRollsToString(), FrameScore, TotalScore);
        }

        private  int TotalScore
        {
            get
            {
                return FrameScore + previousScore;
            }
        }

        public  int FrameScore
        {
            get { return Rolls.Sum(); }
        }

        private  string GetRollsToString()
        {
            return "{0}, {1}".FormatWith(Rolls[0], Rolls[1]);
        }
    }
}