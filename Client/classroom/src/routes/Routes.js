import React from "react";
import { Redirect, Route } from "react-router-dom";

export function IsUserRedirect({ user, loggedInPath, children, ...rest }) {
    return (
        <Route
            {...rest}
            render={() => {
                if (!user) {
                    return children;
                }
                if (user) {
                    return <Redirect to={{ pathname: loggedInPath }} />;
                }
                return null;
            }}
        />
    );
}

export function ProtectedRoute({ user, children, ...rest }) {
    return (
        <Route
            {...rest}
            render={({ location }) => {
                if (user) {
                    return children;
                }
                if (!user) {
                    return (
                        <Redirect
                            to={{
                                pathname: "/SignIn",
                                state: { from: location },
                            }}
                        />
                    );
                }
                return null;
            }}
        />
    );
}
export function ProtectedRouteUserMember({ user, children, ...rest }) {
    return (
        <Route
            {...rest}
            render={({ location }) => {
                if (user) {
                    return children;
                }
                if (!user) {
                    return (
                        <Redirect
                            to={{
                                pathname: "/NotFound",                          
                            }}
                        />
                    );
                }
                return null;
            }}
        />
    );
}
export function ProtectedRouteUserHost({ user, children, ...rest }) {
    return (
        <Route
            {...rest}
            render={({ location }) => {
                if (user) {
                    return children;
                }
                if (user) {
                    return (
                        <Redirect
                            to={{
                                pathname: "/NotFound",
                                
                            }}
                        />
                    );
                }
                return null;
            }}
        />
    );
}