using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    //[SerializeField] private string selectableTag = "Interactive";
   // [SerializeField] private Material highlightMaterial;
   // [SerializeField] private Material defaultMaterial;

    private Transform _selection;

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;

            if (selection.CompareTag("Interactive"))
            {
                Debug.Log("Dziala");
                _selection = selection;
            }
        }
    }
}