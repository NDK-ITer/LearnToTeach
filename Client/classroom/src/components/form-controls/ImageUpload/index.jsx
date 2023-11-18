import { FilledInput } from "@material-ui/core";
import PropTypes from 'prop-types';
import React from 'react';
import { Controller } from 'react-hook-form';

ImageUpload.propTypes = {
    form: PropTypes.object.isRequired,
    name: PropTypes.string.isRequired,

    label: PropTypes.string,
    disabled: PropTypes.bool,
};

function ImageUpload(props) {
    const { form, name, label, disabled } = props;
    const { errors } = form;
    const hasError = errors[name];

    return (

        <Controller
            control={form.control}
            render={({ field, fieldState, name }) => (
                <FilledInput
                    {...field}
                    placeholder="Insert a file"
                    helperText={fieldState.invalid ? "File is invalid" : ""}
                    error={fieldState.invalid}
                    name={name}
                    disabled={disabled}
                />
            )}
        />

    );
}

export default ImageUpload;
