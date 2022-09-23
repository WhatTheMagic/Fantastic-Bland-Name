using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;
    [SerializeField] private PlayerTurn playerOne;
    [SerializeField] private PlayerTurn playerTwo;
    [SerializeField] private float maxTimePerTurn;
    [SerializeField] private float timeBetweenTurns;
    [SerializeField] private Image clock;
    [SerializeField] private TextMeshProUGUI seconds;

    [SerializeField] private GameObject cam1;
    [SerializeField] private GameObject cam2;

    private int currentPlayerIndex;
    private bool waitingForNextTurn;
    private float turnDelay;

    private float currentTurnTime;

    private void Awake()
    {
        cam1.SetActive(true);
        if (instance == null)
        {
            instance = this;
            currentPlayerIndex = 1;
            playerOne.SetPlayerTurn(1);
            playerTwo.SetPlayerTurn(2);
            cam1.SetActive(true);
            cam2.SetActive(false);
        }
    }

    private void Update()
    {
        if (gameObject != null)
        {
            if (waitingForNextTurn)
            {
                turnDelay += Time.deltaTime;
                if (turnDelay >= timeBetweenTurns)
                {
                    turnDelay = 0;
                    waitingForNextTurn = false;
                    ChangeTurn();
                }
            }
            if (turnDelay <= 0)
            {
                currentTurnTime += Time.deltaTime;

                if (currentTurnTime >= maxTimePerTurn)
                {
                    ChangeTurn();
                    ResetTimers();
                }
                UpdateTimeVisuals();
            }
            else
            {
                turnDelay -= Time.deltaTime;
            }
        }
    }

    public bool PlayerCanPlay()
    {
        return turnDelay <= 0;
    }

    public bool IsItPlayerTurn(int index)
    {
        if (waitingForNextTurn)
        {
            return false;
        }

        return index == currentPlayerIndex;
    }

    public static TurnManager GetInstance()
    {
        return instance;
    }

    public void TriggerChangeTurn()
    {
        waitingForNextTurn = true;
    }

    private void ChangeTurn()
    {
        if (gameObject != null)
		{
            if (currentPlayerIndex == 1)
            {
                currentPlayerIndex = 2;
                cam1.SetActive(false);
                cam2.SetActive(true);
            }
            else if (currentPlayerIndex == 2)
            {
                currentPlayerIndex = 1;
                cam1.SetActive(true);
                cam2.SetActive(false);
            }

            ResetTimers();
            UpdateTimeVisuals();
        }
    }

    private void ResetTimers()
    {
        currentTurnTime = 0;
        turnDelay = timeBetweenTurns;
    }

    private void UpdateTimeVisuals()
    {
        clock.fillAmount = 1 - (currentTurnTime / maxTimePerTurn);
        seconds.text = Mathf.RoundToInt(maxTimePerTurn - currentTurnTime).ToString();
    }
}
