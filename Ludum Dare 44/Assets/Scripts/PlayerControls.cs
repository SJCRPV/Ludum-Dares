using UnityEngine;

public class PlayerControls : MonoBehaviour {

    Player player;
    GameObject enemyObj;

    private void Start()
    {
        player = GameObject.Find("Character").GetComponent<Player>();
        enemyObj = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void Update () {

        BeatConstructor.instance.UpModifier = Input.GetKey(KeyCode.UpArrow);
        BeatConstructor.instance.RightModifier = Input.GetKey(KeyCode.RightArrow);
        BeatConstructor.instance.DownModifier = Input.GetKey(KeyCode.DownArrow);
        BeatConstructor.instance.LeftModifier = Input.GetKey(KeyCode.LeftArrow);

        if(Input.GetKeyDown(KeyCode.A))
        {
            float damage = BeatConstructor.instance.attack(isFromTheLeft: true);
            enemyObj.transform.GetChild(0).GetComponent<Enemy>().decrementHealth(damage);
            player.hurtSelf();
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            float damage = BeatConstructor.instance.attack(isFromTheLeft: false);
            enemyObj.transform.GetChild(0).GetComponent<Enemy>().decrementHealth(damage);
            player.hurtSelf();
        }
	}
}
