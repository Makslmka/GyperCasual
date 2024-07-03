using TMPro;
using UnityEngine;

public class LanguageText : MonoBehaviour
{
    [SerializeField] private string _en;
    [SerializeField] private string _ru;
    [SerializeField] private string _tr;

    [SerializeField] private TextMeshProUGUI _textMeshPro;

    private Language _language;

    private void Awake()
    {
        EventBus.LanguageChanged += ChangeLanguage;
        _language = Language.instance;//EventBus.GetLanguage();
        //_textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        
        //ChangeLanguage();
    }

    private void ChangeLanguage()
    {
        if (_language.CurrentLanguage == "en")
        {
            _textMeshPro.text = _en;
        }
        else if (_language.CurrentLanguage == "ru")
        {
            _textMeshPro.text = _ru;
        }
        else if (_language.CurrentLanguage == "tr")
        {
            _textMeshPro.text = _tr;
        }
        else
        {
            _textMeshPro.text = _en;
        }
    }

    private void OnEnable()
    {
        
        ChangeLanguage();
    }

    private void OnDisable()
    {
        EventBus.LanguageChanged -= ChangeLanguage;
    }
}
