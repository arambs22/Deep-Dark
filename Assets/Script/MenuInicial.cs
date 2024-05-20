using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public float delayBeforeLoading = 2f; // Delay in seconds
    public Image fadeOutUIImage; // Reference to the UI image that will cover the screen
    public float fadeSpeed = 0.8f; // Speed of the fade (higher value = faster fade)

    public void Jugar()
    {
        StartCoroutine(FadeAndLoadScene());
    }

    IEnumerator FadeAndLoadScene()
    {
        yield return Fade(fadeOutUIImage, fadeOutUIImage.color.a, 1f); // Fade to black
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator Fade(Image fadeImage, float start, float end)
    {
        float counter = 0f;

        while (counter < delayBeforeLoading)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(start, end, counter / delayBeforeLoading);

            // Change alpha of the image
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alpha);
            yield return null;
        }
    }

    public void Salir()
    {
        Debug.Log("Salir");
        Application.Quit();
    }
}