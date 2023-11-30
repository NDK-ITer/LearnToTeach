import { TextField } from '@material-ui/core';
import PropTypes from 'prop-types';
import React from 'react';
import { Controller } from 'react-hook-form';

TextAreaField.propTypes = {
    form: PropTypes.object.isRequired,
    name: PropTypes.string.isRequired,

    label: PropTypes.string,
    disabled: PropTypes.bool,
    style: PropTypes.string,
};

function TextAreaField(props) {
    const { form, name, label, disabled, style } = props;
    const { errors } = form;
    const hasError = errors[name];

    return (

        <Controller
            name={name}
            control={form.control}
            render={({ onChange, onBlur, value, name }) => (
                <TextField
                    margin="normal"
                    variant="outlined"
                    fullWidth
                    label={label}
                    disabled={disabled}
                    error={!!hasError}
                    helperText={errors[name]?.message}
                    name={name}
                    value={value}
                    onChange={onChange}
                    onBlur={onBlur}
                    multiline
                    minRows={3}
                    style={style}
                />
            )}
        />

    );
}

export default TextAreaField;