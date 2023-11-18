
import React from 'react';
import { Redirect, Route, Switch } from 'react-router-dom';
import './App.css';
import Login from 'components/Auth/Login';
import Register from 'components/Auth/Register';
import NotFound from 'components/NotFound';
function App() {
  return (
    <div className="app">
      <Switch>

        <Redirect from="/home" to="/" exact />
        <Route path="/SignIn" component={Login} exact />
        <Route path="/SignUp" component={Register} exact />
        <Route component={NotFound} />
      </Switch>
    </div>
  );
}

export default App;
