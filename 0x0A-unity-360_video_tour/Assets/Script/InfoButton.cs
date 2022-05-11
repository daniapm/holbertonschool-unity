using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButton : MonoBehaviour
{
    public void ShowOrHide() => gameObject.SetActive(!gameObject.activeInHierarchy);
}
