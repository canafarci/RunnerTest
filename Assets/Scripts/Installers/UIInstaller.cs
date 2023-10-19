using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;

public class UIInstaller : MonoInstaller<UIInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<TextMeshProUGUI>()
            .FromComponentInChildren()
            .AsTransient();
    }
}
