using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHealthManager : MonoBehaviour
{

    public int vidaMaxima;
    public int vidaAtual;
    public Image barraVidaUI;
    public Text vida;

    // Use this for initialization
    void Start()
    {
        vidaAtual = vidaMaxima;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (vidaAtual <= 0)
        {
            // faz com que o inimigo desapareça, representando a morte do inimigo
            Destroy(gameObject);
            // passa para o próximo nível
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            // nao deixa com que a vida do inimigo seja um valor negativo
            vidaAtual = 0;
        }

        if (vidaAtual > vidaMaxima)
        {
            // nao deixa a vida atual ultrapassar a vida maxima
            vidaAtual = vidaMaxima;
        }


        atualiza(vidaMaxima, vidaAtual);
    }

    public void HurtEnemy(int damageToGive)
    {
        vidaAtual -= damageToGive;
    }
    public void SetMaxHealth()
    {
        vidaAtual = vidaMaxima;

    }

    public void atualiza(float vidaMaxima, float vidaAtual)
    {

        float fracaoVida = (vidaAtual / vidaMaxima);
        barraVidaUI.rectTransform.sizeDelta = new Vector2(fracaoVida * 100, 9);
        vida.text = vidaAtual.ToString();
    }





    public void regenera(int valorRegeneracao)
    {
        Debug.Log("regenerou");

        vidaAtual += valorRegeneracao;

    }


}




