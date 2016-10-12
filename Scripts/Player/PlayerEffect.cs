using UnityEngine;
using System.Collections;

public class PlayerEffect : MonoBehaviour {

	private Renderer[] renderArray;
	private NcCurveAnimation ac;
    private GameObject EffectOffset;

	// Use this for initialization
	void Start () {
		renderArray = this.GetComponentsInChildren<Renderer> ();
		ac = this.GetComponentInChildren<NcCurveAnimation> ();


        if (transform.Find("EffectOffset")!=null)
        {
            EffectOffset = transform.Find("EffectOffset").gameObject;
        }
        
	}
	
	public void Show()
	{
		Debug.Log("Show Effect");


        if (EffectOffset != null)
        {
            EffectOffset.SetActive(true);
            StartCoroutine(DisableEffect(EffectOffset, 1f));
        }
        else
        {
            foreach (Renderer render in renderArray)
            {
                render.enabled = true;

            }

            ac.ResetAnimation();
        }
        
		
	}

	void Update()
	{
        //if (Input.GetMouseButtonDown (0)) {
        //    //Show();
        //}
	}


    IEnumerator DisableEffect(GameObject go,float seconds)
    {
        yield return new WaitForSeconds(seconds);
        go.SetActive(false);
    }
}
