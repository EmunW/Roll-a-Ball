using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	private int count;
	public Text countText;
	public Text winText;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText();
		winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
		rb.AddForce(movement * speed);
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("PickUp")){
			other.gameObject.SetActive(false);
			count++;
			SetCountText();
			if (count >= 12){
				winText.text = "You win!";
			}
		}
	}

	void SetCountText(){
		countText.text = "Count: " + count.ToString();
	}
}
