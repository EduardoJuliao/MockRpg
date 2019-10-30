using NUnit.Framework;
using RPG.Domain.Entities;

namespace Tests
{
    public class AdventurerTests
    {
        private Adventurer adventurer { get; set; }

        [SetUp]
        public void Setup()
        {
            adventurer = new Adventurer
            {
                Level = 1,
                Experience = 0,
                NextExperience = 5,
                Health = 10,
                Mana = 5,
                MaxHealth = 10,
                MaxMana = 5
            };
        }

        [Test]
        public void AdventurerTakesDamages()
        {
            adventurer.TakeDamage(3);

            Assert.AreEqual(7, adventurer.Health);
        }

        [Test]
        public void AdventurerDies()
        {
            adventurer.TakeDamage(adventurer.Health);

            Assert.AreEqual(0, adventurer.Health);
        }

        [Test]
        public void AdventurerTakesMoreThanMaxHealth()
        {
            adventurer.TakeDamage(adventurer.MaxHealth + 1);

            Assert.AreEqual(0, adventurer.Health);
        }

        [Test]
        public void AddExperience()
        {
            adventurer.AddExperience(3);

            Assert.AreEqual(3, adventurer.Experience);
        }

        [Test]
        public void Levelup()
        {
            adventurer.AddExperience(adventurer.NextExperience + 1);

            Assert.AreEqual(1, adventurer.Experience);
            Assert.AreEqual(2, adventurer.Level);
        }

        [Test]
        public void LevelupMultiple()
        {
            adventurer.AddExperience(14);

            Assert.AreEqual(1, adventurer.Experience);
            Assert.AreEqual(3, adventurer.Level);
        }
    }
}