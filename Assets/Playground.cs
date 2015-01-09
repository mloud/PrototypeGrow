using UnityEngine;
using System.Collections;

public class Playground : MonoBehaviour 
{
	public Vector2 Size { get { return bCollider.size; } }


	private BoxCollider2D bCollider;

	void Awake () 
	{
		bCollider = GetComponent<BoxCollider2D> ();
	}

	public float GetSurface()
	{
		return Size.x * Size.y;
	}
}
