using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class Levelup : MonoBehaviour
{
    private Button upgradeLevelButton;
    [SerializeField] private ShowObject showObj;
    private void Awake()
    {
        upgradeLevelButton = GetComponent<Button>();    
    }

    private void OnEnable()
    {
        upgradeLevelButton.onClick.AddListener(UpgradeLevel);
    }

    private void OnDisable()
    {
        upgradeLevelButton.onClick.RemoveListener(UpgradeLevel);
    }

    private void UpgradeLevel()
    {
        int level = ++YandexGame.savesData.level;
        int premiumMoney = GameLogic.instance.premiumMoney;

        YandexGame.ResetSaveProgress();
        YandexGame.NewLeaderboardScores("LevelScore", level);
        showObj.HideAll();
        YandexGame.savesData.level = level;
        YandexGame.savesData.premiumMoney = premiumMoney;
        
        saveSystem.loadData();

        YandexGame.SaveProgress();
    }
}
