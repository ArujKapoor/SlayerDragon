using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class LREnemyPath : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed =5;
    float distanceTravelled;
    public float wait = 2f;
    public Vector3[] points;
    public Vector3 currPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DistanceTravelled();
    }

    void DistanceTravelled()
    {
        //transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
        //var rot = transform.rotation;
        //rot.y = rot.y + 180f;
        //transform.rotation = rot;
        points = pathCreator.path.localPoints;
        currPos = transform.position;
        foreach(Vector3 p in points)
        {
            if (currPos.x == p.x)
            {
                Debug.LogWarning("reached point. Time to stop");
                distanceTravelled = 0;
                wait = 2f;
                break;
            }
        }
        wait -= Time.deltaTime;
        if (wait <= 0)
        {
            distanceTravelled += speed * Time.deltaTime;
        }

        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
    }
}
