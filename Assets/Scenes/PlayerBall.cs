using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{

    Rigidbody rigid;
    bool isJump;
    public int itemCount;
    public float jumpPower;
    AudioSource audio1;
    public GameManagerLogic manager;


    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audio1 = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump")&& !isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(h, 0, v),ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
            isJump = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "item"){
            itemCount++;
            audio1.Play();
            other.gameObject.SetActive(false);
            manager.GetItem(itemCount);
        }
        else if ( other.tag == "Finish")
        {
            if(itemCount == manager.TotalItemNumber){
                //Game Clear! && Next Stage
                if(manager.stage==3)
                    SceneManager.LoadScene("Example0");
                else
                    SceneManager.LoadScene("Example1_" + (manager.stage+1) );
            }
            else{
                //Restart..
                SceneManager.LoadScene("Example1_" + manager.stage);
            }
        }
    }
}
