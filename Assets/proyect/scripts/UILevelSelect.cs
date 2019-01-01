using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UILevelSelect : MonoBehaviour
{
    [SerializeField] LevelController levelController;
    [SerializeField] UILevel level;
    [SerializeField] GameObject levelPopUp;
    Transform LevelSelectPanel;
    List<UILevel> levelList;
    int currentPage;
    // Start is called before the first frame update
    void Start()
    {
        LevelSelectPanel = transform;
        for (int i = 0; i < levelController.levels.Count;i++)
        {
            levelList.Add(level);
        }
        BuildLvlPage(0);
    }

    void BuildLvlPage(int lvl)
    {
        RemoveItemsFromPage();
        currentPage = lvl;
        int pageSize = 12;

        List<UILevel> pageList = levelList.Skip(lvl*pageSize).Take(pageSize).ToList();

        for (int i = 0; i < pageList.Count;i++)
        {
            Level level = levelController.levels[(lvl * pageSize) + i];
            UILevel instance = Instantiate(pageList[i]);
            instance.SetStars(level.Stars);
            instance.transform.SetParent(LevelSelectPanel);
            if (!level.Locked)
            {
                instance.lockImage.SetActive(false);
                instance.levelIDText.text = level.ID.ToString();

            }
            else
            {
                instance.levelIDText.text = "";
                instance.lockImage.SetActive(true);
            }
        }
    }

    void RemoveItemsFromPage()
    {
        for (int i= 0; i< LevelSelectPanel.childCount;i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    public void NextPage()
    {
        BuildLvlPage(currentPage+1);
    }

    public void PreviousPage()
    {
        BuildLvlPage(currentPage - 1);
    }

    void SelectLevel(Level level)
    {
        if (level.Locked)
        {
            levelPopUp.SetActive(true);
            Debug.Log("Level Locked");
        }
        else
        {
            Debug.Log("Go to level: "+level.ID);
            levelController.StartLevel(level.ID.ToString());
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
