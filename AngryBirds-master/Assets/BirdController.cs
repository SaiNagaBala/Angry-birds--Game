using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    Rigidbody2D rb;
    public float maximumDragDistance;
    Vector2 birdStartPosition;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    // Start is called before the first frame update
    void Start()
    {
        rb.isKinematic = true;
        birdStartPosition = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color=Color.red;
    }
    private void OnMouseUp()
    {
        //float birdSpeed = Random.Range(0.1f,5.0f);
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 currentPosition = rb.position;
        Vector2 direction=birdStartPosition-currentPosition;
        direction.Normalize();
        rb.isKinematic=false;
        rb.AddForce(direction* 1);
    }
    private void OnMouseDrag()
    {
        //Mouse position converted to world point.
        Vector3 mousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 desiredPosition = mousePosition;
        if(desiredPosition.x>birdStartPosition.x)
        {
            desiredPosition.x=birdStartPosition.x;
        }
        //transform.position = new Vector3(mousePosition.x,mousePosition.y,transform.position.z);
        float distance=Vector2.Distance(desiredPosition,birdStartPosition);
        if(distance>maximumDragDistance)
        {
            Vector2 direction=desiredPosition-birdStartPosition;
            direction.Normalize();
            desiredPosition=birdStartPosition+(direction*maximumDragDistance);
        }
        rb.position = desiredPosition;       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelay());
        
    }
   IEnumerator ResetAfterDelay()
    {  
        yield return new WaitForSeconds(2f);
        print("This is a Coroutine function");
        rb.position = birdStartPosition;
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
    }
    

}
