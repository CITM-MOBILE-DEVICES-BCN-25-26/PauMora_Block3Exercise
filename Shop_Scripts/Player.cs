namespace CleanRefactor
{
    public class Player 
    {
        public int coins;
        public int level;

        public int bombUses;
        public int shieldUses;
        public bool hasDoubleCoins;

        public void SetPlayerLevel(int level)
        {
            this.level = level;
        }

        public void AddCoins(int amount)
        {
            coins += amount;
        }

        public void SavePlayerData(ISaveSystem saveSystem)
        {
            saveSystem.SavePlayerData(this);
        }

        public void LoadPlayerData(ISaveSystem saveSystem)
        {
            saveSystem.LoadPlayerData(this);
        }
    }
}
