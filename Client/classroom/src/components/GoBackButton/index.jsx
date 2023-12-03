import React from 'react';

function GoBackButton() {
    const goBack = () => {
        window.history.back();
    };

    return (
        <button onClick={goBack}>
            Trở lại
        </button>
    );
}

export default GoBackButton;
