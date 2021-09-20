using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : Animal
{
    private float jumpSpeed = 5.0f;
    private float horizontalMove , verticalMove;
    private CharacterController cc;
    private float gravity = 9.81f;
    private Vector3 velocity; //控制Y軸加速度
    public Transform groundCheck;
    private float checkRadius = 0.4f;
    public LayerMask groundLayer;
    private bool isGround;

    public GameObject PlayerHand;
    public GameObject magicBall;
    private GameObject mge;
    private float speed;
    public GameObject eye;

    // Start is called before the first frame update
    public override void OnStartLocalPlayer()
    {
        hp = Random.Range(10,100);
        atk = 10;
        moveSpeed = 4.0f;
        eye.SetActive(false);
        cc = this.GetComponent<CharacterController>();
        Camera.main.transform.SetParent(transform);
        Camera.main.transform.localPosition = new Vector3(0, 0, 0);
        CmdSetUpPlayer(hp , atk);
    }

    [Command]
    public void CmdSetUpPlayer(int _hp , int _atk){
        hp = _hp;
        atk = _atk;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isLocalPlayer){
            return;
        }

        isGround = Physics.CheckSphere(groundCheck.position , checkRadius , groundLayer);//在碰到地板之前，施加重力給玩家
        if(isGround && velocity.y < 0.0f){
            velocity.y = -2.0f;
        }

        horizontalMove = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime * 70.0f;
        verticalMove   = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, horizontalMove, 0);
        transform.Translate(0, 0, verticalMove);

        if(Input.GetButtonDown("Jump") && isGround){
            velocity.y = jumpSpeed;
        }

        velocity.y -= gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Mouse0)){
            CmdShootMagicBall();
        }

        if(Input.GetKeyDown(KeyCode.Mouse1)){
            eye.SetActive(true);
        }
        if(Input.GetKeyUp(KeyCode.Mouse1)){
            eye.SetActive(false);
        }
    }

    public override void TakeDamage(int damage){
        changeHp(damage);
    }

    [Command]
    void changeHp(int damage){
        RpcChangeHp(damage);
    }
    [ClientRpc]
    void RpcChangeHp(int damage){
        hp -= damage;
    }

    [Command]
    void CmdShootMagicBall()
    {
        RpcFireBall();
    }

    [ClientRpc]
    void RpcFireBall()
    {
        mge = Instantiate(magicBall ,PlayerHand.transform.position ,this.transform.rotation);
        Rigidbody magicBallRig = mge.gameObject.GetComponent<Rigidbody>();
        magicBallRig.AddForce(transform.forward * 200.0f);
    } 

    public int GetHP(){
        return hp;
    }
}
