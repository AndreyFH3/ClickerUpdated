using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class CheackLevelUp : MonoBehaviour
{
    [SerializeField] private GameObject ButtonToUpgrade;
    [SerializeField] private TextMeshProUGUI LevelText;
    void Update()
    {
        if (YandexGame.savesData.moneyPerLevel >= 3_000_000 * Mathf.Pow(1.1f, YandexGame.savesData.level-1))
        {
            ButtonToUpgrade.SetActive(true);
        }
        else
        {
            ButtonToUpgrade.SetActive(false);
        }
        LevelText.text = YandexGame.savesData.language == "ru" ? $"{YandexGame.savesData.level} уровень" : $"{YandexGame.savesData.level} level";

    }
}
