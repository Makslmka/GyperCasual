using System.Runtime.InteropServices;
using UnityEngine;

public class Language : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern string GetLang();

    public string CurrentLanguage;

    public static Language instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //CurrentLanguage = "ru";
    }

    private void Start()
    {
        CurrentLanguage = GetLang();
        EventBus.LanguageChange();
    }

    //public void ChangeLanguage()
    //{
    //    if (CurrentLanguage == "ru")
    //    {
    //        CurrentLanguage = "en";
    //    }
    //    else if (CurrentLanguage == "en")
    //    {
    //        CurrentLanguage = "tr";
    //    }
    //    else if (CurrentLanguage == "tr")
    //    {
    //        CurrentLanguage = "ru";
    //    }
    //    else
    //    {
    //        CurrentLanguage = "en";
    //    }

    //    EventBus.LanguageChange();
    //}

    private Language SendLanguage()
    {
        return gameObject.GetComponent<Language>();
    }

    private void OnEnable()
    {
        EventBus.RequestLanguage += SendLanguage;
    }

    private void OnDisable()
    {
        EventBus.RequestLanguage -= SendLanguage;
    }
}
