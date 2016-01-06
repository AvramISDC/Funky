using UnityEngine;
using System.Collections;

public class CriteriaButton : MonoBehaviour {

    public GameObject criteriaPanel;
    public GameObject restaurantsPanel;

	public void OnClick() {
        criteriaPanel.active = !criteriaPanel.active;
        restaurantsPanel.active = !restaurantsPanel.active;
    }
}
