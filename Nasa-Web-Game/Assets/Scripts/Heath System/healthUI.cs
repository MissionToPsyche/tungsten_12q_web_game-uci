using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class healthUI : MonoBehaviour
{
    [SerializeField] private health playerHP;
    [SerializeField] private Image maxHP;
    [SerializeField] private Image curHP;

    // Start is called before the first frame update
    void Start()
    {
        maxHP.fillAmount = playerHP.curHealth / 10;
    }

    // Update is called once per frame
    void Update()
    {
        curHP.fillAmount = playerHP.curHealth / 10;

    }
}
