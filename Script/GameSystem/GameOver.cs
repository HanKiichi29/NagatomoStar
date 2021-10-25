using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;
/// <summary>
/// ゲームオーバーの処理
/// </summary>
public class GameOver : MonoBehaviour
{

    [SerializeField] private Text GameOverText;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject GameOverPanel;

    private PlayerController playerController;
    private void Start()
    {
        var p = GameObject.FindGameObjectWithTag("Player");
        player = p;
        playerController = p.GetComponent<PlayerController>();

    }

    
    public void TimeOver()
    {
        GameOverText.text = "TimeOver";

        PanelDown();
    }

    public void HitEnmy()
    {
        GameOverText.text = "YouDead";

        PanelDown();
    }

    private void PanelDown()
    {
        playerController.isStop = false;

        GameOverPanel.transform.DOLocalMoveY(0, 0.5f)
            .SetLink(gameObject)
            .SetEase(Ease.Linear);
    }

}
