
import React from 'react';
import { Redirect, Route, Switch } from 'react-router-dom';
import './App.css';
import { IsUserRedirect, ProtectedRoute } from "./routes/Routes";
import Login from 'components/Auth/Login';
import Register from 'components/Auth/Register';
import NotFound from 'components/NotFound';
import RestorePassword from 'components/Auth/RestorePassword';
import Drawer from 'components/Drawer'
import { useLocalContext } from "context";
function App() {
  const { logged, user } = useLocalContext();
  console.log(logged);
  console.log(user);
  return (
    <div className="app">

      <Switch>

        <IsUserRedirect
          user={logged}
          loggedInPath="/"
          path="/SignIn"
          exact
        >
          <Login />
        </IsUserRedirect>       
        <ProtectedRoute user={logged} path="/" exact>
          <Drawer />
        </ProtectedRoute>
        <Redirect from="/home" to="/" exact />
        <Route path="/SignIn" component={Login} exact />
        <Route path="/SignUp" component={Register} exact />
        <Route path="/RestorePassword" component={RestorePassword} exact />
        <Route component={NotFound} />
      </Switch>
    </div>
  );
}

export default App;
