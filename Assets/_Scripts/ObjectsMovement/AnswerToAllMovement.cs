using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerToAllMovement : MonoBehaviour
{
	[Range(2, 7)]
	public float		speedRotation = 5f;
	[Range(0.01f,0.05f)]
	public float		speedMovement = 0.01f; 
	public Transform	Number4;
	public Transform	Number2;
	public Material		Number4Material;
	public Material		Number2Material;
	public Animator		LightAnimation;
	public Animator		CameraAnimation;


	bool				_selected = false;
	bool				_Number4OK = false;
	bool				_Number2OK = false;
	bool				_PlayerWin = false;
	bool				winAnimationCompleted = true;



	// Use this for initialization
	void Start ()
	{
		Number4.transform.eulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
		Number2.transform.eulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));	
	}
	
	// Update is called once per frame
	void Update ()
	{
		float HMouseaxis = Input.GetAxis("Mouse Y");
		float VMouseaxis = Input.GetAxis("Mouse X");
		if (Input.GetKeyDown(KeyCode.Space))
		{
			_selected = !_selected;
			Debug.Log(_selected);
		}
		if (!_selected) // target is Number4
		{
			if (Input.GetKey(KeyCode.LeftControl) && Input.GetMouseButton(0) && winAnimationCompleted)
				Number4.transform.Rotate(HMouseaxis * speedRotation, 0, 0, Space.World);
			else if (Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButton(0) && winAnimationCompleted)
			{
				Number4.transform.Translate(0, HMouseaxis * speedMovement, VMouseaxis * speedMovement, Space.World);
				// Debug.Log("Number4Y: :" + Number4.transform.position.y + "\nNumber4Z: " + Number4.transform.position.z + "\nNumber4X: " + Number4.transform.position.x);
				Number4.transform.position = new Vector3(Number4.transform.position.x, 
					Mathf.Clamp(Number4.transform.position.y, 1.451f, 2.522f), Mathf.Clamp(Number4.transform.position.z, 0.764f, 1.820f));
			}
			else if (Input.GetMouseButton(0) && winAnimationCompleted)
				Number4.transform.Rotate(0, -1 * VMouseaxis * speedRotation, HMouseaxis * speedRotation, Space.World);
		}
		else if (_selected)
		{
			if (Input.GetKey(KeyCode.LeftControl) && Input.GetMouseButton(0) && winAnimationCompleted)
				Number2.transform.Rotate(HMouseaxis * speedRotation, 0, 0, Space.World);
			else if (Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButton(0) && winAnimationCompleted)
			{
				Number2.transform.Translate(0, HMouseaxis * speedMovement, VMouseaxis * speedMovement, Space.World);
				// Debug.Log("Number2Y: :" + Number2.transform.position.y + "\nNumber2Z: " + Number2.transform.position.z + "\nNumber2X: " + Number2.transform.position.x);
				Number2.transform.position = new Vector3(Number2.transform.position.x, 
					Mathf.Clamp(Number2.transform.position.y, 1.451f, 2.522f), Mathf.Clamp(Number2.transform.position.z, 0.764f, 1.820f));
			}
			else if (Input.GetMouseButton(0) && winAnimationCompleted)
			{
				Number2.transform.Rotate(0, -1 * VMouseaxis * speedRotation, HMouseaxis * speedRotation, Space.World);
				// Debug.Log(Number2.transform.eulerAngles.z);
			}
		}
		checkNumber4();
		checkNumber2();
		if (_Number2OK && _Number4OK)
		{
			checkDistance();
		}

	}

	void checkNumber4()
	{
		if (Number4.transform.eulerAngles.y >= 85 && Number4.transform.eulerAngles.y <= 95)
		{
			if (Number4.transform.eulerAngles.x >= 352 && Number4.transform.eulerAngles.x <= 360)
			{
				if ((Number4.transform.eulerAngles.z >= 350 && Number4.transform.eulerAngles.z <= 360) ||
					Number4.transform.eulerAngles.z >= 0 && Number4.transform.eulerAngles.z <= 10)
				{
					if (!_Number4OK)
					{
						Number4Material.SetColor("_RimColor", Color.green);
						_Number4OK = true;
					}
				}
			}
		}
		else
		{
			_Number4OK = false;
			Number4Material.SetColor("_RimColor", Color.black);
		}
	}

	void checkNumber2()
	{
		if ((Number2.transform.eulerAngles.y >= 85 && Number2.transform.eulerAngles.y <= 100) ||
			(Number2.transform.eulerAngles.y >= 260 && Number2.transform.eulerAngles.y <= 280))
		{
			if ((Number2.transform.eulerAngles.x >= 350 && Number2.transform.eulerAngles.x <= 360) ||
				(Number2.transform.eulerAngles.x >= 0 && Number2.transform.eulerAngles.x <= 10) ||
				Number2.transform.eulerAngles.x >= 170 && Number2.transform.eulerAngles.x <= 190)
			{
				if ((Number2.transform.eulerAngles.z >= 350 && Number2.transform.eulerAngles.z <= 360) ||
					Number2.transform.eulerAngles.z >= 0 && Number2.transform.eulerAngles.z <= 10)
				{
					if (!_Number2OK)
					{
						Number2Material.SetColor("_RimColor", Color.green);
						_Number2OK = true;
					}
				}
			}
		}
		else
		{
			_Number2OK = false;
			Number2Material.SetColor("_RimColor", Color.black);
		}
	}

	void checkDistance()
	{
		float offsetY = Mathf.Abs(Number4.transform.position.y - Number2.transform.position.y);
		float offsetZ = (Number4.transform.position.z - Number2.transform.position.z);
		if (offsetY <= 0.05 && offsetZ >= -0.2 && offsetZ <= -0.15 && _PlayerWin == false)
		{
			if (PlayerPrefs.GetInt("Mode") == 0)
			{
				PlayerPrefs.SetInt("LastLevelClear", 1);
			}
			// Debug.Log("YOU WIN!");
			_PlayerWin = true;
			Time.timeScale = 0.4f;
			winAnimationCompleted = false;
			// Cursor.visible = false;
			LightAnimation.SetTrigger("LevelClear");
			CameraAnimation.SetTrigger("LevelClear");
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
