using System.Collections;
using System.Collections.Generic;
using NSubstitute;
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

            uiController = Substitute.For<UIController>();

            gameManagerComponent = gameManagerObject.AddComponent<GameManager>();
            gameManagerComponent.cameraMovement = cameraMovementComponent;
            gameManagerComponent.uiController = uiController;
        }

        [UnityTest]
        public IEnumerator PlayerStatusPlayerBuildingSingleStructureStateTestWithEnumeratorPasses()
        {
            yield return new WaitForEndOfFrame(); //Calls Awake
            yield return new WaitForEndOfFrame(); //Calls Start
            gameManagerComponent.State.OnBuildSingleStructure(null);
            yield return new WaitForEndOfFrame();
            Assert.IsTrue(gameManagerComponent.State is PlayerBuildingSingleStructureState);
        }

        [UnityTest]
        public IEnumerator PlayerStatusPlayerBuildingAreaStateTestWithEnumeratorPasses()
        {
            yield return new WaitForEndOfFrame(); //Calls Awake
            yield return new WaitForEndOfFrame(); //Calls Start
            gameManagerComponent.State.OnBuildArea(null);
            yield return new WaitForEndOfFrame();
            Assert.IsTrue(gameManagerComponent.State is PlayerBuildingZoneState);
        }

        [UnityTest]
        public IEnumerator PlayerStatusPlayerBuildingRoadStateTestWithEnumeratorPasses()
        {
            yield return new WaitForEndOfFrame(); //Calls Awake
            yield return new WaitForEndOfFrame(); //Calls Start
            gameManagerComponent.State.OnBuildRoad(null);
            yield return new WaitForEndOfFrame();
            Assert.IsTrue(gameManagerComponent.State is PlayerBuildingRoadState);
        }

        [UnityTest]
        public IEnumerator PlayerStatusPlayerRemoveBuildingStateTestWithEnumeratorPasses()
        {
            yield return new WaitForEndOfFrame(); //Calls Awake
            yield return new WaitForEndOfFrame(); //Calls Start
            gameManagerComponent.State.OnDemolishAction();
            yield return new WaitForEndOfFrame();
            Assert.IsTrue(gameManagerComponent.State is PlayerRemoveBuildingState);
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
