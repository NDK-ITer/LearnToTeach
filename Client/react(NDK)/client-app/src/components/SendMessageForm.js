import { useState } from "react";
import { Button, Form, FormControl, InputGroup } from "react-bootstrap";


const SendMessageForm = ({sendMessage}) =>{
    const [message, setMessages] = useState('');

    return <Form onSubmit={e=>{
            e.preventDefault();
            sendMessage(message);
            setMessages('');
        }}>
        <InputGroup>
            <FormControl placeholder='message...' onChange = {e => setMessages(e.target.value)} value={message}/>
            <InputGroup.Append>
                <Button variant='primary' type='submit' disabled={!message}/>Send
            </InputGroup.Append>
        </InputGroup>
    </Form>
}

export default SendMessageForm;