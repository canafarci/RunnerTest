using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Runner.Movement;
using UnityEngine;
using Zenject;

[TestFixture]
public class position_randomizer_tests : ZenjectUnitTestFixture
{
    [SetUp]
    public void CommonInstall()
    {
        Container.Bind<PositionRandomizer>().AsSingle();
        Container.Inject(this);
    }

    [Inject] private PositionRandomizer _positionRandomizer;

    [Test]
    public void randomized_point_is_different()
    {
        Vector3 originalPos = Vector3.zero;
        float radius = 2f;
        Vector3 randomizedPos = _positionRandomizer.RandomizeDestinationPoint(originalPos, radius);
        Assert.IsTrue(originalPos.x != randomizedPos.x ||
                        originalPos.y != randomizedPos.y ||
                        originalPos.z != randomizedPos.z
        );
    }

    [Test]
    public void randomized_point_is_inside_radius()
    {
        Vector3 originalPos = Vector3.zero;
        float radius = 2f;

        for (int i = 0; i < 100; i++)
        {
            Vector3 randomizedPos = _positionRandomizer.RandomizeDestinationPoint(originalPos, radius);
            float distance = Vector3.Distance(originalPos, randomizedPos);

            Assert.IsTrue(distance <= radius);
        }

    }


}
