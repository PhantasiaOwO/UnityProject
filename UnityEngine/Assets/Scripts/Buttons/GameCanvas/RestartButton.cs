﻿using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public void ClickRestart()
    {
        Debug.Log("Escape: Click restart");
        // Go to check point
        var player = GameObject.FindWithTag("Player");
        player.transform.position =player.GetComponent<PlayerStatus>().courseStart;
        player.GetComponent<Control>().InitializeAllBoolean();
        
        // Remove all spawn bricks
        var bricks = GameObject.FindGameObjectsWithTag("Spawn");
        foreach (var brick in bricks)
        {
            Destroy(brick);
        }

        // Reset button
        var buttons = GameObject.FindGameObjectsWithTag("BrickButton");
        foreach (var button in buttons)
        {
            button.GetComponent<BrickInteraction>().brickNumber = button.GetComponent<BrickInteraction>().brickInit;
            button.GetComponent<BrickInteraction>().remainTextBox.text =
                button.GetComponent<BrickInteraction>().brickNumber.ToString();
        }

        // Data count
        GameObject.FindWithTag("Player").GetComponent<PlayerStatus>().cntRestart++;
    }
}