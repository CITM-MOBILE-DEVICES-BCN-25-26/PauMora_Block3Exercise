using UnityEngine;

namespace CleanRefactor
{
    public class PlayerPrefSaveSystem : ISaveSystem
    {
        public void SavePlayerData(Player player)
        {
            Player data = player;
            string json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString("PlayerData", json);
            PlayerPrefs.Save();
        }

        public void LoadPlayerData(Player player)
        {
            if (PlayerPrefs.HasKey("PlayerData"))
            {
                string json = PlayerPrefs.GetString("PlayerData");
                Player data = JsonUtility.FromJson<Player>(json);
                player.coins = data.coins;
                player.level = data.level;
                player.bombUses = data.bombUses;
                player.shieldUses = data.shieldUses;
                player.hasDoubleCoins = data.hasDoubleCoins;
            }
        }
    }
}
