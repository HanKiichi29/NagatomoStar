using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// 手が出てくるギミック
/// </summary>

public class SuddenlyGimmiick : MonoBehaviour
{

    [SerializeField] private GameObject HandGimmick;
    [SerializeField] private GameObject Player;

    private float GimmickSpeed=10.0f;
    private void Start()
    {
        Observable.EveryUpdate()
            .Where(_ => Input.GetKeyDown(KeyCode.Return))
            .Subscribe(_ => ShotHand()).AddTo(this);
    }


    private void ShotHand()
    {
        var HandClone= Instantiate(HandGimmick, transform.position,Quaternion.Euler(0,0,-40));
        HandClone.GetComponent<Rigidbody2D>().AddForce(Vector2.up*GimmickSpeed, ForceMode2D.Impulse);

    }
}
