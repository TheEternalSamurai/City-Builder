﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GridStructureTests
    {
        GridStructure structure;

        [OneTimeSetUp]
        public void Init()
        {
            structure = new GridStructure(3);
        }

        // A Test behaves as an ordinary method
        [Test]
        public void CalculateGridPositionPasses()
        {
            //Arrange
            Vector3 position = new Vector3(0, 0, 0);
            
            //Act
            Vector3 returnPosition = structure.CalculateGridPosition(position);

            //Assert
            Assert.AreEqual(Vector3.zero, returnPosition);
        }

        [Test]
        public void CalculateGridPositionFloatsPasses()
        {
            //Arrange
            Vector3 position = new Vector3(2.9f, 0, 2.9f);

            //Act
            Vector3 returnPosition = structure.CalculateGridPosition(position);

            //Assert
            Assert.AreEqual(Vector3.zero, returnPosition);
        }

        [Test]
        public void CalculateGridPositionFails()
        {
            //Arrange
            Vector3 position = new Vector3(3.1f, 0, 0f);

            //Act
            Vector3 returnPosition = structure.CalculateGridPosition(position);

            //Assert
            Assert.AreNotEqual(Vector3.zero, returnPosition);
        }
    }
}
