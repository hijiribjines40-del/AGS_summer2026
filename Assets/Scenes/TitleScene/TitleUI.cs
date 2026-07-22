using UnityEngine;
using UnityEngine.EventSystems;

public class TitleUI : MonoBehaviour
{
    [SerializeField] private GameObject firstButton;

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstButton);
    }
}
