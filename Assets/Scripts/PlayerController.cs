using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 7.0f;
    public GameObject bullet;
    public GameObject bulletClone;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        FireBullet();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
    }

    void FireBullet()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bulletClone = Instantiate(bullet, new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, 0), player .transform.rotation) as GameObject;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("here");
        if (collision.gameObject.CompareTag("Player")) 
        {
            Debug.Log("inside if");
            Destroy(gameObject);
            
        }
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            Time.timeScale = 0;
            FindObjectOfType<GameManager>().panel.SetActive(true);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            
        }
    }


}
