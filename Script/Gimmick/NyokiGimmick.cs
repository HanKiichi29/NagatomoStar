using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using DG.Tweening;

public class NyokiGimmick : MonoBehaviour
{

    [SerializeField] private GameObject FaviriteObj;

    private void Start()
    {
        Observable.EveryUpdate()
            .Where(_ => Input.GetKeyDown(KeyCode.T))
            .Subscribe(_ => Nyoki()).AddTo(this);
    }

    public void Nyoki()
    {

        FaviriteObj.transform.DOMoveY(1, 0.1f);
    }
}
