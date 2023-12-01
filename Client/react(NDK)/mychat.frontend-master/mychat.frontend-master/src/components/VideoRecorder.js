import React, { useRef } from 'react';

const VideoRecorder = () => {
  const videoRef = useRef(null);
  const mediaRecorderRef = useRef(null);
  //const chunksRef = useRef([]);

  const startRecording = async () => {
    const stream = await navigator.mediaDevices.getUserMedia({ video: true, audio: true });
    const options = { mimeType: 'video/webm' };
    const mediaRecorder = new MediaRecorder(stream, options);
    mediaRecorderRef.current = mediaRecorder;
    videoRef.current.srcObject = stream;

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

  return (
    <div>
      <video ref={videoRef} autoPlay></video>
      <br/><button onClick={startRecording}>Start Recording</button>
      <br/><button onClick={stopRecording}>Stop Recording</button>
    </div>
  );
};

export default VideoRecorder;
