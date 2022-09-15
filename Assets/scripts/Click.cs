using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using UnityEditor;
using YG;

public class Click : MonoBehaviour
{

    enum WorldNumber { first = 0, second = 1, Third = 2, fourth = 3, fifth = 4}
    [SerializeField] private Button _clickButton;
    [SerializeField] private GameObject parentEarning;
    [SerializeField] private TextMeshProUGUI clone;
    
    private AudioSource audio;
    private GameLogic _logic;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        _logic = GameLogic.instance;
        _clickButton.onClick.AddListener(() =>
        {
            AddMoney();
            spawnText();
            PlayAudio();
        });
    }

    private void spawnText()
    {

        float x = parentEarning.GetComponent<CanvasScaler>().referenceResolution.x / 5;
        float y = parentEarning.GetComponent<CanvasScaler>().referenceResolution.y / 5;
        Vector3 ClickPosition = new Vector3(Random.Range(-x, x), Random.Range(-y, y), 0);

        TextMeshProUGUI go = Instantiate(clone);

        go.transform.SetParent(parentEarning.transform, false);
        go.transform.GetComponent<RectTransform>().localPosition = ClickPosition;
        go.text = $"+{ConverterMoney.Convert((ulong)(_logic.oneClickCost * _logic.bonus))}"; // показать на экране сколько денег за соломанный блок
        Destroy(go.gameObject, .75f);

    }

    private void AddMoney()
    {
        ulong add = (ulong)(_logic.oneClickCost * _logic.bonus);
        _logic.AddMoney(add);
        YandexGame.savesData.moneyPerLevel += add;
    }
    private void PlayAudio() => audio.Play();
}