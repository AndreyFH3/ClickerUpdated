using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using YG;

public class UIControl : MonoBehaviour
{
    [Header("Text on screen")]
    [SerializeField] private TextMeshProUGUI _moneyAmountText;
    [SerializeField] private TextMeshProUGUI _premiumMoneyAmountText;
    [SerializeField] private TextMeshProUGUI _moneyPerSecondText;
    [Header("Slider")]
    [SerializeField] private GameObject _sliderGameObject;
    [SerializeField] private TextMeshProUGUI _sliderText;
    [SerializeField] private Slider timeSlider;

    public static UIControl _UIcontrol;


    private void Start()
    {
        moneySet();
        Debug.Log(YandexGame.savesData.language);
        if(_UIcontrol == null) _UIcontrol = this;
        
    }
    private void OnEnable()
    {
        GameLogic.instance.everyFrameEvent += moneySet;
    }
    private void OnDisable()
    {
        GameLogic.instance.everyFrameEvent -= moneySet;
    }
    public void moneySet()
    {
        if (YandexGame.savesData.language == "ru")
        {
            _moneyAmountText.text = $"Денег: {ConverterMoney.Convert(GameLogic.instance.money)}";
            _premiumMoneyAmountText.text = $"Золото: {GameLogic.instance.premiumMoney}";
            _moneyPerSecondText.text = $"Денег в секунду: {ConverterMoney.Convert(GameLogic.instance.moneyPerSecond)}";
        }
        else
        {
            _moneyAmountText.text = $"Money: {ConverterMoney.Convert(GameLogic.instance.money)}";
            _premiumMoneyAmountText.text = $"Gold: {GameLogic.instance.premiumMoney}";
            _moneyPerSecondText.text = $"Money per second: {ConverterMoney.Convert(GameLogic.instance.moneyPerSecond)}";
        }
    }

    public void SetMaxSliderValue(int value) => timeSlider.maxValue = value;

    public void ActivateSlider(bool value) => _sliderGameObject.SetActive(value);

    public void SetSliderValue(int value)
    {
        timeSlider.value = value;
        SetSliderText(value);
    }
    private void SetSliderText(int value)
    {
        if (YandexGame.savesData.language == "ru") _sliderText.text = $"{value} сек.";
        else _sliderText.text = $"{value} sec.";
    }
}
