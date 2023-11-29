using UnityEngine;
using UnityEngine.UI;

public class vida_boss : MonoBehaviour
{
    public boss_base Boss;
    public Image[] barra;

    void Update()
    {
        int fullbarra = Mathf.CeilToInt(Boss.vida / 100f);
        for (int i = 0; i < barra.Length; i++){
            if (i < fullbarra){
                barra[i].gameObject.SetActive(true);
            } else {
                barra[i].gameObject.SetActive(false);
            }
        }
    }
}
