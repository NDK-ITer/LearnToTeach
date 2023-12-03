
import React, { useEffect, useState } from 'react';
import classApi from 'api/classApi';
import Role from 'constants/role';
import { useLocalContext } from 'context';
import Grade from 'components/Grade/Grade';
import { Route, Switch, useRouteMatch } from 'react-router-dom';
import GradeDetailRoute from '../GradeDetail/GradeDetailRoute/GradeDetailRoute';
import GardeUserAnswer from '../GradeDetail/GardeUserAnswer/GardeUserAnswer';
function GradeRoute({ classData }) {
    const { user } = useLocalContext();
    const match = useRouteMatch();
    const [exercises, setexercises] = useState([])
    const [isUserHost, setisUserHost] = useState(false);
    const [userHost, setuserHost] = useState([]);
    const [classdata, setclassdata] = useState([]);
    const [isUserMember, setisUserMember] = useState(false);
    const [userlist, setuserlist] = useState([])
    useEffect(() => {
        const fetchData = async () => {
            const params = new URLSearchParams([['idClassroom', classData.idClassroom]]);
            const result = await classApi.getClassById(params);
            setclassdata(result)
            setuserlist(result.listMembers)
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
                <Route exact path={`${match.url}`}>
                    <Grade classData={classData} />
                </Route>
                {exercises.map((item, index) => (
                    <Route key={index} exact path={`${match.url}/${item.idExercise}`}>
                        <GradeDetailRoute classData={classdata} exercise={item} userHost={userHost} />
                    </Route>
                ))}
                {exercises.map(exercise => (
                    exercise.listAnswer.map(answerItem => (
                        <Route
                            key={answerItem.idMember} // Assuming idMember is unique for each item
                            path={`${match.url}/${exercise.idExercise}/answer/${answerItem.idMember}`}
                        >
                            <GardeUserAnswer classData={classdata} userHost={userHost} answerItem={answerItem} exercise={exercise} />
                        </Route>
                    ))
                ))}
            </Switch>
        </>

    );
}

export default GradeRoute;
