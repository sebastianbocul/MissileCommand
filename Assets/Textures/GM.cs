using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GM : MonoBehaviour
{
    #region Others
    public string[] cityNames = { "city01", "city02", "city03", "city04", "city05", "city06", "city07" };
    public string[] city_d = { "city01_d(Clone)", "city02_d(Clone)", "city03_d(Clone)", "city04_d(Clone)", "city05_d(Clone)", "city06_d(Clone)", "city07_d(Clone)" };

    public Texture2D defaultTexture;
    public CursorMode curMode = CursorMode.Auto;
    public bool rocketLive = false;
    #endregion

    #region Vectors
    public Vector2 hotSpot = Vector2.zero;
    public Vector2 mousePosition;
    public static Vector2 objPosition = new Vector2(-5.76f, -4.4f);
    public static Vector2 targetPosition;
    private Vector3 mouse_pos;
    private Vector3 object_pos;

    public int pointer_pos_index = 0;
    //  public List<Vector3>[] cursors_pos;
    public List<Vector3> cursors_pos = new List<Vector3>();
    public List<string> pointer_name = new List<string>();
    public int cursors_pos_index=0;
    #endregion

    #region KeyCodes
    public KeyCode fireMissileL;
    public KeyCode fireMissileR;
    //pause/continue button
    public KeyCode clickSpace;
    //ESC- quit button
    public KeyCode exitClick;
    #endregion

    #region Transforms
    public Transform missileObj;
    public Transform missileObjR;
    public Transform lockOnTarget;
    public Transform countText;
    public Transform scoreText;
    public Transform enemyObj;
    public Transform enemyObjBig;
    #endregion

    #region GameObjects
    //after game text
    public GameObject scoreBig;
    public GameObject scoreEnd;
    public GameObject clickSpaceToContinue;
    public GameObject highScore;
    public GameObject highScoreNumber;
    public GameObject staticRocketL;
    public GameObject staticRocketR;
    #endregion

    #region Floats/Ints
    public int randX;
    public int rockets =100;
    public int score = 0;
    public int lives = 7;
    public float spawnSmallCometTimer;
    public float spawnBigCometTimer;
    public float rotationSpeed = 0.1f;
    public float h;
    public float v;
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    //rotacja rakiety
    // private float angle;
    #endregion

    #region Start
    // Start is called before the first frame update
    void Start()
    {
        // PlayerPrefs.SetInt("HighScore", 0);
        Cursor.SetCursor(defaultTexture, hotSpot, curMode);
        //objPosition = Vector3.Lerp(-5.76f, -4.2f, 0);
        staticRocketL.SetActive(true);
        staticRocketR.SetActive(true);


        scoreBig.GetComponent<TextMesh>().text = null;
        scoreEnd.GetComponent<TextMesh>().text = null;
        clickSpaceToContinue.GetComponent<TextMesh>().text = null;

        highScore.GetComponent<TextMesh>().text = null;
        highScoreNumber.GetComponent<TextMesh>().text = null;

        //  PlayerPrefs.SetInt("HighScore", 0);
    }
    #endregion

    #region Update
    // Update is called once per frame

    void Update()
    {

        mousePosition = new Vector3(Input.mousePosition.x + 16, Input.mousePosition.y - 16, Input.mousePosition.z - transform.position.z);
        objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        if (lives > 0)
        {
            //Launching rockets
            if (Input.GetKeyDown(fireMissileL) == true && rockets > 0 && Time.timeScale == 1)
            {
               
                Transform pointerNew = Instantiate(lockOnTarget, objPosition, lockOnTarget.rotation) as Transform;
                pointerNew.gameObject.GetComponent<control>().ID = cursors_pos_index;
                pointer_name.Add(lockOnTarget.name+cursors_pos_index);
                //Debug.Log("pointer1: " + pointer_pos[0]);
                //Debug.Log("pointer2: " + pointer_pos[0].position);
                cursors_pos.Add(objPosition);
                //Debug.Log(cursors_pos[cursors_pos_index]);

                //yield return new WaitForEndOfFrame();
                Transform missileNew = Instantiate(missileObj, new Vector2(-5.76f, -4.2f), missileObj.rotation);
                missileNew.gameObject.GetComponent<missileControl>().ID = cursors_pos_index;
                rockets--;
                rocketLive = true;

                staticRocketL.SetActive(false);


            }

            if (Input.GetKeyDown(fireMissileR) == true && rockets > 0 && Time.timeScale == 1)
            {
                Instantiate(lockOnTarget, objPosition, lockOnTarget.rotation);

                pointer_name.Add(lockOnTarget.name + cursors_pos_index);
                cursors_pos.Add(objPosition);

                Instantiate(missileObjR, new Vector2(6.4f, -4.2f), missileObjR.rotation);

                rockets--;
                rocketLive = true;
                staticRocketR.SetActive(false);

            }

            //spacebar functions
            if (Input.GetKeyDown(clickSpace) == true)
            {
                if (Time.timeScale == 1)
                {
                    Time.timeScale = 0;
                }
                else Time.timeScale = 1;
            }


        }
        else
        {

            scoreEnd.GetComponent<TextMesh>().text = "YOUR SCORE IS:";
            scoreBig.GetComponent<TextMesh>().text = score.ToString();
            clickSpaceToContinue.GetComponent<TextMesh>().text = "Click space to continue";

            highScore.GetComponent<TextMesh>().text = "HIGHSCORE:";

            int highsScore1 = PlayerPrefs.GetInt("HighScore");
            if (score > highsScore1)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
            highScoreNumber.GetComponent<TextMesh>().text = PlayerPrefs.GetInt("HighScore").ToString();


            if (Input.GetKeyDown(clickSpace) == true)
            {
                //0 - menu
                //1 - mainScene
                SceneManager.LoadScene(0);
            }
        }


        enemySpawn();
        countText.GetComponent<TextMesh>().text = rockets.ToString();
        scoreText.GetComponent<TextMesh>().text = score.ToString();



        if (Input.GetKeyDown(exitClick) == true)
        {
            SceneManager.LoadScene(0);
        }
    }
    #endregion

    #region Spawn Enemy
    void enemySpawn()
    {
        spawnSmallCometTimer += Time.deltaTime;
        spawnBigCometTimer += Time.deltaTime;

        randX = Random.Range(-8, 8);



        //small comet spawner
        if (spawnSmallCometTimer > 1f)
        {
            spawnSmallCometTimer = 0;
            Instantiate(enemyObj, new Vector2(randX, 6f), enemyObj.rotation);

            // rocketLive = rocketLiveFun();
        }


        //big comet spawner
        if (spawnBigCometTimer > 3f)
        {
            spawnBigCometTimer = 0;
            Instantiate(enemyObjBig, new Vector2(randX, 6f), enemyObjBig.rotation);



        }

    }
    #endregion
}
