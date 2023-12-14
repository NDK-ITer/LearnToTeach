import { unwrapResult } from '@reduxjs/toolkit';
import { forgetpassword, verifyotp, resetpassword } from 'components/Auth/userSlice';
import { createTheme, ThemeProvider, Typography } from '@material-ui/core';
import Grid from '@material-ui/core/Grid';
import CssBaseline from '@material-ui/core/CssBaseline';
import Paper from '@material-ui/core/Paper';
import Box from '@material-ui/core/Box';
import { useSnackbar } from 'notistack';
import PropTypes from 'prop-types';
import React, { useState } from 'react';
import { useDispatch } from 'react-redux';
import { useHistory, Link } from 'react-router-dom';
import RestorePasswordForm from './RestorePasswordForm';
import VerifyOTPForm from '.././VerifyOTP/VerifyOTPForm'
import ResetPasswordForm from '.././ResetPassword/ResetPasswordForm';
import st from './styles.module.css'


const defaultTheme = createTheme();

RestorePassword.propTypes = {
    closeDialog: PropTypes.func,
};
function Copyright(props) {
    return (
        <Typography variant="body2" align="center" {...props}>
            {'Copyright © '}
            HKC Classroom
            {' '}
            {new Date().getFullYear()}
            {'.'}
        </Typography>
    );
}

function RestorePassword(props) {
    const dispatch = useDispatch();
    const { enqueueSnackbar } = useSnackbar();
    const [Email, setEmail] = useState({});
    const [isShownforgetpassword, setIsShownverforgetpassword] = useState(true);
    const [isShownverifyotp, setIsShownverifyotp] = useState(false);
    const [isShownresetpassword, setIsShownresetpassword] = useState(false);
    const history = useHistory();
    const handleSubmitforgetpassword = async (values) => {

        try {
            const action = forgetpassword(values);
            const resultAction = await dispatch(action);
            unwrapResult(resultAction);
            const check = resultAction.payload
            console.log(resultAction.payload)
            if (typeof check.status != 'undefined') {
                if (check.status === 1) {
                    enqueueSnackbar(check.message, { variant: 'success' });
                    setEmail(values.Email);
                    setIsShownverifyotp(true);
                    setIsShownverforgetpassword(false);
                } else {
                    enqueueSnackbar(check.message, { variant: 'error' });
                }

            }

        } catch (error) {
            console.log('Failed', error);
            enqueueSnackbar(error.message, { variant: 'error' });
        }

    };
    const handleSubmitverifyotp = async (values) => {

        try {
            values.Email = Email;
            const action = verifyotp(values);
            const resultAction = await dispatch(action);
            unwrapResult(resultAction);
            const check = resultAction.payload
            console.log(resultAction.payload)
            if (typeof check.status != 'undefined') {
                if (check.status === 1) {
                    enqueueSnackbar(check.message, { variant: 'success' });
                    setIsShownresetpassword(true);
                    setIsShownverifyotp(false);
                } else {
                    enqueueSnackbar(check.message, { variant: 'error' });
                }

            }

        } catch (error) {
            console.log('Failed', error);
            enqueueSnackbar(error.message, { variant: 'error' });
        }

    };
    const handleSubmitresetpassword = async (values) => {

        try {
            values.Email = Email;
            const action = resetpassword(values);
            const resultAction = await dispatch(action);
            unwrapResult(resultAction);
            const check = resultAction.payload
            console.log(resultAction.payload)
            if (typeof check.status != 'undefined') {
                if (check.status === 1) {
                    enqueueSnackbar(check.message, { variant: 'success' });
                    history.push('/SignIn')
                } else {
                    enqueueSnackbar(check.message, { variant: 'error' });
                }

            }

        } catch (error) {
            console.log('Failed', error);
            enqueueSnackbar(error.message, { variant: 'error' });
        }

    };

    return (
        <ThemeProvider theme={defaultTheme}>
            <Grid container component="main" className={st.main}>
                <CssBaseline />
                <Grid
                    item
                    xs={false}
                    sm={4}
                    md={7}
                    className={st.grid}
                />
                <Grid item xs={12} sm={8} md={5} component={Paper} elevation={6} square>
                    <Box
                        className={st.box}
                    >
                        <div>
                            {isShownforgetpassword && <RestorePasswordForm onSubmit={handleSubmitforgetpassword} />}
                            {isShownverifyotp && <VerifyOTPForm onSubmit={handleSubmitverifyotp} />}
                            {isShownresetpassword && <ResetPasswordForm onSubmit={handleSubmitresetpassword} />}
                        </div>
                        <Grid container>
                            <Grid item>
                                <Link to="/SignIn" variant="body2">
                                    {"Đăng nhập ngay"}
                                </Link>
                            </Grid>
                        </Grid>
                        <Copyright sx={{ mt: 5 }} />
                    </Box>
                </Grid>
            </Grid>
        </ThemeProvider>
    );
}

export default RestorePassword;
