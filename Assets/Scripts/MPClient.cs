using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( NetworkView ) )] // сообщает Unity о том, что нам нужен компонент NetworkView. Данному компоненту NetworkStateSynchronization можно выставить Off.

public class MPClient : MonoBehaviour {
    public GameObject playerPrefab; // префаб игрока, который будет создан в процессе игры

    [RPC] // сообщает Unity о том, что данный метод можно вызвать из сети
    private void baseAction( int x, int y ) {

        Vector2 pos = new Vector2();
        pos.x = x;
        pos.y = y;

        Spawn (pos);
    }
	
	void OnDisconnectedFromServer( NetworkDisconnection info ) {
        Network.DestroyPlayerObjects( Network.player ); // удаляемся из игры
    }
}
