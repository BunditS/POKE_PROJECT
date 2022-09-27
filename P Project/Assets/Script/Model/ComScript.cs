using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComScript : InspectorOfCharacter
{
    // Start is called before the first frame update

    public static ComScript instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        UpdataCharacter();
    }
    void Update()
    {
        Random.InitState(Mathf.FloorToInt(Time.time));
        if (HP <= 0) HP = 0;
        if (HP >= CharacterDB.HP) HP = CharacterDB.HP;
    }

    public void UpdataCharacter()
    {
        Name = Choose.instance.ComMonster[0].name;
        for (int i = 0; i < GameData.instance.StatusData.Count; i++)
        {
            if (Name == GameData.instance.StatusData[i].name)
            {
                CharacterDB = GameData.instance.StatusData[i];
                break;
            }

        }
        HP = CharacterDB.HP;
        ATK = CharacterDB.ATK;
        Def = CharacterDB.Defence;
        Spd = CharacterDB.Speed;
        isDead = false;
    }
}
