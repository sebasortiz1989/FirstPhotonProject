using Bolt.AdvancedTutorial;
using UnityEngine;

//// only on the host
//[BoltGlobalBehaviour(BoltNetworkModes.Server)]

//// only on the client
//[BoltGlobalBehaviour(BoltNetworkModes.Client)]

//// only when the current scene is 'Level2'
//[BoltGlobalBehaviour("Level2")]

//// only when the current scene is 'Level1', 'Level2' or 'Level3'
//[BoltGlobalBehaviour("Level1", "Level2", "Level3")]

//// only when we are the host AND the current scene is 'Level2'
//[BoltGlobalBehaviour(BoltNetworkModes.Server, "Level2")]

//// only when we are the client AND the current scene is 'Level2'
//[BoltGlobalBehaviour(BoltNetworkModes.Client, "Level2")]

[BoltGlobalBehaviour("SandBoxPhoton")]

public class TutorialPlayerCallbacks : Bolt.GlobalEventListener
{
    public override void SceneLoadLocalDone(string map)
    {
        PlayerCamera.Instantiate();
    }
}
