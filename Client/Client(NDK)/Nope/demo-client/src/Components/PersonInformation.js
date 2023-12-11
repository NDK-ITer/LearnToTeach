import { useRef, useState,useEffect } from 'react';
import { Form, Button } from 'react-bootstrap';


const PersonInformation = ({JoinClassroom}) =>{
    const [cameraState, setCameraState] = useState("");
    const [audioState, setAudioState] = useState("");
    const [userName, setUserName] = useState("");
    const [classroom, setClassroom] = useState("");
    const videoRef = useRef(null);
    const audioRef = useRef(null);
    useEffect(() => {
        navigator.mediaDevices.getUserMedia({ video: true})
            .then((stream) => 
            {
                videoRef.current.srcObject = stream;
                setCameraState("on")
            })
            .catch((error) => 
            {
            });
        navigator.mediaDevices.getUserMedia({ audio: true})
            .then((stream) => 
            {
                audioRef.current.srcObject = stream;
                setAudioState("on")
            })
            .catch((error) => 
            {
            });
    }, []);

    
    // const JoinClassroom = async ({image, audio, userName, classroom})=>{
    //     const connection = new HubConnectionBuilder()
    //         .withUrl("https://localhost:9011/chat")
    //         .configureLogging(LogLevel.Information)
    //         .build();
    //     await connection.start().then();
    //     await connection.invoke("JoinRoom", {userName, classroom, image});
    //         setConnection(connection);
    // }

    const startVideo = () =>{
        navigator.mediaDevices.getUserMedia({ video: true})
            .then((stream) => 
            {
                videoRef.current.srcObject = stream;
                setCameraState("on")
            })
            .catch((error) => 
            {
            });
    }

    const startAudio = () =>{
        navigator.mediaDevices.getUserMedia({ audio: true})
            .then((stream) => 
            {
                audioRef.current.srcObject = stream;
                setAudioState("on")
            })
            .catch((error) => 
            {
            });
    }

    const stopVideo = () => {
        const stream = videoRef.current.srcObject;
        const tracks = stream.getTracks();
        tracks.forEach((track) => {
          track.stop();
        });
        // videoRef.current.srcObject = null;
        setCameraState("off");
    };

    const stopAudio = () => {
        const stream = audioRef.current.srcObject;
        const tracks = stream.getTracks();
        tracks.forEach((track) => {
          track.stop();
        });
        //audioRef.current.srcObject = null;
        setAudioState("off");
    };

    return<div>
        {/* <div>
            <video ref={videoRef} autoPlay></video>
            <audio ref={audioRef} autoPlay></audio>
        </div>
        {cameraState !== "on"
            ?<button type='button' onClick={startVideo}>turn on camera</button>
            :<button type='button' onClick={stopVideo}>turn off camera</button>
        }
        {audioState !== "on"
            ?<button type='button' onClick={startAudio}>turn on micro</button>
            :<button type='button' onClick={stopAudio}>turn off micro</button>
        } */}
        <Form onSubmit={e =>{
            e.preventDefault();
            JoinClassroom({userName, classroom})
        }}>
            <Form.Group>
                <Form.Control placeholder="name" onChange={e => setUserName(e.target.value)} />
                <Form.Control placeholder="room" onChange={e => setClassroom(e.target.value)} />
            </Form.Group>
            <Button variant="Successful" type='submit' disabled={!userName || !classroom}>Join Classroom Meeting</Button>
        </Form>
    </div>
}

export default PersonInformation;