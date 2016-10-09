using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

	public static SoundManager _Instance;
	public AudioClip[] audioClipArray;
	private Dictionary<string,AudioClip> audioDict=new Dictionary<string, AudioClip>();
	private AudioSource audioSource;
    public bool isQuiet = false;

	void Awake()
	{
		_Instance = this;
	}

	void Start()
	{
		audioSource = this.GetComponent<AudioSource> ();

		foreach (AudioClip ac in audioClipArray) {
			audioDict.Add(ac.name,ac);
		}
	}

	public void Play(string audioName)
	{
        //Debug.Log("PlayAudio");

        if (isQuiet)
            return;
		AudioClip ac;
		if (audioDict.TryGetValue (audioName, out ac)) {
			audioSource.PlayOneShot(ac);
		}
	}

	public void Play(string audioName,AudioSource audiosource)
	{
        if (isQuiet)
            return;
		AudioClip ac;
		if (audioDict.TryGetValue (audioName, out ac)) {
			audiosource.PlayOneShot(ac);
		}
	}


}
