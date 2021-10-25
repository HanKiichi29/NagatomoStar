using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presenter : MonoBehaviour
{

    [SerializeField] private GameObject player;

    private PlayerController playercontroller;



    private void Start()
    {
        var p = GameObject.FindGameObjectWithTag("Player");
        player = p;
        playercontroller = p.GetComponent<PlayerController>();

    }
}
