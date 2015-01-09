using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hud : MonoBehaviour 
{
	[SerializeField]
	Text txtScore;

	public static Hud Instance { get; private set; }

	void Awake()
	{
		Instance = this;
	}

	public void SetScore(int score)
	{
		txtScore.text = score.ToString ();
	}
}
