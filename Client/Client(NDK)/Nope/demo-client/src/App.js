import React from 'react';
import './App.css';
import PersonInformation from './Components/PersonInformation';
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import Webcam from 'react-webcam';

function App() {
    const [connection, setConnection] = React.useState();
    const [cameraState, setCameraState] = React.useState(true);
    const [audioState, setAudioState] = React.useState(true);
    const [img, setImg] = React.useState()
    const videoRef = React.useRef(null);
    React.useEffect(() => {
        // captureImage()
    },[]);
    
    const toggleCamera = () => {
        setCameraState(!cameraState);
    };
    
    const toggleAudio = () => {
        setAudioState(!audioState);
    };

    const captureImage = () => {
      const image = videoRef.current.getScreenshot();
      console.log(image)
      setImg(image)
    };

  
  const JoinClassroom = async ({userName, classroom})=>{
    setImg(videoRef.current.getScreenshot())  
    console.log(img)
    const connection = new HubConnectionBuilder()
        .withUrl("https://localhost:9011/chat")
        .configureLogging(LogLevel.Information)
        .build();
    await connection.start();
    await connection.invoke("JoinRoom", {userName, classroom});
    connection.stream("Counter",img)
              .subscribe({
                    next: (item) => {
                        console.log(item)
                    },
                    complete: () => {
                        console.log("done")
                    },
                    error: (err) => {
                        console.log(err)
                    },
                }
              );
    setConnection(connection);
  }
  return (
    <div className="App">
      <div>
            <Webcam 
            audio={audioState} 
            ref={videoRef}
            videoConstraints={cameraState ?{ facingMode: 'user' }:false}
            />
        </div>
        <div>
            <button onClick={toggleCamera}>{cameraState ? 'Off':'On'} Camera</button>
            <button onClick={toggleAudio}>{audioState ? 'Off':'On'} Mic</button>
            {/* <button onClick={captureImage}>Capture Image</button> */}
        </div>
      <PersonInformation JoinClassroom={JoinClassroom}/>
    </div>
  );
}

export default App;
