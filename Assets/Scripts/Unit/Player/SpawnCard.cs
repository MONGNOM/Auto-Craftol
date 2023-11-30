using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnCard : MonoBehaviour
{
    public GameObject warrior;
    public Transform pos;
    public void WarriorSpawn()
    {
        Instantiate(warrior, pos);
    }

    public void ArcherSpawn()
    {
        Instantiate(warrior, pos);

    }
    public void PristSpawn()
    {
        Instantiate(warrior, pos);

    }
}
