using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Rectangle : Shape 
{
	[SerializeField]
	private Vector2 defaultSize;

	[SerializeField]
	private Vector2 size;

	[SerializeField]
	Transform visual;

	public void SetSize(float x) 
	{
		size.x = x;
		size.y = x / Aspect();

		bCollider.size = size;

		float scale = size.x / defaultSize.x;
		visual.localScale = new Vector3(scale, scale, scale);
	}

	private BoxCollider2D bCollider;


	void Awake()
	{
		bCollider = GetComponent<BoxCollider2D> ();
	}

	void Start ()
	{
	}

	float Aspect()
	{
		return defaultSize.x / defaultSize.y;
	}

	void Update ()
	{
#if UNITY_EDITOR
		SetSize(size.x);
#endif
	}


	public override float GetSurface ()
	{
		return size.x * size.y;
	}
	
	public override void AddSurface(float amount)
	{
		float newSurface = GetSurface () + amount;
		
		size.y = Mathf.Sqrt (newSurface / Aspect());
		size.x = size.y * Aspect();
	}
	
	public override void SetSurface(float surface)
	{
		size.y = Mathf.Sqrt (surface / Aspect());
		size.x = size.y * Aspect();
	}
}
