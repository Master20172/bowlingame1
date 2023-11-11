using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private player player;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private Pin[] pins;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private Camera mainCamera, closeUpCamera;

    private bool isGamePlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        isGamePlaying = true;

        //Get the first throw
        player.StartThrow();

        mainCamera.enabled = true;
        closeUpCamera.enabled = false;
    }

    public void SetNextThrow()
    {
        Invoke("NextThrow", 3.0f);
    }

    void NextThrow()
    {
        int fallenPins = CalculateFallenPins();
        scoreManager.SetFrameScore(fallenPins);

        if(scoreManager.currentFrame == 0)
        {
            uiManager.ShowGameOver(scoreManager.CalculateTotalScore());
            //Debug.Log($"Game over. Your total score is {scoreManager.CalculateTotalScore()}");
            return;
        }

        int frameTotal = 0;
        for(int i =0; i < scoreManager.currentFrame -1; i++)
        {
            frameTotal += scoreManager.GetFrameScore()[i];
            uiManager.SetFrameTotal(i, frameTotal);
        }

        SwitchCamera();
        player.StartThrow();
    }

    public void ResetAllPins()
    {
        foreach(Pin p in pins)
        {
            p.ResetPin();
        }
    }

    public int CalculateFallenPins()
    {
        int count = 0;

        foreach(Pin pin in pins)
        {
            if(pin.isFallen && pin.gameObject.activeSelf)
            {
                count++;
                pin.gameObject.SetActive(false);
            }
        }

        Debug.Log($"Total fallen pins = {count}");
        return count;
    }

    public void SwitchCamera()
    {
        mainCamera.enabled = !mainCamera.enabled;
        closeUpCamera.enabled = !closeUpCamera.enabled;
        //This
    }
}
