using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GM : MonoBehaviour {
	public int life = 3;
	public int score;
	public int enemiesDefeated;
	public float time = 1;
	public float timeMod = .8f;
	public float timeToMove = 1;
	public float distancePerMove = 15;
	public float level = 1;
	public TextMeshProUGUI scoreCounter;
	public TextMeshProUGUI lifeCounter;
	public TextMeshProUGUI gameOver;
	public TextMeshProUGUI youWin;
	public TextMeshProUGUI level1;
	public TextMeshProUGUI level2;
	public TextMeshProUGUI level3;
	public bool killGM = false;





	/// <summary>
	/// Game master keeps track of invaders and player
	/// If player dies, respawn the player 
	/// If all invaders died, you win
	/// </summary>

	private void Awake()
    {
		//disables all the non-relevant GUI for later re-activation
		gameOver.enabled = false;
		youWin.enabled = false;
		level2.enabled = false;
		level3.enabled = false;
		StartCoroutine("turnOff");

		
		//keeps the GM from being destroyed on scene load so that it maintains score and life count
		DontDestroyOnLoad(this.gameObject);
		score = 0;
	}

    void Start () {

		Time.timeScale = 1;
		StartCoroutine ("timeIncrease");
		
		
	}
	
	void Update () {
		//maintains score and lives GUI
		scoreCounter.text = score.ToString();
		lifeCounter.text = "Lives: " + life.ToString();

		if(enemiesDefeated == 40)
        {
			enemiesDefeated = 0;
			StartCoroutine("win");
        }

		if (killGM == true)
		{
			Destroy(this.gameObject);
		}



	}
	//speeds up time between enemy ship movments by multiplying a base number by a % as defined in engine
	IEnumerator timeIncrease()
	{
		yield return new WaitForSeconds(10);
		time*=timeMod;
		//Debug.Log(time);
		StartCoroutine("timeIncrease");

	}
	//controls the logic for scene loading on level completion
	IEnumerator win()
	{
		
		yield return new WaitForSeconds(0.5f);
		level++;
	
		if (level == 2)
		{
			SceneManager.LoadScene(38);
			level2.enabled = true;
			StartCoroutine("turnOff");
			time = 1;

		}
		else if (level == 3)
		{
			SceneManager.LoadScene(39);
			level3.enabled = true;
			StartCoroutine("turnOff");
			time = 1;
		}
		else if (level > 3)
		{
			Time.timeScale = .5f;
			youWin.enabled = true;
			StartCoroutine("endGame2");
		}
	}
//turns off the Currentlevel GUI
	IEnumerator turnOff()
	{
		yield return new WaitForSeconds(2);
		level1.enabled = false;
		level2.enabled = false;
		level3.enabled = false;

	}
//logic for end of game on loss
	IEnumerator endGame()
	{
		Time.timeScale = .5f;
		yield return new WaitForSeconds(0.5f);
		gameOver.enabled = true;
		StartCoroutine("endGame2");
		
	}
		
	//destroys all game objects in the do not destroy category and loads the final scene	
	IEnumerator endGame2()
	{
		
		yield return new WaitForSeconds(4);
		SceneManager.LoadScene(34);
		GameObject canvas = GameObject.Find("Canvas");
		canvas.GetComponent<CanvasDestroy>().killCanvas = true;
		
		killGM = true;
	}
}


