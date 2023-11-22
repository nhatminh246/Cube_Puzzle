using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlayerStep
{
    KillEnemy,
    Gore,
    Stand,
    Move
}
public class PlayerController : MonoBehaviour
{
    PlayerStep playerStep;
    public StepManager stepManager;
    public SoundsManager sounds;

    public int speed = 300;
    bool isMoving = false;
    public bool isGetKey = false;
    public Transform checkDirection;
    public Vector3 directPlayerMove;

    [Header("Col")]
    public Transform leftPlayer_1;
    public Transform leftPlayer_2;
    public Transform rightPlayer_1;
    public Transform rightPlayer_2;
    public Transform forwardPlayer_1;
    public Transform forwardPlayer_2;
    public Transform backPlayer_1;
    public Transform backPlayer_2;

    [SerializeField] private GameObject goreRock;
    [SerializeField] private GameObject killEnemy;
    private Collider goreObject;

    public static PlayerController Instance;

    SpikeManager spikeManager;

    [Header("UI")]
    UIManager uIManager;
    Transform loseText;
    Transform loseMenu;
    Transform winText;
    Transform winMenu;

    private void Awake()
    {
        spikeManager = FindObjectOfType<SpikeManager>();
        Instance = this;
        stepManager = FindObjectOfType<StepManager>().GetComponent<StepManager>();
        uIManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame

    public void MovePlayerLeft()
    {
        if (isMoving) return;
        CheckCollider(leftPlayer_1, leftPlayer_2);
        PlayerAction(Vector3.left);
    }
    public void MovePlayerRight()
    {
        if (isMoving) return;
        CheckCollider(rightPlayer_1, rightPlayer_2);
        PlayerAction(Vector3.right);
    }
    public void MovePlayerUp()
    {
        if (isMoving) return;
        CheckCollider(forwardPlayer_1, forwardPlayer_2);
        PlayerAction(Vector3.forward);
    }
    public void MovePlayerDown()
    {
        if (isMoving) return;
        CheckCollider(backPlayer_1, backPlayer_2);
        PlayerAction(Vector3.back);
    }

    private void PlayerAction(Vector3 directRoll)
    {

        stepManager.StepMinus();
        sounds.PlayOneShotAudioButtonClick();
        if(spikeManager != null) spikeManager.SpikeMove();
        switch (playerStep)
        {
            case PlayerStep.Move:
                StartCoroutine(Roll(directRoll));
                break;
            case PlayerStep.Stand:
                Camera.main.GetComponent<CameraShake>().Shake();
                break;
            case PlayerStep.Gore:
                StartCoroutine(Gore(directRoll));
                MoveObstacle(goreObject,directRoll);
                Destroy(Instantiate(goreRock, transform.position, Quaternion.identity), 1f);

                break;
            case PlayerStep.KillEnemy:
                Camera.main.GetComponent<CameraShake>().Shake();
                StartCoroutine(Gore(directRoll));
                Destroy(Instantiate(killEnemy, transform.position, Quaternion.identity), 1f);
                Destroy(goreObject.gameObject);
                break;

        }
                StartCoroutine(CheckWinStep());

        
    }
    private void CheckCollider(Transform check1, Transform check2)
    {
        Collider[] colliders1 = Physics.OverlapSphere(check1.position, 0.05f);
        Collider[] colliders2 = Physics.OverlapSphere(check2.position, 0.05f);
        if (colliders1.Length > 0)
        {
            if (colliders1[0].gameObject.tag == "Wall")
            {
                playerStep = PlayerStep.Stand;
            }
            else if (colliders1[0].gameObject.tag == "Chess") KeyCheck(colliders1[0]);
            else if (colliders1[0].gameObject.tag == "Spike" ) { 

                if(colliders1.Length > 1 && colliders2.Length == 0 )
                {
                    
                    playerStep = PlayerStep.Gore;
                    goreObject = colliders1[1];
                    sounds.PlayOneShotAudioStoneMove();
                }else if(colliders1.Length > 1 && colliders2.Length > 0)
                {
                    playerStep = PlayerStep.Stand;
                }
                else playerStep = PlayerStep.Move;
            }
            else if (colliders1[0].gameObject.tag == "Key")
            {

                if (colliders1.Length > 1 && colliders2.Length == 0)
                {

                    playerStep = PlayerStep.Gore;
                    goreObject = colliders1[1];
                    sounds.PlayOneShotAudioStoneMove();
                }
                else if (colliders1.Length > 1 && colliders2.Length > 0)
                {
                    playerStep = PlayerStep.Stand;
                }
                else
                {
                    playerStep = PlayerStep.Move;
                    GetKey();
                }
            }
            else if (colliders1[0].gameObject.tag == "Crystal") { playerStep = PlayerStep.Move; }
            else if (colliders1[0].gameObject.tag == "Key") { playerStep = PlayerStep.Move; GetKey(); }
            else if (colliders2.Length > 0)
            {
                if (colliders2[0].gameObject.tag == "Spike" || colliders2[0].gameObject.tag == "Key")
                {
                    playerStep = PlayerStep.Gore;
                    goreObject = colliders1[0];
                    sounds.PlayOneShotAudioStoneMove();
                }
                else if (colliders1[0].gameObject.tag == "Enemy")
                {
                    playerStep = PlayerStep.KillEnemy;
                    sounds.PlayOneShotAudioEnemyDie();
                    goreObject = colliders1[0];
                }
                else playerStep = PlayerStep.Stand;
            }
            else if (colliders2.Length == 0)
            {
                if (colliders1[0].gameObject.tag == "Wall")
                {
                    playerStep = PlayerStep.Stand;
                }
                else
                {
                    playerStep = PlayerStep.Gore;
                    goreObject = colliders1[0];
                    sounds.PlayOneShotAudioStoneMove();
                }
            }
        }
        if (colliders1.Length == 0)
        {
            playerStep = PlayerStep.Move;
        }

        //truong hop dac biet

    }
    private void KeyCheck(Collider col)
    {
        Camera.main.GetComponent<CameraShake>().Shake();
        if (isGetKey == false)
        {
            playerStep = PlayerStep.Stand;
        }
        else
        {
            playerStep =  PlayerStep.Move;
            sounds.PlayOneShotAudioOpenChess();
            Destroy(col.gameObject);
        }
    }
    private void ResetRotation()
    {
        transform.rotation = Quaternion.identity;
    }
    private void MoveObstacle(Collider obstacle, Vector3 direcMove)
    {
        LeanTween.move(obstacle.gameObject, obstacle.transform.position + direcMove, 0.3f);
    }

    

    private void GetKey()
    {
        isGetKey = true;
        GameObject key = GameObject.FindGameObjectWithTag("Key");
        Destroy(key);
        sounds.PlayOneShotAudioPickKey();

    }
    private IEnumerator CheckWinStep()
    {
        yield return new WaitForSeconds(0.15f);
        if(stepManager.numberStep <= 0 && GameObject.FindGameObjectWithTag("Crystal")!=null)
        {
            Debug.Log(GameObject.FindGameObjectWithTag("Crystal").name);
            Debug.Log("Lossse");
            uIManager.LoseGame();
            
        }

    }
    IEnumerator Roll(Vector3 direction)
    {
        isMoving = true;
        float remainingAngle = 90;
        Vector3 rotationCenter = transform.position + direction / 2 + Vector3.down / 2;
        Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction);
        while (remainingAngle > 0)
        {
            float rotationAngle = Mathf.Min(Time.deltaTime * speed, remainingAngle);
            transform.RotateAround(rotationCenter, rotationAxis, rotationAngle);
            remainingAngle -= rotationAngle;
            yield return null;
        }
        checkDirection.position = transform.position;

        isMoving = false;
    }
    IEnumerator Gore(Vector3 direction)
    {
        isMoving = true;
        ResetRotation();
        bool isComplete = false;

        //transform.position = new Vector3(transform.position.x, 0, transform.position.z );
        Vector3 originalPosition = transform.localPosition;

        LeanTween.moveLocal(transform.gameObject, transform.localPosition + direction / 2, 0.15f);
        yield return new WaitForSecondsRealtime(0.1f);
        LeanTween.moveLocal(transform.gameObject, originalPosition, 0.3f).setEaseInOutBack().setOnComplete(() =>
        {
            isComplete = true;
        }); ; ResetRotation();
        while (isComplete == false)
        {
            yield return null;
        }
        checkDirection.position = transform.position;
        isMoving = false;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Key")
        {
            isGetKey = true;

        }
    }
}
