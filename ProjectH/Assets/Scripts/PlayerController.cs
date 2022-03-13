using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 0.3f;
    public float JumpForce = 1f;
    public Player player;

    public Vector3 mousePosition;

    //даем возможность выбрать тэг пола.
    //так же убедитесь что ваш Player сам не относитс€ к даному слою. 

    //!!!!Ќацепите на него нестандартный Layer, например Player!!!!
    public LayerMask GroundLayer = 1; // 1 == "Default"

    private Rigidbody _rb;
    private CapsuleCollider _collider; // теперь прийдетс€ использовать CapsuleCollider
    //и удалите бокс коллайдер если он есть

    private bool _isGrounded
    {
        get
        {
            var bottomCenterPoint = new Vector3(_collider.bounds.center.x, _collider.bounds.min.y, _collider.bounds.center.z);

            //создаем невидимую физическую капсулу и провер€ем не пересекает ли она обьект который относитс€ к полу

            //_collider.bounds.size.x / 2 * 0.9f -- эта странна€ конструкци€ берет радиус обьекта.
            // был бы об€зательно сферой -- бралс€ бы радиус напр€мую, а так пишем по-универсальнее

            return Physics.CheckCapsule(_collider.bounds.center, bottomCenterPoint, _collider.bounds.size.x / 2 * 0.9f, GroundLayer);
            // если можно будет прыгать в воздухе, то нужно будет изменить коэфициент 0.9 на меньший.
        }
    }

    private Vector3 _movementVector
    {
        get
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            return new Vector3(horizontal, 0.0f, vertical);
        }
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();

        //т.к. нам не нужно что бы персонаж мог падать сам по-себе без нашего на то указани€.
        //то нужно заблочить поворот по ос€х X и Z
        _rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        //  «ащита от дурака
        if (GroundLayer == gameObject.layer)
            Debug.LogError("Player SortingLayer must be different from Ground SourtingLayer!");
    }

    void FixedUpdate()
    {
        JumpLogic();
        MoveLogic();
    }

    private void MoveLogic()
    {
        // т.к. мы сейчас решили использовать физическое движение снова,
        // мы убрали и множитель Time.fixedDeltaTime
        _rb.AddForce(_movementVector * Speed, ForceMode.Impulse);
    }

    private void JumpLogic()
    {
        if (_isGrounded && (Input.GetAxis("Jump") > 0))
        {
            _rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }
}
