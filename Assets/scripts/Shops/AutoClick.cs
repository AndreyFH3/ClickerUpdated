using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using YG;

public class AutoClick : BuysBase
{
    [Header("AutoCickBuy Script")]
    [SerializeField] private int id;
    [SerializeField] private int _addPeroneSecond;
    [SerializeField] private int addPeroneSecond => (int)(_addPeroneSecond * Mathf.Pow(1.07f, YandexGame.savesData.level-1));
    public override void Buy()
    {
        GameLogic.instance.AddOneSecond(_addPeroneSecond);
        GameLogic.instance.RemoveMoney(priceUsual);
        buysAmount++;
        updateText();
        if (buysAmount > 0) FindObjectOfType<ShowObject>().activateForAutoClick(id);
    }

    public override void SaveProgress()
    {
        if(YandexGame.SDKEnabled)
            YandexGame.savesData.upgradeSeconds[id] = buysAmount;
    }

    public override void LoadProgress()
    {
        buysAmount = YandexGame.savesData.upgradeSeconds[id];
        if (buysAmount > 0) FindObjectOfType<ShowObject>().activateForAutoClick(id);

    }

    public override void updateText()
    {
        if (YandexGame.savesData.language == "ru")
        {
            string str = isBuyUsualMoney ? $"{ConverterMoney.Convert(priceUsual)} денег" : $"{_premiumPrice} золота";
            priceText.text = str;
            AmountBuys.text = $"{buysAmount} куплено";
            bonusText.text = $"+{ConverterMoney.Convert((ulong)addPeroneSecond)} денег в секунду";
        }
        else
        {
            string str = isBuyUsualMoney ? $"{ConverterMoney.Convert(priceUsual)} money" : $"{_premiumPrice} gold";
            priceText.text = str;
            AmountBuys.text = $"{buysAmount} bought";
            bonusText.text = $"+{ConverterMoney.Convert((ulong)addPeroneSecond)} money per second";
        }
    }
}
