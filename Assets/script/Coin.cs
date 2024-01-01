using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	Rigidbody2D Rb;
	public int coinValue = 1; // Nilai koin ketika dikumpulkan.
	public GameObject tryAgainCanvas;

	// Ketika pemain menyentuh koin.
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			CollectCoin();
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		// Cek jika karakter menyentuh objek dengan tag "Mati"
		if (collision.gameObject.CompareTag("Mati"))
		{
			GameOver(); // Panggil fungsi GameOver untuk menonaktifkan karakter dan menampilkan pop-up "Coba Lagi"
			Time.timeScale = 0;
		}
	}


	private void GameOver()
	{
		// Nonaktifkan gerakan karakter dan tampilkan pop-up "Coba Lagi"
		Rb.velocity = Vector2.zero;
		Rb.isKinematic = true;
		tryAgainCanvas.SetActive(true);

	}

	// Fungsi untuk mengumpulkan koin.
	private void CollectCoin()
	{
		// Panggil fungsi "CollectCoin" pada skrip "gerak" menggunakan referensi komponen "gerak" pada objek pemain.
		gerak playerMovement = FindObjectOfType<gerak>();
		if (playerMovement != null)
		{
			playerMovement.CollectCoin(coinValue);
		}

		// Hancurkan objek koin setelah dikumpulkan.
		Destroy(gameObject);
	}
}