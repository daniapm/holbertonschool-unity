using UnityEngine;

public class Url : MonoBehaviour
{
    public void ToGithub() {
        Application.OpenURL ("https://github.com/daniapm");
    }
    public void ToTwitter() {
        Application.OpenURL ("https://twitter.com/puertas_dany?t=E1oAeDz5t1VDcj9hHkWH3g&s=09");
    }
    public void ToMedium() {
        Application.OpenURL ("https://puertasmangones.medium.com/");
    }
    public void ToLinkedin() {
        Application.OpenURL ("https://www.linkedin.com/in/dania-puertas-mangones-6018a8205/");
    }
}
