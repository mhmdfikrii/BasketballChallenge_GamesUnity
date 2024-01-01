using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Tambahkan using untuk menggunakan UI.

public class gerak : MonoBehaviour
{
	Rigidbody2D Rb;
	public float ms;
	public float jf;
	public int maxJumps = 2;
	private int jumpsRemaining;

	public GameObject tryAgainCanvas; // Referensi ke UI canvas yang berisi pop-up "Coba Lagi".
	public GameObject finishPanel; // Referensi ke UI canvas yang berisi panel "Finish".
	public Text scoreText; // Referensi ke UI teks untuk menampilkan skor.
	public AudioSource coinSound; // Referensi ke komponen AudioSource untuk suara koin.
	public AudioSource matiSound; // Referensi ke komponen AudioSource untuk suara ketika karakter menyentuh objek dengan tag "Mati".
	private int score; // Variabel untuk menyimpan skor.

	// Use this for initialization
	void Start()
	{
		Rb = GetComponent<Rigidbody2D>();
		jumpsRemaining = maxJumps;
		tryAgainCanvas.SetActive(false); // Sembunyikan pop-up "Coba Lagi" pada awal permainan.
		score = 0; // Inisialisasi skor menjadi 0.
		UpdateScoreText(); // Perbarui teks skor pada UI.
	}

	// Update is called once per frame
	void Update()
	{
		float horiz = Input.GetAxisRaw("Horizontal");
		Rb.velocity = new Vector2(ms * horiz, Rb.velocity.y);

		if (jumpsRemaining > 0 && Input.GetButtonDown("Jump"))
		{
			Rb.AddForce(new Vector2(0, jf));
			jumpsRemaining--;
		}
	}

	// Ketika karakter menyentuh tanah (collision dengan objek tertentu)
	private void OnCollisionEnter2D(Collision2D collision)
	{
		// Reset jumlah loncatan ketika karakter menyentuh tanah
		if (collision.gameObject.CompareTag("Ground"))
		{
			jumpsRemaining = maxJumps;
		}

		// Cek jika karakter menyentuh objek dengan tag "Mati"
		if (collision.gameObject.CompareTag("Mati"))
		{
			GameOver(); // Panggil fungsi GameOver untuk menonaktifkan karakter dan menampilkan pop-up "Coba Lagi"
			Time.timeScale = 0;

			// Putar suara ketika karakter menyentuh objek dengan tag "Mati".
			if (matiSound != null)
			{
				matiSound.Play();
			}
		}
	}

	// Fungsi untuk mengumpulkan koin (dipanggil dari skrip "Coin").
	public void CollectCoin(int coinValue)
	{
		// Tambahkan nilai koin ke skor.
		score += coinValue;
		UpdateScoreText(); // Perbarui teks skor pada UI.

		// Putar suara ketika koin disentuh.
		if (coinSound != null)
		{
			coinSound.Play();
		}
	}

	private void GameOver()
	{
		// Nonaktifkan gerakan karakter dan tampilkan pop-up "Coba Lagi"
		Rb.velocity = Vector2.zero;
		Rb.isKinematic = true;
		tryAgainCanvas.SetActive(true);
	}

	// Fungsi untuk mencoba kembali permainan
	public void RetryGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		Time.timeScale = 1;
	}

	// Fungsi untuk memperbarui teks skor pada UI.
	private void UpdateScoreText()
	{
		scoreText.text = "Skor: " + score.ToString();

		// Cek jika pemain sudah mendapatkan 10 koin
		if (score >= 10)
		{
			FinishGame(); // Panggil fungsi FinishGame untuk menampilkan panel "Finish" dan menghentikan permainan
		}
	}

	// Fungsi untuk mengakhiri permainan dan menampilkan panel "Finish"
	private void FinishGame()
	{
		// Nonaktifkan gerakan karakter
		Rb.velocity = Vector2.zero;
		Rb.isKinematic = true;

		// Tampilkan panel "Finish" (pastikan Anda memiliki canvas dan panel "Finish" pada hierarki)
		finishPanel.SetActive(true);

		// Atau Anda juga bisa menghentikan waktu permainan jika menggunakan Time.timeScale, 
		// seperti yang telah Anda lakukan di fungsi RetryGame.
		Time.timeScale = 0;
	}
}
