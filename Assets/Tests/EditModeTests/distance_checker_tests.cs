using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Runner.Movement;
using UnityEngine;
using Zenject;

[TestFixture]
public class distance_checker_tests : ZenjectUnitTestFixture
{
    [SetUp]
    public void CommonInstall()
    {
        GameObject obj = new GameObject("target");
        obj.transform.position = Vector3.zero;

        Container.Bind<Transform>().FromInstance(obj.transform);
        Container.Bind<DistanceChecker>().AsSingle();
        Container.Inject(this);
    }

    [Inject] private DistanceChecker _distanceChecker;

    [Test]
    public void distance_check_returns_true_when_distance_is_smaller_than_max_distance()
    {
        Vector3 target = Vector3.one / 4;

        Assert.IsTrue(_distanceChecker.CheckIfReachedDestination(target));
    }

    [Test]
    public void distance_check_returns_false_when_distance_is_greater_than_max_distance()
    {
        Vector3 target = Vector3.one;

        Assert.IsFalse(_distanceChecker.CheckIfReachedDestination(target));
    }
}
