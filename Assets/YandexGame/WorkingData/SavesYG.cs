
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;
        public bool isFirstTry = true;

        // Ваши сохранения
        public int level = 1;
        public ulong money;
        public ulong moneyPerLevel;
        public ulong moneyPerSecond;
        public int premiumMoney;
        public int oneClickCost = 1;

        public int [] upgradeClick = new int[10];
        public int [] upgradeSeconds = new int[10];
        public string saveTime = "";

        public bool isSoundActive = true;
        public bool isRewiewEanbled = false;
    }

}
