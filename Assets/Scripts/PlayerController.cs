using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject WinText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI countText;
    private int count;
    public float speed; 
    private Rigidbody rb;
    private float xInput, yInput, zInput;
    private float jumpAmount = 5f;
    private Vector3 jump;
    public bool isGrounded;
    public bool lost;
    public Reset reset;
    
    private void Awake ()
    {
        this.lost = false;
        this.WinText.SetActive(false);
        this.count = 0;
        this.setText();
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 1f, 0.0f);
    }

    public bool won(){
        if (!lost)
            return this.count >= 11;
        return false;
        
    }
    private void setText(){
        this.countText.text = "Count : " + this.count.ToString() + "/11";
        if (this.won()){
            this.WinText.SetActive(true);
            this.scoreText.text = "Your score : " + reset.score.ToString();
            this.lost = false;
        }
    }

    public int getCount(){
        return this.count;
    }
    private void OnCollisionStay(){
        isGrounded = true;
    }
    private void processMovement(){
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }

    private void Move(){
        this.processMovement();
        rb.AddForce(new Vector3(xInput, 0f, yInput) * speed);
        if (Input.GetKey("space") && isGrounded){
            rb.AddForce(jump * jumpAmount, ForceMode.Impulse);
            isGrounded = false;
        }
        
    }

    private void FixedUpdate (){
        this.Move();
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("PickUp")){
            other.gameObject.SetActive(false);
            count += 1;
            this.setText();
        }
    }
}