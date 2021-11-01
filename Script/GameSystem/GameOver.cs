using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;
/// <summary>
/// �Q�[���I�[�o�[�̏���
/// </summary>
public class GameOver : MonoBehaviour
{

    [SerializeField] private Text GameOverText;
    [SerializeField] private GameObject GameOverPanel;

   

    /// <summary>
    /// ���Ԑ؂�̎��̏���
    /// </summary>
    public void TimeOver()
    {
        GameOverText.text = "TimeOver";

        PanelDown();
    }

    /// <summary>
    /// �M�~�b�N�ɓ������Ă��܂������̏���
    /// </summary>
    public void HitEnmy()
    {
        GameOverText.text = "YouDead";

        PanelDown();
    }

    /// <summary>
    /// �Q�[���I�[�o�[�ɂȂ����Ƃ��ɏo���p�l��
    /// </summary>
    private void PanelDown()
    {

        GameOverPanel.transform.DOLocalMoveY(0, 0.5f)
            .SetLink(gameObject)
            .SetEase(Ease.Linear);
    }

}
