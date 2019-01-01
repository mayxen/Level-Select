using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public List<Level> levels;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        levels = new List<Level>
        {
            new Level(0,"Introduction",true, 2, false),
            new Level(1,"Getting Goin",false, 0, false),
            new Level(2,"Yee-haw",false, 0, false),
            new Level(3,"Yee-haw",false, 0, false),
            new Level(4,"Yee-haw",false, 0, false),
            new Level(5,"Yee-haw",false, 0, false),
            new Level(6,"Yee-haw",false, 0, false),
            new Level(7,"Yee-haw",false, 0, false),
            new Level(8,"Yee-haw",false, 0, false),
            new Level(9,"Yee-haw",false, 0, false),
            new Level(10,"Yee-haw",false, 0, false),
            new Level(11,"Yee-haw",false, 0, false),
        };
    }

    public void StartLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void CompleteLevel(string levelName, int stars)
    {
        levels.Find(i => i.LevelName == levelName).Complete(stars);
    }
}
