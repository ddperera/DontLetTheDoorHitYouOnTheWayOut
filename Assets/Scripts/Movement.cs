using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float moveSpeed;
	public float sensitivity;

	private Camera camera;
	public CharacterController controller;
	public Vector3 vel;
	private float targetHeight;
	private RaycastHit hitInfo;
	private Ray toFloor;
	private Ray testShot;
	private float cameraRotY = 0f;
	public enum state {WALKING, AUTO, GUILOCK};
	public state curState;
	private Vector3 temp;
	private Quaternion tempQ;


	// Use this for initialization
	void Start () 
	{
		vel = new Vector3 ();
		controller = GetComponent<CharacterController> ();
		camera = GetComponentInChildren<Camera> ();
		toFloor = new Ray (transform.position, -1 * transform.up);
		Physics.Raycast (toFloor, out hitInfo);
		targetHeight = hitInfo.distance;

		testShot = new Ray (new Vector3 (-1, 1, -3), Vector3.right);

		curState = state.WALKING;
	}
	
	// Update is called once per frame
	void Update () 
	{
		camera.transform.localRotation = Quaternion.Euler (camera.transform.localRotation.eulerAngles.x, 0, 0);
		if (curState == state.WALKING)
		{
			vel.x = Input.GetAxisRaw ("Horizontal");
			vel.y = 0; 
			vel.z = Input.GetAxisRaw ("Vertical");
			vel = transform.TransformDirection (vel);
			vel.Normalize ();
			toFloor.origin = transform.position;
			toFloor.direction = -1 * transform.up;
			Physics.Raycast (toFloor, out hitInfo);
			if (!hitInfo.collider.isTrigger && Mathf.Abs (hitInfo.distance - targetHeight) > .05) 
			{
				transform.position = new Vector3 (transform.position.x, hitInfo.point.y + targetHeight, transform.position.z);
			}
		} 
		else if(curState == state.AUTO)
		{
			vel.x = vel.y = vel.z = 0;
		}
		
		controller.Move (moveSpeed * vel * Time.deltaTime);

		transform.Rotate(Vector3.up, Input.GetAxis ("MouseX") * Time.deltaTime * sensitivity);

		Vector3 goalCamRot = camera.transform.localEulerAngles;
		float amountToMoveY = -1 * Input.GetAxis ("MouseY") * sensitivity * Time.deltaTime;
		goalCamRot.x += amountToMoveY;
		if (goalCamRot.x < 265f && goalCamRot.x > 180f) {
			goalCamRot.x = 265f;
		} else if (goalCamRot.x > 80f && goalCamRot.x < 180f) {
			goalCamRot.x = 80f;
		}
		camera.transform.localEulerAngles = goalCamRot;

	}
		
		
}
