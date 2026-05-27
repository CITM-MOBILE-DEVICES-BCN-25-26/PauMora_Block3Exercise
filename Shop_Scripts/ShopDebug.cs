using UnityEngine;
using UnityEngine.UI;

namespace CleanRefactor
{
    public class ShopDebug : MonoBehaviour
    {
        [SerializeField] Button Addcoins;
        [SerializeField] Button Removecoins;
        [SerializeField] Button AddLevel;
        [SerializeField] Button RemoveLevel;
        [SerializeField] Button SavePlayer;
        [SerializeField] Button LoadPlayer;

        ShopPresenter presenter;

        public void Initialize(ShopPresenter presenter)
        {
            this.presenter = presenter;
            Addcoins.onClick.AddListener(() => presenter.AddCoins(100));
            Removecoins.onClick.AddListener(() => presenter.RemoveCoins(100));
            AddLevel.onClick.AddListener(() => presenter.AddLevel(1));
            RemoveLevel.onClick.AddListener(() => presenter.RemoveLevel(1));
            SavePlayer.onClick.AddListener(() => presenter.SavePlayerData());
            LoadPlayer.onClick.AddListener(() => presenter.LoadPlayerData());
        }
    }
}
