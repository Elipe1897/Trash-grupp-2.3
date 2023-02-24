using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Leo S

public class CameraShake : MonoBehaviour
{
	public static CameraShake instance;
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public Transform camTransform;

	// How long the object should shake for.
	public float shakeDuration = 0f;

	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;

	Vector3 originalPos; // the original position of hte camera

	void Awake()
	{
		shakeDuration = 0f;
		instance = this;
		//refers the camTransform variable to the cameras transform
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}

	void OnEnable()
	{
		//sets the original postition of the camera to infront of the player
		originalPos = camTransform.localPosition;
	}

	void Update()
	{
		originalPos = camTransform.localPosition;
		// if the shakeduration is more than 0 
		//the screen shakes
		//else the cam is set to the players position
		if (shakeDuration > 0)
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shakeDuration = 0f;
			camTransform.localPosition = originalPos;
		}


	}
	//sets the shakeduration to .1f so that the screen shakes
	public void Shake()
	{
		shakeDuration = 0.1f;
	}
}

