using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using static Ky;
using static UnityEngine.Mathf;

public class Main : MonoBehaviour {

  [SerializeField] private Transform mapContainer;
  [SerializeField] private Transform unitContainer;
  [SerializeField] private Camera camera;
  [SerializeField] private WorldManager worldManager;

  private Map? map = null;

  private GameObject[] playerUnits = new GameObject[4];

  private void Start() {

    worldManager.Init();
    //initMap("azaza");
  }

  private void initMap(string mapName) {
    map = new Map(mapContainer, mapName);
    map.generate();

    for (var i = 0; i < 4; i++) playerUnits[i] = null;

    unitContainer.DestroyChildren();
    for (var i = 0; i < 4; i++) {
      playerUnits[i] = Instantiate(R.player, unitContainer);
      playerUnits[i].transform.localPosition = new Vector3(map.players[i].spawn.x + .5f, map.players[i].spawn.y + .5f, -.5f);
    }
  }

  private void Update() {
    //camera.transform.localPosition = new Vector3(35, 35, 0);
    // camera.orthographicSize = 15f;
  }
}
