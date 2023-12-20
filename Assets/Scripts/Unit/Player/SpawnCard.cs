using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnCard : MonoBehaviour
{
    public bool warrior = false;
    public bool archer = false;
    public bool prist = false;


    

  
    public void WarriorSpawn()
    {
        warrior = true;
        archer = false;
        prist = false;
    }   

    public void ArcherSpawn()
    {
        warrior = false;
        archer = true;
        prist = false;
    }
    public void PristSpawn()
    {
        warrior = false;
        archer = false;
        prist = true;
    }
}
