using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using YG;

public class ReviewAsk : MonoBehaviour
{
    private float timeAfterStart = 0;
    [SerializeField] private float timeToShow;
    [SerializeField] private GameObject ask;
    private void OnEnable()
    {
        YandexGame.GetDataEvent += CheckDisableController;
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= CheckDisableController;
    }

    private void CheckDisableController()
    {
        if(YandexGame.savesData.isRewiewEanbled)
            gameObject.SetActive(false);
    }

    private void Start()
    {
        if(YandexGame.SDKEnabled)
            CheckDisableController();
    }

    void Update()
    {
        timeAfterStart += Time.deltaTime;
        if(timeAfterStart >= timeToShow)
        {
            YandexGame.savesData.isRewiewEanbled = true;
            ask.SetActive(true);
        }
    }
}
