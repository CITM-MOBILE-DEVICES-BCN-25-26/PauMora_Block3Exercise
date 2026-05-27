namespace CleanRefactor
{
    public class DoubleCoinsItem : ShopItem
    {
        public DoubleCoinsItem(int price, int levelRequirement, int maxUses) : base(price, levelRequirement, maxUses)
        {
            this.name = "Double Coins";
            this.price = price;
            this.levelRequirement = levelRequirement;
            this.maxUses = maxUses;
        }

        public override void AddToPlayer(Player player)
        {
            player.hasDoubleCoins = true;
        }
    }
}
