using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameOverWindow : Window 
{
	[SerializeField]
	Text txtScoreValue;

	public class Param
	{
		public int Score;
	}

	protected override void OnInit(object param)
	{
		var p = param as Param;

		txtScoreValue.text = p.Score.ToString ();
	}
}
