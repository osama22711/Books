using ActionAdventureGame.Client;
using ActionAdventureGame.WeaponBehavior;

var swordBehavior = new SwordBehavior();
var king = new King(swordBehavior);

king.Fight();