using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	//public GameObject hazard;
	public GameObject npcvan, npclimo, npcmini, npcconv, npcvan2, npclimo2, npcmini2, npcconv2;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

    public float waitTime;

	public GUIText	scoreText;
	public GUIText restartText;
	public GUIText	gameOverText;
	public GUIText	gameOverScoreText;

	private GameObject carSpawned;
	private float yRotation;

	private bool gameOver;
	private bool restart;
	private int score;

	//movement speed manipulator
	public static float movespeed = 10;
	//cylinder rotate manipulator
	public static Vector3 rotateVal;

	//audio
	public AudioSource soundtrack;
	public AudioSource MainMenu;

	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		gameOverScoreText.text = "";
		score = 0;
		updateScore ();
		StartCoroutine (spawnWaves ());

		MainMenu.Stop ();
		soundtrack.Play ();

		//start incrementing score after 3 seconds
		//then continually increment every 1 second
		InvokeRepeating("timeScore", 3.0f, 1.0f);
	}

	void Update ()
	{
        if (waitTime < Time.timeSinceLevelLoad && gameOver) {
            Application.LoadLevel(0);
            SceneManager.LoadScene(0);
            
        }
		movespeed = 10 + ((Time.timeSinceLevelLoad));

		if(!gameOver)
			rotateVal = new Vector3 (0, 90, 0) * Time.deltaTime / 2f;

		//Debug.Log (movespeed);
		//Debug.Log (MiddleBoundaryScript.middlelaneoccupied);
		if (restart) 
		{
			/*
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
			*/
				
			if (Input.GetMouseButtonDown (0)) {
				//var hit : RaycastHit;
				//var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

				if (Physics.Raycast (ray, out hit)) {
					if (hit.transform.name == "LeftScreen" || hit.transform.name == "LeftScreen")
						Application.LoadLevel (Application.loadedLevel);
				}
			}

		}
	}

	IEnumerator spawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++) 
			{	
				float lane = 0f;
				int carLaneChooser = Random.Range(0,5);
				int carChooser = Random.Range(0,16);


				spawnValues.z = 34f;

				if (carChooser >= 0 && carChooser <= 4)
					carSpawned = npcvan2;
				else if (carChooser >= 5 && carChooser <= 9)
					carSpawned = npcconv2;
				else if (carChooser >= 10 && carChooser <= 14)
					carSpawned = npcmini2;
				else if (carChooser == 15)
					carSpawned = npclimo2;

				if (carLaneChooser == 0 && LeftBoundaryScript.leftlaneoccupied == false) {
					lane = -5.5f;
				} else if (carLaneChooser == 1 && LeftMiddleBoundaryScript.leftmiddlelaneoccupied == false) {
					lane = -2.75f;
				} else if (carLaneChooser == 2 && MiddleBoundaryScript.middlelaneoccupied == false) {
					lane = 0.0f;
				} else if (carLaneChooser == 3 && RightMiddleBoundaryScript.rightmiddlelaneoccupied == false) {
					lane = 2.75f;
				} else if (carLaneChooser == 4 && RightBoundaryScript.rightlaneoccupied == false) {
					lane = 5.5f;
				} else
					continue;


				//if else structure to determine which car is being spawned and set the coordinates accurately
				/*
				if (carChooser >= 0 && carChooser <= 4) 
				{

					carSpawned = npcvan;
					yRotation = -90f;
					spawnValues.z = 17f;

					if (carLaneChooser == 0 && LeftBoundaryScript.leftlaneoccupied == false) {
						lane = -32.93f;
					} else if (carLaneChooser == 1 && LeftMiddleBoundaryScript.leftmiddlelaneoccupied == false) {
						lane = -30.15f;
					} else if (carLaneChooser == 2 && MiddleBoundaryScript.middlelaneoccupied == false) {
						lane = -27.43f;
					} else if (carLaneChooser == 3 && RightMiddleBoundaryScript.rightmiddlelaneoccupied == false) {
						lane = -24.7f;
					} else if (carLaneChooser == 4 && RightBoundaryScript.rightlaneoccupied == false)
						lane = -21.95f;
					else {
						continue;
					}
				} 
				else if (carChooser == 15) 
				{
					carSpawned = npclimo;
					yRotation = 90f;
					spawnValues.z = 44f;

					if (carLaneChooser == 0 && LeftBoundaryScript.leftlaneoccupied == false) {
						lane = -5.35f;
					} else if (carLaneChooser == 1 && LeftMiddleBoundaryScript.leftmiddlelaneoccupied == false) {
						lane = -2.6f;
					} else if (carLaneChooser == 2 && MiddleBoundaryScript.middlelaneoccupied == false) {
						lane = 0.15f;
					} else if (carLaneChooser == 3 && RightMiddleBoundaryScript.rightmiddlelaneoccupied == false) {
						lane = 2.85f;
					} else if (carLaneChooser == 4 && RightBoundaryScript.rightlaneoccupied == false)
						lane = 5.625f;
					else {
						continue;
					}
				}
				else if (carChooser >= 10 && carChooser <= 14) 
				{
					carSpawned = npcmini;
					yRotation = 0f;
					spawnValues.z = 33f;

					if (carLaneChooser == 0 && LeftBoundaryScript.leftlaneoccupied == false) {
						lane = -4.77f;
					} else if (carLaneChooser == 1 && LeftMiddleBoundaryScript.leftmiddlelaneoccupied == false) {
						lane = -2.03f;
					} else if (carLaneChooser == 2 && MiddleBoundaryScript.middlelaneoccupied == false) {
						lane = 0.71f;
					} else if (carLaneChooser == 3 && RightMiddleBoundaryScript.rightmiddlelaneoccupied == false) {
						lane = 3.42f;
					} else if (carLaneChooser == 4 && RightBoundaryScript.rightlaneoccupied == false)
						lane = 6.15f;
					else {
						continue;
					}
				}
				else if (carChooser >= 5 && carChooser <= 9) 
				{
					carSpawned = npcconv;
					yRotation = 0f;
					spawnValues.z = 32f;

					if (carLaneChooser == 0 && LeftBoundaryScript.leftlaneoccupied == false) {
						lane = -4.64f;
					} else if (carLaneChooser == 1 && LeftMiddleBoundaryScript.leftmiddlelaneoccupied == false) {
						lane = -1.87f;
					} else if (carLaneChooser == 2 && MiddleBoundaryScript.middlelaneoccupied == false) {
						lane = 0.84f;
					} else if (carLaneChooser == 3 && RightMiddleBoundaryScript.rightmiddlelaneoccupied == false) {
						lane = 3.55f;
					} else if (carLaneChooser == 4 && RightBoundaryScript.rightlaneoccupied == false)
						lane = 6.32f;
					else {
						continue;
					}
				}
				*/



				Vector3 spawnPos = new Vector3 (lane, spawnValues.y, spawnValues.z);
				//Quaternion spawnRot = Quaternion.identity;
				//Quaternion sr = Quaternion.Euler(new Vector3(0f,-90f,0));
				//Instantiate (npcvan, spawnPos, sr);
				Quaternion sr = Quaternion.Euler(new Vector3(0f,yRotation,0));
				Instantiate (carSpawned, spawnPos, sr);


				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver) 
			{
				//restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}

	public void addScore (int newScoreValue)
	{
		score += newScoreValue;
		updateScore ();
	}

	public void timeScore()
	{
		if (!gameOver) {
			score++;
			updateScore ();
		}
	}

	void updateScore()
	{
		scoreText.text = "" + score;
	}

	public void GameOver()
	{
		scoreText.text = "";
		gameOverText.text = "Game Over";
		gameOverScoreText.text = "\n\nScore\n\n"+score;
		gameOver = true;
		rotateVal = new Vector3 (0, 0, 0);
		soundtrack.Stop ();
		MainMenu.Play ();
        waitTime = Time.timeSinceLevelLoad + 3;
	}

}
