using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPath : MonoBehaviour
{
    public enum PathTypes
    {
        ZigZag,
        LeftDiagonal,
        RightDiagonal,
        loop
    }

    public PathTypes PathType;
    public int movementDirection = 1;//1 clockwise/forward || -1 counter clockwise/backward
    public int movingTo = 0; //used to identify in the path sequence we are moving to
    public Transform[] PathSequence; //Array of all points in the path
    // Start is called before the first frame update
    void Start()
    {
        movingTo = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDrawGizmos()
    {

        if (PathSequence == null || PathSequence.Length < 2)
        {
            return;
        }

        for (var i = 1; i < PathSequence.Length; i++)
        {
            Gizmos.DrawLine(PathSequence[i - 1].position, PathSequence[i].position);
        }

        if (PathType == PathTypes.loop)
        {
            Gizmos.DrawLine(PathSequence[0].position, PathSequence[PathSequence.Length - 1].position);
        }
    }

    //GetNextPathPoint() returns the transform component of the next point in our path
    //FollowPath.cs script will inturn move the object it is on that point in the game 
    public IEnumerator<Transform> GetNextPathPoint()
    {
        if (PathSequence == null || PathSequence.Length < 1)
        {
            yield break;
        }

        //does not infinite loop due to yield return
        while (true)
        {

            Debug.Log("returning point at index " + movingTo);
            yield return PathSequence[movingTo];

            //if there is only one point exit the co routine;
            if (PathSequence.Length == 1)
            {
                continue;
            }


            movingTo += movementDirection;
            if (movingTo > PathSequence.Length - 1)
                movingTo = 0;

        }
    }
}
