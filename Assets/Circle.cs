using UnityEngine;
using System.Collections;


[ExecuteInEditMode]
public class Circle : Shape 
{
	[SerializeField]
	float defaultRadius;

	[SerializeField]
	float radius;

	[SerializeField]
	Transform visual;

	private CircleCollider2D cCollider;

	public float Radius 
	{
		get 
		{
			return radius;
		}
		set
		{
			radius = value;
			cCollider.radius = radius;
			visual.localScale = new Vector3(radius / defaultRadius, radius / defaultRadius, radius / defaultRadius);
		}
	}

	void Awake()
	{
		cCollider = GetComponent<CircleCollider2D> ();
	}

	void Start ()
	{}

	void Update () 
	{
#if UNITY_EDITOR
		Radius = radius;
#endif
	}


	public override float GetSurface ()
	{
		return Mathf.PI * Radius * Radius;
	}

	public override void AddSurface(float amount)
	{
		float newSurface = GetSurface () + amount;

		float newRadius = Mathf.Sqrt (newSurface / Mathf.PI);
	
		Radius = newRadius;
	}

	public override void SetSurface(float surface)
	{
		Radius = Mathf.Sqrt (surface / Mathf.PI);
	}
}
