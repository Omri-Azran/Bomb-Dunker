using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSpeech : MonoBehaviour, ISpeech //User 1
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(TellAJoke());
    }

    public string Laugh()
    {
        return "HA! HA! HA!";
    }

    public string SayHi()
    {
        return "Hello World!";
    }

    public string TellAJoke()
    {
        JokesPlugin jokesPlugin = new JokesPlugin();
        IJokes Jokes = new JokeAdapter(jokesPlugin);
        return Jokes.TellAJoke();
    }

}
