using UnityEngine;

public class Exit : MonoBehaviour
{
	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Application.Quit();
		}
	}	
}
