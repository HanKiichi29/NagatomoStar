using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

/// <summary>
/// タイマー
/// </summary>
public class Timer : MonoBehaviour
{
    [SerializeField] private Text TimeText;
    private float Second;

    private ReactiveProperty<bool> isTimeOut=new ReactiveProperty<bool>(false);
    public IReadOnlyReactiveProperty<bool> isTimeOutRP => isTimeOut;

    private void Start()
    {

        Second = 10;

    }

    public void CountDown()
    {
        if (Second >= 0)
        {
            Second -= Time.deltaTime;
            TimeText.text = Second.ToString("F1");
        }
        else
        {
            isTimeOut.Value = true;
        }

    }
}
