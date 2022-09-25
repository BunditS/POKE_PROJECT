using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instance;
    public List<Status> StatusData = new ();
    public string WhoseTurnIsIt;
    public int CurrentTurn;
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (CurrentTurn % 2 == 0) {
            WhoseTurnIsIt = "Player";
            ComScript.instance.tricker = true;
        }
        else WhoseTurnIsIt = "Com";
    }
}
