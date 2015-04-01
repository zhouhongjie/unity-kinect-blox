#pragma strict

var forceAmount : Vector3;

function Start () {

}

function Update () {

//if (Input.GetButtonDown("Jump"))
	GetComponent.<Rigidbody>().AddForce(forceAmount);

}

function OnCollisionEnter (Cubes : Collision) {
		
		forceAmount=-forceAmount;
		
		//Destroy(gameObject);
	}