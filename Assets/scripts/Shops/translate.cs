using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using YG;
public class translate : MonoBehaviour
{
    private TextMeshProUGUI fieldToTranslate;
    [SerializeField, TextArea] private string rusWords;
    [SerializeField, TextArea] private string engWords;

    private void Start()
    {
        fieldToTranslate = GetComponent<TextMeshProUGUI>();
        TranslateText();
        GameLogic.instance.translateUI += TranslateText;
    }
    
    private void OnDestroy()
    {
        GameLogic.instance.translateUI -= TranslateText;
    }

    private void TranslateText()
    {
        if (YandexGame.savesData.language == "ru")
            fieldToTranslate.text = rusWords;
        else
            fieldToTranslate.text = engWords;
    }
}
