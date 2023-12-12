// src/components/VideoCall.js
import React, { useState, useEffect, useRef } from 'react';
import * as signalR from '@microsoft/signalr';

const VideoCall = () => {
  const [connection, setConnection] = useState(null);
  const [remoteStream, setRemoteStream] = useState(null);
  const localVideoRef = useRef();
  const remoteVideoRef = useRef();

  useEffect(() => {
    const newConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:9011/chat')
      .build();

    setConnection(newConnection);

    newConnection.on('UserJoined', (userId) => {
      // Handle user joined
    });

    // Add handlers for other events

    newConnection.start().then(() => {
      navigator.mediaDevices.getUserMedia({ video: true, audio: true })
        .then((stream) => {
          localVideoRef.current.srcObject = stream;
          newConnection.invoke('JoinCall', 'userId');
        })
        .catch((error) => console.error('Error accessing media devices:', error));
    });

    return () => {
      newConnection.stop();
    };
  }, []);

  useEffect(() => {
    if (connection) {
      connection.on('ReceiveOffer', (fromUserId, offer) => {
        // Handle received offer
      });

      // Add handlers for other events
    }
  }, [connection]);

  return (
    <div>
      <video ref={localVideoRef} autoPlay playsInline muted />
      <video ref={remoteVideoRef} autoPlay playsInline />
    </div>
  );
};

export default VideoCall;
