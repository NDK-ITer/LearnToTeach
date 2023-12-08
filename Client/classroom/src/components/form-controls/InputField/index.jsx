import { TextField } from '@material-ui/core';
import PropTypes from 'prop-types';
import React from 'react';
import { Controller } from 'react-hook-form';

InputField.propTypes = {
    form: PropTypes.object.isRequired,
    name: PropTypes.string.isRequired,

    style: PropTypes.string,
    label: PropTypes.string,
    type: PropTypes.string,
    disabled: PropTypes.bool,
    defaultValue: PropTypes.string
};

function InputField(props) {
    const { form, name, label, type, disabled, style, defaultValue } = props;
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
                    //   value={value}
                    onChange={onChange}
                    onBlur={onBlur}
                    type={type}
                    style={style}
                    defaultValue={defaultValue}
                />
            )}
        />
    );
}

export default InputField;
