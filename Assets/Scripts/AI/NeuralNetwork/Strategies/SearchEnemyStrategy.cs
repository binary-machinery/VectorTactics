﻿using System.Collections.Generic;
using UnityEngine;

namespace Ai
{
    namespace Nn
    {
        public class SearchEnemyStrategy : Strategy
        {
            public SearchEnemyStrategy(AiTools aiTools) : base(aiTools)
            {
            }

            public override void OnEnter()
            {
                base.OnEnter();

                aiTools.terrain.SetWeightFunction(TerrainReasoning.PATROL_WEIGHT_FUNCTION);
            }

            public override void OnExit()
            {
                destination = null;
                aiTools.navigation.SetDestination(null);
            }

            protected override Vector3 GetNextDestination()
            {
                return new Vector3(
                    Random.Range(-GameDefines.MAP_WIDTH / 2.0f, GameDefines.MAP_WIDTH / 2.0f),
                    0.0f,
                    Random.Range(-GameDefines.MAP_HEIGHT / 2.0f, GameDefines.MAP_HEIGHT / 2.0f)
                    );
            }
        }
    }
}