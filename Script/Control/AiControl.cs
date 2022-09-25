using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiControl : MonoBehaviour
{
    void Update()
    {
        if (GameData.instance.WhoseTurnIsIt == "Com" && !ComScript.instance.isDead)
        {
            if (ComScript.instance.StackHit >= 5 && ComScript.instance.tricker)
            {
                ComScript.instance.tricker = false;
                StartCoroutine(ComScript.instance.Ultimate());
            }
            while (ComScript.instance.tricker)
            {
                switch (Random.Range(0, 3))
                {
                    case 0:
                        ComScript.instance.tricker = false;
                        StartCoroutine(ComScript.instance.Attack());
                        break;
                    case 1:
                        if (ComScript.instance.CoolDown_Heal <= GameData.instance.CurrentTurn)
                        {
                            if (ComScript.instance.HP <= ComScript.instance.CharacterDB.HP*0.75)
                            {
                                ComScript.instance.tricker = false;
                                StartCoroutine(ComScript.instance.Heal());
                            }               
                        }                
                        break;
                    default:
                        if (ComScript.instance.CoolDown_Buff <= GameData.instance.CurrentTurn)
                        {
                            ComScript.instance.tricker = false;
                            StartCoroutine(ComScript.instance.Buff());
                        }                       
                        break;
                }
            }
        }
        
    }
}
