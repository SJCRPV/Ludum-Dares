using UnityEngine;

public class PlayerControls : MonoBehaviour {

    Player player;
    GameObject endLevelScreen;
    PlayMedia leftHand;
    PlayMedia rightHand;

    private void Start()
    {
        player = GetComponent<Player>();
        leftHand = transform.Find("LeftHand").GetComponent<PlayMedia>();
        rightHand = transform.Find("RightHand").GetComponent<PlayMedia>();
    }

    // Update is called once per frame
    void Update () {

        if(!InteractionWithGod.instance.IsInteractingWithGod)
        {
            BeatConstructor.instance.UpModifier = Input.GetKey(KeyCode.UpArrow);
            BeatConstructor.instance.RightModifier = Input.GetKey(KeyCode.RightArrow);
            BeatConstructor.instance.DownModifier = Input.GetKey(KeyCode.DownArrow);
            BeatConstructor.instance.LeftModifier = Input.GetKey(KeyCode.LeftArrow);

            if(Input.GetKeyDown(KeyCode.A)) // Left Hand
            {
                float damage = BeatConstructor.instance.attack(isFromTheLeft: true);
                EnemyManager.instance.CurrentEnemy.decrementHealth(damage);
                player.hurtSelf();
                leftHand.playAnimation("LeftPunch");
                leftHand.playAudio();
            }
            if(Input.GetKeyDown(KeyCode.D)) // Right Hand
            {
                float damage = BeatConstructor.instance.attack(isFromTheLeft: false);
                EnemyManager.instance.CurrentEnemy.decrementHealth(damage);
                player.hurtSelf();
                rightHand.playAnimation("RightPunch");
                rightHand.playAudio();
            }
        }

	}
}
