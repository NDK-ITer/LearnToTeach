import React, { useEffect, useState } from 'react';
import { HubConnectionBuilder } from "@microsoft/signalr";

const Socket = () =>{
    const connection = new HubConnectionBuilder()
        .withUrl("http://localhost:9011/tracking")
        .build();

    // Connect to the hub
    connection.start().then(() => {
    // Invoke the SendLocationData method
    connection.invoke("SendLocationData", []);
    });

    return(
        <div>
            
        </div>
    );
}

export default Socket;