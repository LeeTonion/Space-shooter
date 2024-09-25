using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyspawn;
    [SerializeField] private GameObject enemyfirespawn;
    [SerializeField] private GameObject meteorite;
    [SerializeField] private GameObject[] Powerup;
    [SerializeField] private bool _isEnemy =true;

    [SerializeField] private GameObject _enemyContainer;
  public void spawn()
        {
            StartCoroutine("SpawnEnemyRoutine");
            StartCoroutine("SpawnTripleshortRoutine");
            StartCoroutine("SpawnSpeedRoutine");
            StartCoroutine("SpawnShieldsRoutine");
            StartCoroutine("SpawnMeteoriteRoutine");
         }

   
    void Update()
    {

    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (_isEnemy)
        {
            Vector3 a = new Vector3(Random.Range(-26, 26), 15, 0);

            GameObject enemy = Instantiate(enemyspawn, a, Quaternion.identity);
            enemy.transform.parent = _enemyContainer.transform ;
            yield return new WaitForSeconds(Random.Range(1,6));
        }  

    }
    IEnumerator SpawnEnemyFireRoutine()
    {
        while (_isEnemy  )
        {
            Vector3 a = new Vector3(Random.Range(-26, 26), 15, 0);

            GameObject enemy = Instantiate(enemyfirespawn, a, Quaternion.identity);
            enemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(Random.Range(1, 6));

        }

    }
    IEnumerator SpawnTripleshortRoutine()
    {
        while (_isEnemy)
        {
            Vector3 a = new Vector3(Random.Range(-26, 26), 15, 0);

            Instantiate(Powerup[0], a, Quaternion.identity);

            yield return new WaitForSeconds(Random.Range(10,15));
        }
    }
    IEnumerator SpawnSpeedRoutine()
    {
        while (_isEnemy)
        {
            Vector3 a = new Vector3(Random.Range(-26, 26), 15, 0);

            Instantiate(Powerup[1], a, Quaternion.identity);

            yield return new WaitForSeconds(Random.Range(10, 15));
        }
    }
    IEnumerator SpawnShieldsRoutine()
    {
        while (_isEnemy)
        {
            Vector3 a = new Vector3(Random.Range(-26, 26), 15, 0);

            Instantiate(Powerup[2], a, Quaternion.identity);

            yield return new WaitForSeconds(Random.Range(10, 15));
        }
    }
    IEnumerator SpawnMeteoriteRoutine()
    {
        while (_isEnemy)
        {
            Vector3 a = new Vector3(Random.Range(-28, 28), 16, 0);

            Instantiate(meteorite, a, Quaternion.identity);

            yield return new WaitForSeconds(10);
        }
    }
    public void isEnemy()
    {
        _isEnemy = false; 
    }
    public void isEnemyFire()
    {
        StartCoroutine("SpawnEnemyFireRoutine");
        
    }
}

