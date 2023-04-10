using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peaShooterRange : MonoBehaviour
{

    private peaShooter peaShooter;

    private void Awake()
    {
        peaShooter = GetComponentInParent<peaShooter>(); 
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Zombie"))
        {
            if(peaShooter.AttackTrigger == false)
                peaShooter.AttackTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (peaShooter.AttackTrigger == true)
            peaShooter.AttackTrigger = false;
    }
}
