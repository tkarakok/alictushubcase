using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiCoinInfoController : UiInfoController
{
    private void Start()
    {
        SetUIValues();
    }

    private void OnEnable()
    {
        EventManager.Instance.EventController.GetEvent<UIInfoEvent>().Data.AddListener(SetUIValues);
    }

    public override void SetUIValues()
    {
        base.SetUIValues();
        _valueText.text = GameManager.Instance.CoinCounter.ToString();
    }
}
