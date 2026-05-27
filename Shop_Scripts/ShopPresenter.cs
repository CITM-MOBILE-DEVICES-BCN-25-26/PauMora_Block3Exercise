using System.Collections.Generic;

namespace CleanRefactor
{
    public class ShopPresenter
    {
        ShopLogic logic;
        ShopView view;
        HashSet<ShopItem> items;
        Player player;
        ISaveSystem saveSystem;

        public ShopPresenter(ShopView view, HashSet<ShopItem> items, Player player, ISaveSystem saveSystem)
        {
            this.view = view;
            this.saveSystem = saveSystem;
            logic = new ShopLogic(this.saveSystem);   
            this.items = items;
            this.player = player;
        }

        public ShopNotification BuyItem(ShopItem item)
        {
            ShopNotification notification = logic.BuyItem(item, player);
            RefreshView();
            return notification;
        }

        public void RefreshView()
        {
            view.RefreshShopUI();
        }

        public void AddCoins(int amount)
        {
            player.AddCoins(amount);
            RefreshView();
        }

        public void RemoveCoins(int amount)
        {
            player.AddCoins(-amount);
            RefreshView();
        }

        public void AddLevel(int amount)
        {
            player.SetPlayerLevel(player.level + amount);
            RefreshView();
        }

        public void RemoveLevel(int amount)
        {
            player.SetPlayerLevel(player.level - amount);
            RefreshView();
        }

        public void SavePlayerData()
        {
            player.SavePlayerData(saveSystem);
            RefreshView();
        }

        public void LoadPlayerData()
        {
            player.LoadPlayerData(saveSystem);
            RefreshView();
        }
    }
}
