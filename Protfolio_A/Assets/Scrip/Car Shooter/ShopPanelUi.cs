using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Car_Shooter;

namespace Car_Shooter {
    public class ShopPanelUi : MonoBehaviour {

        public static ShopPanelUi instance;
        [SerializeField] Button exitButton;
        [SerializeField] RectTransform itemPanel;

        List<ItemPrefebs> ListItemPrefebs = new List<ItemPrefebs>();

        void Awake()
        {
            instance = this;
        }
        void Start() {
            exitButton.onClick.AddListener(ExitButtonOnClick);
            gameObject.SetActive(false);

            GameObject itemRes = Resources.Load<GameObject>("itemprefebs");

            Weapon data = Resources.Load<Weapon>("MP1");
            GameObject tempItem = Instantiate(itemRes);
            tempItem.transform.SetParent(itemPanel);
            ItemPrefebs tempData = tempItem.GetComponent<ItemPrefebs>();
            tempData.SetData("MP1", data);
            ListItemPrefebs.Add(tempData);

            data = Resources.Load<Weapon>("MP2");
            tempItem = Instantiate(itemRes);
            tempItem.transform.SetParent(itemPanel);
            tempData = tempItem.GetComponent<ItemPrefebs>();
            tempData.SetData("MP2", data);
            ListItemPrefebs.Add(tempData);

            data = Resources.Load<Weapon>("MP3");
            tempItem = Instantiate(itemRes);
            tempItem.transform.SetParent(itemPanel);
            tempData = tempItem.GetComponent<ItemPrefebs>();
            tempData.SetData("MP3", data);
            ListItemPrefebs.Add(tempData);

        }
        void ExitButtonOnClick()
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }

        public void SetupShop(PlayerController pc)
        {
            for(int i = 0; i < ListItemPrefebs.Count; ++i)
            {
                ListItemPrefebs[i].SetOnClick(pc);
            }
        }
       
    }
}
