using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElephandMovement : MonoBehaviour
{
	[Range(2, 7)]public float	speedRotation = 5f;
	public float				MinYRot;
	public float				MaxYRot;
	public float				MinZRot;
	public float				MaxZRot;
	public float				MinXRot;
	public float				MaxXRot;
	public Animator				_LightAnimation;
	public Animator				_CameraAnimation;

	bool				_PlayerWin = false;
	bool winAnimationCompleted = true;
	
	void Start()
	{
		transform.eulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
	}

	void Update ()
	{
		float Haxis = Input.GetAxis("Mouse Y");
		float Vaxis = Input.GetAxis("Mouse X");
		if (Input.GetKey(KeyCode.LeftControl) && Input.GetMouseButton(0) && winAnimationCompleted)
			transform.Rotate(Haxis * speedRotation, 0, 0, Space.World);
		else if (Input.GetMouseButton(0) && winAnimationCompleted)
			transform.Rotate(0, -1 * Vaxis * speedRotation, Haxis * speedRotation, Space.World);
		checkObjRotation();
	}

	void checkObjRotation()
	{
		if (transform.eulerAngles.y >= (MinYRot + 360) && transform.eulerAngles.y <= (MaxYRot + 360) && _PlayerWin == false)
		{
			if (transform.eulerAngles.z >= MinZRot && transform.eulerAngles.z <= MaxZRot)
				{
					if (transform.eulerAngles.x >= MinXRot && transform.eulerAngles.x <= MaxXRot)
						{
							if (PlayerPrefs.GetInt("Mode") == 0)
							{
								PlayerPrefs.SetInt("Level3", 1);
							}
							// Debug.Log("YOU WIN!");
							_PlayerWin = true;
							Time.timeScale = 0.4f;
							winAnimationCompleted = false;
							Cursor.visible = false;
							_LightAnimation.SetTrigger("LevelClear");
							_CameraAnimation.SetTrigger("LevelClear");
							StartCoroutine(ReactiveMouse());
						}
				}
		}
		else
			_PlayerWin = false;
	}

	IEnumerator	ReactiveMouse()
	{
		yield return new WaitForSeconds(2);
		winAnimationCompleted = true;
		Cursor.visible = true;
	}
}