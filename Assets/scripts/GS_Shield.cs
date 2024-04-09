using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS_Shield : MonoBehaviour
{

    private float maxdist = -7f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < maxdist)
        {
            //transform.position = new Vector2(Random.Range(-8f, 8f), 6.2f);
            Destroy(this.gameObject);
        }
    }
}
