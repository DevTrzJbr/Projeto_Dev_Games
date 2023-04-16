using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuprincipalManager : MonoBehaviour
{
	[SerializeField] private string nomedoLeveldeJogo;
	[SerializeField] private GameObject painelMenuInicial;
	[SerializeField] private GameObject painelOpcoes;

   public void Jogar()
   {
		SceneManager.LoadScene("Jogo2");
   }

   public void AbrirOpcoes()
   {
   painelMenuInicial.SetActive(false);
   painelOpcoes.SetActive(true);
		
   }

   public void FecharOpcoes()
   {
		painelOpcoes.SetActive(false);
		painelMenuInicial.SetActive(true);
   }

   public void SairJogo()
   {
		Debug.Log("Sair do jogo");
		Application.Quit();
   }
}
