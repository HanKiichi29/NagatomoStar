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
    private Rigidbody2D Rigt;

    public bool isStop;

    private void Start()
    {
        isStop = true;
        Rigt = GetComponent<Rigidbody2D>();

        Observable.EveryUpdate()
            .Where(_ => Input.GetKey(KeyCode.D)&&isStop)
            .Subscribe(_ => PlayerMove()).AddTo(this);

        Observable.EveryUpdate()
            .Where(_ => Input.GetKey(KeyCode.A)&&isStop)
            .Subscribe(_ => PlayerMove()).AddTo(this);

        Observable.EveryUpdate()
            .Where(_ => Input.GetKeyDown(KeyCode.Space)&&isStop&& Rigt.velocity.y == 0)
            .Subscribe(_ => PlayerJump()).AddTo(this);
    }

   
    private void PlayerMove()
    {
        MoveVect.x = Input.GetAxis("Horizontal")*Speed;
        MoveVect.y = Rigt.velocity.y;
        Rigt.velocity = MoveVect;
    }


    private void PlayerJump()
    {
        Rigt.AddForce(transform.up * JumpPower);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }



}
