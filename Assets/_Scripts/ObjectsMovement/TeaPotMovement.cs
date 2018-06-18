using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaPotMovement : MonoBehaviour
{
	[Range(2, 7)]public float	speedRotation = 5f;
	public float				MinYRot;
	public float				MaxYRot;
	public Animator				_LightAnimation;
	public Animator				_CameraAnimation;

	bool				_PlayerWin = false;
	bool winAnimationCompleted = true;
	
	void Start()
	{
		transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
	}

	void Update ()
	{
		float Vaxis = Input.GetAxis("Mouse X");
		if (Input.GetMouseButton(0) && winAnimationCompleted)
			transform.Rotate(0, -1 * Vaxis * speedRotation, 0, Space.World);
		checkObjRotation();
	}

	void checkObjRotation()
	{
		if ((transform.eulerAngles.y >= MinYRot && transform.eulerAngles.y <= MaxYRot) && _PlayerWin == false)
		{
			// Debug.Log("YOU WIN!");
			if (PlayerPrefs.GetInt("Mode") == 0)
			{
				PlayerPrefs.SetInt("Level2", 1);
			}
			//need to put win animation!
			_PlayerWin = true;
			Time.timeScale = 0.4f;
			winAnimationCompleted = false;
			// Cursor.visible = false;
			_LightAnimation.SetTrigger("LevelClear");
			_CameraAnimation.SetTrigger("LevelClear");
			StartCoroutine(ReactiveMouse());
		}
		else
			_PlayerWin = false;
	}

	IEnumerator	ReactiveMouse()
	{
		yield return new WaitForSeconds(2);
		Time.timeScale = 1f;
		winAnimationCompleted = true;
		// Cursor.visible = true;
	}
}