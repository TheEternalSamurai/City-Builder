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
        UIController uiController;
        GameManager gameManagerComponent;

        [SetUp]
        public void Init()
        {
            GameObject gameManagerObject = new GameObject();
            var cameraMovementComponent = gameManagerObject.AddComponent<CameraMovement>();

            uiController = gameManagerObject.AddComponent<UIController>();
            GameObject buttonBuildObject = new GameObject();
            GameObject cancleButtonObject = new GameObject();
            GameObject canclePanel = new GameObject();
            uiController.cancleActionBtn = cancleButtonObject.AddComponent<Button>();
            var buttonBuildComponent = buttonBuildObject.AddComponent<Button>();
            uiController.buildResidentialAreaBtn = buttonBuildComponent;
            uiController.cancleActionPanel = cancleButtonObject;

            uiController.buildingMenuPanel = canclePanel;
            uiController.openBuildMenuBtn = uiController.cancleActionBtn;
            uiController.demolishBtn = uiController.cancleActionBtn;

            gameManagerComponent = gameManagerObject.AddComponent<GameManager>();
            gameManagerComponent.cameraMovement = cameraMovementComponent;
            gameManagerComponent.uiController = uiController;
        }

        [UnityTest]
        public IEnumerator PlayerStatusPlayerBuildingSingleStructureStateTestWithEnumeratorPasses()
        {
            yield return new WaitForEndOfFrame(); //Calls Awake
            yield return new WaitForEndOfFrame(); //Calls Start
            uiController.buildResidentialAreaBtn.onClick.Invoke();
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
