using UnityEngine;
using System.Collections;


public abstract class Shape : MonoBehaviour 
{
	public delegate void ShapeCollisionDelegate(Shape shape1, Shape shape2);

	public ShapeCollisionDelegate OnShapeCollision;

	public void AddSurface(float amount)
	{
		StartCoroutine (AddSurfaceCoroutine (amount, 0.3f));
	}


	public abstract float GetSurface ();
	public abstract void SetSurface(float amount);
	protected abstract void AddSurfaceInternal (float amount);


	private void OnTriggerEnter2D(Collider2D other) 
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


	// continual adding
	protected IEnumerator AddSurfaceCoroutine(float amount, float time)
	{
		float amountFull = amount;
		
		while (amount > 0)
		{
			float uAmount = Mathf.Min(amountFull * Time.deltaTime / time, amount);
			
			AddSurfaceInternal(uAmount);
			amount -= uAmount;
			
			yield return 0;
		}
	}
	
}
