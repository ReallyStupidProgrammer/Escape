using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSetting : MonoBehaviour {

    public Dropdown dropdown;

    private void Start() {
        dropdown.value = Language.languageIndex;
    }

    public void changeLanguage() {
        Language.languageIndex = dropdown.value;
        Language.updateLanguage();
    }
}