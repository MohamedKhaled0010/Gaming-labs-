using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int health =3 ;
    public int lives =3 ;
    private float flickerTime = 0f ;
    public float flickerDuration = 0.1f ;

private SpriteRenderer sr;

public bool isImmune = false ;
private float iImmunityTime = 0f;
public float iImmunityDuration = 1.5f;

       // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isImmune == true )
        {
            iImmunityTime = iImmunityTime= Time.deltaTime ;
            if (iImmunityTime >= iImmunityDuration)
            {
                isImmune = false ;
                sr.enabled =true ;
            }
        }
    }
    public void TakeDamage (int damage )
    {
         if (isImmune == false ) 
         {
            health = health - damage;
            if (health<0)
            health = 0;
            if (lives>0 && health ==0)
            {
                FindObjectOfType <LevelManager>().RespawnPlayer();
                health = 3;
                lives--; 
            }
            else if (lives == 0 && health == 0)
            {
                Debug.Log("Gameover");
                Destroy (this.gameObject);

            }
            Debug.Log ("Player Health : "+ health.ToString ());
            Debug.Log ("Player Lives : "+ lives.ToString ());
         }
         isImmune =true;
         iImmunityTime= 0f;
    }
    void SpriteFlicker()
{
    if (flickerTime<flickerDuration)
    {
        flickerTime= flickerTime+flickerDuration;

    }
    else if (flickerTime>=flickerDuration)
    {
        sr.enabled =!(sr.enabled);
        flickerTime=0;
    }
}
}


