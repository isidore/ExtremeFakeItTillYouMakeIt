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

        public  int TotalScore
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
            var frame1ToString = "{0}) {1} [{2}] = {3}";
            return frame1ToString.FormatWith(frameNumber, GetRollsToString(), FrameScore, TotalScore);
        }

        private  string GetRollsToString()
        {
            var rollsToDisplay = 2;

            if (frameNumber == 10)
            {
                rollsToDisplay = Rolls.Count;
            }
            else if (IsStrike)
            {
                rollsToDisplay = 1;

            }
            return Rolls.Take(rollsToDisplay).JoinStringsWith(n => "" + n, ", ");
  
        }

        public bool IsStrike { get { return Rolls.FirstOrDefault() == 10; }}
        public bool IsSpare { get { return Rolls.Take(2).Sum() == 10; } }

        public void AddRoll(int roll)
        {
            Rolls.Add(roll);
        }
    }
}