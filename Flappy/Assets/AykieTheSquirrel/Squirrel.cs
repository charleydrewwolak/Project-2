using UnityEngine;
using System.Collections;

public class Squirrel : MonoBehaviour {

	public float WalkSpeed = 3.75f;
	public float RunSpeed = 7.5f;
	public float RollSpeed = 12.5f;
	public float JumpPower = 15f;
	
	public KeyCode Left = KeyCode.A;
	public KeyCode Right = KeyCode.D;
	public KeyCode Jump = KeyCode.Space;
	public KeyCode Walk = KeyCode.LeftControl;
	public KeyCode Attack = KeyCode.Alpha1;
	public KeyCode Roll = KeyCode.Alpha2;
	public KeyCode Wash = KeyCode.Alpha3;
	public KeyCode Hit = KeyCode.Alpha4;
	public KeyCode Die = KeyCode.Alpha5;

	public Vector3 GroundCheck = Vector3.zero;
	public LayerMask GroundLayers = -1;

	private SpriteRenderer Renderer;
	private Rigidbody2D RB;
	private Animator Animator;

	private bool Blocked = false;

	private bool doubleJump = false; // Whether or not the player has used double jump

	void Awake() {
		Renderer = GetComponent<SpriteRenderer>();
		RB = GetComponent<Rigidbody2D>();
		Animator = GetComponent<Animator>();
	}
	
	void Update() {
		UpdateAnimationState();

		if(Blocked) {
			return;
		}

		float velocity = 0f;
		//if(Input.GetKey(Left)) {
		//	velocity = Input.GetKey(Walk) ? -WalkSpeed : -RunSpeed;
		//	Renderer.flipX = true;
		//} else if(Input.GetKey(Right)) {
		velocity = Input.GetKey(Walk) ? WalkSpeed : RunSpeed;
		Renderer.flipX = false;
		//}
		RB.velocity = new Vector2(velocity, RB.velocity.y);

		if(Input.GetKeyDown(Attack)) {
			Animator.SetTrigger("Attack");
			StartCoroutine(DoAttack());
		}
		if(Input.GetKeyDown(Wash)) {
			Animator.SetTrigger("Wash");
			StartCoroutine(DoWash());
		}
		if(Input.GetKeyDown(Roll)) {
			Animator.SetTrigger("Roll");
			StartCoroutine(DoRoll());
		}
		if(Input.GetKeyDown(Hit)) {
			Animator.SetTrigger("Hit");
			StartCoroutine(DoHit());
		}
		if(Input.GetKeyDown(KeyCode.Space)) {
			TryJump();
		}
		if(Input.GetKeyDown(Die)) {
			SetAnimation("Die");
			Blocked = true;
		}
	}

	private void UpdateAnimationState() {
		//if(Input.GetKey(Left)) {
		//	SetAnimation(Input.GetKey(Walk) ? "Walk" : "Run");
		//} else if(Input.GetKey(Right)) {
		//	SetAnimation(Input.GetKey(Walk) ? "Walk" : "Run");
		//} else {
		//	SetAnimation("Idle");
		//}
		if(!IsGrounded()) {
			SetAnimation("Fall");
		}
		else {
			SetAnimation(Input.GetKey(Walk) ? "Walk" : "Run");
		}
	}

	private void SetAnimation(string name) {
		Animator.SetBool("Idle", false);
		Animator.SetBool("Walk", false);
		Animator.SetBool("Run", false);
		Animator.SetBool("Fall", false);

		Animator.SetBool(name, true);
	}

	private void TryJump() {
		if(!IsGrounded() && doubleJump) {
			return;
		}
		if(!IsGrounded()) {
			doubleJump = true;
		}
		RB.AddForce(new Vector2(0f, JumpPower), ForceMode2D.Impulse);
		Animator.SetTrigger("Jump");
		
	}


	private bool IsGrounded() {
		Collider2D[] overlaps = Physics2D.OverlapCircleAll(transform.position + GroundCheck, 0.25f, GroundLayers);
		for(int i=0; i<overlaps.Length; i++) {
			if(overlaps[i].gameObject != gameObject) {
				doubleJump = false;
				return true;
			}
		}
		return false;
	}

	private IEnumerator DoAttack() {
		Blocked = true;
		yield return new WaitForEndOfFrame();
		while(Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) {
			RB.velocity = Vector3.zero;
			yield return new WaitForEndOfFrame();
		}
		Blocked = false;
	}

	private IEnumerator DoWash() {
		Blocked = true;
		yield return new WaitForEndOfFrame();
		while(Animator.GetCurrentAnimatorStateInfo(0).IsName("Wash")) {
			RB.velocity = Vector3.zero;
			yield return new WaitForEndOfFrame();
		}
		Blocked = false;
	}

	private IEnumerator DoRoll() {
		Blocked = true;
		yield return new WaitForEndOfFrame();
		while(Animator.GetCurrentAnimatorStateInfo(0).IsName("Roll")) {
			RB.velocity = new Vector3(Renderer.flipX ? -RollSpeed : RollSpeed, RB.velocity.y);
			yield return new WaitForEndOfFrame();
		}
		Blocked = false;
	}

	private IEnumerator DoHit() {
		Blocked = true;
		yield return new WaitForEndOfFrame();
		while(Animator.GetCurrentAnimatorStateInfo(0).IsName("Hit")) {
			yield return new WaitForEndOfFrame();
		}
		Blocked = false;
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(transform.position + GroundCheck, 0.2f);
	}
}