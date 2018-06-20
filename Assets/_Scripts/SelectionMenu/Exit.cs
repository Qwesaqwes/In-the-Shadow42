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

	void OnMouseEnter()
	{
		transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
	}

	void OnMouseExit()
	{
		transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
	}
}
