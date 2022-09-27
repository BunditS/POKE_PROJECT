using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectorOfCharacter : MonoBehaviour
{
    public string Name = "New Character";
    public float HP, ATK, Def, Spd;
    public Status CharacterDB;
    public int CoolDown_Buff, CoolDown_Heal, StackHit;
    public bool tricker = true , isDead = false;
    public IEnumerator Buff()
    {
        if (GameData.instance.WhoseTurnIsIt == "Player")
        {
            GameManager.instance.Player.Anim.SetBool("isMoving", true);
            yield return new WaitForSeconds(.6f);
            GameManager.instance.Player.Anim.SetBool("isMoving", false);
        }
        else
        {
            GameManager.instance.Com.Anim.SetBool("isMoving", true);
            yield return new WaitForSeconds(.6f);
            GameManager.instance.Com.Anim.SetBool("isMoving", false);
            BattleSet.instance.Setkey = true;
        }

        bool Check = true;
        while (Check)
        {
            switch (Random.Range(0, 3))
            {
                case 0:
                    ATK *= 1.2f;
                    Check = false;
                    break;
                case 1:
                    if (Def < 50)
                    {
                        Def += 10f;
                        Check = false;
                        break;
                    }
                    break;
                default:
                    if(Spd < 50)
                    {
                        Spd += 10f;
                        Check = false;
                        break;
                    }
                    break;
            }

        }
        CoolDown_Buff = GameData.instance.CurrentTurn + 6;
        GameData.instance.CurrentTurn++;
    }

    public IEnumerator Heal()
    {
        if (GameData.instance.WhoseTurnIsIt == "Player")
        {
            GameManager.instance.Player.Anim.SetBool("isMoving", true);
            yield return new WaitForSeconds(.6f);
                GameManager.instance.Player.Anim.SetBool("isMoving", false);
        }
        else
        {
            GameManager.instance.Com.Anim.SetBool("isMoving", true);
            yield return new WaitForSeconds(.6f);
            GameManager.instance.Com.Anim.SetBool("isMoving", false);
            BattleSet.instance.Setkey = true;
        }

        HP += CharacterDB.HP * 0.25f;
        if (HP >= CharacterDB.HP) HP = CharacterDB.HP;
        CoolDown_Heal = GameData.instance.CurrentTurn + 8;
        GameData.instance.CurrentTurn++;
    }

    public IEnumerator  Attack()
    {
        if (GameData.instance.WhoseTurnIsIt == "Player")
        {
            GameManager.instance.Player.Anim.SetTrigger("attack");
            yield return new WaitForSeconds(.3f);
        }
        else
        {
            GameManager.instance.Com.Anim.SetTrigger("attack");
            yield return new WaitForSeconds(.3f);

        }
        if (typeof(PlayerScript).IsAssignableFrom(this.GetType()))
        {
            GetComponent<ComScript>().Hit(ATK);
        }
        else
        {
            GetComponent<PlayerScript>().Hit(ATK);
            BattleSet.instance.Setkey = true;
        }
        
    }
    public IEnumerator Ultimate()
    {
        if (GameData.instance.WhoseTurnIsIt == "Player")
        {
            GameManager.instance.Player.Anim.SetTrigger("attack");
            yield return new WaitForSeconds(.3f);
        }
        else
        {
            GameManager.instance.Com.Anim.SetTrigger("attack");
            yield return new WaitForSeconds(.3f);

        }
        if (typeof(PlayerScript).IsAssignableFrom(this.GetType()))
        {
            GetComponent<ComScript>().Hit(ATK*2.5f);
        }
        else
        {
            GetComponent<PlayerScript>().Hit(ATK*2.5f);
            BattleSet.instance.Setkey = true;

        }
        StackHit = 0;
    }

    public void Hit(float inputATK)
    {
        if(Random.Range(0, 100) <= Spd) inputATK = 0;  
        inputATK -= inputATK * (Def / 100);
        HP -= inputATK;
        if (HP < 0)
        {
            HP = 0;
            isDead = true;
        }
        StackHit++;
        GameData.instance.CurrentTurn++;
    }

    public void ReState()
    {
        HP += HP * 0.25f;
        ATK = CharacterDB.ATK;
        Def = CharacterDB.Defence;
        Spd = CharacterDB.Speed;
        CoolDown_Buff = 0;
        CoolDown_Heal = 0;
        StackHit    = 0;
    }
}
