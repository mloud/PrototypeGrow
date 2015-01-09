using UnityEngine;
using System.Collections;
using System;


[ExecuteInEditMode]
public class Triangle : Shape 
{
	[SerializeField]
	float defaultSize;

	[SerializeField]
	float size;

	[SerializeField]
	Transform visual;

	private PolygonCollider2D pCollider;
	private Vector2[] origColliderPoints;

	public float Size 
	{
		get 
		{
			return size;
		}
		set
		{
			size = value;

			float scale = size / defaultSize;

			visual.localScale = new Vector3(scale, scale, scale);
		
			Vector2[] points = origColliderPoints.Clone() as Vector2[];

			for (int i= 0; i < points.Length; ++i)
			{
				points[i] = origColliderPoints[i] * scale;
			}

			pCollider.SetPath(0, points);
		}
	}

	private bool IsInit;

	void Awake()
	{
		pCollider = GetComponent<PolygonCollider2D> ();
		origColliderPoints = pCollider.points.Clone () as Vector2[];
	}


	void Start () 
	{}
	
	void Update ()
	{

#if UNITY_EDITOR
		Size = size;
#endif
	}

	void Init()
	{
	}



	public override float GetSurface ()
	{
		return size * size * Mathf.Sqrt(3) / 4.0f;
	}

	public override void AddSurface(float amount)
	{
		SetSurface (GetSurface () + amount);
	}

	public override void SetSurface(float surface)
	{
		Size = (float)Math.Sqrt (surface * 4.0f / Mathf.Sqrt (3.0f));
	}

}
