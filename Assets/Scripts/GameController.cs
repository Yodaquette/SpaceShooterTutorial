using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	private int score;

	// Text for restart and game over
	public GUIText restartText;
	public GUIText gameOverText;

	// Game over and restart flags
	private bool gameOver,restart;

	void Start()
	{
		// Initial values for gameover and restart
		gameOver = false;
		restart = false;

		// Initial values for gameover and restart text
		restartText.text = "";
		gameOverText.text = "";

		score = 0;
		updateScore();

		StartCoroutine(spawnWaves());
	}

	void Update()
	{
		if(restart)
		{
			if(Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

	// Generate hazards for the player
	IEnumerator spawnWaves()
	{
		yield return new WaitForSeconds(startWait);

		// Continuously spawn waves of hazards
		while(true)
		{
			for(int i = 0;i < hazardCount;i++)
			{
				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x,spawnValues.x),spawnValues.y,spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;

				Instantiate(hazard,spawnPosition,spawnRotation);

				yield return new WaitForSeconds(spawnWait);
			}

			yield return new WaitForSeconds(waveWait);

			if(gameOver)
			{
				restartText.text = "Press 'R' to restart.";
				restart = true;

				// End the play loop
				break;
			}
		}
	}

	public void addScore(int newScoreValue)
	{
		score += newScoreValue;

		updateScore();
	}

	void updateScore()
	{
		scoreText.text = "Score: " + score.ToString();
	}

	public void GameOver()
	{
		// Display game over text and set game over flag to 'true'
		gameOverText.text = "Game Over";
		gameOver = true;
	}
}