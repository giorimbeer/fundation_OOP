using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScens : MonoBehaviour
{

    Player player;

    private void Awake()
    {
        if (GameObject.Find("Player") != null)
        {
            player = GameObject.Find("Player").GetComponent<Player>();
        }
    }

    private void Update()
    {
        if (player != null)
        {
            if(player.actualLive <= 0)
            {
                player.actualLive = 0;
                StartCoroutine(Wait());
            }
        }
    }


    //functions for navigate betwen scenes
    public void TitleScren()
    {
        SceneManager.LoadScene(0);
    }

    public void Main()
    {
        SceneManager.LoadScene(1);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }

    //just for wait
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        GameOver();
    }
}
