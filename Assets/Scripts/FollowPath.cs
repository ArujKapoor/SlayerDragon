using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public enum MovementType
    {
        MoveTowards,
        LerpTowards
    }
    public Transform player;
    private Rigidbody rb;
    public MovementType Type = MovementType.MoveTowards;
    public MovementPath MyPath;
    public float Speed = 1;
    public float MaxdistanceToGoal = 0.1f;// how close does it have to be to the point to be considered as point
    public float waitTime = 2f;
    private IEnumerator<Transform> pointInPath; //used to reference point returned from MyPath.GetNextPathPoint
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        //MovementPath temp = MyPath;
        //MyPath = Instantiate(temp);
        if (MyPath == null)
        {
            Debug.LogError("Movement Path cannot be null, I must have to follow a  path", gameObject);
            return;
        }

        //sets up a reference to an instance of the coroutine GetNextPathPoint
        pointInPath = MyPath.GetNextPathPoint();
        //get the next point in the path to move to (Gets the default 1st value)
        pointInPath.MoveNext();
        //make sure there is a point to move to
        if (pointInPath.Current == null)
        {
            Debug.LogError("A path must have point in it to follow", gameObject);
            return;
        }

        transform.position = pointInPath.Current.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (pointInPath == null || pointInPath.Current == null)
        {
            return;
        }

        //waitTime -= Time.deltaTime;

        //if (waitTime >= 0)
        //{
         //   return;
        //}

        if (Type == MovementType.MoveTowards)
        {
            transform.parent.position = Vector3.MoveTowards(transform.parent.position, pointInPath.Current.position, Time.deltaTime * Speed);
            Debug.Log("..............");
            Debug.Log(gameObject + "at position :" + pointInPath.Current.position);
        }
        else if (Type == MovementType.LerpTowards)
        {
            transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position, Time.deltaTime * Speed);
        }
        //check to see if you are close enough to the next point to start moving to the following one
        var distanceSquared = (transform.parent.position - pointInPath.Current.position).sqrMagnitude;
        if (distanceSquared < MaxdistanceToGoal * MaxdistanceToGoal)
        {
            pointInPath.MoveNext();

        }
        RotateToPlayer();
    }
    void RotateToPlayer()
    {
        Vector3 direction =(player.position - transform.parent.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, angle-90);
    }

}
