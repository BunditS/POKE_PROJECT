using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiIcon : MonoBehaviour
{
    private void Start()
    {
        Choose instance = Choose.instance;
        for (int i = 0; i < instance.Lobby.Count; i++)
        {
            instance.Lobby[i].sprite = instance.Character[i].GetComponentsInChildren<SpriteRenderer>()[1].sprite;
        }
    }
}
    