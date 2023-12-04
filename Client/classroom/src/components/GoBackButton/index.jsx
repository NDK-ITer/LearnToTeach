import { Button } from '@material-ui/core';
import React from 'react';

function GoBackButton() {
    const goBack = () => {
        window.history.back();
    };

    return (
        <Button onClick={goBack} variant="contained" style={{ width: '12vw', borderRadius: 10 }}>
            Trở lại
        </Button>
    );
}

export default GoBackButton;
