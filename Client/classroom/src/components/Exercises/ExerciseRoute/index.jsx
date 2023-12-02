
import React, { useEffect, useState } from 'react';
import { Redirect, Route, Switch, useRouteMatch } from 'react-router-dom';
import Exercises from 'components/Exercises/Exercises';
import CreateExercise from 'components/CreateExercise';
import ExerciseDetail from 'components/Exercises/ExerciseDetail/ExerciseDetail';
import classApi from 'api/classApi';
import SubmitExercise from 'components/Exercises/SubmitExercise/SubmitExercise';
import Role from 'constants/role';
import { useLocalContext } from 'context';
import { ProtectedRouteUserHost, ProtectedRouteUserMember } from 'routes/Routes';
function ExerciseRoute({ classData }) {
    const { user } = useLocalContext();
    const match = useRouteMatch();
    const [exercises, setexercises] = useState([])
    const [isUserHost, setisUserHost] = useState(false);
    const [userHost, setuserHost] = useState([]);
    const [classdata, setclassdata] = useState([]);
    const [isUserMember, setisUserMember] = useState(false);
    useEffect(() => {
        const fetchData = async () => {
            const params = new URLSearchParams([['idClassroom', classData.idClassroom]]);
            const result = await classApi.getClassById(params);
            setclassdata(result)
            setexercises(result.listExercises);
            setuserHost(result.listMembers.find(x => x.role == Role.HOST));
            setisUserHost(result.listMembers.filter(x => x.role == Role.HOST && user.id == x.idMember).length > 0 ? true : false);
            setisUserMember(result.listMembers.filter(x => x.role == Role.MEMBER && user.id == x.idMember).length > 0 ? true : false);
        };
        fetchData();
    }, []);

    return (
        <>
            <Switch>
                <Route exact path={match.url}>
                    <Exercises classData={classData} />
                </Route>

            </Switch>
            {isUserHost && <Switch>
                <Route exact path={`${match.url}/create`}>
                    <CreateExercise classData={classData} />
                </Route>
                {exercises.map((item, index) => (
                    <Route key={index} user={isUserHost} exact path={`${match.url}/${item.idExercise}`}>
                        <ExerciseDetail classData={classdata} exercise={item} userHost={userHost} />
                    </Route>

                ))}
            </Switch>}
            {isUserMember && <Switch>
                {exercises.map((item, index) => (
                    <Route key={index} user={isUserMember} exact path={`${match.url}/${item.idExercise}/answer`}>
                        <SubmitExercise classData={classdata} exercise={item} userHost={userHost} user={user} />
                    </Route>

                ))}
            </Switch>}
        </>

    );
}

export default ExerciseRoute;
