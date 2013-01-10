using System;

namespace WebSite.Models
{
    public class ComputerMoveGenerator : IComputerMoveGenerator
    {
        public Move GenerateComputerMove()
        {
            var randomNumberGenerator = new Random();
            var weaponIndex = randomNumberGenerator.Next(1, 3);

            var weapon = (Weapon) weaponIndex;

            return new Move() {PlayerName = "Computer", WeaponType = weapon};
        }
    }
}