
import React, { useEffect, useState } from 'react';
import classApi from 'api/classApi';
import Role from 'constants/role';
import { useLocalContext } from 'context';
import { Route, Switch, useRouteMatch } from 'react-router-dom';
import GradeDetail from '../GradeDetail';
import GardeUserAnswer from '../GardeUserAnswer/GardeUserAnswer';
function GradeDetailRoute({ classData, exercise, userHost }) {
    const { user } = useLocalContext();
    const match = useRouteMatch();
    const [userlist, setuserlist] = useState([])
    useEffect(() => {
        const fetchData = async () => {
            const params = new URLSearchParams([['idClassroom', classData.idClassroom]]);
            const result = await classApi.getClassById(params);
            setuserlist(result.listExercises.find(ex => ex.idExercise === exercise.idExercise).listAnswer)
        };
        fetchData();
    }, []);
    console.log(userlist);
    return (
        <>
            <Switch>
                <Route exact path={`${match.url}`}>
                    <GradeDetail classData={classData} exercise={exercise} userHost={userHost} />
                </Route>
            </Switch>
        </>

    );
}

export default GradeDetailRoute;
