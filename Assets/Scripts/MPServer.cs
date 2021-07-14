using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( NetworkView ) )] // сообщает Unity о том, что нам нужен компонент NetworkView. Данному компоненту NetworkStateSynchronization можно выставить Off.

public class MPServer : MonoBehaviour {
	private int playerCount = 0; // хранит количество подключенных игроков
	public int PlayersCount { get { return playerCount; } } // публичный доступ для внешних компонентов относительно количества игроков на сервере

    void OnServerInitialized() {
        // SendMessage( "SpawnPlayer", "Player Server" ); // создаем локального игрока сервера
    }

    void OnPlayerConnected( NetworkPlayer player ) {
		++playerCount;
        // networkView.RPC( "SpawnPlayer", player, "Player " + playerCount.ToString() ); // вызываем у игрока процедуру создания экземпляра префаба
    }

    void OnPlayerDisconnected( NetworkPlayer player ) {
        --playerCount; // уменьшаем количество игроков
        Network.RemoveRPCs( player ); // очищаем список процедур игрока
        Network.DestroyPlayerObjects( player ); // уничтожаем все объекты игрока
    }
}
