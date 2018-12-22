using System;
using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "Installers/Match Field Setup")]
public class MatchFieldSetup : ScriptableObjectInstaller<MatchFieldSetup>
{
    public FieldGridSettings Grid;

    [Serializable]
    public class FieldGridSettings
    {
        public FieldGridGenerator.Settings GridGenerator;
    }

    public override void InstallBindings()
    {
    }
}
