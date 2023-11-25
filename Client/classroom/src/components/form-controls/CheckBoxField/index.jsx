import { Checkbox } from '@material-ui/core';
import PropTypes from 'prop-types';
import React from 'react';
import { Controller } from 'react-hook-form';

CheckBoxField.propTypes = {
    form: PropTypes.object.isRequired,
    name: PropTypes.string.isRequired,
};

function CheckBoxField(props) {
    const { form, name } = props;
    const { errors } = form;
    const hasError = errors[name];

    return (
        <Controller
            name={name}
            control={form.control}
            defaultValue={false}
            render={({ onChange, onBlur, value, name }) => (
                <Checkbox
                    checked={value}
                    onChange={(e) => onChange(e.target.checked)}
                    name={name}
                />
            )}
        />
    );
}

export default CheckBoxField;
