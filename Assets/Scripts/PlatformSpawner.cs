using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;

    public Transform lastPlatform;
    Vector3 lasPos;
    Vector3 newPos;

    public bool stop;

    // Start is called before the first frame update
    void Start()
    {
        lasPos = lastPlatform.position;
        StartCoroutine(SpawnPlatform());
    }

    
    

    void GenratePos()
    {
        newPos = lasPos; 
        int rand = Random.Range(0,2);
        if(rand >0)
        {
            newPos.x += 2f;
        }
        else
        {
            newPos.z += 2f;
        }
    }
    IEnumerator SpawnPlatform()
    {
        while(!stop)
        {
            GenratePos();
            Instantiate(platform, newPos, Quaternion.identity);
            lasPos = newPos;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
