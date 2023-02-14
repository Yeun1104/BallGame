using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerLogic : MonoBehaviour
{
    public int TotalItemNumber;
    public int stage;
    public Text stageNumText;
    public Text playerNumText;

    void Awake(){
        stageNumText.text = "/"+TotalItemNumber;
    }

    public void GetItem(int count){
        playerNumText.text=count.ToString();

    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player");
            SceneManager.LoadScene(stage);
    }
}
