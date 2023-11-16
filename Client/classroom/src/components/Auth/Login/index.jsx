import { unwrapResult } from '@reduxjs/toolkit';
import { login } from 'components/Auth/userSlice';
import { useSnackbar } from 'notistack';
import { createTheme, ThemeProvider, Typography, Link } from '@material-ui/core';
import Grid from '@material-ui/core/Grid';
import CssBaseline from '@material-ui/core/CssBaseline';
import Paper from '@material-ui/core/Paper';
import Box from '@material-ui/core/Box';
import React from 'react';
import { useDispatch } from 'react-redux';
import LoginForm from '../LoginForm';
import st from './styles.module.css'

const defaultTheme = createTheme();

function Copyright(props) {
    return (
        <Typography variant="body2" align="center" {...props}>
            {'Copyright © '}
            <Link color="inherit" href="https://mui.com/">
                HKC classroom
            </Link>{' '}
            {new Date().getFullYear()}
            {'.'}
        </Typography>
    );
}

function Login(props) {
    const dispatch = useDispatch();
    const { enqueueSnackbar } = useSnackbar();

    const handleSubmit = async (values) => {
        try {
            const action = login(values);
            const resultAction = await dispatch(action);
            unwrapResult(resultAction);
            console.log(resultAction);
            enqueueSnackbar('Login successfully!!! 🎉', { variant: 'success' });
        } catch (error) {
            console.log('Failed to login:', error);
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
                            <LoginForm onSubmit={handleSubmit} />
                        </div>
                        <Grid container>
                            <Grid item xs>
                                <Link href="#" variant="body2">
                                    Quên mật khẩu?
                                </Link>
                            </Grid>
                            <Grid item>
                                <Link href="/SingnUp" variant="body2">
                                    {"Chưa có tài khoản? Đăng ký ngay"}
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

export default Login;
