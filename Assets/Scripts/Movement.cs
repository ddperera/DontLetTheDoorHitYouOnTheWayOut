using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

	public float moveSpeed;
	public float sensitivity;
	public bool isGhost;
	public bool Level1 = false;

	private Camera camera;
	public CharacterController controller;
	public Vector3 vel;
	private ColorCorrectionCurves colorCorrection;
	private MotionBlur motionBlur;
	private float targetHeight;
	private RaycastHit hitInfo;
	private int CHECK_RATE = 25;
	private float proximityDistance =  2.5f;
	private Ray toFloor;
	private Ray testShot;
	private float cameraRotY = 0f;
	public enum state {WALKING, AUTO, GUILOCK, FALLING};
	public state curState;
	private Vector3 temp;
	private Quaternion tempQ;
	private Rigidbody rb;
	private float fallSpeed = 0f;

	// UI Feedback
	public GameObject playerUI;
	private Image playerReticle;
	private GameObject NPC;

	// Use this for initialization
	void Start () 
	{
		vel = new Vector3 ();
		rb = GetComponent<Rigidbody> ();
		controller = GetComponent<CharacterController> ();
		camera = GetComponentInChildren<Camera> ();
		colorCorrection = camera.GetComponent<ColorCorrectionCurves> ();
		motionBlur = camera.GetComponent<MotionBlur> ();
		toFloor = new Ray (transform.position, -1 * transform.up);
		Physics.Raycast (toFloor, out hitInfo);
		targetHeight = hitInfo.distance;
		isGhost = false;
		NPC = GameObject.FindGameObjectWithTag ("NPC");

		testShot = new Ray (new Vector3 (-1, 1, -3), Vector3.right);

		curState = state.WALKING;

		playerReticle = playerUI.transform.FindChild("Reticle").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Indicates if the object within the player's purview is interactable by changing the reticle.
		if (Time.frameCount % CHECK_RATE == 0) {
			RaycastHit hitCheckerInfo = new RaycastHit ();
			playerReticle.color = Color.grey;
			if (Physics.Raycast (camera.ViewportPointToRay (new Vector3 (.5f, .5f, 0f)), out hitCheckerInfo, proximityDistance)) {
				if (hitCheckerInfo.collider.gameObject.CompareTag ("Interactable")) {
					playerReticle.color = Color.white;
				}
			}
		}
		// Mouse click interaction handling
		// If the object that is clicked has an "Interactable" tag, call the "OnPlayerClicked" function
		// on its attached script.
		if (Input.GetButtonDown("Fire1") && curState == state.WALKING)
		{
			RaycastHit hitInfo = new RaycastHit();
			if (Physics.Raycast(camera.ViewportPointToRay(new Vector3(.5f,.5f,0f)), out hitInfo, proximityDistance))
			{
				if (hitInfo.collider.gameObject.CompareTag("Interactable"))
				{
					hitInfo.collider.gameObject.SendMessage("OnPlayerClicked",SendMessageOptions.DontRequireReceiver);
				}
			}
		}



		camera.transform.localRotation = Quaternion.Euler (camera.transform.localRotation.eulerAngles.x, 0, 0);
		if (curState == state.WALKING) 
		{
			fallSpeed = 0f;
			vel.x = Input.GetAxisRaw ("Horizontal");
			vel.y = 0;
			vel.z = Input.GetAxisRaw ("Vertical");
			vel = transform.TransformDirection (vel);
			vel.Normalize ();
			toFloor.origin = transform.position;
			toFloor.direction = -1 * transform.up;

			Debug.Log(fallSpeed);

			if (Physics.Raycast (toFloor, out hitInfo)) 
			{
				if (!hitInfo.collider.isTrigger) 
				{
					if (Mathf.Abs (hitInfo.distance - targetHeight) < 1) 
					{
						transform.position = new Vector3 (transform.position.x, hitInfo.point.y + targetHeight, transform.position.z);
					} 
					else
					{
						curState = state.FALLING;
					}
				}
			} 
			else 
			{
				
			}
		} 
		else if (curState == state.AUTO) 
		{
			vel.x = vel.y = vel.z = 0;
		} 
		else if (curState == state.FALLING) 
		{
			vel.x = Input.GetAxisRaw ("Horizontal");
			fallSpeed -= 9.8f*Time.deltaTime;
			vel.y = 0;
			vel.z = Input.GetAxisRaw ("Vertical");
			vel = transform.TransformDirection (vel);
			vel.Normalize ();
			vel.y = fallSpeed/moveSpeed;

			toFloor.origin = transform.position;
			toFloor.direction = -1 * transform.up;
			if (Physics.Raycast (toFloor, out hitInfo)) 
			{
				if (!hitInfo.collider.isTrigger) 
				{
					if(Mathf.Abs (hitInfo.distance - targetHeight) < .15) 
					{
						curState = state.WALKING;
					}
				}
			} 
			else 
			{
				
			}
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
		
		if (isGhost) {
			colorCorrection.enabled = true;
			motionBlur.enabled = true;
			if (Level1) {
				NPC.GetComponentInChildren<Rigidbody> ().isKinematic = true;
				//NPC.GetComponentInChildren<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionY;
				NPC.GetComponentInChildren<SphereCollider> ().enabled = false;
			}
		}
		if (!isGhost) {
			colorCorrection.enabled = false;
			motionBlur.enabled = false;
			if (Level1) {
				NPC.GetComponentInChildren<SphereCollider> ().enabled = true;
				//NPC.GetComponentInChildren<Rigidbody> ().constraints = RigidbodyConstraints.None;
				NPC.GetComponentInChildren<Rigidbody> ().isKinematic = false;
			}
		}

	}
		
		
}
