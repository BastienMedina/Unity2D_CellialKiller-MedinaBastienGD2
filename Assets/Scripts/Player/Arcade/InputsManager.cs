using UnityEngine;

public class InputsManager : MonoBehaviour
{
    [Header("Mouvements")]
    [SerializeField] private float _minHoldTime = 1.0f;

    private PlayerMouvements _mouvementsScript;
    private float _touchTimer;
    private Vector2 _startTouchPos;

    [Header("Phone Throw")]
    [SerializeField] private PhoneThrower _phoneThrower;

    private FlipBookAnimation _walkAnim;

    void Start() //Initialise les scripts et l’animation
    {
        _walkAnim = GetComponent<FlipBookAnimation>();
        _mouvementsScript = GetComponent<PlayerMouvements>();
        _phoneThrower = GetComponent<PhoneThrower>();
        if (_phoneThrower == null) //Si PhoneThrower n’est pas assigné
        {
            Debug.LogWarning("Phone thrower est nuuuuullll !!");
        }
    }

    void Update() //Appelle la gestion input selon la plateforme
    {
#if UNITY_EDITOR
    HandleMouseInput();
#else
        HandleTouchInput();
#endif
    }

    // =========================
    // INPUTS MOBILE (pour inputs sur mobile)
    // =========================
    void HandleTouchInput() //Gère les touches sur mobile
    {
        if (Input.touchCount == 0) //Si aucun toucher
        {
            _touchTimer = 0f;
            return;
        }

        Touch touche = Input.GetTouch(0);

        if (touche.phase == TouchPhase.Began) //Début du toucher
        {
            _startTouchPos = touche.position;
            TouchTimer(false, touche.position);
        }

        if (touche.phase == TouchPhase.Stationary || touche.phase == TouchPhase.Moved) //Maintien ou déplacement du toucher
        {
            TouchTimer(true, touche.position);
        }

        if (touche.phase == TouchPhase.Ended) //Fin du toucher
        {
            if (_touchTimer < _minHoldTime) //Si le toucher était court
            {
                _phoneThrower.ThrowPhone(touche.position); //Lance le téléphone
            }
            _walkAnim.ActivateFlipbook(false); //Arrête l’animation de marche
            _touchTimer = 0f;
        }
    }

    // =========================
    // INPUTS PC (SOURIS) (pour test dev sur PC)
    // =========================
    void HandleMouseInput() //Gère les inputs souris
    {
        Vector2 mousePos = Input.mousePosition;

        if (Input.GetMouseButtonDown(0)) //Bouton pressé
        {
            _startTouchPos = mousePos;
            _touchTimer = 0f;
        }

        if (Input.GetMouseButton(0)) //Bouton maintenu
        {
            _touchTimer += Time.deltaTime;

            if (_touchTimer >= _minHoldTime) //Si maintenu assez longtemps
            {
                InputMove(mousePos); //Déplace le joueur
                _walkAnim.ActivateFlipbook(true); //Active l’animation de marche
            }
        }

        if (Input.GetMouseButtonUp(0)) //Bouton relâché
        {
            if (_touchTimer < _minHoldTime) //Si clic court
            {
                _phoneThrower.ThrowPhone(mousePos); //Lance le téléphone
            }
            _walkAnim.ActivateFlipbook(false); //Arrête l’animation
            _touchTimer = 0f;
        }
    }

    void TouchTimer(bool state, Vector2 pos) //Compte le temps de maintien
    {
        if (state) //Si le toucher est maintenu
        {
            _touchTimer += Time.deltaTime;

            if (_touchTimer >= _minHoldTime) //Si le temps dépasse le minimum
            {
                InputMove(pos); //Déplace le joueur
            }
        }
        else //Sinon reset du timer
        {
            _touchTimer = 0f;
        }
    }

    void InputMove(Vector2 pos) //Transforme la position écran en déplacement
    {
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(pos);
        Vector2 dir2D = (worldPos - (Vector2)_mouvementsScript.transform.position).normalized;

        Vector3 dir3D = new Vector3(dir2D.x, dir2D.y, 0f);
        _mouvementsScript.Move(dir3D); //Applique le déplacement
    }
}
