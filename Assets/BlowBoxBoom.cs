using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowBoxBoom : MonoBehaviour
{
    public GameObject player;
    public Animator BoxAnimator;

    // Update is called once per frame
    void Update()
    {
       Vector2 playerPosition  = player.transform.position;
       playerPosition.x += 1;
       transform.position = playerPosition;
    }
    public void hitIsDone()
    {
        BoxAnimator.SetBool("isBlow", false);
    }
    public void hit()
    {
        BoxAnimator.SetBool("isBlow", true);
    }
}
