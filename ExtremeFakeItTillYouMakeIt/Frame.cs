using System.Collections.Generic;
using System.Linq;
using ApprovalUtilities.Utilities;

namespace ExtremeFakeItTillYouMakeIt
{
    public class Frame
    {
        private int frameNumber ;
        private int previousScore = 0;
        private  List<int> Rolls = new List<int>();

        public Frame(int frameNumber, int previousScore)
        {
            this.frameNumber = frameNumber;
            this.previousScore = previousScore;
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

        public  override string ToString()
        {
            var frame1ToString = @"
{0}) {1} [{2}] = {3}".TrimStart();
            return frame1ToString.FormatWith(frameNumber, GetRollsToString(), FrameScore, TotalScore);
        }

        private  string GetRollsToString()
        {
            if (IsStrike)
            {
                return "{0}".FormatWith(Rolls[0]);
                
            }
            return "{0}, {1}".FormatWith(Rolls[0], Rolls[1]);
        }

        public bool IsStrike { get { return Rolls.First() == 10; }}

        public void AddRoll(int roll)
        {
            Rolls.Add(roll);
        }
    }
}