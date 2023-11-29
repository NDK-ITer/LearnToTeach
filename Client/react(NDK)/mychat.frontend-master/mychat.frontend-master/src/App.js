import { useState, useRef } from 'react';
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import SimplePeer from 'simple-peer';
import Lobby from './components/Lobby';
import Chat from './components/Chat';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';

const App = () => {
  const [connection, setConnection] = useState();
  const [messages, setMessages] = useState([]);
  const [UserName, setUserName] = useState([]);
  const videoRef = useRef();

  const joinRoom = async (UserName, IdClassroom, videoRef) => {
    try {
      const connection = new HubConnectionBuilder()
        .withUrl("https://localhost:9011/chat")
        .configureLogging(LogLevel.Information)
        .build();
        
      const peer = new SimplePeer({ initiator: true });
      navigator.mediaDevices.getUserMedia({ video: true, audio: true })
      .then(stream => {
        videoRef.current.srcObject = stream;
        peer.addStream(stream);
      })
      .catch(error => {
        console.error('Error accessing media devices:', error);
      });

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
      ? <Lobby joinRoom={joinRoom} videoRef = {videoRef}/>
      : <Chat sendMessage={sendMessage} messages={messages} users={UserName} closeConnection={closeConnection} />}
  </div>
}

export default App;
