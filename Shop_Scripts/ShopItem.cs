namespace CleanRefactor
{
    public abstract class ShopItem 
    {
        public ShopItem(int price, int levelRequirement, int maxUses)
        {
            this.price = price;
            this.name = "Unknown Item";
            this.levelRequirement = levelRequirement;
            this.maxUses = maxUses;
        }

        public int price;
        public string name;
        public int levelRequirement;
        public int maxUses;

        public abstract void AddToPlayer(Player player);

    }
}
