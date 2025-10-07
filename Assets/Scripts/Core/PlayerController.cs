using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;              // Kecepatan jalan
    private Vector2 moveInput;                // Input arah dari player

    [Header("References")]
    public Rigidbody2D rb;                    // Rigidbody2D untuk gerak halus
    private Animator anim;                    // (Opsional) buat animasi

    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Ambil input dari keyboard
        moveInput.x = Input.GetAxisRaw("Horizontal"); // A/D atau ← →
        moveInput.y = Input.GetAxisRaw("Vertical");   // W/S atau ↑ ↓
        moveInput.Normalize();                        // Biar diagonal gak terlalu cepat

        // Update animasi (kalau ada)
        if (anim != null)
        {
            anim.SetFloat("MoveX", moveInput.x);
            anim.SetFloat("MoveY", moveInput.y);
            anim.SetFloat("Speed", moveInput.sqrMagnitude);
        }
    }

    void FixedUpdate()
    {
        // Gerakan player berdasarkan input
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }
}
