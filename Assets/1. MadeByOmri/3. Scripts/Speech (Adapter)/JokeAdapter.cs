using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokeAdapter : IJokes
{
    private readonly JokesPlugin _jokesPlugin;
    public JokeAdapter (JokesPlugin jokesPlugin)
    {
        this._jokesPlugin = jokesPlugin;
    }

    public string TellAJoke()
    {
        List<string> jokes = new List<string>();
        jokes.Add(_jokesPlugin.TellJokeOne());
        jokes.Add(_jokesPlugin.TellJokeTwo());
        jokes.Add(_jokesPlugin.TellJokeThree());
        return jokes[Random.Range(0, jokes.Count)];
    }

}
