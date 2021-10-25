using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// ÉvÉåÉCÉÑÅ[ÇÃèàóù
/// </summary>
public class PlayerController : MonoBehaviour
{


    [SerializeField] private float Speed;
    [SerializeField] private float JumpPower;


    private Vector2 MoveVect;
    private Rigidbody2D rigt;

    public bool isStop;

    private void Start()
    {
        isStop = true;
        rigt = GetComponent<Rigidbody2D>();

        Observable.EveryUpdate()
            .Where(_ => Input.GetKey(KeyCode.D)&&isStop)
            .Subscribe(_ => PlayerMove()).AddTo(this);

        Observable.EveryUpdate()
            .Where(_ => Input.GetKey(KeyCode.A)&&isStop)
            .Subscribe(_ => PlayerMove()).AddTo(this);

        Observable.EveryUpdate()
            .Where(_ => Input.GetKeyDown(KeyCode.Space) && rigt.velocity.y == 0)
            .Subscribe(_ => PlayerJump()).AddTo(this);
    }

   
    private void PlayerMove()
    {
        MoveVect.x = Input.GetAxis("Horizontal")*Speed;
        MoveVect.y = rigt.velocity.y;
        rigt.velocity = MoveVect;
    }


    private void PlayerJump()
    {
        rigt.AddForce(transform.up * JumpPower);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }



}
