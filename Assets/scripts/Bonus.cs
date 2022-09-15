using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class Bonus : MonoBehaviour
{
    private static int bonusTimer = 30;
    [SerializeField] private Slider bonusSlider;

    public static void Multiplayer(int bonus) => GameLogic.instance.SetBonus(bonus);

    public static void AddPremiumMoney(int value) => GameLogic.instance.AddPremiumMoney(value);

    public static ulong TimeWarp(int minutes)
    {
        ulong add = GameLogic.instance.moneyPerSecond * (ulong)minutes * 60;
        YandexGame.savesData.moneyPerLevel += add;
        return add;

    }
    public static void SetBonusMultiplayer(int time, int multiplayer)
    { 
        bonusTimer = time;
        GameLogic.instance.SetBonus(multiplayer);
        
        UIControl._UIcontrol.ActivateSlider(true);
        UIControl._UIcontrol.SetMaxSliderValue(time);
        UIControl._UIcontrol.SetSliderValue(time);

        GameLogic.instance.oneSecondTimer += SBonus ; 
    }

    private static void SBonus()
    {
        bonusTimer -= 1;
        UIControl._UIcontrol.SetSliderValue(bonusTimer);
        if (bonusTimer <= 0)
        {
            GameLogic.instance.oneSecondTimer -= SBonus;
            UIControl._UIcontrol.ActivateSlider(false);
            GameLogic.instance.SetBonus(1);
        }
    }
    
}
