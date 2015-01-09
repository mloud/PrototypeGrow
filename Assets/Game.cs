using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
	private Shape hitShape = null;

	private List<Shape> Shapes { get; set; }
	private Playground Playground { get; set; }

	private enum State
	{
		Running = 0,
		GameOver
	}

	private State CurrState;

	void Start () 
	{
		Shapes = new List<Shape> (GameObject.FindObjectsOfType<Shape>());
	
		Playground = GameObject.FindObjectOfType<Playground> ();

		Shapes.ForEach (x => x.OnShapeCollision = this.OnShapeCollision);

		CurrState = State.Running;
	}
	
	void Update ()
	{
		ProcessTouch ();
	}


	void ProcessTouch()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			hitShape = GetHitShape(Input.mousePosition);
		}
		else if (Input.GetMouseButtonUp (0))
		{
			if (hitShape != null)
			{
				var hit = GetHitShape(Input.mousePosition);

				if (hit != null && !object.ReferenceEquals(hit, hitShape))
				{
					hit.AddSurface(hitShape.GetSurface());

					var pos = hitShape.transform.position;

					RecreateShape(hit, pos);

					Destroy(hitShape.gameObject);

				}
			}
		}
	}


	private void RecreateShape(Shape shape, Vector3 pos)
	{
		var clone = (GameObject.Instantiate (shape.gameObject) as GameObject).GetComponent<Shape> ();
		clone.name = shape.name;
		clone.transform.position = pos;

		clone.OnShapeCollision = this.OnShapeCollision;

		clone.SetSurface (shape.GetSurface () * 0.3f);
	}

	private Shape GetHitShape(Vector2 pos)
	{
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(pos.x, pos.y, 10)), Vector2.zero);
		
		if(hit.collider != null)
		{
			var shape = hit.collider.gameObject.GetComponent<Shape>();
			
			if (shape != null)
			{
				return shape;
			}
		}

		return  null;
	}


	private void OnShapeCollision(Shape shape1, Shape shape2)
	{	
		if (CurrState == State.Running)
		{
			Debug.Log ("Game.OnShapeCollision() " + shape1.name + " with " + shape2.name);

			GameOver ();
		}
	}


	private void GameOver()
	{
		CurrState = State.GameOver;

		WindowManager.Instance.OpenWindow (WindowDef.GameOver, new GameOverWindow.Param() { Score = 99 });
	}
}
