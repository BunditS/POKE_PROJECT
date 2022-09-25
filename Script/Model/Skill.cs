using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public static Skill instance;
    private void Awake()
    {
        instance = this;
    }
    public void buff(string Name)
    {
        if (Name == "Character (1)")
        {
            PlayerScript.instance.ATK = PlayerScript.instance.CharacterDB.ATK * 1.25f;
        }
        if(Name == "Character (2)")
        {
            PlayerScript.instance.Def = PlayerScript.instance.CharacterDB.Defence +10;
        }
        if(Name == "Character (3)")
        {
            PlayerScript.instance.Spd = PlayerScript.instance.CharacterDB.Speed +10;
        }
        if (Name == "Character (4)")
        {
            PlayerScript.instance.Def = PlayerScript.instance.CharacterDB.Defence + 10;
        }
        if (Name == "Character (5)")
        {
            PlayerScript.instance.Spd = PlayerScript.instance.CharacterDB.Speed + 10;
        }
        if (Name == "Character (6)")
        {
            PlayerScript.instance.ATK = PlayerScript.instance.CharacterDB.ATK * 1.25f;
        }
        if (Name == "Character (7)")
        {
            PlayerScript.instance.Def = PlayerScript.instance.CharacterDB.Defence + 10;
        }
        if (Name == "Character (8)")
        {
            PlayerScript.instance.Spd = PlayerScript.instance.CharacterDB.Speed + 10;
        }
        if (Name == "Character (9)")
        {
            PlayerScript.instance.Def = PlayerScript.instance.CharacterDB.Defence + 10;
        }
        if (Name == "Character (10)")
        {
            PlayerScript.instance.Spd = PlayerScript.instance.CharacterDB.Speed + 10;
        }
    }    

}
