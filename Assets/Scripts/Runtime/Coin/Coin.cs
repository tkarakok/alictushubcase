using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Coin : PoolObject, ICoin, ISpawner
{
    [SerializeField] private float _lastYPos;
    [SerializeField] private float _animDuration;

    private Tween _animTween;
    public void DoAnim()
    {
        _animTween = transform.DOMoveY(_lastYPos, _animDuration).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnEnable()
    {
        DoAnim();
    }

    private void OnDisable()
    {
        _animTween?.Kill();
    }

    public void SpawnObject(Vector3 pos)
    {
        transform.position = pos;
        transform.DOScale(Vector3.one * 2, .3f).SetEase(Ease.Flash);
    }
}
