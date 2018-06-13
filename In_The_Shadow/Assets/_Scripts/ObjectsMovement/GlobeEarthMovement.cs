﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobeEarthMovement : MonoBehaviour
{
	[Range(2, 7)]public float	speedRotation = 5f;
	[Range(0.01f,0.05f)]public float speedMovement = 0.01f; 
	public	Transform Earth;
	public	Transform Base;
	bool	_selected = false; //by default selected is targeting earth (false = earth / true = base)

	bool	_earthOK = false;
	bool	_baseOK = false;
	
	// Use this for initialization
	void Start ()
	{
		Earth.transform.eulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
		Base.transform.eulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
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
		if (!_selected) // target is earth
		{
			if (Input.GetKey(KeyCode.LeftControl) && Input.GetMouseButton(0))
				Earth.transform.Rotate(HMouseaxis * speedRotation, 0, 0, Space.World);
			else if (Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButton(0))
			{
				Earth.transform.Translate(0, HMouseaxis * speedMovement, VMouseaxis * speedMovement, Space.World);
				// Debug.Log("EarthY: :" + Earth.transform.position.y + "\nEarthZ: " + Earth.transform.position.z);
				Earth.transform.position = new Vector3(Earth.transform.position.x, 
					Mathf.Clamp(Earth.transform.position.y, 1.451f, 2.522f), Mathf.Clamp(Earth.transform.position.z, 0.764f, 1.820f));
			}
			else if (Input.GetMouseButton(0))
				Earth.transform.Rotate(0, -1 * VMouseaxis * speedRotation, HMouseaxis * speedRotation, Space.World);
		}
		else if (_selected)
		{
			if (Input.GetKey(KeyCode.LeftControl) && Input.GetMouseButton(0))
				Base.transform.Rotate(HMouseaxis * speedRotation, 0, 0, Space.World);
			else if (Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButton(0))
			{
				Base.transform.Translate(0, HMouseaxis * speedMovement, VMouseaxis * speedMovement, Space.World);
				// Debug.Log("BaseY: :" + Base.transform.position.y + "\nBaseZ: " + Base.transform.position.z);
				Base.transform.position = new Vector3(Base.transform.position.x, 
					Mathf.Clamp(Base.transform.position.y, 1.451f, 2.522f), Mathf.Clamp(Base.transform.position.z, 0.764f, 1.820f));
			}
			else if (Input.GetMouseButton(0))
			{
				Base.transform.Rotate(0, -1 * VMouseaxis * speedRotation, HMouseaxis * speedRotation, Space.World);
				// Debug.Log(Base.transform.eulerAngles.z);
			}
		}
		checkEarth();
		checkBase();
		if (_earthOK && _baseOK)
		{
			checkDistance();
		}
	}

	void checkEarth()
	{
		//z revert (-90)/ z normal (90)
		if ((Earth.transform.eulerAngles.z >= 260 && Earth.transform.eulerAngles.z <= 280) ||
			Earth.transform.eulerAngles.z >= 80 && Earth.transform.eulerAngles.z <= 100)
		{
			//y normal (0)
			if ((Earth.transform.eulerAngles.y >= 350 && Earth.transform.eulerAngles.y <= 360) ||
				Earth.transform.eulerAngles.y >= 0 && Earth.transform.eulerAngles.y <= 10)
			{
				if (!_earthOK)
				{
					Debug.Log("EarthOKK NORMAL");
					_earthOK = true;
				}
			}

			//y revert (180)
			if(Earth.transform.eulerAngles.y >= 170 && transform.eulerAngles.y <= 190)
			{
				if (!_earthOK)
				{
					Debug.Log("EarthOKKK REVERT");
					_earthOK = true;
				}
			}
		}
		else
			_earthOK = false;
	}

	void checkBase()
	{
		if (Base.transform.eulerAngles.y >= 310 && Base.transform.eulerAngles.y <= 330)
		{
			if (Base.transform.eulerAngles.z >= 310 && Base.transform.eulerAngles.z <= 330)
			{
				if (Base.transform.eulerAngles.x >= 270 && Base.transform.eulerAngles.x <= 290)
				{
					if (!_baseOK)
					{
						Debug.Log("BASEOKKKKK");
						_baseOK = true;
					}
				}
			}
		}
		else
			_baseOK = false;
	}

	void checkDistance()
	{
		float offsetY = Mathf.Abs(Base.transform.position.y - Earth.transform.position.y);
		float offsetZ = Mathf.Abs(Base.transform.position.z - Earth.transform.position.z);

		if (offsetY <= 0.01 && offsetZ <= 0.01)
		{
			Debug.Log("YOU WIN!");
		}
	}
}
