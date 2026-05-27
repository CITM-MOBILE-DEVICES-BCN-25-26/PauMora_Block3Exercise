using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace CleanRefactor
{
    public class ShopItemSlotView : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI itemNameText;
        [SerializeField] TextMeshProUGUI itemCostText;
        [SerializeField] TextMeshProUGUI itemUsesText;
        [SerializeField] TextMeshProUGUI buttonText;
        [SerializeField] public Button buyButton;

        Player player;
        ShopPresenter shopPresenter;
        ShopItem shopItem;
        ShopVFX shopVFX;

        public void Initialize(ShopItem item, Player player, ShopPresenter presenter, ShopVFX vfx)
        {
            shopItem = item;
            this.player = player;
            shopPresenter = presenter;
            shopVFX = vfx;
            RefreshButton();
            buyButton.onClick.AddListener(BuyItem);
        }

        public void BuyItem()
        {
            ShopNotification shopNotification = shopPresenter.BuyItem(shopItem);

            shopVFX.DisplayPurchaseFeedback(shopNotification, buttonText);
        }

        public void RefreshButton()
        {
            itemNameText.text = shopItem.name;
            itemCostText.text = $"Cost: {shopItem.price} coins";
            itemUsesText.text = GetItemUsesText();
            buttonText.text = "Buy";
        }

        private string GetItemUsesText()
        {
            switch (shopItem)
            {
                case BombItem bomb:
                    return $"Uses: {player.bombUses}";
                case ShieldItem shield:
                    return $"Uses: {player.shieldUses}";
                case DoubleCoinsItem doubleCoins:
                    if (player.hasDoubleCoins)
                    {
                        return "DoubleCoins enabled";
                    }
                    else
                    {
                        return "DoubleCoins disabled";
                    }
                default:
                    return "";
            }
        }
    }
}