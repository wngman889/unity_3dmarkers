using UnityEngine;
public class SelectionManager : MonoBehaviour
{
    public Selectable currentSelection { get; set; }
    private SpeechInput speechInput;

    void Awake()
    {
        speechInput = FindObjectOfType<SpeechInput>();
    }
    public void Select(string objName)
    {
        GameObject obj;
        if ((obj = GameObject.Find(objName)) != null)
        {
            currentSelection = obj.GetComponent<Selectable>();
            if (currentSelection == null)
            {
                Debug.Log(objName + " is not selectable");
            }
            else
            {
                Camera.main.transform.position = currentSelection.viewPos;
                Camera.main.transform.LookAt(currentSelection.transform.position);
                speechInput.ChangeHandler("play", currentSelection.GetComponent<Playable>().Play);
                speechInput.ChangeHandler("stop", currentSelection.GetComponent<Playable>().Stop);
                Debug.Log("selected " + objName);
            }
        }
        else
        {
            Debug.Log("Object " + objName + " not found");
        }
    }
}
