using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class GameManager : MonoBehaviour
{
    bool Check = true;
    public class Character
    {
        public GameObject MonsterPoint ;
        public GameObject Object;
        public Animator Anim;
    }
    public Character Player = new(), Com = new();


    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Player.MonsterPoint = GameObject.Find("Pmonster");
        Com.MonsterPoint = GameObject.Find("Cmonster");

        CreateObject(Player);
        CreateObject(Com);

        GameData.instance.WhoseTurnIsIt = "Player";   
    }

    void Update()
    {
        if (Check) {
            if (PlayerScript.instance.HP == 0)
            {
                Check = false;
                if (Choose.instance.PlayerMonster.Count != 0)
                {
                    Choose.instance.PlayerMonster.RemoveAt(0);
                    StartCoroutine(DestroyObject(Player));
                }
                ComScript.instance.ReState();
            }
            if (ComScript.instance.HP == 0)
            {
                Check = false;
                if (Choose.instance.ComMonster.Count != 0)
                {
                    Choose.instance.ComMonster.RemoveAt(0);
                    StartCoroutine(DestroyObject(Com));
                }
                PlayerScript.instance.ReState();

            }
        }
        
    }

    IEnumerator DestroyObject(Character Cls)
    {
        for(int i = 0; i < 2; i++)
        {
            Cls.Object.SetActive(false);
            yield return new WaitForSeconds(.125f);
            Cls.Object.SetActive(true);
            yield return new WaitForSeconds(.125f);
        }
        for (int i = 0; i < 2; i++)
        {
            Cls.Object.SetActive(false);
            yield return new WaitForSeconds(.25f);
            Cls.Object.SetActive(true);
            yield return new WaitForSeconds(.25f);
        }
        Destroy(Cls.Object);
        yield return new WaitForSeconds(1);
        CreateObject(Cls);

    }

    void CreateObject(Character Cls)
    {

        if (Cls.MonsterPoint.name == "Pmonster")
        {
            if (Choose.instance.PlayerMonster.Count != 0)
            {
                Cls.Object = Instantiate(Choose.instance.PlayerMonster[0]);
                Cls.Object.transform.position = Player.MonsterPoint.transform.position;
                Cls.Object.transform.localScale = new Vector3(-2f, 2f, 2f);
                Cls.Anim = Player.Object.GetComponent<Animator>();
                PlayerScript.instance.UpdataCharacter();
                Check = true;
            }
        }
        else
        {
            if (Choose.instance.ComMonster.Count != 0)
            {
                Cls.Object = Instantiate(Choose.instance.ComMonster[0]);
                Cls.Object.transform.position = Com.MonsterPoint.transform.position;
                Cls.Object.transform.localScale = new Vector3(2f, 2f, 2f);
                Cls.Anim = Com.Object.GetComponent<Animator>();
                ComScript.instance.UpdataCharacter();
                Check = true;
            }
        }
        
    }
    
}
