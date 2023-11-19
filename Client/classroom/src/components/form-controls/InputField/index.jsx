import { TextField } from '@material-ui/core';
import PropTypes from 'prop-types';
import React from 'react';
import { Controller } from 'react-hook-form';

InputField.propTypes = {
    form: PropTypes.object.isRequired,
    name: PropTypes.string.isRequired,

    label: PropTypes.string,
    type: PropTypes.string,
    disabled: PropTypes.bool,
};

function InputField(props) {
    const { form, name, label, type, disabled } = props;
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
                    type={type}
                />
            )}
        />
    );
}

export default InputField;
