using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class MoneyBuy : MonoBehaviour
{
    private Button btn;
    [SerializeField] private ulong moneyAdd;
    [SerializeField] private int premiumPrice;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI goldAddText;
    private void Awake()
    {
        btn = GetComponent<Button>();
        priceText.text = YandexGame.savesData.language == "ru" ? $"{premiumPrice} золота" : $"{premiumPrice} gold";
        goldAddText.text = YandexGame.savesData.language == "ru" ? $"+{ConverterMoney.Convert(moneyAdd)} денег" : $"+{ConverterMoney.Convert(moneyAdd)} gold";
        
    }


    private void OnEnable()
    {
        GameLogic.instance.everyFrameEvent += CheckBuy;
        btn.onClick.AddListener(AddMoney);
        
    }

    private void OnDisable()
    {
        GameLogic.instance.everyFrameEvent -= CheckBuy; 
        btn.onClick.RemoveListener(AddMoney);
    }

    public void CheckBuy()
    {
        if(GameLogic.instance.premiumMoney >= premiumPrice)
        {
            priceText.color = Color.white;
            btn.interactable = true;
        }
        else
        {
            priceText.color = Color.red;
            btn.interactable = false;
        }
    }

    private void AddMoney()
    {
        GameLogic.instance.AddMoney(moneyAdd);
        GameLogic.instance.RemovePremiumMoney(premiumPrice);
    }
}
