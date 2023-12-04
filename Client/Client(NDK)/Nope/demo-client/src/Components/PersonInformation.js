import { useRef, useState,useEffect } from 'react';

const PersonInformation = () =>{
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
        const stream = navigator.mediaDevices.getUserMedia({ audio: true})
        if (videoRef.current) {
            videoRef.current.srcObject = stream;
            videoRef.current.play();
          }
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
        <div>
            <video ref={videoRef} autoPlay></video>
        </div>
        {cameraState !== "on"
            ?<button type='button' onClick={startVideo}>turn on camera</button>
            :<button type='button' onClick={stopVideo}>turn off camera</button>
        }
        {audioState !== "on"
            ?<button type='button' onClick={startAudio}>turn on micro</button>
            :<button type='button' onClick={stopAudio}>turn off micro</button>
        }
    </div>
}

export default PersonInformation;