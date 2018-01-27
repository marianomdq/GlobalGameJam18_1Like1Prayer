using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingAnimation : MonoBehaviour {

	public GameObject PlayerControllerPrefab;
	public GameObject AnimationThumbUp;
	public SmoothFollow AnimationCamera;

	public void StartAnimation()
	{
		// Start the Menu Animation
		GetComponent<Animator>().SetBool("HasClicked", true);
		// Fade Out the Menu Music and Start the Dubstep forever
		AudioManager.instance.FadeOutAndPlayMainMusic(2.0f);
	}

	public void FinishAnimation()
	{
		// Detach children
		AnimationCamera.transform.parent = null;
		AnimationThumbUp.transform.parent = null;

		// Create the Player Controller
		GameObject PlayerController = Instantiate(PlayerControllerPrefab, AnimationThumbUp.transform.position, AnimationThumbUp.transform.rotation);
		// Set the Box Collider Position
		PlayerController.GetComponent<BoxCollider>().center = new Vector3(-0.03f, -0.06f, 0.04f);
		// Destroy the current player in the Prefab
		Destroy(PlayerController.transform.GetChild(0).gameObject);
		// Add our ThumbUp Animation Mesh as a child
		AnimationThumbUp.transform.parent = PlayerController.transform;
		// And now set it as the player to be controlled
		PlayerController.GetComponent<PlayerCtrl>().PlayerMesh = AnimationThumbUp;
		
		// Set the camera to follow player mode
		AnimationCamera.enabled = true;

		// Destroy this animation container
		Destroy(gameObject);
	}

}
