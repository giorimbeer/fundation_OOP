using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwnEnemies : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] GameObject player;

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == null) Invoke();
    }

    private void Invoke()
    {
        int random = Random.Range(0, enemies.Length);

        StartCoroutine(Wait(random));

        Instantiate(enemies[random]);
    }

    IEnumerator WaitSpawn()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == null) Invoke();
        yield return new WaitForSeconds(1);
    }
    IEnumerator Wait(int i) 
    {
        player.SetActive(false);
        enemies[i].SetActive(false);
        yield return new WaitForSeconds(0.1f);
        player.SetActive(true);
        enemies[i].SetActive(true);
    }
    
}
