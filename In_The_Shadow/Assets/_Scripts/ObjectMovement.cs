using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
	[Range(2, 7)]public float	speedRotation = 5f;
	public float	MinYRot;
	public float	MaxYRot;
	public float	MinZRot;
	public float	MaxZRot;
	public float	MinXRot;
	public float	MaxXRot;
	
	void Start()
	{
		transform.eulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
	}

	void Update ()
	{
		float Haxis = Input.GetAxis("Mouse Y");
		float Vaxis = Input.GetAxis("Mouse X");
		if (Input.GetKey(KeyCode.LeftControl) && Input.GetMouseButton(0))
		{
			transform.Rotate(Haxis * speedRotation, 0, 0);
			// transform.rotation = Quaternion.Euler(Haxis * speedRotation, 0, 0);
		}
		else if (Input.GetMouseButton(0))
		{
			transform.Rotate(0, -1 * Vaxis * speedRotation, Haxis * speedRotation);
			// transform.rotation = Quaternion.Euler(0, -1 * Vaxis * speedRotation, Haxis * speedRotation);
		}
		checkObjRotation();
	}

	void checkObjRotation()
	{
		Vector3 min = new Vector3(MinXRot, MinYRot, MinZRot);
		Vector3 max = new Vector3(MaxXRot, MaxYRot, MaxZRot);



	}
}
