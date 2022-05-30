using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using DualMountain.WorldBusiness.Facades;

namespace DualMountain.WorldBusiness.Controller {

    public class WorldSpawnController {

        public WorldSpawnController() { }

        public void Tick() {

            if (!AllWorldEventCenter.IsTriggerSpawnWorld) {
                return;
            }

            AllWorldEventCenter.SetTriggerSpawnWorld(false);

            Action action = async () => {

                // 生成场景 -> 获取世界
                string sceneName = "Mountain_Scene";
                var res = await Addressables.LoadSceneAsync(sceneName).Task;
                var worldGo = res.Scene.GetRootGameObjects()[0];
                WorldEntity worldEntity = worldGo.GetComponent<WorldEntity>();

                // 找到世界的生成角色的坐标点位
                var spawnPoint = worldEntity.SpawnerGroup.GetChild(0);

                // 生成角色
                var prefab = AllWorldAssets.WorldAssets.GetRolePrefab();
                prefab = GameObject.Instantiate(prefab);

                RoleEntity role = prefab.GetComponent<RoleEntity>();
                role.transform.position = spawnPoint.transform.position;
                role.Mesh.rotation = spawnPoint.transform.rotation;

                // 让相机看向角色
                var cm = worldEntity.CameraEntity;
                cm.Follow(role.transform);

                AllWorldRepo.SetWorldEntity(worldEntity);
                AllWorldRepo.SetRoleEntity(role);

                Debug.Log("世界生成完成");

            };

            action.Invoke();

        }

    }
}