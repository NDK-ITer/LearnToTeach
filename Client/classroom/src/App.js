
import React from 'react';
import { Redirect, Route, Switch } from 'react-router-dom';
import './App.css';
import Login from 'components/Auth/Login';
import Register from 'components/Auth/Register';
function App() {
  return (
    <div className="app">
      <Switch>

        <Redirect from="/home" to="/" exact />
        <Route path="/SignIn" component={Login} exact />
        <Route path="/SingnUp" component={Register} exact />

      </Switch>
    </div>
  );
}

export default App;
