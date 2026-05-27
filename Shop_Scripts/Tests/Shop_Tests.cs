using NUnit.Framework;

namespace CleanRefactor.Tests
{
    public class Shop_Tests
    {
        Player player;
        ShopLogic shop;
        BombItem bomb;
        ShieldItem shield;
        DoubleCoinsItem doubleCoins;
        MockSaveSystem saveSystem;

        [SetUp]
        public void Setup()
        {
            player = new Player();
            bomb = new BombItem(100, -1, 3);
            shield = new ShieldItem(150, -1, 2);
            doubleCoins = new DoubleCoinsItem(300, 5, 1);
            saveSystem = new MockSaveSystem();
            shop = new ShopLogic(saveSystem);
           
        }

        [Test]
        public void When_EnoughCoins_Then_CanBuyBomb()
        {

            player.AddCoins(100);
            ShopNotification notification = shop.BuyItem(bomb, player);

            Assert.AreEqual(ShopNotification.NotificationType.PurchaseComplete, notification.type);
        }

        [Test]
        public void When_NotEnoughCoins_Then_CannotBuyBomb()
        {
            shop.BuyItem(bomb, player);

            ShopNotification notification = shop.BuyItem(bomb, player);

            Assert.AreEqual(ShopNotification.NotificationType.NotEnoughCoins, notification.type);
        }

        [Test]
        public void When_BombMaxUsesReached_Then_CantBuy() 
        {
            player.AddCoins(500);

            shop.BuyItem(bomb, player);
            shop.BuyItem(bomb, player);
            shop.BuyItem(bomb, player);

            ShopNotification notification = shop.BuyItem(bomb, player);

            Assert.AreEqual(ShopNotification.NotificationType.MaxUsesReached, notification.type);
        }

        [Test]
        public void When_EnoughCoins_Then_CanBuyShield() 
        {
            player.AddCoins(150);

            ShopNotification notification = shop.BuyItem(shield, player);

            Assert.AreEqual(ShopNotification.NotificationType.PurchaseComplete, notification.type);
        }
        [Test]
        public void When_ShieldMaxUsesReached_Then_CantBuy()
        {
            player.AddCoins(600);

            shop.BuyItem(shield, player);
            shop.BuyItem(shield, player);

            ShopNotification notification = shop.BuyItem(shield, player);

            Assert.AreEqual(ShopNotification.NotificationType.MaxUsesReached, notification.type);
        }
        [Test]
        public void When_EnoughCoins_And_LevelRequirementMet_Then_CanBuyDoubleCoins()
        {
            player.SetPlayerLevel(5);
            player.AddCoins(300);

            ShopNotification notification = shop.BuyItem(doubleCoins, player);

            Assert.AreEqual(ShopNotification.NotificationType.PurchaseComplete, notification.type);

        }

        [Test]
        public void When_LevelRequirementNotMet_Then_CantBuyDoubleCoins()
        {
            player.SetPlayerLevel(4);
            player.AddCoins(300);

            ShopNotification notification = shop.BuyItem(doubleCoins, player);
            Assert.AreEqual(ShopNotification.NotificationType.RequiredLevelNotReached, notification.type);
        }
        [Test]
        public void When_AlreadyOwnsDoubleCoins_Then_CantBuyDoubleCoins()
        {
            player.SetPlayerLevel(5);
            player.AddCoins(600);

            shop.BuyItem(doubleCoins, player);

            ShopNotification notification = shop.BuyItem(doubleCoins, player);
            Assert.AreEqual(ShopNotification.NotificationType.AlreadyOwned, notification.type);
        }
        [Test]
        public void When_SuccessfullItemBuy_Then_PlayerCoinsAreReduced()
        {
            player.AddCoins(100);

            shop.BuyItem(bomb, player);
            Assert.AreEqual(0, player.coins);
        }
        [Test]
        public void When_SuccessfullyBuysItem_Then_PlayerIsSaved()
        {
            player.AddCoins(200);

            shop.BuyItem(bomb, player);

            player.AddCoins(1000);

            player.LoadPlayerData(saveSystem);
            
            Assert.AreEqual(100, player.coins);
        }
    }

    public class MockSaveSystem : ISaveSystem
    {
        public Player savedPlayer;
        public void SavePlayerData(Player player)
        {
            savedPlayer = new Player();
            savedPlayer.coins = player.coins;
            savedPlayer.level = player.level;
            savedPlayer.bombUses = player.bombUses;
            savedPlayer.shieldUses = player.shieldUses;
            savedPlayer.hasDoubleCoins = player.hasDoubleCoins;
        }
        public void LoadPlayerData(Player player)
        {
            if (savedPlayer != null)
            {
                player.coins = savedPlayer.coins;
                player.level = savedPlayer.level;
                player.bombUses = savedPlayer.bombUses;
                player.shieldUses = savedPlayer.shieldUses;
                player.hasDoubleCoins = savedPlayer.hasDoubleCoins;
            }
        }
    }
}