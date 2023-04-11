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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            peaShooter.AttackTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            peaShooter.AttackTrigger = false;
        }
    }
}
