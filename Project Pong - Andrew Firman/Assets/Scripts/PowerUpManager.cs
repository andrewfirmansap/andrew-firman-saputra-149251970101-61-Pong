using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public int maxPowerUpAmount;
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;

    public List<GameObject> powerUpTemplateList;
    private List<GameObject> powerUpList;
    private bool lastPaddleP1;

    public Transform paddle1;
    public Transform paddle2;
    public GameObject paddle1Obj;
    public GameObject paddle2Obj;



    public Transform spawnArea;
    private float timer;
    private float deleteTimer;
    public int spawnInterval;
    public int deleteInterval;

    private void Start()
    {
        powerUpList = new List<GameObject>();
        lastPaddleP1 = true;

        

    }
    private void Update()
    {
        timer += Time.deltaTime;
        deleteTimer += Time.deltaTime;
        if(timer> spawnInterval)
        {
            GenerateRandomPowerUp();
            timer -= spawnInterval;
        }
        if (deleteTimer > deleteInterval)
        {

            deleteTimer -= deleteInterval;
            RemovePowerUp(powerUpList[0]);
        }
        

    }
    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }
    public void GenerateRandomPowerUp(Vector2 position)
    {
        if (powerUpList.Count >=maxPowerUpAmount)
        {

            return;
        }
        if(position.x < powerUpAreaMin.x || 
           position.x > powerUpAreaMax.x ||
           position.y < powerUpAreaMin.y ||
           position.y > powerUpAreaMax.y
             )
        {
            return;
        }
        int randomIndex = Random.Range(0, powerUpTemplateList.Count);
        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex], new Vector3(position.x,position.y,powerUpTemplateList[randomIndex].transform.position.z), Quaternion.identity, spawnArea);
        powerUp.SetActive(true);
        powerUpList.Add(powerUp);
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);

    }
    public void RemoveAllPowerUp()
    {
        while (powerUpList.Count>0)
        {
            RemovePowerUp(powerUpList[0]);
        }
    }
    public void PerpanjangPaddle()
    {   
        if (lastPaddleP1)
        {
            paddle1Obj.GetComponent<PaddleController>().ActivePUPanjangUp();

        }
        else
        {
            paddle2Obj.GetComponent<PaddleController_P2>().ActivePUPanjangUp();
        }
    }
    public void SpeedUpPaddle()
    {
        Debug.Log("Speedup!");
        if (lastPaddleP1)
        {
            paddle1Obj.GetComponent<PaddleController>().ActivePUSpeedUp();

        }
        else
        {
            paddle2Obj.GetComponent<PaddleController_P2>().ActivePUSpeedUp();
        }
    }
    public void PaddleP2Hit()
    {
        lastPaddleP1 = false;
    }
    public void PaddleP1Hit()
    {
        lastPaddleP1 = true;
    }
}
