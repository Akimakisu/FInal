using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorPersonaje : MonoBehaviour {

	private Rigidbody jugador;
	public float speed;
	private int contador;
	public Text llave;
	public Text muerte;
	public Text ganar;

	void Start ()
	{
		jugador = GetComponent<Rigidbody> ();
		contador = 0;
		Contador ();
		ganar.text = "";
		muerte.text = "";
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		jugador.AddForce (movement * speed);

	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Llave"))
		{
		    Destroy(other.gameObject);
			contador = contador + 1;
			Contador ();
		}
		if (other.gameObject.CompareTag ("Enemigo")) 
		{
			muerte.text = "PERDISTE";
			Time.timeScale = 0;
		}
	}

	void Contador ()
	{
		llave.text = "Contador " + contador.ToString ();
		if (contador >= 7) 
		{
			ganar.text = "GANASTE";
		}
	}
}
