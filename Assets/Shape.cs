using UnityEngine;
using System.Collections;


public abstract class Shape : MonoBehaviour 
{
	public delegate void ShapeCollisionDelegate(Shape shape1, Shape shape2);

	public ShapeCollisionDelegate OnShapeCollision;

	public abstract float GetSurface ();
	public abstract void AddSurface(float amount);
	public abstract void SetSurface(float amount);

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (OnShapeCollision != null)
		{
			var shapeOther = other.gameObject.GetComponent<Shape>();

			if (shapeOther != null)
			{
				OnShapeCollision(this, shapeOther);
			}
		}
	}
	
}
