using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreBehaviour : MonoBehaviour
{
    public Text scoreText;
    // Start is called before the first frame update
  
    // Update is called once per frame
    void Update()
    {
        scoreText.text = GameManager.instance.score.ToString();
    }
}
