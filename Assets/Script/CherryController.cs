using System.Collections;
using System.Collections.Generic;

using System.Timers;
using UnityEditor;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    public GameObject target ;
    public GameObject cherry;
    private float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMove());
    }

    IEnumerator SpawnMove()
    {
        while(true)
        {
            yield return new WaitForSeconds(10);
            CherrySpawn();
        }
    }
    private void CherrySpawn()
    {
        int randomNumber = Random.Range(1,5);
        Vector2 spawnPos = new Vector2(6, -26);

        if (randomNumber == 1)
        {
            spawnPos = new Vector2(Random.Range(-25, 28), 6);  
        }
        else if (randomNumber == 2)
        {
            spawnPos = new Vector2(-26, Random.Range(-24.6f, 4.75f));  
        }
        else if (randomNumber == 3)
        {
            spawnPos = new Vector2(Random.Range(-25, 28), -26);  
        }
        else if (randomNumber == 4)
        {
            spawnPos = new Vector2(30, Random.Range(-24.6f, 4.75f));  
        }

        GameObject spawnedCherry = Instantiate(cherry, spawnPos, cherry.transform.rotation);
        Vector2 opposite = Opposite(spawnPos);
        StartCoroutine(MoveCherry(spawnedCherry, opposite));
    }

    private Vector2 Opposite(Vector2 spawnPos)
    {
        Vector2 t2d = new Vector2(target.transform.position.x, target.transform.position.y);
        Vector2 oppositePosition = t2d + (t2d- spawnPos);  
        return oppositePosition;
    }

    IEnumerator MoveCherry(GameObject cherryPrefab, Vector2 targetPos)
    {
        Vector2 start = cherryPrefab.transform.position;
        float elapsed = 0;
        float distanceTraveled = Vector2.Distance(start, targetPos);
        while (elapsed < distanceTraveled)
        {
            elapsed += Time.deltaTime * speed; 
            float t = elapsed / distanceTraveled; 

            cherryPrefab.transform.position = Vector2.Lerp(start, targetPos, t);  
            yield return null;
        }
        Destroy(cherryPrefab);
        yield return null;
    }
}
