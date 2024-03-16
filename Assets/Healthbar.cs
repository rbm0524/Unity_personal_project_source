using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public Player player;

    private void Start()
    {
        slider.maxValue = player.maxHealth;
    }

    private void Update()
    {
        slider.value = player.currentHealth;
    }
}
