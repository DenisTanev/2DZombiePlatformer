using System.Collections;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;
using _Scripts.Weapons.Components;
using System.Runtime.CompilerServices;
using UnityEditor.Callbacks;
using System.Linq;

namespace _Scripts.Weapons
{
    [CustomEditor(typeof(WeaponData_SO))]
    public class WeaponDataSOEditor : Editor
    {
        private static List<Type> dataComponentTypes = new List<Type>();

        private WeaponData_SO dataSO;

        private void OnEnable()
        {
            dataSO = target as WeaponData_SO;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            foreach (var dataCompType in dataComponentTypes)
            {
                if (GUILayout.Button(dataCompType.Name))
                {
                    var comp = Activator.CreateInstance(dataCompType) as ComponentData;

                    if (comp == null)
                        return;

                    dataSO.AddData(comp);
                }
            }
        }

        [DidReloadScripts]
        private static void OnRecompile()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var types = assemblies.SelectMany(assembly => assembly.GetTypes());
            var filterTypes = types.Where(
                type => type.IsSubclassOf(typeof(ComponentData)) && !type.ContainsGenericParameters && type.IsClass
            );
            dataComponentTypes = filterTypes.ToList();
        }
    }
}
