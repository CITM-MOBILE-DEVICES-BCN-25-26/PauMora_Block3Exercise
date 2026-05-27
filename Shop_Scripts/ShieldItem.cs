namespace CleanRefactor
{
    public class ShieldItem : ShopItem
    {
        public ShieldItem(int price, int levelRequirement, int maxUses) : base(price, levelRequirement, maxUses)
        {
            this.name = "Shield";
            this.price = price;
            this.levelRequirement = levelRequirement;
            this.maxUses = maxUses;
        }

        public override void AddToPlayer(Player player)
        {
            player.shieldUses++;
        }
    }
}
