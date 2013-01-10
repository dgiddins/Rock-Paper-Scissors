using NUnit.Framework;
using WebSite.Models;

namespace WebSiteTests.Model
{
    [TestFixture]
    public class ComputerMoveGeneratorTests
    {
        [Test]
        public void GeneratorSetsNameAsComputer()
        {
            var classUnderTest = new ComputerMoveGenerator();

            var result = classUnderTest.GenerateComputerMove();
            Assert.That(result.PlayerName, Is.EqualTo("Computer"));
        }

        [Test]
        public void GeneratorDoesNotReturnNull()
        {
            var classUnderTest = new ComputerMoveGenerator();

            var result = classUnderTest.GenerateComputerMove();
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void GeneratorSetsWeaponType()
        {
            var classUnderTest = new ComputerMoveGenerator();

            var result = classUnderTest.GenerateComputerMove();
            Assert.That(result.WeaponType, Is.Not.Null);
        }
    }
}