using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactionParticleSpawner : MonoBehaviour {

    public Sprite HappyOnes;
    public Sprite SadOnes;
    public int ParticleCount;
    public float ParticleLifetime;
    public float ParticleSpeed;
    public float GravityScale;

void Start () {
        EventManager.SomethingGotBetter += EventManager_SomethingGotBetter;
        EventManager.SomethingGotWorse += EventManager_SomethingGotWorse;
	}
	
	// Update is called once per frame
	void Update () {

    }

    void EventManager_SomethingGotBetter()
    {
        Spawn(HappyOnes);
    }

    void EventManager_SomethingGotWorse()
    {
        Spawn(SadOnes);
    }

    private void Spawn(Sprite sprite)
    {
        for (int i = 0; i < ParticleCount; i++)
        {
            var go = new GameObject("ReactionParticle_" + i);
            go.transform.SetParent(transform, false);
            go.AddComponent<Image>().sprite = sprite;
            var reactionParticle = go.AddComponent<ReactionParticle>();
            reactionParticle.Lifetime = ParticleLifetime;
            reactionParticle.Speed = ParticleSpeed;
            reactionParticle.GravityScale = GravityScale;
        }
    }


}
