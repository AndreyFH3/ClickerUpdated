using Unity.VisualScripting;
using UnityEngine;
using YG;

public class ClickBuy : BuysBase
{
    [Header("CickBuy Script")]
    [SerializeField] private int id;
    [SerializeField] private int _addClick;
    [SerializeField] private int addClick => (int)(_addClick * Mathf.Pow(1.07f, YandexGame.savesData.level-1));

    public override void SaveProgress()
    {
        if(YandexGame.SDKEnabled)
            YandexGame.savesData.upgradeClick[id] = buysAmount; 
    }

    public override void LoadProgress()
    {
        buysAmount = YandexGame.savesData.upgradeClick[id];
        if (buysAmount > 0) FindObjectOfType<ShowObject>().activateForClick(id);

    }

    public override void Buy()
    {
        GameLogic.instance.OneClickCostAdd(addClick);
        GameLogic.instance.RemoveMoney(priceUsual);
        buysAmount++;
        updateText();
        if (buysAmount > 0) FindObjectOfType<ShowObject>().activateForClick(id);
    }

    public override void updateText()
    {
        if (YandexGame.savesData.language == "ru")
        {
            string str = isBuyUsualMoney ? $"{ConverterMoney.Convert(priceUsual)} денег" : $"{_premiumPrice} золота";
            priceText.text = str;
            AmountBuys.text = $"{buysAmount} куплено";
            bonusText.text = $"+{ConverterMoney.Convert((ulong)addClick)} денег за клик";
        }
        else
        {
            string str = isBuyUsualMoney ? $"{ConverterMoney.Convert(priceUsual)} money" : $"{_premiumPrice} gold";
            priceText.text = str;
            AmountBuys.text = $"{buysAmount} bought";
            bonusText.text = $"+{ConverterMoney.Convert((ulong)addClick)} money for click";
        }
    }
}
