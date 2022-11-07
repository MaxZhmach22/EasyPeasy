#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


namespace EasyPeasy
{
    public class LetterUtils : MonoBehaviour
    {
        [field: Foldout("Setttings")] [field: SerializeField] public List<Button> Buttons { get; private set; }

        private void Awake()
        {
            if(Buttons.Count == 0) Buttons = GetComponentsInChildren<Button>().ToList();
        }

        [Button("Select All Letters")]
        private void SelectAllLetters()
        {
            Selection.objects = GetComponentsInChildren<Button>().Select(x => x.gameObject).ToArray();
        }
        
        [Button("Select All TMP")]
        private void SelectAllTMP()
        {
            Selection.objects = GetComponentsInChildren<TMP_Text>().Select(x => x.gameObject).ToArray();
        }
        
        [Button("Change Text by Parent")]
        private void ChangeText()
        {
            if (Buttons.Count == 0) Buttons = GetComponentsInChildren<Button>().ToList();

            foreach (var btn in Buttons)
            {
                btn.GetComponentInChildren<TMP_Text>().text = btn.name;
            }
        }
    }
}
#endif
