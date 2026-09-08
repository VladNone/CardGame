using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI PlayerText;
    public TextMeshProUGUI TutorialText;
    public List<GameObject> Cards;
    public List<GameObject> MoveCard;
    public List<GameObject> Points;
    public List<GameObject> Puppets;
    public float MultMusic = 1f;

    private PlayerMovement player;
    private Deck deck;
    private Hand hand;
    private bool once = false;
    private float playerSpeed = 6f;
    private CoreGame game;
    private AudioSource music;
    private bool startMusic;
    private bool endTutorial;
    private void Start()
    {
        music = GetComponent<AudioSource>();
        player = ServiceLocator.GetService<PlayerMovement>();
        playerSpeed = player.Speed;
        player.Speed = 0f;
        deck = ServiceLocator.GetService<Deck>();
        hand = ServiceLocator.GetService<Hand>();
        ServiceLocator.GetService<ArenaStats>().AddEnemy(gameObject);
        game = ServiceLocator.GetService<CoreGame>();
    }
    public void StartTutorial()
    {
        TutorialText.gameObject.SetActive(false);
        PlayerText.gameObject.SetActive(true);
        PlayerText.text = "This is your character";

        music.Play();
        startMusic = true;

        Invoke("SecondStep", 4f);
    }
    public void SecondStep()
    {
        player.Speed = playerSpeed;
        PlayerText.text = "He moves automatic";

        Invoke("ThirdStep", 4f);
    }

    public void ThirdStep()
    {
        deck.Cards = MoveCard;
        
        PlayerText.gameObject.SetActive(false);
        TutorialText.gameObject.SetActive(true);
        TutorialText.text = "Bouncing off a wall gives cards from the deck to your hand";

        Invoke("MovementTest", 5f);
    }

    public void MovementTest()
    {
        TutorialText.text = "Get to these points using these Cards";

        for (int i = 0; i < this.Points.Count; i++)
        {
            if (this.Points[i] == null)
            {
                this.Points.Remove(this.Points[i]);
                i--;
                continue;
            }
            this.Points[i].SetActive(true);
        }
    }
    public void CheckPoints()
    {
        int points = 0;
        for (int i = 0; i < this.Points.Count; i++)
        {
            if (this.Points[i] == null)
            {
                this.Points.Remove(this.Points[i]);
                i--;
                continue;
            }
            points++;
        }
        if (points <= 1 && !once)
        {
            Invoke("ShotTest", 2f);
            once = true;
        }
        CheckPuppets();
    }

    public void ShotTest()
    {
        TutorialText.text = "Destroy them with battle cards";

        hand.KillAllCards();
        deck.Cards = Cards;
        deck.AddToHand();
        deck.AddToHand();
        deck.AddToHand();
        deck.AddToHand();

        for (int i = 0; i < this.Puppets.Count; i++)
        {
            if (this.Puppets[i] == null)
            {
                this.Puppets.Remove(this.Puppets[i]);
                i--;
                continue;
            }
            this.Puppets[i].SetActive(true);
        }
    }

    public void CheckPuppets()
    {
        int points = 0;
        for (int i = 0; i < this.Puppets.Count; i++)
        {
            if (this.Puppets[i] == null)
            {
                this.Puppets.Remove(this.Puppets[i]);
                i--;
                continue;
            }
            points++;
        }
        if (points <= 1)
        {
            Invoke("FinalBattle", 2f);
        }
    }
    public void FinalBattle()
    {
        TutorialText.text = "Get ready for the enemy, he has contact damage.";


        Invoke("SkipTutorial", 4f);
    }
    public void SkipTutorial()
    {
        TutorialText.gameObject.SetActive(false);
        PlayerText.gameObject.SetActive(false);

        hand.KillAllCards();
        deck.Cards = Cards;

        player.Speed = playerSpeed;
        player.TakeDamage = true;
        endTutorial = true;
        startMusic = false;
    }
    private void Update()
    {
        if (startMusic && music.volume < 1f)
        {
            music.volume += Time.deltaTime * MultMusic;
        }

        if (endTutorial)
        {
            music.volume -= Time.deltaTime * MultMusic;
            if (music.volume <= 0f)
            {
                game.SwitchGameplay();
                Destroy(gameObject);
            }
        }
    }
}
