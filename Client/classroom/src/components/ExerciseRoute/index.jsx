
import React, { useEffect, useState } from 'react';
import { Redirect, Route, Switch, useRouteMatch } from 'react-router-dom';
import Exercises from 'components/Exercises/Exercises';
import CreateExercise from 'components/CreateExercise';
import ExerciseDetail from 'components/ExerciseDetail/ExerciseDetail';
import classApi from 'api/classApi';
import SubmitExercise from 'components/SubmitExercise/SubmitExercise';
function ExerciseRoute({ classData }) {
    const match = useRouteMatch();
    const [exercises, setexercises] = useState([])
    useEffect(() => {
        const fetchData = async () => {
            const params = new URLSearchParams([['idClassroom', classData.idClassroom]]);
            const result = await classApi.getClassById(params);
            setexercises(result.listExercises);

        };
        fetchData();
    }, []);
    return (
        <Switch>

            <Route exact path={match.url}>
                <Exercises classData={classData} />
            </Route>
            <Route path={`${match.url}/create`}>
                <CreateExercise classData={classData} />
            </Route>
            {exercises.map((item, index) => (
                <Route key={index} path={`${match.url}/${item.idExercise}`}>
                    <ExerciseDetail classData={classData} exercises={item} />
                </Route>

            ))}

            {exercises.map((item, index) => (
                <Route key={index} path={`${match.url}/${item.idExercise}/sbumit`}>
                    <SubmitExercise classData={classData} exercises={item} />
                </Route>

            ))}
        </Switch>
    );
}

export default ExerciseRoute;
