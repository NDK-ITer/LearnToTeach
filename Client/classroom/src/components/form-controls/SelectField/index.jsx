import { Select,FormControl,InputLabel,MenuItem } from '@material-ui/core';
import PropTypes from 'prop-types';
import React from 'react';
import { Controller } from 'react-hook-form';

SelectField.propTypes = {
    form: PropTypes.object.isRequired,
    name: PropTypes.string.isRequired,

    label: PropTypes.string,
    idlabel: PropTypes.string,
    type: PropTypes.string,
    disabled: PropTypes.bool,
};

function SelectField(props) {
    const { form, name, label,idlabel, type, disabled } = props;
    const { errors } = form;
    const hasError = errors[name];

    return (
        <FormControl style={{ minWidth: 150 }} size="small">
            <InputLabel id={idlabel}>{label}</InputLabel>
            <Controller
                name={name}
                control={form.control}
                render={({ onChange, onBlur, value, name }) => (
                    <Select
                        disabled={disabled}
                        error={!!hasError}
                        helperText={errors[name]?.message}
                        name={name}
                        value={value}
                        onChange={onChange}
                        onBlur={onBlur}
                    >
                        <MenuItem value={0}>0</MenuItem>
                        <MenuItem value={1}>1</MenuItem>
                        <MenuItem value={2}>2</MenuItem>
                        <MenuItem value={3}>3</MenuItem>
                        <MenuItem value={4}>4</MenuItem>
                        <MenuItem value={5}>5</MenuItem>
                        <MenuItem value={6}>6</MenuItem>
                        <MenuItem value={7}>7</MenuItem>
                        <MenuItem value={8}>8</MenuItem>
                        <MenuItem value={9}>9</MenuItem>
                        <MenuItem value={10}>10</MenuItem>
                    </Select>
                )}
            />
        </FormControl>
    );
}

export default SelectField;
