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
    [SerializeField] private GameOver gameover;

    private float second;

    private bool isStop=true;

    private void Start()
    {

        second = 10;

        Observable.EveryUpdate()
            .Where(_=>isStop)
            .Subscribe(_ => CountDown()).AddTo(this);

    }

    private void CountDown()
    {
        if (second >= 0)
        {
            second -= Time.deltaTime;
            TimeText.text = second.ToString("F1");
        }
        else
        {
            isStop = false;
            gameover.TimeOver();
            Debug.Log("タイムオーバー");
        }

    }
}
