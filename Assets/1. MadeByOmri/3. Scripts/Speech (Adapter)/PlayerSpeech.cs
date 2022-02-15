using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerSpeech : MonoBehaviour, ISpeech //User 2
{
    private void Start()
    {
        Debug.Log(TellAJoke());
    }

    public string TellAJoke()
    {
        JokesPlugin jokesPlugin = new JokesPlugin();
        IJokes Jokes = new JokeAdapter(jokesPlugin);
        return Jokes.TellAJoke();
    }

    public string Laugh()
    {
        return "Ha! So Funny Mate!";
    }

    public string SayHi()
    {
        return "Hello there";
    }
}
