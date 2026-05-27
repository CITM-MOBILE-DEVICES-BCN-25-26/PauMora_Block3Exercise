using System.Collections.Generic;
using UnityEngine;

namespace CleanRefactor
{
    [System.Serializable]
    struct ShopItemConfigData
    {
        public int price;
        public int levelRequirement;
        public int maxUses;
    }

    public class ShopBootstrap : MonoBehaviour
    {
        [SerializeField] ShopView shopView;
        [SerializeField] ShopDebug shopDebug;
        PlayerPrefSaveSystem saveSystem;
        ShopPresenter shopPresenter;
        Player player;

        [SerializeField] ShopItemConfigData bombConfig;
        [SerializeField] ShopItemConfigData shieldConfig;
        [SerializeField] ShopItemConfigData doubleCoinsItemConfig;

        public void Awake()
        {
            BombItem bombItem = new BombItem(bombConfig.price, bombConfig.levelRequirement, bombConfig.maxUses);
            ShieldItem shieldItem = new ShieldItem(shieldConfig.price, shieldConfig.levelRequirement, shieldConfig.maxUses);
            DoubleCoinsItem doubleCoinsItem = new DoubleCoinsItem(doubleCoinsItemConfig.price, doubleCoinsItemConfig.levelRequirement, doubleCoinsItemConfig.maxUses);

            PlayerPrefSaveSystem saveSystem = new PlayerPrefSaveSystem();

            HashSet<ShopItem> shopItems = new HashSet<ShopItem>();
            shopItems.Add(bombItem);
            shopItems.Add(shieldItem);
            shopItems.Add(doubleCoinsItem);

            player = new Player();

            saveSystem = new PlayerPrefSaveSystem();
            shopPresenter = new ShopPresenter(shopView, shopItems, player, saveSystem);
            shopView.Initialize(shopItems, player, shopPresenter);
            shopDebug.Initialize(shopPresenter);
        }
    }
}
