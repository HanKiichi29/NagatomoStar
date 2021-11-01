using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// 僕は中間訳のプレゼンターと申します
/// </summary>
public class Presenter : MonoBehaviour
{

    [SerializeField] private GameObject Player;
    [SerializeField] private Timer _timer;
    [SerializeField] private GameOver _gameOver;
  

    private PlayerController _playercontroller;
    private bool isTimeStop=true;


    private void Start()
    {
        var p = GameObject.FindGameObjectWithTag("Player");
        Player = p;
        _playercontroller = p.GetComponent<PlayerController>();

        Observable.EveryUpdate()
            .Where(_ => isTimeStop)
            .Subscribe(_ => _timer.CountDown()).AddTo(this);

        _timer.isTimeOutRP.Skip(1)
            .Subscribe(_ =>
            {
               PlayerStopOP();
               TimeOverOP();
            });

    }

    /// <summary>
    /// プレイヤーの操作を止める
    /// </summary>
    public void PlayerStopOP()
    {
        _playercontroller.isStop = false;
    }

    public void TimeOverOP()
    {
        isTimeStop = false;
        _gameOver.TimeOver();
    }
}
