using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.Experimental.GraphView;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector3;
using UnityEngine;

public class PacStudentMovement : MonoBehaviour
{
    public float movingSpeed = 0.2f;
    public  AudioSource movingMan;//chunjat!
    public Transform[] coordinates;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveMan());
    }

    IEnumerator MoveMan(){
        while(true){
            Vector3 startWichi = transform.position;
            Vector3 endWichi =  coordinates[0].position;

            float distanceTraveled = Vector2.Distance(startWichi, endWichi);
            float traveledTime = distanceTraveled/movingSpeed;
            float passedTime = 0f;

            transform.position = Vector2.Lerp(startWichi, endWichi, passedTime/traveledTime);
            passedTime += Time.deltaTime;
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
