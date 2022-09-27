using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choose : MonoBehaviour
{
    public static Choose instance;
    public List<Image> Lobby = new();
    public GameObject[] Character = new GameObject[10];
    public List<GameObject> PlayerMonster = new ();
    public List<GameObject> ComMonster = new ();

    public bool count;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        if(PlayerMonster.Count < 3)
        {
            count = true;
        }
        else
        {
            count = false;
        }
        Random.InitState(Mathf.FloorToInt(Time.time));
    }

    public void Add(string Name)
    {
        for(int i = 0; i < Lobby.Count; i++)
        {
            if (Name == Lobby[i].name)
            {
                PlayerMonster.Add(Character[i]);
                break;
            }
        }
    }
    
    public void Remove(string Name)
    {
        for (int i = 0; i < Lobby.Count; i++)
        {
            if (Name == Lobby[i].name)
            {
                PlayerMonster.Remove(Character[i]);
                break;
            }
        }
    }

    public void EnemyChoose()
    {
        while (ComMonster.Count < 3) {
            GameObject Monster = Character[Random.Range(0, 10)];

            for (int i = 0; i < PlayerMonster.Count; i++)
            {
                if (Monster == PlayerMonster[i])
                {
                    Monster = Character[Random.Range(0, 10)];
                    i = 0;
                }
            }

            for (int i = 0; i < ComMonster.Count; i++)
            {
                if(Monster == ComMonster[i])
                {
                    Monster = Character[Random.Range(0, 10)];
                    
                    i = 0;
                }
            }
            ComMonster.Add(Monster);
        }
    }
}
    