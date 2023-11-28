using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponEvent : MonoBehaviour
{
    Human human;

    private void Awake()
    {
        human = GetComponentInParent<Human>();
    }

    public void WeaponOn()
    {
        human.OnPlayerWeapon();
    }

    public void WeaponOff()
    {
        human.OffPlayerWeapon();
    }
}       
