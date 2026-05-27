namespace CleanRefactor
{
    public class ShopLogic 
    {
        ISaveSystem saveSystem;

        public ShopLogic(ISaveSystem saveSystem) 
        {
            this.saveSystem = saveSystem;
        }

        public ShopNotification BuyItem(ShopItem item, Player player)
        {
            if (CheckItemUses(item, player) == false)
            {
                switch(item)
                {
                    case DoubleCoinsItem doubleCoins:
                        return new ShopNotification(ShopNotification.NotificationType.AlreadyOwned);
                    default:
                        return new ShopNotification(ShopNotification.NotificationType.MaxUsesReached);
                }
            }

            if (player.level < item.levelRequirement)
            {
                return new ShopNotification(ShopNotification.NotificationType.RequiredLevelNotReached);
            }

            if (player.coins >= item.price)
            {
                player.AddCoins(-item.price);
                item.AddToPlayer(player);
                saveSystem.SavePlayerData(player);

                return new ShopNotification(ShopNotification.NotificationType.PurchaseComplete);
            }
            else
            {
                return new ShopNotification(ShopNotification.NotificationType.NotEnoughCoins);
            }
        }

        public bool CheckItemUses(ShopItem item, Player player)
        {
            switch(item)
            {
                case BombItem bomb:
                    return player.bombUses < bomb.maxUses;
                case ShieldItem shield:
                    return player.shieldUses < shield.maxUses;
                case DoubleCoinsItem doubleCoins:
                    return !player.hasDoubleCoins;
                default:
                    return false;
            }
        }
    }
}
