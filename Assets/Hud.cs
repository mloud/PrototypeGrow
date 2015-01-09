using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hud : MonoBehaviour 
{
	[SerializeField]
	Text txtScore;

	[SerializeField]
	Image imgBarFill;

	public static Hud Instance { get; private set; }

	private Vector2 imgBarFillOrigSize;

	void Awake()
	{
		Instance = this;

		imgBarFillOrigSize = imgBarFill.GetComponent<RectTransform> ().sizeDelta;
	}

	public void SetScore(int score)
	{
		txtScore.text = score.ToString () + " %";

		Vector2 size = imgBarFillOrigSize;
		size.x *= score / 100.0f;

		imgBarFill.GetComponent<RectTransform> ().sizeDelta = size;
	}
}
