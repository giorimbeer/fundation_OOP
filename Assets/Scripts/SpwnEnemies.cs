using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwnEnemies : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] GameObject player;

    private void Update()
    {
        //look for enemies in the scene if it don't have any invoke one enemy
        if (GameObject.FindGameObjectWithTag("Enemy") == null) StartCoroutine(WaitSpawn());
    }

    //for invoke a enemy
    private void Invoke()
    {
        int random = Random.Range(0, enemies.Length);

        Instantiate(enemies[random]);

    }

    //for wait a moment before invoke a enemy
    IEnumerator WaitSpawn()
    {
        yield return new WaitForSeconds(1);
        if (GameObject.FindGameObjectWithTag("Enemy") == null)  Invoke();
    }
    
}
