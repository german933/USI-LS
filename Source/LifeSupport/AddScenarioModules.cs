using System.Linq;
using UnityEngine;

namespace LifeSupport
{
    [KSPAddon(KSPAddon.Startup.SpaceCentre, false)]
    public class AddScenarioModules : MonoBehaviour
    {
        void Start()
        {
            var game = HighLogic.CurrentGame;

            var psm = game.scenarios.Find(s => s.moduleName == typeof(LifeSupportScenario).Name);
            if (psm == null)
            {
                game.AddProtoScenarioModule(typeof(LifeSupportScenario), GameScenes.SPACECENTER,
                    GameScenes.FLIGHT, GameScenes.EDITOR);
            }
            else
            {
                if (psm.targetScenes.All(s => s != GameScenes.SPACECENTER))
                {
                    psm.targetScenes.Add(GameScenes.SPACECENTER);
                }
                if (psm.targetScenes.All(s => s != GameScenes.FLIGHT))
                {
                    psm.targetScenes.Add(GameScenes.FLIGHT);
                }
                if (psm.targetScenes.All(s => s != GameScenes.EDITOR))
                {
                    psm.targetScenes.Add(GameScenes.EDITOR);
                }
            }
        }
    }
}