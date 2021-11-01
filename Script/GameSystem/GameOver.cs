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
    [SerializeField] private GameObject GameOverPanel;

   

    /// <summary>
    /// 時間切れの時の処理
    /// </summary>
    public void TimeOver()
    {
        GameOverText.text = "TimeOver";

        PanelDown();
    }

    /// <summary>
    /// ギミックに当たってしまった時の処理
    /// </summary>
    public void HitEnmy()
    {
        GameOverText.text = "YouDead";

        PanelDown();
    }

    /// <summary>
    /// ゲームオーバーになったときに出すパネル
    /// </summary>
    private void PanelDown()
    {

        GameOverPanel.transform.DOLocalMoveY(0, 0.5f)
            .SetLink(gameObject)
            .SetEase(Ease.Linear);
    }

}
