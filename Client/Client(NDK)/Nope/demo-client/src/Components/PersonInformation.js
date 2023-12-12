import { useRef, useState, useEffect } from 'react';
import { Form, Button } from 'react-bootstrap';
import Webcam from 'react-webcam';

const PersonInformation = ({JoinClassroom}) =>{
    const [userName, setUserName] = useState("");
    const [classroom, setClassroom] = useState("");
    // const [cameraState, setCameraState] = useState(true);
    // const [audioState, setAudioState] = useState(true);
    // const [img, setImg] = useState('')
    // const videoRef = useRef(null);
    // useEffect(() => {
    //     // captureImage()
    // },[]);
    
    // const toggleCamera = () => {
    //     setCameraState(!cameraState);
    // };
    
    // const toggleAudio = () => {
    //     setAudioState(!audioState);
    // };

    // const captureImage = () => {
    //     while(videoRef !== null){
    //         setImg(videoRef.current.getScreenshot())
    //     }
    // };

    return<div>
        {/* <div>
            <Webcam 
            audio={audioState} 
            ref={videoRef}
            videoConstraints={cameraState ?{ facingMode: 'user' }:false}
            />
        
        </div>
        <div>
            <button onClick={toggleCamera}>{cameraState ? 'Off':'On'} Camera</button>
            <button onClick={toggleAudio}>{audioState ? 'Off':'On'} Mic</button>
            <button onClick={captureImage}>Capture Image</button>
        </div> */}
        <Form onSubmit={e =>{
            e.preventDefault();
        JoinClassroom({userName, classroom/*, img*/})
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