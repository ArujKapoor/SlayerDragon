using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryConditions : MonoBehaviour
{   
    private Vector3 offset;
    private Vector3 screenPoint;
    private GameObject player;
    float screenRatio = (float)Screen.width / (float)Screen.height;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
		// Calculates the orthographic height and width
        float height = Camera.main.orthographicSize;
		float width = Camera.main.orthographicSize * screenRatio;

		// Sets the size based on screen size.
        transform.localScale = new Vector3(width*2, height*2, 0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    // For mouse click movement
    // void OnMouseDown(){
    //     offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    //     Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z) + offset;
    //     Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
    //     player.GetComponent<Transform> ().position = curPosition;
    // }
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject); //Destroys the other object
    }
}
