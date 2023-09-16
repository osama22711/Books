using ActionAdventureGame.Client;
using ActionAdventureGame.WeaponBehavior;
using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;

namespace ActionAdventureGame.Tests
{
    public class TestFile1
    {
        [Fact]
        public void InstansiateKnightClass_WhenWeaponIsUsed_ShouldUseWeaponAndPrintOutAMessage()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var weapon = fixture.Freeze<Mock<IWeaponBehavior>>();

            // Act
            var king = fixture.Create<King>();
            king.Fight();

            // Assert
            weapon.Verify(x => x.UseWeapon(), Times.Once);
        }
    }
}