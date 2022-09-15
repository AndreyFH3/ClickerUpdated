using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class timeWarp : BuysBase
{
    [Header("Time Warp Scr")]
    [SerializeField] private GameObject canvas;
    [SerializeField] private int minutesWarp;
    public override void Buy()
    {
        GameLogic.instance.RemovePremiumMoney(_premiumPrice);
        ulong warpMoney = Bonus.TimeWarp(minutesWarp);
        GameLogic.instance.AddMoney(warpMoney);
        
        canvas.SetActive(true);
        TextMeshProUGUI text =  canvas.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        if(YandexGame.savesData.language == "ru")
            text.text = $"{ConverterMoney.Convert(warpMoney)} денег получено!";
        else
           text.text = $"{ConverterMoney.Convert(warpMoney)} money earned!";
    }

    public override void LoadProgress()
    {
        
    }

    public override void SaveProgress()
    {
        
    }

    public override void updateText()
    {
        if (YandexGame.savesData.language == "ru")
        {
            string str = isBuyUsualMoney ? $"{ConverterMoney.Convert(priceUsual)} денег" : $"{_premiumPrice} золота";
            priceText.text = str;
        }
        else
        {
            string str = isBuyUsualMoney ? $"{ConverterMoney.Convert(priceUsual)} money" : $"{_premiumPrice} gold";
            priceText.text = str;
        }
    }
}
