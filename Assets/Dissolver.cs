using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Dissolver : MonoBehaviour
{
	Material material;

	bool isDissolving = false;
	float Fade = 1f;
	public PlayableDirector director;
	public Material dissolver;

	void Start()
	{
		// Get a reference to the material
		material = GetComponent<SpriteRenderer>().material;
		director = GetComponent<PlayableDirector>();
		director.played += OnTimelinePlayed;
	}
	void OnTimelinePlayed(PlayableDirector director)
    {
		isDissolving = true;
    }
	void Update()
	{
	
		if (isDissolving)
		{
			Fade -= Time.deltaTime;

			if (Fade <= 0f)
			{
				Fade = 0f;
				isDissolving = false;
			}

			// Set the property
			material.SetFloat("_Fade", Fade);
		}
	}
}