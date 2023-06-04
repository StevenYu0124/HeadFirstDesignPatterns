// setup
var king = new King();
king.WeaponBehavior = new AxeBehavior();
var queen = new Queen();
queen.WeaponBehavior = new BowAndArrowBehavior();
var troll = new Troll();
troll.WeaponBehavior = new KnifeBehavior();
var knight = new Knight();
knight.WeaponBehavior = new SwordBehavior();

// perform
king.Fight();
queen.Fight();
knight.Fight();
troll.Fight();

// change while running
king.WeaponBehavior = new SwordBehavior();
king.Fight();