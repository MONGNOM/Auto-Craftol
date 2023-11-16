using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitBase : MonoBehaviour
{
    public abstract void Attack();
    public abstract void Move();
    public abstract void Death();
}
