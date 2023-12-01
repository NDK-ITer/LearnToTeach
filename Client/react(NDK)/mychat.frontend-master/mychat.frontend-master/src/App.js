import { useState ,useRef} from 'react';
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
  const mediaRecorderRef = useRef(null);

  const joinRoom = async (UserName, IdClassroom) => {
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

      connection.send('SendVideoAndAudio', videoRef, mediaRecorderRef)
          .then(() => {
            console.log('Video and audio data sent to the hub');
          })

      connection.onclose(e => {
        setConnection();
        setMessages([]);
        setUsers([]);
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

  const startRecording = async () => {
    const stream = await navigator.mediaDevices.getUserMedia({ video: true, audio: true });
    videoRef.current.srcObject = stream;

    const options = { mimeType: 'video/webm' };
    const mediaRecorder = new MediaRecorder(stream, options);
    mediaRecorderRef.current = mediaRecorder;

    /*mediaRecorder.addEventListener('dataavailable', (event) => {
      chunksRef.current.push(event.data);
    });*/

    mediaRecorder.addEventListener('stop', () => {
      //const blob = new Blob(chunksRef.current, { type: 'video/webm' });
      // Do something with the recorded blob, such as sending it to a server or saving it locally
    });

    mediaRecorder.start();
  };

  const stopRecording = () => {
    mediaRecorderRef.current.stop();
    videoRef.current.srcObject.getTracks().forEach((track) => track.stop());
  };

  return <div className='app'>
    <h2>MyChat</h2>
    <hr className='line' />
    {!connection
      ? <Lobby joinRoom={joinRoom} />
      : <Chat sendMessage={sendMessage} messages={messages} users={users} closeConnection={closeConnection} />}
    <div>
      <video ref={videoRef} autoPlay></video>
      <br/><button onClick={startRecording}>Start Recording</button>
      <br/><button onClick={stopRecording}>Stop Recording</button>
    </div>
  </div>
}

export default App;
