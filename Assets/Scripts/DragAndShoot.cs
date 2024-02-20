using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragAndShoot : MonoBehaviour
{
    public SpriteRenderer sr;
    public float power = 10f;
    public Rigidbody2D rb;
    private bool shotFired = false;
    public Vector2 minPower;
    public Vector2 maxPower;
    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;
    LineaTraiettoria tl;
    private bool isRestarting = false;
    private float lastTapTime = 0f;
    public float doubleTapThreshold = 0.5f; // Time threshold for double-tap in seconds
    [SerializeField] private AudioSource jumpSoundFX;
    [SerializeField] private AudioSource firstShotFX;
    [SerializeField] private AudioSource successFX;

    private void Start()
    {
        sr.sprite = GameManager.instance.getSkin();
        cam=Camera.main;
        tl = GetComponent<LineaTraiettoria>();

        if (GameManager.instance.IsGameplayLevel())
                {
                    GameManager.instance.livesText.gameObject.SetActive(true);
                    GameManager.instance.UpdateLivesUI();
                }
                else
                {
                    GameManager.instance.livesText.gameObject.SetActive(false); // Deactivate Lives UI in tutorial scene
                }
        GameManager.instance.firstTry = true;
    }
    private void Update()
    {
        if (!Pausemenu.gameIsPaused)
        {

            if (Input.GetMouseButtonDown(0) && !shotFired)
            {
                startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                startPoint.z = 15;
            }
            if (Input.GetMouseButton(0) && !shotFired)
            {
                Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                currentPoint.z = 15;
                tl.RenderLine(startPoint, currentPoint);
            }
            if (Input.GetMouseButtonUp(0) && !shotFired)
            {
                endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                endPoint.z = 15;
                force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
                rb.AddForce(force * power, ForceMode2D.Impulse);
                tl.EndLine();
                shotFired = true;
            }
            if (Input.GetMouseButtonDown(0) && shotFired) // Change to your input method (e.g., touch)
            {
                if (Time.time - lastTapTime < doubleTapThreshold)
                {
                    GameManager.instance.firstTry = false;
                    if (!isRestarting)
                    {
                        if (SceneManager.GetActiveScene().name == "Tutorial1" || SceneManager.GetActiveScene().name == "Tutorial2")
                        {
                            GameManager.instance.RestartLevel();
                        }
                        else
                        {
                            GameManager.instance.DecreaseLives();
                        }
                        isRestarting = true;
                    }
                }
                lastTapTime = Time.time;
            }
            if (shotFired && rb.velocity.magnitude <= 0.01f)
            {
                if (SceneManager.GetActiveScene().name == "Tutorial1" || SceneManager.GetActiveScene().name == "Tutorial2")
                {
                    GameManager.instance.RestartLevel();
                }
                else
                {
                    GameManager.instance.DecreaseLives();
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish")){
            if (GameManager.instance.firstTry)
            {
                firstShotFX.Play();
            }
            else
            {
                successFX.Play();
            }
            //suono vittoria/superamento livello in base a FirstTry
        }else
        {
            jumpSoundFX.Play();
        }
    }

    private bool IsGrounded()
    {
        // Raycast downward to check if the ball is grounded
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.1f))
        {
            GameManager.instance.firstTry = false;
            return true;
        }
        return false;
    }
}
