﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text[] buttonList;
	public GameObject gameOverPanel;
	public Text gameOverText;
	private string playerSide;
	private int moveCount;
	public GameObject restartButton;

	public void SetGameControllerReferenceOnButtons () {
		for (int i = 0; i < buttonList.Length; i++) {
			buttonList[i].GetComponentInParent< GridSpace>().SetGameControllerReference(this);
		}
	}

	void Awake ()
	{
		gameOverPanel.SetActive (false);
		restartButton.SetActive (false);
		SetGameControllerReferenceOnButtons();
		playerSide = "X";
		moveCount = 0;
	}
		
	public string GetPlayerSide ()
	{
		return playerSide;
	}

	public void EndTurn ()
	{
		moveCount++;

		if (buttonList [0].text == playerSide && buttonList [1].text == playerSide && buttonList [2].text == playerSide)
		{
			GameOver(playerSide);
			return;
		}

		if (buttonList [3].text == playerSide && buttonList [4].text == playerSide && buttonList [5].text == playerSide)
		{
			GameOver(playerSide);
			return;
		}

		if (buttonList [6].text == playerSide && buttonList [7].text == playerSide && buttonList [8].text == playerSide)
		{
			GameOver(playerSide);
			return;
		}

		if (buttonList [0].text == playerSide && buttonList [3].text == playerSide && buttonList [6].text == playerSide)
		{
			GameOver(playerSide);
			return;
		}

		if (buttonList [1].text == playerSide && buttonList [4].text == playerSide && buttonList [7].text == playerSide)
		{
			GameOver(playerSide);
			return;
		}

		if (buttonList [2].text == playerSide && buttonList [5].text == playerSide && buttonList [8].text == playerSide)
		{
			GameOver(playerSide);
			return;
		}

		if (buttonList [0].text == playerSide && buttonList [4].text == playerSide && buttonList [8].text == playerSide)
		{
			GameOver(playerSide);
			return;
		}

		if (buttonList [2].text == playerSide && buttonList [4].text == playerSide && buttonList [6].text == playerSide)
		{
			GameOver(playerSide);
			return;
		}

		if (moveCount >= 9) 
		{
			GameOver("draw");
		}

		ChangeSides ();
	}

	void ChangeSides() 
	{
		playerSide = playerSide == "X" ? "O" : "X";
	}

	void SetGameOverText(string value)
	{
		gameOverPanel.SetActive (true);
		gameOverText.text = value;
	}

	void SetBoardInteractable (bool toggle)
	{
		for (int i = 0; i < buttonList.Length; i++) 
		{
			buttonList[i].GetComponentInParent<Button>().interactable = toggle;
		}
	}

	public void RestartGame () 
	{
		playerSide = "X";
		moveCount = 0;
		gameOverPanel.SetActive (false);

		SetBoardInteractable (true);
		for (int i = 0; i < buttonList.Length; i++) 
		{
			buttonList[i].text = "";
		}

		restartButton.SetActive (false);
	}

	void GameOver(string winningPlayer)
	{
		SetBoardInteractable (false);
		if (winningPlayer == "draw") {
			SetGameOverText ("It's a draw!");
		} else {
			SetGameOverText (playerSide + " wins!");
		}
		restartButton.SetActive (true);
	}

}
