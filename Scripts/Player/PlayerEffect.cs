using UnityEngine;
using System.Collections;

public class PlayerEffect : MonoBehaviour {

	private Renderer[] renderArray;
	private NcCurveAnimation ac;

	// Use this for initialization
	void Start () {
		renderArray = this.GetComponentsInChildren<Renderer> ();
		ac = this.GetComponentInChildren<NcCurveAnimation> ();
	}
	
	public void Show()
	{
		Debug.Log("Show Effect");

		foreach (Renderer render in renderArray) {
			render.enabled=true;

		}

		ac.ResetAnimation ();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown (0)) {
			Show();
		}
	}
}
