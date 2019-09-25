using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    private float x;
    private float y;
    private Animator anim;
    private int coins = 0;

    public Text coin;
    public float speed;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	// Update is called once per frame
	void Update () {
       x = Input.GetAxis("Horizontal");
       y = Input.GetAxis("Vertical");
      
       Vector3 move = new Vector3(x, 0f, y);
       rb.transform.Translate(move * speed);
       this.transform.Rotate(0, Input.GetAxisRaw("Mouse X") * 5f , 0); //Rotates the x axis
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        coin.text = "$ " + coins.ToString() + ".00";
        if(coins > 14)
        {
            SceneManager.LoadScene("Ending");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public int getPlayerCoins()
    {
        return coins;
    }
   public void changeMoney(int cash)
    {
        coins += cash;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "WaterMelons")
        {
            GetComponent<PlayerQuestLog>().applesCollected = 5;
            other.transform.Translate(new Vector3(0, -50, 0));
        }
    }
}
