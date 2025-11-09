using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : Enemy
{
   private float flickerTime = 0f;
   private float flickerDuration = 2f;
    // Start is called before the first frame update
    void Start()
    {
        sr=GetComponent<SpriteRenderer>();
        sr.flipX = true ;
        SpriteFlicker();
    }

void SpriteFlicker()
{
    if (flickerTime<flickerDuration){
        flickerTime = flickerTime + Time.deltaTime;

    }
    else if (flickerTime>= flickerDuration)
    {
        sr.enabled =! (sr.enabled);
        flickerTime = 0;
    }
}
void FixedUpdate ()
{
    if(sr.flipX==true )
    {
        this.GetComponent<Rigidbody2D>().velocity=
        new Vector2 (-maxSpeed,this.GetComponent<Rigidbody2D>().velocity.y);
    }
    else 
    {
     this.GetComponent<Rigidbody2D>().velocity=
        new Vector2 (maxSpeed,this.GetComponent<Rigidbody2D>().velocity.y);
    }
}
void OnTriggerEnter2D(Collider2D other)
{
    if (other.tag == "Player")
    {
        FindObjectOfType<PlayerStats>().TakeDamage(damage);
    }
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
