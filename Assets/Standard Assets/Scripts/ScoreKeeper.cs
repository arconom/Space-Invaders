using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;

public class ScoreKeeper : MonoBehaviour 
{
	private int score = 0;
	private int penalty = 0;
	public int kills = 0;
	private int killsToWin = 50;

	private Dictionary<string, int> highScores = new Dictionary<string, int>();
	private string scoresPath = @"\scores.txt";

	private bool lose = false;
	private bool show = true;
	private bool win = false;

	private Rect windowRect0 = new Rect(0, 0, 120, 50);
//	private Rect windowRect1 = new Rect(0, 100, 120, 50);

	void Start()
	{
		ReadScores ();
		Show ();
	}

	private void ReadScores()
	{
		try
		{
			string name = "Dicks";
			int score = 0;
			string[] data;
			
			using (StreamReader reader = new StreamReader(scoresPath)) 
			{
				while (reader.Peek() >= 0) 
				{
					data = reader.ReadLine ().Split (',');
					name = data[0];
					score = Convert.ToInt32 (data[1]);
					
					highScores.Add(name, score); 
				}
			}
		}
		catch
		{
			print ("no high scores found");
		}
	}

	private void WriteScores()
	{
		try
		{
			using (StreamWriter writer = new StreamWriter(scoresPath)) 
			{
				foreach (string s in highScores.Keys)
				{
					writer.WriteLine (s + "," + highScores[s]);
				}
			}
		}
		catch
		{
			print ("error writing scores");
		}
	}

	private void OnGUI() 
	{
		if(show)
		{
			windowRect0 = GUI.Window(0, windowRect0, ScoreWindow, "Score");
		}
		else if(win)
		{
			windowRect0 = GUI.Window(0, windowRect0, WinWindow, "Victory");
		}
		else if(lose)
		{
			windowRect0 = GUI.Window(0, windowRect0, LoseWindow, "Annihilated");
		}
	}
	
	void WinWindow(int windowID) 
	{
		string name = "Dicks";
		int mult = 0;

		GUI.TextField (new Rect(10,10,50,20),name,6);
		if (GUI.Button(new Rect(10,30,50,20), "You Win"))
		{
			highScores.Add (name, score);
			Application.LoadLevel("Space Invaders 2D");
		}

		foreach (string s in highScores.Keys)
		{
			GUI.Label (new Rect(mult * 25, mult * 25, 100, 20), s + " " + highScores[s].ToString());
			mult++;
		}
	}

	void LoseWindow(int windowID) 
	{
		if (GUI.Button(new Rect(10, 20, 100, 20), "Restart"))
		{
			Application.LoadLevel("Space Invaders 2D");
		}
	}

	void ScoreWindow(int windowID) 
	{
		GUI.Label (new Rect(10, 10, 200, 20), "your score is " + score.ToString());
	}

	public void Show()
	{
		show = true;
		lose = false;
		win = false;
	}

	public void Win()
	{
		show = false;
		win = true;
		lose = false;
	}

	public void Lose()
	{
		win = false;
		lose = true;
		show = false;
	}

	private void UpdateScore()
	{
		int displayMe = score - penalty;
		GameObject.Find ("ScoreCard").guiText.text = displayMe.ToString ();
	}

	public void AddScore(int addMe)
	{
		score += addMe - penalty;
		UpdateScore ();
	}
	public void AddPenalty(int addMe)
	{
		penalty += addMe;
		UpdateScore ();
	}

	public void AddKills(int addMe)
	{
		kills += addMe;
		if(kills >= killsToWin)
		{
			Win ();
		}
	}
}
