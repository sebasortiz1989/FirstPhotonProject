using UnityEngine;

[BoltGlobalBehaviour(BoltNetworkModes.Server, "SandBoxPhoton")]
public class TutorialServerCallbacks : Bolt.GlobalEventListener
{
    public override void SceneLoadLocalDone(string map)
    {
        BoltNetwork.Instantiate(BoltPrefabs.Player);
    }

    public override void SceneLoadRemoteDone(BoltConnection connection)
    {
        BoltNetwork.Instantiate(BoltPrefabs.Player);
    }
}