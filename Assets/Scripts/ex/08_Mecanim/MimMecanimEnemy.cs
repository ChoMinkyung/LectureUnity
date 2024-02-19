using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimMecanimEnemy : MonoBehaviour
{
    private int HP;
    private bool IsDie = false;
    CharacterController pcController;
    Animator animator;

    void Start()
    {
        pcController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        CharacterControll_Slerp();
    }

    private void CharacterControll_Slerp()
    {
        

    }
}
