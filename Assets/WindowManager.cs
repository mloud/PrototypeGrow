using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class WindowManager : MonoBehaviour 
{
	public static WindowManager Instance { get; set; }

	private List<Window> Windows { get; set; }

	private void Awake()
	{
		Instance = this;

		Windows = new List<Window>();

		DontDestroyOnLoad (gameObject);
	}

	public void OpenWindow(string name, object param)
	{
		var window = CreateWindow (name);

		window.Init (param);
	
		Windows.Add (window);
	}

	public void CloseWindow(string name)
	{
		if (IsOpen(name))
		{
			int index = Windows.FindIndex(x=>x.Name == name);

			var win = Windows[index];

			Windows.RemoveAt(index);

			win.Close();

			Destroy (win.gameObject);
		}
	}

	public bool IsOpen(string name)
	{
		return Windows.Find (x => x.Name == name) != null;
	}

	private Window CreateWindow(string name)
	{
		var win = (Instantiate(Resources.Load ("Prefabs/Ui/" + name)) as GameObject).GetComponent<Window> ();

		win.transform.SetParent (GameObject.FindObjectOfType<Canvas> ().transform);

		return win;

	}
}
