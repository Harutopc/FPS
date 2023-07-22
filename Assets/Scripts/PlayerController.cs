using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float turnSpeed;
    [SerializeField]
    private float shootDistance = 6f;
    [SerializeField]
    private ParticleSystem shootPS;
    [SerializeField]
    private float vida;
    public float maximodeVida;
    public HealthBar healthBar;

    private Rigidbody mRb;
    private Vector2 mDirection;
    private Vector2 mDeltaLook;
    private Transform cameraMain;
    private GameObject debugImpactSphere;
    private GameObject bloodObjectParticles;
    private GameObject otherObjectParticles;
    
    private ArrayList[] armas;
    public int indicarArma=0;

    private void Start()
    {
        vida= maximodeVida;
        healthBar.InicializarBarra(vida);
        mRb = GetComponent<Rigidbody>();
        cameraMain = transform.Find("Main Camera");

        debugImpactSphere = Resources.Load<GameObject>("DebugImpactSphere");
        bloodObjectParticles = Resources.Load<GameObject>("BloodSplat_FX Variant");
        otherObjectParticles = Resources.Load<GameObject>("GunShot_Smoke_FX Variant");

        Cursor.lockState = CursorLockMode.Locked;
    }
/*   private void Update()
    {
        RevisarCambiodeArmas();
    }
    void CambiarArma()
    {
        for(int i =0;i <transform.childCount; i ++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        armas[indicarArma].gameObject.SetActive(true);

    }
    void RevisarCambiodeArmas()
    {//tabcito revisar
        float Tabcito=Input.GetKeyDown(KeyCode.Tab).childCount;
        if("latecla mayor a0")
        {
            SeleccionarArmaSiguiente();
        }else if("latecla es menor q 0"){
            SeleccionarArmaAnterior();
        }
            
    }
    
    void SeleccionarArmaAnterior(){
        if(indicarArma==0)
        {
            indicarArma=armas.Length -1;
        }
        else{
            indicarArma--;
        }
        CambiarArma();
    }
*/

    
    private void FixedUpdate()
    {
        mRb.velocity = mDirection.y * speed * transform.forward 
            + mDirection.x * speed * transform.right;

        transform.Rotate(
            Vector3.up,
            turnSpeed * Time.deltaTime * mDeltaLook.x
        );
        cameraMain.GetComponent<CameraMovement>().RotateUpDown(
            -turnSpeed * Time.deltaTime * mDeltaLook.y
        );

    }

    private void OnMove(InputValue value)
    {
        mDirection = value.Get<Vector2>();
    }

    private void OnLook(InputValue value)
    {
        mDeltaLook = value.Get<Vector2>();
    }

    private void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        shootPS.Play();

        RaycastHit hit;
        if (Physics.Raycast(
            cameraMain.position,
            cameraMain.forward,
            out hit,
            shootDistance
        ))
        {
            if (hit.collider.CompareTag("Enemigos")|| hit.collider.CompareTag("Vampire")|| hit.collider.CompareTag("L1")|| hit.collider.CompareTag("L3")|| hit.collider.CompareTag("L4")|| hit.collider.CompareTag("L5"))
            {   

                var bloodPS = Instantiate(bloodObjectParticles, hit.point, Quaternion.identity);
                Destroy(bloodPS, 3f);
                var enemyController = hit.collider.GetComponent<EnemyController>();
                enemyController.TakeDamage(3f);
            }else
            {
                var otherPS = Instantiate(otherObjectParticles, hit.point, Quaternion.identity);
                otherPS.GetComponent<ParticleSystem>().Play();
                Destroy(otherPS, 3f);
            }
            
        }
    }

    public void TakeDamage(float damage)
    {
        vida -= damage;
        healthBar.InicializarBarra(vida);
        if (vida <= 0f)
        {
            // Fin del juego
            Debug.Log("Fin del juego");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemigo-Attack"))
        {
            Debug.Log("Player recibio danho");
            TakeDamage(20f);
        }
        
    }

}
