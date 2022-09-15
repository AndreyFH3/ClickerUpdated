using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class ShowObject : MonoBehaviour
{
    [SerializeField] private GameObject[] ObjectsToActiveteClick;
    [SerializeField] private GameObject[] ObjectsToActiveteAutoClick;

    private void OnEnable()
    {
        YandexGame.GetDataEvent += loadData;
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= loadData;
    }

    private void loadData()
    {
        for (int i = 0; i < ObjectsToActiveteClick.Length; i++)
        {
            if (YandexGame.savesData.upgradeClick[i] > 0)
                activateForClick(i);
        }
        for (int i = 0; i < ObjectsToActiveteAutoClick.Length; i++)
        {
            if (YandexGame.savesData.upgradeSeconds[i] > 0)
                activateForAutoClick(i);
        }

    }

    public void HideAll()
    {
        foreach (GameObject obj in ObjectsToActiveteClick)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in ObjectsToActiveteAutoClick)
        {
            obj.SetActive(false);
        }
    }

    public void activateForClick(int index) 
    {
        ObjectsToActiveteClick[index].SetActive(true);
    }

    public void activateForAutoClick(int index)
    {
        ObjectsToActiveteAutoClick[index].SetActive(true);
    }

}
