using UnityEngine;
using System.Collections;

public class App : MonoBehaviour
{

	public GoogleAnalyticsV3 GoogleAnalytics;

	void Start ()
	{
		GoogleAnalytics.StartSession();
	
		GoogleAnalytics.LogScreen ("MainScreen");

		GoogleAnalytics.LogEvent("Achievement", "Unlocked", "Slay 10 dragons", 5);
	}




	void OnDestroy()
	{
		GoogleAnalytics.StopSession ();
	}


	void Update () 
	{
	
	}
}
