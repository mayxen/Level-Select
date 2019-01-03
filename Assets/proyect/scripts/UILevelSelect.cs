using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UILevelSelect : MonoBehaviour
{
    [SerializeField] LevelController levelController;
    [SerializeField] UILevel level;
    [SerializeField] LevelPopup levelPopUp;
    Transform LevelSelectPanel;
    List<UILevel> levelList = new List<UILevel>();
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
        int pageSize = 8;

        List<UILevel> pageList = levelList.Skip(lvl*pageSize).Take(pageSize).ToList();

        for (int i = 0; i < pageList.Count;i++)
        {
            Level level = levelController.levels[(lvl * pageSize) + i];
            UILevel instance = Instantiate(pageList[i]);
            instance.SetStars(level.Stars);
            instance.transform.SetParent(LevelSelectPanel);
            instance.GetComponent<Button>().onClick.AddListener(() => SelectLevel(level));
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
            levelPopUp.gameObject.SetActive(true);
            levelPopUp.SetText("<b>Level "+ level.ID+ " is currently locked </b> \nComplete level" +(level.ID-1)+" to unlock it!");
            Debug.Log("Level Locked");
        }
        else
        {
            Debug.Log("Go to level: "+level.ID);
            levelController.StartLevel(level.ID.ToString());
        }
    }
}
