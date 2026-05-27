using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CleanRefactor
{
    public class ShopView : MonoBehaviour
    {
        public struct ShopItemUIData
        {
            public string name;
            public int price;
            public int levelRequirement;
            public int maxUses;
            public ShopItem item;
        }

        [SerializeField] GameObject itemSlotPrefab;
        [SerializeField] GameObject itemSlotGroup;
        [SerializeField] TextMeshProUGUI playerCoinsText;
        [SerializeField] TextMeshProUGUI playerLevelText;
        [SerializeField] ShopVFX shopVFX;

        List<GameObject> itemSlots = new List<GameObject>();

        Player player;
        ShopPresenter shopPresenter;
   
        public void Initialize(HashSet<ShopItem> items, Player player, ShopPresenter shopPresenter)
        {
            this.player = player;
            this.shopPresenter = shopPresenter;

            foreach (var item in items) 
            {
                SpawnSlot(item);
            }
            RefreshShopUI();
        }

        void SpawnSlot(ShopItem item)
        {
            GameObject slot = Instantiate(itemSlotPrefab, itemSlotGroup.transform);
            ShopItemSlotView slotView = slot.GetComponent<ShopItemSlotView>();
            slotView.Initialize(item, player, shopPresenter, shopVFX);

            itemSlots.Add(slot);
        }

        public void RefreshShopUI()
        {
            playerCoinsText.text = $"Coins: {player.coins}";
            playerLevelText.text = $"Level: {player.level}";
            foreach (var slot in itemSlots)
            {
                ShopItemSlotView slotView = slot.GetComponent<ShopItemSlotView>();
                slotView.RefreshButton();
            }
        }
    }   
}
