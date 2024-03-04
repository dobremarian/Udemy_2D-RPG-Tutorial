using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleChar : MonoBehaviour
{
    public bool isPlayer;
    public string[] movesAvalible;

    public string charName;
    public int currentHP, maxHP, currentMP, maxMP, strength, defence, wpnPwr, armrPwr;
    public bool hasDied;

    public SpriteRenderer theSprite;
    public Sprite deadSprite, aliveSprite;

    private bool shouldFade;
    public float FadeSpeed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldFade)
        {
            theSprite.color = new Color(Mathf.MoveTowards(theSprite.color.r, 1f, FadeSpeed * Time.deltaTime), Mathf.MoveTowards(theSprite.color.g, 0f, FadeSpeed * Time.deltaTime), Mathf.MoveTowards(theSprite.color.b, 0f, FadeSpeed * Time.deltaTime), Mathf.MoveTowards(theSprite.color.a, 0, FadeSpeed * Time.deltaTime));
            if(theSprite.color.a == 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void EnemyFade()
    {
        shouldFade = true;
    }
}