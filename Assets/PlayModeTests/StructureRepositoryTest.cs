using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class StructureRepositoryTest
    {
        StructureRepository repository;

        [OneTimeSetUp]
        public void Init()
        {
            CollectionSO collection = new CollectionSO();
            
            var road = new RoadStructureSO();
            road.buildingName = "Road";
            collection.roadStructure = road;

            var facility = new SingleFacilitySO();
            facility.buildingName = "PowerPlant";
            collection.singleStructureList = new List<SingleStructureBaseSO>();
            collection.singleStructureList.Add(facility);

            var zone = new ZoneStructureSO();
            zone.buildingName = "Commercial";
            collection.zonesList = new List<ZoneStructureSO>();
            collection.zonesList.Add(zone);

            GameObject testObject = new GameObject();
            repository = testObject.AddComponent<StructureRepository>();
            repository.modelDataCollection = collection;
        }

        [UnityTest]
        public IEnumerator StructureRepositoryTestRoadNamePasses()
        {
            string name = repository.GetRoadStructureName();
            yield return new WaitForEndOfFrame();
            Assert.AreEqual("Road", name);
        }

        [UnityTest]
        public IEnumerator StructureRepositoryTestSingleStructureListQuantityPasses()
        {
            int quantity = repository.GetSingleStructureNames().Count;
            yield return new WaitForEndOfFrame();
            Assert.AreEqual(1, quantity);
        }

        [UnityTest]
        public IEnumerator StructureRepositoryTestSingleStructureListNamePasses()
        {
            string name = repository.GetSingleStructureNames()[0];
            yield return new WaitForEndOfFrame();
            Assert.AreEqual("PowerPlant", name);
        }
        [UnityTest]
        public IEnumerator StructureRepositoryTestZoneListQuantityPasses()
        {
            int quantity = repository.GetZoneNames().Count;
            yield return new WaitForEndOfFrame();
            Assert.AreEqual(1, quantity);
        }

        [UnityTest]
        public IEnumerator StructureRepositoryTestZoneListNamePasses()
        {
            string name = repository.GetZoneNames()[0];
            yield return new WaitForEndOfFrame();
            Assert.AreEqual("Commercial", name);
        }
    }
}
