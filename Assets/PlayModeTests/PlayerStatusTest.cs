using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    [TestFixture]
    public class PlayerStatusTest
    {
        UIController uIController;
        GameManager gameManagerComponent;

        [SetUp]
        public void Init()
        {
            GameObject gameManagerObject = new GameObject();
            var cameraMovementComponent = gameManagerObject.AddComponent<CameraMovement>();
            gameManagerObject.AddComponent<InputManager>();
            uIController = gameManagerObject.AddComponent<UIController>();
            GameObject buttonBuildObject = new GameObject();
            GameObject cancleButtonObject = new GameObject();
            GameObject canclePanel = new GameObject();
            uIController.cancleActionBtn = cancleButtonObject.AddComponent<Button>();
            var buttonBuildComponent = buttonBuildObject.AddComponent<Button>();
            uIController.buildResidentialAreaBtn = buttonBuildComponent;
            uIController.cancleActionPanel = cancleButtonObject;

            gameManagerComponent = gameManagerObject.AddComponent<GameManager>();
            gameManagerComponent.cameraMovement = cameraMovementComponent;
            gameManagerComponent.uiController = uIController;
        }

        [UnityTest]
        public IEnumerator PlayerStatusPlayerBuildingSingleStructureStateTestWithEnumeratorPasses()
        {
            yield return new WaitForEndOfFrame(); //Calls Awake
            yield return new WaitForEndOfFrame(); //Calls Start
            uIController.buildResidentialAreaBtn.onClick.Invoke();
            yield return new WaitForEndOfFrame();
            Assert.IsTrue(gameManagerComponent.State is PlayerBuildingSingleStructureState);
            yield return null;
        }

        [UnityTest]
        public IEnumerator PlayerStatusPlayerSelectionStateTestWithEnumeratorPasses()
        {
            yield return new WaitForEndOfFrame(); //Calls Awake
            yield return new WaitForEndOfFrame(); //Calls Start
            Assert.IsTrue(gameManagerComponent.State is PlayerSelectionState);
            yield return null;
        }
    }
}
