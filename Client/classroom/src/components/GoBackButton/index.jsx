import { Button } from '@material-ui/core';
import React from 'react';
import KeyboardReturnOutlinedIcon from '@material-ui/icons/KeyboardReturnOutlined';

function GoBackButton() {
    const goBack = () => {
        window.history.back();
    };

    return (
        <Button onClick={goBack} variant="contained" style={{ width: '12vw', borderRadius: 10 }} startIcon={<KeyboardReturnOutlinedIcon/>}>
            Trở lại
        </Button>
    );
}

export default GoBackButton;
