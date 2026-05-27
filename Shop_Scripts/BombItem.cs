namespace CleanRefactor
{
    public class BombItem : ShopItem
    {
        public BombItem(int price, int levelRequirement, int maxUses) : base(price, levelRequirement, maxUses)
        {
            this.name = "Bomb";
            this.price = price;
            this.levelRequirement = levelRequirement;
            this.maxUses = maxUses;
        }

        public override void AddToPlayer(Player player)
        {
            player.bombUses++;
        }
    }
}
