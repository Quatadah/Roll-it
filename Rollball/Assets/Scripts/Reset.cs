using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Reset : MonoBehaviour
{
    private float timeRemaining = 20f;
    private float threshold = -10f;
    // Start is called before the first frame update
    public GameObject LossText;
    public PlayerController player;
    // Update is called once per frame
    public TextMeshProUGUI timer;

    public float score;
    


    void Start(){
        score = 0f;
        this.LossText.SetActive(false);
    }


    void Update()
    {
        if (timeRemaining > 0 && !player.won()){
            timeRemaining -= Time.deltaTime;
            timer.text = "Timer : " + timeRemaining.ToString();
            this.score = 20 - this.timeRemaining;
        }
        if (timeRemaining <= 0)
            timer.text = "Timer : 0";
        if (timeRemaining <= 0 && player.getCount() < 11){
            timer.text = "Timer : 0";
            this.LossText.SetActive(true);
            player.lost = true;
        }
        
        

        if (transform.position.y < threshold ){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        /*
        else if (player.getCount() == 11){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("You win");
        }
        */
    }
}
