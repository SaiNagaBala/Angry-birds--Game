using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterController : MonoBehaviour
{
    public Sprite monster;
    public int flag = 0;
    // Start is called before the first frame update
   Scene scene;
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
       BirdController bird= collision.gameObject.GetComponent<BirdController>();
        if (bird != null|| collision.gameObject.tag == "MonsterDestroy")
        {
            //Destroy(gameObject);
            MonsterDeath();
            if(flag == 1)
            {
                scene=SceneManager.GetActiveScene();
            }
            // gameObject.SetActive(false);
        }
       
    }
    private void MonsterDeath()
    {
        gameObject.SetActive(false);
        flag = 1;

    }
    //Level 1:More Monsters and crates. check for preventing multiple deaths.
    //Level 2:When collision happens.print the score.
    //Create different scenes 
    private void MonsterReplace()
    {
        
        GetComponent<SpriteRenderer>().sprite = monster;
    }
}
