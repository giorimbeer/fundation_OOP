using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwnEnemies : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] GameObject player;

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == null) StartCoroutine(WaitSpawn());
    }

    private void Invoke()
    {
        int random = Random.Range(0, enemies.Length);

        Instantiate(enemies[random]);

    }

    IEnumerator WaitSpawn()
    {
        yield return new WaitForSeconds(1);
        if (GameObject.FindGameObjectWithTag("Enemy") == null)  Invoke();
    }
    
}
