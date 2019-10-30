using System;

namespace RPG.Domain.Entities
{
    public class Adventurer
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Experience { get; set; }
        public int MaxHealth { get; set; }
        public int MaxMana { get; set; }
        public int NextExperience { get; set; }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
                Health = 0;
        }

        public void AddExperience(int experience)
        {
            var totalRemaining = experience;

            do
            {
                var difference = NextExperience - Experience;
                var levelUpDifference = difference - totalRemaining;
                if (levelUpDifference < 0)
                    levelUpDifference *= -1;

                if (totalRemaining >= NextExperience)
                {
                    Experience = 0;
                    Level++;
                    NextExperience = (int)Math.Ceiling(NextExperience * Settings.NextLevelExperienceRating);
                    totalRemaining = totalRemaining - difference;
                }
                else
                {
                    Experience = totalRemaining;
                    totalRemaining = 0;
                }
            } while (totalRemaining > 0);
        }
    }
}
