using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS_Missile : MonoBehaviour
{

    //misile movement
    public int _missilespeed=5;
    private float  maxdist=6.5f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * _missilespeed * Time.deltaTime);
        if(transform.position.y>maxdist)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="enemy")
        {
            GS_Playercontroller _GS_Playercontroller = GameObject.Find("player").GetComponent<GS_Playercontroller>();
            _GS_Playercontroller.scorevalue();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
   
    }
}
