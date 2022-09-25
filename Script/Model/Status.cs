using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character",menuName = "Character/Status")]
public class Status : ScriptableObject
{
    new public string name = "New Character";
    public float HP;
    public float ATK;
    public float Defence;
    public float Speed;
}

