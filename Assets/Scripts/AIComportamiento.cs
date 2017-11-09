using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AIComportamiento : MonoBehaviour {

	public float distanciaObjetivo;
	public float distanciaSeguir;
	public float velocidad;
	public float orientacion;
	private bool patrulla;
	public Transform objetivo;
	public Transform[] caminos;
	private int camino;
	private Rigidbody enemigo;


	// Use this for initialization
	void Start () {
		enemigo = GetComponent<Rigidbody>();
		patrulla = true;
		camino = 0;
	}

	// Update is called once per frame
	void FixedUpdate () {
		distanciaObjetivo = Vector3.Distance (objetivo.position, transform.position);
		if (distanciaObjetivo < distanciaSeguir) 
		{
			velocidad = 30;
			SeguirObjetivo ();
			MirarObjetivo ();
			patrulla = false;
		}
		if ( patrulla== true ) 
		{
			Patrullar ();

			if (distanciaObjetivo < distanciaSeguir) 
			{
				patrulla = false;

			} 
		}

	}
	void Patrullar()
	{
		if (Vector3.Distance (this.transform.position, caminos [camino].transform.position) > 1) 
		{
			Quaternion rotation = Quaternion.LookRotation (caminos[camino].position - transform.position);
			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * orientacion);
			enemigo.AddForce(transform.forward * velocidad);
		} 
		else if (Vector3.Distance (this.transform.position, caminos [camino].transform.position) < 1) 
		{
 			camino += 1;
			if (camino > caminos.Length) 
			{
				camino = 0;

			}
		}
	}
	void MirarObjetivo()
	{
		Quaternion rotation = Quaternion.LookRotation (objetivo.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * orientacion);
	}
	void SeguirObjetivo()
	{
		enemigo.AddForce(transform.forward * velocidad);
	}

}