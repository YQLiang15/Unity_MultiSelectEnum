using System;
using UnityEngine;

namespace BitMask
{
    public class UIManager : MonoBehaviour
    {
        [Flags]
        public enum UILayer
        {
            Top = 1 << 0,
            Bottom = 1 << 1,
            Left = 1 << 2,
            Right = 1 << 3,
        }

        [Serializable]
        public struct UIGroup
        {
            public UILayer UILayer { get { return uiLayer; } }
            public GameObject UIObject { get { return uiObject; } }
            [SerializeField] private UILayer uiLayer;
            [SerializeField] private GameObject uiObject;
        }

        [SerializeField, BitMask] private UILayer selectedUI;
        [SerializeField] private UIGroup[] uiGroups;

        // Just for Demo
        private void Update()
        {
            foreach (var ui in uiGroups)
            {
                var value = (int)selectedUI & (int)ui.UILayer;
                ui.UIObject.SetActive(value != 0);
            }
        }
    }
}
