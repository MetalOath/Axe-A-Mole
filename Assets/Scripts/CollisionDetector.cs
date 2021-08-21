using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CollisionDetector : MonoBehaviour
{
    public int hitScore = 0;
    public int missScore = 0;
    Vector3 initPosition;
    Vector3 initVelocity;
    Quaternion initRotation;
    public GameObject endGameUI;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("HitScore").GetComponent<TextMeshProUGUI>().text = "Hits = " + hitScore + "/8";
        GameObject.Find("MissScore").GetComponent<TextMeshProUGUI>().text = "Miss = " + missScore + "/10";
        initPosition = gameObject.transform.position;
        initRotation = gameObject.transform.rotation;
        initVelocity = gameObject.GetComponent<Rigidbody>().velocity;
    }
    
    // Update is called once per frame
    void Update()
    {
        ScoreUpdater();
        GameStateUpdater();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Active_Mole")
        {
            collision.gameObject.GetComponent<AudioSource>().Play();
            transform.GetChild(0).GetComponent<AudioSource>().Play();
            collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
            collision.gameObject.GetComponent<MeshCollider>().enabled = false;
            hitScore++;
        }
        else if (collision.gameObject.tag == "Inactive_Mole")
        {
            transform.GetChild(1).GetComponent<AudioSource>().Play();
            missScore++;
        }
        else
        {
            transform.GetChild(2).GetComponent<AudioSource>().Play();
        }
    }

    private void ScoreUpdater()
    {
        GameObject.Find("HitScore").GetComponent<TextMeshProUGUI>().text = "Hits = " + hitScore + "/8";
        GameObject.Find("MissScore").GetComponent<TextMeshProUGUI>().text = "Miss = " + missScore + "/10";
    }

    private void GameStateUpdater()
    {
        switch (hitScore)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                WinRoutine();
                hitScore = 0;
                missScore = 0;
                break;
        }
        switch (missScore)
        {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
                break;
            case 10:
                LoseRoutine();
                hitScore = 0;
                missScore = 0;
                break;
        }
        if (missScore > 10)
        {
            LoseRoutine();
            hitScore = 0;
            missScore = 0;
        }
    }

    private void WinRoutine()
    {
        GameObject.Find("Title").GetComponent<TextMeshProUGUI>().text = "YOU WIN! Play Again?";
        GameObject.Find("WinSound").GetComponent<AudioSource>().Play();
        GameObject.Find("Ambience").GetComponent<AudioSource>().Stop();
        GameObject.Find("HitScore").SetActive(false);
        GameObject.Find("MissScore").SetActive(false);
        GameObject.Find("Interactive").SetActive(false);
        GameObject.Find("Axe").GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("Axe").GetComponent<MeshCollider>().enabled = false;
        endGameUI.SetActive(true);
    }
    private void LoseRoutine()
    {
        GameObject.Find("Title").GetComponent<TextMeshProUGUI>().text = "GAME OVER Try Again?";
        GameObject.Find("GameOver").GetComponent<AudioSource>().Play();
        GameObject.Find("Ambience").GetComponent<AudioSource>().Stop();
        GameObject.Find("HitScore").SetActive(false);
        GameObject.Find("MissScore").SetActive(false);
        GameObject.Find("Interactive").SetActive(false);
        GameObject.Find("Axe").GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("Axe").GetComponent<MeshCollider>().enabled = false;
        endGameUI.SetActive(true);
    }
    public void ResetPostion()
    {
        gameObject.transform.position = initPosition;
        gameObject.transform.rotation = initRotation;
        gameObject.GetComponent<Rigidbody>().velocity = initVelocity;
    }
    public void Replay()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
