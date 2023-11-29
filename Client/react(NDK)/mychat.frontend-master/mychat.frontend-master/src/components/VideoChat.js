import React, { useEffect, useRef } from 'react';
import SimplePeer from 'simple-peer';

const VideoChat = () => {
  const videoRef = useRef();

  useEffect(() => {
    const peer = new SimplePeer({ initiator: true });

    navigator.mediaDevices.getUserMedia({ video: true, audio: true })
      .then(stream => {
        videoRef.current.srcObject = stream;
        peer.addStream(stream);
      })
      .catch(error => {
        console.error('Error accessing media devices:', error);
      });

    peer.on('signal', data => {
      // Gửi dữ liệu tín hiệu tới Hub .NET Core
      // để thiết lập kết nối với đối tác trò chuyện
    });

    peer.on('stream', stream => {
      // Nhận dữ liệu âm thanh và video từ đối tác trò chuyện
      // và hiển thị nó trong videoRef.current
    });

    // Xử lý các sự kiện khác của SimplePeer

    return () => {
      peer.destroy();
    };
  }, []);

  return (
    <div>
      <video ref={videoRef} autoPlay = {true} />
    </div>
  );
};

export default VideoChat;
