
import React, { useEffect, useState } from 'react';
import { Redirect, Route, Switch } from 'react-router-dom';
import './App.css';
import { IsUserRedirect, ProtectedRoute } from "./routes/Routes";
import Login from 'components/Auth/Login';
import Register from 'components/Auth/Register';
import NotFound from 'components/NotFound';
import RestorePassword from 'components/Auth/RestorePassword';
import Drawer from 'components/Drawer'
import { useLocalContext } from "context";
import userApi from 'api/userApi';
import JoinedClasses from 'components/JoinedClasses/JoinedClasses';
import Main from 'components/Main/Main';
function App() {
  const { logged, user } = useLocalContext();
  console.log(logged);
  console.log(user);
  const [joinedClasses, setJoinedClasses] = useState([]);
  useEffect(() => {
    if (logged) {

      const fetchData = async () => {
        const userid = JSON.parse(user);
        const formData = new FormData()
        formData.append('idUser', userid.id);
        const result = await userApi.getclassroom(formData);
        setJoinedClasses(result.listClassroom);
        console.log(result)
      };

      fetchData();
    }
  }, [logged]);



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
        {joinedClasses.map((item, index) => (
          <Route key={index} exact path={`/${item.idClassroom}`}>
            <Drawer />
            <Main classData={item} />
          </Route>
        ))}
        <ProtectedRoute user={logged} path="/" exact>
          <Drawer />
          <ol className="joined">
            {joinedClasses.map((item) => (
              <JoinedClasses classData={item} key={item.idClassroom} />
            ))}
          </ol>
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
