namespace CleanRefactor
{
    public class ShopNotification
    {
        public enum NotificationType
        {
            PurchaseComplete,
            NotEnoughCoins,
            MaxUsesReached,
            RequiredLevelNotReached,
            AlreadyOwned
        }

        public NotificationType type;

        public ShopNotification(NotificationType type)
        {
            this.type = type;
        }

    }
}
