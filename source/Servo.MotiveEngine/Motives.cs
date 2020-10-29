using System.Linq;

namespace Servo.MotiveEngine
{
    public class Motives
    {
        const int NAX_MOOD = 600;
        const int MAX_MOTIVE = 100;

        public Motives(int hunger, int bladder, int fun, int energy,
            int environment, int social)
        {
            Hunger = hunger;
            Bladder = bladder;
            Fun = fun;
            Energy = energy;
            Environment = environment;
            Social = social;
        }

        public int Hunger { get; set; }
        public int Bladder { get; set; }
        public int Fun { get; set; }
        public int Energy { get; set; }
        public int Environment { get; set; }
        public int Social { get; set; }

        /// <summary>
        /// The mood is the sum of all the motives.
        /// It deteremines the best course of action.
        /// </summary>
        public int Mood
        {
            get
            {
                var curMood = new[] { Hunger, Bladder, Fun,
                Social, Environment, Energy };

                return curMood.Sum();
            }
        }

        /// <summary>
        /// In the game, this would increament gradually
        /// until it reaches it's max motive.
        /// </summary>
        /// <param name="motive">Current Motive</param>
        /// <param name="input">New Motive</param>
        /// <returns>Changed Motive</returns>
        int CalcuateMotiveChange(int motive, int input)
        {
            var curMotive = motive;
            var curMood = Mood;

            // New motive equals the current motive plus the input
            var newMotive = curMotive + input;

            // New mood equals the new motive plus the current mood
            var newMood = newMotive + curMood;

            // Changed motive is the new motive with the limit
            var changedMotive = newMotive.MaxLimit(MAX_MOTIVE);

            // Does the new motive increase my current motive?
            // Does the new motive increase my overall mood?
            if (changedMotive >= curMotive && curMood <= newMood
                && changedMotive <= MAX_MOTIVE && curMood <= NAX_MOOD)
                return changedMotive;

            // Fall back to the current movement
            return curMotive;
        }

        public void ChangeHunger(int input)
        {
            Hunger = CalcuateMotiveChange(Hunger, input);
        }

        public void ChangeFun(int input)
        {
            Fun = CalcuateMotiveChange(Fun, input);
        }

        public void ChangeBladder(int input)
        {
            Bladder = CalcuateMotiveChange(Bladder, input);
        }

        public void ChangeSocial(int input)
        {
            Social = CalcuateMotiveChange(Social, input);
        }

        public void ChangeEnergy(int input)
        {
            Energy = CalcuateMotiveChange(Energy, input);
        }

        public void ChangeEnvironment(int input)
        {
            Environment = CalcuateMotiveChange(Environment, input);
        }
    }
}
