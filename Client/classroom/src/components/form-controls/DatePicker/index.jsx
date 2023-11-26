import { TextField } from '@material-ui/core';
import PropTypes from 'prop-types';
import React from 'react';
import { Controller } from 'react-hook-form';
import dayjs from 'dayjs';
import { DatePicker, DatePickerProps } from 'antd';

DatePicker.propTypes = {
    form: PropTypes.object.isRequired,
    name: PropTypes.string.isRequired,

    label: PropTypes.string,
    placeholder: PropTypes.string,
    disabled: PropTypes.bool,
};

function DatePicker(props) {
    const { form, name, label, placeholder, disabled } = props;
    const { errors } = form;
    const hasError = errors[name];

    return (
        <Controller
            name={name}
            control={form.control}
            render={({ onChange, onBlur, value, name }) => (
                <DatePicker
                    placeholder={placeholder}
                    status={fieldState.error ? "error" : undefined}
                    name={name}
                    disabled={disabled}
                    error={!!hasError}
                    onBlur={onBlur}
                    helperText={errors[name]?.message}
                    value={value ? dayjs(value) : null}
                    onChange={(date) => {
                        onChange(date ? date.valueOf() : null);
                    }}
                />
            )}
        />
    );
}

export default DatePicker;
