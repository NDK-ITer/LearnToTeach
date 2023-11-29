import { useState } from 'react';
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import Lobby from './components/Lobby';
import Chat from './components/Chat';
import VideoChat from './components/VideoChat';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';

const App = () => {
  const [connection, setConnection] = useState();
  const [messages, setMessages] = useState([]);
  const [UserName, setUserName] = useState([]);

  const joinRoom = async (UserName, IdClassroom) => {
    try {
      const connection = new HubConnectionBuilder()
        .withUrl("https://localhost:9011/chat")
        .configureLogging(LogLevel.Information)
        .build();

      connection.on("ReceiveMessage", (UserName, message) => {
        setMessages(messages => [...messages, { UserName, message }]);
      });

      connection.on("UsersInRoom", (users) => {
        setUserName(users);
      });

      connection.onclose(e => {
        setConnection();
        setMessages([]);
        setUserName([]);
      });

      await connection.start();
      await connection.invoke("JoinRoom", { UserName, IdClassroom });
      setConnection(connection);
    } catch (e) {
      console.log(e);
    }
  }

  const sendMessage = async (message) => {
    try {
      await connection.invoke("SendMessage", message);
    } catch (e) {
      console.log(e);
    }
  }

  const closeConnection = async () => {
    try {
      await connection.stop();
    } catch (e) {
      console.log(e);
    }
  }

  return <div className='app'>
    <h2>My Chat</h2>
    <hr className='line' />
    {!connection
      ? <Lobby joinRoom={joinRoom} />
      : <Chat sendMessage={sendMessage} messages={messages} users={UserName} closeConnection={closeConnection} />}
    <div>
      <div>
        <VideoChat></VideoChat>
      </div>
    </div>
  </div>
}

export default App;
