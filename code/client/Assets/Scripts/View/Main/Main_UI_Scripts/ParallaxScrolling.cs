using UnityEngine;
using System.Collections;

public class ParallaxScrolling : MonoBehaviour
{
	public Transform[] Layers;
	public float[] Offsets;
	int count;
	bool dragged;
	bool tweened;
	float lastTouch;
	float dragOffset;
	float tweenTime;
	const float MaxTweenTime = 0.5f;
	float location;
	float touchToPos;
	
	// Use this for initialization
	void Start ()
	{
		count = Layers.Length;
		dragged = false;
		tweened = false;
		touchToPos = 1f / Screen.width * camera.orthographicSize * 2f * camera.aspect / Mathf.Abs(Offsets[0]);
		SetPosition(0.5f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			dragged = true;
			tweened = false;
			lastTouch = Input.mousePosition.x;
		}
		if (Input.GetMouseButtonUp(0))
		{
			dragged = false;
			tweened = true;
			tweenTime = 0f;
		}
		if (dragged)
		{
			float currTouch = Input.mousePosition.x;
			dragOffset = lastTouch - currTouch;
			lastTouch = currTouch;
			dragOffset *= touchToPos;
			location += dragOffset;
			//            location = Mathf.Clamp01(location);
			SetPosition(location);
		} else if (tweened)
		{
			tweenTime += Time.deltaTime;
			if (tweenTime > MaxTweenTime)
			{
				tweened = false;
			} else 
			{
				float offset = dragOffset * (1 - tweenTime / MaxTweenTime);
				location += offset;
				SetPosition(location);
			}
		}
	}


    public void ShutDownDraggedOnce()
    {
        dragged = false;
        tweened = false;
        tweenTime = 0f;
    }

    public void SetPosition(float position)
	{
		location = Mathf.Clamp01(position);
		for (int i = 0; i < count; i++)
		{
			Layers[i].localPosition = new Vector3(Offsets[i] * location ,0, 0);
		}
	}
}
