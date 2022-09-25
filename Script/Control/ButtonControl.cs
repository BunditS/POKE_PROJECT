using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonControl : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void OnClickAttack()
    {
        StartCoroutine(PlayerScript.instance.Attack());

    }
    public void OnClickUltimate()
    {
        StartCoroutine(PlayerScript.instance.Ultimate());
        
    }
    public void OnClickHeal()
    {  
        StartCoroutine(PlayerScript.instance.Heal());
    }
    public void OnClickBuff()
    {
        StartCoroutine(PlayerScript.instance.Buff());

    }
    public void DisableButton()
    {
       BattleSet.instance.Setkey = false;
    }
}
