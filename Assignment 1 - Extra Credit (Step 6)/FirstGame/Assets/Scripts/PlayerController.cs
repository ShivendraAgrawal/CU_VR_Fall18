using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;
	private Vector3 originalPos;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
		count = 0;
		SetCountText ();
		winText.text = "";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetMouseButtonDown(0))
		{
			rb.AddForce (Camera.main.transform.forward *
				Random.Range (500, 750));
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Pick up")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
			transform.position = originalPos;
			rb.AddForce (new Vector3(0,0,0));

		}
	}

	void SetCountText()
	{
		countText.text = "Nuns hunted: " + count.ToString ();
		if (count >= 6) {
			winText.text = "Survived !! Now face life";
		}
	}
}
