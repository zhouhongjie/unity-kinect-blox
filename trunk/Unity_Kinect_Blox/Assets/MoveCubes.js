#pragma strict

var forceAmount : Vector3;

function Start () {

}

function Update () {
GetComponent.<Rigidbody>().AddForce(forceAmount);
transform.LookAt(Vector3.zero);




}

function OnCollisionEnter (Cubes : Collision) {
		
		forceAmount=-forceAmount;
		
		//Destroy(gameObject);
	}