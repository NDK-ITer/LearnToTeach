import { useState } from 'react';
import './App.css';
import PersonInformation from './Components/PersonInformation';
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';

function App() {
  const [connection, setConnection] = useState();
  const JoinClassroom = async ({videoRef, audioRef, userName, classroom})=>{
    
    const connection = new HubConnectionBuilder()
        .withUrl("https://localhost:9011/chat")
        .configureLogging(LogLevel.Information)
        .build();
    await connection.start();
    await connection.invoke("JoinRoom", { userName, classroom,videoRef,audioRef});
      setConnection(connection);

  }
  return (
    <div className="App">
      <PersonInformation JoinClassroom={JoinClassroom}/>
    </div>
  );
}

export default App;
