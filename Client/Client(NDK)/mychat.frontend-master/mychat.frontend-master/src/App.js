import { useRef, useState } from 'react';
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import Lobby from './components/Lobby';
import Chat from './components/Chat';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';

const App = () => {
  const [connection, setConnection] = useState();
  const [messages, setMessages] = useState([]);
  const [users, setUsers] = useState([]);
  const videoRef = useRef(null);
  const [mediaRecorderRef, setMediaRecorderRef] = useRef(null);

  const startCamera = async () => {
    try {
      const stream = await navigator.mediaDevices.getUserMedia({ video: true });
      videoRef.current.srcObject = stream;

      // Khởi tạo MediaRecorder
      const options = { mimeType: 'video/webm' };
      mediaRecorderRef.current = new MediaRecorder(stream, options);

      // Gửi dữ liệu video đến .NET Core Hub thông qua @microsoft/signalr
      hubConnectionRef.current = new HubConnectionBuilder()
        .withUrl('https://your-net-core-hub-url')
        .build();

      hubConnectionRef.current.start().then(() => {
        mediaRecorderRef.current.ondataavailable = (event) => {
          if (event.data && event.data.size > 0) {
            hubConnectionRef.current.invoke('SendVideoData', event.data);
          }
        };

        mediaRecorderRef.current.start();
      });
    } catch (error) {
      console.error('Lỗi khi truy cập camera:', error);
    }
  };

  const joinRoom = async (UserName, IdClassroom, mediaRecorderRef) => {
    
    try {
      const connection = new HubConnectionBuilder()
        .withUrl("https://localhost:9011/chat")
        .configureLogging(LogLevel.Information)
        .build();
      
      connection.on("ReceiveMessage", (user, message) => {
        setMessages(messages => [...messages, { user, message }]);
      });

      connection.on("UsersInRoom", (users) => {
        setUsers(users);
      });

      connection.onclose(e => {
        setConnection();
        setMessages([]);
        setUsers([]);
      });

      await connection.start().then(()=>{
        mediaRecorderRef.current.onDataAvailable = (event) => {
          if (event.data && event.data.size > 0) {
            const data = event.data;
            connection.current.invoke('SendVideoData', data);
          }
        };
      });
      await connection.invoke("JoinRoom", { UserName, IdClassroom,});
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
    <h2>MyChat</h2>
    <hr className='line' />
    {!connection
      ? <Lobby joinRoom={joinRoom} />
      : <Chat sendMessage={sendMessage} messages={messages} users={users} closeConnection={closeConnection} />}
    <div>
    </div>
  </div>
}

export default App;
