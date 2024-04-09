using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GS_Playercontroller : MonoBehaviour
{
    //player movement components
    [SerializeField]
    public int speed;
    private float horinput;
    private float verinput;
    private float minxx = -9f;
    private float maxx = 9f;
    private float miny = -5f;
    private float maxy = 0f;

    //attack missile gameobject
    public GameObject _missile;

    //cooldown properties
    private float _firerate = 0.3f;
    private float _canfire = 2;

    //player behaviiour
    public int life = 5;
    // public Transform pr;
    //public GameObject childObject;
    //public GameObject parentObject;
    // public Transform target;
    //public Vector2 offset;
    public GameObject protect;
    public GameObject speedup;

    //lifespan
    private TMP_Text scoreboard;
    public Image[] hearts;
    public Sprite fheart;
    public Sprite eheart;
    //score
    public float score;
    [SerializeField]
    private TMP_Text scoremsg;
    private void Awake()
    {
        //player eventbegin location 
        transform.position = new Vector2(0, -4);
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Playermovement();
        //attack();
        cooldownattack();
    }

    public void scorevalue()
    {
        score += 10;
       // Debug.Log("Score:" + score);
        scoremsg.text = "Score:" + score;
    }

    public void Playermovement()
    {
        horinput = Input.GetAxis("Horizontal");
        verinput = Input.GetAxis("Vertical");
        Vector2 directon = new Vector2(horinput, verinput);
        transform.Translate(directon * speed * Time.deltaTime);
        setboundary();
    }
    public void setboundary()
    {
        if (transform.position.x < minxx)
        {
            transform.position = new Vector2(maxx, transform.position.y);
        }
        else if (transform.position.x > maxx)
        {
            transform.position = new Vector2(minxx, transform.position.y);
        }
        else if (transform.position.y < miny)
        {
            transform.position = new Vector2(transform.position.x, maxy);
        }
        else if (transform.position.y > maxy)
        {
            transform.position = new Vector2(transform.position.x, miny);
        }
    }

    public void attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_missile, new Vector2(transform.position.x, transform.position.y + 1f), Quaternion.identity);
        }
    }



        public void damage()
        {


            life--;
            int i = life;
            //Debug.Log("rem.lives" + lives);
            hearts[i].sprite = eheart;
            if (life < 1)
            {
                Debug.Log("Game over");
                //_spawnmanager.stopspawningenemy();
                restart();
            }
        }
    public void restart()
    {
        SceneManager.LoadScene("Gameover");
    }
    public void cooldownattack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canfire)
        {
            _canfire = Time.time + _firerate;
            Instantiate(_missile, new Vector2(transform.position.x, transform.position.y + 2f), Quaternion.identity);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);
            
            //life--;
            damage();
            Debug.Log(life);
        }
        else if (collision.gameObject.tag == "fuel")
        {
            Destroy(collision.gameObject);
            Invoke("setnewspeed", 0.2f);
            Invoke("normalspeed", 10f);
        }
        else if (collision.gameObject.tag == "shield")
        {
            Destroy(collision.gameObject);
            // Vector2 desiredPosition = (Vector2)target.position + offset;
            // transform.position = desiredPosition;
            //transform.SetParent(pr);
            //childObject.transform.SetParent(parentObject);
            protect.SetActive(true);
            Debug.Log("parented");
            if (collision.gameObject.tag == "enemy")
            {
                Destroy(collision.gameObject);
            }
            Invoke("collideoff", 0.2f);
            Invoke("collideon", 10f);
        }
    }

    public void setnewspeed()
    {
        speedup.SetActive(true);
        speed = 15;
    }
    public void normalspeed()
    {
        speedup.SetActive(false);
        speed = 5;
    }
    public void collideoff()
    {
        GetComponent<Collider2D>().enabled = false;
    }
    public void collideon()
    {
        protect.SetActive(false);
        GetComponent<Collider2D>().enabled = true;
    }



  
}
