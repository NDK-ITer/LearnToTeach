
import React, { useEffect, useState } from 'react';
import { Redirect, Route, Switch } from 'react-router-dom';
import './App.css';
import { IsUserRedirect, ProtectedRoute } from "./routes/Routes";
import Login from 'components/Auth/Login';
import Register from 'components/Auth/Register';
import RestorePassword from 'components/Auth/RestorePassword';
import Drawer from 'components/Drawer'
import { useLocalContext } from "context";
import userApi from 'api/userApi';
import JoinedClasses from 'components/JoinedClasses/JoinedClasses';
import Main from 'components/Main/Main';
import Community from 'components/Community/Community';
import NavigationBar from 'components/NavigationBar/NavigationBar';
import ExerciseRoute from 'components/Exercises/ExerciseRoute';
import NotFound from 'components/NotFound';
import GradeRoute from 'components/Grade/GradeRoute';
import DocumentRoute from 'components/Document/DocumentRoute/inde';
import Information from 'components/Information';
function App() {
  const { logged, user } = useLocalContext();
  console.log(logged);
  console.log(user);
  const [joinedClasses, setJoinedClasses] = useState([]);
  useEffect(() => {
    if (logged) {

      const fetchData = async () => {
        const formData = new FormData()
        formData.append('idUser', user.id);
        const result = await userApi.getclassroom(formData);
        setJoinedClasses(result.listClassroom);
        console.log(result)
      };

      fetchData();
    }
  }, [logged]);
  console.log(joinedClasses)
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
            <NavigationBar classData={item.idClassroom} />
            <Main classData={item} />
          </Route>
        ))}
        {joinedClasses.map((item, index) => (
          <Route key={index} path={`/${item.idClassroom}/exercises`}>
            <Drawer />
            <NavigationBar classData={item.idClassroom} />
            <ExerciseRoute classData={item} />
          </Route>
        ))}
        {joinedClasses.map((item, index) => (
          <Route key={index} exact path={`/${item.idClassroom}/community`}>
            <Drawer />
            <NavigationBar classData={item.idClassroom} />
            <Community classData={item} />
          </Route>
        ))}
        {joinedClasses.map((item, index) => (
          <Route key={index} path={`/${item.idClassroom}/grades`}>
            <Drawer />
            <NavigationBar classData={item.idClassroom} />
            <GradeRoute classData={item} />
          </Route>
        ))}
        {joinedClasses.map((item, index) => (
          <Route key={index} path={`/${item.idClassroom}/document`}>
            <Drawer />
            <NavigationBar classData={item.idClassroom} />
            <DocumentRoute classData={item} />
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
        {logged &&
          <Route path='/infor'>
            <Drawer />
            <Information />
          </Route>

        }
        <Redirect from="/home" to="/" exact />
        <Route path="/SignIn" component={Login} exact />
        <Route path="/SignUp" component={Register} exact />
        <Route path="/RestorePassword" component={RestorePassword} exact />
        <Route path="/NotFound" component={NotFound} exact />

      </Switch>
    </div>
  );
}

export default App;
