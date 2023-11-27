import { FilledInput, TextField } from "@material-ui/core";
import PropTypes from 'prop-types';
import React from 'react';
import { Controller } from 'react-hook-form';

UploadField.propTypes = {
    form: PropTypes.object.isRequired,
    name: PropTypes.string.isRequired,

    label: PropTypes.string,
    disabled: PropTypes.bool,
    style: PropTypes.string,
};

function UploadField(props) {
    const { form, name, label, disabled, style } = props;
    const { errors } = form;
    const hasError = errors[name];

    return (

        <Controller
            name={name}
            control={form.control}
            render={({ onChange, onBlur, name }) => (
                <TextField
                    label={label}
                    placeholder=" "
                    disabled={disabled}
                    accept="*"
                    error={!!hasError}
                    helperText={errors[name]?.message}
                    name={name}
                    onChange={(e) => onChange(e.target.files)}
                    onBlur={onBlur}
                    type="file"
                    style={style}
                />
            )}
        />

    );
}

export default UploadField;
